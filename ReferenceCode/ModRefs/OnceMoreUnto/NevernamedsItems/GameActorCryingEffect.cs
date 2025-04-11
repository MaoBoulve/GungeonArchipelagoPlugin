using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class GameActorCryingEffect : GameActorEffect
{
	private float tearAccum;

	public GameActorCryingEffect()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		base.TintColor = Color.blue;
		base.DeathTintColor = Color.blue;
		base.AppliesTint = false;
		base.AppliesDeathTint = false;
		base.AffectsPlayers = false;
		base.AffectsEnemies = true;
		base.effectIdentifier = "crying";
		base.OverheadVFX = SharedVFX.CryingOverhead;
		tearAccum = 0f;
	}

	public override void EffectTick(GameActor actor, RuntimeGameActorEffectData effectData)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		tearAccum += BraveTime.DeltaTime * 4f;
		if (tearAccum > 1f)
		{
			int num = Mathf.FloorToInt(tearAccum);
			tearAccum %= 1f;
			Vector2 worldBottomLeft = ((BraveBehaviour)actor).sprite.WorldBottomLeft;
			Vector2 worldTopRight = ((BraveBehaviour)actor).sprite.WorldTopRight;
			for (int i = 0; i < num; i++)
			{
				PickupObject byId = PickupObjectDatabase.GetById(33);
				GameObject val = ProjectileUtility.InstantiateAndFireInDirection(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0], new Vector2(Random.Range(worldBottomLeft.x, worldTopRight.x), Random.Range(worldBottomLeft.y, worldTopRight.y)), BraveUtility.RandomAngle(), 0f, (PlayerController)null);
				GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(val.gameObject);
				Projectile component = val.gameObject.GetComponent<Projectile>();
				if (Object.op_Implicit((Object)(object)component))
				{
					component.Owner = (GameActor)(object)GameManager.Instance.BestActivePlayer;
					ProjectileData baseData = component.baseData;
					baseData.range *= 0.6f;
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)actor).specRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)component).specRigidbody))
					{
						((BraveBehaviour)component).specRigidbody.RegisterSpecificCollisionException(((BraveBehaviour)actor).specRigidbody);
					}
				}
			}
		}
		((GameActorEffect)this).EffectTick(actor, effectData);
	}
}
