using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RapidRiposte : AdvancedGunBehavior
{
	public static int RapidRiposteID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rapid Riposte", "rapidriposte");
		Game.Items.Rename("outdated_gun_mods:rapid_riposte", "nn:rapid_riposte");
		((Component)val).gameObject.AddComponent<RapidRiposte>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Top Tier Gunsmanship");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires with the utmost precision, parrying projectiles back at their owners.\n\nAn old rapier, modified for gunslinging.");
		val.SetGunSprites("rapidriposte");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(417);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 1f;
		val.DefaultModule.numberOfShotsInClip = 5;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.62f, 0.43f, 0f);
		val.SetBaseMaxAmmo(130);
		val.ammo = 130;
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 3f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 3f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 2f;
		AdvancedMirrorProjectileModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<AdvancedMirrorProjectileModifier>(((Component)val2).gameObject);
		orAddComponent.projectileSurvives = true;
		orAddComponent.maxMirrors = 1;
		orAddComponent.postProcessReflectedBullets = true;
		orAddComponent.tintsBullets = false;
		val2.SetProjectileSprite("rapidriposte_projectile", 26, 8, lightened: true, (Anchor)4, 13, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		RapidRiposteID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)((Component)projectile).GetComponent<AdvancedMirrorProjectileModifier>()) && projectile.Owner is PlayerController && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Wouldn't You Agree?"))
		{
			((Component)projectile).GetComponent<AdvancedMirrorProjectileModifier>().RapidRiposteWeebshitSynergy = true;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
