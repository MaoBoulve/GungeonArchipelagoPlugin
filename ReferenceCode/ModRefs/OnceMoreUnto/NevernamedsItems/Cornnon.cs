using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Cornnon : GunBehaviour
{
	public class CornTwister : MonoBehaviour
	{
		private Projectile self;

		private float t = 0f;

		private void Start()
		{
			self = ((Component)this).GetComponent<Projectile>();
		}

		private void Update()
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			t += BraveTime.DeltaTime;
			if (t > 0.1f)
			{
				self.SendInDirection(Vector2Extensions.Rotate(self.Direction, 15f), false, true);
				t = 0f;
			}
		}
	}

	public static int ID;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Cornnon", "cornnon");
		Game.Items.Rename("outdated_gun_mods:cornnon", "nn:cornnon");
		((Component)val).gameObject.AddComponent<Cornnon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "On the Cob");
		GunExt.SetLongDescription((PickupObject)(object)val, "Corn within the Gungeon possesses strange projectile properties, as visitors to the Gungeons Oubliette are no doubt aware.");
		val.SetGunSprites("cornnon", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.AddCustomSwitchGroup("NN_Cornnon", "Play_ENM_pop_shot_01", "Play_ENM_Tarnisher_Bite_01");
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.9f;
		val.DefaultModule.cooldownTime = 0.02f;
		val.DefaultModule.numberOfShotsInClip = 50;
		val.DefaultModule.angleVariance = 360f;
		val.SetBarrel(17, 8);
		val.SetBaseMaxAmmo(2000);
		val.ammo = 2000;
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 10f);
		((Object)((Component)val2).gameObject).name = "Cornnon Projectile";
		val2.SetProjectileSprite("cornnon_proj", 8, 6, lightened: false, (Anchor)4, 6, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.baseData.UsesCustomAccelerationCurve = true;
		val2.baseData.AccelerationCurve = AnimationCurve.Linear(0f, 0.1f, 0.2f, 2f);
		val2.baseData.speed = 10f;
		((Component)val2).gameObject.AddComponent<CornTwister>();
		val2.onDestroyEventName = "Play_ENM_pop_shot_01";
		((Component)val2).gameObject.AddComponent<PierceDeadActors>();
		val.DefaultModule.projectiles[0] = val2;
		val2.hitEffects.deathAny = VFXToolbox.CreateBlankVFXPool(((Component)Breakables.GenerateDebrisObject(Initialisation.VFXCollection, "cornnon_debris_002", debrisObjectsCanRotate: true, 1f, 1f, 10f, 200f)).gameObject, isDebris: true);
		val2.hitEffects.HasProjectileDeathVFX = true;
		val.gunHandedness = (GunHandedness)0;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(124);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.AddClipSprites("cornnon");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Kernel Panic"))
		{
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	private void OnHit(Projectile proj, SpeculativeRigidbody body, bool fatal)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (!fatal || !Object.op_Implicit((Object)(object)proj))
		{
			return;
		}
		for (int i = 0; i < 7; i++)
		{
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(base.gun.DefaultModule.projectiles[0], proj.SafeCenter, BraveUtility.RandomAngle(), 0f, (PlayerController)null).GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.Owner = proj.Owner;
				component.Shooter = proj.Shooter;
				BounceProjModifier component2 = ((Component)component).gameObject.GetComponent<BounceProjModifier>();
				if ((Object)(object)component2 == (Object)null)
				{
					component2 = ((Component)component).gameObject.AddComponent<BounceProjModifier>();
					component2.numberOfBounces = 1;
				}
				else
				{
					BounceProjModifier obj = component2;
					obj.numberOfBounces++;
				}
				if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(component)))
				{
					component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(component));
				}
			}
		}
	}
}
