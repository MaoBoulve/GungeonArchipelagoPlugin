using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class SpawnGameObjectOnDestructionMod : MonoBehaviour
{
	public float chanceToSpawn;

	public List<GameObject> objectsToPickFrom = new List<GameObject>();

	private Projectile m_projectile;

	public SpawnGameObjectOnDestructionMod()
	{
		chanceToSpawn = 1f;
	}

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile))
		{
			m_projectile.OnDestruction += OnDestroy;
		}
	}

	private void OnDestroy(Projectile self)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value <= chanceToSpawn && objectsToPickFrom.Count > 0)
		{
			GameObject thingToSpawn = BraveUtility.RandomElement<GameObject>(objectsToPickFrom);
			SpawnObjectManager.SpawnObject(thingToSpawn, Vector2.op_Implicit(((BraveBehaviour)m_projectile).specRigidbody.UnitCenter), null, correctForWalls: true);
		}
	}
}
