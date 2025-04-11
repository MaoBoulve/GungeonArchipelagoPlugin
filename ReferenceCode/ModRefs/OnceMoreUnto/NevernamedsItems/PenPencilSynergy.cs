using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PenPencilSynergy : GunBehaviour
{
	public static int penID;

	public static List<Projectile> ActiveBullets = new List<Projectile>();

	public static List<Projectile> BulletsToRemoveFromActiveBullets = new List<Projectile>();

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pen", "pen");
		Game.Items.Rename("outdated_gun_mods:pen", "nn:pencil+mightier_than_the_gun");
		((Component)val).gameObject.AddComponent<PenPencilSynergy>();
		GunExt.SetShortDescription((PickupObject)(object)val, "draw me like one of your french girls");
		GunExt.SetLongDescription((PickupObject)(object)val, "massive fuck'n pen");
		val.SetGunSprites("pen", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.0001f;
		val.DefaultModule.numberOfShotsInClip = 6000;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.25f, 0.31f, 0f);
		val.SetBaseMaxAmmo(6000);
		val.ammo = 6000;
		val.PreventNormalFireAudio = true;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 1f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 0.1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.0001f;
		GunTools.SetProjectileSpriteRight(val2, "pen_projectile", 4, 4, false, (Anchor)4, (int?)4, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the pen";
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		penID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		ActiveBullets.Add(projectile);
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)projectile).specRigidbody;
		specRigidbody.OnPreTileCollision = (OnPreTileCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreTileCollision, (Delegate)new OnPreTileCollisionDelegate(onhit));
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	private void onhit(SpeculativeRigidbody myrigidbody, PixelCollider mypixelcollider, Tile tile, PixelCollider tilepixelcollider)
	{
		((BraveBehaviour)myrigidbody).projectile.ForceDestruction();
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveBullets.Count > 0)
		{
			foreach (Projectile activeBullet in ActiveBullets)
			{
				if (Object.op_Implicit((Object)(object)activeBullet))
				{
					Vector2 centerPosition = ((GameActor)player).CenterPosition;
					Vector2 val = Vector3Extensions.XY(player.unadjustedAimPoint) - centerPosition;
					Vector2 normalized = ((Vector2)(ref val)).normalized;
					activeBullet.SendInDirection(normalized, false, true);
					ProjectileData baseData = activeBullet.baseData;
					baseData.speed *= 10000f;
					activeBullet.UpdateSpeed();
					BulletsToRemoveFromActiveBullets.Add(activeBullet);
				}
			}
			foreach (Projectile bulletsToRemoveFromActiveBullet in BulletsToRemoveFromActiveBullets)
			{
				ActiveBullets.Remove(bulletsToRemoveFromActiveBullet);
			}
			BulletsToRemoveFromActiveBullets.Clear();
		}
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
	}
}
