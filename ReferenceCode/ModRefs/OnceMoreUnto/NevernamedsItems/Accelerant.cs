using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class Accelerant : PassiveItem
{
	private DamageTypeModifier m_fireMultiplier;

	public static List<int> fireyGuns = new List<int> { 382, 125, 336 };

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Accelerant>("Accelerant", "Burning Sensation", "Triples the damage dealt to enemies by fire.\n\nWatching their skin melt off is actually rather horrifying. Avert your eyes.", "accelerant_improved", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
	}

	public void AIActorMods(AIActor target)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		m_fireMultiplier = new DamageTypeModifier();
		m_fireMultiplier.damageMultiplier = 3f;
		m_fireMultiplier.damageType = (CoreDamageTypes)4;
		((BraveBehaviour)target).healthHaver.damageTypeModifiers.Add(m_fireMultiplier);
	}

	private void OnFires(Projectile bullet, float chanceshit)
	{
		if (fireyGuns.Contains(((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).PickupObjectId))
		{
			ProjectileData baseData = bullet.baseData;
			baseData.damage *= 2f;
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += OnFires;
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= OnFires;
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		return result;
	}

	public override void OnDestroy()
	{
		AIActor.OnPreStart = (Action<AIActor>)Delegate.Remove(AIActor.OnPreStart, new Action<AIActor>(AIActorMods));
		((PassiveItem)this).OnDestroy();
	}
}
