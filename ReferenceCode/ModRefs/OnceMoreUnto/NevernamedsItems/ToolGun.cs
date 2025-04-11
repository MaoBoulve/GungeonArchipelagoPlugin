using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ToolGun : AdvancedGunBehavior
{
	private int overrideAmmoConsumption = 1;

	private int currentMode = 1;

	private Dictionary<int, string> ModeNames = new Dictionary<int, string>
	{
		{ 1, "Increase" },
		{ 2, "Decrease" },
		{ 3, "Apply Status" },
		{ 4, "Spawn: Kin" },
		{ 5, "Spawn: Table" },
		{ 6, "Spawn: Barrel" },
		{ 7, "Erase" }
	};

	private Dictionary<int, int> ModeAmmoCosts = new Dictionary<int, int>
	{
		{ 1, 1 },
		{ 2, 2 },
		{ 3, 1 },
		{ 4, 5 },
		{ 5, 4 },
		{ 6, 3 },
		{ 7, 25 }
	};

	public static int ToolGunID;

	public static void Add()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Tool Gun", "toolgun");
		Game.Items.Rename("outdated_gun_mods:tool_gun", "nn:tool_gun");
		((Component)val).gameObject.AddComponent<ToolGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "sv_cheats 1");
		GunExt.SetLongDescription((PickupObject)(object)val, "Pressing reload with a full clip cycles firing modes.\n\nAn incredibly advanced piece of technology capable of manipulating reality around you. Used almost entirely for practical jokes.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "toolgun_idle_001", 8, "toolgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.DefaultModule.angleVariance = 0f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.62f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 2f;
		val2.AdditionalScaleMultiplier *= 0.3f;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Toolgun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/toolgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/toolgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ToolGunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		switch (currentMode)
		{
		case 1:
		{
			EnemyScaleUpdaterMod orAddComponent6 = GameObjectExtensions.GetOrAddComponent<EnemyScaleUpdaterMod>(((Component)projectile).gameObject);
			orAddComponent6.targetScale = new Vector2(1.25f, 1.25f);
			orAddComponent6.multiplyExisting = true;
			orAddComponent6.addScaleEffectsToEnemy = true;
			break;
		}
		case 2:
		{
			EnemyScaleUpdaterMod orAddComponent5 = GameObjectExtensions.GetOrAddComponent<EnemyScaleUpdaterMod>(((Component)projectile).gameObject);
			orAddComponent5.targetScale = new Vector2(0.75f, 0.75f);
			orAddComponent5.multiplyExisting = true;
			orAddComponent5.addScaleEffectsToEnemy = true;
			break;
		}
		case 3:
		{
			StatusEffectBulletMod statusEffectBulletMod = ((Component)projectile).gameObject.AddComponent<StatusEffectBulletMod>();
			statusEffectBulletMod.pickRandom = true;
			statusEffectBulletMod.datasToApply.AddRange(new List<StatusEffectBulletMod.StatusData>
			{
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StaticStatusEffects.chaosBulletsFreeze,
					applyChance = 1f,
					applyTint = false
				},
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect,
					applyChance = 1f,
					applyTint = false
				},
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StaticStatusEffects.greenFireEffect,
					applyChance = 1f,
					applyTint = false
				},
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StaticStatusEffects.StandardPlagueEffect,
					applyChance = 1f,
					applyTint = false
				},
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StaticStatusEffects.tripleCrossbowSlowEffect,
					applyChance = 1f,
					applyTint = false
				},
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StaticStatusEffects.hotLeadEffect,
					applyChance = 1f,
					applyTint = false
				},
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect,
					applyChance = 1f,
					applyTint = false
				},
				new StatusEffectBulletMod.StatusData
				{
					effect = (GameActorEffect)(object)StatusEffectHelper.GenerateLockdown(),
					applyChance = 1f,
					applyTint = false
				}
			});
			break;
		}
		case 4:
		{
			SpawnEnemyOnDestructionMod orAddComponent4 = GameObjectExtensions.GetOrAddComponent<SpawnEnemyOnDestructionMod>(((Component)projectile).gameObject);
			orAddComponent4.pickRandom = true;
			orAddComponent4.EnemiesToSpawn.AddRange(new List<string>
			{
				EnemyGuidDatabase.Entries["bullet_kin"],
				EnemyGuidDatabase.Entries["mutant_bullet_kin"],
				EnemyGuidDatabase.Entries["cardinal"],
				EnemyGuidDatabase.Entries["shroomer"],
				EnemyGuidDatabase.Entries["ashen_bullet_kin"],
				EnemyGuidDatabase.Entries["fallen_bullet_kin"],
				EnemyGuidDatabase.Entries["ak47_bullet_kin"],
				EnemyGuidDatabase.Entries["bandana_bullet_kin"],
				EnemyGuidDatabase.Entries["veteran_bullet_kin"],
				EnemyGuidDatabase.Entries["treadnaughts_bullet_kin"],
				EnemyGuidDatabase.Entries["brollet"],
				EnemyGuidDatabase.Entries["skullet"],
				EnemyGuidDatabase.Entries["skullmet"],
				EnemyGuidDatabase.Entries["gummy_spent"],
				EnemyGuidDatabase.Entries["red_shotgun_kin"],
				EnemyGuidDatabase.Entries["blue_shotgun_kin"],
				EnemyGuidDatabase.Entries["veteran_shotgun_kin"],
				EnemyGuidDatabase.Entries["mutant_shotgun_kin"],
				EnemyGuidDatabase.Entries["executioner"],
				EnemyGuidDatabase.Entries["ashen_shotgun_kin"],
				EnemyGuidDatabase.Entries["bullat"],
				EnemyGuidDatabase.Entries["shotgat"],
				EnemyGuidDatabase.Entries["grenat"],
				EnemyGuidDatabase.Entries["spirat"],
				EnemyGuidDatabase.Entries["grenade_kin"],
				EnemyGuidDatabase.Entries["dynamite_kin"],
				EnemyGuidDatabase.Entries["m80_kin"],
				EnemyGuidDatabase.Entries["tazie"],
				EnemyGuidDatabase.Entries["rubber_kin"],
				EnemyGuidDatabase.Entries["sniper_shell"],
				EnemyGuidDatabase.Entries["professional"]
			});
			break;
		}
		case 5:
		{
			SpawnGameObjectOnDestructionMod orAddComponent3 = GameObjectExtensions.GetOrAddComponent<SpawnGameObjectOnDestructionMod>(((Component)projectile).gameObject);
			orAddComponent3.objectsToPickFrom.AddRange(new List<GameObject>
			{
				EasyPlaceableObjects.TableVertical,
				EasyPlaceableObjects.TableHorizontal,
				EasyPlaceableObjects.TableHorizontalStone,
				EasyPlaceableObjects.TableVerticalStone,
				EasyPlaceableObjects.FoldingTable
			});
			break;
		}
		case 6:
		{
			SpawnGameObjectOnDestructionMod orAddComponent2 = GameObjectExtensions.GetOrAddComponent<SpawnGameObjectOnDestructionMod>(((Component)projectile).gameObject);
			orAddComponent2.objectsToPickFrom.AddRange(new List<GameObject>
			{
				EasyPlaceableObjects.ExplosiveBarrel,
				EasyPlaceableObjects.MetalExplosiveBarrel,
				EasyPlaceableObjects.OilBarrel,
				EasyPlaceableObjects.PoisonBarrel,
				EasyPlaceableObjects.WaterBarrel
			});
			break;
		}
		case 7:
		{
			EraseEnemyBehav orAddComponent = GameObjectExtensions.GetOrAddComponent<EraseEnemyBehav>(((Component)projectile).gameObject);
			orAddComponent.doSparks = true;
			break;
		}
		}
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
		if (base.gun.DefaultModule.ammoCost != overrideAmmoConsumption)
		{
			base.gun.DefaultModule.ammoCost = overrideAmmoConsumption;
		}
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, bSOMETHING);
		if (gun.ClipCapacity == gun.ClipShotsRemaining || gun.CurrentAmmo == gun.ClipShotsRemaining)
		{
			if (currentMode == 7)
			{
				currentMode = 1;
				overrideAmmoConsumption = ModeAmmoCosts[currentMode];
				VFXToolbox.DoStringSquirt(ModeNames[1], Vector2.op_Implicit(((BraveBehaviour)player).transform.position), Color.red);
			}
			else
			{
				currentMode++;
				overrideAmmoConsumption = ModeAmmoCosts[currentMode];
				VFXToolbox.DoStringSquirt(ModeNames[currentMode], Vector2.op_Implicit(((BraveBehaviour)player).transform.position), Color.red);
			}
		}
	}
}
