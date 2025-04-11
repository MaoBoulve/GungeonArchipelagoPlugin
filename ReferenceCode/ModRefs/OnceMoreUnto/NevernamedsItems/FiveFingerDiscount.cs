using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FiveFingerDiscount : PassiveItem
{
	public static GameObject Interactible;

	private RoomHandler lastroom;

	private List<RoomHandler> preprocessedRooms = new List<RoomHandler>();

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		PickupObject obj = ItemSetup.NewItem<FiveFingerDiscount>("Five Finger Discount", "Sleight of Hand", "A cost-saving technique passed down among elite criminal circles for eons...", "fivefingerdiscount_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)3;
		GameObject val2 = ItemBuilder.SpriteFromBundle("fivefingerdiscount_interactible_001", Initialisation.EnvironmentCollection.GetSpriteIdByName("fivefingerdiscount_interactible_001"), Initialisation.EnvironmentCollection, new GameObject("Five Finger Discount Interactible"));
		FakePrefabExtensions.MakeFakePrefab(val2);
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val2);
		orAddComponent.Library = Initialisation.environmentAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.environmentAnimationCollection.GetClipIdByName("fivefingerdiscount_idle");
		orAddComponent.DefaultClipId = Initialisation.environmentAnimationCollection.GetClipIdByName("fivefingerdiscount_idle");
		orAddComponent.playAutomatically = true;
		val2.AddComponent<FiveFingerInteractible>();
		Interactible = val2;
	}

	public override void Update()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null && ((PassiveItem)this).Owner.CurrentRoom != null && ((PassiveItem)this).Owner.CurrentRoom != lastroom)
		{
			foreach (BaseShopController allShop in StaticReferenceManager.AllShops)
			{
				if (Object.op_Implicit((Object)(object)allShop) && allShop.m_room != null && !preprocessedRooms.Contains(allShop.m_room))
				{
					IntVector2 centeredVisibleClearSpot = allShop.m_room.GetCenteredVisibleClearSpot(1, 1);
					Object.Instantiate<GameObject>(Interactible, Vector2.op_Implicit((Vector2)centeredVisibleClearSpot), Quaternion.identity);
					LootEngine.DoDefaultPurplePoof((Vector2)centeredVisibleClearSpot, false);
					preprocessedRooms.Add(allShop.m_room);
				}
			}
			lastroom = ((PassiveItem)this).Owner.CurrentRoom;
		}
		((PassiveItem)this).Update();
	}
}
