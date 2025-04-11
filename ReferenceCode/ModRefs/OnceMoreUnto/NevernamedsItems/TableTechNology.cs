using System;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class TableTechNology : PassiveItem
{
	public class TableVortex : BraveBehaviour
	{
		public MajorBreakable table;

		public PlayerController owner;

		public Vector2 direction;

		public FlippableCover flipper;

		private float timeActive;

		private bool started = false;

		private void Start()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			LootEngine.DoDefaultPurplePoof(Vector2.op_Implicit(((BraveBehaviour)this).transform.position), false);
		}

		private void Update()
		{
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).specRigidbody))
			{
				((BraveBehaviour)this).specRigidbody.Reinitialize();
			}
			if (!started && (Object)(object)table != (Object)null && !table.m_isBroken)
			{
				Projectile val = laser;
				if (CustomSynergies.PlayerHasActiveSynergy(owner, "Flippity Beoooow!") && Random.value <= 0.2f)
				{
					PickupObject byId = PickupObjectDatabase.GetById(107);
					val = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
				}
				if (CustomSynergies.PlayerHasActiveSynergy(owner, "The Two Tables"))
				{
					BeamController val2 = BeamAPI.FreeFireBeamFromAnywhere(val, owner, ((Component)this).gameObject, Vector2.zero, Vector2Extensions.ToAngle(direction) + 35f, 20f, true, false, 0f);
					if (val2 is BasicBeamController)
					{
						BeamController obj = ((val2 is BasicBeamController) ? val2 : null);
						((BasicBeamController)obj).reflections = ((BasicBeamController)obj).reflections + 1;
					}
					BeamController val3 = BeamAPI.FreeFireBeamFromAnywhere(val, owner, ((Component)this).gameObject, Vector2.zero, Vector2Extensions.ToAngle(direction) - 35f, 20f, true, false, 0f);
					if (val3 is BasicBeamController)
					{
						BeamController obj2 = ((val3 is BasicBeamController) ? val3 : null);
						((BasicBeamController)obj2).reflections = ((BasicBeamController)obj2).reflections + 1;
					}
				}
				else
				{
					BeamAPI.FreeFireBeamFromAnywhere(val, owner, ((Component)this).gameObject, Vector2.zero, Vector2Extensions.ToAngle(direction), 20f, true, false, 0f);
				}
				started = true;
			}
			timeActive += BraveTime.DeltaTime;
			if (!Object.op_Implicit((Object)(object)table) || table.m_isBroken || timeActive > 20.5f)
			{
				EndBeam();
			}
		}

		private void EndBeam()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			LootEngine.DoDefaultPurplePoof(Vector2.op_Implicit(((BraveBehaviour)this).transform.position), false);
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	public static Projectile laser;

	public static GameObject CrimsonVortex;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TableTechNology>("Table Tech-Nology", "T-Tech", "Laser-powered scroll-readers like this one are employed by elderly followers of the way of the flip- in lieu of glasses, which tend to wind up broken.", "tabletechnology_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamBuilders.GenerateAnchoredBeamPrefabBundle(val2, "vortexbeam_mid_001", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "VortexBeam", new Vector2(17f, 11f), new Vector2(0f, -3f), "CrimsonVortex", (Vector2?)new Vector2(3f, 3f), (Vector2?)new Vector2(-1f, -1f), (string)null, (Vector2?)null, (Vector2?)null, (string)null, (Vector2?)null, (Vector2?)null, false, false, (string)null, (string)null, (string)null, 1f, false, (string)null, (string)null, (string)null, 1f);
		((Object)((Component)val2).gameObject).name = "Vortex Beam";
		EmmisiveBeams orAddComponent = GameObjectExtensions.GetOrAddComponent<EmmisiveBeams>(((Component)val2).gameObject);
		orAddComponent.EmissivePower = 50f;
		orAddComponent.EmissiveColorPower = 50f;
		orAddComponent.EmissiveColor = new Color(0.99607843f, 48f / 85f, 0.5019608f);
		val2.baseData.damage = 20f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 5f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 10f;
		val3.boneType = (BeamBoneType)0;
		val3.endAudioEvent = "Stop_WPN_All";
		val3.startAudioEvent = "Play_WPN_moonscraperLaser_shot_01";
		laser = val2;
		GameObject val4 = ItemBuilder.SpriteFromBundle("crimsonvortex_001", Initialisation.ProjectileCollection.GetSpriteIdByName("crimsonvortex_001"), Initialisation.ProjectileCollection, new GameObject("Vortex"));
		val4.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val4);
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val4);
		orAddComponent2.Library = Initialisation.projectileAnimationCollection;
		orAddComponent2.defaultClipId = Initialisation.projectileAnimationCollection.GetClipIdByName("CrimsonVortex");
		orAddComponent2.DefaultClipId = Initialisation.projectileAnimationCollection.GetClipIdByName("CrimsonVortex");
		orAddComponent2.playAutomatically = true;
		tk2dBaseSprite component = val4.GetComponent<tk2dBaseSprite>();
		component.HeightOffGround = 3f;
		component.usesOverrideMaterial = true;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutoutEmissive");
		((BraveBehaviour)component).renderer.material.EnableKeyword("BRIGHTNESS_CLAMP_ON");
		((BraveBehaviour)component).renderer.material.SetFloat("_EmissivePower", 50f);
		((BraveBehaviour)component).renderer.material.SetFloat("_EmissiveColorPower", 50f);
		((BraveBehaviour)component).renderer.material.SetColor("_EmissiveColor", new Color(0.99607843f, 48f / 85f, 0.5019608f));
		val4.gameObject.AddComponent<TableVortex>();
		SpeculativeRigidbody val5 = SpriteBuilder.SetUpSpeculativeRigidbody(val4.GetComponent<tk2dSprite>(), new IntVector2(-1, -2), new IntVector2(3, 3));
		val5.CollideWithTileMap = false;
		val5.CollideWithOthers = false;
		CrimsonVortex = val4;
		AlexandriaTags.SetTag(val, "table_tech");
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnTableFlipCompleted = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipCompleted, new Action<FlippableCover>(DoLaser));
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnTableFlipCompleted = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipCompleted, new Action<FlippableCover>(DoLaser));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void DoLaser(FlippableCover obj)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		IntVector2 intVector2FromDirection = DungeonData.GetIntVector2FromDirection(obj.DirectionFlipped);
		Vector2 val = ((IntVector2)(ref intVector2FromDirection)).ToVector2();
		GameObject val2 = Object.Instantiate<GameObject>(CrimsonVortex, Vector2.op_Implicit(((BraveBehaviour)obj).sprite.WorldCenter + val), Quaternion.identity);
		TableVortex component = val2.GetComponent<TableVortex>();
		component.owner = ((PassiveItem)this).Owner;
		component.table = ((Component)obj).GetComponentInChildren<MajorBreakable>();
		component.direction = val;
		component.flipper = obj;
		val2.transform.SetParent(((BraveBehaviour)obj).transform.GetChild(0));
	}
}
