using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BioTranstater2100 : AdvancedGunBehavior
{
	public static int BioTranstater2100ID;

	public static void Add()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bio-Transtater 2100", "biotranstater2100");
		Game.Items.Rename("outdated_gun_mods:biotranstater_2100", "nn:bio_transtater_2100");
		BioTranstater2100 bioTranstater = ((Component)val).gameObject.AddComponent<BioTranstater2100>();
		((AdvancedGunBehavior)bioTranstater).overrideNormalFireAudio = "Play_WPN_dl45heavylaser_shot_01";
		((AdvancedGunBehavior)bioTranstater).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Don't Get Used To Yourself");
		GunExt.SetLongDescription((PickupObject)(object)val, "A highly advanced piece of alien technology developed by a race of cephalopodal beings native to a far off world.\n\nDeconstructs organisms on a cellular level, and rearranges them into something else.\nThis process is incredibly painful.");
		val.SetGunSprites("biotranstater2100");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		PickupObject byId = PickupObjectDatabase.GetById(90);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.25f;
		val.DefaultModule.numberOfFinalProjectiles = 0;
		val.DefaultModule.finalProjectile = null;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.68f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 10f;
		SimpleRandomTransmogrifyComponent simpleRandomTransmogrifyComponent = ((Component)val2).gameObject.AddComponent<SimpleRandomTransmogrifyComponent>();
		simpleRandomTransmogrifyComponent.maintainHPPercent = true;
		simpleRandomTransmogrifyComponent.chaosPalette = true;
		simpleRandomTransmogrifyComponent.RandomStringList.AddRange(MagickeCauldron.chaosEnemyPalette);
		if (Object.op_Implicit((Object)(object)((Component)val2).GetComponent<PierceProjModifier>()))
		{
			Object.Destroy((Object)(object)((Component)val2).GetComponent<PierceProjModifier>());
		}
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		BioTranstater2100ID = ((PickupObject)val).PickupObjectId;
	}
}
