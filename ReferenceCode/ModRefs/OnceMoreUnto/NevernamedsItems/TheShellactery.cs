using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class TheShellactery : PlayerItem
{
	public static void Init()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TheShellactery>("The Shellactery", "Firearm Immortality", "Generates ammunition.\n\nThis ancient relic allows you to reach right through the Curtain and pluck ammo directly from the great beyond.\n\nTorn from the gut of an ancient Gungeoneer who was ripped back from the jaws of death, despite his best attempts...", "theshellactery_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 1600f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2f, (ModifyMethod)0);
		val.consumable = false;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		((PickupObject)val).quality = (ItemQuality)5;
		List<string> list = new List<string> { "nn:the_shellactery", "black_hole_gun" };
		CustomSynergies.Add("Black Paradox", list, (List<string>)null, true);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
		if (user.HasPickupID(169))
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(600)).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(600)).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
		}
		else
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(78)).gameObject, Vector2.op_Implicit(((BraveBehaviour)base.LastOwner).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
		}
	}
}
