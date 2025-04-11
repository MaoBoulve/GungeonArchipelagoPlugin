using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class AM0SpreadForme : AdvancedGunBehavior
{
	public static int AM0SpreadFormeID;

	public static void Add()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("AM-0 Spread Forme", "am0spreadforme");
		Game.Items.Rename("outdated_gun_mods:am0_spread_forme", "nn:am0+spreadshot");
		((Component)val).gameObject.AddComponent<AM0SpreadForme>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Fires Ammunition");
		GunExt.SetLongDescription((PickupObject)(object)val, "\n\nThis gun is comically stuffed with whole ammo boxes.");
		val.SetGunSprites("am0spreadforme", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(519);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		val.reloadTime = 0.8f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.43f, 0.75f, 0f);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.angleVariance = 35f;
			projectile.cooldownTime = 0.11f;
			projectile.numberOfShotsInClip = 30;
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			projectile.projectiles[0] = val2;
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 0.55f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 0.7f;
			ProjectileData baseData3 = val2.baseData;
			baseData3.range *= 2f;
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			ProjectileBuilders.AnimateProjectileBundle(val2, "AM0SpreadProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "AM0SpreadProjectile", new List<IntVector2>
			{
				new IntVector2(11, 14),
				new IntVector2(13, 16),
				new IntVector2(13, 16),
				new IntVector2(13, 16),
				new IntVector2(11, 14),
				new IntVector2(13, 16),
				new IntVector2(13, 16),
				new IntVector2(13, 16),
				new IntVector2(11, 14),
				new IntVector2(13, 16),
				new IntVector2(13, 16),
				new IntVector2(13, 16),
				new IntVector2(11, 14),
				new IntVector2(13, 16),
				new IntVector2(13, 16),
				new IntVector2(13, 16)
			}, MiscTools.DupeList(value: false, 16), MiscTools.DupeList<Anchor>((Anchor)4, 16), MiscTools.DupeList(value: true, 16), MiscTools.DupeList(value: false, 16), MiscTools.DupeList<Vector3?>(null, 16), MiscTools.DupeList<IntVector2?>(null, 16), MiscTools.DupeList<IntVector2?>(null, 16), MiscTools.DupeList<Projectile>(null, 16));
		}
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "AM-0");
		AM0SpreadFormeID = ((PickupObject)val).PickupObjectId;
	}
}
