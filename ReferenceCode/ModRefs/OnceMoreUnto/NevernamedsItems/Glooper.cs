using System.Collections.Generic;
using System.Reflection;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Glooper : GunBehaviour
{
	public static int GlooperID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Glooper", "glooper");
		Game.Items.Rename("outdated_gun_mods:glooper", "nn:glooper");
		((Component)val).gameObject.AddComponent<Glooper>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Slippery");
		GunExt.SetLongDescription((PickupObject)(object)val, "Made of strange soapy goo, this weapon slips out of your hands when reloaded.");
		val.SetGunSprites("glooper");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(599);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0f;
		val.DefaultModule.angleVariance = 12f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.06f, 0.93f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)55;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.force *= 2.5f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "GlooperProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "GlooperProjectile", new List<IntVector2>
		{
			new IntVector2(7, 7),
			new IntVector2(5, 9),
			new IntVector2(7, 7),
			new IntVector2(9, 5)
		}, MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Glooper Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/glooper_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/glooper_clipempty");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GlooperID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
		if (Object.op_Implicit((Object)(object)((GameActor)player).CurrentGun) && ((PickupObject)((GameActor)player).CurrentGun).PickupObjectId == GlooperID)
		{
			ForceThrow(player);
		}
	}

	private void ForceThrow(PlayerController user)
	{
		((GameActor)user).CurrentGun.PrepGunForThrow();
		typeof(Gun).GetField("m_prepThrowTime", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(((GameActor)user).CurrentGun, 999);
		((GameActor)user).CurrentGun.CeaseAttack(true, (ProjectileData)null);
	}
}
