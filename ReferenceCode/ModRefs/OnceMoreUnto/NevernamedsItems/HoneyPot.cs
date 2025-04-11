using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class HoneyPot : PlayerItem
{
	private static Projectile PotProjectile;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<HoneyPot>("Honey Pot", "A Little Something", "A handy, throwable pot of sticky honey.\n\nSome Gundead tell whispers of buzzing coming from the Oubliette...", "honeypot_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 250f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		PotProjectile = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)PotProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)PotProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)PotProjectile);
		ProjectileData baseData = PotProjectile.baseData;
		baseData.damage *= 0f;
		ProjectileData baseData2 = PotProjectile.baseData;
		baseData2.speed *= 0.5f;
		ProjectileData baseData3 = PotProjectile.baseData;
		baseData3.range *= 0.5f;
		PotProjectile.collidesWithEnemies = false;
		PotProjectile.collidesWithPlayer = false;
		PotProjectile.collidesWithProjectiles = false;
		PotProjectile.pierceMinorBreakables = true;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)PotProjectile).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration += 100;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)PotProjectile).gameObject);
		orAddComponent2.numberOfBounces += 100;
		ProjectileBuilders.AnimateProjectileBundle(PotProjectile, "HoneyPotProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "HoneyPotProjectile", new List<IntVector2>
		{
			new IntVector2(19, 16),
			new IntVector2(16, 19),
			new IntVector2(19, 16),
			new IntVector2(16, 19)
		}, MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(14, 14), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)PotProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)user).CurrentGun == (Object)null) ? 0f : ((GameActor)user).CurrentGun.CurrentAngle), true);
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
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		if (projectile.Owner is PlayerController)
		{
			float num = 7f;
			GameActor owner = projectile.Owner;
			if (CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((owner is PlayerController) ? owner : null), "Honey, I'm Home!"))
			{
				num = 10f;
			}
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.HoneyGoop);
			goopManagerForGoopType.TimedAddGoopCircle(((BraveBehaviour)projectile).specRigidbody.UnitCenter, num, 0.75f, true);
		}
	}
}
