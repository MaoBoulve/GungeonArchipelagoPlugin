using Alexandria.ItemAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class HematicRounds : PassiveItem
{
	private int timesHit = 0;

	private RoomHandler lastCheckedRoom;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HematicRounds>("Hematic Rounds", "Blood... So Much Blood...", "Increases damage the more times it's bearer takes damage. Resets per room.\n\nThese red blood shells are sloshing with the good stuff.", "hematicrounds_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_HEMATICROUNDS, requiredFlagValue: true);
		val.AddItemToDougMetaShop(50, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProj;
		player.PostProcessBeam += PostBeam;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessBeam -= PostBeam;
		player.PostProcessProjectile -= PostProj;
		return ((PassiveItem)this).Drop(player);
	}

	private void PostProj(Projectile proj, float i)
	{
		ProjectileData baseData = proj.baseData;
		baseData.damage *= 1f + 0.5f * (float)timesHit;
	}

	private void PostBeam(BeamController b)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)b).projectile))
		{
			ProjectileData baseData = ((BraveBehaviour)b).projectile.baseData;
			baseData.damage *= 1f + 0.5f * (float)timesHit;
		}
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.CurrentRoom != null && ((PassiveItem)this).Owner.CurrentRoom != lastCheckedRoom)
		{
			if (!CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Blood Transfusion") || !(Random.value <= 0.5f))
			{
				timesHit = 0;
			}
			lastCheckedRoom = ((PassiveItem)this).Owner.CurrentRoom;
		}
		((PassiveItem)this).Update();
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeam -= PostBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProj;
		}
		((PassiveItem)this).OnDestroy();
	}
}
