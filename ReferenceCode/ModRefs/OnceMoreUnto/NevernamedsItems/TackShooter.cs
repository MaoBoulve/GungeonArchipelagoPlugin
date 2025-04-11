using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class TackShooter : PlayerItem
{
	public static GameObject TackShooterObject;

	private static string[] RegTackShooterSprites = new string[8] { "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_idle_001", "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_shoot_001", "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_shoot_002", "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_spawn_001", "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_spawn_002", "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_spawn_003", "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_spawn_004", "NevernamedsItems/Resources/PlaceableObjects/TackShooter/tackshooter_spawn_005" };

	public static void Init()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TackShooter>("Tack Shooter", "Tacked On", "Places a radial tack-spraying turret.\n\nLegends tell of a tiny monkey hiding inside, operating the device.", "tackshooter_generic", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 200f);
		TackShooterObject = SetupTackShooter();
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	private static GameObject SetupTackShooter()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		PickupObject byId = PickupObjectDatabase.GetById(26);
		Projectile val = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)val).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val);
		val.baseData.damage = 8f;
		val.baseData.range = 5f;
		ref GameObject overrideMidairDeathVFX = ref val.hitEffects.overrideMidairDeathVFX;
		PickupObject byId2 = PickupObjectDatabase.GetById(28);
		overrideMidairDeathVFX = ((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0].hitEffects.tileMapVertical.effects[0].effects[0].effect;
		GameObject val2 = CompanionBuilder.BuildPrefab("Tack Shooter", "Tack_Shooter_GUID", RegTackShooterSprites[0], new IntVector2(6, 2), new IntVector2(7, 14));
		((Object)val2).name = "Tack Shooter";
		SpeculativeRigidbody val3 = SpriteBuilder.SetUpSpeculativeRigidbody(val2.GetComponent<tk2dSprite>(), new IntVector2(6, 2), new IntVector2(7, 14));
		TackShooterBehaviour tackShooterBehaviour = val2.AddComponent<TackShooterBehaviour>();
		tackShooterBehaviour.ProjectileToShoot = val;
		AIAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<AIAnimator>(val2);
		DirectionalAnimation val4 = new DirectionalAnimation();
		val4.Type = (DirectionType)1;
		val4.Flipped = (FlipType[])(object)new FlipType[1];
		val4.Prefix = "idle";
		val4.AnimNames = new string[1] { "idle" };
		orAddComponent.IdleAnimation = val4;
		List<NamedDirectionalAnimation> list = new List<NamedDirectionalAnimation>();
		NamedDirectionalAnimation val5 = new NamedDirectionalAnimation();
		val5.name = "appear";
		NamedDirectionalAnimation obj = val5;
		val4 = new DirectionalAnimation();
		val4.Prefix = "appear";
		val4.Type = (DirectionType)1;
		val4.Flipped = (FlipType[])(object)new FlipType[1];
		val4.AnimNames = new string[1] { "appear" };
		obj.anim = val4;
		list.Add(val5);
		val5 = new NamedDirectionalAnimation();
		val5.name = "shoot";
		NamedDirectionalAnimation obj2 = val5;
		val4 = new DirectionalAnimation();
		val4.Prefix = "shoot";
		val4.Type = (DirectionType)1;
		val4.Flipped = (FlipType[])(object)new FlipType[1];
		val4.AnimNames = new string[1] { "shoot" };
		obj2.anim = val4;
		list.Add(val5);
		orAddComponent.OtherAnimations = list;
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val2);
		tk2dSpriteCollectionData val6 = SpriteBuilder.ConstructCollection(val2, "TackShooterCollection", false);
		Object.DontDestroyOnLoad((Object)(object)val6);
		for (int i = 0; i < RegTackShooterSprites.Length; i++)
		{
			SpriteBuilder.AddSpriteToCollection(RegTackShooterSprites[i], val6, (Assembly)null);
		}
		SpriteBuilder.AddAnimation(orAddComponent2, val6, new List<int> { 0 }, "idle", (WrapMode)0, 15f).fps = 12f;
		SpriteBuilder.AddAnimation(orAddComponent2, val6, new List<int> { 1, 2 }, "shoot", (WrapMode)2, 15f).fps = 12f;
		SpriteBuilder.AddAnimation(orAddComponent2, val6, new List<int> { 3, 4, 5, 6, 7 }, "appear", (WrapMode)2, 15f).fps = 12f;
		val3.PixelColliders.Clear();
		val3.PixelColliders.Add(new PixelCollider
		{
			ColliderGenerationMode = (PixelColliderGeneration)0,
			CollisionLayer = (CollisionLayer)0,
			IsTrigger = false,
			BagleUseFirstFrameOnly = false,
			SpecifyBagelFrame = string.Empty,
			BagelColliderNumber = 0,
			ManualOffsetX = 6,
			ManualOffsetY = 2,
			ManualWidth = 7,
			ManualHeight = 14,
			ManualDiameter = 0,
			ManualLeftX = 0,
			ManualLeftY = 0,
			ManualRightX = 0,
			ManualRightY = 0
		});
		val3.CollideWithOthers = false;
		val2.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val2);
		Object.DontDestroyOnLoad((Object)(object)val2);
		return val2;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = PlayerUtility.PositionInDistanceFromAimDir(user, 1f);
		GameObject val2 = Object.Instantiate<GameObject>(TackShooterObject, Vector2.op_Implicit(val), Quaternion.identity);
		val2.GetComponent<AIActor>().CompanionOwner = user;
		((tk2dBaseSprite)val2.GetComponent<tk2dSprite>()).PlaceAtLocalPositionByAnchor(Vector2.op_Implicit(val), (Anchor)4);
		TackShooterBehaviour component = val2.GetComponent<TackShooterBehaviour>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.owner = user;
		}
	}
}
