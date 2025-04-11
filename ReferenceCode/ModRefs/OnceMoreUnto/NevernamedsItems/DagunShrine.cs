using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DagunShrine : GenericShrine
{
	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_dagun", Initialisation.NPCCollection.GetSpriteIdByName("shrine_dagun"), Initialisation.NPCCollection, new GameObject("Shrine Dagun Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<DagunShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		return val;
	}

	public override void OnAccept(PlayerController Interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		if (Interactor.characterIdentity == OMITBChars.Shade)
		{
			PlayerConsumables carriedConsumables = Interactor.carriedConsumables;
			carriedConsumables.Currency -= 40;
		}
		else if (Interactor.ForceZeroHealthState)
		{
			HealthHaver healthHaver = ((BraveBehaviour)Interactor).healthHaver;
			healthHaver.Armor -= 2f;
		}
		else
		{
			StatModifier item = new StatModifier
			{
				statToBoost = (StatType)3,
				amount = -1f,
				modifyType = (ModifyMethod)0
			};
			Interactor.ownerlessStatModifiers.Add(item);
			Interactor.stats.RecalculateStats(Interactor, false, false);
		}
		int num = Random.Range(5, 11);
		for (int i = 0; i < num; i++)
		{
			IntVector2 randomVisibleClearSpot = m_room.GetRandomVisibleClearSpot(2, 2);
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(BabyGoodChanceKin.lootIDlist))).gameObject, Vector2.op_Implicit(((IntVector2)(ref randomVisibleClearSpot)).ToVector2()), Vector2.zero, 0f, true, false, false);
		}
		GameUIRoot.Instance.notificationController.DoCustomNotification("Bounty", "Dungeon of Plenty", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("dagun_popup"), (NotificationColor)0, true, false);
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
	}

	public override bool CanAccept(PlayerController interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			return interactor.carriedConsumables.Currency >= 40;
		}
		if (interactor.ForceZeroHealthState)
		{
			return ((BraveBehaviour)interactor).healthHaver.Armor > 2f;
		}
		return ((BraveBehaviour)interactor).healthHaver.GetMaxHealth() > 1f;
	}

	public override string AcceptText(PlayerController interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			return "Pray <Lose 40[sprite \"ui_coin\"]>";
		}
		if (interactor.ForceZeroHealthState)
		{
			return "Pray <Lose 2 [sprite \"armor_money_icon_001\"]>";
		}
		return "Pray <Lose 1 [sprite \"heart_big_idle_001\"] Container>";
	}

	public override string DeclineText(PlayerController Interactor)
	{
		return "Leave";
	}

	public override string PanelText(PlayerController Interactor)
	{
		return "A shrine to Dagun, god of plenty. His amphora of shells running never dry.";
	}
}
