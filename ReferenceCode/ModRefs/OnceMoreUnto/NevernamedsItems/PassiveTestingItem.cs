using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class PassiveTestingItem : PassiveItem
{
	public static int DebugPassiveID;

	private int numfired = 0;

	public static void Init()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		PassiveTestingItem passiveTestingItem = ItemSetup.NewItem<PassiveTestingItem>("PassiveTestingItem", "Work In Progress", "Did you seriously give yourself a testing item just to read the flavour text?", "workinprogress_icon", assetbundle: true) as PassiveTestingItem;
		((PickupObject)passiveTestingItem).quality = (ItemQuality)(-100);
		((BraveBehaviour)passiveTestingItem).sprite.IsPerpendicular = true;
		((PickupObject)passiveTestingItem).CanBeDropped = true;
		((PickupObject)passiveTestingItem).CanBeSold = true;
		DebugPassiveID = ((PickupObject)passiveTestingItem).PickupObjectId;
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		numfired++;
		ETGModConsole.Log((object)("Fired bullet; " + numfired), false);
	}

	public void OnPreTileCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, Tile tile, PixelCollider tilePixelCollider)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		RoomHandler absoluteRoom = ProjectileUtility.GetAbsoluteRoom(((BraveBehaviour)myRigidbody).projectile);
		IntVector2 position = tile.Position;
		CellData val = GameManager.Instance.Dungeon.data[position];
		if (val != null)
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

	public override void Pickup(PlayerController player)
	{
		ETGModConsole.Log((object)"-------------------------------", false);
		numfired = 0;
		player.PostProcessProjectile += onFired;
		((PassiveItem)this).Pickup(player);
	}

	public override void Update()
	{
		((PassiveItem)this).Update();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= onFired;
		return ((PassiveItem)this).Drop(player);
	}
}
