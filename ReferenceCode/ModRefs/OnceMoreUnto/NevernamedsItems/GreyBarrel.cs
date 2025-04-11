using System;
using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class GreyBarrel : BraveBehaviour
{
	public GameObject trapShot;

	private RoomHandler room;

	public static void Init()
	{
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		List<ShardCluster> list = Breakables.GenerateBarrelStyleShardClusters(new List<string> { "greybarrel_debris_001", "greybarrel_debris_002", "greybarrel_debris_003", "greybarrel_debris_004" }, new List<string> { "greybarrel_metaldebris_001", "greybarrel_metaldebris_002", "greybarrel_metaldebris_003" }, new List<string> { "greybarrel_metalshardsmall_001" }, new List<string> { "greybarrel_woodshardlarge_001", "greybarrel_woodshardlarge_002", "greybarrel_woodshardlarge_003" }, new List<string> { "greybarrel_woodshardmed_001", "greybarrel_woodshardmed_002", "greybarrel_woodshardmed_003" }, new List<string> { "greybarrel_woodshardsmall_001", "greybarrel_woodshardsmall_002" });
		MinorBreakable val = Breakables.GenerateMinorBreakable("Grey_Barrel", Initialisation.EnvironmentCollection, Initialisation.environmentAnimationCollection, "greybarrel_idle_001", "greybarrel_idle", "greybarrel_break", "Play_OBJ_barrel_break_01", 14, 14, 2, 0);
		FakePrefabExtensions.MakeFakePrefab(((Component)val).gameObject);
		GameObject val2 = ItemBuilder.SpriteFromBundle("genericbarrel_shadow_001", Initialisation.EnvironmentCollection.GetSpriteIdByName("genericbarrel_shadow_001"), Initialisation.EnvironmentCollection, new GameObject("Shadow"));
		val2.transform.SetParent(((BraveBehaviour)val).transform);
		val2.transform.localPosition = new Vector3(0f, -0.0625f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -5f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		val.stopsBullets = true;
		val.OnlyPlayerProjectilesCanBreak = false;
		val.OnlyBreaksOnScreen = false;
		val.resistsExplosions = false;
		val.canSpawnFairy = false;
		val.chanceToRain = 0f;
		val.dropCoins = false;
		val.goopsOnBreak = false;
		((Component)val).gameObject.layer = 22;
		((BraveBehaviour)val).sprite.HeightOffGround = -1f;
		val.shardClusters = list.ToArray();
		val.breakStyle = (BreakStyle)0;
		val.IsDecorativeOnly = false;
		GameObject val3 = FakePrefabExtensions.InstantiateAndFakeprefab(((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5")).bulletBank.GetBullet("default").BulletObject);
		GreyBarrel greyBarrel = ((Component)val).gameObject.AddComponent<GreyBarrel>();
		greyBarrel.trapShot = val3;
		DungeonPlaceable val4 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { 
		{
			((Component)val).gameObject,
			1f
		} }, 1, 1, (DungeonPrerequisite[])null);
		val4.isPassable = true;
		val4.width = 1;
		val4.height = 1;
		val4.variantTiers[0].unitOffset = new Vector2(-0.0625f, 0f);
		StaticReferences.StoredDungeonPlaceables.Add("grey_barrel", val4);
		StaticReferences.customPlaceables.Add("nn:grey_barrel", val4);
	}

	private void Start()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		MinorBreakable minorBreakable = ((BraveBehaviour)this).minorBreakable;
		minorBreakable.OnBreak = (Action)Delegate.Combine(minorBreakable.OnBreak, new Action(OnBreak));
		room = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position);
		SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)this).sprite, Color.red);
	}

	private void OnBreak()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		PlayerController activePlayerClosestToPoint = GameManager.Instance.GetActivePlayerClosestToPoint(((BraveBehaviour)this).sprite.WorldCenter, false);
		if (Object.op_Implicit((Object)(object)activePlayerClosestToPoint) && Object.op_Implicit((Object)(object)((BraveBehaviour)activePlayerClosestToPoint).specRigidbody) && room != null && activePlayerClosestToPoint.CurrentRoom == room)
		{
			Vector2 direction = MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)this).sprite.WorldCenter, ((BraveBehaviour)activePlayerClosestToPoint).specRigidbody.UnitCenter);
			ShootProjectileInDirection(Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldCenter), direction);
		}
	}

	private void ShootProjectileInDirection(Vector3 spawnPosition, Vector2 direction)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_TRP_bullet_shot_01", ((Component)this).gameObject);
		float num = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
		GameObject val = SpawnManager.SpawnProjectile(trapShot, spawnPosition, Quaternion.Euler(0f, 0f, num), true);
		SpeculativeRigidbody component = val.GetComponent<SpeculativeRigidbody>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.RegisterGhostCollisionException(((BraveBehaviour)this).specRigidbody);
		}
		Projectile component2 = val.GetComponent<Projectile>();
		component2.Shooter = ((BraveBehaviour)this).specRigidbody;
		component2.OwnerName = StringTableManager.GetEnemiesString("A Barrel", -1);
	}
}
