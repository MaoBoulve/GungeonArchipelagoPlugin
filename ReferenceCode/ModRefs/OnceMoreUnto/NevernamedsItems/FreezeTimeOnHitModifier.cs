using UnityEngine;

namespace NevernamedsItems;

public class FreezeTimeOnHitModifier : MonoBehaviour
{
	private Projectile m_projectile;

	public float radius;

	public float timeMultiplier;

	public float lengthOfEffect;

	public FreezeTimeOnHitModifier()
	{
		radius = 4f;
		lengthOfEffect = 7f;
		timeMultiplier = 1E-05f;
	}

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.OnDestruction += Destruction;
	}

	private void Destruction(Projectile self)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		RadialSlowInterface val = new RadialSlowInterface();
		val.DoesSepia = false;
		val.EffectRadius = radius;
		val.RadialSlowHoldTime = lengthOfEffect;
		val.RadialSlowTimeModifier = timeMultiplier;
		val.UpdatesForNewEnemies = true;
		val.DoRadialSlow(((BraveBehaviour)self).specRigidbody.UnitCenter, Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)self).transform.position));
		GameObject val2 = new GameObject();
		val2.transform.position = Vector2.op_Implicit(((BraveBehaviour)self).specRigidbody.UnitCenter);
		MagicCircle magicCircle = val2.AddComponent<MagicCircle>();
		magicCircle.radius = radius;
		magicCircle.autoEnableAutoDisableTimer = lengthOfEffect;
		magicCircle.colour = ExtendedColours.freezeBlue;
	}
}
