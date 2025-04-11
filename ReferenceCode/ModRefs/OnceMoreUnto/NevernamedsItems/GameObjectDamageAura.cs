using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class GameObjectDamageAura : MonoBehaviour
{
	private SpeculativeRigidbody body;

	private tk2dSprite sprite;

	public float damagePerSecond;

	public bool damageFallsOff;

	public float radius;

	public bool startActivated;

	public bool damageAuraActivated;

	private float ScaledDamagePerSecond => damagePerSecond;

	private float ScaledRadius => radius;

	private Vector2 CenterPosition
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)sprite))
			{
				return ((tk2dBaseSprite)sprite).WorldCenter;
			}
			if (Object.op_Implicit((Object)(object)body))
			{
				return body.UnitCenter;
			}
			return Vector2.op_Implicit(((Component)this).transform.position);
		}
	}

	public GameObjectDamageAura()
	{
		damageFallsOff = false;
		radius = 3f;
		damagePerSecond = 5f;
		startActivated = true;
	}

	public virtual void Start()
	{
		damageAuraActivated = startActivated;
		if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<SpeculativeRigidbody>()))
		{
			body = ((Component)this).GetComponent<SpeculativeRigidbody>();
		}
		if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<tk2dSprite>()))
		{
			sprite = ((Component)this).GetComponent<tk2dSprite>();
		}
	}

	private void Update()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		if (Vector3Extensions.GetAbsoluteRoom(CenterPosition) == null || !damageAuraActivated)
		{
			return;
		}
		List<AIActor> activeEnemies = Vector3Extensions.GetAbsoluteRoom(CenterPosition).GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (!val.IsNormalEnemy || !Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver))
			{
				continue;
			}
			float num = Vector2.Distance(CenterPosition, ((GameActor)val).CenterPosition);
			if (num <= ScaledRadius)
			{
				float num2 = ScaledDamagePerSecond * BraveTime.DeltaTime;
				if (damageFallsOff)
				{
					num2 = Mathf.Lerp(num2, 0f, num / ScaledRadius);
				}
				((BraveBehaviour)val).healthHaver.ApplyDamage(num2, Vector2.zero, "Aura", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
				TickedOnEnemy(val);
			}
		}
	}

	public virtual void TickedOnEnemy(AIActor enemy)
	{
	}
}
