using UnityEngine;

namespace NevernamedsItems;

public class GoldenAppleEffectHandler : MonoBehaviour
{
	public PlayerController target;

	public float timer;

	private DamageTypeModifier fireImmunity;

	private StatModifier SpeedBuff;

	private StatModifier DamageBuff;

	private float ParticleTimer;

	public void Start()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (fireImmunity == null)
		{
			fireImmunity = new DamageTypeModifier();
			fireImmunity.damageMultiplier = 0f;
			fireImmunity.damageType = (CoreDamageTypes)4;
		}
		if (SpeedBuff == null)
		{
			SpeedBuff = new StatModifier();
			SpeedBuff.statToBoost = (StatType)0;
			SpeedBuff.amount = 2f;
			SpeedBuff.modifyType = (ModifyMethod)0;
		}
		if (DamageBuff == null)
		{
			DamageBuff = new StatModifier();
			DamageBuff.statToBoost = (StatType)5;
			DamageBuff.amount = 1.25f;
			DamageBuff.modifyType = (ModifyMethod)1;
		}
		if (Object.op_Implicit((Object)(object)target))
		{
			GoldenEffectStart(target);
		}
		timer = 60f;
	}

	public void Update()
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Invalid comparison between Unknown and I4
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (timer <= 0f && Object.op_Implicit((Object)(object)target))
		{
			GoldenEffectEnd(target);
		}
		if (ParticleTimer > 0f)
		{
			ParticleTimer -= BraveTime.DeltaTime;
		}
		if (ParticleTimer <= 0f)
		{
			if ((int)GameManager.Options.ShaderQuality != 0 && (int)GameManager.Options.ShaderQuality != 3 && Object.op_Implicit((Object)(object)target) && target.IsVisible && !((GameActor)target).IsFalling)
			{
				GlobalSparksDoer.DoRandomParticleBurst(3, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)target).sprite.WorldBottomLeft, 0f), Vector2Extensions.ToVector3ZisY(((BraveBehaviour)target).sprite.WorldTopRight, 0f), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, (SparksType)9);
			}
			ParticleTimer = 0.1f;
		}
	}

	public void GoldenEffectStart(PlayerController player)
	{
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(fireImmunity);
		player.ownerlessStatModifiers.Add(DamageBuff);
		player.ownerlessStatModifiers.Add(SpeedBuff);
		player.stats.RecalculateStats(player, false, false);
	}

	public void GoldenEffectEnd(PlayerController player)
	{
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(fireImmunity);
		player.ownerlessStatModifiers.Remove(DamageBuff);
		player.ownerlessStatModifiers.Remove(SpeedBuff);
		player.stats.RecalculateStats(player, false, false);
		Object.Destroy((Object)(object)this);
	}
}
