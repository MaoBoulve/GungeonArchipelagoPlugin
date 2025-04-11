using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DiamondBracelet : PassiveItem
{
	public static int DiamondBraceletID;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<DiamondBracelet>("Diamond Bracelet", "Slinger's Best Friend", "Thrown guns deal massive damage, and return safely to their owner.\n\nDespite the seeming societal progress marked by the reforging of the Ruby Bracelet, it seems there are still some bumpkins in the Gungeon's depths who insist on chucking their guns.", "diamondbracelet_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)20, 7f, (ModifyMethod)0);
		val.quality = (ItemQuality)1;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.KILLEDENEMYWITHTHROWNGUN, requiredFlagValue: true);
		DiamondBraceletID = val.PickupObjectId;
	}

	private void HandleReturnLikeBoomerang(DebrisObject obj)
	{
		obj.PreventFallingInPits = true;
		obj.OnGrounded = (Action<DebrisObject>)Delegate.Remove(obj.OnGrounded, new Action<DebrisObject>(HandleReturnLikeBoomerang));
		PickupMover orAddComponent = GameObjectExtensions.GetOrAddComponent<PickupMover>(((Component)obj).gameObject);
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent).specRigidbody))
		{
			((BraveBehaviour)orAddComponent).specRigidbody.CollideWithTileMap = false;
		}
		orAddComponent.minRadius = 1f;
		orAddComponent.moveIfRoomUnclear = true;
		orAddComponent.stopPathingOnContact = false;
	}

	private void PostProcessThrownGun(Projectile thrownGunProjectile)
	{
		thrownGunProjectile.pierceMinorBreakables = true;
		thrownGunProjectile.IgnoreTileCollisionsFor(0.01f);
		thrownGunProjectile.OnBecameDebrisGrounded = (Action<DebrisObject>)Delegate.Combine(thrownGunProjectile.OnBecameDebrisGrounded, new Action<DebrisObject>(HandleReturnLikeBoomerang));
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessThrownGun += PostProcessThrownGun;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessThrownGun -= PostProcessThrownGun;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
