using System;
using UnityEngine;

namespace NevernamedsItems;

public class PandephoniumBounce : MonoBehaviour
{
	private Projectile self;

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)self).gameObject);
		orAddComponent.numberOfBounces += 5;
		orAddComponent.OnBounceContext = (Action<BounceProjModifier, SpeculativeRigidbody>)Delegate.Combine(orAddComponent.OnBounceContext, new Action<BounceProjModifier, SpeculativeRigidbody>(OnBounced));
	}

	private void OnBounced(BounceProjModifier bouncer, SpeculativeRigidbody srb)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)bouncer) && Object.op_Implicit((Object)(object)((BraveBehaviour)bouncer).specRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)bouncer).projectile) && Object.op_Implicit((Object)(object)((BraveBehaviour)bouncer).projectile.Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)((BraveBehaviour)bouncer).projectile.Owner).specRigidbody))
		{
			Vector2 val = ((BraveBehaviour)((BraveBehaviour)bouncer).projectile.Owner).specRigidbody.UnitCenter - ((BraveBehaviour)bouncer).specRigidbody.UnitCenter;
			((BraveBehaviour)bouncer).projectile.SendInDirection(val, false, true);
		}
	}
}
