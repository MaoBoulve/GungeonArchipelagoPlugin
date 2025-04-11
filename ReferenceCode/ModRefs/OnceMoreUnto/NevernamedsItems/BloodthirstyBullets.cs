using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BloodthirstyBullets : PassiveItem
{
	public static int BloodthirstyBulletsID;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BloodthirstyBullets>("Bloodthirsty Bullets", "Born in the Fray", "Bullets either deal massive bonus damage to enemies, or enjam them.\n\nThese bullets were designed, cast, and shaped in the middle of combat to train them for the battlefield.", "bloodthirstybullets_improved", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_MINES, requiredFlagValue: true);
		BloodthirstyBulletsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		try
		{
			if (AllJammedState.AllJammedActive)
			{
				ProjectileData baseData = sourceProjectile.baseData;
				baseData.damage *= 1.45f;
				return;
			}
			BloodthirstyBulletsComp orAddComponent = GameObjectExtensions.GetOrAddComponent<BloodthirstyBulletsComp>(((Component)sourceProjectile).gameObject);
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(sourceProjectile), "[todo: Add funny synergy name]"))
			{
				orAddComponent.nonJamDamageMult = 30f;
				orAddComponent.jamChance = 0.2f;
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)sourceBeam) && Object.op_Implicit((Object)(object)((BraveBehaviour)sourceBeam).projectile))
		{
			PostProcessProjectile(((BraveBehaviour)sourceBeam).projectile, 1f);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
