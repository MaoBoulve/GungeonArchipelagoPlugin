using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class LovePistol : GunBehaviour
{
	public static int LovePistolID;

	public static void Add()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Love Pistol", "lovepistol");
		Game.Items.Rename("outdated_gun_mods:love_pistol", "nn:love_pistol");
		((Component)val).gameObject.AddComponent<LovePistol>();
		GunExt.SetShortDescription((PickupObject)(object)val, ";)");
		GunExt.SetLongDescription((PickupObject)(object)val, "A low powered pistol, formerly kept in the back pocket of Hespera, the Pride of Venus, for times of need.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "lovepistol_idle_001", 8, "lovepistol_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(199);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 9;
		val.SetBarrel(22, 12);
		val.SetBaseMaxAmmo(400);
		val.gunClass = (GunClass)40;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(86, 4f);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.9f;
		val2.AppliesCharm = true;
		val2.CharmApplyChance = 1f;
		val2.charmEffect = StaticStatusEffects.charmingRoundsEffect;
		val2.SetProjectileSprite("lovepistol_projectile", 7, 6, lightened: true, (Anchor)4, 7, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		val.AddShellCasing(1, 0, 0, 0, "shell_pink");
		val.AddClipSprites("lovepistol");
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPoolBundle("LovePistolMuzzle", usesZHeight: false, 0f, (VFXAlignment)0, 10f, Color32.op_Implicit(new Color32((byte)250, (byte)0, (byte)0, byte.MaxValue)));
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmallHeartImpact;
		val2.hitEffects.alwaysUseMidair = true;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		LovePistolID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Toxic Love"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 2f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Everlasting Love"))
			{
				projectile.charmEffect = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect;
			}
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
