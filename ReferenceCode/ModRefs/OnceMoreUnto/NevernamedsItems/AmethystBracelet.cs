using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class AmethystBracelet : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<AmethystBracelet>("Amethyst Bracelet", "Thrown Guns Hunt", "This shimmering brace was once clasped around the wrist of Artemissile, goddess of the hunt.\n\nIt imbues thrown weaponry with that same hunter instinct.", "amethystbracelet_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)20, 1.5f, (ModifyMethod)1);
		val.quality = (ItemQuality)1;
		ID = val.PickupObjectId;
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
		thrownGunProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(thrownGunProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		((Component)thrownGunProjectile).gameObject.AddComponent<PierceProjModifier>();
		((Component)thrownGunProjectile).gameObject.AddComponent<PierceDeadActors>();
		HomingModifier val = ((Component)thrownGunProjectile).gameObject.AddComponent<HomingModifier>();
		val.HomingRadius = 100f;
		val.AngularVelocity = 2000f;
		thrownGunProjectile.pierceMinorBreakables = true;
		thrownGunProjectile.IgnoreTileCollisionsFor(0.01f);
		thrownGunProjectile.OnBecameDebrisGrounded = (Action<DebrisObject>)Delegate.Combine(thrownGunProjectile.OnBecameDebrisGrounded, new Action<DebrisObject>(HandleReturnLikeBoomerang));
	}

	private void OnHitEnemy(Projectile projectile, SpeculativeRigidbody arg2, bool fatal)
	{
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		if (!fatal || !Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || !CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Artemisfire"))
		{
			return;
		}
		Gun componentInChildren = ((Component)projectile).GetComponentInChildren<Gun>();
		if (!Object.op_Implicit((Object)(object)componentInChildren))
		{
			return;
		}
		Projectile val = null;
		if (componentInChildren.DefaultModule != null)
		{
			if (componentInChildren.DefaultModule.projectiles.Count > 0 && (Object)(object)componentInChildren.DefaultModule.projectiles[0] != (Object)null)
			{
				val = componentInChildren.DefaultModule.projectiles[0];
			}
			else if (componentInChildren.DefaultModule.chargeProjectiles.Count > 0 && componentInChildren.DefaultModule.chargeProjectiles[0] != null)
			{
				val = componentInChildren.DefaultModule.chargeProjectiles[0].Projectile;
			}
		}
		for (int i = 0; i < 5; i++)
		{
			Projectile val2 = null;
			if (Object.op_Implicit((Object)(object)val))
			{
				if ((Object)(object)((Component)val).GetComponent<BeamController>() != (Object)null)
				{
					BeamController val3 = BeamAPI.FreeFireBeamFromAnywhere(val, ((PassiveItem)this).Owner, (GameObject)null, Vector2.op_Implicit(projectile.LastPosition), Vector2Extensions.ToAngle(Random.insideUnitCircle), Random.Range(1f, 3f), true, false, 0f);
					if (Object.op_Implicit((Object)(object)val3) && Object.op_Implicit((Object)(object)((BraveBehaviour)val3).projectile))
					{
						val2 = ((BraveBehaviour)val3).projectile;
					}
				}
				else
				{
					val2 = ProjectileUtility.InstantiateAndFireInDirection(val, Vector2.op_Implicit(projectile.LastPosition), Vector2Extensions.ToAngle(Random.insideUnitCircle), 0f, (PlayerController)null).GetComponent<Projectile>();
					((PassiveItem)this).Owner.DoPostProcessProjectile(val2);
				}
			}
			if ((Object)(object)val2 != (Object)null)
			{
				ProjectileData baseData = val2.baseData;
				baseData.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = val2.baseData;
				baseData2.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = val2.baseData;
				baseData3.range *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)26);
				ProjectileData baseData4 = val2.baseData;
				baseData4.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessThrownGun += PostProcessThrownGun;
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
