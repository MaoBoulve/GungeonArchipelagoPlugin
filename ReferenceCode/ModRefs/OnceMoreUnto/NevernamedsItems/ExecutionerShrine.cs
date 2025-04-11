using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ExecutionerShrine : GenericShrine
{
	public bool hasFailed = false;

	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_execution", Initialisation.NPCCollection.GetSpriteIdByName("shrine_execution"), Initialisation.NPCCollection, new GameObject("Shrine Execution Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<ExecutionerShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		return val;
	}

	public override bool CanAccept(PlayerController interactor)
	{
		return !hasFailed;
	}

	public override void OnAccept(PlayerController Interactor)
	{
		float num = 0.5f;
		if (Interactor.HasPickupID(LuckyCoin.LuckyCoinID))
		{
			num = 0.75f;
		}
		if (Interactor.HasPickupID(289))
		{
			num = 0.9f;
		}
		if (Random.value <= num)
		{
			if (Interactor.ForceZeroHealthState)
			{
				HealthHaver healthHaver = ((BraveBehaviour)Interactor).healthHaver;
				healthHaver.Armor += 4f;
			}
			else
			{
				((BraveBehaviour)Interactor).healthHaver.ApplyHealing(1000f);
			}
			GameUIRoot.Instance.notificationController.DoCustomNotification("Salvation", "Executioner's Wager", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("executioner_icon"), (NotificationColor)0, true, false);
			AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
		}
		else
		{
			hasFailed = true;
			if (Interactor.ForceZeroHealthState)
			{
				((BraveBehaviour)Interactor).healthHaver.Armor = 1f;
			}
			else
			{
				((BraveBehaviour)Interactor).healthHaver.ForceSetCurrentHealth(0.5f);
			}
			GameUIRoot.Instance.notificationController.DoCustomNotification("Damnation", "Executioner's Wager", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("executioner_icon"), (NotificationColor)0, true, false);
			AkSoundEngine.PostEvent("Play_VO_lichA_cackle_01", ((Component)this).gameObject);
		}
	}

	public override string AcceptText(PlayerController interactor)
	{
		return "Conjure The Spirit of Execution";
	}

	public override string DeclineText(PlayerController Interactor)
	{
		return "Leave";
	}

	public override string PanelText(PlayerController Interactor)
	{
		return hasFailed ? "No second chances..." : "A shrine to an over-zealous Executioner, fond of gambling and wagers. Those who conjure his spirit are either saved or damned depending on a roll of the dice.";
	}
}
