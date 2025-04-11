using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MiniMonger : AdvancedGunBehavior
{
	public static int MiniMongerID;

	private DamageTypeModifier m_fireImmunity;

	public static void Add()
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Mini Monger", "minimonger");
		Game.Items.Rename("outdated_gun_mods:mini_monger", "nn:mini_monger");
		MiniMonger miniMonger = ((Component)val).gameObject.AddComponent<MiniMonger>();
		((AdvancedGunBehavior)miniMonger).preventNormalFireAudio = true;
		((AdvancedGunBehavior)miniMonger).overrideNormalFireAudio = "Play_ENM_demonwall_barf_01";
		((AdvancedGunBehavior)miniMonger).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)miniMonger).overrideNormalReloadAudio = "Play_ENM_demonwall_intro_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Great Wall");
		GunExt.SetLongDescription((PickupObject)(object)val, "A scale model of the fearsome Wallmonger, used as a mock-up during it's original construction.\n\nWhile the Wallmonger contains hundreds of tortured souls, this only contains two or three.");
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.SetGunSprites("minimonger");
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_ENM_demonwall_barf_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 5);
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)3;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 2f;
			projectile.angleVariance = 15f;
			projectile.numberOfShotsInClip = 4;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.speed *= 0.5f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.damage *= 1.6f;
			AutoDoShadowChainOnSpawn orAddComponent = GameObjectExtensions.GetOrAddComponent<AutoDoShadowChainOnSpawn>(((Component)val2).gameObject);
			orAddComponent.NumberInChain = 5;
			orAddComponent.pauseLength = 0.1f;
			val2.SetProjectileSprite("pillarocket_subprojectile", 5, 5, lightened: true, (Anchor)4, 3, 3, anchorChangesCollider: true, fixesScale: false, null, null);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			ChargeProjectile item = new ChargeProjectile
			{
				Projectile = val2,
				ChargeTime = 1f
			};
			projectile.chargeProjectiles = new List<ChargeProjectile> { item };
		}
		val.reloadTime = 2f;
		val.SetBaseMaxAmmo(50);
		val.gunClass = (GunClass)5;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 3;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Punishment Ray Lasers";
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		MiniMongerID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		if (gun.ClipShotsRemaining < gun.ClipCapacity)
		{
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.FireDef);
			Vector2 worldCenter = ((BraveBehaviour)gun).sprite.WorldCenter;
			Vector2 val = Vector3Extensions.XY(player.unadjustedAimPoint) - worldCenter;
			Vector2 normalized = ((Vector2)(ref val)).normalized;
			goopManagerForGoopType.TimedAddGoopLine(((BraveBehaviour)gun).sprite.WorldCenter, ((BraveBehaviour)gun).sprite.WorldCenter + normalized * 10f, 1.5f, 0.5f);
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, manualReload);
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			RemoveFireImmunity((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	public override void OnSwitchedToThisGun()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			GiveFireImmunity((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		GiveFireImmunity(player);
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		RemoveFireImmunity(player);
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			RemoveFireImmunity((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	private void GiveFireImmunity(PlayerController playerController)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (m_fireImmunity == null)
		{
			m_fireImmunity = new DamageTypeModifier();
			m_fireImmunity.damageMultiplier = 0f;
			m_fireImmunity.damageType = (CoreDamageTypes)4;
		}
		((BraveBehaviour)playerController).healthHaver.damageTypeModifiers.Add(m_fireImmunity);
	}

	private void RemoveFireImmunity(PlayerController playerController)
	{
		((BraveBehaviour)playerController).healthHaver.damageTypeModifiers.Remove(m_fireImmunity);
	}
}
