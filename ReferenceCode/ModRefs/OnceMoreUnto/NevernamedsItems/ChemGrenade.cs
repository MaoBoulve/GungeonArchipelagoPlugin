using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class ChemGrenade : PassiveItem
{
	public static int ChemGrenadeID;

	private DamageTypeModifier m_poisonImmunity;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ChemGrenade>("Chem Grenade", "Toxic Explosions", "Explosions leave pools of poison. Gives poison immunity. \n\nThis probably breaks the Guneva Conventions, but this is the Gungeon, who's gonna stop you?", "chemgrenade_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		ChemGrenadeID = ((PickupObject)val).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (m_poisonImmunity == null)
		{
			m_poisonImmunity = new DamageTypeModifier();
			m_poisonImmunity.damageMultiplier = 0f;
			m_poisonImmunity.damageType = (CoreDamageTypes)16;
		}
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(m_poisonImmunity);
		CustomActions.OnExplosionComplex = (Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>)(object)Delegate.Combine((Delegate)(object)CustomActions.OnExplosionComplex, (Delegate)(object)new Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>(Explosion));
		((PassiveItem)this).Pickup(player);
	}

	public void Explosion(Vector3 position, ExplosionData data, Vector2 dir, Action onbegin, bool ignoreQueues, CoreDamageTypes damagetypes, bool ignoreDamageCaps)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		float num = 5f;
		if (GameManagerUtility.AnyPlayerHasActiveSynergy(GameManager.Instance, "Toxic Shock"))
		{
			num = 8f;
		}
		DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(EasyGoopDefinitions.PoisonDef).TimedAddGoopCircle(Vector2.op_Implicit(position), num, 1f, false);
	}

	public override void DisableEffect(PlayerController player)
	{
		CustomActions.OnExplosionComplex = (Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>)(object)Delegate.Remove((Delegate)(object)CustomActions.OnExplosionComplex, (Delegate)(object)new Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>(Explosion));
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(m_poisonImmunity);
		((PassiveItem)this).DisableEffect(player);
	}
}
