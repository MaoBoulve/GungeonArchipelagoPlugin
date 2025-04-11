using System;
using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DiamondGun : AdvancedGunBehavior
{
	public static int DiamondGunID;

	private float sparkleAccum;

	private GameActorFireEffect fireEffect = ((Component)Game.Items["hot_lead"]).GetComponent<BulletStatusEffectItem>().FireModifierEffect;

	public static List<string> undead = new List<string>
	{
		EnemyGuidDatabase.Entries["spent"],
		EnemyGuidDatabase.Entries["gummy"],
		EnemyGuidDatabase.Entries["skullet"],
		EnemyGuidDatabase.Entries["skullmet"],
		EnemyGuidDatabase.Entries["shelleton"],
		EnemyGuidDatabase.Entries["gummy_spent"],
		EnemyGuidDatabase.Entries["skusket"],
		EnemyGuidDatabase.Entries["revolvenant"]
	};

	public static List<string> arthropods = new List<string>
	{
		EnemyGuidDatabase.Entries["phaser_spider"],
		EnemyGuidDatabase.Entries["shotgrub"],
		EnemyGuidDatabase.Entries["creech"]
	};

	public static void Add()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Diamond Gun", "diamondgun2");
		Game.Items.Rename("outdated_gun_mods:diamond_gun", "nn:diamond_gun");
		((Component)val).gameObject.AddComponent<DiamondGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Diamonds Toniiiight");
		GunExt.SetLongDescription((PickupObject)(object)val, "Made out of shimmering crystal, this sidearm was mined in one piece from the rock of the Black Powder Mines.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "diamondgun2_idle_001", 8, "diamondgun2_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(53);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(53);
		gunSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.SetBarrel(27, 17);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 3f;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(506);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX;
		val2.hitEffects.alwaysUseMidair = true;
		SpriteSparkler orAddComponent = GameObjectExtensions.GetOrAddComponent<SpriteSparkler>(((Component)val2).gameObject);
		orAddComponent.doVFX = true;
		orAddComponent.VFX = SharedVFX.BlueSparkle;
		orAddComponent.particlesPerSecond = 20f;
		val2.SetProjectileSprite("diamond_projectile", 11, 11, lightened: false, (Anchor)4, 10, 10, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Diamond Gun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/diamondgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/diamondgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		val.AddShellCasing(0, 0, 6, 0, "shell_diamond");
		DiamondGunID = ((PickupObject)val).PickupObjectId;
		SpriteSparkler spriteSparkler = val.shellCasing.AddComponent<SpriteSparkler>();
		spriteSparkler.doVFX = true;
		spriteSparkler.VFX = SharedVFX.BlueSparkle;
		spriteSparkler.particlesPerSecond = 0.5f;
		spriteSparkler.randomise = true;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		try
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Bane of Arthropods"))
			{
				projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(killArthropods));
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Smite"))
			{
				projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(killUndead));
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Fire Aspect"))
			{
				projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(applyFire));
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Sharpness"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 1.5f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Knockback"))
			{
				ProjectileData baseData2 = projectile.baseData;
				baseData2.force *= 2f;
			}
			((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.GunChanged += OnChangedGun;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	private void OnChangedGun(Gun oldGun, Gun newGun, bool huh)
	{
		if ((Object)(object)newGun == (Object)(object)base.gun && !CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Looting"))
		{
		}
	}

	public override void OnDropped()
	{
		((AdvancedGunBehavior)this).OnDropped();
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		val.GunChanged -= OnChangedGun;
	}

	protected override void Update()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)((BraveBehaviour)base.gun).sprite))
		{
			sparkleAccum += BraveTime.DeltaTime * 3f;
			if (sparkleAccum > 1f)
			{
				int num = Mathf.FloorToInt(sparkleAccum);
				sparkleAccum %= 1f;
				Vector2 worldBottomLeft = ((BraveBehaviour)((BraveBehaviour)base.gun).sprite).sprite.WorldBottomLeft;
				Vector2 worldTopRight = ((BraveBehaviour)((BraveBehaviour)base.gun).sprite).sprite.WorldTopRight;
				for (int i = 0; i < num; i++)
				{
					GameObject val = Object.Instantiate<GameObject>(SharedVFX.BlueSparkle, Vector2.op_Implicit(new Vector2(Random.Range(worldBottomLeft.x, worldTopRight.x), Random.Range(worldBottomLeft.y, worldTopRight.y))), Quaternion.identity);
					val.GetComponent<tk2dBaseSprite>().HeightOffGround = 0.2f;
				}
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void applyFire(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).gameActor))
		{
			((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)fireEffect, 1f, (Projectile)null);
		}
	}

	private void killArthropods(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && !string.IsNullOrEmpty(((BraveBehaviour)enemy).aiActor.EnemyGuid) && arthropods.Contains(((BraveBehaviour)enemy).aiActor.EnemyGuid))
		{
			((BraveBehaviour)((BraveBehaviour)enemy).aiActor).healthHaver.ApplyDamage(10000000f, Vector2.zero, "BaneOfArthropods", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
	}

	private void killUndead(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && !string.IsNullOrEmpty(((BraveBehaviour)enemy).aiActor.EnemyGuid) && undead.Contains(((BraveBehaviour)enemy).aiActor.EnemyGuid))
		{
			((BraveBehaviour)((BraveBehaviour)enemy).aiActor).healthHaver.ApplyDamage(10000000f, Vector2.zero, "Smite", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
	}
}
