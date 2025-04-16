using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    ETGModConsole.Spawn(new string[] { "rat", "100" });
                    break;
                case 1:

                    EffectsController.PlayCurseVFX();
                    // mimic gun
                    playerToSpawnOn.AcquirePuzzleItem(PickupObjectDatabase.GetByName("mimic_gun"));
                    
                    break;
                case 2:
                    EffectsController.PlayCurseVFX();
                    // add curse
                    playerToSpawnOn.CurrentCurseMeterValue += 1;

                    break;
                case 3:
                    EffectsController.PlayCurseVFX();
                    // drop ur gun!!
                    playerToSpawnOn.ForceDropGun(playerToSpawnOn.CurrentGun);
                    break;
                case 4:
                    EffectsController.PlayCurseVFX();
                    playerToSpawnOn.IncreaseFire(0.5f);
                    break;
                case 5:
                    EffectsController.PlayCurseVFX();
                    playerToSpawnOn.CurrentPoisonMeterValue += 0.5f;
                    TrapStatModifier.CheckToPoison(playerToSpawnOn);
                    break;
                case 6:
                    EffectsController.PlayCurseVFX();
                    playerToSpawnOn.CurrentCurseMeterValue += 0.5f;
                    TrapStatModifier.CheckToCurse(playerToSpawnOn);
                    break;
                case 7:
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