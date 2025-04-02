using BepInEx.Logging;
using SGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace ArchiGungeon.Archipelago
{
    public delegate void MenuEvent();

    // Front end Archipelago menu
    public class ArchipelagoGUI : ETGModMenu
    {
        // bool & event for pausing gameplay & user control
        public static bool IsOpen;
        public static MenuEvent OnMenuClose;
        public static MenuEvent OnMenuOpen;

        // Hook into ETG console logger
        private static ManualLogSource Logger = ETGModConsole.Logger;


        // Text input vars
        private List<string> lastCommands = new List<string>();
        private int currentCommandIndex = -1;
        protected static char[] _SplitArgsCharacters = new char[1] { ' ' };

        // Backend class for bridging Gungeon to Archipelago
        private static ArchipelConsoleCommandParser archipelagoCommands = new();

        // The current instance of the GUI class
        public static ArchipelagoGUI Instance { get; protected set; }

        // Command parsing helpers
        private static bool isCombiningCommands = false;

        public ArchipelagoGUI()
        {
            Instance = this;
            Logger = BepInEx.Logging.Logger.CreateLogSource("Archipelago Mod Menu");
            return;
        }

        public override void Start()
        {
            InitGUI();   
        }

        private void InitGUI()
        {
            base.GUI = new SGroup
            {
                Visible = false,
                OnUpdateStyle = delegate (SElement elem)
                {
                    elem.Fill(100); //empty
                    elem.Position = new Vector2(elem.Position.x, elem.Position.y);
                    //elem.Size = new Vector2(elem.Size.x, elem.Size.y - 100f);
                },
                Children =
            {   
                // Initial text elements
                (SElement)new SGroup
                {
                    Background = new UnityEngine.Color(0f, 153f, 0f, 0f), //0,0,0
                    AutoLayout = (SGroup g) => g.AutoLayoutVertical,
                    ScrollDirection = SGroup.EDirection.Vertical,
                    OnUpdateStyle = delegate(SElement elem)
                    {
                        elem.Fill();
                        elem.Size -= new Vector2(0f, elem.Backend.LineHeight - 4f);
                    },
                    Children =
                    {
                        (SElement)new SLabel("==== <color=#ffffffff>Archipelago</color> Gungeon Menu ====")
                        {
                            Foreground = UnityEngine.Color.green
                        },
                        (SElement)new SLabel("Press ESC at any time to close")
                        {
                            Foreground = UnityEngine.Color.white
                        },

                        (SElement)new SLabel("The following commands are available:")
                        {
                            Foreground = UnityEngine.Color.green
                        },


                        // CONNECT
                        (SElement)new SLabel($"<color=#f4d03f>{ArchipelConsoleCommandParser.connectCommandText}</color> [IP address] [port] [player slot]")
                        {
                            Foreground = UnityEngine.Color.white
                        },
                        (SElement)new SLabel("    Connect to Archipelago")
                        {
                            Foreground = UnityEngine.Color.green
                        },

                        // RETRIEVE
                        (SElement)new SLabel($"<color=#f4d03f>{ArchipelConsoleCommandParser.retrieveCommandText}</color>")
                        {
                            Foreground = UnityEngine.Color.white
                        },
                        (SElement)new SLabel("    Collect items from server (once per Run)")
                        {
                            Foreground = UnityEngine.Color.green
                        },

                        // GOAL

                        (SElement)new SLabel($"<color=#f4d03f>{ArchipelConsoleCommandParser.progressCommandText}</color>")
                        {
                            Foreground = UnityEngine.Color.white
                        },
                        (SElement)new SLabel("    Display game completion goal progress")
                        {
                            Foreground = UnityEngine.Color.green
                        },


                        (SElement)new SLabel($"<color=#f4d03f>{ArchipelConsoleCommandParser.spawnAPItemCommandText}</color>")
                        {
                            Foreground = UnityEngine.Color.yellow
                        },
                        (SElement)new SLabel("    (DEBUG) Spawn an AP Item")
                        {
                            Foreground = UnityEngine.Color.green
                        },
                        (SElement)new SLabel("")
                        {
                            Foreground = UnityEngine.Color.green
                        }

                    }
                },

                // Text entry field, with hooks for up/down/escape/submit
                (SElement)new STextField
                {
                    OnUpdateStyle = delegate(SElement elem)
                    {
                        elem.Size.x = elem.Parent.InnerSize.x;
                        elem.Position.x = 0f;
                        elem.Position.y = elem.Parent.InnerSize.y - elem.Size.y;
                    },

                    OverrideTab = true,
                    OnKey = delegate(STextField field, bool keyDown, KeyCode keyCode)
                    { 
                        ParseKeyboardInput(field, keyDown, keyCode);
                    },
                    OnSubmit = delegate(STextField elem, string text)
                    {
                        // Add new entry to entry list
                        int index = lastCommands.Count - 1;
                        if (text != string.Empty && (lastCommands.Count <= 0 || text != lastCommands[index]))
                        {
                            lastCommands.Add(text);
                        }
                        currentCommandIndex = lastCommands.Count;

                        // Parse command
                        if (text.Length != 0)
                        {
                            ParseCommandForArchipelago(text.Trim());
                        }
                    }
                }
            }
            };

            return;
        }


        protected virtual SLabel _Log(object text, Texture image)
        {
            Logger.LogMessage(text);
            SLabel sLabel = new SLabel(text.ToString())
            {
                Icon = image
            };
            base.GUI[0].Children.Add(sLabel);
            ((SGroup)base.GUI[0]).ScrollPosition.y = float.MaxValue;
            return sLabel;
        }

        // Log internally in Archipelago & ETGModConsole menus
        public static SLabel ConsoleLog(object text, bool debuglog = false)
        {
            if (Instance == null)
            {
                new ArchipelagoGUI();
            }

            SLabel result = Instance?._Log(text, null);
            if (debuglog)
            {
                Debug.Log(text);
            }

            ETGModConsole.Log(text);

            return result;
        }

        private string[] SplitArgs(string args)
        {
            return args.Split(_SplitArgsCharacters, StringSplitOptions.RemoveEmptyEntries);
        }

        private void ParseKeyboardInput(STextField field, bool keyDown, KeyCode keyCode)
        {
            if ((keyDown && (keyCode != 0) == false))
            {
                return;
            }

            if (keyCode == ETGModGUI.CloseAllKey || keyCode == KeyCode.Escape)
            {
                OnClose();
                return;
            }

            if (keyCode == ETGModGUI.ConsolePreviousCommand || keyCode == ETGModGUI.ConsoleNextCommand)
            {
                if (lastCommands.Count <= 0)
                {
                    field.Text = string.Empty;
                    return;
                }

                if (keyCode == ETGModGUI.ConsolePreviousCommand)
                {
                    currentCommandIndex--;
                    if (currentCommandIndex <= 0)
                    {
                        currentCommandIndex = 0;
                    }
                }
                else if (keyCode == ETGModGUI.ConsoleNextCommand)
                {
                    currentCommandIndex++;
                    if (currentCommandIndex >= lastCommands.Count)
                    {
                        currentCommandIndex = lastCommands.Count - 1;
                    }
                }

                field.Text = lastCommands[currentCommandIndex];
                field.MoveCursor(field.Text.Length);
            }

            return;
        }

        protected void ParseCommandForArchipelago(string command)
        {
            string[] commandInputs;
            string commandGroup;

            if (isCombiningCommands)
            {
                // grab prior command
                List<string> bulkCommand = SplitArgs(lastCommands.Last<string>()).ToList<string>();
                commandGroup = bulkCommand[0];

                bulkCommand.Add(command);

                commandInputs = bulkCommand.Skip(1).ToArray<string>();

                isCombiningCommands = false;
            }

            else
            {   // Command group, sub command group
                string[] array = SplitArgs(command);

                commandInputs = array.Skip(1).ToArray();
                commandGroup = array[0];

            }
            

            // CONNECT: IP, port, player slot

            switch (commandGroup)
            {
                case ArchipelConsoleCommandParser.connectCommandText:
                {

                    if (commandInputs.Length > 3)
                    {
                        ConsoleLog("ERROR: Too many inputs - [Connect] expected input [IP Address] [Port] [Player Slot Name]");
                        ConsoleLog("If name contains spaces, please use [connect] [IP Address] [Port] option");
                        return;
                    }
                    else if (commandInputs.Length != 2)
                    {
                        ConsoleLog("Please enter player slot name");
                        isCombiningCommands = true;

                        return;

                    }

                    string connectCommand = $"{ArchipelConsoleCommandParser.archipelagoCommandGroup} {ArchipelConsoleCommandParser.connectCommandText} " + command;
                    archipelagoCommands.SendETGConsoleCommand(connectCommand);


                    //TODO: handle password entry

                    break;
                }

                case ArchipelConsoleCommandParser.retrieveCommandText:
                {
                    string retrieveCommand = $"{ArchipelConsoleCommandParser.archipelagoCommandGroup} {ArchipelConsoleCommandParser.retrieveCommandText} ";
                    archipelagoCommands.SendETGConsoleCommand(retrieveCommand);
                    break;
                }

                case ArchipelConsoleCommandParser.progressCommandText:
                {
                    string goalCommand = $"{ArchipelConsoleCommandParser.archipelagoCommandGroup} {ArchipelConsoleCommandParser.progressCommandText} ";
                    archipelagoCommands.SendETGConsoleCommand(goalCommand);
                    break;
                }

                case ArchipelConsoleCommandParser.spawnAPItemCommandText:
                {
                    string spawnCommand = $"{ArchipelConsoleCommandParser.archipelagoCommandGroup} {ArchipelConsoleCommandParser.spawnAPItemCommandText} ";
                    archipelagoCommands.SendETGConsoleCommand(spawnCommand);
                    break;
                }

                default:
                    ConsoleLog($"ERROR: '{commandGroup}' not recognized as a command");
                    break;
            }
            
            return;
        }


        public override void Update()
        {
            if (IsOpen)
            {
                // keep focus on UI while open
                base.GUI[1].Focus();
            }

            return;
        }

        public override void OnOpen()
        {
            base.OnOpen();
            base.GUI[1].Focus();
            IsOpen = true;

            return;
        }


        public override void OnClose()
        {
            base.OnClose();
            OnMenuClose.Invoke();
            IsOpen = false;

            return;
        }


    }


    public class ArchipelConsoleCommandParser
    {

        // Summary:
        // The current instance of the console.
        public static ArchipelConsoleCommandParser Instance { get; protected set; }

        public static Dictionary<string, int> slot_data = new Dictionary<string, int>();
        public const string archipelagoCommandGroup = "archie";
        public const string connectCommandText = "connect";
        public const string retrieveCommandText = "retrieve";
        public const string progressCommandText = "progress";
        public const string spawnAPItemCommandText = "APspawn";


        // Instance archipelago commands inside ETGModConsole
        public ArchipelConsoleCommandParser() 
        {
            Instance = this;

            // Add commands for use by base ETGModConsole
            ETGModConsole.CommandDescriptions.Add($"{archipelagoCommandGroup} {connectCommandText}", "Input [ip], [port], [player name] seperated by spaces");
            ETGModConsole.Commands.AddGroup($"{archipelagoCommandGroup}");

            new SessionHandler();

            // Hook archipelago commands to ETG mod console delegate events
            ETGModConsole.Commands.GetGroup($"{archipelagoCommandGroup}").AddGroup($"{connectCommandText}", delegate (string[] args)
            {
                if (args.Length > 3)
                {
                    // arg[0] is the command group for archipelago so START on args[1]
                    SessionHandler.Instance.ArchipelagoConnect(args[1], args[2], args[3]);
                }
                else
                {
                    SessionHandler.Instance.ArchipelagoConnect(args[0], args[1], args[2]);
                }

            });

            ETGModConsole.Commands.GetGroup($"{archipelagoCommandGroup}").AddGroup($"{retrieveCommandText}", delegate (string[] args)
            {
                SessionHandler.RetrieveServerItems();

            });

            ETGModConsole.Commands.GetGroup($"{archipelagoCommandGroup}").AddGroup($"{progressCommandText}", delegate (string[] args)
            {
                SessionHandler.OutputGameGoalStatus();

            });

            ETGModConsole.Commands.GetGroup($"{archipelagoCommandGroup}").AddGroup($"{spawnAPItemCommandText}", delegate (string[] args)
            {
                ArchipelagoGungeonBridge.SpawnAPItem(1);

            });
        }

        public void SendETGConsoleCommand(string command)
        {
            ETGModConsole.Instance?.ParseCommand(command);
        }

    }

}
