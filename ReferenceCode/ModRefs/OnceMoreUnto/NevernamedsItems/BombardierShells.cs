using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class BombardierShells : PassiveItem
{
	public static int BombardierShellsID;

	private static Hook gunFiredHook;

	public static void Init()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		PickupObject val = ItemSetup.NewItem<BombardierShells>("Bombardier Shells", "Heavy Ammunition", "Increases damage and gives a chance for projectiles to be explosive.\n\nThe explosive force necessary to fire these shells creates a lot of recoil.", "bombardiershells_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)5, 2f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)15, 1.3f, (ModifyMethod)1);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
		gunFiredHook = new Hook((MethodBase)typeof(Gun).GetMethod("ShootSingleProjectile", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BombardierShells).GetMethod("GunAttackHook", BindingFlags.Static | BindingFlags.Public));
		BombardierShellsID = val.PickupObjectId;
	}

	public static void GunAttackHook(Action<Gun, ProjectileModule, ProjectileData, GameObject> orig, Gun self, ProjectileModule mod, ProjectileData data = null, GameObject overrideObject = null)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			orig(self, mod, data, overrideObject);
			if (!((Object)(object)self != (Object)null) || mod == null || !Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(self)) || !GunTools.GunPlayerOwner(self).HasPickupID(BombardierShellsID))
			{
				return;
			}
			float num = 40f;
			float num2 = 10f;
			Dictionary<ProjectileModule, ModuleShootData> moduleData = self.m_moduleData;
			if (Object.op_Implicit((Object)(object)overrideObject))
			{
				Projectile component = overrideObject.GetComponent<Projectile>();
				num2 = component.baseData.damage;
			}
			else if ((int)mod.shootStyle == 3 && moduleData != null)
			{
				ChargeProjectile chargeProjectile = mod.GetChargeProjectile(moduleData[mod].chargeTime);
				if (chargeProjectile != null)
				{
					Projectile projectile = chargeProjectile.Projectile;
					num2 = projectile.baseData.damage;
				}
			}
			else
			{
				Projectile currentProjectile = mod.GetCurrentProjectile(moduleData[mod], (GameActor)(object)GunTools.GunPlayerOwner(self));
				num2 = currentProjectile.baseData.damage;
			}
			float num3 = num2 / 10f;
			num *= num3;
			num = Mathf.Min(100f, num);
			if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(self), "Forward Thinking"))
			{
				num *= -0.5f;
			}
			KnockbackDoer knockbackDoer = ((BraveBehaviour)GunTools.GunPlayerOwner(self)).knockbackDoer;
			Vector2 val = ((BraveBehaviour)GunTools.GunPlayerOwner(self)).sprite.WorldCenter - Vector3Extensions.XY(GunTools.GunPlayerOwner(self).unadjustedAimPoint);
			knockbackDoer.ApplyKnockback(((Vector2)(ref val)).normalized, num, false);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		if (Random.value <= 0.07f)
		{
			ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)sourceProjectile).gameObject);
			orAddComponent.doExplosion = true;
			orAddComponent.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
		}
	}

	private void PostProcessBeamTick(BeamController beam)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)(object)((BraveBehaviour)beam).aiShooter == (Object)null)
			{
				float num = 60f;
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Forward Thinking"))
				{
					num *= -0.5f;
				}
				KnockbackDoer knockbackDoer = ((BraveBehaviour)((PassiveItem)this).Owner).knockbackDoer;
				Vector2 val = ((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter - Vector3Extensions.XY(((PassiveItem)this).Owner.unadjustedAimPoint);
				knockbackDoer.ApplyKnockback(((Vector2)(ref val)).normalized, num, false);
			}
			else
			{
				ETGModConsole.Log((object)"Beam AIShooter was not null", false);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeamChanceTick -= PostProcessBeamTick;
		return result;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeamChanceTick += PostProcessBeamTick;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeamChanceTick -= PostProcessBeamTick;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
