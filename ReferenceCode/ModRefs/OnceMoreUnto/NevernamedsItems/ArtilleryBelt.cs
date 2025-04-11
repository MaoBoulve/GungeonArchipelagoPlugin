using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class ArtilleryBelt : PassiveItem
{
	private float timer;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ArtilleryBelt>("Artillery Belt", "From The Hip", "Takes pot-shots at your foes.\n\nA relic of Alben Smallbore's research on garmentosapience.", "artillerybelt_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (timer > 0f)
			{
				timer -= BraveTime.DeltaTime;
			}
			if (timer <= 0f)
			{
				if (Random.value <= 0.1f && ((PassiveItem)this).Owner.IsInCombat)
				{
					Fire();
				}
				timer = 0.1f;
			}
		}
		((PassiveItem)this).Update();
	}

	private void Fire()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody != (Object)null && (Object)(object)MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null) != (Object)null)
		{
			AkSoundEngine.PostEvent("Play_WPN_smileyrevolver_shot_01", ((Component)this).gameObject);
			PickupObject byId = PickupObjectDatabase.GetById(86);
			GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject, ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, Vector2.op_Implicit(MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null).Position), 0f, 20f, ((PassiveItem)this).Owner);
			Projectile component = val.GetComponent<Projectile>();
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			ProjectileData baseData = component.baseData;
			baseData.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = component.baseData;
			baseData2.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
			ProjectileData baseData3 = component.baseData;
			baseData3.range *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)26);
			ProjectileData baseData4 = component.baseData;
			baseData4.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
			((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			ProjectileUtility.ApplyCompanionModifierToBullet(component, ((PassiveItem)this).Owner);
		}
	}

	public override void Pickup(PlayerController player)
	{
		timer = 0.1f;
		((PassiveItem)this).Pickup(player);
	}
}
