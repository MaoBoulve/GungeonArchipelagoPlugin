using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class HeartPadlock : PlayerItem
{
	public static int HeartPadlockID;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<HeartPadlock>("Heart Padlock", "Locked Life", "Spend keys to heal.\n\nLocks such as these are commonly used by powerful Gunjurers to secure their souls to their bodies in case of catastrophic injury.", "heartpadlock_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 2f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)1, 1f);
		HeartPadlockID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_OBJ_goldkey_pickup_01", ((Component)this).gameObject);
		_003F val = user;
		Object obj = ResourceCache.Acquire("Global VFX/vfx_healing_sparkles_001");
		((GameActor)val).PlayEffectOnActor((GameObject)(object)((obj is GameObject) ? obj : null), Vector3.zero, true, false, false);
		if (user.ForceZeroHealthState)
		{
			HealthHaver healthHaver = ((BraveBehaviour)user).healthHaver;
			healthHaver.Armor += (float)((!CustomSynergies.PlayerHasActiveSynergy(user, "All Locked Up")) ? 1 : 2);
		}
		else
		{
			((BraveBehaviour)user).healthHaver.ApplyHealing((float)((!CustomSynergies.PlayerHasActiveSynergy(user, "All Locked Up")) ? 1 : 2));
		}
		PlayerConsumables carriedConsumables = user.carriedConsumables;
		carriedConsumables.KeyBullets -= ((!CustomSynergies.PlayerHasActiveSynergy(user, "Key Death") || !(Random.value < 0.5f)) ? 1 : 0);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if (user.carriedConsumables.KeyBullets >= 1)
		{
			return true;
		}
		return false;
	}
}
