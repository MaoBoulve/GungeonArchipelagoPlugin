using System;
using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class BulletScarecrow : BraveBehaviour
{
	public string wobbleAnim;

	public static List<string> dialogue = new List<string> { "Ouch.", "Stop that." };

	public static void Init()
	{
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		List<ShardCluster> clusters = Breakables.GenerateBarrelStyleShardClusters(new List<string> { "bulletscarecrow_debris_001", "bulletscarecrow_debris_002", "bulletscarecrow_debris_003", "bulletscarecrow_debris_004" }, new List<string> { "bulletscarecrow_weirddebris_001", "bulletscarecrow_weirddebris_002" }, new List<string> { "bulletscarecrow_smalldebris_001", "bulletscarecrow_smalldebris_002", "bulletscarecrow_smalldebris_003", "bulletscarecrow_smalldebris_004" }, new List<string> { "bulletscarecrow_smalldebris_001", "bulletscarecrow_smalldebris_002", "bulletscarecrow_smalldebris_003", "bulletscarecrow_smalldebris_004" }, new List<string> { "bulletscarecrow_stuffing_001", "bulletscarecrow_stuffing_002" }, new List<string> { "bulletscarecrow_stuffing_001", "bulletscarecrow_stuffing_002", "bulletscarecrow_stuffing_003", "bulletscarecrow_stuffing_004" });
		GameObject val = SetupScarecrow("bulletscarecrow_center", "bulletscarecrow_centerhit", clusters);
		GameObject val2 = SetupScarecrow("bulletscarecrow_left", "bulletscarecrow_lefthit", clusters);
		GameObject val3 = SetupScarecrow("bulletscarecrow_right", "bulletscarecrow_hitright", clusters);
		DungeonPlaceable val4 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float>
		{
			{ val.gameObject, 1f },
			{ val2.gameObject, 1f },
			{ val3.gameObject, 1f }
		}, 1, 1, (DungeonPrerequisite[])null);
		val4.isPassable = true;
		val4.width = 1;
		val4.height = 1;
		val4.variantTiers[0].unitOffset = new Vector2(-0.25f, 0f);
		val4.variantTiers[1].unitOffset = new Vector2(-0.25f, 0f);
		val4.variantTiers[2].unitOffset = new Vector2(-0.25f, 0f);
		StaticReferences.StoredDungeonPlaceables.Add("bullet_scarecrow", val4);
		StaticReferences.customPlaceables.Add("nn:bullet_scarecrow", val4);
	}

	private static GameObject SetupScarecrow(string idle, string wobbleanim, List<ShardCluster> clusters)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		MajorBreakable val = Breakables.GenerateMajorBreakable("Bullet_Scarecrow", Initialisation.EnvironmentCollection, Initialisation.environmentAnimationCollection, "bulletscarecrow_center_001", idle, "bulletscarecrow_break", 15f, UsesCustomColliderValues: false, 11, 15, 7, 4, DistribleShards: true, null, null, BlocksPaths: false, null, null, destroyedOnBreak: false, handlesOwnBreakAnim: true);
		GameObject val2 = ItemBuilder.SpriteFromBundle("bulletscarecrow_shadow", Initialisation.EnvironmentCollection.GetSpriteIdByName("bulletscarecrow_shadow"), Initialisation.EnvironmentCollection, new GameObject("Shadow"));
		val2.transform.SetParent(((BraveBehaviour)val).transform);
		val2.transform.localPosition = new Vector3(0.25f, -0.0625f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -5f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		BulletScarecrow bulletScarecrow = ((Component)val).gameObject.AddComponent<BulletScarecrow>();
		bulletScarecrow.wobbleAnim = wobbleanim;
		((Component)val).gameObject.AddComponent<PlacedBlockerConfigurable>();
		val.InvulnerableToEnemyBullets = true;
		val.IgnoreExplosions = false;
		((Component)val).gameObject.layer = 22;
		((BraveBehaviour)val).sprite.HeightOffGround = -1f;
		val.shardClusters = clusters.ToArray();
		FakePrefabExtensions.MakeFakePrefab(((Component)val).gameObject);
		return ((Component)val).gameObject;
	}

	private void Start()
	{
		MajorBreakable majorBreakable = ((BraveBehaviour)this).majorBreakable;
		majorBreakable.OnDamaged = (Action<float>)Delegate.Combine(majorBreakable.OnDamaged, new Action<float>(OnDamaged));
		MajorBreakable majorBreakable2 = ((BraveBehaviour)this).majorBreakable;
		majorBreakable2.OnBreak = (Action)Delegate.Combine(majorBreakable2.OnBreak, new Action(OnBreak));
	}

	private void OnDamaged(float amount)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (((BraveBehaviour)this).majorBreakable.HitPoints > 0f && !string.IsNullOrEmpty(wobbleAnim))
		{
			((BraveBehaviour)this).spriteAnimator.Play(wobbleAnim);
			if (Random.value <= 0.001f)
			{
				TextBoxManager.ShowTextBox(Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldTopCenter), ((BraveBehaviour)this).transform, 1f, BraveUtility.RandomElement<string>(dialogue), "gambler", false, (BoxSlideOrientation)0, false, false);
			}
		}
	}

	private void OnBreak()
	{
		AkSoundEngine.PostEvent("Play_CHR_general_death_01", ((Component)this).gameObject);
	}
}
