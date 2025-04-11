using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Welrod : AdvancedGunBehavior
{
	public static int WelrodID;

	public static void Add()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Welrod", "welrod");
		Game.Items.Rename("outdated_gun_mods:welrod", "nn:welrod");
		Welrod welrod = ((Component)val).gameObject.AddComponent<Welrod>();
		((AdvancedGunBehavior)welrod).overrideNormalFireAudio = "Play_WPN_SAA_impact_01";
		((AdvancedGunBehavior)welrod).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Quiet, Quiet");
		GunExt.SetLongDescription((PickupObject)(object)val, "Designed for stealth assasination missions behind enemy lines, the Welrod is quiet and efficient.");
		val.SetGunSprites("welrod");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 4;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.18f, 0.56f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 15f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration = 1;
		GunTools.SetProjectileSpriteRight(val2, "welrod_projectile", 7, 5, true, (Anchor)4, (int?)6, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		WelrodID = ((PickupObject)val).PickupObjectId;
	}
}
