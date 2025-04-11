using UnityEngine;

namespace NevernamedsItems;

public class SpawnObjectBehaviour : MonoBehaviour
{
	public GameObject objectToSpawn;

	public float tossForce;

	public bool canBounce;

	private Projectile self;

	private SpeculativeRigidbody specBody;

	public SpawnObjectBehaviour()
	{
		canBounce = true;
		tossForce = 5f;
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self) && Object.op_Implicit((Object)(object)((BraveBehaviour)self).specRigidbody))
		{
			specBody = ((BraveBehaviour)self).specRigidbody;
		}
		self.OnDestruction += OnDestroyed;
	}

	private void OnDestroyed(Projectile victim)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Vector2 unitCenter = ((BraveBehaviour)victim).specRigidbody.UnitCenter;
		GameObject val = Object.Instantiate<GameObject>(objectToSpawn, Vector2.op_Implicit(unitCenter), Quaternion.identity);
		tk2dBaseSprite component = val.GetComponent<tk2dBaseSprite>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.PlaceAtPositionByAnchor(Vector2.op_Implicit(unitCenter), (Anchor)4);
		}
		DebrisObject val2 = LootEngine.DropItemWithoutInstantiating(val, val.transform.position, Random.insideUnitCircle, tossForce, false, false, true, false);
		val2.IsAccurateDebris = true;
		((EphemeralObject)val2).Priority = (EphemeralPriority)0;
		val2.bounceCount = (canBounce ? 1 : 0);
	}
}
