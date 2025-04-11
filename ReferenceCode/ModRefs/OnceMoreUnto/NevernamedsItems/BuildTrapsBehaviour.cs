using System.Collections.Generic;
using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace NevernamedsItems;

public class BuildTrapsBehaviour : MovementBehaviorBase
{
	public bool speedy = false;

	public List<GameObject> traps = new List<GameObject>();

	public float timeBuilding = 0f;

	public Vector2 arbitraryTrapPoint = Vector2.zero;

	public float PathInterval = 0.25f;

	private float m_repathTimer;

	public override void Upkeep()
	{
		((MovementBehaviorBase)this).Upkeep();
		((BehaviorBase)this).DecrementTimer(ref m_repathTimer, false);
	}

	public override BehaviorResult Update()
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
		if ((Object)(object)primaryPlayer == (Object)null || primaryPlayer.CurrentRoom == null || !primaryPlayer.CurrentRoom.IsSealed)
		{
			if (speedy)
			{
				((GameActor)((BehaviorBase)this).m_aiActor).MovementModifiers -= new MovementModifier(CatchUpMovementModifier);
			}
			speedy = false;
			arbitraryTrapPoint = Vector2.zero;
			((BehaviorBase)this).m_aiAnimator.EndAnimationIf("build");
			return (BehaviorResult)0;
		}
		IntVector2 val;
		if (arbitraryTrapPoint == Vector2.zero)
		{
			val = primaryPlayer.CurrentRoom.GetRandomVisibleClearSpot(2, 2) + new IntVector2(1, 1);
			arbitraryTrapPoint = ((IntVector2)(ref val)).ToCenterVector2();
		}
		if (!speedy)
		{
			((GameActor)((BehaviorBase)this).m_aiActor).MovementModifiers += new MovementModifier(CatchUpMovementModifier);
		}
		speedy = true;
		float num = Vector2.Distance(arbitraryTrapPoint, ((GameActor)((BehaviorBase)this).m_aiActor).CenterPosition);
		if (num <= 1.4f)
		{
			((BehaviorBase)this).m_aiActor.ClearPath();
			if (!((BehaviorBase)this).m_aiAnimator.IsPlaying("build"))
			{
				((BehaviorBase)this).m_aiAnimator.PlayUntilCancelled("build", false, (string)null, -1f, false);
			}
			timeBuilding += ((BehaviorBase)this).m_deltaTime;
			if (timeBuilding > 5f)
			{
				timeBuilding = 0f;
				CreateObj();
				val = primaryPlayer.CurrentRoom.GetRandomVisibleClearSpot(2, 2) + new IntVector2(1, 1);
				arbitraryTrapPoint = ((IntVector2)(ref val)).ToCenterVector2();
				((BehaviorBase)this).m_aiAnimator.EndAnimationIf("build");
			}
			return (BehaviorResult)1;
		}
		if (m_repathTimer <= 0f)
		{
			((BehaviorBase)this).m_aiAnimator.EndAnimationIf("build");
			timeBuilding = 0f;
			m_repathTimer = PathInterval;
			((BehaviorBase)this).m_aiActor.PathfindToPosition(arbitraryTrapPoint, (Vector2?)null, true, (CellValidator)null, (ExtraWeightingFunction)null, (CellTypes?)null, false);
		}
		return (BehaviorResult)1;
	}

	private void CatchUpMovementModifier(ref Vector2 voluntaryVel, ref Vector2 involuntaryVel)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		voluntaryVel = ((Vector2)(ref voluntaryVel)).normalized * 7f;
	}

	public void CreateObj()
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		if (traps == null)
		{
			traps = new List<GameObject>();
		}
		if (traps.Count == 0)
		{
			traps.AddRange(new List<GameObject>
			{
				((Component)PickupObjectDatabase.GetById(71)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn.gameObject,
				((Component)PickupObjectDatabase.GetById(66)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn.gameObject,
				((Component)PickupObjectDatabase.GetById(66)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn.gameObject,
				((Component)PickupObjectDatabase.GetById(438)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn.gameObject,
				((Component)EnemyDatabase.GetOrLoadByGuid(((Component)PickupObjectDatabase.GetById(201)).GetComponent<SpawnObjectPlayerItem>().enemyGuidToSpawn)).gameObject,
				TackShooter.TackShooterObject,
				TackShooter.TackShooterObject
			});
		}
		if (arbitraryTrapPoint != Vector2.zero)
		{
			PickupObject byId = PickupObjectDatabase.GetById(37);
			SpawnManager.SpawnVFX(((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX, Vector2.op_Implicit(arbitraryTrapPoint), Quaternion.identity);
			GameObject val = Object.Instantiate<GameObject>(BraveUtility.RandomElement<GameObject>(traps), Vector2.op_Implicit(arbitraryTrapPoint), Quaternion.identity);
			tk2dBaseSprite component = val.GetComponent<tk2dBaseSprite>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.PlaceAtPositionByAnchor(Vector2.op_Implicit(arbitraryTrapPoint), (Anchor)4);
			}
			if (Object.op_Implicit((Object)(object)val.GetComponent<TackShooterBehaviour>()))
			{
				val.GetComponent<TackShooterBehaviour>().owner = ((BehaviorBase)this).m_aiActor.CompanionOwner;
			}
			AkSoundEngine.PostEvent("Play_ITM_Folding_Table_Use_01", val.gameObject);
		}
	}
}
