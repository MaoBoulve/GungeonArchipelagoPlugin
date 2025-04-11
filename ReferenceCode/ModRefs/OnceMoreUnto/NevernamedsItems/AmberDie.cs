using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class AmberDie : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<AmberDie>("Amber Die", "Tastes Lucky", "Chance for enemy projectiles to be friendly instead!\n\nThe remains of a leprechaun are immaculately preserved in it's center.", "amberdie_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	private void NewBulletAppeared(Projectile proj)
	{
		if (((Object)(object)proj.Owner == (Object)null || !(proj.Owner is PlayerController)) && Random.value <= 0.1f)
		{
			ConvertBullet(proj);
		}
	}

	private void ConvertBullet(Projectile proj)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		Vector2 direction = proj.Direction;
		if (Object.op_Implicit((Object)(object)proj.Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)proj.Owner).specRigidbody))
		{
			((BraveBehaviour)proj).specRigidbody.DeregisterSpecificCollisionException(((BraveBehaviour)proj.Owner).specRigidbody);
		}
		proj.Owner = (GameActor)(object)((PassiveItem)this).Owner;
		proj.SetNewShooter(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody);
		proj.allowSelfShooting = false;
		proj.collidesWithPlayer = false;
		proj.collidesWithEnemies = true;
		proj.baseData.damage = 15f;
		if (proj.IsBlackBullet)
		{
			ProjectileData baseData = proj.baseData;
			baseData.damage *= 2f;
		}
		PlayerController owner = ((PassiveItem)this).Owner;
		if ((Object)(object)owner != (Object)null)
		{
			ProjectileData baseData2 = proj.baseData;
			baseData2.damage *= owner.stats.GetStatValue((StatType)5);
			ProjectileData baseData3 = proj.baseData;
			baseData3.speed *= owner.stats.GetStatValue((StatType)6);
			proj.UpdateSpeed();
			ProjectileData baseData4 = proj.baseData;
			baseData4.force *= owner.stats.GetStatValue((StatType)12);
			ProjectileData baseData5 = proj.baseData;
			baseData5.range *= owner.stats.GetStatValue((StatType)26);
			proj.BossDamageMultiplier *= owner.stats.GetStatValue((StatType)22);
			proj.RuntimeUpdateScale(owner.stats.GetStatValue((StatType)15));
			if (owner.stats.GetStatValue((StatType)17) > 0f)
			{
				bool flag = Object.op_Implicit((Object)(object)((Component)proj).gameObject.GetComponent<BounceProjModifier>());
				BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)proj).gameObject);
				if (flag)
				{
					orAddComponent.numberOfBounces += (int)owner.stats.GetStatValue((StatType)17);
				}
				else
				{
					orAddComponent.numberOfBounces = (int)owner.stats.GetStatValue((StatType)17);
				}
			}
			owner.DoPostProcessProjectile(proj);
		}
		if ((Object)(object)((Component)proj).GetComponent<BeamController>() != (Object)null)
		{
			((Component)proj).GetComponent<BeamController>().HitsPlayers = false;
			((Component)proj).GetComponent<BeamController>().HitsEnemies = true;
		}
		else if ((Object)(object)((Component)proj).GetComponent<BasicBeamController>() != (Object)null)
		{
			((BeamController)((Component)proj).GetComponent<BasicBeamController>()).HitsPlayers = false;
			((BeamController)((Component)proj).GetComponent<BasicBeamController>()).HitsEnemies = true;
		}
		proj.AdjustPlayerProjectileTint(ExtendedColours.honeyYellow, 1, 0f);
		proj.UpdateCollisionMask();
		ProjectileUtility.RemoveFromPool(proj);
		proj.Reflected();
		proj.SendInDirection(direction, false, true);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		StaticReferenceManager.ProjectileAdded += NewBulletAppeared;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		StaticReferenceManager.ProjectileAdded -= NewBulletAppeared;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			StaticReferenceManager.ProjectileAdded -= NewBulletAppeared;
		}
		((PassiveItem)this).OnDestroy();
	}
}
