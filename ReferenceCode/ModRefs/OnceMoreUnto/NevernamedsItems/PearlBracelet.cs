using System;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PearlBracelet : PassiveItem
{
	public static int PearlBraceletID;

	private GameActorFireEffect fireEffect = ((Component)Game.Items["hot_lead"]).GetComponent<BulletStatusEffectItem>().FireModifierEffect;

	private GameActorCharmEffect charmEffect = ((Component)Game.Items["charming_rounds"]).GetComponent<BulletStatusEffectItem>().CharmModifierEffect;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<PearlBracelet>("Pearl Bracelet", "Thrown Guns Afflict", "Thrown guns afflict a whole host of status effects, and return to their owner.\n\nPearls aren't really proper gemstones, but the people who make these are Wizards, not Geologists.", "pearlbracelet_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		PearlBraceletID = val.PickupObjectId;
	}

	private void HandleReturnLikeBoomerang(DebrisObject obj)
	{
		obj.PreventFallingInPits = true;
		obj.OnGrounded = (Action<DebrisObject>)Delegate.Remove(obj.OnGrounded, new Action<DebrisObject>(HandleReturnLikeBoomerang));
		PickupMover val = ((Component)obj).gameObject.AddComponent<PickupMover>();
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody))
		{
			((BraveBehaviour)val).specRigidbody.CollideWithTileMap = false;
		}
		val.minRadius = 1f;
		val.moveIfRoomUnclear = true;
		val.stopPathingOnContact = false;
	}

	private void PostProcessThrownGun(Projectile thrownGunProjectile)
	{
		thrownGunProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(thrownGunProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(AddSlowEffect));
		thrownGunProjectile.pierceMinorBreakables = true;
		thrownGunProjectile.IgnoreTileCollisionsFor(0.01f);
		thrownGunProjectile.OnBecameDebrisGrounded = (Action<DebrisObject>)Delegate.Combine(thrownGunProjectile.OnBecameDebrisGrounded, new Action<DebrisObject>(HandleReturnLikeBoomerang));
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessThrownGun += PostProcessThrownGun;
	}

	private void AddSlowEffect(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		PickupObject obj = Databases.Items["triple_crossbow"];
		Gun val = (Gun)(object)((obj is Gun) ? obj : null);
		GameActorSpeedEffect speedEffect = val.DefaultModule.projectiles[0].speedEffect;
		((GameActorEffect)speedEffect).duration = 20f;
		((GameActor)((BraveBehaviour)arg2).aiActor).ApplyEffect((GameActorEffect)(object)speedEffect, 1f, (Projectile)null);
		((BraveBehaviour)arg2).gameActor.ApplyEffect((GameActorEffect)(object)fireEffect, 1f, (Projectile)null);
		((BraveBehaviour)arg2).gameActor.ApplyEffect((GameActorEffect)(object)charmEffect, 1f, (Projectile)null);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessThrownGun -= PostProcessThrownGun;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessThrownGun -= PostProcessThrownGun;
		}
		((PassiveItem)this).OnDestroy();
	}
}
