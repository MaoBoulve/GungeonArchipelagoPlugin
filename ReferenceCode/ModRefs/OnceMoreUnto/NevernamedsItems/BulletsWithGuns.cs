using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BulletsWithGuns : PassiveItem
{
	public class BulletFromBulletWithGun : MonoBehaviour
	{
	}

	public static Projectile projectileToSpawn;

	public static Projectile swordProjectile;

	public static void Init()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BulletsWithGuns>("Bullets With Guns", "Bullets From Bullets", "Your bullets move slower, but they take that extra time to aim and shoot more bullets at enemies mid-air!\n\n...this is getting a little ridiculous.", "bulletswithguns_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 0.6f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 0.85f, (ModifyMethod)1);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)Databases.Items[86]).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		((Component)val2).gameObject.AddComponent<BulletFromBulletWithGun>();
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0.8f;
		val2.AdditionalScaleMultiplier *= 0.5f;
		projectileToSpawn = val2;
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)Databases.Items[377]).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		((Component)val3).gameObject.AddComponent<BulletFromBulletWithGun>();
		ProjectileData baseData2 = val3.baseData;
		baseData2.damage *= 0.715f;
		val3.AdditionalScaleMultiplier *= 0.8f;
		swordProjectile = val3;
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcessProj;
		player.PostProcessBeam += PostProcessBeam;
		((PassiveItem)this).Pickup(player);
	}

	private void PostProcessProj(Projectile bullet, float scaler)
	{
		if (!((Object)(object)((Component)bullet).GetComponent<BulletFromBulletWithGun>() == (Object)null))
		{
			return;
		}
		if ((Object)(object)((Component)bullet).GetComponent<SpawnProjModifier>() != (Object)null)
		{
			SpawnProjModifier component = ((Component)bullet).gameObject.GetComponent<SpawnProjModifier>();
			if (component.spawnProjectilesInFlight)
			{
				component.inFlightSpawnCooldown *= 0.5f;
				return;
			}
			component.spawnProjectilesInFlight = true;
			component.inFlightAimAtEnemies = true;
			component.usesComplexSpawnInFlight = true;
			component.inFlightSpawnCooldown = 0.5f;
			component.PostprocessSpawnedProjectiles = true;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Bullets With Knives"))
			{
				component.projectileToSpawnInFlight = swordProjectile;
			}
			else
			{
				component.projectileToSpawnInFlight = projectileToSpawn;
			}
		}
		else
		{
			SpawnProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<SpawnProjModifier>(((Component)bullet).gameObject);
			orAddComponent.spawnProjectilesInFlight = true;
			orAddComponent.inFlightAimAtEnemies = true;
			orAddComponent.inFlightSpawnCooldown = 0.5f;
			orAddComponent.usesComplexSpawnInFlight = true;
			orAddComponent.PostprocessSpawnedProjectiles = true;
			orAddComponent.numToSpawnInFlight = 1;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Bullets With Knives"))
			{
				orAddComponent.projectileToSpawnInFlight = swordProjectile;
			}
			else
			{
				orAddComponent.projectileToSpawnInFlight = projectileToSpawn;
			}
		}
	}

	private void PostProcessBeam(BeamController beam)
	{
		SpawnProjectileAtBeamPoint orAddComponent = GameObjectExtensions.GetOrAddComponent<SpawnProjectileAtBeamPoint>(((Component)beam).gameObject);
		orAddComponent.addFromBulletWithGunComponent = true;
		orAddComponent.doPostProcess = true;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Bullets With Knives"))
		{
			orAddComponent.projectileToFire = swordProjectile;
		}
		else
		{
			orAddComponent.projectileToFire = projectileToSpawn;
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProj;
		player.PostProcessBeam -= PostProcessBeam;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProj;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
