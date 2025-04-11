using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Missinguno : AdvancedGunBehavior
{
	public static int MissingunoID;

	private List<int> viableSourceGuns = new List<int>
	{
		86, 56, 0, 3, 4, 5, 6, 7, 9, 12,
		13, 14, 16, 17, 18, 19, 21, 22, 24, 26,
		27, 28, 29, 32, 33, 37, 39, 42, 45, 47,
		53, 54, 59, 61, 81, 83, 89, 90, 92, 93,
		95, 97, 124, 125, 128, 129, 130, 142, 143, 145,
		146, 149, 150, 151, 152, 153, 154, 156, 169, 175,
		176, 178, 180, 197, 198, 199, 207, 223, 228, 229,
		230, 275, 292, 327, 328, 330, 335, 336, 334, 341,
		338, 339, 340, 345, 347, 357, 360, 362, 365, 369,
		372, 376, 377, 379, 383, 384, 385, 387, 394, 402,
		404, 406, 444, 417, 445, 464, 475, 476, 477, 478,
		479, 480, 481, 482, 483, 484, 503, 504, 506, 507,
		508, 510, 511, 512, 513, 514, 516, 519, 520, 537,
		541, 542, 543, 545, 546, 550, 551, 562, 563, 566,
		576, 577, 593, 594, 596, 597, 598, 599, 601, 602,
		603, 604, 609, 611, 612, 613, 614, 615, 617, 618,
		619, 620, 621, 622, 623, 624, 626, 647, 649, 651,
		652, 656, 657, 659, 660, 670, 672, 673, 674, 676,
		677, 682, 685, 691, 692, 693, 694, 698, 704, 709,
		718, 719, 721, 722, 724, 726, 732, 734, 739, 748,
		755, 761, 762, 809, 810, 811, 812, 813, 819, 8,
		52, 210, 274, 332
	};

	public static void Add()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Missinguno", "missinguno");
		Game.Items.Rename("outdated_gun_mods:missinguno", "nn:missinguno");
		((Component)val).gameObject.AddComponent<Missinguno>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Try Catch This!");
		GunExt.SetLongDescription((PickupObject)(object)val, "This gun can't seem to decide what gun it wants to be!\n\nFished from the deepest waters of the Gungeon's coast.");
		val.SetGunSprites("missinguno");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(13);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.06f, 0.87f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)50;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		MissingunoID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.UNLOCKED_MISSINGUNO, requiredFlagValue: true);
		CustomActions.OnChestPreOpen = (Action<Chest, PlayerController>)Delegate.Combine(CustomActions.OnChestPreOpen, new Action<Chest, PlayerController>(OnChestPreOpen));
	}

	public static void OnChestPreOpen(Chest self, PlayerController opener)
	{
		if (Object.op_Implicit((Object)(object)self) && self.IsGlitched && !SaveAPIManager.GetFlag(CustomDungeonFlags.UNLOCKED_MISSINGUNO))
		{
			SaveAPIManager.SetFlag(CustomDungeonFlags.UNLOCKED_MISSINGUNO, value: true);
		}
	}

	private void ReRandomiseGun(PlayerController player)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Invalid comparison between Unknown and I4
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		int num = 1;
		float value = Random.value;
		if (value <= 0.025f)
		{
			num = 5;
		}
		else if (value <= 0.1f)
		{
			num = 4;
		}
		else if (value <= 0.2f)
		{
			num = 3;
		}
		else if (value <= 0.4f)
		{
			num = 2;
		}
		PickupObject byId = PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(viableSourceGuns));
		Gun val = (Gun)(object)((byId is Gun) ? byId : null);
		List<Projectile> list = new List<Projectile>();
		if ((int)base.gun.DefaultModule.shootStyle == 3)
		{
			Projectile val2 = null;
			for (int i = 0; i < 15; i++)
			{
				ChargeProjectile val3 = GunTools.RawDefaultModule(val).chargeProjectiles[Random.Range(0, GunTools.RawDefaultModule(val).chargeProjectiles.Count)];
				if (val3 != null)
				{
					val2 = val3.Projectile;
				}
				if (Object.op_Implicit((Object)(object)val2))
				{
					break;
				}
			}
			list.Add(val2);
		}
		else
		{
			Projectile val4 = null;
			for (int j = 0; j < 15; j++)
			{
				Projectile val5 = GunTools.RawDefaultModule(val).projectiles[Random.Range(0, GunTools.RawDefaultModule(val).projectiles.Count)];
				if ((Object)(object)val5 != (Object)null)
				{
					val4 = val5;
				}
				if (Object.op_Implicit((Object)(object)val4))
				{
					break;
				}
			}
			list.Add(val4);
		}
		if (base.gun.RawSourceVolley.projectiles.Count() > 1)
		{
			while (base.gun.RawSourceVolley.projectiles.Count() > 1)
			{
				base.gun.RawSourceVolley.projectiles.RemoveAt(1);
			}
		}
		if (num > 1)
		{
			for (int k = 0; k < num - 1; k++)
			{
				Gun gun = base.gun;
				PickupObject byId2 = PickupObjectDatabase.GetById(86);
				GunTools.AddProjectileModuleToRawVolleyFrom(gun, (Gun)(object)((byId2 is Gun) ? byId2 : null), true);
			}
		}
		Projectile val6 = Object.Instantiate<Projectile>(BraveUtility.RandomElement<Projectile>(list));
		((Component)val6).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val6).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val6);
		ProjectileData baseData = val6.baseData;
		baseData.damage *= Random.Range(0.5f, 2f);
		ProjectileData baseData2 = val6.baseData;
		baseData2.range *= Random.Range(0.2f, 3.5f);
		ProjectileData baseData3 = val6.baseData;
		baseData3.force *= Random.Range(0.25f, 3.5f);
		ProjectileData baseData4 = val6.baseData;
		baseData4.speed *= Random.Range(0.15f, 2f);
		val6.AdditionalScaleMultiplier *= Random.Range(0.25f, 2f);
		val6.BossDamageMultiplier *= Random.Range(0.25f, 2f);
		val6.BlackPhantomDamageMultiplier *= Random.Range(0.1f, 3.5f);
		float cooldownTime = Random.Range(0.01f, 1.1f);
		int numberOfShotsInClip = Random.Range(1, 30);
		float angleVariance = Random.Range(0, 25);
		base.gun.reloadTime = Random.Range(0.1f, 2f);
		int num2 = Random.Range(50, 350);
		base.gun.SetBaseMaxAmmo(num2);
		base.gun.ammo = num2;
		int num3 = Random.Range(1, 4);
		float burstCooldownTime = Random.Range(0.01f, 0.7f);
		int burstShotCount = Random.Range(1, 11);
		GunTools.RawDefaultModule(base.gun).projectiles[0] = val6;
		GunTools.RawDefaultModule(base.gun).cooldownTime = cooldownTime;
		GunTools.RawDefaultModule(base.gun).numberOfShotsInClip = numberOfShotsInClip;
		GunTools.RawDefaultModule(base.gun).angleVariance = angleVariance;
		switch (num3)
		{
		case 1:
			GunTools.RawDefaultModule(base.gun).shootStyle = (ShootStyle)0;
			break;
		case 2:
			GunTools.RawDefaultModule(base.gun).shootStyle = (ShootStyle)1;
			break;
		case 3:
			GunTools.RawDefaultModule(base.gun).shootStyle = (ShootStyle)4;
			GunTools.RawDefaultModule(base.gun).burstCooldownTime = burstCooldownTime;
			GunTools.RawDefaultModule(base.gun).burstShotCount = burstShotCount;
			break;
		}
		foreach (ProjectileModule projectile in base.gun.RawSourceVolley.projectiles)
		{
			Projectile val7 = Object.Instantiate<Projectile>(val6);
			((Component)val7).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val7).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val7);
			projectile.projectiles[0] = val7;
			projectile.cooldownTime = cooldownTime;
			projectile.numberOfShotsInClip = numberOfShotsInClip;
			projectile.angleVariance = angleVariance;
			if (projectile != base.gun.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			switch (num3)
			{
			case 1:
				projectile.shootStyle = (ShootStyle)0;
				break;
			case 2:
				projectile.shootStyle = (ShootStyle)1;
				break;
			case 3:
				projectile.shootStyle = (ShootStyle)4;
				projectile.burstCooldownTime = burstCooldownTime;
				projectile.burstShotCount = burstShotCount;
				break;
			}
			base.gun.RawSourceVolley.projectiles[0].ammoCost = 1;
		}
		player.stats.RecalculateStats(player, true, false);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			AddEvenMoreGuns();
			ReRandomiseGun(player);
		}
		GameManager.Instance.OnNewLevelFullyLoaded += NewLevelLoaded;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	private void NewLevelLoaded()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			ReRandomiseGun((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= NewLevelLoaded;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= NewLevelLoaded;
		((BraveBehaviour)this).OnDestroy();
	}

	private void AddEvenMoreGuns()
	{
		List<int> collection = new List<int>
		{
			LovePistol.LovePistolID,
			DiscGun.DiscGunID,
			Repeatovolver.RepeatovolverID,
			DiamondGun.DiamondGunID,
			GoldenRevolver.GoldenRevolverID,
			UnusCentum.UnusCentumID,
			StunGun.StunGunID,
			Rekeyter.RekeyterID,
			HotGlueGun.HotGlueGunID,
			CrescendoBlaster.CrescendoBlasterID,
			Glasster.GlassterID,
			HandGun.HandGunID,
			HeadOfTheOrder.HeadOfTheOrderID,
			JusticeGun.JusticeID,
			Orgun.OrgunID,
			Octagun.OctagunID,
			Ranger.RangerID,
			HandCannon.HandCannonID,
			Lantaka.LantakaID,
			GreekFire.GreekFireID,
			EmberCannon.EmberCannonID,
			Purpler.PurplerID,
			HighVelocityRifle.HighVelocityRifleID,
			Demolitionist.DemolitionistID,
			Gravitron.GravitronID,
			FireLance.FireLanceID,
			Blowgun.BlowgunID,
			AntimaterielRifle.AntimaterielRifleID,
			DartRifle.DartRifleID,
			AM0.ID,
			RiotGun.RiotGunID,
			MaidenRifle.MaidenRifleID,
			HeavyAssaultRifle.HeavyAssaultRifleID,
			DynamiteLauncher.DynamiteLauncherID,
			NNBazooka.BazookaID,
			SporeLauncher.SporeLauncherID,
			Corgun.DoggunID,
			FungoCannon.FungoCannonID,
			PhaserSpiderling.PhaserSpiderlingID,
			Guneonate.GuneonateID,
			KillithidTendril.KillithidTendrilID,
			ButchersKnife.ButchersKnifeID,
			MantidAugment.MantidAugmentID,
			Gumgun.GumgunID,
			Spiral.SpiralID,
			Gunshark.GunsharkID,
			GolfRifle.GolfRifleID,
			Icicle.IcicleID,
			GunjurersStaff.GunjurersStaffID,
			SpearOfJustice.SpearOfJusticeID,
			Protean.ProteanID,
			BulletBlade.BulletBladeID,
			Bookllet.BooklletID,
			Lorebook.LorebookID,
			Bullatterer.BullattererID,
			Entropew.EntropewID,
			Creditor.CreditorID
		};
		viableSourceGuns.AddRange(collection);
	}
}
