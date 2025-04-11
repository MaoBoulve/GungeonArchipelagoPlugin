using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class ArtemissileShrine : GenericShrine
{
	public static GameObject Setup(GameObject pedestal)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("shrine_artemissile", Initialisation.NPCCollection.GetSpriteIdByName("shrine_artemissile"), Initialisation.NPCCollection, new GameObject("Shrine Artemissile Statue"));
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		((BraveBehaviour)val.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutout");
		((tk2dBaseSprite)val.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		pedestal.AddComponent<ArtemissileShrine>();
		GameObject val2 = new GameObject("talkpoint");
		val2.transform.SetParent(pedestal.transform);
		val2.transform.localPosition = new Vector3(1f, 2.25f, 0f);
		return val;
	}

	public override bool CanAccept(PlayerController interactor)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (timesAccepted > 0)
		{
			return false;
		}
		if (interactor.characterIdentity == OMITBChars.Shade)
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
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		if (Interactor.ForceZeroHealthState)
		{
			if (Interactor.characterIdentity != OMITBChars.Shade)
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
		StatModifier item2 = new StatModifier
		{
			statToBoost = (StatType)14,
			amount = 2.5f,
			modifyType = (ModifyMethod)0
		};
		Interactor.ownerlessStatModifiers.Add(item2);
		Interactor.stats.RecalculateStats(Interactor, false, false);
		Gun itemOfTypeAndQuality = LootEngine.GetItemOfTypeAndQuality<Gun>(MathsAndLogicHelper.GetRandomQuality(PickupObjectDatabase.Instance, 0.32f, 0.2f, 0.09f, 0.04f), GameManager.Instance.RewardManager.GunsLootTable, false);
		Debug.Log((object)$"Tryget gun for Artemissile, ID: {((PickupObject)itemOfTypeAndQuality).PickupObjectId}");
		Object obj = ResourceCache.Acquire("Global Prefabs/HoveringGun");
		GameObject val = Object.Instantiate<GameObject>((GameObject)(object)((obj is GameObject) ? obj : null), Vector2Extensions.ToVector3ZisY(((GameActor)Interactor).CenterPosition, 0f), Quaternion.identity);
		val.transform.parent = ((BraveBehaviour)Interactor).transform;
		HoveringGunController component = val.GetComponent<HoveringGunController>();
		component.ConsumesTargetGunAmmo = false;
		component.ChanceToConsumeTargetGunAmmo = 0f;
		component.Position = (HoverPosition)1;
		component.Aim = (AimType)1;
		component.Trigger = (FireType)0;
		component.CooldownTime = GetProperShootingSpeed(itemOfTypeAndQuality);
		component.ShootDuration = GetProperShootDuration(itemOfTypeAndQuality);
		component.OnlyOnEmptyReload = false;
		component.Initialize(itemOfTypeAndQuality, Interactor);
		Interactor.stats.RecalculateStats(Interactor, false, false);
		DeregisterMapIcon();
		GameUIRoot.Instance.notificationController.DoCustomNotification("Enchanted Gun", "Blessing Of The Hunt", Initialisation.NPCCollection, Initialisation.NPCCollection.GetSpriteIdByName("artemissile_popup"), (NotificationColor)0, true, false);
		AkSoundEngine.PostEvent("Play_OBJ_shrine_accept_01", ((Component)this).gameObject);
	}

	public override string AcceptText(PlayerController interactor)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (interactor.characterIdentity == OMITBChars.Shade)
		{
			return "Prove your devotion to the hunt <Lose Nothing>";
		}
		if (interactor.ForceZeroHealthState)
		{
			return "Prove your devotion to the hunt <Lose 2 [sprite \"armor_money_icon_001\"]>";
		}
		return "Prove your devotion to the hunt <Lose 1 [sprite \"heart_big_idle_001\"] Container>";
	}

	public override string DeclineText(PlayerController Interactor)
	{
		return "Leave";
	}

	public override string PanelText(PlayerController Interactor)
	{
		return (timesAccepted == 0) ? "A shrine to Artemissile, goddess of the eternal hunt. She grants enchanted arms to her most devout followers." : "The spirits inhabiting this shrine have departed...";
	}

	public static float GetProperShootingSpeed(Gun gun)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		float num = gun.DefaultModule.cooldownTime;
		if ((int)gun.DefaultModule.shootStyle == 3 && gun.DefaultModule.chargeProjectiles != null)
		{
			num += gun.DefaultModule.chargeProjectiles[0].ChargeTime;
		}
		if (gun.DefaultModule.numberOfShotsInClip <= 1)
		{
			num += gun.reloadTime;
		}
		return num;
	}

	public static float GetProperShootDuration(Gun gun)
	{
		float num = 1f;
		if (gun.DefaultModule != null && gun.DefaultModule.projectiles != null && (Object)(object)gun.DefaultModule.projectiles[0] != (Object)null && (Object)(object)((Component)gun.DefaultModule.projectiles[0]).GetComponent<BeamController>() != (Object)null && ((Component)gun.DefaultModule.projectiles[0]).GetComponent<BeamController>().usesChargeDelay)
		{
			num += ((Component)gun.DefaultModule.projectiles[0]).GetComponent<BeamController>().chargeDelay;
		}
		return num;
	}
}
