using UnityEngine;

namespace NevernamedsItems;

internal class ShadowRing : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ShadowRing>("Shadow Ring", "Umbral", "Creates a shadow realm duplicate upon damage.\n\nForged of darkness and misery, mined from the shrunken dead heart of an emo teenager.", "shadowring_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		ID = val.PickupObjectId;
	}

	private void charmAll(PlayerController user)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		GameObject objectToSpawn = ((Component)PickupObjectDatabase.GetById(820)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn;
		GameObject val = Object.Instantiate<GameObject>(objectToSpawn, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Quaternion.identity);
		tk2dBaseSprite component = val.GetComponent<tk2dBaseSprite>();
		if ((Object)(object)component != (Object)null)
		{
			component.PlaceAtPositionByAnchor(Vector2Extensions.ToVector3ZUp(((BraveBehaviour)user).specRigidbody.UnitCenter, ((BraveBehaviour)component).transform.position.z), (Anchor)4);
			if ((Object)(object)((BraveBehaviour)component).specRigidbody != (Object)null)
			{
				((BraveBehaviour)component).specRigidbody.RegisterGhostCollisionException(((BraveBehaviour)user).specRigidbody);
			}
		}
		KageBunshinController component2 = val.GetComponent<KageBunshinController>();
		if (Object.op_Implicit((Object)(object)component2))
		{
			component2.InitializeOwner(user);
		}
		val.transform.position = dfVectorExtensions.Quantize(val.transform.position, 0.0625f);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReceivedDamage += charmAll;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= charmAll;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= charmAll;
		}
		((PassiveItem)this).OnDestroy();
	}
}
