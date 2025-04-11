using System;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class DestroyInternalWallsBehav : MonoBehaviour
{
	public Projectile m_projectile;

	public SpeculativeRigidbody body;

	private void Start()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		m_projectile = ((Component)this).GetComponent<Projectile>();
		body = ((Component)m_projectile).GetComponent<SpeculativeRigidbody>();
		SpeculativeRigidbody obj = body;
		obj.OnPreTileCollision = (OnPreTileCollisionDelegate)Delegate.Combine((Delegate)(object)obj.OnPreTileCollision, (Delegate)new OnPreTileCollisionDelegate(OnPreTileCollision));
	}

	public void OnPreTileCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, Tile tile, PixelCollider tilePixelCollider)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		RoomHandler absoluteRoom = ProjectileUtility.GetAbsoluteRoom(m_projectile);
		IntVector2 position = tile.Position;
		CellData val = GameManager.Instance.Dungeon.data[position];
		if (val != null && val.isRoomInternal)
		{
			val.breakable = true;
			val.occlusionData.overrideOcclusion = true;
			val.occlusionData.cellOcclusionDirty = true;
			tk2dTileMap val2 = GameManager.Instance.Dungeon.DestroyWallAtPosition(position.x, position.y, true);
			absoluteRoom.Cells.Add(val.position);
			absoluteRoom.CellsWithoutExits.Add(val.position);
			absoluteRoom.RawCells.Add(val.position);
			Pixelator.Instance.MarkOcclusionDirty();
			Pixelator.Instance.ProcessOcclusionChange(absoluteRoom.Epicenter, 1f, absoluteRoom, false);
			if (Object.op_Implicit((Object)(object)val2))
			{
				GameManager.Instance.Dungeon.RebuildTilemap(val2);
			}
		}
	}
}
