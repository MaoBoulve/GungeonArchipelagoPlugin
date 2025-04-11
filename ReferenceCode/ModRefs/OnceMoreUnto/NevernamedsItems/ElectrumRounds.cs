using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ElectrumRounds : PassiveItem
{
	public static GameObject linkVFX;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ElectrumRounds>("Electrum Rounds", "Zip Zop Zap", "Fast, penetrative bullets made of gold and silver alloy. Highly conductive, it maintains a powerful electric bond with it's home holster.", "electrumrounds_icon", assetbundle: true);
		val.quality = (ItemQuality)5;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 1.7f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)11, 1f, (ModifyMethod)0);
		linkVFX = FakePrefab.Clone(((Component)PickupObjectDatabase.GetById(298)).GetComponent<ComplexProjectileModifier>().ChainLightningVFX);
		FakePrefab.MarkAsFakePrefab(linkVFX);
		Object.DontDestroyOnLoad((Object)(object)linkVFX);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.ADVDRAGUN_KILLED_ROBOT, requiredFlagValue: true);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		OwnerConnectLightningModifier ownerConnectLightningModifier = ((Component)sourceProjectile).gameObject.AddComponent<OwnerConnectLightningModifier>();
		ownerConnectLightningModifier.linkPrefab = linkVFX;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
