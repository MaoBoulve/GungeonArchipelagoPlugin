using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Bejeweler : GunBehaviour
{
	public enum GemColour
	{
		BLUE,
		GREEN,
		ORANGE,
		PINK,
		RED,
		WHITE,
		YELLOW
	}

	public static Projectile railgun;

	public static GameObject stickyBlue;

	public static GameObject stickyGreen;

	public static GameObject stickyOrange;

	public static GameObject stickyPink;

	public static GameObject stickyRed;

	public static GameObject stickyWhite;

	public static GameObject stickyYellow;

	public static VFXPool hitEffectBlue;

	public static VFXPool hitEffectGreen;

	public static VFXPool hitEffectOrange;

	public static VFXPool hitEffectPink;

	public static VFXPool hitEffectRed;

	public static VFXPool hitEffectWhite;

	public static VFXPool hitEffectYellow;

	public static GameObject cubeVFX;

	public static int ID;

	public static void Add()
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Unknown result type (might be due to invalid IL or missing references)
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0919: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Unknown result type (might be due to invalid IL or missing references)
		//IL_099f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a83: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bejeweler", "bejeweler");
		Game.Items.Rename("outdated_gun_mods:bejeweler", "nn:bejeweler");
		((Component)val).gameObject.AddComponent<Bejeweler>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Gem Jam");
		GunExt.SetLongDescription((PickupObject)(object)val, "Stacks different coloured jewels on enemies. When three gems of the same colour exist in a room, they will be... erased.\n\nVolatile crystals like this are a rare but lucrative opportunity for wandering Minelets deep within the Gungeon.");
		val.SetGunSprites("bejeweler");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(199);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 11);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 1f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)1;
		foreach (string item in new List<string> { "blue", "green", "orange", "pink", "red", "white", "yellow" })
		{
			VFXPool val2 = VFXToolbox.CreateVFXPool("Bejeweler " + item + " Impact", new List<string>
			{
				"NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectilehitvfx_" + item + "_001",
				"NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectilehitvfx_" + item + "_002",
				"NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectilehitvfx_" + item + "_003",
				"NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectilehitvfx_" + item + "_004",
				"NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectilehitvfx_" + item + "_005"
			}, 13, new IntVector2(42, 36), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)2, -1f, null, (WrapMode)2);
			switch (item)
			{
			case "blue":
				hitEffectBlue = val2;
				break;
			case "green":
				hitEffectGreen = val2;
				break;
			case "orange":
				hitEffectOrange = val2;
				break;
			case "pink":
				hitEffectPink = val2;
				break;
			case "red":
				hitEffectRed = val2;
				break;
			case "white":
				hitEffectWhite = val2;
				break;
			case "yellow":
				hitEffectYellow = val2;
				break;
			}
		}
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val3 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		val3.SetProjectileSprite("bejeweler_projectile_blue", 11, 11, lightened: false, (Anchor)4, 11, 11, anchorChangesCollider: true, fixesScale: false, null, null);
		val3.hitEffects.deathAny = hitEffectBlue;
		val3.hitEffects.HasProjectileDeathVFX = true;
		((Component)val3).gameObject.AddComponent<BejewelerStuckJewels>().colour = GemColour.BLUE;
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		Projectile val4 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		val4.SetProjectileSprite("bejeweler_projectile_green", 10, 9, lightened: false, (Anchor)4, 10, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		val4.hitEffects.deathAny = hitEffectGreen;
		val4.hitEffects.HasProjectileDeathVFX = true;
		((Component)val4).gameObject.AddComponent<BejewelerStuckJewels>().colour = GemColour.GREEN;
		PickupObject byId6 = PickupObjectDatabase.GetById(86);
		Projectile val5 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		val5.SetProjectileSprite("bejeweler_projectile_orange", 8, 8, lightened: false, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		val5.hitEffects.deathAny = hitEffectOrange;
		val5.hitEffects.HasProjectileDeathVFX = true;
		((Component)val5).gameObject.AddComponent<BejewelerStuckJewels>().colour = GemColour.ORANGE;
		PickupObject byId7 = PickupObjectDatabase.GetById(86);
		Projectile val6 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId7 is Gun) ? byId7 : null)).DefaultModule.projectiles[0]);
		val6.SetProjectileSprite("bejeweler_projectile_pink", 9, 10, lightened: false, (Anchor)4, 9, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		val6.hitEffects.deathAny = hitEffectPink;
		val6.hitEffects.HasProjectileDeathVFX = true;
		((Component)val6).gameObject.AddComponent<BejewelerStuckJewels>().colour = GemColour.PINK;
		PickupObject byId8 = PickupObjectDatabase.GetById(86);
		Projectile val7 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId8 is Gun) ? byId8 : null)).DefaultModule.projectiles[0]);
		val7.SetProjectileSprite("bejeweler_projectile_red", 9, 9, lightened: false, (Anchor)4, 9, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		val7.hitEffects.deathAny = hitEffectRed;
		val7.hitEffects.HasProjectileDeathVFX = true;
		((Component)val7).gameObject.AddComponent<BejewelerStuckJewels>().colour = GemColour.RED;
		PickupObject byId9 = PickupObjectDatabase.GetById(86);
		Projectile val8 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId9 is Gun) ? byId9 : null)).DefaultModule.projectiles[0]);
		val8.SetProjectileSprite("bejeweler_projectile_white", 10, 10, lightened: false, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		val8.hitEffects.deathAny = hitEffectWhite;
		val8.hitEffects.HasProjectileDeathVFX = true;
		((Component)val8).gameObject.AddComponent<BejewelerStuckJewels>().colour = GemColour.WHITE;
		PickupObject byId10 = PickupObjectDatabase.GetById(86);
		Projectile val9 = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId10 is Gun) ? byId10 : null)).DefaultModule.projectiles[0]);
		val9.SetProjectileSprite("bejeweler_projectile_yellow", 10, 10, lightened: false, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		val9.hitEffects.deathAny = hitEffectYellow;
		val9.hitEffects.HasProjectileDeathVFX = true;
		((Component)val9).gameObject.AddComponent<BejewelerStuckJewels>().colour = GemColour.YELLOW;
		val.DefaultModule.projectiles[0] = val3;
		val.DefaultModule.projectiles.AddRange(new List<Projectile> { val4, val5, val6, val7, val8, val9 });
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Bejeweler Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/bejeweler_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/bejeweler_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		stickyBlue = VFXToolbox.CreateVFX("BlueGemSticky", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectile_blue" }, 0, new IntVector2(11, 11), (Anchor)4, usesZHeight: true, 1f, -1f, null, (WrapMode)0, persist: true);
		stickyGreen = VFXToolbox.CreateVFX("GreenGemSticky", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectile_green" }, 0, new IntVector2(10, 9), (Anchor)4, usesZHeight: true, 1f, -1f, null, (WrapMode)0, persist: true);
		stickyOrange = VFXToolbox.CreateVFX("OrangeGemSticky", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectile_orange" }, 0, new IntVector2(8, 8), (Anchor)4, usesZHeight: true, 1f, -1f, null, (WrapMode)0, persist: true);
		stickyPink = VFXToolbox.CreateVFX("PinkGemSticky", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectile_pink" }, 0, new IntVector2(9, 10), (Anchor)4, usesZHeight: true, 1f, -1f, null, (WrapMode)0, persist: true);
		stickyRed = VFXToolbox.CreateVFX("RedGemSticky", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectile_red" }, 0, new IntVector2(9, 9), (Anchor)4, usesZHeight: true, 1f, -1f, null, (WrapMode)0, persist: true);
		stickyWhite = VFXToolbox.CreateVFX("WhiteGemSticky", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectile_white" }, 0, new IntVector2(10, 10), (Anchor)4, usesZHeight: true, 1f, -1f, null, (WrapMode)0, persist: true);
		stickyYellow = VFXToolbox.CreateVFX("YellowGemSticky", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/Bejeweler/bejeweler_projectile_yellow" }, 0, new IntVector2(10, 10), (Anchor)4, usesZHeight: true, 1f, -1f, null, (WrapMode)0, persist: true);
		foreach (GameObject item2 in new List<GameObject> { stickyBlue, stickyGreen, stickyOrange, stickyPink, stickyRed, stickyWhite, stickyYellow })
		{
			BuffVFXAnimator val10 = item2.AddComponent<BuffVFXAnimator>();
			val10.animationStyle = (BuffAnimationStyle)3;
			val10.AdditionalPierceDepth = 0f;
		}
		cubeVFX = VFXToolbox.CreateVFXBundle("BejewelerCube", usesZHeight: true, 1f, -1f, -1f, null, persist: true);
		PickupObject byId11 = PickupObjectDatabase.GetById(370);
		railgun = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId11 is Gun) ? byId11 : null)).DefaultModule.chargeProjectiles[1].Projectile);
		railgun.PenetratesInternalWalls = true;
		railgun.baseData.damage = 70f;
	}
}
