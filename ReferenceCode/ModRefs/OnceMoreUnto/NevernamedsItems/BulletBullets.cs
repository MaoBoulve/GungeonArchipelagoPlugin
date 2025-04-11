using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BulletBullets : IntersectEnemyBulletsItem
{
	private Projectile lastProjectile = null;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BulletBullets>("Bullet Bullets", "Score!", "When your bullets pass through enemy bullets, a single bullet will be reloaded into your clip.\n\nStrategic aiming can allow a gungeoneer to avoid the irritation of reloading.", "bulletbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void DoIntersectionEffect(Projectile playerBullet, Projectile enemyBullet)
	{
		if ((Object)(object)enemyBullet != (Object)(object)lastProjectile)
		{
			((GameActor)((PassiveItem)this).Owner).CurrentGun.MoveBulletsIntoClip(1);
			lastProjectile = enemyBullet;
		}
		else if (((PassiveItem)this).Owner.HasPickupID(375))
		{
			((GameActor)((PassiveItem)this).Owner).CurrentGun.MoveBulletsIntoClip(1);
			lastProjectile = enemyBullet;
		}
		base.DoIntersectionEffect(playerBullet, enemyBullet);
	}
}
