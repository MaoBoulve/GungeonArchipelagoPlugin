using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Gunycomb : GunBehaviour
{
	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gunycomb", "gunycomb");
		Game.Items.Rename("outdated_gun_mods:gunycomb", "nn:gunycomb");
		((Component)val).gameObject.AddComponent<Gunycomb>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Shreddin' Vapours");
		GunExt.SetLongDescription((PickupObject)(object)val, "Used in rebel attacks on remote Hegemony of Man outposts, this high-tech tool of destruction is geared to take out heavy targets.\n\nIgnores boss DPS cap.");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "antimaterielrifle_idle_001", 8);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(10);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.0001f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 900;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.75f, 0.56f, 0f);
		val.SetBaseMaxAmmo(900);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		val2.DefaultTintColor = ExtendedColours.honeyYellow;
		GoopModifier component = ((Component)val2).GetComponent<GoopModifier>();
		component.goopDefinition = EasyGoopDefinitions.HoneyGoop;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Antimateriel Rifle";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}
}
