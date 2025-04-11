using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class Bombinomicon : PlayerItem
{
	public static int ID;

	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Bombinomicon>("Bombinomicon", "GUTS AN' GLORY, LADS!", "An ancient tome literally full to bursting with explosive knowledge.\n\nPeople who would read this recreationally probably huff gunpowder.", "bombinomicon_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 200f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		int num = 108;
		if (user.HasPickupID(109) || user.HasPickupID(364) || user.HasPickupID(170))
		{
			num = 109;
		}
		if (user.HasPickupID(118))
		{
			RandomBombSpawn(user, num);
		}
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			SpawnObjectPlayerItem component = ((Component)PickupObjectDatabase.GetById(num)).GetComponent<SpawnObjectPlayerItem>();
			GameObject gameObject = component.objectToSpawn.gameObject;
			GameObject val2 = Object.Instantiate<GameObject>(gameObject, Vector2.op_Implicit(((BraveBehaviour)val).sprite.WorldBottomCenter), Quaternion.identity);
			tk2dBaseSprite component2 = val2.GetComponent<tk2dBaseSprite>();
			if (Object.op_Implicit((Object)(object)component2))
			{
				component2.PlaceAtPositionByAnchor(Vector2.op_Implicit(((BraveBehaviour)val).sprite.WorldBottomCenter), (Anchor)4);
			}
			if (user.HasPickupID(19) || user.HasPickupID(332))
			{
				RestoreAmmo(user, activeEnemies.Count);
				SpawnObjectPlayerItem component3 = ((Component)PickupObjectDatabase.GetById(num)).GetComponent<SpawnObjectPlayerItem>();
				GameObject gameObject2 = component3.objectToSpawn.gameObject;
				GameObject val3 = Object.Instantiate<GameObject>(gameObject2, Vector2.op_Implicit(((BraveBehaviour)val).sprite.WorldBottomCenter), Quaternion.identity);
				tk2dBaseSprite component4 = val3.GetComponent<tk2dBaseSprite>();
				if (Object.op_Implicit((Object)(object)component4))
				{
					component4.PlaceAtPositionByAnchor(Vector2.op_Implicit(((BraveBehaviour)val).sprite.WorldBottomCenter), (Anchor)4);
				}
			}
		}
	}

	private void RestoreAmmo(PlayerController user, int amount)
	{
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if (((PickupObject)allGun).PickupObjectId == 19 || ((PickupObject)allGun).PickupObjectId == 332)
			{
				allGun.GainAmmo(amount);
			}
		}
	}

	private void RandomBombSpawn(PlayerController user, int bombToSpawn)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 10; i++)
		{
			IntVector2 randomVisibleClearSpot = user.CurrentRoom.GetRandomVisibleClearSpot(1, 1);
			Vector3 val = ((IntVector2)(ref randomVisibleClearSpot)).ToVector3();
			SpawnObjectPlayerItem component = ((Component)PickupObjectDatabase.GetById(bombToSpawn)).GetComponent<SpawnObjectPlayerItem>();
			GameObject gameObject = component.objectToSpawn.gameObject;
			GameObject val2 = Object.Instantiate<GameObject>(gameObject, val, Quaternion.identity);
			tk2dBaseSprite component2 = val2.GetComponent<tk2dBaseSprite>();
			if (Object.op_Implicit((Object)(object)component2))
			{
				component2.PlaceAtPositionByAnchor(val, (Anchor)4);
			}
			if (user.HasPickupID(19) || user.HasPickupID(332))
			{
				RestoreAmmo(user, 10);
				SpawnObjectPlayerItem component3 = ((Component)PickupObjectDatabase.GetById(bombToSpawn)).GetComponent<SpawnObjectPlayerItem>();
				GameObject gameObject2 = component3.objectToSpawn.gameObject;
				GameObject val3 = Object.Instantiate<GameObject>(gameObject2, val, Quaternion.identity);
				tk2dBaseSprite component4 = val3.GetComponent<tk2dBaseSprite>();
				if (Object.op_Implicit((Object)(object)component4))
				{
					component4.PlaceAtPositionByAnchor(val, (Anchor)4);
				}
			}
		}
	}
}
