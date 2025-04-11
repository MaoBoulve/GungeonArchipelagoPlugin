using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class PortableHole : PlayerItem
{
	private static Projectile HoleProjectile;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<PortableHole>("Portable Hole", "The Hole Nine Yards", "Not only is this hole portable, it's also bottomless. And depressed. I mean, you would be too if you didn't have a bottom.", "portablehole_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 600f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		HoleProjectile = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)HoleProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)HoleProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)HoleProjectile);
		ProjectileData baseData = HoleProjectile.baseData;
		baseData.damage *= 0f;
		ProjectileData baseData2 = HoleProjectile.baseData;
		baseData2.speed *= 0.5f;
		ProjectileData baseData3 = HoleProjectile.baseData;
		baseData3.range *= 0.5f;
		HoleProjectile.collidesWithEnemies = false;
		HoleProjectile.collidesWithPlayer = false;
		HoleProjectile.collidesWithProjectiles = false;
		HoleProjectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)HoleProjectile).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration += 100;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)HoleProjectile).gameObject);
		orAddComponent2.numberOfBounces += 100;
		ProjectileBuilders.SetProjectileCollisionRight(HoleProjectile, "portablehole_projectile", Initialisation.ProjectileCollection, 17, 17, false, (Anchor)4, (int?)17, (int?)17, true, false, (int?)null, (int?)null, (Projectile)null);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)HoleProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)user).CurrentGun == (Object)null) ? 0f : ((GameActor)user).CurrentGun.CurrentAngle), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)user;
			component.Shooter = ((BraveBehaviour)user).specRigidbody;
			component.OnDestruction += DoHoleSpawn;
		}
	}

	private void DoHoleSpawn(Projectile projectile)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.PitGoop);
		goopManagerForGoopType.TimedAddGoopCircle(((BraveBehaviour)projectile).specRigidbody.UnitCenter, 7f, 0.75f, true);
	}
}
