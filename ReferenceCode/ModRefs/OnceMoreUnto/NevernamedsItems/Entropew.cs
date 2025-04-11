using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Gungeon;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class Entropew : AdvancedGunBehavior
{
	public static int EntropewID;

	public static Hook chestPreOpenHook;

	public static void Add()
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		Gun val = Databases.Items.NewGun("Entropew", "entropew");
		Game.Items.Rename("outdated_gun_mods:entropew", "nn:entropew");
		((Component)val).gameObject.AddComponent<Entropew>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Controlled Chaos");
		GunExt.SetLongDescription((PickupObject)(object)val, "An icon of disorder and displacement, given form by the Gungeon's Magickes.\n\nStrange things seem to happen when a chest is opened while holding this gun...");
		val.SetGunSprites("entropew");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		for (int i = 0; i < 2; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(56);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)1;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.1f;
			projectile.angleVariance = 2f;
			projectile.numberOfShotsInClip = 40;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.range *= 10f;
			val2.baseData.damage = 6f;
			val2.SetProjectileSprite("entropew_projectile", 5, 7, lightened: true, (Anchor)4, 4, 6, anchorChangesCollider: true, fixesScale: false, null, null);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
				projectile.angleVariance = 40f;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 1.5f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.18f, 0.75f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)10;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		chestPreOpenHook = new Hook((MethodBase)typeof(Chest).GetMethod("Open", BindingFlags.Instance | BindingFlags.NonPublic), typeof(Entropew).GetMethod("ChestPreOpen", BindingFlags.Static | BindingFlags.Public));
		EntropewID = ((PickupObject)val).PickupObjectId;
	}

	public static void ChestPreOpen(Action<Chest, PlayerController> orig, Chest chest, PlayerController opener)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((GameActor)opener).CurrentGun) && ((PickupObject)((GameActor)opener).CurrentGun).PickupObjectId == EntropewID && ((GameActor)opener).CurrentGun.ammo >= 150)
		{
			List<ItemQuality> list = new List<ItemQuality>
			{
				(ItemQuality)1,
				(ItemQuality)2,
				(ItemQuality)3,
				(ItemQuality)4,
				(ItemQuality)5
			};
			chest.PredictContents(opener);
			List<PickupObject> list2 = new List<PickupObject>();
			int count = chest.contents.Count;
			for (int i = 0; i < count; i++)
			{
				PickupObject itemOfTypeAndQuality = LootEngine.GetItemOfTypeAndQuality<PickupObject>(BraveUtility.RandomElement<ItemQuality>(list), (GenericLootTable)null, false);
				list2.Add(itemOfTypeAndQuality);
			}
			chest.contents.Clear();
			chest.contents.AddRange(list2);
			Gun currentGun = ((GameActor)opener).CurrentGun;
			currentGun.ammo -= 150;
		}
		orig(chest, opener);
	}
}
