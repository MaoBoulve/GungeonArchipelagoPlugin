using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BeamProjSpewModifier : MonoBehaviour
{
	public enum SpawnPosition
	{
		BEAM_END,
		BEAM_START,
		ENEMY_IMPACT
	}

	public float chancePerTick;

	public bool tickOnHit = false;

	public float onHitTickcooldown = 0.05f;

	public bool tickOnTimer = false;

	public float tickDelay;

	public Projectile bulletToSpew;

	public float accuracyVariance;

	public float angleFromAim;

	private float timer;

	private float hitTickCool;

	private Projectile projectile;

	private BasicBeamController basicBeamController;

	private BeamController beamController;

	private PlayerController owner;

	public SpawnPosition positionToSpawn;

	public BeamProjSpewModifier()
	{
		chancePerTick = 1f;
		tickDelay = 0.01f;
		angleFromAim = 0f;
		accuracyVariance = 7f;
		positionToSpawn = SpawnPosition.BEAM_END;
		ref Projectile reference = ref bulletToSpew;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		reference = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
	}

	private void Start()
	{
		timer = tickDelay;
		projectile = ((Component)this).GetComponent<Projectile>();
		beamController = ((Component)this).GetComponent<BeamController>();
		basicBeamController = ((Component)this).GetComponent<BasicBeamController>();
		if (projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref owner;
			GameActor obj = projectile.Owner;
			reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
		}
		Projectile obj2 = projectile;
		obj2.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj2.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
	}

	private void OnHit(Projectile proj, SpeculativeRigidbody body, bool fatal)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (tickOnHit && hitTickCool <= 0f)
		{
			hitTickCool = onHitTickcooldown;
			if (Object.op_Implicit((Object)(object)body))
			{
				DoTick(body.UnitCenter, body);
			}
		}
	}

	private void Update()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (hitTickCool > 0f)
		{
			hitTickCool -= BraveTime.DeltaTime;
		}
		if (tickOnTimer)
		{
			if (timer > 0f)
			{
				timer -= BraveTime.DeltaTime;
			}
			if (timer <= 0f)
			{
				DoTick(Vector2.zero, null);
				timer = tickDelay;
			}
		}
	}

	private void DoTick(Vector2 enemyContact, SpeculativeRigidbody aiactor)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value < chancePerTick)
		{
			LinkedList<BeamBone> bones = basicBeamController.m_bones;
			Vector2 pos = Vector2.zero;
			float angle = 0f;
			switch (positionToSpawn)
			{
			case SpawnPosition.BEAM_END:
				pos = basicBeamController.GetBonePosition(bones.Last.Value);
				angle = BeamAPI.GetFinalBoneDirection(basicBeamController);
				break;
			case SpawnPosition.BEAM_START:
				pos = basicBeamController.GetBonePosition(bones.First.Value);
				angle = Vector2Extensions.ToAngle(((BeamController)basicBeamController).Direction);
				break;
			case SpawnPosition.ENEMY_IMPACT:
				pos = enemyContact;
				angle = Vector2Extensions.ToAngle(((BeamController)basicBeamController).Direction);
				break;
			}
			FireProjectile(pos, angle, (positionToSpawn == SpawnPosition.ENEMY_IMPACT && (Object)(object)aiactor != (Object)null) ? aiactor : null);
		}
	}

	private void FireProjectile(Vector2 pos, float angle, SpeculativeRigidbody ToIgnore)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		float num = Random.Range(0f, accuracyVariance);
		if ((double)Random.value <= 0.5)
		{
			num *= -1f;
		}
		float num2 = angle + angleFromAim + num;
		GameObject val = SpawnManager.SpawnProjectile(((Component)bulletToSpew).gameObject, Vector2.op_Implicit(pos), Quaternion.Euler(0f, 0f, num2), true);
		val.AddComponent<BulletIsFromBeam>();
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)ProjectileUtility.ProjectilePlayerOwner(projectile);
			component.Shooter = ((BraveBehaviour)ProjectileUtility.ProjectilePlayerOwner(projectile)).specRigidbody;
			owner.DoPostProcessProjectile(component);
		}
		SpeculativeRigidbody component2 = val.GetComponent<SpeculativeRigidbody>();
		if ((Object)(object)component2 != (Object)null && (Object)(object)ToIgnore != (Object)null)
		{
			component2.RegisterGhostCollisionException(ToIgnore);
		}
	}
}
