using System;
using UnityEngine;

namespace NevernamedsItems;

public class PlayerResponsibleForDisplacement : MonoBehaviour
{
	private PlayerController m_player;

	private void Start()
	{
		m_player = ((Component)this).GetComponent<PlayerController>();
		PlayerController player = m_player;
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
	}

	private void OnEnteredCombat()
	{
		if (listOfDisplacedEnemies.DisplacedEnemies.Count <= 0)
		{
			return;
		}
		float chanceToSpawn = GetChanceToSpawn();
		if (!(chanceToSpawn > Random.value))
		{
			return;
		}
		DoSpawn();
		if (chanceToSpawn - 1f > Random.value)
		{
			DoSpawn();
			if (chanceToSpawn - 2f > Random.value)
			{
				DoSpawn();
			}
		}
	}

	private float GetChanceToSpawn()
	{
		float num = 0.1f;
		return num * (float)listOfDisplacedEnemies.DisplacedEnemies.Count;
	}

	private void DoSpawn()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		DisplacedEnemy displacedEnemy = BraveUtility.RandomElement<DisplacedEnemy>(listOfDisplacedEnemies.DisplacedEnemies);
		AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(displacedEnemy.GUID);
		IntVector2? val = m_player.CurrentRoom.GetRandomVisibleClearSpot(2, 2);
		AIActor val2 = AIActor.Spawn(((BraveBehaviour)orLoadByGuid).aiActor, val.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(val.Value), true, (AwakenAnimationType)0, true);
		PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)val2).specRigidbody, (int?)null, false);
		if (val2.IsBlackPhantom && !displacedEnemy.ISJAMMED)
		{
			val2.UnbecomeBlackPhantom();
		}
		else if (!val2.IsBlackPhantom && displacedEnemy.ISJAMMED)
		{
			val2.BecomeBlackPhantom();
		}
		((BraveBehaviour)val2).healthHaver.ForceSetCurrentHealth(displacedEnemy.HEALTH);
		listOfDisplacedEnemies.DisplacedEnemies.Remove(displacedEnemy);
		AkSoundEngine.PostEvent("Play_OBJ_chestwarp_use_01", ((Component)this).gameObject);
		PickupObject byId = PickupObjectDatabase.GetById(573);
		GameObject teleportVFX = ((ChestTeleporterItem)((byId is ChestTeleporterItem) ? byId : null)).TeleportVFX;
		SpawnManager.SpawnVFX(teleportVFX, Vector2.op_Implicit(((BraveBehaviour)val2).sprite.WorldCenter), Quaternion.identity, true);
	}
}
