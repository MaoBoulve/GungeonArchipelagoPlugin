using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GrenadeShotgun : GunBehaviour
{
	public static int GrenadeShotgunID;

	public static void Add()
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Grenade Shotgun", "grenadeshotgun");
		Game.Items.Rename("outdated_gun_mods:grenade_shotgun", "nn:grenade_shotgun");
		((Component)val).gameObject.AddComponent<GrenadeShotgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Sit Down");
		GunExt.SetLongDescription((PickupObject)(object)val, "The product of combining two of the most entertaining classes of weaponry- Shotguns, and the ones that explode.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "grenadeshotgun_idle_001", 8, "grenadeshotgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		for (int i = 0; i < 4; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(19);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 1f;
			projectile.angleVariance = 15f;
			projectile.numberOfShotsInClip = 1;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			val2.baseData.range = 7f;
			BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
			orAddComponent.numberOfBounces = 1;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 2f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.18f, 0.68f, 0f);
		val.SetBaseMaxAmmo(40);
		val.gunClass = (GunClass)45;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(37);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		GrenadeShotgunID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_GRENADESHOTGUN, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(40, null);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.speed *= Random.Range(0.5f, 1.5f);
			ProjectileData baseData2 = projectile.baseData;
			baseData2.range *= Random.Range(1f, 1.5f);
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
