using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class OrbOfTheGun : AdvancedGunBehavior
{
	public static void Add()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Orb of the Gun", "orbofthegun");
		Game.Items.Rename("outdated_gun_mods:orb_of_the_gun", "nn:orb_of_the_gun");
		OrbOfTheGun orbOfTheGun = ((Component)val).gameObject.AddComponent<OrbOfTheGun>();
		((AdvancedGunBehavior)orbOfTheGun).preventNormalFireAudio = true;
		((AdvancedGunBehavior)orbOfTheGun).overrideNormalFireAudio = "Play_BOSS_agunim_orb_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Hypershot");
		GunExt.SetLongDescription((PickupObject)(object)val, "This gun is from a strange non-euclidian plane of reality, where it used to be able to only point in one direction.\n\nReloading when the clip is more than 50% empty sends bullets close to you to another dimension.");
		val.SetGunSprites("orbofthegun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.7f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 15;
		val.gunHandedness = (GunHandedness)3;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.62f, 0f);
		val.SetBaseMaxAmmo(125);
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 4f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 2f;
		val2.pierceMinorBreakables = true;
		val2.SetProjectileSprite("orbofthegun_projectile", 20, 12, lightened: true, (Anchor)4, 20, 12, anchorChangesCollider: true, fixesScale: false, null, null);
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void OnReload(PlayerController player, Gun gun)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)player != (Object)null && (Object)(object)gun != (Object)null && gun.ClipShotsRemaining < gun.ClipCapacity / 2)
		{
			PlayerUtility.DoEasyBlank(player, ((BraveBehaviour)player).specRigidbody.UnitCenter, (EasyBlankType)1);
		}
		((AdvancedGunBehavior)this).OnReload(player, gun);
	}
}
