using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class CyanGuonStone : AdvancedPlayerOrbitalItem
{
	public static Projectile cyanGuonProj;

	private bool canFire = true;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<CyanGuonStone>("Cyan Guon Stone", "Slow and Steady", "Targets enemies when you stand still.\n\nThis rock is inhabited by a powerful spirit of lethargy.", "cyanguon_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.OrbitalPrefab = ItemSetup.CreateOrbitalObject("Cyan Guon Stone", "cyanguon_ingame", new IntVector2(8, 8), new IntVector2(-4, -4), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0).GetComponent<PlayerOrbital>();
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Cyaner Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ItemSetup.CreateOrbitalObject("Cyaner Guon Stone", "cyanguon_synergy", new IntVector2(12, 12), new IntVector2(-6, -6), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0, 10f);
		Projectile proj = ProjectileSetupUtility.MakeProjectile(86, 2f, 1000f, 50f);
		proj.SetProjectileSprite("cyanguon_proj", 5, 5, lightened: true, (Anchor)4, 5, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		cyanGuonProj = proj;
	}

	public override void Update()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)base.m_extantOrbital != (Object)null && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody) && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.IsInCombat && ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.Velocity == Vector2.zero && canFire)
		{
			tk2dSprite component = base.m_extantOrbital.GetComponent<tk2dSprite>();
			if (Object.op_Implicit((Object)(object)component))
			{
				AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(((tk2dBaseSprite)component).WorldCenter, true, (ActiveEnemyType)0, (List<AIActor>)null, (Func<AIActor, bool>)null);
				if ((Object)(object)nearestEnemyToPosition != (Object)null)
				{
					GameObject val = SpawnManager.SpawnProjectile(((Component)cyanGuonProj).gameObject, Vector2.op_Implicit(((tk2dBaseSprite)component).WorldCenter), Quaternion.Euler(0f, 0f, Vector2Extensions.ToAngle(MathsAndLogicHelper.CalculateVectorBetween(((tk2dBaseSprite)component).WorldCenter, ((GameActor)nearestEnemyToPosition).CenterPosition))), true);
					Projectile component2 = val.GetComponent<Projectile>();
					if ((Object)(object)component2 != (Object)null)
					{
						component2.Owner = (GameActor)(object)((PassiveItem)this).Owner;
						component2.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
						ProjectileData baseData = component2.baseData;
						baseData.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
						ProjectileData baseData2 = component2.baseData;
						baseData2.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
						ProjectileData baseData3 = component2.baseData;
						baseData3.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
						component2.AdditionalScaleMultiplier *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)15);
						component2.UpdateSpeed();
						((PassiveItem)this).Owner.DoPostProcessProjectile(component2);
					}
					canFire = false;
					float num = 0.35f;
					if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Cyaner Guon Stone"))
					{
						num = 0.16f;
					}
					((MonoBehaviour)this).Invoke("resetFireCooldown", num);
				}
			}
		}
		((AdvancedPlayerOrbitalItem)this).Update();
	}

	private void resetFireCooldown()
	{
		canFire = true;
	}

	public override void Pickup(PlayerController player)
	{
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}
}
