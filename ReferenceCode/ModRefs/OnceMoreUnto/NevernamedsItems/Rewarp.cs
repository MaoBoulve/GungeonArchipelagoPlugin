using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Rewarp : AdvancedGunBehavior
{
	public class SideshooterHandler : MonoBehaviour
	{
		private Projectile self;

		private float lastCheckedDistance = 0f;

		private void Start()
		{
			self = ((Component)this).GetComponent<Projectile>();
		}

		private void Update()
		{
			if (Object.op_Implicit((Object)(object)self) && self.m_distanceElapsed >= lastCheckedDistance + 2f)
			{
				Fire();
				lastCheckedDistance += 2f;
			}
		}

		private void Fire()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			for (int i = 0; i < 2; i++)
			{
				Projectile component = ProjectileUtility.InstantiateAndFireInDirection(subProjPrefab, Vector2.op_Implicit(self.m_lastPosition), Vector2Extensions.ToAngle(self.Direction) + (90f + (float)(180 * i)), 0f, (PlayerController)null).GetComponent<Projectile>();
				component.Owner = self.Owner;
				component.Shooter = self.Shooter;
				if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(self)))
				{
					component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(self));
					ProjectileUtility.ProjectilePlayerOwner(self).DoPostProcessProjectile(component);
				}
			}
		}
	}

	public static Projectile subProjPrefab;

	public static int ID;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rewarp", "rewarp");
		Game.Items.Rename("outdated_gun_mods:rewarp", "nn:rewarp");
		Rewarp rewarp = ((Component)val).gameObject.AddComponent<Rewarp>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Time Twister");
		GunExt.SetLongDescription((PickupObject)(object)val, "Summons bullets from an alternate timeline.\n\nThis was pulled through a tear in the curtain along with the Killithid incursion- though it is not of their craftmanship.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "rewarp_idle_001", 8, "rewarp_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(59);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(59);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.8f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(59);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.375f, 0.375f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)50;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.AddComponent<SideshooterHandler>();
		val2.baseData.damage = 20f;
		PierceProjModifier val3 = ((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val3.penetration = 1;
		val.DefaultModule.projectiles[0] = val2;
		val2.pierceMinorBreakables = true;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		PickupObject byId4 = PickupObjectDatabase.GetById(59);
		subProjPrefab = (Projectile)(object)DataCloners.CopyFields<TachyonProjectile>(Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]));
		FakePrefabExtensions.MakeFakePrefab(((Component)subProjPrefab).gameObject);
		subProjPrefab.pierceMinorBreakables = true;
		subProjPrefab.PenetratesInternalWalls = true;
	}
}
