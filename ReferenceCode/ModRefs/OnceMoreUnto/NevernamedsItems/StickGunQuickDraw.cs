using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class StickGunQuickDraw : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Full Auto Stick Gun", "stickgunquickdraw");
		Game.Items.Rename("outdated_gun_mods:full_auto_stick_gun", "nn:stick_gun+quick_draw");
		StickGunQuickDraw stickGunQuickDraw = ((Component)val).gameObject.AddComponent<StickGunQuickDraw>();
		((AdvancedGunBehavior)stickGunQuickDraw).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)stickGunQuickDraw).preventNormalFireAudio = true;
		((AdvancedGunBehavior)stickGunQuickDraw).overrideNormalFireAudio = "Play_PencilScratch";
		GunExt.SetShortDescription((PickupObject)(object)val, "Scribble");
		GunExt.SetLongDescription((PickupObject)(object)val, "Carried by a brave stickman as he ventured through the pages of a bored child's homework.\n\nHe may be long erased, but his legacy lives on.");
		val.SetGunSprites("fullautostickgun", 8, noAmmonomicon: true);
		PickupObject byId = PickupObjectDatabase.GetById(StickGun.ID);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.gunHandedness = (GunHandedness)1;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 33;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.5f, 0f);
		val.SetBaseMaxAmmo(333);
		val.ammo = 333;
		val.gunClass = (GunClass)55;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(StickGun.ID);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		GunExt.SetName((PickupObject)(object)val, "Stick Gun");
	}
}
