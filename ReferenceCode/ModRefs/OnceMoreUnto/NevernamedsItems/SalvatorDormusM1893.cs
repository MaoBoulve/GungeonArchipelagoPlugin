using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SalvatorDormusM1893 : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Salvator Dormus M1893", "salvatordormusm1893");
		Game.Items.Rename("outdated_gun_mods:salvator_dormus_m1893", "nn:salvator_dormus+m1893");
		((Component)val).gameObject.AddComponent<SalvatorDormusM1893>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Type Match");
		GunExt.SetLongDescription((PickupObject)(object)val, "Increases it's own stats based on what other types of gun are in it's owner's possession\n\nOne of the earliest models of semiautomatic pistol ever invented, it's ancestral promenance grants it more power the more of it's descendants are held.");
		val.SetGunSprites("salvatordormusm1893", 8, noAmmonomicon: true);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 30;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3.0625f, 0.75f, 0f);
		val.SetBaseMaxAmmo(550);
		val.gunClass = (GunClass)1;
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		val.DefaultModule.projectiles[0] = component;
		ref GameObject overrideMidairDeathVFX = ref component.hitEffects.overrideMidairDeathVFX;
		PickupObject byId2 = PickupObjectDatabase.GetById(178);
		overrideMidairDeathVFX = ((Component)((byId2 is Gun) ? byId2 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		component.hitEffects.alwaysUseMidair = true;
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		GunExt.SetName((PickupObject)(object)val, "Salvator Dormus");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
