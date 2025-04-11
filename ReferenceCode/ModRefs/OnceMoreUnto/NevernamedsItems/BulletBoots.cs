using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BulletBoots : PassiveItem
{
	public static Projectile BulletBootsProjectile;

	public static int BulletBootsID;

	private bool onCooldown = false;

	private float cooldownSeconds = 0.25f;

	public static void Init()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BulletBoots>("Bullet Boots", "Run and Gun", "Fires bullets in the direction you're running.\n\nThe best offence is running directly at the enemy completely unguarded.", "bulletboots_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)0, 1f, (ModifyMethod)0);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)1;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 0.5f;
		val2.SetProjectileSprite("bulletboots_projectile", 19, 9, lightened: true, (Anchor)4, 17, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		BulletBootsProjectile = val2;
		BulletBootsID = val.PickupObjectId;
	}

	public override void Update()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null && ((PassiveItem)this).Owner.IsInCombat && ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.Velocity != Vector2.zero && !onCooldown)
		{
			onCooldown = true;
			float num = Vector2Extensions.ToAngle(((PassiveItem)this).Owner.LastCommandedDirection);
			GameObject val = SpawnManager.SpawnProjectile(((Component)BulletBootsProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), Quaternion.Euler(0f, 0f, num), true);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
				component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
				component.TreatedAsNonProjectileForChallenge = true;
				ProjectileData baseData = component.baseData;
				baseData.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
				component.UpdateSpeed();
				((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			}
			((MonoBehaviour)this).Invoke("ResetCooldown", cooldownSeconds);
		}
		((PassiveItem)this).Update();
	}

	private void ResetCooldown()
	{
		onCooldown = false;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((PassiveItem)this).Drop(player);
	}
}
