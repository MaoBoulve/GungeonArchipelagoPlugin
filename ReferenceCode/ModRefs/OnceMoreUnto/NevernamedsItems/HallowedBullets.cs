using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class HallowedBullets : IntersectEnemyBulletsItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<HallowedBullets>("Hallowed Bullets", "Bullet Holeys", "These bullets are so blessed that they will preach to other projectiles mid-air. Usually this does nothing, but it does give Jammed projectiles a chance at redemption.", "hallowedbullets_improved", assetbundle: true);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_KEEP, requiredFlagValue: true);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public void onFiredGun(Projectile bullet, float eventchancescaler)
	{
		bullet.BlackPhantomDamageMultiplier *= 1.1f;
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += onFiredGun;
		base.Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= onFiredGun;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public override void DoIntersectionEffect(Projectile playerBullet, Projectile enemyBullet)
	{
		if (enemyBullet.IsBlackBullet)
		{
			enemyBullet.ReturnFromBlackBullet();
		}
		base.DoIntersectionEffect(playerBullet, enemyBullet);
	}
}
