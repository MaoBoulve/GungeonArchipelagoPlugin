using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using BepInEx.Bootstrap;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ERRORShells : PassiveItem
{
	public static GameActorDecorationEffect ERRORShellsDummyEffect;

	private bool hasPicked = false;

	public string PickedEnemiesDialogue;

	public List<string> badMenGoByeBye = new List<string>();

	public List<string> badMenToNotGoByeBye = new List<string>
	{
		EnemyGuidDatabase.Entries["gummy_spent"],
		EnemyGuidDatabase.Entries["western_shotgun_kin"],
		EnemyGuidDatabase.Entries["pirate_shotgun_kin"],
		EnemyGuidDatabase.Entries["blobuloid"],
		EnemyGuidDatabase.Entries["blobulin"],
		EnemyGuidDatabase.Entries["poisbuloid"],
		EnemyGuidDatabase.Entries["poisbulin"],
		EnemyGuidDatabase.Entries["black_skusket"],
		EnemyGuidDatabase.Entries["skusket_head"],
		EnemyGuidDatabase.Entries["shotgat"],
		EnemyGuidDatabase.Entries["necronomicon"],
		EnemyGuidDatabase.Entries["tablet_bookllett"],
		EnemyGuidDatabase.Entries["pot_fairy"],
		EnemyGuidDatabase.Entries["fridge_maiden"],
		EnemyGuidDatabase.Entries["bullet_king"],
		EnemyGuidDatabase.Entries["blobulord"],
		EnemyGuidDatabase.Entries["old_king"],
		EnemyGuidDatabase.Entries["lich"],
		EnemyGuidDatabase.Entries["megalich"],
		EnemyGuidDatabase.Entries["infinilich"],
		EnemyGuidDatabase.Entries["tiny_blobulord"],
		EnemyGuidDatabase.Entries["cannonbalrog"],
		EnemyGuidDatabase.Entries["brown_chest_mimic"],
		EnemyGuidDatabase.Entries["blue_chest_mimic"],
		EnemyGuidDatabase.Entries["green_chest_mimic"],
		EnemyGuidDatabase.Entries["red_chest_mimic"],
		EnemyGuidDatabase.Entries["black_chest_mimic"],
		EnemyGuidDatabase.Entries["rat_chest_mimic"],
		EnemyGuidDatabase.Entries["pedestal_mimic"],
		EnemyGuidDatabase.Entries["wall_mimic"],
		EnemyGuidDatabase.Entries["door_lord"],
		EnemyGuidDatabase.Entries["brollet"],
		EnemyGuidDatabase.Entries["grenat"],
		EnemyGuidDatabase.Entries["det"],
		EnemyGuidDatabase.Entries["x_det"],
		EnemyGuidDatabase.Entries["diagonal_x_det"],
		EnemyGuidDatabase.Entries["vertical_det"],
		EnemyGuidDatabase.Entries["horizontal_det"],
		EnemyGuidDatabase.Entries["diagonal_det"],
		EnemyGuidDatabase.Entries["vertical_x_det"],
		EnemyGuidDatabase.Entries["horizontal_x_det"],
		EnemyGuidDatabase.Entries["m80_kin"],
		EnemyGuidDatabase.Entries["mine_flayers_claymore"],
		EnemyGuidDatabase.Entries["office_bullet_kin"],
		EnemyGuidDatabase.Entries["office_bullette_kin"],
		EnemyGuidDatabase.Entries["western_bullet_kin"],
		EnemyGuidDatabase.Entries["pirate_bullet_kin"],
		EnemyGuidDatabase.Entries["armored_bullet_kin"],
		EnemyGuidDatabase.Entries["spectre"],
		EnemyGuidDatabase.Entries["bullat"],
		EnemyGuidDatabase.Entries["spirat"],
		EnemyGuidDatabase.Entries["gargoyle"],
		EnemyGuidDatabase.Entries["grey_cylinder"],
		EnemyGuidDatabase.Entries["red_cylinder"],
		EnemyGuidDatabase.Entries["bullet_mech"],
		EnemyGuidDatabase.Entries["arrow_head"],
		EnemyGuidDatabase.Entries["musketball"],
		EnemyGuidDatabase.Entries["western_cactus"],
		EnemyGuidDatabase.Entries["candle_kin"],
		EnemyGuidDatabase.Entries["chameleon"],
		EnemyGuidDatabase.Entries["bird_parrot"],
		EnemyGuidDatabase.Entries["western_snake"],
		EnemyGuidDatabase.Entries["kalibullet"],
		EnemyGuidDatabase.Entries["kbullet"],
		EnemyGuidDatabase.Entries["blue_fish_bullet_kin"],
		EnemyGuidDatabase.Entries["green_fish_bullet_kin"],
		EnemyGuidDatabase.Entries["ammoconda_ball"],
		EnemyGuidDatabase.Entries["summoned_treadnaughts_bullet_kin"],
		EnemyGuidDatabase.Entries["mine_flayers_bell"],
		EnemyGuidDatabase.Entries["titan_bullet_kin"],
		EnemyGuidDatabase.Entries["grip_master"],
		EnemyGuidDatabase.Entries["titan_bullet_kin_boss"],
		EnemyGuidDatabase.Entries["titaness_bullet_kin_boss"],
		EnemyGuidDatabase.Entries["fusebot"],
		EnemyGuidDatabase.Entries["candle_guy"],
		EnemyGuidDatabase.Entries["draguns_knife"],
		EnemyGuidDatabase.Entries["dragun_knife_advanced"],
		EnemyGuidDatabase.Entries["marines_past_imp"],
		EnemyGuidDatabase.Entries["convicts_past_soldier"],
		EnemyGuidDatabase.Entries["robots_past_terminator"],
		EnemyGuidDatabase.Entries["bullet_kings_toadie"],
		EnemyGuidDatabase.Entries["bullet_kings_toadie_revenge"],
		EnemyGuidDatabase.Entries["old_kings_toadie"],
		EnemyGuidDatabase.Entries["chicken"],
		EnemyGuidDatabase.Entries["rat"],
		EnemyGuidDatabase.Entries["dragun_egg_slimeguy"],
		EnemyGuidDatabase.Entries["poopulons_corn"],
		EnemyGuidDatabase.Entries["rat_candle"],
		EnemyGuidDatabase.Entries["robots_past_critter_3"],
		EnemyGuidDatabase.Entries["robots_past_critter_2"],
		EnemyGuidDatabase.Entries["robots_past_critter_1"],
		EnemyGuidDatabase.Entries["snake"],
		EnemyGuidDatabase.Entries["beholster"],
		EnemyGuidDatabase.Entries["treadnaught"],
		EnemyGuidDatabase.Entries["cannonbalrog"],
		EnemyGuidDatabase.Entries["gorgun"],
		EnemyGuidDatabase.Entries["gatling_gull"],
		EnemyGuidDatabase.Entries["ammoconda"],
		EnemyGuidDatabase.Entries["dragun"],
		EnemyGuidDatabase.Entries["dragun_advanced"],
		EnemyGuidDatabase.Entries["helicopter_agunim"],
		EnemyGuidDatabase.Entries["super_space_turtle_dummy"],
		EnemyGuidDatabase.Entries["cop_android"],
		EnemyGuidDatabase.Entries["portable_turret"],
		EnemyGuidDatabase.Entries["friendly_gatling_gull"],
		EnemyGuidDatabase.Entries["cucco"],
		EnemyGuidDatabase.Entries["cop"],
		EnemyGuidDatabase.Entries["blockner"],
		ModdedGUIDDatabase.FrostAndGunfireGUIDs["humphrey"],
		ModdedGUIDDatabase.FrostAndGunfireGUIDs["milton"],
		ModdedGUIDDatabase.FrostAndGunfireGUIDs["roomimic"],
		ModdedGUIDDatabase.FrostAndGunfireGUIDs["mushboom"],
		ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["shellrax"],
		ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["bullet_banker"],
		ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["jammed_guardian"],
		ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["deturret_left"],
		ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs["deturret_right"],
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

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ERRORShells>("ERROR Shells", "What do you mean 74 errors!?", "Picks a random selection of enemies to become highly efficient against.\n\nThese bullets were moulded by the numerous errors that went into making them, thanks to their incompetent smith.", "errorshells_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_ERRORSHELLS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(30, null);
		Doug.AddToLootPool(val.PickupObjectId);
		ERRORShellsDummyEffect = new GameActorDecorationEffect
		{
			AffectsEnemies = true,
			OverheadVFX = SharedVFX.ERRORShellsOverhead,
			AffectsPlayers = false,
			AppliesTint = false,
			AppliesDeathTint = false,
			AppliesOutlineTint = false,
			duration = float.MaxValue,
			effectIdentifier = "ERROR Shells Overheader",
			resistanceType = (EffectResistanceType)0,
			PlaysVFXOnActor = false,
			stackMode = (EffectStackingMode)2
		};
	}

	private void PreSpawn(AIActor aIActor)
	{
		if (badMenGoByeBye.Contains(aIActor.EnemyGuid))
		{
			((GameActor)aIActor).ApplyEffect((GameActorEffect)(object)ERRORShellsDummyEffect, 1f, (Projectile)null);
		}
	}

	public override void Pickup(PlayerController player)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		((PassiveItem)this).Pickup(player);
		PickEnemies();
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(PreSpawn));
		TextBubble.DoAmbientTalk(((BraveBehaviour)player).transform, new Vector3(1f, 2f, 0f), PickedEnemiesDialogue, 5f);
	}

	private void PickEnemies()
	{
		int num = 0;
		if (hasPicked)
		{
			return;
		}
		string text = "";
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (string key in EnemyGuidDatabase.Entries.Keys)
		{
			if (!badMenToNotGoByeBye.Contains(EnemyGuidDatabase.Entries[key]))
			{
				dictionary.Add(key, EnemyGuidDatabase.Entries[key]);
			}
		}
		if (Chainloader.PluginInfos.ContainsKey("somebunny.etg.planetsideofgunymede"))
		{
			foreach (string key2 in ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs.Keys)
			{
				if (!badMenToNotGoByeBye.Contains(ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs[key2]))
				{
					dictionary.Add(key2, ModdedGUIDDatabase.PlanetsideOfGunymedeGUIDs[key2]);
				}
			}
		}
		if (Chainloader.PluginInfos.ContainsKey("frostandgunfireplaceholder"))
		{
			foreach (string key3 in ModdedGUIDDatabase.FrostAndGunfireGUIDs.Keys)
			{
				if (!badMenToNotGoByeBye.Contains(ModdedGUIDDatabase.FrostAndGunfireGUIDs[key3]))
				{
					dictionary.Add(key3, ModdedGUIDDatabase.FrostAndGunfireGUIDs[key3]);
				}
			}
		}
		for (int i = 0; i < 10; i++)
		{
			num++;
			int index = Random.Range(0, dictionary.Count);
			string text2 = ((num < 10) ? (dictionary.Keys.ElementAt(index) + ", \n") : ("and " + dictionary.Keys.ElementAt(index) + "."));
			text2 = text2.Replace("_", " ");
			ETGModConsole.Log((object)("Enemy Chosen for Death: " + dictionary.Keys.ElementAt(index)), false);
			text += text2;
			badMenGoByeBye.Add(dictionary.Values.ElementAt(index));
			dictionary.Remove(dictionary.Keys.ElementAt(index));
		}
		hasPicked = true;
		PickedEnemiesDialogue = text;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		ProjectileInstakillBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)sourceProjectile).gameObject);
		orAddComponent.enemyGUIDsToKill.AddRange(badMenGoByeBye);
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)sourceBeam).projectile))
		{
			PostProcessProjectile(((BraveBehaviour)sourceBeam).projectile, 1f);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(PreSpawn));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(PreSpawn));
		((PassiveItem)this).OnDestroy();
	}
}
