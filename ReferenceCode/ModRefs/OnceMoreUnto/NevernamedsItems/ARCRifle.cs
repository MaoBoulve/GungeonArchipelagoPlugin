using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ARCRifle : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("ARC Rifle", "arcrifle");
		Game.Items.Rename("outdated_gun_mods:arc_rifle", "nn:arc_rifle");
		((Component)val).gameObject.AddComponent<ARCRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Electrotech Assassin");
		GunExt.SetLongDescription((PickupObject)(object)val, "This slow firing yet powerful electric rifle was patented by the ARC Private Security Company for effective 'ranged situation management'.\n\nColloquial nicknames such as 'Thunderstick' are not uncommon among ARC personnel.");
		val.SetGunSprites("arcrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(ARCPistol.ID);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(153);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(41);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.numberOfShotsInClip = 8;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.9375f, 0.5f, 0f);
		val.SetBaseMaxAmmo(180);
		val.gunClass = (GunClass)15;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "ARC Bullets";
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		component.baseData.damage = 26f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)component).gameObject);
		orAddComponent.penetration++;
		val.DefaultModule.projectiles[0] = component;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
