using System;
using UnityEngine;

namespace NevernamedsItems;

public class TintingBeamModifier : MonoBehaviour
{
	private Projectile self;

	public Color targetColour;

	public string designatedSource;

	public TintingBeamModifier()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		targetColour = Color.red;
		designatedSource = "unset";
	}

	public void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		Projectile obj = self;
		obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	public void OnHitEnemy(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			((GameActor)((BraveBehaviour)enemy).aiActor).RegisterOverrideColor(targetColour, designatedSource);
		}
	}
}
