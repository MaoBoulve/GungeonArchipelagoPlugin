using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using BepInEx.Bootstrap;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class MagickeCauldron : PlayerItem
{
	public static GameObject overheadder;

	public static List<AIActor> enemiesToReRoll;

	public static List<AIActor> enemiesToPostMogModify;

	public static List<string> chaosEnemyPalette;

	public static List<string> ExpandTheGungeonChaosPalette;

	public static List<string> FrostAndGunfireChaosPalette;

	public static List<string> PlanetsideOfGunymedeChaosPalette;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<MagickeCauldron>("Alchemy Crucible", "Philosopher's Own", "Magically changes enemies into other enemies from the same floor.\nBest used on strong enemies, where the only way forwards is down.\n\nDon't get used to yourself. You're gonna have to change.", "magickecauldron_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 150f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)2;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		try
		{
			List<string> currentFloorEnemyPalette = FloorAndGenerationToolbox.CurrentFloorEnemyPalette;
			List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies == null)
			{
				return;
			}
			enemiesToReRoll.Clear();
			enemiesToPostMogModify.Clear();
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor item = activeEnemies[i];
				enemiesToReRoll.Add(item);
			}
			foreach (AIActor item2 in enemiesToReRoll)
			{
				string text = "01972dee89fc4404a5c408d50007dad5";
				if (currentFloorEnemyPalette.Count > 0)
				{
					text = BraveUtility.RandomElement<string>(currentFloorEnemyPalette);
				}
				if (CustomSynergies.PlayerHasActiveSynergy(user, "I CAN DO ANYTHING"))
				{
					List<string> list = GenerateChaosPalette();
					text = BraveUtility.RandomElement<string>(list);
				}
				if (Object.op_Implicit((Object)(object)((Component)item2).gameObject.GetComponent<ExplodeOnDeath>()))
				{
					Object.Destroy((Object)(object)((Component)item2).gameObject.GetComponent<ExplodeOnDeath>());
				}
				if (!((BraveBehaviour)item2).healthHaver.IsVulnerable)
				{
					((BraveBehaviour)item2).healthHaver.IsVulnerable = true;
				}
				item2.Transmogrify(EnemyDatabase.GetOrLoadByGuid(text), (GameObject)ResourceCache.Acquire("Global VFX/VFX_Item_Spawn_Poof"));
			}
			List<AIActor> activeEnemies2 = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies2 != null)
			{
				for (int j = 0; j < activeEnemies2.Count; j++)
				{
					AIActor val = activeEnemies2[j];
					enemiesToPostMogModify.Add(val);
					if (val.IsTransmogrified && CustomSynergies.PlayerHasActiveSynergy(user, "A Moste Accursed Brew"))
					{
						AIActorDebuffEffect val2 = new AIActorDebuffEffect();
						val2.HealthMultiplier = 0.5f;
						val2.CooldownMultiplier = 1f;
						val2.SpeedMultiplier = 1f;
						val2.KeepHealthPercentage = true;
						ref GameObject overheadVFX = ref ((GameActorEffect)val2).OverheadVFX;
						Object obj = ResourceCache.Acquire("Global VFX/VFX_Debuff_Status");
						overheadVFX = (GameObject)(object)((obj is GameObject) ? obj : null);
						((GameActorEffect)val2).duration = 1000000f;
						((GameActor)val).ApplyEffect((GameActorEffect)(object)val2, 1f, (Projectile)null);
					}
				}
			}
			foreach (AIActor item3 in enemiesToPostMogModify)
			{
				HandlePostTransmogLootEnemies(item3);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public static List<string> GenerateChaosPalette()
	{
		List<string> list = new List<string>();
		list.AddRange(chaosEnemyPalette);
		if (Chainloader.PluginInfos.ContainsKey("ApacheThunder.etg.ExpandTheGungeon"))
		{
			list.AddRange(ExpandTheGungeonChaosPalette);
		}
		if (Chainloader.PluginInfos.ContainsKey("kp.etg.frostandgunfire"))
		{
			list.AddRange(FrostAndGunfireChaosPalette);
		}
		if (Chainloader.PluginInfos.ContainsKey("somebunny.etg.planetsideofgunymede"))
		{
			list.AddRange(PlanetsideOfGunymedeChaosPalette);
		}
		return list;
	}

	public void HandlePostTransmogLootEnemies(AIActor enemy)
	{
		try
		{
			if (enemy.EnemyGuid == EnemyGuidDatabase.Entries["spent"] && Object.op_Implicit((Object)(object)((Component)enemy).GetComponent<SpawnEnemyOnDeath>()))
			{
				Object.Destroy((Object)(object)((Component)enemy).GetComponent<SpawnEnemyOnDeath>());
			}
			if (enemy.IsTransmogrified)
			{
				enemy.IsTransmogrified = false;
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies != null)
		{
			return true;
		}
		return false;
	}

	static MagickeCauldron()
	{
		Object obj = ResourceCache.Acquire("Global VFX/VFX_Debuff_Status");
		overheadder = (GameObject)(object)((obj is GameObject) ? obj : null);
		enemiesToReRoll = new List<AIActor>();
		enemiesToPostMogModify = new List<AIActor>();
		chaosEnemyPalette = new List<string>
		{
			EnemyGuidDatabase.Entries["bullet_kin"],
			EnemyGuidDatabase.Entries["ak47_bullet_kin"],
			EnemyGuidDatabase.Entries["bandana_bullet_kin"],
			EnemyGuidDatabase.Entries["veteran_bullet_kin"],
			EnemyGuidDatabase.Entries["treadnaughts_bullet_kin"],
			EnemyGuidDatabase.Entries["minelet"],
			EnemyGuidDatabase.Entries["cardinal"],
			EnemyGuidDatabase.Entries["shroomer"],
			EnemyGuidDatabase.Entries["ashen_bullet_kin"],
			EnemyGuidDatabase.Entries["mutant_bullet_kin"],
			EnemyGuidDatabase.Entries["fallen_bullet_kin"],
			EnemyGuidDatabase.Entries["chance_bullet_kin"],
			EnemyGuidDatabase.Entries["key_bullet_kin"],
			EnemyGuidDatabase.Entries["hooded_bullet"],
			EnemyGuidDatabase.Entries["red_shotgun_kin"],
			EnemyGuidDatabase.Entries["blue_shotgun_kin"],
			EnemyGuidDatabase.Entries["veteran_shotgun_kin"],
			EnemyGuidDatabase.Entries["mutant_shotgun_kin"],
			EnemyGuidDatabase.Entries["executioner"],
			EnemyGuidDatabase.Entries["ashen_shotgun_kin"],
			EnemyGuidDatabase.Entries["shotgrub"],
			EnemyGuidDatabase.Entries["sniper_shell"],
			EnemyGuidDatabase.Entries["professional"],
			EnemyGuidDatabase.Entries["gummy"],
			EnemyGuidDatabase.Entries["skullet"],
			EnemyGuidDatabase.Entries["skullmet"],
			EnemyGuidDatabase.Entries["creech"],
			EnemyGuidDatabase.Entries["hollowpoint"],
			EnemyGuidDatabase.Entries["bombshee"],
			EnemyGuidDatabase.Entries["rubber_kin"],
			EnemyGuidDatabase.Entries["tazie"],
			EnemyGuidDatabase.Entries["king_bullat"],
			EnemyGuidDatabase.Entries["grenade_kin"],
			EnemyGuidDatabase.Entries["dynamite_kin"],
			EnemyGuidDatabase.Entries["arrow_head"],
			EnemyGuidDatabase.Entries["blobulon"],
			EnemyGuidDatabase.Entries["blobuloid"],
			EnemyGuidDatabase.Entries["blobulin"],
			EnemyGuidDatabase.Entries["poisbulon"],
			EnemyGuidDatabase.Entries["poisbuloid"],
			EnemyGuidDatabase.Entries["poisbulin"],
			EnemyGuidDatabase.Entries["blizzbulon"],
			EnemyGuidDatabase.Entries["leadbulon"],
			EnemyGuidDatabase.Entries["poopulon"],
			EnemyGuidDatabase.Entries["bloodbulon"],
			EnemyGuidDatabase.Entries["skusket"],
			EnemyGuidDatabase.Entries["bookllet"],
			EnemyGuidDatabase.Entries["blue_bookllet"],
			EnemyGuidDatabase.Entries["green_bookllet"],
			EnemyGuidDatabase.Entries["gigi"],
			EnemyGuidDatabase.Entries["muzzle_wisp"],
			EnemyGuidDatabase.Entries["muzzle_flare"],
			EnemyGuidDatabase.Entries["cubulon"],
			EnemyGuidDatabase.Entries["chancebulon"],
			EnemyGuidDatabase.Entries["cubulead"],
			EnemyGuidDatabase.Entries["apprentice_gunjurer"],
			EnemyGuidDatabase.Entries["gunjurer"],
			EnemyGuidDatabase.Entries["high_gunjurer"],
			EnemyGuidDatabase.Entries["lore_gunjurer"],
			EnemyGuidDatabase.Entries["gunsinger"],
			EnemyGuidDatabase.Entries["aged_gunsinger"],
			EnemyGuidDatabase.Entries["ammomancer"],
			EnemyGuidDatabase.Entries["jammomancer"],
			EnemyGuidDatabase.Entries["jamerlengo"],
			EnemyGuidDatabase.Entries["wizbang"],
			EnemyGuidDatabase.Entries["pot_fairy"],
			EnemyGuidDatabase.Entries["bullat"],
			EnemyGuidDatabase.Entries["shotgat"],
			EnemyGuidDatabase.Entries["grenat"],
			EnemyGuidDatabase.Entries["spirat"],
			EnemyGuidDatabase.Entries["coaler"],
			EnemyGuidDatabase.Entries["gat"],
			EnemyGuidDatabase.Entries["diagonal_det"],
			EnemyGuidDatabase.Entries["diagonal_x_det"],
			EnemyGuidDatabase.Entries["gunzookie"],
			EnemyGuidDatabase.Entries["gunzockie"],
			EnemyGuidDatabase.Entries["bullet_shark"],
			EnemyGuidDatabase.Entries["great_bullet_shark"],
			EnemyGuidDatabase.Entries["tombstoner"],
			EnemyGuidDatabase.Entries["gun_cultist"],
			EnemyGuidDatabase.Entries["beadie"],
			EnemyGuidDatabase.Entries["gun_nut"],
			EnemyGuidDatabase.Entries["spectral_gun_nut"],
			EnemyGuidDatabase.Entries["chain_gunner"],
			EnemyGuidDatabase.Entries["fungun"],
			EnemyGuidDatabase.Entries["spogre"],
			EnemyGuidDatabase.Entries["mountain_cube"],
			EnemyGuidDatabase.Entries["flesh_cube"],
			EnemyGuidDatabase.Entries["lead_cube"],
			EnemyGuidDatabase.Entries["lead_maiden"],
			EnemyGuidDatabase.Entries["misfire_beast"],
			EnemyGuidDatabase.Entries["phaser_spider"],
			EnemyGuidDatabase.Entries["killithid"],
			EnemyGuidDatabase.Entries["tarnisher"],
			EnemyGuidDatabase.Entries["shambling_round"],
			EnemyGuidDatabase.Entries["shelleton"],
			EnemyGuidDatabase.Entries["agonizer"],
			EnemyGuidDatabase.Entries["revolvenant"],
			EnemyGuidDatabase.Entries["gunreaper"],
			EnemyGuidDatabase.Entries["mine_flayers_bell"],
			EnemyGuidDatabase.Entries["mine_flayers_claymore"],
			EnemyGuidDatabase.Entries["fusebot"],
			EnemyGuidDatabase.Entries["ammoconda_ball"],
			EnemyGuidDatabase.Entries["bullet_kings_toadie"],
			EnemyGuidDatabase.Entries["bullet_kings_toadie_revenge"],
			EnemyGuidDatabase.Entries["old_kings_toadie"],
			EnemyGuidDatabase.Entries["draguns_knife"],
			EnemyGuidDatabase.Entries["dragun_knife_advanced"],
			EnemyGuidDatabase.Entries["gummy_spent"],
			EnemyGuidDatabase.Entries["candle_guy"],
			EnemyGuidDatabase.Entries["convicts_past_soldier"],
			EnemyGuidDatabase.Entries["robots_past_terminator"],
			EnemyGuidDatabase.Entries["marines_past_imp"],
			EnemyGuidDatabase.Entries["chicken"],
			EnemyGuidDatabase.Entries["rat"],
			EnemyGuidDatabase.Entries["dragun_egg_slimeguy"],
			EnemyGuidDatabase.Entries["poopulons_corn"],
			EnemyGuidDatabase.Entries["rat_candle"],
			EnemyGuidDatabase.Entries["tiny_blobulord"],
			EnemyGuidDatabase.Entries["office_bullet_kin"],
			EnemyGuidDatabase.Entries["office_bullette_kin"],
			EnemyGuidDatabase.Entries["brollet"],
			EnemyGuidDatabase.Entries["western_bullet_kin"],
			EnemyGuidDatabase.Entries["pirate_bullet_kin"],
			EnemyGuidDatabase.Entries["armored_bullet_kin"],
			EnemyGuidDatabase.Entries["western_shotgun_kin"],
			EnemyGuidDatabase.Entries["pirate_shotgun_kin"],
			EnemyGuidDatabase.Entries["gargoyle"],
			EnemyGuidDatabase.Entries["necronomicon"],
			EnemyGuidDatabase.Entries["tablet_bookllett"],
			EnemyGuidDatabase.Entries["grey_cylinder"],
			EnemyGuidDatabase.Entries["red_cylinder"],
			EnemyGuidDatabase.Entries["bullet_mech"],
			EnemyGuidDatabase.Entries["m80_kin"],
			EnemyGuidDatabase.Entries["candle_kin"],
			EnemyGuidDatabase.Entries["western_cactus"],
			EnemyGuidDatabase.Entries["musketball"],
			EnemyGuidDatabase.Entries["bird_parrot"],
			EnemyGuidDatabase.Entries["western_snake"],
			EnemyGuidDatabase.Entries["kalibullet"],
			EnemyGuidDatabase.Entries["kbullet"],
			EnemyGuidDatabase.Entries["blue_fish_bullet_kin"],
			EnemyGuidDatabase.Entries["green_fish_bullet_kin"],
			EnemyGuidDatabase.Entries["fridge_maiden"],
			EnemyGuidDatabase.Entries["titan_bullet_kin"],
			EnemyGuidDatabase.Entries["titan_bullet_kin_boss"],
			EnemyGuidDatabase.Entries["titaness_bullet_kin_boss"],
			EnemyGuidDatabase.Entries["robots_past_critter_3"],
			EnemyGuidDatabase.Entries["robots_past_critter_2"],
			EnemyGuidDatabase.Entries["robots_past_critter_1"],
			EnemyGuidDatabase.Entries["snake"],
			EnemyGuidDatabase.Entries["spent"]
		};
		ExpandTheGungeonChaosPalette = new List<string>
		{
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["bootleg_bullat"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["bootleg_bullet_kin"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["bootleg_bandana_bullet_kin"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["bootleg_red_shotgun_kin"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["bootleg_blue_shotgun_kin"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["grenade_rat"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["cronenberg"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["agressive_cronenberg"],
			ModdedGUIDDatabase.ExpandTheGungeonGUIDs["explodey_boy"]
		};
		FrostAndGunfireChaosPalette = new List<string>
		{
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["humphrey"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["milton"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["gunzooka"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["spitfire"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["firefly"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["ophaim"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["mushboom"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["salamander"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["skell"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["suppressor"],
			ModdedGUIDDatabase.FrostAndGunfireGUIDs["cannon_kin"]
		};
		PlanetsideOfGunymedeChaosPalette = new List<string>
		{
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["fodder"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["skullvenant"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["wailer"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["arch_gunjurer"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["cursebulon"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["glockulus"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["barretina"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["an3s_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["apache_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["blazey_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["bleak_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["bot_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["bunny_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["cel_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["glaurung_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["hunter_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["king_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["kyle_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["neighborino_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["nevernamed_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["panda_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["retrash_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["skilotar_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["spapi_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["spcreat_bullet"],
			ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["wow_bullet"]
		};
	}
}
