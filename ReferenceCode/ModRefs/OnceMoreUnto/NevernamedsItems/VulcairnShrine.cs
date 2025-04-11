using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class VulcairnShrine : GenericShrine
{
	public List<int> ids = new List<int>();

	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_vulcairn", Initialisation.NPCCollection.GetSpriteIdByName("shrine_vulcairn"), Initialisation.NPCCollection, new GameObject("Shrine Vulcairn Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<VulcairnShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		return val;
	}

	public override void OnPlacement()
	{
		ids = AlexandriaTags.GetAllItemsIdsWithTag("guon_stone");
		ids.Remove(565);
		base.OnPlacement();
	}

	public override bool CanAccept(PlayerController interactor)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (timesAccepted > 0)
		{
			return false;
		}
		if (interactor.characterIdentity == OMITBChars.Shade && interactor.carriedConsumables.Currency >= 40)
		{
			return true;
		}
		if (interactor.ForceZeroHealthState && ((BraveBehaviour)interactor).healthHaver.Armor > 2f)
		{
			return true;
		}
		if (((BraveBehaviour)interactor).healthHaver.GetMaxHealth() > 1f)
		{
			return true;
		}
		return false;
	}

	public override void OnAccept(PlayerController Interactor)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (Interactor.ForceZeroHealthState)
		{
			if (Interactor.characterIdentity == OMITBChars.Shade)
			{
				PlayerConsumables carriedConsumables = Interactor.carriedConsumables;
				carriedConsumables.Currency -= 40;
			}
			else
			{
				HealthHaver healthHaver = ((BraveBehaviour)Interactor).healthHaver;
				healthHaver.Armor -= 2f;
			}
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
		List<int> list = new List<int>(ids);
		MathsAndLogicHelper.RemoveInvalidIDListEntries(list, true, true);
		GameUIRoot.Instance.notificationController.DoCustomNotification("Rock and Stone!", "Bounty of the earth", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("vulcairn_icon"), (NotificationColor)0, true, false);
		PickupObject byId = PickupObjectDatabase.GetById(BraveUtility.RandomElement<int>(list));
		Interactor.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		DeregisterMapIcon();
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
	}

	public override string AcceptText(PlayerController interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			return "Rock and Stone! <Lose 40[sprite \"ui_coin\"]>";
		}
		if (interactor.ForceZeroHealthState)
		{
			return "Rock and Stone! <Lose 2 [sprite \"armor_money_icon_001\"]>";
		}
		return "Rock and Stone! <Lose 1 [sprite \"heart_big_idle_001\"] Container>";
	}

	public override string DeclineText(PlayerController Interactor)
	{
		return "Leave";
	}

	public override string PanelText(PlayerController Interactor)
	{
		return (timesAccepted == 0) ? "A shrine to the stoic rock god Vulcairn. His most devout followers are said to recieve gifts of precious stone..." : "The spirits inhabiting this shrine have departed...";
	}
}
