using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ChemicalBurn : PassiveItem
{
	private DamageTypeModifier poisonReduc;

	public static void Init()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ChemicalBurn>("Chemical Burn", "Two-Faced", "Poison immunity. Standing on poison grants massively increased firepower.\n\nSweet, sweet pain.", "chemicalburn_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		((PickupObject)val).quality = (ItemQuality)3;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_OUB, requiredFlagValue: true);
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && (Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGoop != (Object)null && ((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect != null && ((GameActor)((PassiveItem)this).Owner).CurrentGoop.AppliesDamageOverTime && !(((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect is GameActorPlagueEffect))
		{
			ProjectileData baseData = bullet.baseData;
			baseData.damage *= 2f;
			bullet.RuntimeUpdateScale(1.2f);
			_ = ((GameActorEffect)((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect).TintColor;
			if (true)
			{
				bullet.AdjustPlayerProjectileTint(((GameActorEffect)((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect).TintColor, 1, 0f);
			}
			bullet.statusEffectsToApply.Add((GameActorEffect)(object)((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect);
		}
	}

	public void OnBeamTick(BeamController bem, SpeculativeRigidbody enemy, float what)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && (Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGoop != (Object)null && ((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect != null && ((GameActor)((PassiveItem)this).Owner).CurrentGoop.AppliesDamageOverTime && !(((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect is GameActorPlagueEffect) && Object.op_Implicit((Object)(object)((Component)bem).GetComponent<Projectile>()) && Object.op_Implicit((Object)(object)((Component)enemy).GetComponent<GameActor>()))
		{
			((Component)enemy).GetComponent<GameActor>().ApplyEffect((GameActorEffect)(object)((GameActor)((PassiveItem)this).Owner).CurrentGoop.HealthModifierEffect, 1f, (Projectile)null);
		}
	}

	public void BeamCreation(BeamController bem)
	{
	}

	public override void Pickup(PlayerController player)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		player.PostProcessProjectile += onFired;
		player.PostProcessBeamTick += OnBeamTick;
		player.PostProcessBeam += BeamCreation;
		poisonReduc = new DamageTypeModifier();
		poisonReduc.damageMultiplier = 0f;
		poisonReduc.damageType = (CoreDamageTypes)16;
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(poisonReduc);
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessBeamTick -= OnBeamTick;
		player.PostProcessProjectile -= onFired;
		player.PostProcessBeam -= BeamCreation;
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(poisonReduc);
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeamTick -= OnBeamTick;
			((PassiveItem)this).Owner.PostProcessProjectile -= onFired;
			((PassiveItem)this).Owner.PostProcessBeam -= BeamCreation;
		}
		((PassiveItem)this).OnDestroy();
	}
}
