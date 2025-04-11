using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MysticOil : PassiveItem
{
	public static void Init()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MysticOil>("Sanctified Oil", "Soyled It", "Drastically increases firerate, and removes the need to reload- but greatly stunts damage.\n\nOil supposedly used to shine the glittering barrels and gleaming chambers of Bullet Heaven, though the existence of the place is but a mere rumour.\n\nWorks best on Automatic weapons.", "mysticoil_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 100f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 0.2f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)9, 15f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.01f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)25, 100f, (ModifyMethod)1);
		val.quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop(val, (ShopType)0, 1f);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SANCTIFIEDOIL, requiredFlagValue: true);
		val.AddItemToGooptonMetaShop(27, null);
	}

	public override void Pickup(PlayerController player)
	{
		bool pickedUpThisRun = base.m_pickedUpThisRun;
		player.PostProcessProjectile += PostProcess;
		((PassiveItem)this).Pickup(player);
		if (pickedUpThisRun)
		{
			return;
		}
		for (int i = 0; i < ((PassiveItem)this).Owner.inventory.AllGuns.Count; i++)
		{
			if ((Object)(object)((PassiveItem)this).Owner.inventory.AllGuns[i] != (Object)null && ((PassiveItem)this).Owner.inventory.AllGuns[i].CanGainAmmo)
			{
				((PassiveItem)this).Owner.inventory.AllGuns[i].GainAmmo(((PassiveItem)this).Owner.inventory.AllGuns[i].AdjustedMaxAmmo);
				((PassiveItem)this).Owner.inventory.AllGuns[i].ForceImmediateReload(false);
			}
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcess;
		return ((PassiveItem)this).Drop(player);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun) && ((GameActor)((PassiveItem)this).Owner).CurrentGun.ammo > ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity && ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipShotsRemaining < ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity)
		{
			((GameActor)((PassiveItem)this).Owner).CurrentGun.MoveBulletsIntoClip(((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipCapacity - ((GameActor)((PassiveItem)this).Owner).CurrentGun.ClipShotsRemaining);
		}
		((PassiveItem)this).Update();
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
		}
		((PassiveItem)this).OnDestroy();
	}

	private void PostProcess(Projectile projectile, float effectChanceScalar)
	{
		GameObjectExtensions.GetOrAddComponent<PierceDeadActors>(((Component)projectile).gameObject);
	}
}
