using System;
using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class BigBlank : BraveBehaviour
{
	public static GameObject vfx;

	public static void Init()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		vfx = VFXToolbox.CreateVFXBundle("BigBlankBurst", new IntVector2(40, 38), (Anchor)0, usesZHeight: true, 2f, -1f, null);
		MinorBreakable val = Breakables.GenerateMinorBreakable("Big_Blank", Initialisation.EnvironmentCollection, Initialisation.environmentAnimationCollection, "bigblank_idle_001", "bigblank_idle", "bigblank_break", "Play_OBJ_silenceblank_use_01", 10, 10, 8, 2, vfx);
		FakePrefabExtensions.MakeFakePrefab(((Component)val).gameObject);
		GameObject val2 = ItemBuilder.SpriteFromBundle("genericbarrel_shadow_001", Initialisation.EnvironmentCollection.GetSpriteIdByName("genericbarrel_shadow_001"), Initialisation.EnvironmentCollection, new GameObject("Shadow"));
		val2.transform.SetParent(((BraveBehaviour)val).transform);
		val2.transform.localPosition = new Vector3(0.25f, 0f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -5f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		((Component)val).gameObject.AddComponent<PlacedBlockerConfigurable>();
		val.stopsBullets = true;
		val.OnlyPlayerProjectilesCanBreak = true;
		val.OnlyBreaksOnScreen = true;
		val.resistsExplosions = false;
		val.canSpawnFairy = false;
		val.chanceToRain = 0f;
		val.dropCoins = false;
		val.goopsOnBreak = false;
		((Component)val).gameObject.layer = 22;
		((BraveBehaviour)val).sprite.HeightOffGround = -1f;
		val.IsDecorativeOnly = false;
		val.isInvulnerableToGameActors = true;
		BigBlank bigBlank = ((Component)val).gameObject.AddComponent<BigBlank>();
		DungeonPlaceable val3 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { 
		{
			((Component)val).gameObject,
			1f
		} }, 1, 1, (DungeonPrerequisite[])null);
		val3.isPassable = false;
		val3.width = 1;
		val3.height = 1;
		val3.variantTiers[0].unitOffset = new Vector2(-0.25f, 0.125f);
		StaticReferences.StoredDungeonPlaceables.Add("big_blank", val3);
		StaticReferences.customPlaceables.Add("nn:big_blank", val3);
	}

	private void Start()
	{
		MinorBreakable minorBreakable = ((BraveBehaviour)this).minorBreakable;
		minorBreakable.OnBreak = (Action)Delegate.Combine(minorBreakable.OnBreak, new Action(OnBreak));
	}

	private void OnBreak()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX");
		GameObject val2 = new GameObject("silencer");
		SilencerInstance val3 = val2.AddComponent<SilencerInstance>();
		val3.TriggerSilencer(((BraveBehaviour)this).specRigidbody.UnitCenter, 50f, 25f, val, 0.15f, 0.2f, 50f, 10f, 140f, 15f, 0.5f, ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null) ? GameManager.Instance.PrimaryPlayer : null, true, false);
	}
}
