using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class MirrorBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MirrorBullets>("Mirror Bullets", "Upon Further Reflection...", "Scoring a direct hit on enemy bullets sends them right back at their owners.\n\nOf all the greatest horrors, and most abhorrent foes one may face, perhaps the most dangerous is the one that stares back at you from the mirror.", "mirrorbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)5;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 3f, (ModifyMethod)0);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_HOLLOW, requiredFlagValue: true);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		MirrorProjectileModifier mirrorProjectileModifier = ((Component)bullet).gameObject.AddComponent<MirrorProjectileModifier>();
		mirrorProjectileModifier.MirrorRadius = 3f;
	}

	private void onFiredBeam(BeamController sourceBeam)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		sourceBeam.AdjustPlayerBeamTint(Color.white, 1, 0f);
		((Component)sourceBeam).gameObject.AddComponent<EnemyBulletReflectorBeam>();
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += onFired;
		player.PostProcessBeam += onFiredBeam;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= onFired;
		player.PostProcessBeam -= onFiredBeam;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= onFired;
			((PassiveItem)this).Owner.PostProcessBeam -= onFiredBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
