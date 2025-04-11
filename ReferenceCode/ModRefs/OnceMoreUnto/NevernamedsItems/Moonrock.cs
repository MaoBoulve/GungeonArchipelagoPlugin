using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class Moonrock : PassiveItem
{
	public static Projectile moonrockProjectile;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Moonrock>("Moonrock", "Little Orbiters", "Causes small chunks of space debris to orbit your shots.\n\nRound and round and round and round and round and round and round and round and round and round and round and round and round and round and round and round and round and...", "moonrock_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		moonrockProjectile = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)moonrockProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)moonrockProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)moonrockProjectile);
		moonrockProjectile.baseData.damage = 5f;
		ProjectileData baseData = moonrockProjectile.baseData;
		baseData.speed *= 0.5f;
		GunTools.SetProjectileSpriteRight(moonrockProjectile, "moonrock_proj", 4, 4, false, (Anchor)4, (int?)4, (int?)4, true, false, (int?)null, (int?)null, (Projectile)null);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)((Component)sourceProjectile).GetComponent<MoonrockProjectile>()) || sourceProjectile is InstantDamageOneEnemyProjectile || sourceProjectile is InstantlyDamageAllProjectile || Object.op_Implicit((Object)(object)((Component)sourceProjectile).GetComponent<ArtfulDodgerProjectileController>()))
		{
			return;
		}
		PlayerController val = ProjectileUtility.ProjectilePlayerOwner(sourceProjectile);
		int num = Random.Range(0, 4);
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			GameObject val2 = SpawnManager.SpawnProjectile(((Component)moonrockProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)sourceProjectile).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle), true);
			Projectile component = val2.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)val;
				component.Shooter = ((BraveBehaviour)val).specRigidbody;
				ProjectileData baseData = component.baseData;
				baseData.damage *= val.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= val.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.force *= val.stats.GetStatValue((StatType)12);
				component.UpdateSpeed();
				((BraveBehaviour)component).specRigidbody.CollideWithTileMap = true;
				BulletLifeTimer orAddComponent = GameObjectExtensions.GetOrAddComponent<BulletLifeTimer>(((Component)component).gameObject);
				orAddComponent.secondsTillDeath = 30f;
				OrbitProjectileMotionModule val3 = new OrbitProjectileMotionModule();
				val3.lifespan = 50f;
				val3.MinRadius = 0.5f;
				val3.MaxRadius = 2f;
				val3.usesAlternateOrbitTarget = true;
				val3.OrbitGroup = -5;
				val3.alternateOrbitTarget = ((BraveBehaviour)sourceProjectile).specRigidbody;
				if (component.OverrideMotionModule != null && component.OverrideMotionModule is HelixProjectileMotionModule)
				{
					val3.StackHelix = true;
					ref bool forceInvert = ref val3.ForceInvert;
					ProjectileMotionModule overrideMotionModule = component.OverrideMotionModule;
					forceInvert = ((HelixProjectileMotionModule)((overrideMotionModule is HelixProjectileMotionModule) ? overrideMotionModule : null)).ForceInvert;
				}
				component.OverrideMotionModule = (ProjectileMotionModule)(object)val3;
				GameObjectExtensions.GetOrAddComponent<MoonrockProjectile>(((Component)component).gameObject);
				val.DoPostProcessProjectile(component);
			}
		}
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
