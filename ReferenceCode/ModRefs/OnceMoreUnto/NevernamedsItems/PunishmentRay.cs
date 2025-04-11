using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PunishmentRay : AdvancedGunBehavior
{
	public class PunishmentRayHitOnce : MonoBehaviour
	{
	}

	public static int HitStreak = 0;

	public static List<string> AcceptableNonEnemyTargets = new List<string> { "Red Barrel" };

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Punishment Ray", "punishmentray");
		Game.Items.Rename("outdated_gun_mods:punishment_ray", "nn:punishment_ray");
		((Component)val).gameObject.AddComponent<PunishmentRay>();
		GunExt.SetShortDescription((PickupObject)(object)val, "STREAK");
		GunExt.SetLongDescription((PickupObject)(object)val, "Repeatedly landing shots builds up a damage increasing streak, but missing shots will be PUNISHED.\n\nHave you been a bad Gungeoneer?");
		val.SetGunSprites("punishmentray");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(32);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.DefaultModule.angleFromAim = 0f;
		val.DefaultModule.angleVariance = 0f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.68f, 0.56f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.4f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		ProjectileData baseData4 = val2.baseData;
		baseData4.force *= 1f;
		val2.SetProjectileSprite("punishmentray_projectile", 20, 3, lightened: false, (Anchor)4, 10, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Punishment Ray Lasers", "NevernamedsItems/Resources/CustomGunAmmoTypes/punishmentray_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/punishmentray_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			HitStreak = 0;
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	private void OnCollision(CollisionData data)
	{
		if ((Object)(object)data.OtherRigidbody != (Object)null && (Object)(object)((Component)data.OtherRigidbody).gameObject != (Object)null)
		{
			AIActor component = ((Component)data.OtherRigidbody).gameObject.GetComponent<AIActor>();
			HealthHaver component2 = ((Component)data.OtherRigidbody).gameObject.GetComponent<HealthHaver>();
			if ((Object)(object)component != (Object)null || (Object)(object)component2 != (Object)null)
			{
				if (component2.IsVulnerable)
				{
					HitStreak++;
				}
			}
			else if (((Object)data.OtherRigidbody).name != null && !AcceptableNonEnemyTargets.Contains(((Object)data.OtherRigidbody).name))
			{
				ETGModConsole.Log((object)((Object)data.OtherRigidbody).name, false);
				EndStreak(((BraveBehaviour)data.MyRigidbody).projectile);
			}
			else if (((Object)data.OtherRigidbody).name == null)
			{
				EndStreak(((BraveBehaviour)data.MyRigidbody).projectile);
			}
		}
		else
		{
			EndStreak(((BraveBehaviour)data.MyRigidbody).projectile);
		}
		if ((Object)(object)((BraveBehaviour)data.MyRigidbody).projectile != (Object)null)
		{
			PunishmentRayHitOnce punishmentRayHitOnce = ((Component)((BraveBehaviour)data.MyRigidbody).projectile).gameObject.AddComponent<PunishmentRayHitOnce>();
		}
	}

	private void EndStreak(Projectile projectileResponsible)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)projectileResponsible != (Object)null)
		{
			PunishmentRayHitOnce component = ((Component)projectileResponsible).GetComponent<PunishmentRayHitOnce>();
			if ((Object)(object)component != (Object)null)
			{
				return;
			}
		}
		if ((Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.CurrentOwner is PlayerController)
		{
			if (HitStreak > 0)
			{
				VFXToolbox.DoRisingStringFade("STREAK LOST", Vector2.op_Implicit(((BraveBehaviour)base.gun.CurrentOwner).transform.position), Color.red);
			}
			int num = 15;
			GameActor currentOwner = base.gun.CurrentOwner;
			if (CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null), "Spare The Rod"))
			{
				num = 7;
			}
			if (HitStreak >= num)
			{
				((Component)GunTools.GunPlayerOwner(base.gun)).GetComponent<PlayerToolbox>().DoFakeDamage();
			}
		}
		HitStreak = 0;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if (val.IsInCombat)
			{
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)projectile).specRigidbody;
				specRigidbody.OnCollision = (Action<CollisionData>)Delegate.Combine(specRigidbody.OnCollision, new Action<CollisionData>(OnCollision));
			}
			float num = 0.02f;
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Cobalt Streak"))
			{
				num = 0.05f;
			}
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= (float)HitStreak * num + 1f;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
