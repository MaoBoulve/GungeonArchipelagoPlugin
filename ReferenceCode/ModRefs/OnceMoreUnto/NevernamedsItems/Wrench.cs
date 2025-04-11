using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Wrench : AdvancedGunBehavior
{
	public static int WrenchID;

	private int currentItems;

	private int lastItems;

	private int currentActives;

	private int lastActives;

	private int currentGuns;

	private int lastGuns;

	private int AmountOfModdedShit;

	public static void Add()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wrench", "wrench");
		Game.Items.Rename("outdated_gun_mods:wrench", "nn:wrench");
		((Component)val).gameObject.AddComponent<Wrench>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Mod The Gun");
		GunExt.SetLongDescription((PickupObject)(object)val, "While appearing unremarkable, this wonky wrench is actually an artefact of great power.\n\nResponsible for the tear in the dimensional curtain through which new strange artefacts migrate to the Gungeon to this very day.\n\nGrows stronger for each esoteric artefact in your possession.");
		val.SetGunSprites("wrench");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.31f, 0f);
		val.SetBaseMaxAmmo(400);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		GunTools.SetProjectileSpriteRight(val2, "wrench_if_projectile", 12, 7, false, (Anchor)4, (int?)12, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData4 = val3.baseData;
		baseData4.damage *= 1.6f;
		ProjectileData baseData5 = val3.baseData;
		baseData5.speed *= 1f;
		ProjectileData baseData6 = val3.baseData;
		baseData6.range *= 10f;
		GunTools.SetProjectileSpriteRight(val3, "wrench_else_projectile", 20, 7, false, (Anchor)4, (int?)20, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		ProjectileData baseData7 = val4.baseData;
		baseData7.damage *= 1.6f;
		ProjectileData baseData8 = val4.baseData;
		baseData8.speed *= 1f;
		ProjectileData baseData9 = val4.baseData;
		baseData9.range *= 10f;
		GunTools.SetProjectileSpriteRight(val4, "wrench_float_projectile", 19, 7, false, (Anchor)4, (int?)19, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		ProjectileData baseData10 = val5.baseData;
		baseData10.damage *= 1.6f;
		ProjectileData baseData11 = val5.baseData;
		baseData11.speed *= 1f;
		ProjectileData baseData12 = val5.baseData;
		baseData12.range *= 10f;
		GunTools.SetProjectileSpriteRight(val5, "wrench_bool_projectile", 15, 7, false, (Anchor)4, (int?)15, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		Projectile val6 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val6).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val6).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val6);
		ProjectileData baseData13 = val6.baseData;
		baseData13.damage *= 1.6f;
		ProjectileData baseData14 = val6.baseData;
		baseData14.speed *= 1f;
		ProjectileData baseData15 = val6.baseData;
		baseData15.range *= 10f;
		GunTools.SetProjectileSpriteRight(val6, "wrench_int_projectile", 9, 7, false, (Anchor)4, (int?)9, (int?)7, true, false, (int?)null, (int?)null, (Projectile)null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.projectiles.Add(val3);
		val.DefaultModule.projectiles.Add(val4);
		val.DefaultModule.projectiles.Add(val5);
		val.DefaultModule.projectiles.Add(val6);
		val.gunClass = (GunClass)50;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		WrenchID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (AmountOfModdedShit >= 1)
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 0.1f * (float)AmountOfModdedShit + 1f;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	protected override void Update()
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (Object.op_Implicit((Object)(object)val))
		{
			currentItems = val.passiveItems.Count;
			currentActives = val.activeItems.Count;
			currentGuns = val.inventory.AllGuns.Count;
			if (currentItems != lastItems || currentActives != lastActives || currentGuns != lastGuns)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				foreach (PassiveItem passiveItem in val.passiveItems)
				{
					if (((PickupObject)passiveItem).PickupObjectId > 823 || ((PickupObject)passiveItem).PickupObjectId < 0)
					{
						num++;
					}
				}
				foreach (PlayerItem activeItem in val.activeItems)
				{
					if (((PickupObject)activeItem).PickupObjectId > 823 || ((PickupObject)activeItem).PickupObjectId < 0)
					{
						num2++;
					}
				}
				foreach (Gun allGun in val.inventory.AllGuns)
				{
					if (((PickupObject)allGun).PickupObjectId > 823 || ((PickupObject)allGun).PickupObjectId < 0)
					{
						num3++;
					}
				}
				AmountOfModdedShit = num + num2 + num3;
				lastItems = currentItems;
				lastActives = currentActives;
				lastGuns = currentGuns;
			}
		}
		((AdvancedGunBehavior)this).Update();
	}
}
