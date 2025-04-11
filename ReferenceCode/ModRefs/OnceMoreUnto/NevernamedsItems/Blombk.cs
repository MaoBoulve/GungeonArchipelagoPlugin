using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class Blombk : PassiveItem
{
	public static int BlombkID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Blombk>("Blombk", "Boomer Blanks", "Triggers a small blank whenever an explosion goes off.\n\nA Fuselier egg painted blue.", "blombk_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		BlombkID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		CustomActions.OnExplosionComplex = (Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>)(object)Delegate.Combine((Delegate)(object)CustomActions.OnExplosionComplex, (Delegate)(object)new Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>(Explosion));
		((PassiveItem)this).Pickup(player);
	}

	public void Explosion(Vector3 position, ExplosionData data, Vector2 dir, Action onbegin, bool ignoreQueues, CoreDamageTypes damagetypes, bool ignoreDamageCaps)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			EasyBlankType val = (EasyBlankType)1;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Atomic Blombk") && Random.value < 0.2f)
			{
				val = (EasyBlankType)0;
			}
			PlayerUtility.DoEasyBlank(((PassiveItem)this).Owner, Vector2.op_Implicit(position), val);
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		CustomActions.OnExplosionComplex = (Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>)(object)Delegate.Remove((Delegate)(object)CustomActions.OnExplosionComplex, (Delegate)(object)new Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>(Explosion));
		((PassiveItem)this).DisableEffect(player);
	}
}
