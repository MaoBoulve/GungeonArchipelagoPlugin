using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FuckingExplodeYouCunt : MonoBehaviour
{
	public bool spawnedBySynergy = false;

	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.OnDestruction += Destruction;
	}

	private void Destruction(Projectile projectile)
	{
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)ProjectileUtility.ProjectilePlayerOwner(m_projectile) != (Object)null && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(m_projectile), "Bazooka Joe") && !spawnedBySynergy)
		{
			GameObject val = SpawnManager.SpawnVFX(ChewingGun.popVFX, projectile.LastPosition, Quaternion.identity);
			AkSoundEngine.PostEvent("Play_MouthPopSound", ((Component)this).gameObject);
			List<AIActor> activeEnemies = ProjectileUtility.GetAbsoluteRoom(m_projectile).GetActiveEnemies((ActiveEnemyType)0);
			if (activeEnemies != null)
			{
				for (int i = 0; i < activeEnemies.Count; i++)
				{
					AIActor val2 = activeEnemies[i];
					if (!val2.IsNormalEnemy)
					{
						continue;
					}
					float num = Vector2.Distance(Vector2.op_Implicit(projectile.LastPosition), ((GameActor)val2).CenterPosition);
					if (num <= 7f && Object.op_Implicit((Object)(object)((BraveBehaviour)val2).healthHaver) && ((BraveBehaviour)val2).healthHaver.IsAlive)
					{
						if (Object.op_Implicit((Object)(object)((BraveBehaviour)val2).behaviorSpeculator))
						{
							((BraveBehaviour)val2).behaviorSpeculator.Stun(1f, true);
						}
						GameObject val3 = SpawnManager.SpawnVFX(ChewingGun.gummedVFX, true);
						tk2dBaseSprite component = val3.GetComponent<tk2dBaseSprite>();
						val3.transform.position = Vector2.op_Implicit(new Vector2(((BraveBehaviour)val2).sprite.WorldBottomCenter.x + 0.5f, ((BraveBehaviour)val2).sprite.WorldBottomCenter.y));
						val3.transform.parent = ((BraveBehaviour)val2).transform;
						component.HeightOffGround = 0.2f;
						((BraveBehaviour)val2).sprite.AttachRenderer(component);
						GumPile component2 = val3.GetComponent<GumPile>();
						if (Object.op_Implicit((Object)(object)component2))
						{
							component2.lifetime = 7f;
							component2.target = ((BraveBehaviour)val2).specRigidbody;
						}
					}
				}
			}
		}
		Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)projectile).specRigidbody.UnitTopCenter), default(Vector2), (Action)null, false, (CoreDamageTypes)0, true);
	}
}
