using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GreyGuonStone : AdvancedPlayerOrbitalItem
{
	public static PlayerOrbital upgradeOrbitalPrefab;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GreyGuonStone>("Grey Guon Stone", "Vengeful Rock", "Any creature that harms this stone or its bearer shall be harmed in kind.\n\nBlood unto blood, as it has always been.", "greyguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.OrbitalPrefab = ItemSetup.CreateOrbitalObject("Grey Guon Stone", "greyguon_animated_ingame1", new IntVector2(9, 9), new IntVector2(-4, -5), "greyguon_orbital", 2.5f, 120f, 0, (OrbitalMotionStyle)0).GetComponent<PlayerOrbital>();
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Greyer Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ItemSetup.CreateOrbitalObject("Greyer Guon Stone", "greyguon_synergy", new IntVector2(12, 12), new IntVector2(-6, -6), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0, 10f);
	}

	private void OwnerHitByProjectile(Projectile incomingProjectile, PlayerController arg2)
	{
		if (Object.op_Implicit((Object)(object)incomingProjectile.Owner))
		{
			DealDamageToEnemy(incomingProjectile.Owner, 25f);
		}
	}

	private void DealDamageToEnemy(GameActor target, float damage)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && !((BraveBehaviour)target).healthHaver.IsDead && (Object)(object)((PassiveItem)this).Owner != (Object)null)
		{
			float num = damage * ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Greyer Guon Stone"))
			{
				num *= 2f;
			}
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && ((BraveBehaviour)target).aiActor.IsBlackPhantom)
			{
				num *= 3f;
			}
			((BraveBehaviour)target).healthHaver.ApplyDamage(num, Vector2.zero, "Guon Wrath", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, false);
		}
	}

	public override void OnOrbitalCreated(GameObject orbital)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		SpeculativeRigidbody component = orbital.GetComponent<SpeculativeRigidbody>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)component.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHit));
		}
		((AdvancedPlayerOrbitalItem)this).OnOrbitalCreated(orbital);
	}

	private void OnGuonHit(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		Projectile component = ((Component)other).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && component.Owner is AIActor)
		{
			DealDamageToEnemy(component.Owner, 5f);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Combine(player.OnHitByProjectile, new Action<Projectile, PlayerController>(OwnerHitByProjectile));
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnHitByProjectile = (Action<Projectile, PlayerController>)Delegate.Remove(player.OnHitByProjectile, new Action<Projectile, PlayerController>(OwnerHitByProjectile));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
