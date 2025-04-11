using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Icicle : GunBehaviour
{
	public static int IcicleID;

	public static void Add()
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Icicle", "icicle");
		Game.Items.Rename("outdated_gun_mods:icicle", "nn:icicle");
		((Component)val).gameObject.AddComponent<Icicle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Begins Anew");
		GunExt.SetLongDescription((PickupObject)(object)val, "Becomes more powerful the cooler it's owner is.\n\nSnapped off of the ceiling of the Hollow's deepest catacomb, and somehow hasn't thawed ever since.");
		val.SetGunSprites("icicle");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(199);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)4, 1f, (ModifyMethod)0);
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.62f, 0.56f, 0f);
		val.SetBaseMaxAmmo(220);
		val.ammo = 220;
		val.gunClass = (GunClass)35;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		val2.damageTypes = (CoreDamageTypes)(val2.damageTypes | 8);
		ScaleProjectileStatOffPlayerStat scaleProjectileStatOffPlayerStat = ((Component)val2).gameObject.AddComponent<ScaleProjectileStatOffPlayerStat>();
		scaleProjectileStatOffPlayerStat.multiplierPerLevelOfStat = 0.2f;
		scaleProjectileStatOffPlayerStat.projstat = ScaleProjectileStatOffPlayerStat.ProjectileStatType.DAMAGE;
		scaleProjectileStatOffPlayerStat.playerstat = (StatType)4;
		SimpleFreezingBulletBehaviour simpleFreezingBulletBehaviour = ((Component)val2).gameObject.AddComponent<SimpleFreezingBulletBehaviour>();
		simpleFreezingBulletBehaviour.freezeAmount = 40;
		simpleFreezingBulletBehaviour.useSpecialTint = false;
		simpleFreezingBulletBehaviour.freezeAmountForBosses = 40;
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.CollisionSpawnRadius = 0.8f;
		val3.SpawnGoopOnCollision = true;
		val3.SpawnGoopInFlight = false;
		val3.goopDefinition = EasyGoopDefinitions.WaterGoop;
		val2.SetProjectileSprite("icicle_projectile", 13, 5, lightened: false, (Anchor)4, 13, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Icicle Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/icicle_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/icicle_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		IcicleID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (!(projectile.Owner is PlayerController))
		{
			return;
		}
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "You Need To Chill"))
		{
			SimpleFreezingBulletBehaviour component = ((Component)projectile).gameObject.GetComponent<SimpleFreezingBulletBehaviour>();
			if ((Object)(object)component != (Object)null)
			{
				component.freezeAmount *= 2;
			}
		}
	}
}
