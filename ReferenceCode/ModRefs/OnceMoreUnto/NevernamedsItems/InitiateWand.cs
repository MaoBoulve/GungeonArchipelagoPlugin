using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class InitiateWand : AdvancedGunBehavior
{
	public static Projectile GreenBouncyProj;

	public static Projectile EnergyBall;

	public static Projectile PinkBouncer;

	public static int InitiateWandID;

	public int currentForm = -1;

	public static void Add()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Initiate Wand", "initiatewand");
		Game.Items.Rename("outdated_gun_mods:initiate_wand", "nn:initiate_wand");
		((Component)val).gameObject.AddComponent<InitiateWand>();
		GunExt.SetShortDescription((PickupObject)(object)val, "You Just Got Witch'd");
		GunExt.SetLongDescription((PickupObject)(object)val, "Adopts one of four random spell types each time it is encountered.\n\nCrafted (poorly) by an Apprentice Gunjurer.");
		val.SetGunSprites("initiatewand");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(145);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(33);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfShotsInClip = 4;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.5f, 0f);
		val.SetBaseMaxAmmo(180);
		val.gunClass = (GunClass)50;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 8f;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 2f;
		EasyTrailBullet easyTrailBullet = ((Component)val2).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val2).transform.position);
		easyTrailBullet.StartWidth = 0.25f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 0.5f;
		easyTrailBullet.BaseColor = ExtendedColours.pink;
		easyTrailBullet.EndColor = ExtendedColours.pink;
		val2.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(145);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.enemy.effects[0].effects[0].effect;
		GunTools.SetProjectileSpriteRight(val2, "initiatewand_sparkbolt", 7, 7, true, (Anchor)4, (int?)7, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		SpecialProjectileIdentifier specialProjectileIdentifier = ((Component)val2).gameObject.AddComponent<SpecialProjectileIdentifier>();
		specialProjectileIdentifier.SpecialIdentifier = "INITIATE_WAND";
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 17f;
		ProjectileData baseData3 = val3.baseData;
		baseData3.speed *= 0.6f;
		ProjectileData baseData4 = val3.baseData;
		baseData4.range *= 0.5f;
		EasyTrailBullet easyTrailBullet2 = ((Component)val3).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet2.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val3).transform.position);
		easyTrailBullet2.StartWidth = 0.5f;
		easyTrailBullet2.EndWidth = 0f;
		easyTrailBullet2.LifeTime = 0.2f;
		easyTrailBullet2.BaseColor = ExtendedColours.freezeBlue;
		easyTrailBullet2.EndColor = ExtendedColours.freezeBlue;
		val3.hitEffects.alwaysUseMidair = true;
		ref GameObject overrideMidairDeathVFX2 = ref val3.hitEffects.overrideMidairDeathVFX;
		PickupObject byId6 = PickupObjectDatabase.GetById(18);
		overrideMidairDeathVFX2 = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		GunTools.SetProjectileSpriteRight(val3, "initiatewand_energyball", 8, 8, true, (Anchor)4, (int?)7, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		SpecialProjectileIdentifier specialProjectileIdentifier2 = ((Component)val3).gameObject.AddComponent<SpecialProjectileIdentifier>();
		specialProjectileIdentifier2.SpecialIdentifier = "INITIATE_WAND";
		EnergyBall = val3;
		PickupObject byId7 = PickupObjectDatabase.GetById(86);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.baseData.damage = 5.5f;
		ProjectileData baseData5 = val4.baseData;
		baseData5.speed *= 3f;
		ProjectileData baseData6 = val4.baseData;
		baseData6.range *= 10f;
		val4.hitEffects.alwaysUseMidair = true;
		EasyTrailBullet easyTrailBullet3 = ((Component)val4).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet3.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val4).transform.position);
		easyTrailBullet3.StartWidth = 0.125f;
		easyTrailBullet3.EndWidth = 0f;
		easyTrailBullet3.LifeTime = 0.5f;
		easyTrailBullet3.BaseColor = ExtendedColours.poisonGreen;
		easyTrailBullet3.EndColor = ExtendedColours.poisonGreen;
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val4).gameObject);
		orAddComponent.numberOfBounces = 3;
		orAddComponent.damageMultiplierOnBounce = 2f;
		ref GameObject overrideMidairDeathVFX3 = ref val4.hitEffects.overrideMidairDeathVFX;
		PickupObject byId8 = PickupObjectDatabase.GetById(89);
		overrideMidairDeathVFX3 = ((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		GunTools.SetProjectileSpriteRight(val4, "initiatewand_bouncer", 4, 4, true, (Anchor)4, (int?)4, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
		SpecialProjectileIdentifier specialProjectileIdentifier3 = ((Component)val4).gameObject.AddComponent<SpecialProjectileIdentifier>();
		specialProjectileIdentifier3.SpecialIdentifier = "INITIATE_WAND";
		GreenBouncyProj = val4;
		PickupObject byId9 = PickupObjectDatabase.GetById(86);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId9 is Gun) ? byId9 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		val5.baseData.damage = 22f;
		ProjectileData baseData7 = val5.baseData;
		baseData7.speed *= 1.5f;
		val5.hitEffects.alwaysUseMidair = true;
		ScaleChangeOverTimeModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ScaleChangeOverTimeModifier>(((Component)val5).gameObject);
		orAddComponent2.destroyAfterChange = true;
		orAddComponent2.timeToChangeOver = 0.3f;
		orAddComponent2.ScaleToChangeTo = 0.01f;
		orAddComponent2.suppressDeathFXIfdestroyed = true;
		BounceProjModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val5).gameObject);
		orAddComponent3.numberOfBounces = 1;
		orAddComponent3.damageMultiplierOnBounce = 1f;
		val5.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofPink;
		GunTools.SetProjectileSpriteRight(val5, "initiatewand_pinkshitty", 8, 8, true, (Anchor)4, (int?)6, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		SpecialProjectileIdentifier specialProjectileIdentifier4 = ((Component)val5).gameObject.AddComponent<SpecialProjectileIdentifier>();
		specialProjectileIdentifier4.SpecialIdentifier = "INITIATE_WAND";
		PinkBouncer = val5;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Initiate Wand Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/initiatewand_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/initiatewand_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		InitiateWandID = ((PickupObject)val).PickupObjectId;
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		if (currentForm > 0 && (Object)(object)((Component)projectile).GetComponent<SpecialProjectileIdentifier>() != (Object)null && ((Component)projectile).GetComponent<SpecialProjectileIdentifier>().SpecialIdentifier == "INITIATE_WAND")
		{
			switch (currentForm)
			{
			case 2:
				return EnergyBall;
			case 3:
				return GreenBouncyProj;
			case 4:
				return PinkBouncer;
			}
		}
		return ((AdvancedGunBehavior)this).OnPreFireProjectileModifier(gun, projectile, mod);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (currentForm == -1)
		{
			currentForm = Random.Range(1, 5);
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}
}
