using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class TotemOfGundying : AdvancedGunBehavior
{
	public static int ID;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Totem of Gundying", "totemofgundying");
		Game.Items.Rename("outdated_gun_mods:totem_of_gundying", "nn:totem_of_gundying");
		((Component)val).gameObject.AddComponent<TotemOfGundying>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Postmortal");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ancient relic of a lost religion, holding this totem-shaped gun as one breathes their last breath allows them to return to the firefight, fit and ready for action.");
		val.SetGunSprites("totemofgundying");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 9);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 9);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(89);
		muzzleFlashEffects = ((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects;
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId3 = PickupObjectDatabase.GetById(145);
		gunSwitchGroup = ((Gun)((byId3 is Gun) ? byId3 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 4;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.125f, 1.5625f, 0f);
		val.SetBaseMaxAmmo(120);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val2.baseData.damage = 9f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)val2).gameObject.AddComponent<SlowDownOverTimeModifier>();
		slowDownOverTimeModifier.extendTimeByRangeStat = true;
		slowDownOverTimeModifier.doRandomTimeMultiplier = true;
		slowDownOverTimeModifier.killAfterCompleteStop = true;
		slowDownOverTimeModifier.timeTillKillAfterCompleteStop = 0.5f;
		slowDownOverTimeModifier.timeToSlowOver = 0.5f;
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(89);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		((Component)val2).gameObject.AddComponent<PierceProjModifier>().penetration = 1;
		((Component)val2).gameObject.AddComponent<BounceProjModifier>().numberOfBounces = 1;
		ProjectileBuilders.AnimateProjectileBundle(val2, "TotemOfGundyingProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "TotemOfGundyingProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(9, 9), 2), MiscTools.DupeList(value: true, 2), MiscTools.DupeList<Anchor>((Anchor)4, 2), MiscTools.DupeList(value: true, 2), MiscTools.DupeList(value: false, 2), MiscTools.DupeList<Vector3?>(null, 2), MiscTools.DupeList<IntVector2?>(null, 2), MiscTools.DupeList<IntVector2?>(null, 2), MiscTools.DupeList<Projectile>(null, 2));
		((PickupObject)val).quality = (ItemQuality)(-100);
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		((BraveBehaviour)player).healthHaver.OnPreDeath += OwnerTookDamage;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	private void OwnerTookDamage(Vector2 dir)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		if (!Object.op_Implicit((Object)(object)((AdvancedGunBehavior)this).Owner) || !(((AdvancedGunBehavior)this).Owner is PlayerController) || ((!(((BraveBehaviour)(PlayerController)((AdvancedGunBehavior)this).Owner).healthHaver.GetCurrentHealth() < 0.5f) || !((Object)(object)((GameActor)(PlayerController)((AdvancedGunBehavior)this).Owner).CurrentGun != (Object)null) || ((PickupObject)((GameActor)(PlayerController)((AdvancedGunBehavior)this).Owner).CurrentGun).PickupObjectId != ID) && (!((Object)(object)((PlayerController)((AdvancedGunBehavior)this).Owner).CurrentSecondaryGun != (Object)null) || ((PickupObject)((PlayerController)((AdvancedGunBehavior)this).Owner).CurrentSecondaryGun).PickupObjectId != ID)))
		{
			return;
		}
		if (((PlayerController)((AdvancedGunBehavior)this).Owner).ForceZeroHealthState)
		{
			HealthHaver healthHaver = ((BraveBehaviour)(PlayerController)((AdvancedGunBehavior)this).Owner).healthHaver;
			healthHaver.Armor += 6f;
		}
		((BraveBehaviour)(PlayerController)((AdvancedGunBehavior)this).Owner).healthHaver.FullHeal();
		((BraveBehaviour)(PlayerController)((AdvancedGunBehavior)this).Owner).healthHaver.OnPreDeath -= OwnerTookDamage;
		((PlayerController)((AdvancedGunBehavior)this).Owner).stats.RecalculateStats((PlayerController)((AdvancedGunBehavior)this).Owner, false, false);
		((PlayerController)((AdvancedGunBehavior)this).Owner).ClearDeadFlags();
		for (int i = 0; i < 20; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(ID);
			GameObject gameObject = ((Component)((BraveBehaviour)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).projectile).gameObject;
			GameObject val = Object.Instantiate<GameObject>(gameObject, Vector2.op_Implicit(((GameActor)(PlayerController)((AdvancedGunBehavior)this).Owner).CenterPosition), Quaternion.Euler(new Vector3(0f, 0f, (float)Random.Range(0, 360))));
			Projectile component = val.GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.Owner = ((AdvancedGunBehavior)this).Owner;
				component.Shooter = ((BraveBehaviour)((AdvancedGunBehavior)this).Owner).specRigidbody;
				ProjectileData baseData = component.baseData;
				baseData.damage *= ((PlayerController)((AdvancedGunBehavior)this).Owner).stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= ((PlayerController)((AdvancedGunBehavior)this).Owner).stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.range *= ((PlayerController)((AdvancedGunBehavior)this).Owner).stats.GetStatValue((StatType)26);
				ProjectileData baseData4 = component.baseData;
				baseData4.force *= ((PlayerController)((AdvancedGunBehavior)this).Owner).stats.GetStatValue((StatType)12);
				component.BossDamageMultiplier *= ((PlayerController)((AdvancedGunBehavior)this).Owner).stats.GetStatValue((StatType)22);
				component.UpdateSpeed();
				((PlayerController)((AdvancedGunBehavior)this).Owner).DoPostProcessProjectile(component);
			}
		}
		for (int num = ((PlayerController)((AdvancedGunBehavior)this).Owner).inventory.AllGuns.Count; num >= 0; num--)
		{
			if (((PickupObject)((PlayerController)((AdvancedGunBehavior)this).Owner).inventory.AllGuns[num]).PickupObjectId == ID)
			{
				PlayerUtility.RemoveItemFromInventory((PlayerController)((AdvancedGunBehavior)this).Owner, (PickupObject)(object)((PlayerController)((AdvancedGunBehavior)this).Owner).inventory.AllGuns[num]);
			}
		}
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((BraveBehaviour)(PlayerController)((AdvancedGunBehavior)this).Owner).healthHaver.OnPreDeath -= OwnerTookDamage;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}
}
