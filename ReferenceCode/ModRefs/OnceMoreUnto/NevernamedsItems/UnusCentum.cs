using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class UnusCentum : GunBehaviour
{
	public static int UnusCentumID;

	public static void Add()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Unus Centum", "unuscentum");
		Game.Items.Rename("outdated_gun_mods:unus_centum", "nn:unus_centum");
		((Component)val).gameObject.AddComponent<UnusCentum>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Forget Me Not");
		GunExt.SetLongDescription((PickupObject)(object)val, "Has 100 shots. Cannot gain ammo.\n\nThe sidearm of a glistening sentinel, who came to the Gungeon not to flee his inevitable death, but to embrace it.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "unuscentum_idle_001", 8, "unuscentum_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.CanGainAmmo = false;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.68f, 0f);
		val.SetBaseMaxAmmo(100);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 8f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		GunTools.SetProjectileSpriteRight(val2, "demolitionist_projectile", 16, 7, false, (Anchor)4, (int?)15, (int?)6, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Unus Centum";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		UnusCentumID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		((GunBehaviour)this).OnPostFired(player, gun);
		if (gun.ammo == 0)
		{
			player.inventory.DestroyCurrentGun();
		}
		gun.PreventNormalFireAudio = true;
		AkSoundEngine.PostEvent("Play_WPN_deck4rd_shot_01", ((Component)this).gameObject);
	}
}
