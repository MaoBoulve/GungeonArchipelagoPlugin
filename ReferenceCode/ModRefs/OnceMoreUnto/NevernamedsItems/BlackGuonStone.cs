using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class BlackGuonStone : AdvancedPlayerOrbitalItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BlackGuonStone>("Black Guon Stone", "No Bullets Can Escape", "Chance to crush enemy bullets into a single point of infinite density.\n\nThis ancient stone, though appearing arcane, is entirely based on scientific principles. Batteries are included.", "blackguonstone_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		val.OrbitalPrefab = ItemSetup.CreateOrbitalObject("Black Guon Stone", "blackguonstone_orbital", new IntVector2(8, 8), new IntVector2(-4, -4), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0).GetComponent<PlayerOrbital>();
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Blacker Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ItemSetup.CreateOrbitalObject("Blacker Guon Stone", "blackguonstone_synergy", new IntVector2(12, 12), new IntVector2(-6, -6), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0, 10f);
	}

	public override void OnOrbitalCreated(GameObject orbital)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		SpeculativeRigidbody component = orbital.GetComponent<SpeculativeRigidbody>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)component.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHit));
		}
		((AdvancedPlayerOrbitalItem)this).OnOrbitalCreated(orbital);
	}

	private void OnGuonHit(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		if (!(Random.value <= 0.25f))
		{
			return;
		}
		Projectile component = ((Component)other).GetComponent<Projectile>();
		if (!((Object)(object)component != (Object)null) || !((Object)(object)ProjectileUtility.ProjectilePlayerOwner(component) == (Object)null) || !Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		Projectile val = ((Gun)PickupObjectDatabase.GetById(169)).DefaultModule.projectiles[0];
		float num = Vector2Extensions.ToAngle(myRigidbody.UnitCenter - ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter);
		GameObject val2 = ProjectileUtility.InstantiateAndFireInDirection(val, myRigidbody.UnitCenter, num, 0f, (PlayerController)null);
		Projectile component2 = val2.GetComponent<Projectile>();
		if ((Object)(object)component2 != (Object)null)
		{
			component2.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component2.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			if (!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Blacker Guon Stone"))
			{
				component2.RuntimeUpdateScale(0.5f);
				ProjectileData baseData = component2.baseData;
				baseData.damage *= 0.5f;
			}
			ProjectileData baseData2 = component2.baseData;
			baseData2.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
			((PassiveItem)this).Owner.DoPostProcessProjectile(component2);
			SlowDownOverTimeModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<SlowDownOverTimeModifier>(((Component)component2).gameObject);
			orAddComponent.timeToSlowOver = 0.5f;
			orAddComponent.timeTillKillAfterCompleteStop = (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Schwarzschild Radius") ? 1f : 0.5f);
			orAddComponent.killAfterCompleteStop = true;
			orAddComponent.extendTimeByRangeStat = false;
		}
	}
}
