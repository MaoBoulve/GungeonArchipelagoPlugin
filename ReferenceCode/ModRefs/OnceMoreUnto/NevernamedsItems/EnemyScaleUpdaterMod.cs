using System;
using Alexandria.EnemyAPI;
using UnityEngine;

namespace NevernamedsItems;

public class EnemyScaleUpdaterMod : MonoBehaviour
{
	public Vector2 targetScale;

	public bool multiplyExisting;

	public bool addScaleEffectsToEnemy;

	private Projectile m_projectile;

	public EnemyScaleUpdaterMod()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		targetScale = new Vector2(1f, 1f);
		multiplyExisting = true;
		addScaleEffectsToEnemy = false;
	}

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)m_projectile))
		{
			Projectile projectile = m_projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && !fatal)
		{
			if (addScaleEffectsToEnemy)
			{
				GameObjectExtensions.GetOrAddComponent<SpecialSizeStatModification>(((Component)enemy).gameObject);
			}
			float num = targetScale.x;
			float num2 = targetScale.y;
			if (multiplyExisting)
			{
				num = ((BraveBehaviour)enemy).aiActor.EnemyScale.x * targetScale.x;
				num2 = ((BraveBehaviour)enemy).aiActor.EnemyScale.y * targetScale.y;
			}
			float num3 = 2f;
			float num4 = 0.4f;
			if (((BraveBehaviour)enemy).healthHaver.IsBoss)
			{
				num3 = 1.4f;
				num4 = 0.8f;
			}
			num = Mathf.Min(num, num3);
			num = Mathf.Max(num, num4);
			num2 = Mathf.Min(num2, num3);
			num2 = Mathf.Max(num2, num4);
			int layer = ((Component)enemy).gameObject.layer;
			int num5 = layer;
			((Component)enemy).gameObject.layer = LayerMask.NameToLayer("Unpixelated");
			num5 = SpriteOutlineManager.ChangeOutlineLayer(((BraveBehaviour)enemy).sprite, LayerMask.NameToLayer("Unpixelated"));
			((BraveBehaviour)enemy).aiActor.EnemyScale = new Vector2(num, num2);
			((Component)((BraveBehaviour)enemy).aiActor).gameObject.layer = layer;
			SpriteOutlineManager.ChangeOutlineLayer(((BraveBehaviour)enemy).sprite, num5);
			((BraveBehaviour)((BraveBehaviour)enemy).aiActor).specRigidbody.Reinitialize();
			AIActorUtility.DoCorrectForWalls(((BraveBehaviour)enemy).aiActor);
		}
	}
}
