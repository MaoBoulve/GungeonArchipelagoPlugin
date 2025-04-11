using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class PutAGunAgainstHisHeadPulledMyTriggerNowHesDeadBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		m_projectile.OnPostUpdate += HandlePostUpdate;
		Projectile projectile = m_projectile;
		projectile.AdditionalScaleMultiplier *= 2f;
		ProjectileData baseData = m_projectile.baseData;
		baseData.damage *= 5f;
		Projectile projectile2 = m_projectile;
		projectile2.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile2.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void HandlePostUpdate(Projectile proj)
	{
		if (Object.op_Implicit((Object)(object)proj) && proj.GetElapsedDistance() > 1f)
		{
			proj.RuntimeUpdateScale(0.5f);
			ProjectileData baseData = proj.baseData;
			baseData.damage /= 5f;
			proj.OnPostUpdate -= HandlePostUpdate;
		}
	}

	private void OnHitEnemy(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && fatal && Object.op_Implicit((Object)(object)proj) && proj.GetElapsedDistance() < 1f && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(proj)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(proj), "Any Way The Wind Blows"))
		{
			for (int i = 0; i < 5; i++)
			{
				PickupObject byId = PickupObjectDatabase.GetById(520);
				GameObject val = ProjectileUtility.InstantiateAndFireInDirection(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0], Vector2.op_Implicit(proj.LastPosition), (float)Random.Range(0, 360), 0f, (PlayerController)null);
				Projectile component = val.GetComponent<Projectile>();
				component.AssignToPlayer(ProjectileUtility.ProjectilePlayerOwner(proj));
				((Component)component).gameObject.AddComponent<PierceDeadActors>();
			}
		}
	}
}
