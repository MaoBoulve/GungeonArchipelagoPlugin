using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class LongswordShot : PassiveItem
{
	public static void Init()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<LongswordShot>("Longsword Shot", "Foreign Technology", "Your bullets cut through the air!\n\nPhased into our dimension through a tear in the curtain from a terrible and heretical place known as the 'Swordtress'.", "longswordshot_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public void PostProcess(Projectile bullet, float chanceScaler)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)bullet) || !Object.op_Implicit((Object)(object)bullet.Owner) || !(bullet.Owner is PlayerController))
		{
			return;
		}
		float num = 0.35f;
		num *= chanceScaler;
		if (Random.value <= num)
		{
			SlashData val = new SlashData();
			GameActor owner = bullet.Owner;
			PlayerController val2 = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			ProjectileData baseData = bullet.baseData;
			baseData.speed *= 0.5f;
			bullet.UpdateSpeed();
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)bullet).gameObject);
			orAddComponent.penetratesBreakables = true;
			orAddComponent.penetration += 2;
			ProjectileSlashingBehaviour orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ProjectileSlashingBehaviour>(((Component)bullet).gameObject);
			orAddComponent2.DestroyBaseAfterFirstSlash = false;
			orAddComponent2.timeBetweenSlashes = 0.3f;
			if (CustomSynergies.PlayerHasActiveSynergy(val2, "Sword Mage"))
			{
				orAddComponent2.timeBetweenSlashes = 0.15f;
			}
			orAddComponent2.SlashDamageUsesBaseProjectileDamage = true;
			if (CustomSynergies.PlayerHasActiveSynergy(val2, "Sabre Throw"))
			{
				val.projInteractMode = (ProjInteractMode)2;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val2, "Whirling Blade"))
			{
				orAddComponent2.customSequence = new List<float> { 0f, 90f, 180f, 270f };
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val2, "Live By The Sword"))
			{
				bullet.OnDestruction += OnDestruction;
			}
			val.playerKnockbackForce = 0f;
			orAddComponent2.slashParameters = val;
		}
	}

	private void OnDestruction(Projectile bullet)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody))
		{
			ExplosionData val = ((Component)Game.Items["katana_bullets"]).GetComponent<ComplexProjectileModifier>().LinearChainExplosionData.CopyExplosionData();
			val.ignoreList.Add(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody);
			Exploder.Explode(Vector2.op_Implicit(((BraveBehaviour)bullet).specRigidbody.UnitCenter), val, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcess;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcess;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
		}
		((PassiveItem)this).OnDestroy();
	}
}
