using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class DisplacerCannon : AdvancedGunBehavior
{
	public static List<int> lootIDlist = new List<int> { 565, 73, 85, 120, 224, 67 };

	private PlayerController storedPlayer;

	public static void Add()
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Displacer Cannon", "displacercannon");
		Game.Items.Rename("outdated_gun_mods:displacer_cannon", "nn:displacer_cannon");
		DisplacerCannon displacerCannon = ((Component)val).gameObject.AddComponent<DisplacerCannon>();
		((AdvancedGunBehavior)displacerCannon).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)displacerCannon).overrideNormalReloadAudio = "Play_OBJ_teleport_arrive_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Goodbye");
		GunExt.SetLongDescription((PickupObject)(object)val, "Displaces enemies through time and space to somewhere... else. \nThose too weak to withstand the vortex will be lost among the border worlds of reality.\n\n\"We're gonna take our problems and DISPLACE them somewhere else!\"");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "displacercannon_idle_001", 8, "displacercannon_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 11);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].eventAudio = "Play_WPN_warp_impact_01";
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).frames[0].triggerEvent = true;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(228);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.4f;
		val.DefaultModule.cooldownTime = 0.2f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.06f, 0.56f, 0f);
		val.SetBaseMaxAmmo(40);
		val.gunClass = (GunClass)60;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 9;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.5f;
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.SmoothLightBlueLaserCircleVFX;
		DisplaceEnemies displaceEnemies = ((Component)val2).gameObject.AddComponent<DisplaceEnemies>();
		val2.SetProjectileSprite("displacercannon_projectile", 17, 17, lightened: true, (Anchor)4, 15, 15, anchorChangesCollider: true, fixesScale: false, null, null);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 1f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("DisplacerCannon Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/displacercannon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/displacercannon_clipempty");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			listOfDisplacedEnemies.DisplacedEnemies.Clear();
			GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
			PlayerResponsibleForDisplacement orAddComponent = GameObjectExtensions.GetOrAddComponent<PlayerResponsibleForDisplacement>(((Component)player).gameObject);
		}
		storedPlayer = player;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, bSOMETHING);
		if ((gun.ClipCapacity == gun.ClipShotsRemaining || gun.CurrentAmmo == gun.ClipShotsRemaining) && CustomSynergies.PlayerHasActiveSynergy(player, "Loot Vortex") && gun.CurrentAmmo >= 10)
		{
			gun.CurrentAmmo -= 10;
			IntVector2 bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
			Vector3 val = ((IntVector2)(ref bestRewardLocation)).ToVector3();
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(lootIDlist))).gameObject, val, Vector2.zero, 1f, false, true, false);
			AkSoundEngine.PostEvent("Play_OBJ_chestwarp_use_01", ((Component)this).gameObject);
			PickupObject byId = PickupObjectDatabase.GetById(573);
			GameObject teleportVFX = ((ChestTeleporterItem)((byId is ChestTeleporterItem) ? byId : null)).TeleportVFX;
			SpawnManager.SpawnVFX(teleportVFX, val, Quaternion.identity, true);
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if ((Object)(object)val != (Object)null && CustomSynergies.PlayerHasActiveSynergy(val, "Misfire Cannon"))
		{
			InstantTeleportToPlayerCursorBehav orAddComponent = GameObjectExtensions.GetOrAddComponent<InstantTeleportToPlayerCursorBehav>(((Component)projectile).gameObject);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		if (!Object.op_Implicit((Object)(object)((Component)player).gameObject.GetComponent<PlayerResponsibleForDisplacement>()))
		{
			((Component)((GameActor)player).CurrentGun).gameObject.AddComponent<PlayerResponsibleForDisplacement>();
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	private void OnNewFloor()
	{
		if (Object.op_Implicit((Object)(object)storedPlayer))
		{
			PlayerResponsibleForDisplacement orAddComponent = GameObjectExtensions.GetOrAddComponent<PlayerResponsibleForDisplacement>(((Component)storedPlayer).gameObject);
		}
	}
}
