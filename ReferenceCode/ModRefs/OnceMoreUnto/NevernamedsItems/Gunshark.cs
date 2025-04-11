using System;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Gunshark : GunBehaviour
{
	public static int GunsharkID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gunshark", "gunshark");
		Game.Items.Rename("outdated_gun_mods:gunshark", "nn:gunshark");
		((Component)val).gameObject.AddComponent<Gunshark>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Completely Awesome");
		GunExt.SetLongDescription((PickupObject)(object)val, "A bullet shark that is also a gun, what more could you ask for?");
		val.SetGunSprites("gunshark");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.04f;
		val.DefaultModule.numberOfShotsInClip = 200;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.68f, 0.43f, 0f);
		val.SetBaseMaxAmmo(3996);
		val.ammo = 3996;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 2f;
		val2.pierceMinorBreakables = true;
		val2.SetProjectileSprite("gunshark_projectile", 17, 4, lightened: true, (Anchor)4, 17, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunsharkID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.JAMMEDBULLETSHARK_QUEST_REWARDED, requiredFlagValue: true);
		AlexandriaTags.SetTag((PickupObject)(object)val, "non_companion_living_item");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Blood In The Water"))
		{
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!fatal || !(Random.value <= 0.05f) || ((BraveBehaviour)enemy).healthHaver.IsBoss)
			{
				return;
			}
			((BraveBehaviour)enemy).aiActor.EraseFromExistenceWithRewards(false);
			float num = 0f;
			for (int i = 0; i < 8; i++)
			{
				GameActor owner = bullet.Owner;
				PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
				Projectile projectile = ((Gun)PickupObjectDatabase.GetById(359)).DefaultModule.chargeProjectiles[0].Projectile;
				GameObject val2 = SpawnManager.SpawnProjectile(((Component)projectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)bullet).sprite.WorldCenter), Quaternion.Euler(0f, 0f, num), true);
				Projectile component = val2.GetComponent<Projectile>();
				if (Object.op_Implicit((Object)(object)component))
				{
					PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)component).gameObject);
					component.SpawnedFromOtherPlayerProjectile = true;
					ProjectileData baseData = component.baseData;
					baseData.damage *= val.stats.GetStatValue((StatType)5);
					ProjectileData baseData2 = component.baseData;
					baseData2.speed *= val.stats.GetStatValue((StatType)6);
					component.AdditionalScaleMultiplier *= val.stats.GetStatValue((StatType)15);
					val.DoPostProcessProjectile(component);
				}
				num += 45f;
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
	}
}
