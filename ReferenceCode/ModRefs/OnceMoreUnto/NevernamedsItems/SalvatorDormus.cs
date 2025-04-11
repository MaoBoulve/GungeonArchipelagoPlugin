using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SalvatorDormus : AdvancedGunBehavior
{
	public static int ID;

	public int lastGunCount;

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Salvator Dormus", "salvatordormus");
		Game.Items.Rename("outdated_gun_mods:salvator_dormus", "nn:salvator_dormus");
		((Component)val).gameObject.AddComponent<SalvatorDormus>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Type Match");
		GunExt.SetLongDescription((PickupObject)(object)val, "Increases it's own stats based on what other types of gun are in it's owner's possession\n\nOne of the earliest models of semiautomatic pistol ever invented, it's ancestral promenance grants it more power the more of it's descendants are held.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "salvatordormus_idle_001", 8, "salvatordormus_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.12f;
		val.DefaultModule.numberOfShotsInClip = 7;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5625f, 0.875f, 0f);
		val.SetBaseMaxAmmo(440);
		val.gunClass = (GunClass)1;
		Projectile component = FakePrefabExtensions.InstantiateAndFakeprefab(((Component)val.DefaultModule.projectiles[0]).gameObject).GetComponent<Projectile>();
		val.DefaultModule.projectiles[0] = component;
		ref GameObject overrideMidairDeathVFX = ref component.hitEffects.overrideMidairDeathVFX;
		PickupObject byId2 = PickupObjectDatabase.GetById(178);
		overrideMidairDeathVFX = ((Component)((byId2 is Gun) ? byId2 : null)).GetComponent<FireOnReloadSynergyProcessor>().DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.hitEffects.tileMapHorizontal.effects[0].effects[0].effect;
		component.hitEffects.alwaysUseMidair = true;
		component.baseData.damage = 7f;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnSwitchedToThisGun()
	{
		UpdateGunStats();
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
		UpdateGunStats();
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		UpdateGunStats();
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	public void UpdateGunStats()
	{
		ItemBuilder.RemoveCurrentGunStatModifier(base.gun, (StatType)1);
		ItemBuilder.RemoveCurrentGunStatModifier(base.gun, (StatType)10);
		ItemBuilder.RemoveCurrentGunStatModifier(base.gun, (StatType)5);
		ItemBuilder.RemoveCurrentGunStatModifier(base.gun, (StatType)6);
		ItemBuilder.RemoveCurrentGunStatModifier(base.gun, (StatType)16);
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			ItemBuilder.AddCurrentGunStatModifier(base.gun, (StatType)1, 1f + 0.05f * (float)GunTools.GunPlayerOwner(base.gun).inventory.AllGuns.FindAll((Gun x) => x.DefaultModule != null && (int)x.DefaultModule.shootStyle == 1).Count, (ModifyMethod)1);
			ItemBuilder.AddCurrentGunStatModifier(base.gun, (StatType)10, Mathf.Max(0f, 1f - 0.05f * (float)GunTools.GunPlayerOwner(base.gun).inventory.AllGuns.FindAll((Gun x) => x.DefaultModule != null && (int)x.DefaultModule.shootStyle == 0).Count), (ModifyMethod)1);
			ItemBuilder.AddCurrentGunStatModifier(base.gun, (StatType)5, 1f + 0.05f * (float)GunTools.GunPlayerOwner(base.gun).inventory.AllGuns.FindAll((Gun x) => x.DefaultModule != null && (int)x.DefaultModule.shootStyle == 3).Count, (ModifyMethod)1);
			ItemBuilder.AddCurrentGunStatModifier(base.gun, (StatType)6, 1f + 0.05f * (float)GunTools.GunPlayerOwner(base.gun).inventory.AllGuns.FindAll((Gun x) => x.DefaultModule != null && (int)x.DefaultModule.shootStyle == 4).Count, (ModifyMethod)1);
			ItemBuilder.AddCurrentGunStatModifier(base.gun, (StatType)16, 1f + 0.05f * (float)GunTools.GunPlayerOwner(base.gun).inventory.AllGuns.FindAll((Gun x) => x.DefaultModule != null && (int)x.DefaultModule.shootStyle == 2).Count, (ModifyMethod)1);
			GunTools.GunPlayerOwner(base.gun).stats.RecalculateStats(GunTools.GunPlayerOwner(base.gun), false, false);
		}
	}

	protected override void NonCurrentGunUpdate()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && GunTools.GunPlayerOwner(base.gun).inventory.AllGuns.Count != lastGunCount)
		{
			UpdateGunStats();
			lastGunCount = GunTools.GunPlayerOwner(base.gun).inventory.AllGuns.Count;
		}
		((AdvancedGunBehavior)this).NonCurrentGunUpdate();
	}
}
