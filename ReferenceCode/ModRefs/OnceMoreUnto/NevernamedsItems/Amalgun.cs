using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Amalgun : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Invalid comparison between Unknown and I4
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Amalgun", "amalgun");
		Game.Items.Rename("outdated_gun_mods:amalgun", "nn:amalgun");
		((Component)val).gameObject.AddComponent<Amalgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "The Ultimate Gun");
		GunExt.SetLongDescription((PickupObject)(object)val, "A collection of seemingly random guns duct taped together.\n\nHas a penchant for jamming in firing mode, reload to clear the jam.");
		val.SetGunSprites("amalgun");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(124);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		for (int i = 0; i < 10; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(122);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		PickupObject byId3 = PickupObjectDatabase.GetById(87);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		PickupObject byId4 = PickupObjectDatabase.GetById(30);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId4 is Gun) ? byId4 : null), true, false);
		PickupObject byId5 = PickupObjectDatabase.GetById(94);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId5 is Gun) ? byId5 : null), true, false);
		PickupObject byId6 = PickupObjectDatabase.GetById(15);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId6 is Gun) ? byId6 : null), true, false);
		bool flag = false;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			if ((int)projectile.shootStyle == 3)
			{
				if (!flag)
				{
					flag = true;
				}
				else
				{
					projectile.ammoCost = 0;
				}
			}
		}
		AdvancedHoveringGunSynergyProcessor advancedHoveringGunSynergyProcessor = ((Component)val).gameObject.AddComponent<AdvancedHoveringGunSynergyProcessor>();
		advancedHoveringGunSynergyProcessor.RequiredSynergy = "The Sum Of It's Parts";
		advancedHoveringGunSynergyProcessor.requiresTargetGunInInventory = true;
		advancedHoveringGunSynergyProcessor.fireDelayBasedOnGun = true;
		advancedHoveringGunSynergyProcessor.BeamFireDuration = 1.2f;
		advancedHoveringGunSynergyProcessor.Trigger = AdvancedHoveringGunSynergyProcessor.TriggerStyle.CONSTANT;
		advancedHoveringGunSynergyProcessor.PositionType = (HoverPosition)1;
		advancedHoveringGunSynergyProcessor.IDsToSpawn = new int[5] { 122, 87, 30, 94, 15 };
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId7 = PickupObjectDatabase.GetById(124);
		muzzleFlashEffects = ((Gun)((byId7 is Gun) ? byId7 : null)).muzzleFlashEffects;
		val.reloadTime = 1.21f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.6875f, 0.875f, 0f);
		val.SetBaseMaxAmmo(700);
		val.gunClass = (GunClass)10;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
