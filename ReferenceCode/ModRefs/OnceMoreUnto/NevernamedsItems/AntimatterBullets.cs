using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AntimatterBullets : PassiveItem
{
	public static int AntimatterBulletsID;

	public static ExplosionData smallPlayerSafeExplosion = new ExplosionData
	{
		effect = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData.effect,
		ss = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData.ss,
		ignoreList = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData.ignoreList,
		damageRadius = 2.5f,
		damageToPlayer = 0f,
		doDamage = true,
		damage = 25f,
		doDestroyProjectiles = false,
		doForce = true,
		debrisForce = 30f,
		preventPlayerForce = true,
		explosionDelay = 0.1f,
		usesComprehensiveDelay = false,
		doScreenShake = true,
		playDefaultSFX = true
	};

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<AntimatterBullets>("Antimatter Bullets", "Prime Antimaterial", "Your bullets have a chance to create an explosion upon intersecting with enemy bullets.\n\nWhy does't this trigger when you actually hit an enemy?... don't ask questions.", "antimatterbullets_improved", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		AntimatterBulletsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessProjectile(Projectile proj, float flot)
	{
		ExplodeOnBulletIntersection orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplodeOnBulletIntersection>(((Component)proj).gameObject);
		orAddComponent.explosionData = smallPlayerSafeExplosion;
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProjectile;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
