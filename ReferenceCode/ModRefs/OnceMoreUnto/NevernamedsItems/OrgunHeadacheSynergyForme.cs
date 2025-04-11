using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class OrgunHeadacheSynergyForme : GunBehaviour
{
	public static int OrgunHeadacheSynergyFormeID;

	public static void Add()
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bigass Brain Thing", "orgun_headache");
		Game.Items.Rename("outdated_gun_mods:bigass_brain_thing", "nn:orgun+headache");
		((Component)val).gameObject.AddComponent<OrgunHeadacheSynergyForme>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Activates those almonds");
		GunExt.SetLongDescription((PickupObject)(object)val, "Aww yeah, it's big brain time.\n\nAlso, if you're reading this, you're a cheaty haxxor.");
		val.SetGunSprites("orgun_headache", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		for (int i = 0; i < 10; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.9f;
			projectile.angleVariance = 50f;
			projectile.numberOfShotsInClip = 6;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 4f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 0.3f;
			GunTools.SetProjectileSpriteRight(val2, "orgun_headache_projectile", 11, 14, true, (Anchor)4, (int?)10, (int?)13, true, false, (int?)null, (int?)null, (Projectile)null);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 1.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.62f, 0.87f, 0f);
		val.SetBaseMaxAmmo(120);
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Orgun Headache Synergy Forme";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Orgun");
		OrgunHeadacheSynergyFormeID = ((PickupObject)val).PickupObjectId;
	}
}
