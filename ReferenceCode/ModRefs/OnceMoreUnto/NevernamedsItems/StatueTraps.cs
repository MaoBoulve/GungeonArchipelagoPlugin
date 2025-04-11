using System.Collections.Generic;
using System.Reflection;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class StatueTraps
{
	public static GameObject BulletKinStatueTrap;

	public static void Init()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		BulletKinStatueTrap = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/kinstatuetrap_bullet.png", new GameObject("kinstatuetrap_bullet"), (Assembly)null);
		FakePrefabExtensions.MakeFakePrefab(BulletKinStatueTrap);
		SpeculativeRigidbody val = SpriteBuilder.SetUpSpeculativeRigidbody(BulletKinStatueTrap.GetComponent<tk2dSprite>(), new IntVector2(0, -2), new IntVector2(16, 18));
		val.CollideWithTileMap = false;
		val.CollideWithOthers = true;
		val.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)6;
		((tk2dBaseSprite)((Component)BulletKinStatueTrap.GetComponent<tk2dSprite>()).GetComponent<tk2dSprite>()).HeightOffGround = 0.1f;
		Transform transform = new GameObject("shootPoint").transform;
		transform.SetParent(BulletKinStatueTrap.transform);
		transform.localPosition = new Vector3(0.5f, 1.25f);
		GameObject val2 = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/PlaceableObjects/kinstatuetrap_shadow.png", new GameObject("kinstatuetrap_shadow"), (Assembly)null);
		val2.transform.SetParent(BulletKinStatueTrap.transform);
		val2.transform.localPosition = new Vector3(-0.0625f, -0.125f, 50f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = 0f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		GameObject trapShot = FakePrefabExtensions.InstantiateAndFakeprefab(((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5")).bulletBank.GetBullet("default").BulletObject);
		KinStatueTrap kinStatueTrap = BulletKinStatueTrap.gameObject.AddComponent<KinStatueTrap>();
		kinStatueTrap.trapShot = trapShot;
		kinStatueTrap.vfxOffset = Vector2.op_Implicit(new Vector2(-0.375f, 0.3125f));
		kinStatueTrap.vfx = VFXToolbox.CreateVFXBundle("KinStatueTrapBulletActivate", new IntVector2(27, 34), (Anchor)0, usesZHeight: true, 10f, -1f, null);
		((tk2dBaseSprite)kinStatueTrap.vfx.GetComponent<tk2dSprite>()).HeightOffGround = 10f;
		((BasicTrapController)kinStatueTrap).triggerTimerDelay = 2f;
		((BasicTrapController)kinStatueTrap).triggerTimerOffset = 3f;
		DungeonPlaceable val3 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { BulletKinStatueTrap.gameObject, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val3.isPassable = false;
		val3.width = 1;
		val3.height = 1;
		StaticReferences.StoredDungeonPlaceables.Add("kinstatuetrap_bullet", val3);
		StaticReferences.customPlaceables.Add("nn:kinstatuetrap_bullet", val3);
	}
}
