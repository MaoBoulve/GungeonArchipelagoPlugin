using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Pandephonium : AdvancedGunBehavior
{
	public static int PandephoniumID;

	public static void Add()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pandephonium", "pandephonium");
		Game.Items.Rename("outdated_gun_mods:pandephonium", "nn:pandephonium");
		Pandephonium pandephonium = ((Component)val).gameObject.AddComponent<Pandephonium>();
		((AdvancedGunBehavior)pandephonium).preventNormalFireAudio = true;
		((AdvancedGunBehavior)pandephonium).overrideNormalFireAudio = "Play_PandephoniumSound";
		GunExt.SetShortDescription((PickupObject)(object)val, "Chaostric Melody");
		GunExt.SetLongDescription((PickupObject)(object)val, "The bullets from this peculiar brass shotgun seem to want revenge against their creator. Even though they can't do any real harm, this won't stop them trying.");
		val.SetGunSprites("pandephonium");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.37f, 0.93f, 0f);
		for (int i = 0; i < 9; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 3.5f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 100f;
		((Component)val2).gameObject.AddComponent<PandephoniumBounce>();
		val2.AdditionalScaleMultiplier *= 0.5f;
		int num = 1;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.numberOfShotsInClip = 3;
			projectile.cooldownTime = 0.5f;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.shootStyle = (ShootStyle)0;
			if (num < 5)
			{
				float num2 = 0.2f;
				num2 *= (float)num;
				projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, 0f - num2));
			}
			else if (num > 5)
			{
				float num3 = 0.2f;
				num3 *= (float)(num - 5);
				projectile.positionOffset = Vector2.op_Implicit(new Vector2(0f, num3));
			}
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			projectile.angleVariance = 0f;
			projectile.projectiles[0] = val2;
			num++;
		}
		val.reloadTime = 1f;
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)5;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PandephoniumID = ((PickupObject)val).PickupObjectId;
	}
}
