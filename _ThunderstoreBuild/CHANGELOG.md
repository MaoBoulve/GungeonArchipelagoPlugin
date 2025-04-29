# 0.1.1
Major update adding multiple new features tied to APWorld update
- Updating expected APWorld to V0.1.1
- Paradox Mode implemented
	- Character swap restricted until corresponding item received for character
- Reverse Curse implemented
	- Gain 8 curse (either after 1 Past is cleared or immediately)
	- Item Check to reduce curse created "Reverse Curse Reversal"
- Shop items can now be replaced by APItem
- Chest items now only replace every other chest
- Pedestal items are now replaced by APItem

# 0.0.8
Debugging!

- When an exception occurs a crash log is placed in the BepInEx root folder
- Entering 'debugtool fullDebug' will also write the crash log
- Reload with the ArchipelaGun swaps between the first 6 characters
        - Setting up for future Archipelago item check


# 0.0.7
Multiclient Newtonsoft.Json exception fix. Now mod should only have ArchipelaGun.dll and c-wspp.dll

# 0.0.6
Major fixes around Multiclient & websocket issues

- Using async calls for server pulls to reduce performance hitch
- Fixes items not being received, items not sent synced up will be sent at room clears
- Additional debug commands under the 'debugtools' category in the Mod Menu
- Disconnect command
- Fallback cases on data being set below 0

# 0.0.5
- Fix to bug breaking core behavior on returning to Breach
- Fix to bug breaking core behavior on restarting a Run
- Fix to co-op breaking functionality
- Deathlink now properly kills Player 2, then Player 1
- Disconnect archipelago command implemented
- Added Deathlink toggle
- Added images to main page readme
	- Archipelagun, lil buddy!

# 0.0.4
- Renaming to match github versioning
- Hotfix for sprites layout

# 0.0.1
- Initial upload
