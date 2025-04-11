using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RedRobin : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Red Robin", "redrobin");
		Game.Items.Rename("outdated_gun_mods:red_robin", "nn:red_robin");
		((Component)val).gameObject.AddComponent<RedRobin>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Healthy Option");
		GunExt.SetLongDescription((PickupObject)(object)val, "Deals bonus damage at full health.\n\nThe signature weapon of Gungeoneer 'Hearts Ferros', famous for never being shot in a gunfight... until he was.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "redrobin_idle_001", 8, "redrobin_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.angleFromAim = 0f;
		val.DefaultModule.angleVariance = 12f;
		val.DefaultModule.numberOfShotsInClip = 13;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.4375f, 0.6875f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)50;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPool("RedRobin Muzzleflash", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/redrobin_muzzleflash_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/redrobin_muzzleflash_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/redrobin_muzzleflash_004", "NevernamedsItems/Resources/MiscVFX/GunVFX/redrobin_muzzleflash_005" }, 13, new IntVector2(9, 16), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)0, -1f, null, (WrapMode)2);
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		val.DefaultModule.projectiles[0] = component;
		component.baseData.damage = 5f;
		component.SetProjectileSprite("redrobin_projectile", 12, 6, lightened: true, (Anchor)4, 12, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		component.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		component.hitEffects.alwaysUseMidair = true;
		val.DefaultModule.ammoType = (AmmoType)5;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnReload(PlayerController player, Gun gun)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)player) && CustomSynergies.PlayerHasActiveSynergy(player, "Manbat and Robin"))
		{
			CompanionisedEnemyUtility.SpawnCompanionisedEnemy(player, "2feb50a6a40f4f50982e89fd276f6f15", Vector2Extensions.ToIntVector2(Vector3Extensions.XY(gun.barrelOffset.position), (VectorConversions)2), doTint: true, Color.black, 10, 2, shouldBeJammed: false, doFriendlyOverhead: false);
		}
		((AdvancedGunBehavior)this).OnReload(player, gun);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			if (GunTools.GunPlayerOwner(base.gun).ForceZeroHealthState)
			{
				if (GunTools.GunPlayerOwner(base.gun).characterIdentity == OMITBChars.Shade)
				{
					BuffProj(projectile);
				}
				else if (((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver.Armor > 6f)
				{
					BuffProj(projectile);
				}
			}
			else if (((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver.GetCurrentHealthPercentage() == 1f)
			{
				BuffProj(projectile);
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void BuffProj(Projectile proj)
	{
		if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Scarlet Tanager"))
		{
			ProjectileData baseData = proj.baseData;
			baseData.damage *= 2f;
		}
		else
		{
			ProjectileData baseData2 = proj.baseData;
			baseData2.damage *= 1.75f;
		}
		proj.RuntimeUpdateScale(1.2f);
	}
}
