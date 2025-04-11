using System.Collections.Generic;
using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class KliklokShrine : GenericShrine
{
	public bool shadeOneOff = false;

	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_kliklok", Initialisation.NPCCollection.GetSpriteIdByName("shrine_kliklok"), Initialisation.NPCCollection, new GameObject("Shrine Kliklok Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<KliklokShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		return val;
	}

	public override bool CanAccept(PlayerController interactor)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (GetAllChests().Count == 0)
		{
			return false;
		}
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			return !shadeOneOff;
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
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected I4, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Invalid comparison between Unknown and I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		if (Interactor.characterIdentity == OMITBChars.Shade)
		{
			shadeOneOff = true;
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
		foreach (Chest allChest in GetAllChests())
		{
			ChestTier val = (ChestTier)11;
			ChestTier chestTier = ChestUtility.GetChestTier(allChest);
			ChestTier val2 = chestTier;
			ChestTier val3 = val2;
			switch ((int)val3)
			{
			case 0:
				val = (ChestTier)1;
				break;
			case 1:
				val = (ChestTier)2;
				break;
			case 2:
				val = ((!(Random.value <= 0.75f)) ? ((ChestTier)8) : ((ChestTier)3));
				break;
			case 3:
				val = (ChestTier)4;
				break;
			case 4:
				if (Random.value <= 0.05f)
				{
					val = (ChestTier)5;
				}
				else
				{
					allChest.ForceUnlock();
				}
				break;
			case 8:
				val = ((!(Random.value <= 0.5f)) ? ((ChestTier)4) : ((ChestTier)3));
				break;
			}
			ThreeStateValue val4 = (ThreeStateValue)2;
			val4 = ((!allChest.IsMimic) ? ((ThreeStateValue)1) : ((ThreeStateValue)0));
			if ((int)val != 11)
			{
				Chest val5 = ChestUtility.SpawnChestEasy(Vector2Extensions.ToIntVector2(((BraveBehaviour)allChest).sprite.WorldBottomLeft, (VectorConversions)2), val, allChest.IsLocked, allChest.ChestType, val4, (ThreeStateValue)1);
				if (Object.op_Implicit((Object)(object)((Component)allChest).GetComponent<JammedChestBehav>()))
				{
					((Component)val5).gameObject.AddComponent<JammedChestBehav>();
				}
				allChest.m_room.DeregisterInteractable((IPlayerInteractable)(object)allChest);
				allChest.DeregisterChestOnMinimap();
				Object.Destroy((Object)(object)((Component)allChest).gameObject);
			}
		}
		GameUIRoot.Instance.notificationController.DoCustomNotification("Kliklok's Blessing", "Chests Upgraded", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("kliklok_icon"), (NotificationColor)0, true, false);
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
	}

	public override string AcceptText(PlayerController interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			return "Pray <Lose Nothing>";
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
		return (!shadeOneOff) ? "A shrine to Kliklok, patron god of chests. Giving a blood sacrifice to his effigy may bolster his disciples." : "The spirits inhabiting this shrine have departed...";
	}

	public static List<Chest> GetAllChests()
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		List<Chest> list = new List<Chest>();
		foreach (Chest allChest in StaticReferenceManager.AllChests)
		{
			if (Object.op_Implicit((Object)(object)allChest) && !allChest.IsBroken && !allChest.IsOpen && !allChest.IsGlitched && !allChest.IsLockBroken)
			{
				List<ChestTier> list2 = new List<ChestTier>
				{
					(ChestTier)11,
					(ChestTier)10,
					(ChestTier)5,
					(ChestTier)7,
					(ChestTier)6,
					(ChestTier)9
				};
				if (!list2.Contains(ChestUtility.GetChestTier(allChest)))
				{
					list.Add(allChest);
				}
			}
		}
		return list;
	}
}
