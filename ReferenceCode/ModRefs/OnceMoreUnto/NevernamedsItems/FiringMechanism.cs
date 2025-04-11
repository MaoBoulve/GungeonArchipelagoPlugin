using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class FiringMechanism : PlayerItem
{
	public static void Init()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FiringMechanism>("Firing Mechanism", "Spin Stabilized", "The infernal chambers of this strange device violate the laws of conservation of energy; one bullet goes in, three come out.\n\nThe Revolvenants of the fifth chamber and beyond use devices such as these in their dark ammomantic rituals.", "firingmechanism_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 325f);
		FiringMechanismController.Init();
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = PlayerUtility.PositionInDistanceFromAimDir(user, 1f);
		GameObject val2 = Object.Instantiate<GameObject>(FiringMechanismController.MechanismPrefab, Vector2.op_Implicit(val), Quaternion.identity);
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).PlaceAtLocalPositionByAnchor(Vector2.op_Implicit(val), (Anchor)4);
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).UpdateZDepth();
	}
}
