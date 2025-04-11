using System.Collections.Generic;
using System.Reflection;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class GenericPlaceables
{
	public static GameObject megaStatueBase;

	public static GameObject megaStatuePose;

	public static GameObject megaStatueShotput;

	public static GameObject megaStatueDiscus;

	public static GameObject megaStatueBroken;

	public static void Init()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		megaStatueBase = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/megastatue_base.png", new GameObject("MegaStatue_base"), (Assembly)null);
		megaStatueBase.SetActive(false);
		FakePrefab.MarkAsFakePrefab(megaStatueBase);
		((tk2dBaseSprite)megaStatueBase.GetComponent<tk2dSprite>()).HeightOffGround = -1f;
		megaStatueBase.AddComponent<PlacedBlockerConfigurable>();
		SpeculativeRigidbody val = SpriteBuilder.SetUpSpeculativeRigidbody(megaStatueBase.GetComponent<tk2dSprite>(), new IntVector2(0, -3), new IntVector2(32, 35));
		val.CollideWithTileMap = false;
		val.CollideWithOthers = true;
		val.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		GameObject val2 = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/megastatue_shadow.png", new GameObject("megastatue_shadow"), (Assembly)null);
		val2.transform.SetParent(megaStatueBase.transform);
		val2.transform.localPosition = new Vector3(-0.1875f, -0.1875f, 50f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = 0f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		Dictionary<GameObject, float> dictionary = new Dictionary<GameObject, float> { { megaStatueBase.gameObject, 1f } };
		DungeonPlaceable val3 = BreakableAPIToolbox.GenerateDungeonPlaceable(dictionary, 1, 1, (DungeonPrerequisite[])null);
		val3.isPassable = false;
		val3.width = 2;
		val3.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("megastatue_base", val3);
		StaticReferences.customPlaceables.Add("nn:megastatue_base", val3);
		GameObject val4 = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/megastatue_pose.png", new GameObject("megastatue_pose"), (Assembly)null);
		megaStatuePose = FakePrefab.Clone(megaStatueBase);
		val4.transform.SetParent(megaStatuePose.transform);
		val4.transform.localPosition = new Vector3(-2.125f, 0.8125f, 50f);
		((tk2dBaseSprite)val4.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		DungeonPlaceable val5 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { megaStatuePose.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val5.isPassable = false;
		val5.width = 2;
		val5.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("megastatue_pose", val5);
		StaticReferences.customPlaceables.Add("nn:megastatue_pose", val5);
		GameObject val6 = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/megastatue_discus.png", new GameObject("megastatue_discus"), (Assembly)null);
		megaStatueDiscus = FakePrefab.Clone(megaStatueBase);
		val6.transform.SetParent(megaStatueDiscus.transform);
		val6.transform.localPosition = new Vector3(-1f, 1.0625f, 50f);
		((tk2dBaseSprite)val6.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		DungeonPlaceable val7 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { megaStatueDiscus.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val7.isPassable = false;
		val7.width = 2;
		val7.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("megastatue_discus", val7);
		StaticReferences.customPlaceables.Add("nn:megastatue_discus", val7);
		GameObject val8 = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/megastatue_shotput.png", new GameObject("megastatue_shotput"), (Assembly)null);
		megaStatueShotput = FakePrefab.Clone(megaStatueBase);
		val8.transform.SetParent(megaStatueShotput.transform);
		val8.transform.localPosition = new Vector3(-1.375f, 1.0625f, 50f);
		((tk2dBaseSprite)val8.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		DungeonPlaceable val9 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { megaStatueShotput.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val9.isPassable = false;
		val9.width = 2;
		val9.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("megastatue_shotput", val9);
		StaticReferences.customPlaceables.Add("nn:megastatue_shotput", val9);
		GameObject val10 = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/megastatue_broken.png", new GameObject("megastatue_broken"), (Assembly)null);
		megaStatueBroken = FakePrefab.Clone(megaStatueBase);
		val10.transform.SetParent(megaStatueBroken.transform);
		val10.transform.localPosition = new Vector3(-1f, 1.0625f, 50f);
		((tk2dBaseSprite)val10.GetComponent<tk2dSprite>()).HeightOffGround = 1.25f;
		DungeonPlaceable val11 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { megaStatueBroken.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val11.isPassable = false;
		val11.width = 2;
		val11.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("megastatue_broken", val11);
		StaticReferences.customPlaceables.Add("nn:megastatue_broken", val11);
		DungeonPlaceable val12 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float>
		{
			{ megaStatuePose.gameObject, 1f },
			{ megaStatueShotput.gameObject, 1f },
			{ megaStatueDiscus.gameObject, 1f },
			{ megaStatueBroken.gameObject, 1f }
		}, 1, 1, (DungeonPrerequisite[])null);
		val12.isPassable = false;
		val12.width = 2;
		val12.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("megastatue_random", val12);
		StaticReferences.customPlaceables.Add("nn:megastatue_random", val12);
	}
}
