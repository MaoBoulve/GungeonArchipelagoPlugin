using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Borz : AdvancedGunBehavior
{
	public static int ID;

	public float timeRemaining = 0f;

	public static void Add()
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Borz", "borz");
		Game.Items.Rename("outdated_gun_mods:borz", "nn:borz");
		Borz borz = ((Component)val).gameObject.AddComponent<Borz>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Krasniy Wolf");
		GunExt.SetLongDescription((PickupObject)(object)val, "A homemade insurgency weapon- slapped together and barely able to function. Flipping the gun upside down with a dodge roll seems to boost it's effectiveness.\n\nUsed for a short time by a brief splinter-state of the Hegemony of Man.");
		val.SetGunSprites("borz");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(2);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(2);
		gunSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.angleVariance = 8f;
		val.DefaultModule.numberOfShotsInClip = 60;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.125f, 0.75f, 0f);
		val.SetBaseMaxAmmo(600);
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		val2.SetProjectileSprite("spacersfancy_proj", 9, 4, lightened: true, (Anchor)4, 9, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(15);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_BORZ, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(20, null);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.OnRollStarted += OnRolled;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnRollStarted -= OnRolled;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			GunTools.GunPlayerOwner(base.gun).OnRollStarted -= OnRolled;
		}
		((BraveBehaviour)this).OnDestroy();
	}

	private void OnRolled(PlayerController player, Vector2 vec)
	{
		timeRemaining += 3.5f;
		timeRemaining = Mathf.Min(timeRemaining, 3.5f);
	}

	protected override void Update()
	{
		if (timeRemaining > 0f && Object.op_Implicit((Object)(object)((AdvancedGunBehavior)this).Owner) && ((AdvancedGunBehavior)this).Owner is PlayerController && GunTools.IsCurrentGun(base.gun))
		{
			timeRemaining -= BraveTime.DeltaTime;
			ItemBuilder.RemoveCurrentGunStatModifier(base.gun, (StatType)1);
			float num = Mathf.Lerp(1f, CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Back in Grozny") ? 4f : 3f, timeRemaining / 3.5f);
			ItemBuilder.AddCurrentGunStatModifier(base.gun, (StatType)1, num, (ModifyMethod)1);
			GameActor owner = ((AdvancedGunBehavior)this).Owner;
			PlayerStats stats = ((PlayerController)((owner is PlayerController) ? owner : null)).stats;
			GameActor owner2 = ((AdvancedGunBehavior)this).Owner;
			VolleyRebuildHelpers.RecalculateStatsWithoutRebuildingGunVolleys(stats, (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null));
		}
		((AdvancedGunBehavior)this).Update();
	}
}
