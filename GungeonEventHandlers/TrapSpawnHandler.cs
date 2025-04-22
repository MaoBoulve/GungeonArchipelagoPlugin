using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchiGungeon.DebugTools;

namespace ArchiGungeon.GungeonEventHandlers
{
    public class TrapSpawnHandler
    {
        public static bool IsSpawnValid { get; protected set; } = true;

        public static void SetCanSpawn(bool newState)
        {
            IsSpawnValid = newState;
            return;
        }

        public static void SpawnTrapByCase(int trapCase)
        {
            if (IsSpawnValid == false)
            {
                return;
            }

            PlayerController playerToSpawnOn = GungeonPlayerEventListener.GetFirstAlivePlayer();
            if(playerToSpawnOn == null)
            {
                return;
            }

            switch (trapCase)
            {
                case 0:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: Rats??");
                    ETGModConsole.Spawn(new string[] { "rat", "100" });
                    break;
                case 1:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: Mimic gun");

                    EffectsController.PlayCurseVFX();
                    // mimic gun
                    //playerToSpawnOn.AcquirePuzzleItem(PickupObjectDatabase.GetByName("mimic_gun"));

                    GungeonPlayerEventListener.GetFirstAlivePlayer().GiveItem("mimic_gun");

                    break;
                case 2:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: +1 Curse");

                    EffectsController.PlayCurseVFX();
                    // add curse
                    playerToSpawnOn.CurrentCurseMeterValue += 1;

                    break;
                case 3:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: Drop gun jumpscare");

                    EffectsController.PlayCurseVFX();
                    // drop ur gun!!
                    playerToSpawnOn.ForceDropGun(playerToSpawnOn.CurrentGun);
                    break;
                case 4:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: Fire!!");

                    EffectsController.PlayCurseVFX();
                    playerToSpawnOn.IncreaseFire(0.5f);
                    break;
                case 5:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: Poison");

                    EffectsController.PlayCurseVFX();
                    playerToSpawnOn.CurrentPoisonMeterValue += 0.5f;
                    TrapStatModifier.CheckToPoison(playerToSpawnOn);
                    break;
                case 6:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: Curse pot");

                    EffectsController.PlayCurseVFX();
                    playerToSpawnOn.CurrentCurseMeterValue += 0.5f;
                    TrapStatModifier.CheckToCurse(playerToSpawnOn);
                    break;
                case 7:
                    ArchDebugPrint.DebugLog(DebugCategory.TrapHandling, $"Sending trap: Shelleton, maybe");

                    EffectsController.PlayCurseVFX();
                    ETGModConsole.Spawn(new string[] { "shelleton", "3" });
                    break;

                default:
                    break;

            }

            return;
        }
    
    }

    public class TrapStatModifier
    {
        public static void CheckToCurse(PlayerController targetPlayer)
        {
            if(targetPlayer.CurrentCurseMeterValue >= 1.0f)
            {
                targetPlayer.CurrentCurseMeterValue = 0f;
                StatModifier statMod = new StatModifier();
                statMod.amount = 1f;
                statMod.modifyType = StatModifier.ModifyMethod.ADDITIVE;

                statMod.statToBoost = PlayerStats.StatType.Curse;

                targetPlayer.ownerlessStatModifiers.Add(statMod);
                targetPlayer.stats.RecalculateStats(targetPlayer);
            }
            return;
        }

        public static void CheckToPoison(PlayerController targetPlayer)
        {
            if (targetPlayer.CurrentPoisonMeterValue >= 1.0f)
            {
                targetPlayer.CurrentPoisonMeterValue -= 1f;
                targetPlayer.stats.RecalculateStats(targetPlayer);
            }
            return;
        }

    }
}

/*
                switch (num6)
                {
                    case 0L:
                        ETGModConsole.Spawn(new string[] { "rat", "100" });
                        break;
                    case 1L:
                        ETGModConsole.Spawn(new string[] { "shelleton", "3" });
                        break;
                    case 2L:
                        ETGModConsole.Spawn(new string[] { "shotgrub", "3" });
                        break;
                    case 3L:
                        ETGModConsole.Spawn(new string[] { "tanker", "12" });
                        ETGModConsole.Spawn(new string[] { "professional", "2" });
                        break;
                    case 4L:
                        ETGModConsole.Spawn(new string[] { "hollowpoint", "6" });
                        ETGModConsole.Spawn(new string[] { "bombshee", "2" });
                        ETGModConsole.Spawn(new string[] { "gunreaper", "1" });
                        break;
                    case 5L:
                        ETGModConsole.Spawn(new string[] { "gun_nut", "1" });
                        ETGModConsole.Spawn(new string[] {"chain_gunner", "2"});
                        ETGModConsole.Spawn(new string[] { "spectral_gun_nut", "3" });
                        break;
                    case 6L:
                        ETGModConsole.Spawn(new string[] { "jamerlengo", "3" });
                        ETGModConsole.Spawn(new string[] { "spirat", "15" });
                        break;
                    case 7L:
                        GameManager.Instance.Dungeon.SpawnCurseReaper();
                        break;
                }
                */