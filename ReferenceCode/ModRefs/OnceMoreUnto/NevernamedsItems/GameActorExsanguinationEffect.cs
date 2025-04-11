using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class GameActorExsanguinationEffect : GameActorEffect
{
	private int currentStackAmount;

	private GameObject extantOverheadder;

	private float bloodAccum;

	private List<float> stackedBleedTimers;

	public GameActorExsanguinationEffect()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		base.DeathTintColor = Color.red;
		base.AppliesTint = false;
		base.AppliesDeathTint = true;
		base.AffectsPlayers = false;
		base.AffectsEnemies = true;
		base.stackMode = (EffectStackingMode)3;
		base.effectIdentifier = "exsanguination";
		bloodAccum = 0f;
		stackedBleedTimers = new List<float>();
	}

	public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1f)
	{
		currentStackAmount = 1;
		ChangeOverheadVFX(1, actor);
		((BraveBehaviour)actor).healthHaver.OnDeath += OnTargetDeath;
		((GameActorEffect)this).OnEffectApplied(actor, effectData, partialAmount);
	}

	private void OnTargetDeath(Vector2 dir)
	{
		if ((Object)(object)extantOverheadder != (Object)null)
		{
			Object.Destroy((Object)(object)extantOverheadder);
		}
	}

	public void ChangeOverheadVFX(int stackamount, GameActor target, bool lethal = false)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		if (stackamount > 0)
		{
			if ((Object)(object)extantOverheadder != (Object)null)
			{
				Object.Destroy((Object)(object)extantOverheadder);
			}
			GameObject val = ExsanguinationSetup.labelStackVFX;
			if (stackamount <= 5)
			{
				val = ExsanguinationSetup.effectStackVFX[stackamount];
			}
			GameObject val2 = Object.Instantiate<GameObject>(val);
			tk2dBaseSprite component = val2.GetComponent<tk2dBaseSprite>();
			val2.transform.parent = ((BraveBehaviour)target).transform;
			if (((BraveBehaviour)target).healthHaver.IsBoss)
			{
				val2.transform.position = Vector2.op_Implicit(((BraveBehaviour)target).specRigidbody.HitboxPixelCollider.UnitTopCenter);
			}
			else
			{
				Bounds bounds = ((BraveBehaviour)target).sprite.GetBounds();
				Vector3 val3 = ((BraveBehaviour)target).transform.position + dfVectorExtensions.Quantize(new Vector3((((Bounds)(ref bounds)).max.x + ((Bounds)(ref bounds)).min.x) / 2f, ((Bounds)(ref bounds)).max.y, 0f), 0.0625f);
				val2.transform.position = Vector3Extensions.WithY(Vector2Extensions.ToVector3ZUp(((BraveBehaviour)target).sprite.WorldCenter, 0f), val3.y);
			}
			component.HeightOffGround = 0.5f;
			((BraveBehaviour)target).sprite.AttachRenderer(component);
			Color red = Color.red;
			red.a = 0.1f * (float)Mathf.Min(stackamount, 10);
			target.RegisterOverrideColor(red, "exsanguination");
			extantOverheadder = val2;
			if (stackamount > 5)
			{
				RelativeLabelAttacher relativeLabelAttacher = extantOverheadder.AddComponent<RelativeLabelAttacher>();
				relativeLabelAttacher.colour = ExtendedColours.carrionRed;
				relativeLabelAttacher.offset = new Vector3(0f, 0.75f, 0f);
				relativeLabelAttacher.labelValue = stackamount.ToString();
			}
		}
		else
		{
			if ((Object)(object)extantOverheadder != (Object)null)
			{
				Object.Destroy((Object)(object)extantOverheadder);
			}
			if (!lethal)
			{
				target.DeregisterOverrideColor("exsanguination");
			}
		}
	}

	public override void EffectTick(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector3Extensions.XY(((BraveBehaviour)actor).transform.position);
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).specRigidbody) && ((BraveBehaviour)actor).specRigidbody.HitboxPixelCollider != null)
		{
			val = dfVectorExtensions.Quantize(((BraveBehaviour)actor).specRigidbody.HitboxPixelCollider.UnitTopCenter, 0.0625f);
		}
		if ((Object)(object)extantOverheadder != (Object)null && (Object)(object)extantOverheadder.GetComponent<tk2dBaseSprite>() != (Object)null)
		{
			extantOverheadder.transform.position = Vector2.op_Implicit(val);
			((BraveBehaviour)extantOverheadder.GetComponent<tk2dBaseSprite>()).renderer.enabled = !actor.IsGone;
		}
		if (((BraveBehaviour)actor).healthHaver.IsDead && (Object)(object)extantOverheadder != (Object)null)
		{
			ChangeOverheadVFX(0, actor, lethal: true);
		}
		bloodAccum += BraveTime.DeltaTime * Mathf.Min(10f * (float)currentStackAmount, 100f);
		if (bloodAccum > 1f)
		{
			int num = Mathf.FloorToInt(bloodAccum);
			bloodAccum %= 1f;
			Vector2 worldBottomLeft = ((BraveBehaviour)actor).sprite.WorldBottomLeft;
			Vector2 worldTopRight = ((BraveBehaviour)actor).sprite.WorldTopRight;
			for (int i = 0; i < num; i++)
			{
				Object.Destroy((Object)(object)Object.Instantiate<GameObject>(ExsanguinationSetup.BloodParticleDoer, Vector2.op_Implicit(new Vector2(Random.Range(worldBottomLeft.x, worldTopRight.x), Random.Range(worldBottomLeft.y, worldTopRight.y))), Quaternion.identity), 5f);
			}
		}
		if (base.AffectsEnemies && actor is AIActor && currentStackAmount > 0)
		{
			((BraveBehaviour)actor).healthHaver.ApplyDamage(1.75f * (float)currentStackAmount * BraveTime.DeltaTime, Vector2.zero, base.effectIdentifier, (CoreDamageTypes)0, (DamageCategory)1, false, (PixelCollider)null, false);
		}
		if (stackedBleedTimers != null && stackedBleedTimers.Count > 0 && currentStackAmount > 1)
		{
			if (stackedBleedTimers[0] > 0f)
			{
				stackedBleedTimers[0] -= BraveTime.DeltaTime;
			}
			else
			{
				currentStackAmount--;
				stackedBleedTimers.RemoveAt(0);
				ChangeOverheadVFX(currentStackAmount, actor);
			}
		}
		((GameActorEffect)this).EffectTick(actor, effectData);
	}

	public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		currentStackAmount = 0;
		ChangeOverheadVFX(0, actor);
		((GameActorEffect)this).OnEffectRemoved(actor, effectData);
	}

	public void AddStackLayer(GameActor actor, float dur)
	{
		currentStackAmount++;
		ChangeOverheadVFX(currentStackAmount, actor);
		stackedBleedTimers.Add(dur);
	}

	public override void OnDarkSoulsAccumulate(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1f, Projectile sourceProjectile = null)
	{
		for (int i = 0; i < actor.m_activeEffects.Count; i++)
		{
			if (actor.m_activeEffects[i].effectIdentifier == base.effectIdentifier && actor.m_activeEffects[i] is GameActorExsanguinationEffect)
			{
				RuntimeGameActorEffectData obj = actor.m_activeEffectData[i];
				obj.elapsed -= base.duration;
				(actor.m_activeEffects[i] as GameActorExsanguinationEffect).AddStackLayer(actor, base.duration);
			}
		}
		((GameActorEffect)this).OnDarkSoulsAccumulate(actor, effectData, partialAmount, sourceProjectile);
	}
}
