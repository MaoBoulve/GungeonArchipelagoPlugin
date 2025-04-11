using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class TracerRound : PassiveItem
{
	public static int ID;

	private int currentItems;

	private int lastItems;

	private int currentGuns;

	private int lastGuns;

	private DamageTypeModifier m_fireImmunity;

	public static void Init()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TracerRound>("Tracer Rounds", "Follow The Red Line", "Shots have a chance to leave a trail of fire, marking their exact trajectory.\n\nStandard issue for military training exercises, weapons tests, and really bad assassins.", "tracerrounds_improved", assetbundle: true);
		ItemBuilder.AddToSubShop(val, (ShopType)3, 1f);
		val.quality = (ItemQuality)1;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_TRACERROUNDS, requiredFlagValue: true);
		val.AddItemToTrorcMetaShop(8, null);
		Doug.AddToLootPool(val.PickupObjectId);
		ID = val.PickupObjectId;
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		if (!((PassiveItem)this).Owner.HasPickupID(GracefulGoop.ID) && (Random.value < 0.1f * eventchancescaler || CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Ring of Fire")))
		{
			GoopModifier val = ((Component)bullet).gameObject.AddComponent<GoopModifier>();
			val.InFlightSpawnRadius = (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Even More Visible!") ? 1f : 0.5f);
			val.SpawnGoopInFlight = true;
			val.InFlightSpawnFrequency = 0.01f;
			val.goopDefinition = (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Hot Tempered") ? GoopUtility.GreenFireDef : GoopUtility.FireDef);
			ProjectileData baseData = bullet.baseData;
			baseData.speed *= 1.25f;
			bullet.OnDestruction += OnProjectileDeath;
		}
	}

	private void OnProjectileDeath(Projectile self)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject byId = PickupObjectDatabase.GetById(((Object)(object)((PassiveItem)this).Owner != (Object)null && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Hot Tempered")) ? 722 : 336);
		Object.Instantiate<GameObject>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0].hitEffects.overrideMidairDeathVFX, self.LastPosition, Quaternion.identity);
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(83);
			GameObject val = ProjectileUtility.InstantiateAndFireInDirection(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0], Vector2.op_Implicit(self.LastPosition), (float)Random.Range(0, 360), 0f, (PlayerController)null);
			Projectile component = val.GetComponent<Projectile>();
			component.baseData.damage = 3f;
			component.AssignToPlayer(((PassiveItem)this).Owner);
			ScaleChangeOverTimeModifier scaleChangeOverTimeModifier = val.AddComponent<ScaleChangeOverTimeModifier>();
			scaleChangeOverTimeModifier.destroyAfterChange = true;
			scaleChangeOverTimeModifier.scaleMultAffectsDamage = false;
			scaleChangeOverTimeModifier.ScaleToChangeTo = 0.1f;
			scaleChangeOverTimeModifier.suppressDeathFXIfdestroyed = true;
			scaleChangeOverTimeModifier.timeToChangeOver = 0.165f;
			component.IgnoreTileCollisionsFor(0.1f);
			GoopModifier val2 = val.gameObject.AddComponent<GoopModifier>();
			val2.InFlightSpawnRadius = (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Even More Visible!") ? 1f : 0.5f);
			val2.SpawnGoopInFlight = true;
			val2.InFlightSpawnFrequency = 0.05f;
			val2.goopDefinition = (((Object)(object)((PassiveItem)this).Owner != (Object)null && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Hot Tempered")) ? GoopUtility.GreenFireDef : GoopUtility.FireDef);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += onFired;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= onFired;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CalculateStats(((PassiveItem)this).Owner);
		}
	}

	private void CalculateStats(PlayerController player)
	{
		currentItems = player.passiveItems.Count;
		currentGuns = player.inventory.AllGuns.Count;
		if (currentItems != lastItems || currentGuns != lastGuns)
		{
			bool shouldGiveFireImmunity = false;
			if (((PassiveItem)this).Owner.HasPickupID(481) || ((PassiveItem)this).Owner.HasPickupID(275) || ((PassiveItem)this).Owner.HasPickupID(661))
			{
				shouldGiveFireImmunity = true;
			}
			HandleFireImmunity(shouldGiveFireImmunity);
			lastItems = currentItems;
			lastGuns = currentGuns;
		}
	}

	private void HandleFireImmunity(bool shouldGiveFireImmunity)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (shouldGiveFireImmunity)
		{
			m_fireImmunity = new DamageTypeModifier();
			m_fireImmunity.damageMultiplier = 0f;
			m_fireImmunity.damageType = (CoreDamageTypes)4;
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Add(m_fireImmunity);
		}
		else
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.damageTypeModifiers.Remove(m_fireImmunity);
		}
	}
}
