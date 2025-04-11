using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class PanicPendant : PassiveItem
{
	public float timer;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<PanicPendant>("Panic Pendant", "AAAAA", "Makes all enemy bullets friendly for a short time after taking damage.\n\nMade of crystalised adrenaline.", "panicpendant_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
	}

	private void NewBulletAppeared(Projectile proj)
	{
		if (timer > 0f && ((Object)(object)proj.Owner == (Object)null || !(proj.Owner is PlayerController)))
		{
			ConvertBullet(proj);
		}
	}

	public override void Update()
	{
		if (timer >= 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		((PassiveItem)this).Update();
	}

	private void convertAllBullets(PlayerController user)
	{
		timer = 2f;
		if (CustomSynergies.PlayerHasActiveSynergy(user, "Plan B"))
		{
			timer = 6f;
		}
		foreach (Projectile allProjectile in StaticReferenceManager.AllProjectiles)
		{
			if ((Object)(object)allProjectile.Owner == (Object)null || !(allProjectile.Owner is PlayerController))
			{
				ConvertBullet(allProjectile);
			}
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
		player.OnReceivedDamage += convertAllBullets;
		StaticReferenceManager.ProjectileAdded += NewBulletAppeared;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnReceivedDamage -= convertAllBullets;
		StaticReferenceManager.ProjectileAdded -= NewBulletAppeared;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= convertAllBullets;
			StaticReferenceManager.ProjectileAdded -= NewBulletAppeared;
		}
		((PassiveItem)this).OnDestroy();
	}
}
