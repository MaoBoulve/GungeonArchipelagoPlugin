using System;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SnailBullets : PassiveItem
{
	public static void Init()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<SnailBullets>("Snail Bullets", "Slow as Slugs", "It looks like a colony of snails has made it’s home in this empty shell to hide from predatory birds. \n\nWhile the shell itself cannot be fired, the slime it oozes from the generations of snails within has interesting properties when paired with other ammunition.", "snailbullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)6, 0.6f, (ModifyMethod)1);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_SNAILBULLETS, requiredFlagValue: true);
		val.AddItemToGooptonMetaShop(30, null);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		float num = 0.8f;
		float num2 = num * effectChanceScalar;
		if (Random.value < num2)
		{
			sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(AddSlowEffect));
		}
	}

	private void AddSlowEffect(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)arg2 != (Object)null && (Object)(object)((BraveBehaviour)arg2).aiActor != (Object)null && (Object)(object)((PassiveItem)this).Owner != (Object)null && (Object)(object)arg2 != (Object)null && ((BraveBehaviour)arg2).healthHaver.IsAlive && ((BraveBehaviour)arg2).aiActor.EnemyGuid != "465da2bb086a4a88a803f79fe3a27677" && ((BraveBehaviour)arg2).aiActor.EnemyGuid != "05b8afe0b6cc4fffa9dc6036fa24c8ec")
		{
			PickupObject obj = Databases.Items["triple_crossbow"];
			Gun val = (Gun)(object)((obj is Gun) ? obj : null);
			GameActorSpeedEffect speedEffect = val.DefaultModule.projectiles[0].speedEffect;
			ApplyDirectStatusEffects.ApplyDirectSlow(((BraveBehaviour)arg2).gameActor, 20f, speedEffect.SpeedMultiplier, Color.white, Color.white, (EffectResistanceType)0, "Snail Bullets", tintsEnemy: false, tintsCorpse: false);
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}
}
