using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class AppleActive : PlayerItem
{
	private static int NormalSpriteID;

	private static int GoldenSpriteID;

	public static int AppleID;

	private bool WasGoldenLastChecked = false;

	public static void Init()
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<AppleActive>("Apple", "Doesn't Fall Far", "Heals a small amount. Can only be eaten once.\n\nAn apple from Kaliber's garden.", "apple_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		NormalSpriteID = ((BraveBehaviour)val).sprite.spriteId;
		GoldenSpriteID = Initialisation.itemCollection.GetSpriteIdByName("goldenapple_icon");
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 0f);
		((PickupObject)val).CustomCost = 10;
		((PickupObject)val).UsesCustomCost = true;
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)1;
		AppleID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.LastOwner))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(base.LastOwner, "Golden Apple") && !WasGoldenLastChecked)
			{
				((BraveBehaviour)this).sprite.SetSprite(GoldenSpriteID);
				WasGoldenLastChecked = true;
			}
			else if (!CustomSynergies.PlayerHasActiveSynergy(base.LastOwner, "Golden Apple") && WasGoldenLastChecked)
			{
				((BraveBehaviour)this).sprite.SetSprite(NormalSpriteID);
				WasGoldenLastChecked = false;
			}
		}
		((PlayerItem)this).Update();
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_OBJ_heart_heal_01", ((Component)user).gameObject);
		((GameActor)user).PlayEffectOnActor(((Component)PickupObjectDatabase.GetById(73)).GetComponent<HealthPickup>().healVFX, Vector3.zero, true, false, false);
		if (user.ForceZeroHealthState)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Apple A Day"))
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
			}
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Golden Apple"))
			{
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
				LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
			}
		}
		else if (CustomSynergies.PlayerHasActiveSynergy(user, "Golden Apple"))
		{
			((BraveBehaviour)user).healthHaver.ApplyHealing(1E+14f);
		}
		else if (CustomSynergies.PlayerHasActiveSynergy(user, "Apple A Day"))
		{
			((BraveBehaviour)user).healthHaver.ApplyHealing(3f);
		}
		else
		{
			((BraveBehaviour)user).healthHaver.ApplyHealing(1.5f);
		}
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Golden Apple"))
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(GoldenAppleCore.GoldenAppleCoreID)).gameObject, user);
			GoldenAppleEffectHandler goldenAppleEffectHandler = ((Component)ETGModMainBehaviour.Instance).gameObject.AddComponent<GoldenAppleEffectHandler>();
			goldenAppleEffectHandler.timer = 60f;
			goldenAppleEffectHandler.target = user;
		}
		else
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(AppleCore.AppleCoreID)).gameObject, user);
		}
		foreach (PassiveItem passiveItem in user.passiveItems)
		{
			if (((PickupObject)passiveItem).PickupObjectId != AppleCore.AppleCoreID && ((PickupObject)passiveItem).PickupObjectId != GoldenAppleCore.GoldenAppleCoreID)
			{
				continue;
			}
			AppleCore component = ((Component)passiveItem).GetComponent<AppleCore>();
			GoldenAppleCore component2 = ((Component)passiveItem).GetComponent<GoldenAppleCore>();
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Newton"))
			{
				if ((Object)(object)component != (Object)null)
				{
					component.givesFlight = true;
				}
				if ((Object)(object)component2 != (Object)null)
				{
					component2.givesFlight = true;
				}
			}
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
