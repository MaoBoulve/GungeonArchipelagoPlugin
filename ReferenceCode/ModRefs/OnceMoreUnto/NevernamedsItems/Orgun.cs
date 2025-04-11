using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Orgun : GunBehaviour
{
	public static int OrgunID;

	private DamageTypeModifier m_electricityImmunity;

	private bool hasElectricityImmunity;

	private bool hadHeadacheLastTimeWeChecked;

	private int currentItems;

	private int lastItems;

	private int currentActives;

	private int lastActives;

	private int currentGuns;

	private int lastGuns;

	private int currentClip;

	private int lastClip;

	public static List<int> HeartAttackItems = new List<int>
	{
		421,
		422,
		423,
		424,
		425,
		164,
		364,
		815,
		CheeseHeart.CheeseHeartID,
		ForsakenHeart.ForsakenHeartID,
		HeartOfGold.HeartOfGoldID,
		HeartPadlock.HeartPadlockID
	};

	public static void Add()
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Orgun", "orgun");
		Game.Items.Rename("outdated_gun_mods:orgun", "nn:orgun");
		((Component)val).gameObject.AddComponent<Orgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "My Heart Will Go On");
		GunExt.SetLongDescription((PickupObject)(object)val, "Hespera, the Pride of Venus, always wished that her fighting spirit, her courage... her heart, if you will, would go on to inspire and aid others.\n\nShe never realised how literal that would be.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "orgun_idle_001", 8, "orgun_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 8);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 5);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)3, 1f, (ModifyMethod)0);
		for (int i = 0; i < 6; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(56);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)4;
			projectile.burstShotCount = 2;
			projectile.burstCooldownTime = 0.2f;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.5f;
			projectile.angleVariance = 20f;
			projectile.numberOfShotsInClip = 6;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
			PickupObject byId2 = PickupObjectDatabase.GetById(369);
			overrideMidairDeathVFX = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.tileMapVertical.effects[0].effects[0].effect;
			val2.hitEffects.alwaysUseMidair = true;
			ProjectileData baseData = val2.baseData;
			baseData.damage *= 1.4f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.speed *= 1.2f;
			GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
			val3.goopDefinition = EasyGoopDefinitions.BlobulonGoopDef;
			val3.SpawnGoopInFlight = true;
			val3.InFlightSpawnFrequency = 0.05f;
			val3.InFlightSpawnRadius = 1f;
			val3.SpawnGoopOnCollision = true;
			val3.CollisionSpawnRadius = 2f;
			val2.SetProjectileSprite("orgun_projectile", 12, 7, lightened: true, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
			((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		}
		val.reloadTime = 1.3f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.62f, 0.81f, 0f);
		val.SetBaseMaxAmmo(80);
		val.gunClass = (GunClass)5;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Orgun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/orgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/orgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Orgun";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		OrgunID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomMaximum(CustomTrackedMaximums.MAX_HEART_CONTAINERS_EVER, 7f, (PrerequisiteOperation)2);
	}

	public override void Update()
	{
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)base.gun) || !Object.op_Implicit((Object)(object)base.gun.CurrentOwner) || !(base.gun.CurrentOwner is PlayerController))
		{
			return;
		}
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		currentItems = val.passiveItems.Count;
		currentGuns = val.inventory.AllGuns.Count;
		currentClip = base.gun.DefaultModule.numberOfShotsInClip;
		currentActives = val.activeItems.Count;
		if (currentItems != lastItems || currentGuns != lastGuns || currentClip != lastClip || currentActives != lastActives)
		{
			CalculateHeartAttackStats(val);
			lastGuns = currentGuns;
			lastItems = currentItems;
			lastClip = currentClip;
			lastActives = currentActives;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Headache"))
		{
			if (!hasElectricityImmunity)
			{
				m_electricityImmunity = new DamageTypeModifier();
				m_electricityImmunity.damageMultiplier = 0f;
				m_electricityImmunity.damageType = (CoreDamageTypes)64;
				((BraveBehaviour)val).healthHaver.damageTypeModifiers.Add(m_electricityImmunity);
				hasElectricityImmunity = true;
			}
			if (!hadHeadacheLastTimeWeChecked)
			{
				CalculateHeartAttackStats(val);
				hadHeadacheLastTimeWeChecked = true;
			}
		}
		else
		{
			if (hasElectricityImmunity)
			{
				((BraveBehaviour)val).healthHaver.damageTypeModifiers.Remove(m_electricityImmunity);
				hasElectricityImmunity = false;
			}
			if (hadHeadacheLastTimeWeChecked)
			{
				CalculateHeartAttackStats(val);
				hadHeadacheLastTimeWeChecked = false;
			}
		}
	}

	public override void OnInitializedWithOwner(GameActor actor)
	{
		((GunBehaviour)this).OnInitializedWithOwner(actor);
		PlayerController player = (PlayerController)(object)((actor is PlayerController) ? actor : null);
		CalculateHeartAttackStats(player);
	}

	private void CalculateHeartAttackStats(PlayerController player)
	{
		int num = 6;
		int num2 = 80;
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Headache"))
		{
			num2 = 120;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Heart Attack"))
		{
			foreach (PassiveItem passiveItem in player.passiveItems)
			{
				if (HeartAttackItems.Contains(((PickupObject)passiveItem).PickupObjectId))
				{
					num += 2;
					num2 += 50;
				}
			}
			foreach (Gun allGun in player.inventory.AllGuns)
			{
				if (HeartAttackItems.Contains(((PickupObject)allGun).PickupObjectId))
				{
					num += 2;
					num2 += 50;
				}
			}
			foreach (PlayerItem activeItem in player.activeItems)
			{
				if (HeartAttackItems.Contains(((PickupObject)activeItem).PickupObjectId))
				{
					num += 2;
					num2 += 50;
				}
			}
			foreach (ProjectileModule projectile in base.gun.Volley.projectiles)
			{
				projectile.numberOfShotsInClip = num;
			}
			base.gun.SetBaseMaxAmmo(num2);
			return;
		}
		foreach (ProjectileModule projectile2 in base.gun.Volley.projectiles)
		{
			projectile2.numberOfShotsInClip = 6;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Headache"))
		{
			base.gun.SetBaseMaxAmmo(120);
		}
		else
		{
			base.gun.SetBaseMaxAmmo(80);
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		((GunBehaviour)this).PostProcessProjectile(projectile);
		CalculateHeartAttackStats(val);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Headache"))
		{
			projectile.damageTypes = (CoreDamageTypes)(projectile.damageTypes | 0x40);
		}
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Headache"))
		{
			DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.WaterGoop).TimedAddGoopCircle(((BraveBehaviour)player).sprite.WorldCenter, 7f, 1f, false);
		}
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
		CalculateHeartAttackStats(player);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_shotgun_shot_01", ((Component)this).gameObject);
	}
}
