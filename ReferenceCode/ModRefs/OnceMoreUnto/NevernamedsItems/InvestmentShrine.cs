using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class InvestmentShrine : GenericShrine
{
	public int numUses = 0;

	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_investment", Initialisation.NPCCollection.GetSpriteIdByName("shrine_investment"), Initialisation.NPCCollection, new GameObject("Shrine Investment Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<InvestmentShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		return val;
	}

	public override bool CanAccept(PlayerController interactor)
	{
		return interactor.carriedConsumables.Currency >= 10 * (numUses + 1);
	}

	public override void OnAccept(PlayerController Interactor)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		PlayerConsumables carriedConsumables = Interactor.carriedConsumables;
		carriedConsumables.Currency -= 10 * (numUses + 1);
		StatModifier item = new StatModifier
		{
			statToBoost = (StatType)13,
			amount = 0.9f,
			modifyType = (ModifyMethod)1
		};
		Interactor.ownerlessStatModifiers.Add(item);
		Interactor.stats.RecalculateStats(Interactor, false, false);
		GameUIRoot.Instance.notificationController.DoCustomNotification("Invested!", "Shop Prices Reduced", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("investment_icon"), (NotificationColor)0, true, false);
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
		numUses++;
	}

	public override string AcceptText(PlayerController interactor)
	{
		return $"Invest! <Spend {10 * (numUses + 1)}[sprite \"ui_coin\"]>";
	}

	public override string DeclineText(PlayerController Interactor)
	{
		return "Leave";
	}

	public override string PanelText(PlayerController Interactor)
	{
		return "A shrine to the darkest of demonic hordes- the board of investors.\nGiving up your money seems like a great investment opportunity.";
	}
}
