using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Wolfgun : AdvancedGunBehavior
{
	public static int WolfgunID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Wolfgun", "wolfgun");
		Game.Items.Rename("outdated_gun_mods:wolfgun", "nn:doggun+discord_and_rhyme");
		((Component)val).gameObject.AddComponent<Wolfgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bork Bork BORK!");
		GunExt.SetLongDescription((PickupObject)(object)val, "BORKBORKBORKBORKBORKBORKBORK\n\nAlso, if you're reading this, you're a BORKING haxor.");
		val.SetGunSprites("wolfgun", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.75f, 0.56f, 0f);
		val.SetBaseMaxAmmo(400);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		val2.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration = 5;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.numberOfBounces = 5;
		HomingModifier val3 = ((Component)val2).gameObject.AddComponent<HomingModifier>();
		val3.AngularVelocity = 140f;
		val3.HomingRadius = 100f;
		GunTools.SetProjectileSpriteRight(val2, "wolfgun_projectile", 18, 12, false, (Anchor)4, (int?)17, (int?)11, true, false, (int?)null, (int?)null, (Projectile)null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.PreventNormalFireAudio = true;
		val.OverrideNormalFireAudioEvent = "Play_PET_dog_bark_02";
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Wolfgun synergy";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Doggun");
		WolfgunID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnReload(PlayerController player, Gun gun)
	{
		((AdvancedGunBehavior)this).OnReload(player, gun);
		AkSoundEngine.PostEvent("Stop_WPN_All", ((Component)this).gameObject);
		AkSoundEngine.PostEvent("Play_PET_dog_bark_02", ((Component)this).gameObject);
	}
}
