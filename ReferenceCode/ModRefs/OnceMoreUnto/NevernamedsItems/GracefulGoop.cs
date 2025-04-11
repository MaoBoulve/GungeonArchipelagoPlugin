using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class GracefulGoop : PassiveItem
{
	public static int ID;

	private DamageTypeModifier m_poisonImmunity;

	public static void Init()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GracefulGoop>("Graceful Goop", "They Have Died... Inside", "Bullets trail poison.\n\nBrewed (and probably drunk) by a tragic comedian on the brink.", "gracefulgoop_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		((PickupObject)val).quality = (ItemQuality)3;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_GRACEFULGOOP, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToGooptonMetaShop(25, null);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		GoopModifier val = ((Component)bullet).gameObject.AddComponent<GoopModifier>();
		val.SpawnGoopInFlight = true;
		val.SpawnGoopOnCollision = false;
		val.InFlightSpawnRadius = 0.5f;
		val.InFlightSpawnFrequency = 0.01f;
		val.goopDefinition = GoopUtility.PoisonDef;
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Hot Tempered") && (Random.value < 0.1f || CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Ring of Fire")))
		{
			val.goopDefinition = GoopUtility.GreenFireDef;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Even More Visible!"))
			{
				val.InFlightSpawnRadius = 1f;
			}
			ProjectileData baseData = bullet.baseData;
			baseData.speed *= 1.25f;
			bullet.UpdateSpeed();
			bullet.OnDestruction += OnProjectileDeath;
		}
		if (((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).PickupObjectId == 33)
		{
			IsaacIsDeadLetsCrabDance();
		}
	}

	private void OnProjectileDeath(Projectile self)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject byId = PickupObjectDatabase.GetById(CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Hot Tempered") ? 722 : 336);
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
			scaleChangeOverTimeModifier.timeToChangeOver = 0.5f;
			component.IgnoreTileCollisionsFor(0.1f);
			GoopModifier val2 = val.gameObject.AddComponent<GoopModifier>();
			val2.InFlightSpawnRadius = (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Even More Visible!") ? 1f : 0.5f);
			val2.SpawnGoopInFlight = true;
			val2.InFlightSpawnFrequency = 0.05f;
			val2.goopDefinition = (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Hot Tempered") ? GoopUtility.GreenFireDef : GoopUtility.FireDef);
		}
	}

	private void IsaacIsDeadLetsCrabDance()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		((PassiveItem)this).Owner.inventory.RemoveGunFromInventory(((GameActor)((PassiveItem)this).Owner).CurrentGun);
		IntVector2 bestRewardLocation = ((PassiveItem)this).Owner.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
		Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)((PassiveItem)this).Owner).sprite.WorldCenter), default(Vector2), (Action)null, false, (CoreDamageTypes)0, false);
		if ((double)Random.value < 0.5)
		{
			Chest a_Chest = GameManager.Instance.RewardManager.A_Chest;
			a_Chest.IsLocked = false;
			Chest.Spawn(a_Chest, bestRewardLocation);
		}
		else if ((double)Random.value < 0.2)
		{
			Chest s_Chest = GameManager.Instance.RewardManager.S_Chest;
			s_Chest.IsLocked = true;
			Chest.Spawn(s_Chest, bestRewardLocation);
		}
		else
		{
			Chest synergy_Chest = GameManager.Instance.RewardManager.Synergy_Chest;
			synergy_Chest.IsLocked = false;
			Chest.Spawn(synergy_Chest, bestRewardLocation);
		}
	}

	private void onFiredBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)sourceBeam) && Object.op_Implicit((Object)(object)((Component)sourceBeam).gameObject) && (Object)(object)((Component)sourceBeam).gameObject.GetComponent<GoopModifier>() == (Object)null && Object.op_Implicit((Object)(object)((Component)sourceBeam).GetComponent<BasicBeamController>()))
		{
			GoopModifier val = ((Component)sourceBeam).gameObject.AddComponent<GoopModifier>();
			val.goopDefinition = GoopUtility.PoisonDef;
			val.SpawnGoopInFlight = true;
			val.InFlightSpawnRadius = 0.5f;
			val.InFlightSpawnFrequency = 0.05f;
			val.BeamEndRadius = 1f;
			val.CollisionSpawnRadius = 3f;
			((Component)sourceBeam).GetComponent<BasicBeamController>().m_beamGoopModifier = val;
		}
	}

	private void SpawnCasingSynergy(float damage, bool fatal, HealthHaver enemy)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && fatal && (((PassiveItem)this).Owner.HasPickupID(93) || ((PassiveItem)this).Owner.HasPickupID(321) || ((PassiveItem)this).Owner.HasPickupID(641) || ((PassiveItem)this).Owner.HasPickupID(53) || ((PassiveItem)this).Owner.HasPickupID(231) || ((PassiveItem)this).Owner.HasPickupID(532) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:golden_armour"].PickupObjectId) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:gold_guon_stone"].PickupObjectId)))
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		player.PostProcessProjectile += onFired;
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(SpawnCasingSynergy));
		player.PostProcessBeam += onFiredBeam;
		m_poisonImmunity = new DamageTypeModifier();
		m_poisonImmunity.damageMultiplier = 0f;
		m_poisonImmunity.damageType = (CoreDamageTypes)16;
		((BraveBehaviour)player).healthHaver.damageTypeModifiers.Add(m_poisonImmunity);
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(SpawnCasingSynergy));
			player.PostProcessProjectile -= onFired;
			player.PostProcessBeam -= onFiredBeam;
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(m_poisonImmunity);
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
