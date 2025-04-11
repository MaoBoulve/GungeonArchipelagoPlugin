using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class NNMinigun : GunBehaviour
{
	public static int MiniGunID;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Mini Gun", "nnminigun2");
		Game.Items.Rename("outdated_gun_mods:mini_gun", "nn:mini_gun");
		((Component)val).gameObject.AddComponent<NNMinigun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Misleading Name");
		GunExt.SetLongDescription((PickupObject)(object)val, "A tiny toy gun, probably pulled from the grip of a tiny toy soldier.");
		val.SetGunSprites("nnminigun2", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 16);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(79);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(43);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.gunClass = (GunClass)1;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 4;
		val.SetBaseMaxAmmo(100);
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.SetBarrel(9, 5);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.AdditionalScaleMultiplier *= 0.5f;
		val2.baseData.damage = 6f;
		val.AddShellCasing(0, 0, 4, 0, "shell_tiny");
		val.AddClipSprites("minigun");
		MiniGunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Micro Aggressions") && Random.value <= 0.1f)
		{
			projectile.AdjustPlayerProjectileTint(ExtendedColours.vibrantOrange, 2, 0f);
			projectile.statusEffectsToApply.Add((GameActorEffect)(object)StatusEffectHelper.GenerateSizeEffect(5f, new Vector2(0.4f, 0.4f)));
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
