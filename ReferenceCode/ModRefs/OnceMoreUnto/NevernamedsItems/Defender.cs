using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Defender : GunBehaviour
{
	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Defender", "defender");
		Game.Items.Rename("outdated_gun_mods:defender", "nn:defender");
		((Component)val).gameObject.AddComponent<Defender>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Starcadia");
		GunExt.SetLongDescription((PickupObject)(object)val, "An old ground-to-air defence system from the 80s, to be used in the event of an extraterrestial incursion.");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "defender_idle_001", 8);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(124);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.6f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)0;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 3f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.5f;
		val2.pierceMinorBreakables = true;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Defender";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
