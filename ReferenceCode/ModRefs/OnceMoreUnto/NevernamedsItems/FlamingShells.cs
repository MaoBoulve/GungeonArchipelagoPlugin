using System;
using System.Collections.Generic;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class FlamingShells : PassiveItem
{
	public static int ID;

	public static List<Projectile> options = new List<Projectile>();

	private Gun lastCheckedGun;

	public bool look = false;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<FlamingShells>("Flaming Shells", "Hothothothothothothot", "Adds a spurt of flames to every gunshot...\n\nThese ingenious shells were created by attaching a primer directly to an open flame. Why didn't we do this earlier?!", "flamingshells_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		ID = val.PickupObjectId;
		val.SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 34f, (PrerequisiteOperation)2);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Update()
	{
		if (look && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && (Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun != (Object)null && (Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun != (Object)(object)lastCheckedGun)
		{
			if ((Object)(object)lastCheckedGun != (Object)null)
			{
				Gun obj = lastCheckedGun;
				obj.OnPostFired = (Action<PlayerController, Gun>)Delegate.Remove(obj.OnPostFired, new Action<PlayerController, Gun>(OnFiredGun));
			}
			Gun currentGun = ((GameActor)((PassiveItem)this).Owner).CurrentGun;
			currentGun.OnPostFired = (Action<PlayerController, Gun>)Delegate.Combine(currentGun.OnPostFired, new Action<PlayerController, Gun>(OnFiredGun));
			lastCheckedGun = ((GameActor)((PassiveItem)this).Owner).CurrentGun;
		}
		((PassiveItem)this).Update();
	}

	public void OnFiredGun(PlayerController shooter, Gun gun)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)shooter) || !Object.op_Implicit((Object)(object)gun) || !Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || !((Object)(object)shooter == (Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		float num = 1f / gun.DefaultModule.cooldownTime;
		float num2 = 8f;
		if ((int)gun.DefaultModule.shootStyle == 2)
		{
			num2 = 0.1f;
		}
		float num3 = num2 / num;
		num3 = Mathf.Max(0.1f, num3);
		List<Projectile> list = new List<Projectile>();
		float num4 = num3;
		while (num4 > 0f)
		{
			if (num4 >= 1f)
			{
				list.Add(BraveUtility.RandomElement<Projectile>(options));
				num4 -= 1f;
				continue;
			}
			if (Random.value <= num4)
			{
				list.Add(BraveUtility.RandomElement<Projectile>(options));
			}
			num4 = 0f;
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Projectile item in list)
		{
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(item, Vector2.op_Implicit(gun.barrelOffset.position), gun.CurrentAngle, 45f, shooter).GetComponent<Projectile>();
			component.Owner = (GameActor)(object)shooter;
			component.Shooter = ((BraveBehaviour)shooter).specRigidbody;
			component.ScaleByPlayerStats(shooter);
			shooter.DoPostProcessProjectile(component);
			ProjectileData baseData = component.baseData;
			baseData.speed *= Random.Range(0.5f, 1f);
			component.UpdateSpeed();
			component.baseData.range = Random.Range(3f, 5f);
		}
	}

	private void PostProcessBeamTick(BeamController bemcont, SpeculativeRigidbody beam, float effectChanceScalar)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(BraveUtility.RandomElement<Projectile>(options), bemcont.Origin, Vector2Extensions.ToAngle(bemcont.Direction), 45f, ((PassiveItem)this).Owner).GetComponent<Projectile>();
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			component.ScaleByPlayerStats(((PassiveItem)this).Owner);
			((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			ProjectileData baseData = component.baseData;
			baseData.speed *= Random.Range(0.5f, 1f);
			ProjectileData baseData2 = component.baseData;
			baseData2.damage *= 0.5f;
			component.UpdateSpeed();
			component.baseData.range = Random.Range(3f, 5f);
			if ((Object)(object)((Component)component).gameObject.GetComponent<SlowDownOverTimeModifier>() != (Object)null)
			{
				((Component)component).gameObject.GetComponent<SlowDownOverTimeModifier>().timeTillKillAfterCompleteStop = 5f;
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (options.Count == 0)
		{
			List<Projectile> list = options;
			PickupObject byId = PickupObjectDatabase.GetById(336);
			list.Add(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
			List<Projectile> list2 = options;
			PickupObject byId2 = PickupObjectDatabase.GetById(336);
			list2.Add(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
			options.Add(StandardisedProjectiles.smoke);
			options.Add(StandardisedProjectiles.flamethrower);
			options.Add(StandardisedProjectiles.flamethrower);
		}
		look = true;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		look = false;
		if ((Object)(object)lastCheckedGun != (Object)null)
		{
			Gun obj = lastCheckedGun;
			obj.OnPostFired = (Action<PlayerController, Gun>)Delegate.Remove(obj.OnPostFired, new Action<PlayerController, Gun>(OnFiredGun));
			lastCheckedGun = null;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
