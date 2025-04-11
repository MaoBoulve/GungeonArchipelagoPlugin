using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class RingOfInvisibility : PassiveItem
{
	public static int RingOfInvisibilityID;

	private float unstealthyTimer;

	private bool isCurrentlyStealthed;

	public static void Init()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RingOfInvisibility>("Ring of Invisibility", "Precious", "Grants invisibility while standing perfectly still.\n\nThis ancient ring has been coveted throughout generations of Gungeoneers and Gundead alike. The idea of removing it seems unthinkable.", "ringofinvisibility_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		val.CanBeDropped = false;
		val.quality = (ItemQuality)5;
		RingOfInvisibilityID = val.PickupObjectId;
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.CHALLENGE_INVISIBLEO_BEATEN, requiredFlagValue: true);
	}

	public override void Update()
	{
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			if (unstealthyTimer >= 0f)
			{
				unstealthyTimer -= BraveTime.DeltaTime;
			}
			UpdateShouldBeStealthed();
		}
		((PassiveItem)this).Update();
	}

	private void UpdateShouldBeStealthed()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (unstealthyTimer <= 0f && ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.Velocity == Vector2.zero)
		{
			if (!isCurrentlyStealthed)
			{
				StealthEffect();
			}
		}
		else if (isCurrentlyStealthed)
		{
			BreakStealth(((PassiveItem)this).Owner);
		}
	}

	private void StealthEffect()
	{
		PlayerController owner = ((PassiveItem)this).Owner;
		owner.ChangeSpecialShaderFlag(1, 1f);
		((GameActor)owner).SetIsStealthed(true, "invisibilityRing");
		owner.SetCapableOfStealing(true, "invisibilityRing", (float?)null);
		isCurrentlyStealthed = true;
	}

	private void BreakStealth(PlayerController player, bool brokeStealthUnstealthily = false)
	{
		player.ChangeSpecialShaderFlag(1, 0f);
		((GameActor)player).SetIsStealthed(false, "invisibilityRing");
		player.SetCapableOfStealing(false, "invisibilityRing", (float?)null);
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
		isCurrentlyStealthed = false;
		if (brokeStealthUnstealthily)
		{
			unstealthyTimer += 5f;
		}
	}

	private void OnUnstealthy(PlayerController playa)
	{
		if (isCurrentlyStealthed)
		{
			BreakStealth(playa, brokeStealthUnstealthily: true);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnDidUnstealthyAction += OnUnstealthy;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnDidUnstealthyAction -= OnUnstealthy;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnDidUnstealthyAction -= OnUnstealthy;
		}
		((PassiveItem)this).OnDestroy();
	}
}
