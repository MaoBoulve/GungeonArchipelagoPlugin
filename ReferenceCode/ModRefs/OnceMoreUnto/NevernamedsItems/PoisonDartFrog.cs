using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PoisonDartFrog : AdvancedGunBehavior
{
	public static int PoisonDartFrogID;

	public static void Add()
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Poison Dart Frog", "poisondartfrog");
		Game.Items.Rename("outdated_gun_mods:poison_dart_frog", "nn:poison_dart_frog");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(599);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetShortDescription((PickupObject)(object)val, "Oh yeah, it's Frog Time");
		GunExt.SetLongDescription((PickupObject)(object)val, "An endangered frog species from inside the Gungeon. Spits poison darts to protect itself.\n\nHow do you 'fire' a frog? How do you RELOAD a frog??");
		val.SetGunSprites("poisondartfrog");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(56);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.2f;
			projectile.angleVariance = 10f;
			projectile.numberOfShotsInClip = 3;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 1.4f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
			val2.damageTypes = (CoreDamageTypes)(val2.damageTypes | 0x10);
			ExtremelySimplePoisonBulletBehaviour extremelySimplePoisonBulletBehaviour = ((Component)val2).gameObject.AddComponent<ExtremelySimplePoisonBulletBehaviour>();
			extremelySimplePoisonBulletBehaviour.procChance = 1;
			extremelySimplePoisonBulletBehaviour.useSpecialTint = false;
			val2.SetProjectileSprite("blowgun_projectile", 16, 7, lightened: false, (Anchor)4, 15, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Blowgun Darts";
		val.reloadTime = 0.5f;
		val.SetBaseMaxAmmo(200);
		((PickupObject)val).quality = (ItemQuality)2;
		val.gunClass = (GunClass)25;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Poison Dart Frog";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.37f, 0f);
		PoisonDartFrogID = ((PickupObject)val).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)val, "non_companion_living_item");
	}
}
