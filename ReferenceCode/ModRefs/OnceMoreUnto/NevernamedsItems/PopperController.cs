using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class PopperController : GameObjectDamageAura
{
	private SpeculativeRigidbody body;

	private tk2dSprite sprite;

	private tk2dSpriteAnimator animator;

	public float secondsTillDeath;

	private float timer;

	private bool isDead;

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
			if (Object.op_Implicit((Object)(object)body))
			{
				return body.UnitCenter;
			}
			if (Object.op_Implicit((Object)(object)sprite))
			{
				return ((tk2dBaseSprite)sprite).WorldCenter;
			}
			return Vector2.op_Implicit(((Component)this).transform.position);
		}
	}

	public PopperController()
	{
		secondsTillDeath = 20f;
	}

	public override void Start()
	{
		isDead = false;
		timer = secondsTillDeath;
		if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<SpeculativeRigidbody>()))
		{
			body = ((Component)this).GetComponent<SpeculativeRigidbody>();
		}
		if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<tk2dSprite>()))
		{
			sprite = ((Component)this).GetComponent<tk2dSprite>();
		}
		if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<tk2dSpriteAnimator>()))
		{
			animator = ((Component)this).GetComponent<tk2dSpriteAnimator>();
		}
		base.Start();
	}

	private void FixedUpdate()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((Component)this).gameObject != (Object)null && !isDead)
		{
			if (Vector3Extensions.GetAbsoluteRoom(CenterPosition) == null || GameManager.Instance.PrimaryPlayer.CurrentRoom == null)
			{
				KeelOver();
			}
			else if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null && GameManager.Instance.PrimaryPlayer.CurrentRoom != null && Vector3Extensions.GetAbsoluteRoom(CenterPosition) != null && GameManager.Instance.PrimaryPlayer.CurrentRoom != Vector3Extensions.GetAbsoluteRoom(CenterPosition))
			{
				KeelOver();
			}
			if (timer > 0f)
			{
				timer -= BraveTime.DeltaTime;
			}
			if (timer <= 0f)
			{
				KeelOver();
			}
		}
	}

	public void KeelOver()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (!isDead)
		{
			isDead = true;
			if (Object.op_Implicit((Object)(object)animator))
			{
				animator.Play("popper_deactivate");
			}
			damageAuraActivated = false;
			if (Object.op_Implicit((Object)(object)((Component)this).gameObject.GetComponent<DebrisObject>()))
			{
				((EphemeralObject)((Component)this).gameObject.GetComponent<DebrisObject>()).Priority = (EphemeralPriority)3;
			}
		}
	}

	public override void TickedOnEnemy(AIActor enemy)
	{
		if (GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "Pickled Poppers"))
		{
			((GameActor)enemy).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect, 1f, (Projectile)null);
		}
		base.TickedOnEnemy(enemy);
	}
}
