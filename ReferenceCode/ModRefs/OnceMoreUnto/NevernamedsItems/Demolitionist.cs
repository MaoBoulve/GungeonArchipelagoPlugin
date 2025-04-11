using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Demolitionist : GunBehaviour
{
	public static int DemolitionistID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Demolitionist", "demolitionist");
		Game.Items.Rename("outdated_gun_mods:demolitionist", "nn:demolitionist");
		((Component)val).gameObject.AddComponent<Demolitionist>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Up in Smoke!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Reloading on a full clip consumes some ammo and places a proximity mine.\n\nAn old Hegemony of Man weapon, repurposed by Minelets for blasting open ore deposits in the mines.");
		val.SetGunSprites("demolitionist");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.81f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.8f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		val2.SetProjectileSprite("demolitionist_projectile", 16, 7, lightened: false, (Anchor)4, 15, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Demolitionist Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/demolitionist_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/thinline_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Demolitionist";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		DemolitionistID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_DEMOLITIONIST, requiredFlagValue: true);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
		if (gun.ClipCapacity == gun.ClipShotsRemaining || gun.CurrentAmmo == gun.ClipShotsRemaining)
		{
			if (gun.CurrentAmmo >= 5)
			{
				gun.CurrentAmmo -= 5;
				SpawnObjectPlayerItem component = ((Component)PickupObjectDatabase.GetById(66)).GetComponent<SpawnObjectPlayerItem>();
				GameObject gameObject = component.objectToSpawn.gameObject;
				GameObject val = Object.Instantiate<GameObject>(gameObject, Vector2.op_Implicit(((BraveBehaviour)player).sprite.WorldBottomCenter), Quaternion.identity);
				tk2dBaseSprite component2 = val.GetComponent<tk2dBaseSprite>();
				if (Object.op_Implicit((Object)(object)component2))
				{
					component2.PlaceAtPositionByAnchor(Vector2.op_Implicit(((BraveBehaviour)player).sprite.WorldBottomCenter), (Anchor)4);
				}
			}
		}
		else if (gun.ClipShotsRemaining == 0 && gun.CurrentAmmo != 0 && CustomSynergies.PlayerHasActiveSynergy(player, "Demolition Man"))
		{
			SpawnObjectPlayerItem component3 = ((Component)PickupObjectDatabase.GetById(66)).GetComponent<SpawnObjectPlayerItem>();
			GameObject gameObject2 = component3.objectToSpawn.gameObject;
			GameObject val2 = Object.Instantiate<GameObject>(gameObject2, Vector2.op_Implicit(((BraveBehaviour)player).sprite.WorldBottomCenter), Quaternion.identity);
			tk2dBaseSprite component4 = val2.GetComponent<tk2dBaseSprite>();
			if (Object.op_Implicit((Object)(object)component4))
			{
				component4.PlaceAtPositionByAnchor(Vector2.op_Implicit(((BraveBehaviour)player).sprite.WorldBottomCenter), (Anchor)4);
			}
		}
	}
}
