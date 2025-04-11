using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class SoakGoopProjModifier : MonoBehaviour
{
	private Projectile self;

	private List<GoopDefinition> AbsorbedGoops;

	private void Start()
	{
		AbsorbedGoops = new List<GoopDefinition>();
		self = ((Component)this).GetComponent<Projectile>();
	}

	private void Update()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)GameManager.Instance.Dungeon == (Object)null)
		{
			return;
		}
		RoomHandler absoluteRoom = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)self).transform.position);
		List<DeadlyDeadlyGoopManager> roomGoops = absoluteRoom.RoomGoops;
		if (roomGoops == null)
		{
			return;
		}
		for (int i = 0; i < roomGoops.Count; i++)
		{
			if (!roomGoops[i].IsPositionInGoop(((BraveBehaviour)self).specRigidbody.UnitCenter))
			{
				continue;
			}
			IntVector2 val = Vector2Extensions.ToIntVector2(((BraveBehaviour)self).specRigidbody.UnitCenter / DeadlyDeadlyGoopManager.GOOP_GRID_SIZE, (VectorConversions)0);
			DeadlyDeadlyGoopManager val2 = roomGoops[i];
			GoopDefinition goopDefinition = val2.goopDefinition;
			if (goopDefinition.AppliesCharm && goopDefinition.CharmModifierEffect != null)
			{
				self.statusEffectsToApply.Add((GameActorEffect)(object)goopDefinition.CharmModifierEffect);
				if (((GameActorEffect)goopDefinition.CharmModifierEffect).AppliesTint)
				{
					self.AdjustPlayerProjectileTint(((GameActorEffect)goopDefinition.CharmModifierEffect).TintColor, 2, 0f);
				}
			}
			if (goopDefinition.AppliesCheese && goopDefinition.CheeseModifierEffect != null)
			{
				self.statusEffectsToApply.Add((GameActorEffect)(object)goopDefinition.CheeseModifierEffect);
				if (((GameActorEffect)goopDefinition.CheeseModifierEffect).AppliesTint)
				{
					self.AdjustPlayerProjectileTint(((GameActorEffect)goopDefinition.CheeseModifierEffect).TintColor, 2, 0f);
				}
			}
			if (goopDefinition.AppliesDamageOverTime && goopDefinition.HealthModifierEffect != null)
			{
				self.statusEffectsToApply.Add((GameActorEffect)(object)goopDefinition.HealthModifierEffect);
				if (((GameActorEffect)goopDefinition.HealthModifierEffect).AppliesTint)
				{
					self.AdjustPlayerProjectileTint(((GameActorEffect)goopDefinition.HealthModifierEffect).TintColor, 2, 0f);
				}
			}
			if ((goopDefinition.AppliesSpeedModifier || goopDefinition.AppliesSpeedModifierContinuously) && goopDefinition.SpeedModifierEffect != null)
			{
				self.statusEffectsToApply.Add((GameActorEffect)(object)goopDefinition.SpeedModifierEffect);
				if (((GameActorEffect)goopDefinition.SpeedModifierEffect).AppliesTint)
				{
					self.AdjustPlayerProjectileTint(((GameActorEffect)goopDefinition.HealthModifierEffect).TintColor, 2, 0f);
				}
			}
			if (goopDefinition.damagesEnemies)
			{
				ProjectileData baseData = self.baseData;
				baseData.damage += goopDefinition.damagePerSecondtoEnemies;
				self.AdjustPlayerProjectileTint(Color32.op_Implicit(goopDefinition.baseColor32), 2, 0f);
			}
			if (val2.IsPositionOnFire(((BraveBehaviour)self).specRigidbody.UnitCenter))
			{
				self.statusEffectsToApply.Add((GameActorEffect)(object)goopDefinition.fireEffect);
				if (((GameActorEffect)goopDefinition.fireEffect).AppliesTint)
				{
					self.AdjustPlayerProjectileTint(((GameActorEffect)goopDefinition.fireEffect).TintColor, 2, 0f);
				}
			}
			if (val2.IsPositionFrozen(((BraveBehaviour)self).specRigidbody.UnitCenter))
			{
				self.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.frostBulletsEffect);
				self.AdjustPlayerProjectileTint(ExtendedColours.frostBulletsTint, 2, 0f);
			}
			AbsorbedGoops.Add(goopDefinition);
			for (int j = 0; j < StaticReferenceManager.AllGoops.Count; j++)
			{
				if (Object.op_Implicit((Object)(object)StaticReferenceManager.AllGoops[j]))
				{
					StaticReferenceManager.AllGoops[j].RemoveGoopCircle(((BraveBehaviour)self).specRigidbody.UnitCenter, 0.5f);
				}
			}
		}
	}
}
