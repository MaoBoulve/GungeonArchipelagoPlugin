using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DeskFan : AdvancedGunBehavior
{
	public static int DeskFanID;

	public static Projectile overrideGustyProj;

	public static void Add()
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Desk Fan", "deskfan");
		Game.Items.Rename("outdated_gun_mods:desk_fan", "nn:desk_fan");
		((Component)val).gameObject.AddComponent<DeskFan>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Night Shift");
		GunExt.SetLongDescription((PickupObject)(object)val, "Pushes enemies away, and does slight damage.\n\nHides great and terrible secrets... maybe.");
		val.SetGunSprites("deskfan");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 24);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(520);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.reloadTime = 0.8f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.62f, 0.62f, 0f);
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.SetBaseMaxAmmo(700);
		val.ammo = 700;
		val.doesScreenShake = false;
		val.gunClass = (GunClass)55;
		val.DefaultModule.angleVariance = 5f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 30;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 1f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.01f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 1f;
		GameObjectExtensions.GetOrAddComponent<DeskFanBlowey>(((Component)val2).gameObject);
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 0.1f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		DeskFanID = ((PickupObject)val).PickupObjectId;
		PickupObject byId3 = PickupObjectDatabase.GetById(520);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 10f;
		DeskFanBlowey orAddComponent = GameObjectExtensions.GetOrAddComponent<DeskFanBlowey>(((Component)val3).gameObject);
		orAddComponent.deleteSelf = false;
		overrideGustyProj = val3;
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		if (gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = gun.CurrentOwner;
			if (CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null), "Fresh Air") && Random.value < 0.1f)
			{
				return overrideGustyProj;
			}
			return projectile;
		}
		return projectile;
	}
}
