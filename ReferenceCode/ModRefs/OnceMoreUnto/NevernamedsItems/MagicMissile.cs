using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class MagicMissile : PlayerItem
{
	public static int ID;

	public bool isGivingDarknessImmunity = false;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<MagicMissile>("Magic Missile", "Dank Dungeon Walls", "An ancient art, kept sacred by a sect of Gunjurers deep within the Hollow's caverns.\n\nImbued with physical form in an attempt to preserve it for future generations.\n\nWorks best in the dark.", "magicmissile_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 540f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)2;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_MAGICMISSILE, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(20, null);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		((PlayerItem)this).Pickup(player);
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
		if (!isGivingDarknessImmunity)
		{
			CustomDarknessHandler.shouldBeLightOverride.SetOverride("MagicMissile", true, (float?)null);
			isGivingDarknessImmunity = true;
		}
	}

	private void OnEnteredCombat()
	{
		if ((Object)(object)base.LastOwner != (Object)null && base.LastOwner.CurrentRoom != null && base.LastOwner.CurrentRoom.IsDarkAndTerrifying)
		{
			base.LastOwner.CurrentRoom.EndTerrifyingDarkRoom(1f, 0.1f, 1f, "Play_ENM_lighten_world_01");
		}
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.LastOwner))
		{
			PlayerController lastOwner = base.LastOwner;
			lastOwner.OnEnteredCombat = (Action)Delegate.Combine(lastOwner.OnEnteredCombat, new Action(OnEnteredCombat));
		}
		if (isGivingDarknessImmunity)
		{
			CustomDarknessHandler.shouldBeLightOverride.RemoveOverride("MagicMissile");
			isGivingDarknessImmunity = false;
		}
		((PlayerItem)this).OnDestroy();
	}

	public override void OnPreDrop(PlayerController user)
	{
		((PlayerItem)this).OnPreDrop(user);
		user.OnEnteredCombat = (Action)Delegate.Remove(user.OnEnteredCombat, new Action(OnEnteredCombat));
		if (isGivingDarknessImmunity)
		{
			CustomDarknessHandler.shouldBeLightOverride.RemoveOverride("MagicMissile");
			isGivingDarknessImmunity = false;
		}
	}

	public override void DoEffect(PlayerController user)
	{
		SpawnMissile();
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Magic-er Missile"))
		{
			((MonoBehaviour)this).Invoke("SpawnMissile", 1f);
		}
	}

	private void SpawnMissile()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		PlayerController lastOwner = base.LastOwner;
		Projectile val = ((Gun)Databases.Items[372]).DefaultModule.projectiles[0];
		GameObject val2 = SpawnManager.SpawnProjectile(((Component)val).gameObject, Vector2.op_Implicit(((BraveBehaviour)lastOwner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)lastOwner).CurrentGun == (Object)null) ? 0f : ((GameActor)lastOwner).CurrentGun.CurrentAngle), true);
		Projectile component = val2.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)lastOwner;
			component.Shooter = ((BraveBehaviour)lastOwner).specRigidbody;
			ProjectileData baseData = component.baseData;
			baseData.damage *= 2f;
			component.AdjustPlayerProjectileTint(ExtendedColours.lime, 1, 0f);
			lastOwner.DoPostProcessProjectile(component);
		}
	}
}
