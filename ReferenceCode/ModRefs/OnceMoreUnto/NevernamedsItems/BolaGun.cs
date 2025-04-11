using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BolaGun : AdvancedGunBehavior
{
	public static int BolaGunID;

	public static GameObject LinkVFX;

	public static void Add()
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bola Gun", "bolagun");
		Game.Items.Rename("outdated_gun_mods:bola_gun", "nn:bola_gun");
		BolaGun bolaGun = ((Component)val).gameObject.AddComponent<BolaGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Deathly Strands");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires swinging bolas connected by frazzling energy beams.\n\nThe wide swing of the bolas renders the weapon ineffective in narrow corridors.");
		val.SetGunSprites("bolagun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.gunClass = (GunClass)15;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.56f, 0.81f, 0f);
		val.SetBaseMaxAmmo(210);
		val.carryPixelOffset = new IntVector2(10, -3);
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.damage *= 2f;
		ProjectileBuilders.SetProjectileCollisionRight(val2, "bolagun_projectile", Initialisation.ProjectileCollection, 9, 9, true, (Anchor)4, (int?)7, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		Projectile val3 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val.DefaultModule.projectiles[0] = val3;
		val3.baseData.damage = 7f;
		ProjectileData baseData4 = val3.baseData;
		baseData4.speed *= 0.5f;
		ProjectileData baseData5 = val3.baseData;
		baseData5.range *= 10f;
		BolaControlla bolaControlla = ((Component)val3).gameObject.AddComponent<BolaControlla>();
		bolaControlla.bolaPrefab = ((Component)val2).gameObject;
		((BraveBehaviour)((BraveBehaviour)val3).sprite).renderer.enabled = false;
		NoCollideBehaviour noCollideBehaviour = ((Component)val3).gameObject.AddComponent<NoCollideBehaviour>();
		noCollideBehaviour.worksOnEnemies = true;
		noCollideBehaviour.worksOnProjectiles = true;
		((BraveBehaviour)val3).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Bola Gun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/bolagun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/bolagun_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		BolaGunID = ((PickupObject)val).PickupObjectId;
		LinkVFX = FakePrefab.Clone(((Component)Game.Items["shock_rounds"]).GetComponent<ComplexProjectileModifier>().ChainLightningVFX);
	}
}
