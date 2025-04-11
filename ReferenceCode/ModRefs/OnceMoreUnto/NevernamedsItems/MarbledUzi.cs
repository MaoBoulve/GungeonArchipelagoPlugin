using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using GungeonAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MarbledUzi : AdvancedGunBehavior
{
	public static List<GameObject> stoneBulletKin = new List<GameObject>();

	public static List<GameObject> stoneShotgunKin = new List<GameObject>();

	private Vector2 lastCenter = Vector2.zero;

	private bool hasScreamed = false;

	private float m_timer;

	private float m_prevWaveDist;

	public static int MarbledUziID;

	public static List<string> ValidBulletKin = new List<string>
	{
		EnemyGuidDatabase.Entries["bullet_kin"],
		EnemyGuidDatabase.Entries["ak47_bullet_kin"],
		EnemyGuidDatabase.Entries["bandana_bullet_kin"],
		EnemyGuidDatabase.Entries["veteran_bullet_kin"],
		EnemyGuidDatabase.Entries["treadnaughts_bullet_kin"],
		EnemyGuidDatabase.Entries["minelet"],
		EnemyGuidDatabase.Entries["cardinal"],
		EnemyGuidDatabase.Entries["ashen_bullet_kin"],
		EnemyGuidDatabase.Entries["mutant_bullet_kin"],
		EnemyGuidDatabase.Entries["fallen_bullet_kin"],
		EnemyGuidDatabase.Entries["office_bullet_kin"],
		EnemyGuidDatabase.Entries["office_bullette_kin"],
		EnemyGuidDatabase.Entries["brollet"],
		EnemyGuidDatabase.Entries["western_bullet_kin"],
		EnemyGuidDatabase.Entries["pirate_bullet_kin"],
		EnemyGuidDatabase.Entries["summoned_treadnaughts_bullet_kin"],
		EnemyGuidDatabase.Entries["gummy"]
	};

	public static void Add()
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Marbled Uzi", "marbleduzi");
		Game.Items.Rename("outdated_gun_mods:marbled_uzi", "nn:marbled_uzi");
		MarbledUzi marbledUzi = ((Component)val).gameObject.AddComponent<MarbledUzi>();
		((AdvancedGunBehavior)marbledUzi).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)marbledUzi).overrideNormalReloadAudio = "Play_ENM_gorgun_gaze_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "At First I Was Afraid");
		GunExt.SetLongDescription((PickupObject)(object)val, "Favoured sidearm of Meduzi, the fearsome Gorgun. Legends say she emerged from her egg already clutching it's cold steel.\n\nReleases a stunning wave upon reloading, and deals more damage to stunned enemies.");
		val.SetGunSprites("marbleduzi");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(673);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 2;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.05f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(97);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 80;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.56f, 1f, 0f);
		val.SetBaseMaxAmmo(2000);
		val.ammo = 2000;
		val.gunClass = (GunClass)10;
		ref VFXPool muzzleFlashEffects2 = ref val.muzzleFlashEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(23);
		muzzleFlashEffects2 = ((Gun)((byId4 is Gun) ? byId4 : null)).muzzleFlashEffects;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 3f;
		SelectiveDamageMult orAddComponent = GameObjectExtensions.GetOrAddComponent<SelectiveDamageMult>(((Component)val2).gameObject);
		orAddComponent.multiplier = 2f;
		orAddComponent.multOnStunnedEnemies = true;
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		MarbledUziID = ((PickupObject)val).PickupObjectId;
		foreach (WeightedRoom element in StaticReferences.RoomTables["gorgun"].includedRooms.elements)
		{
			if (!((Object)(object)element.room != (Object)null) || element.room.placedObjects == null)
			{
				continue;
			}
			foreach (PrototypePlacedObjectData placedObject in element.room.placedObjects)
			{
				if ((Object)(object)placedObject.nonenemyBehaviour != (Object)null && (Object)(object)((Component)placedObject.nonenemyBehaviour).gameObject != (Object)null && !string.IsNullOrEmpty(((Object)((Component)placedObject.nonenemyBehaviour).gameObject).name))
				{
					if (((Object)((Component)placedObject.nonenemyBehaviour).gameObject).name.Contains("Bullet"))
					{
						stoneBulletKin.Add(((Component)placedObject.nonenemyBehaviour).gameObject);
					}
					if (((Object)((Component)placedObject.nonenemyBehaviour).gameObject).name.Contains("Shotgun"))
					{
						stoneShotgunKin.Add(((Component)placedObject.nonenemyBehaviour).gameObject);
					}
				}
			}
		}
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		if (gun.ClipShotsRemaining != gun.ClipCapacity && !hasScreamed)
		{
			m_timer = 1.5f - BraveTime.DeltaTime;
			m_prevWaveDist = 0f;
			hasScreamed = true;
			Vector2 worldCenter = ((BraveBehaviour)gun).sprite.WorldCenter;
			Exploder.DoDistortionWave(worldCenter, 0.5f, 0.04f, 20f, 1.5f);
			lastCenter = worldCenter;
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, manualReload);
	}

	protected override void Update()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && m_timer > 0f)
		{
			m_timer -= BraveTime.DeltaTime;
			float num = BraveMathCollege.LinearToSmoothStepInterpolate(0f, 20f, 1f - m_timer / 1.5f);
			List<AIActor> activeEnemies = GunTools.GunPlayerOwner(base.gun).CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies != null)
			{
				for (int i = 0; i < activeEnemies.Count; i++)
				{
					AIActor val = activeEnemies[i];
					Vector2 unitCenter = ((BraveBehaviour)val).specRigidbody.GetUnitCenter((ColliderType)2);
					float num2 = Vector2.Distance(unitCenter, lastCenter);
					if (!(num2 >= m_prevWaveDist - 0.25f) || !(num2 <= num + 0.25f))
					{
						continue;
					}
					((BraveBehaviour)val).behaviorSpeculator.Stun(2f, true);
					if ((Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver) && ((BraveBehaviour)val).healthHaver.GetCurrentHealthPercentage() < 0.5f) || CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Gorgun's Gaze"))
					{
						if (AlexandriaTags.HasTag(val, "shotgun_kin"))
						{
							PickupObject byId = PickupObjectDatabase.GetById(37);
							Object.Instantiate<GameObject>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX, Vector2.op_Implicit(((BraveBehaviour)val).specRigidbody.UnitCenter), Quaternion.identity);
							val.EraseFromExistenceWithRewards(false);
							Object.Instantiate<GameObject>(BraveUtility.RandomElement<GameObject>(stoneShotgunKin), Vector2.op_Implicit(((BraveBehaviour)val).specRigidbody.UnitBottomLeft), Quaternion.identity);
						}
						else if (ValidBulletKin.Contains(val.EnemyGuid))
						{
							PickupObject byId2 = PickupObjectDatabase.GetById(37);
							Object.Instantiate<GameObject>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX, Vector2.op_Implicit(((BraveBehaviour)val).specRigidbody.UnitCenter), Quaternion.identity);
							val.EraseFromExistenceWithRewards(false);
							Object.Instantiate<GameObject>(BraveUtility.RandomElement<GameObject>(stoneBulletKin), Vector2.op_Implicit(((BraveBehaviour)val).specRigidbody.UnitBottomLeft), Quaternion.identity);
						}
					}
				}
			}
			m_prevWaveDist = num;
		}
		((AdvancedGunBehavior)this).Update();
		if (!base.gun.IsReloading && hasScreamed)
		{
			hasScreamed = false;
		}
	}
}
