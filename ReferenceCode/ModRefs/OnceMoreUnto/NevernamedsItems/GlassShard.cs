using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class GlassShard : PassiveItem
{
	public static Projectile GlassShardProjectile;

	public static int GlassShardID;

	private bool onCooldown = false;

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GlassShard>("Glass Shard", "Walking on Broken Glass", "Makes Glass Guon Stones fire at enemies.\n\nCarries the soul of a vengeful gungeoneer.\nSome say if you gaze into the depths of the shard, you can see him gazing back out at you.", "glassshard_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)4;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 1f;
		val2.SetProjectileSprite("glasster_projectile", 4, 4, lightened: true, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		GlassShardProjectile = val2;
		GlassShardID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null && ((PassiveItem)this).Owner.IsInCombat && !onCooldown)
		{
			foreach (IPlayerOrbital orbital in ((PassiveItem)this).Owner.orbitals)
			{
				PlayerOrbital val = (PlayerOrbital)orbital;
				if (((Object)val).name == "IounStone_Glass(Clone)" && Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun) && ((PickupObject)((GameActor)((PassiveItem)this).Owner).CurrentGun).PickupObjectId != Glasster.GlassterID)
				{
					if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Shattershot"))
					{
						FireBullet(orbital.GetTransform(), 0f, 10f);
						FireBullet(orbital.GetTransform(), 14f, 10f);
						FireBullet(orbital.GetTransform(), -14f, 10f);
					}
					else
					{
						FireBullet(orbital.GetTransform(), 0f, 5f);
					}
				}
			}
			onCooldown = true;
			float num = 1.5f;
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Break Fast!"))
			{
				num = 0.9f;
			}
			((MonoBehaviour)this).Invoke("ResetCooldown", num);
		}
		((PassiveItem)this).Update();
	}

	private void FireBullet(Transform pos, float angleOffset, float anglevariance)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ProjectileUtility.InstantiateAndFireTowardsPosition(GlassShardProjectile, Vector2.op_Implicit(pos.position), MathsAndLogicHelper.GetPositionOfNearestEnemy(Vector2.op_Implicit(pos.position), (ActorCenter)2, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null), angleOffset, anglevariance, (PlayerController)null);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
			component.TreatedAsNonProjectileForChallenge = true;
			component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
			ProjectileData baseData = component.baseData;
			baseData.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = component.baseData;
			baseData2.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
			ProjectileData baseData3 = component.baseData;
			baseData3.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
			component.AdditionalScaleMultiplier *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)15);
			component.UpdateSpeed();
			((PassiveItem)this).Owner.DoPostProcessProjectile(component);
		}
	}

	private void ResetCooldown()
	{
		onCooldown = false;
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			for (int i = 0; i < 3; i++)
			{
				_003F val = player;
				PickupObject byId = PickupObjectDatabase.GetById(565);
				((PlayerController)val).AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			}
		}
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
		((PassiveItem)this).Pickup(player);
	}

	private void OnNewFloor()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			_003F val = ((PassiveItem)this).Owner;
			PickupObject byId = PickupObjectDatabase.GetById(565);
			((PlayerController)val).AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((PassiveItem)this).OnDestroy();
	}
}
