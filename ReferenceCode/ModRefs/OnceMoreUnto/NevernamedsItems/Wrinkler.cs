using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Wrinkler : AdvancedGunBehavior
{
	public static int WrinklerID;

	public static void Add()
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wrinkler", "wrinkler");
		Game.Items.Rename("outdated_gun_mods:wrinkler", "nn:wrinkler");
		Wrinkler wrinkler = ((Component)val).gameObject.AddComponent<Wrinkler>();
		((AdvancedGunBehavior)wrinkler).overrideNormalReloadAudio = "Play_ENM_Tarnisher_Bite_01";
		((AdvancedGunBehavior)wrinkler).overrideNormalFireAudio = "Play_ENM_Tarnisher_Spit_01";
		((AdvancedGunBehavior)wrinkler).preventNormalFireAudio = true;
		((AdvancedGunBehavior)wrinkler).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Bite The Bullet");
		GunExt.SetLongDescription((PickupObject)(object)val, "Eats bullets on reload, resulting in a net ammo profit overall.\n\nAn elder-ich being whose gluttony knows no grounds. \nIt's odd fractal digestive tract seems to allow it to regurgitate more material than it ingests.");
		val.SetGunSprites("wrinkler");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3f, 0.59f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 8.5f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "WrinklerProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "WrinklerProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(18, 10), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(14, 8), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Wrinkler Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/wrinkler_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/wrinkler_clipempty");
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		WrinklerID = ((PickupObject)val).PickupObjectId;
	}

	private Vector2 EatPosition()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && Object.op_Implicit((Object)(object)((BraveBehaviour)base.gun).sprite))
		{
			PlayerController val = GunTools.GunPlayerOwner(base.gun);
			Vector2 centerPosition = ((GameActor)val).CenterPosition;
			Vector2 val2 = Vector3Extensions.XY(val.unadjustedAimPoint) - centerPosition;
			Vector2 normalized = ((Vector2)(ref val2)).normalized;
			return ((BraveBehaviour)base.gun).sprite.WorldCenter + normalized * 1f;
		}
		return Vector2.zero;
	}

	protected override void Update()
	{
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && (Object)(object)((GameActor)GunTools.GunPlayerOwner(base.gun)).CurrentGun != (Object)null && ((PickupObject)((GameActor)GunTools.GunPlayerOwner(base.gun)).CurrentGun).PickupObjectId == WrinklerID && base.gun.IsReloading && StaticReferenceManager.AllProjectiles != null && StaticReferenceManager.AllProjectiles.Count > 0)
		{
			for (int num = StaticReferenceManager.AllProjectiles.Count - 1; num >= 0; num--)
			{
				Projectile val = StaticReferenceManager.AllProjectiles[num];
				if (Object.op_Implicit((Object)(object)val) && ((Object)(object)val.Owner == (Object)null || !(val.Owner is PlayerController)) && !val.ImmuneToBlanks && (Object)(object)((BraveBehaviour)val).specRigidbody != (Object)null && Vector2.Distance(EatPosition(), ((BraveBehaviour)val).specRigidbody.UnitCenter) < 1.5f)
				{
					val.DieInAir(false, true, true, false);
					if ((double)Random.value <= 0.2)
					{
						base.gun.GainAmmo(2);
					}
					else
					{
						base.gun.GainAmmo(1);
					}
				}
			}
		}
		((AdvancedGunBehavior)this).Update();
	}
}
