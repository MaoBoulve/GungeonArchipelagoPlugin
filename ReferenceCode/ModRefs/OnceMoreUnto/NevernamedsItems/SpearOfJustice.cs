using System;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SpearOfJustice : AdvancedGunBehavior
{
	public static int SpearOfJusticeID;

	public AIActorDebuffEffect NoMoveDebuff = new AIActorDebuffEffect
	{
		SpeedMultiplier = 0f,
		OverheadVFX = null,
		duration = 1000000f
	};

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Spear of Justice", "spearofjustice");
		Game.Items.Rename("outdated_gun_mods:spear_of_justice", "nn:spear_of_justice");
		((Component)val).gameObject.AddComponent<SpearOfJustice>();
		GunExt.SetShortDescription((PickupObject)(object)val, "NGAH!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Weapon of an ancient gundead warrior, who believed she could escape the Gungeon by harnessing the power of Gungeoneer souls.\n\nShe never achieved her goal.");
		val.SetGunSprites("spearofjustice");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 30);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(417);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 100;
		val.DefaultModule.angleVariance = 0f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.25f, 1.68f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 4f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration += 10;
		val2.SetProjectileSprite("spearofjustice_projectile", 52, 14, lightened: false, (Anchor)4, 39, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)4;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Spear of Justice";
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		SpearOfJusticeID = ((PickupObject)val).PickupObjectId;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(Greenify));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Undying") && Random.value <= 0.1f)
		{
			projectile.AdjustPlayerProjectileTint(Color.yellow, 1, 0f);
			HomingModifier val2 = ((Component)projectile).gameObject.AddComponent<HomingModifier>();
			val2.AngularVelocity = 250f;
			val2.HomingRadius = 250f;
		}
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(Greenify));
	}

	public void Greenify(AIActor target)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "No Running Away!") && Random.value <= 0.25f)
		{
			((GameActor)target).ApplyEffect((GameActorEffect)(object)NoMoveDebuff, 1f, (Projectile)null);
			GameActorHealthEffect val2 = new GameActorHealthEffect
			{
				TintColor = Color.green,
				DeathTintColor = Color.green,
				AppliesTint = true,
				AppliesDeathTint = true,
				AffectsEnemies = true,
				DamagePerSecondToEnemies = 0f,
				duration = 10000000f,
				effectIdentifier = "SpearOfJusticeGreening"
			};
			((GameActor)target).ApplyEffect((GameActorEffect)(object)val2, 1f, (Projectile)null);
		}
	}

	public override void OnDropped()
	{
		((AdvancedGunBehavior)this).OnDropped();
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(Greenify));
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
		if (!Object.op_Implicit((Object)(object)base.gun) || !Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			return;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Undying"))
		{
			if (base.gun.DefaultModule.cooldownTime == 0.5f)
			{
				base.gun.DefaultModule.cooldownTime = 0.25f;
				base.gun.SetBaseMaxAmmo(400);
			}
		}
		else if (base.gun.DefaultModule.cooldownTime == 0.25f)
		{
			base.gun.DefaultModule.cooldownTime = 0.5f;
			base.gun.SetBaseMaxAmmo(200);
		}
	}
}
