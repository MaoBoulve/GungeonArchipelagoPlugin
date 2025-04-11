using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TurtleShrine : GenericShrine
{
	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_turtle", Initialisation.NPCCollection.GetSpriteIdByName("shrine_turtle"), Initialisation.NPCCollection, new GameObject("Shrine Turtle Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<TurtleShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		return val;
	}

	public override bool CanAccept(PlayerController interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			if (interactor.carriedConsumables.Currency >= 20)
			{
				return true;
			}
			return false;
		}
		if (interactor.ForceZeroHealthState && ((BraveBehaviour)interactor).healthHaver.Armor > 1f)
		{
			return true;
		}
		if (((BraveBehaviour)interactor).healthHaver.GetCurrentHealth() > 0.5f)
		{
			return true;
		}
		return false;
	}

	public override void OnAccept(PlayerController Interactor)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		GameUIRoot.Instance.notificationController.DoCustomNotification("Turtle Power", "A new friend?", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("turtle_icon"), (NotificationColor)0, true, false);
		float value = Random.value;
		TurtleShrineEffectHandler orAddComponent = GameObjectExtensions.GetOrAddComponent<TurtleShrineEffectHandler>(((Component)Interactor).gameObject);
		if ((int)Interactor.characterIdentity == 2)
		{
			HealthHaver healthHaver = ((BraveBehaviour)Interactor).healthHaver;
			healthHaver.Armor -= 1f;
			if (value <= 0.01f)
			{
				PickupObject byId = PickupObjectDatabase.GetById(301);
				Interactor.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
			else
			{
				orAddComponent.SpawnNewTurtle();
				orAddComponent.SpawnNewTurtle();
				orAddComponent.SpawnNewTurtle();
				orAddComponent.SpawnNewTurtle();
			}
		}
		else
		{
			if (Interactor.characterIdentity == OMITBChars.Shade)
			{
				PlayerConsumables carriedConsumables = Interactor.carriedConsumables;
				carriedConsumables.Currency -= 20;
			}
			else
			{
				((BraveBehaviour)Interactor).healthHaver.ApplyHealing(-0.5f);
			}
			if (value <= 0.005f)
			{
				PickupObject byId2 = PickupObjectDatabase.GetById(301);
				Interactor.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId2 is PassiveItem) ? byId2 : null));
			}
			else
			{
				orAddComponent.SpawnNewTurtle();
				orAddComponent.SpawnNewTurtle();
			}
		}
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
	}

	public override string AcceptText(PlayerController interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			return "Beat your wallet against the statue <Lose 20[sprite \"ui_coin\"]>";
		}
		if (interactor.ForceZeroHealthState)
		{
			return "Beat your head against the statue <Lose 1 [sprite \"armor_money_icon_001\"]>";
		}
		return "Beat your head against the statue <Lose half a heart>";
	}

	public override string DeclineText(PlayerController Interactor)
	{
		return "Leave";
	}

	public override string PanelText(PlayerController Interactor)
	{
		return "A shrine to a bizarre Gungeoneer, whose psychopathy was rewarded by a bloodthirsty reptilian horde.";
	}
}
