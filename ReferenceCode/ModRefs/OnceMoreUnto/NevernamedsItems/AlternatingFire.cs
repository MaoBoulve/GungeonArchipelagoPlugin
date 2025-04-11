using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class AlternatingFire : AdvancedGunBehavior
{
	public float timer;

	public bool alternate = false;

	public static Projectile alternateProj;

	public static int ID;

	public static void Add()
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Alternating Fire", "alternatingfire");
		Game.Items.Rename("outdated_gun_mods:alternating_fire", "nn:alternating_fire");
		AlternatingFire alternatingFire = ((Component)val).gameObject.AddComponent<AlternatingFire>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Worth the Risk");
		GunExt.SetLongDescription((PickupObject)(object)val, "Alternates every two seconds between smaller, punchier bullets and larger, more powerful projectiles. \n\nThis gun exists simultaneously in both the elemental planes of light and darkness, and is constantly phasing between the two.");
		val.SetGunSprites("alternatingfire");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 7);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(47);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(13);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.085f;
		val.DefaultModule.numberOfShotsInClip = 35;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.125f, 1f, 0f);
		val.SetBaseMaxAmmo(800);
		val.gunClass = (GunClass)10;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Object)((Component)val2).gameObject).name = "alternatingfire_proj";
		val2.SetProjectileSprite("alternatingfire_proj", 7, 7, lightened: true, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		val2.baseData.damage = 6f;
		val.DefaultModule.projectiles[0] = val2;
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		alternateProj = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		alternateProj.SetProjectileSprite("alternatingfire_proj2", 7, 7, lightened: true, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		alternateProj.hitEffects.alwaysUseMidair = true;
		alternateProj.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		alternateProj.baseData.damage = 3f;
		ProjectileData baseData = alternateProj.baseData;
		baseData.speed *= 2f;
		ProjectileData baseData2 = alternateProj.baseData;
		baseData2.force *= 2f;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("AlternatingFireClip", "NevernamedsItems/Resources/CustomGunAmmoTypes/alternatingfire_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/alternatingfire_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		if (timer >= 2f)
		{
			alternate = !alternate;
			timer = 0f;
		}
		else
		{
			timer += BraveTime.DeltaTime;
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		if (alternate && ((Object)((Component)projectile).gameObject).name.Contains("alternatingfire"))
		{
			return alternateProj;
		}
		return ((AdvancedGunBehavior)this).OnPreFireProjectileModifier(gun, projectile, mod);
	}
}
