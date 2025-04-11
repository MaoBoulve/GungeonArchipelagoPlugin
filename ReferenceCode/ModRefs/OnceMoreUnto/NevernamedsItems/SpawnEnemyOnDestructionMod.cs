using System.Collections.Generic;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SpawnEnemyOnDestructionMod : MonoBehaviour
{
	public List<string> EnemiesToSpawn = new List<string>();

	public bool pickRandom;

	public bool companionise;

	private Projectile m_projectile;

	public SpawnEnemyOnDestructionMod()
	{
		pickRandom = true;
		companionise = true;
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
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		string text = BraveUtility.RandomElement<string>(EnemiesToSpawn);
		PlayerController owner = ProjectileUtility.ProjectilePlayerOwner(m_projectile);
		AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(text);
		CompanionisedEnemyUtility.SpawnCompanionisedEnemy(owner, text, Vector2Extensions.ToIntVector2(((BraveBehaviour)m_projectile).specRigidbody.UnitCenter, (VectorConversions)2), doTint: false, Color.red, 5, 2, shouldBeJammed: false, doFriendlyOverhead: true);
	}
}
