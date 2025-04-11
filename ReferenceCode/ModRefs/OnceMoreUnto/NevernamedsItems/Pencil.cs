using System;
using System.Collections.Generic;
using Alexandria.EnemyAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Pencil : AdvancedGunBehavior
{
	public static int pencilID;

	public float launchCoolDownTimer;

	public static List<Projectile> ActiveBullets = new List<Projectile>();

	public static List<Projectile> BulletsToRemoveFromActiveBullets = new List<Projectile>();

	public static void Add()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pencil", "pencil");
		Game.Items.Rename("outdated_gun_mods:pencil", "nn:pencil");
		Pencil pencil = ((Component)val).gameObject.AddComponent<Pencil>();
		((AdvancedGunBehavior)pencil).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Me Hoy Minoy");
		GunExt.SetLongDescription((PickupObject)(object)val, "Sketches out stationary bullets in the air. Reload to send your drawings flying!\n\nAbandoned in the Gungeon by a grieving artist with really big hands.");
		val.SetGunSprites("pencil");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		val.doesScreenShake = false;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.PreventNormalFireAudio = true;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.gunClass = (GunClass)50;
		val.DefaultModule.cooldownTime = 0.0001f;
		val.DefaultModule.numberOfShotsInClip = 5000;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.25f, 0.31f, 0f);
		val.SetBaseMaxAmmo(5000);
		val.ammo = 5000;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 0.5f;
		val2.objectImpactEventName = null;
		val2.enemyImpactEventName = null;
		val2.onDestroyEventName = null;
		val2.additionalStartEventName = null;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 0.1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.0001f;
		val2.SetProjectileSprite("pencil_projectile", 4, 4, lightened: false, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.enemy = null;
		val2.hitEffects.tileMapHorizontal = null;
		val2.hitEffects.tileMapVertical = null;
		val2.hitEffects.deathTileMapVertical = null;
		val2.hitEffects.deathTileMapHorizontal = null;
		val2.hitEffects.overrideMidairDeathVFX = null;
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Pencil";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		pencilID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if ((Object)(object)val != (Object)null && CustomSynergies.PlayerHasActiveSynergy(val, "Freehand"))
		{
			InstantTeleportToPlayerCursorBehav orAddComponent = GameObjectExtensions.GetOrAddComponent<InstantTeleportToPlayerCursorBehav>(((Component)projectile).gameObject);
		}
		ActiveBullets.Add(projectile);
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)projectile).specRigidbody;
		specRigidbody.OnPreTileCollision = (OnPreTileCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreTileCollision, (Delegate)new OnPreTileCollisionDelegate(onhit));
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Stationary"))
		{
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void onhit(SpeculativeRigidbody myrigidbody, PixelCollider mypixelcollider, Tile tile, PixelCollider tilepixelcollider)
	{
	}

	private void OnHitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		if (ActiveBullets.Contains(self) && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).gameActor))
		{
			float num = 1f;
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && ((BraveBehaviour)enemy).healthHaver.IsBoss)
			{
				num = 0.33f;
			}
			AIActorUtility.DeleteOwnedBullets(((BraveBehaviour)enemy).gameActor, num, false);
		}
	}

	protected override void Update()
	{
		if (launchCoolDownTimer > 0f)
		{
			launchCoolDownTimer -= BraveTime.DeltaTime;
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (launchCoolDownTimer <= 0f)
		{
			launchCoolDownTimer = 1f;
			if (ActiveBullets.Count > 0)
			{
				foreach (Projectile activeBullet in ActiveBullets)
				{
					if (Object.op_Implicit((Object)(object)activeBullet))
					{
						activeBullet.SendInDirection(MathsAndLogicHelper.DegreeToVector2(gun.CurrentAngle), false, true);
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
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, bSOMETHING);
	}
}
