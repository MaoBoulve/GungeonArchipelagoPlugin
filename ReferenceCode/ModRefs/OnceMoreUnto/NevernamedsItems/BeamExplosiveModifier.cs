using System;
using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class BeamExplosiveModifier : MonoBehaviour
{
	public bool ignoreQueues;

	public float chancePerTick;

	public float tickDelay;

	public ExplosionData explosionData;

	public bool canHarmOwner;

	private float timer;

	private Projectile projectile;

	private BasicBeamController basicBeamController;

	private BeamController beamController;

	private PlayerController owner;

	public BeamExplosiveModifier()
	{
		canHarmOwner = false;
		explosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
		chancePerTick = 1f;
		tickDelay = 0.1f;
		ignoreQueues = true;
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
	}

	private void Update()
	{
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (timer <= 0f)
		{
			DoTick();
			timer = tickDelay;
		}
	}

	private void DoTick()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value < chancePerTick)
		{
			LinkedList<BeamBone> bones = basicBeamController.m_bones;
			LinkedListNode<BeamBone> last = bones.Last;
			Vector2 bonePosition = basicBeamController.GetBonePosition(last.Value);
			Explode(bonePosition);
		}
	}

	private void Explode(Vector2 pos)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		if (!canHarmOwner && (Object)(object)owner != (Object)null)
		{
			for (int i = 0; i < GameManager.Instance.AllPlayers.Length; i++)
			{
				PlayerController val = GameManager.Instance.AllPlayers[i];
				if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody))
				{
					explosionData.ignoreList.Add(((BraveBehaviour)val).specRigidbody);
				}
			}
		}
		Exploder.Explode(Vector2.op_Implicit(pos), explosionData, Vector2.zero, (Action)null, ignoreQueues, (CoreDamageTypes)0, false);
	}
}
