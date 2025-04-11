using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RelodinShrine : GenericShrine
{
	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_relodin", Initialisation.NPCCollection.GetSpriteIdByName("shrine_relodin"), Initialisation.NPCCollection, new GameObject("Shrine Relodin Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<RelodinShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		TextHelper.RegisterCustomTokenInsert("NevernamedsItems/Resources/UISprites/accuracy_ui.png", "accuracy_ui");
		return val;
	}

	public override bool CanAccept(PlayerController interactor)
	{
		return timesAccepted == 0;
	}

	public override void OnAccept(PlayerController Interactor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		StatModifier item = new StatModifier
		{
			statToBoost = (StatType)2,
			amount = 2f,
			modifyType = (ModifyMethod)1
		};
		StatModifier item2 = new StatModifier
		{
			statToBoost = (StatType)5,
			amount = 1.3f,
			modifyType = (ModifyMethod)1
		};
		Interactor.ownerlessStatModifiers.Add(item);
		Interactor.ownerlessStatModifiers.Add(item2);
		Interactor.stats.RecalculateStats(Interactor, false, false);
		GameUIRoot.Instance.notificationController.DoCustomNotification("Blinded", "Wisdom of the Gun", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("relodin_popup"), (NotificationColor)0, true, false);
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
	}

	public override string AcceptText(PlayerController interactor)
	{
		return "Give an eye for knowledge <Accuracy Down [sprite \"accuracy_ui\"]>";
	}

	public override string DeclineText(PlayerController Interactor)
	{
		return "Leave";
	}

	public override string PanelText(PlayerController Interactor)
	{
		return (timesAccepted == 0) ? "A shrine to the lord of chambered rounds Relodin. According to legend, he plucked out his eye as a tribute to Kaliber, and in return recieved great wisdom." : "The spirits inhabiting this shrine have departed...";
	}
}
