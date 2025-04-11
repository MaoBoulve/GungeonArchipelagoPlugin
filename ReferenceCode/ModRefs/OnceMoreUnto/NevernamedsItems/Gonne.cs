using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Gonne : GunBehaviour
{
	public static int GonneID;

	public static void Add()
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gonne", "gonne");
		Game.Items.Rename("outdated_gun_mods:gonne", "nn:gonne");
		((Component)val).gameObject.AddComponent<Gonne>();
		GunExt.SetShortDescription((PickupObject)(object)val, "It Whispers To Me");
		GunExt.SetLongDescription((PickupObject)(object)val, "This peculiar old-fashioned firearm whispers offers of power and domination to it's bearer.\n\nFor the rest of the Galaxy's safety, it was cast away to the depths of the Gungeon.");
		val.SetGunSprites("gonne");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(519);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)4;
		val.DefaultModule.burstShotCount = 3;
		val.DefaultModule.burstCooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.18f, 0.62f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.damage *= 2.4f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Gonne";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GonneID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((GunBehaviour)this).PostProcessProjectile(projectile);
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Discworld"))
		{
			HomingModifier val2 = ((Component)projectile).gameObject.AddComponent<HomingModifier>();
			val2.AngularVelocity = 250f;
			val2.HomingRadius = 250f;
		}
	}
}
