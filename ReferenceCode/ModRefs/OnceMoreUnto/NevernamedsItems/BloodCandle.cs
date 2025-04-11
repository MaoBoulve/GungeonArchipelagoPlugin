using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class BloodCandle : BraveBehaviour
{
	private RoomHandler currentRoom;

	public GameObject bullet;

	public GameObject vfx;

	private float breakAfter = 0f;

	private bool spent = false;

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("bloodcandle_halo", Initialisation.TrapCollection.GetSpriteIdByName("bloodcandle_halo"), Initialisation.TrapCollection, new GameObject("Halo"));
		val.SetActive(true);
		tk2dSprite component = val.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = 1f;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("tk2d/BlendVertexColorTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		SpritePulser val2 = val.AddComponent<SpritePulser>();
		val2.duration = 0.7f;
		val2.maxDuration = 2.9f;
		val2.maxScale = 1.1f;
		val2.metaDuration = 6f;
		val2.minAlpha = 0.6f;
		val2.minDuration = 0.8f;
		val2.minScale = 0.9f;
		val2.m_active = true;
		MinorBreakable val3 = Breakables.GenerateMinorBreakable("Blood Candle", Initialisation.TrapCollection, Initialisation.trapAnimationCollection, "bloodcandle_001", "bloodcandle_idle", null, "Play_OBJ_candle_fall_01", 4, 4, 1, 1);
		FakePrefabExtensions.MakeFakePrefab(((Component)val3).gameObject);
		((BraveBehaviour)val3).specRigidbody.PixelColliders = new List<PixelCollider>
		{
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)5,
				ManualWidth = 4,
				ManualHeight = 4,
				ManualOffsetX = 1,
				ManualOffsetY = 1
			}
		};
		val3.stopsBullets = false;
		val3.OnlyPlayerProjectilesCanBreak = false;
		val3.OnlyBreaksOnScreen = false;
		val3.resistsExplosions = true;
		val3.canSpawnFairy = false;
		val3.chanceToRain = 0f;
		val3.dropCoins = false;
		val3.goopsOnBreak = false;
		((Component)val3).gameObject.layer = 22;
		((BraveBehaviour)val3).sprite.HeightOffGround = 0f;
		val3.shardClusters = new List<ShardCluster>
		{
			BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.TrapCollection, new List<string> { "bloodcandle_debris_001" }.ToArray()), 1f, 1f, 1, 1, 1f),
			BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.TrapCollection, new List<string> { "bloodcandle_debris_002" }.ToArray()), 1f, 1f, 1, 1, 1f),
			BreakableAPIToolbox.GenerateShardCluster(Breakables.GenerateDebrisObjects(Initialisation.TrapCollection, new List<string> { "bloodcandle_debrissmall_001", "bloodcandle_debrissmall_002", "bloodcandle_debrissmall_003" }.ToArray(), debrisObjectsCanRotate: true, 1f, 1f, 1080f, 40f, null, 0.8f), 0.5f, 2f, 1, 2, 1f)
		}.ToArray();
		val3.breakStyle = (BreakStyle)0;
		val3.IsDecorativeOnly = false;
		PositionRandomiser positionRandomiser = ((Component)val3).gameObject.AddComponent<PositionRandomiser>();
		positionRandomiser.xOffsetMax = 14f;
		positionRandomiser.yOffsetMax = 14f;
		val.transform.SetParent(((Component)val3).gameObject.transform);
		val.transform.localPosition = new Vector3(0.1875f, 0.6875f);
		GameObject val4 = ItemBuilder.SpriteFromBundle("bloodcandle_shadow", Initialisation.TrapCollection.GetSpriteIdByName("bloodcandle_shadow"), Initialisation.TrapCollection, new GameObject("Shadow"));
		val4.transform.SetParent(((Component)val3).gameObject.transform);
		val4.transform.localPosition = new Vector3(-0.0625f, -0.0625f);
		tk2dSprite component2 = val4.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component2).HeightOffGround = -5f;
		((tk2dBaseSprite)component2).SortingOrder = 0;
		((tk2dBaseSprite)component2).IsPerpendicular = false;
		((BraveBehaviour)component2).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component2).usesOverrideMaterial = true;
		GameObject val5 = ItemBuilder.SpriteFromBundle("bloodcandle_flame_001", Initialisation.TrapCollection.GetSpriteIdByName("bloodcandle_flame_001"), Initialisation.TrapCollection, new GameObject("BloodCandleFlame"));
		tk2dSprite component3 = val5.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component3).HeightOffGround = 1f;
		val5.transform.SetParent(((Component)val3).gameObject.transform);
		val5.transform.localPosition = new Vector3(-0.125f, 0.5f);
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val5);
		orAddComponent.Library = Initialisation.trapAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("bloodcandle_flame");
		orAddComponent.DefaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("bloodcandle_flame");
		orAddComponent.playAutomatically = true;
		Material val6 = new Material(((BraveBehaviour)((BraveBehaviour)EnemyDatabase.GetOrLoadByName("GunNut")).sprite).renderer.material);
		val6.mainTexture = ((BraveBehaviour)component3).renderer.material.mainTexture;
		val6.SetColor("_EmissiveColor", new Color(255f, 0f, 0f));
		val6.SetFloat("_EmissiveColorPower", 10f);
		val6.SetFloat("_EmissivePower", 5f);
		((BraveBehaviour)component3).renderer.material = val6;
		BloodCandle bloodCandle = ((Component)val3).gameObject.AddComponent<BloodCandle>();
		bloodCandle.bullet = FakePrefabExtensions.InstantiateAndFakeprefab(((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("5f3abc2d561b4b9c9e72b879c6f10c7e")).bulletBank.GetBullet("default").BulletObject);
		bloodCandle.vfx = SharedVFX.BloodCandleVFX;
		DungeonPlaceable value = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { 
		{
			((Component)val3).gameObject,
			1f
		} }, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("bloodcandle_singular", value);
		StaticReferences.customPlaceables.Add("nn:bloodcandle_singular", value);
		GameObject key = CustomCandles.GenerateCandomizer(2, 2, "BloodCandle", ((Component)val3).gameObject, new List<Vector2>
		{
			new Vector2(2f, 6f),
			new Vector2(10f, 6f)
		}, -1f, 1f, -5f, 6f);
		GameObject key2 = CustomCandles.GenerateCandomizer(3, 3, "BloodCandle", ((Component)val3).gameObject, new List<Vector2>
		{
			new Vector2(0f, 4f),
			new Vector2(10f, 1f),
			new Vector2(9f, 9f)
		}, -3f, 3f, -3f, 3f);
		DungeonPlaceable value2 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float>
		{
			{
				((Component)val3).gameObject,
				1f
			},
			{ key, 1f },
			{ key2, 1f }
		}, 1, 1, (DungeonPrerequisite[])null);
		StaticReferences.StoredDungeonPlaceables.Add("bloodcandle_cluster", value2);
		StaticReferences.customPlaceables.Add("nn:bloodcandle_cluster", value2);
	}

	private void Start()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		breakAfter = Random.Range(5f, 35f);
		currentRoom = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position);
	}

	private void Update()
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		if (currentRoom == null || !((Object)(object)GameManager.Instance.BestActivePlayer != (Object)null) || GameManager.Instance.BestActivePlayer.CurrentRoom != currentRoom)
		{
			return;
		}
		if (breakAfter > 0f)
		{
			breakAfter -= BraveTime.DeltaTime;
		}
		else if (!spent)
		{
			PlayerController activePlayerClosestToPoint = GameManager.Instance.GetActivePlayerClosestToPoint(((BraveBehaviour)this).sprite.WorldTopCenter, false);
			Vector2 direction = MathsAndLogicHelper.CalculateVectorBetween(((BraveBehaviour)this).sprite.WorldTopCenter, ((BraveBehaviour)activePlayerClosestToPoint).specRigidbody.UnitCenter);
			FireProjectile(Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldTopCenter), direction);
			Transform val = ((BraveBehaviour)this).transform.Find("BloodCandleFlame");
			if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((Component)val).gameObject))
			{
				Object.Destroy((Object)(object)((Component)val).gameObject);
			}
			Transform val2 = ((BraveBehaviour)this).transform.Find("Halo");
			if (Object.op_Implicit((Object)(object)val2) && Object.op_Implicit((Object)(object)((Component)val2).gameObject))
			{
				Object.Destroy((Object)(object)((Component)val2).gameObject);
			}
			spent = true;
		}
	}

	private void FireProjectile(Vector3 spawnPosition, Vector2 direction)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)vfx != (Object)null)
		{
			SpawnManager.SpawnVFX(vfx, Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldTopCenter), Quaternion.identity);
		}
		AkSoundEngine.PostEvent("Play_WPN_burninghand_shot_01", ((Component)this).gameObject);
		float num = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
		GameObject val = SpawnManager.SpawnProjectile(bullet, spawnPosition, Quaternion.Euler(0f, 0f, num), true);
		SpeculativeRigidbody component = val.GetComponent<SpeculativeRigidbody>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.RegisterGhostCollisionException(((BraveBehaviour)this).specRigidbody);
		}
		Projectile component2 = val.GetComponent<Projectile>();
		component2.Shooter = ((BraveBehaviour)this).specRigidbody;
		component2.OwnerName = StringTableManager.GetEnemiesString("#TRAP", -1);
	}
}
