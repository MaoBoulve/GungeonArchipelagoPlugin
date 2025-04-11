using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class SlotMachineButton : BraveBehaviour, IPlayerInteractable
{
	public SlotMachine master;

	public RoomHandler m_room;

	public int betAlteration = 0;

	private void Start()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		m_room = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(Vector3Extensions.IntXY(((BraveBehaviour)this).transform.position, (VectorConversions)2));
		m_room.RegisterInteractable((IPlayerInteractable)(object)this);
	}

	public float GetDistanceToPoint(Vector2 point)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite))
		{
			return float.MaxValue;
		}
		Bounds bounds = ((BraveBehaviour)this).sprite.GetBounds();
		((Bounds)(ref bounds)).SetMinMax(((Bounds)(ref bounds)).min + ((BraveBehaviour)this).transform.position, ((Bounds)(ref bounds)).max + ((BraveBehaviour)this).transform.position);
		float num = Mathf.Max(Mathf.Min(point.x, ((Bounds)(ref bounds)).max.x), ((Bounds)(ref bounds)).min.x);
		float num2 = Mathf.Max(Mathf.Min(point.y, ((Bounds)(ref bounds)).max.y), ((Bounds)(ref bounds)).min.y);
		return Mathf.Sqrt((point.x - num) * (point.x - num) + (point.y - num2) * (point.y - num2));
	}

	public void OnEnteredRange(PlayerController interactor)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.white);
		((BraveBehaviour)this).sprite.UpdateZDepth();
	}

	public void OnExitRange(PlayerController interactor)
	{
		SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)this).sprite, true);
		((BraveBehaviour)this).sprite.UpdateZDepth();
	}

	public void Interact(PlayerController interactor)
	{
		if (Object.op_Implicit((Object)(object)master) && !master.busy)
		{
			master.DoodadTriggered(betAlteration, lever: false, interactor);
		}
	}

	public string GetAnimationState(PlayerController interactor, out bool shouldBeFlipped)
	{
		shouldBeFlipped = false;
		return string.Empty;
	}

	public float GetOverrideMaxDistance()
	{
		return 1.5f;
	}

	public override void OnDestroy()
	{
		((BraveBehaviour)this).OnDestroy();
	}
}
