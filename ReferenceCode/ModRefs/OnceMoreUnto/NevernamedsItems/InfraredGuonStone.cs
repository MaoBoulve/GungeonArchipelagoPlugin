using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class InfraredGuonStone : AdvancedPlayerOrbitalItem
{
	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital upgradeOrbitalPrefab;

	public static Projectile InfraredBeam;

	private BeamController extantBeam;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<InfraredGuonStone>("Infrared Guon Stone", "Under the Radar", "Expels photonic exhaust away from the user.\n\nStand well back.", "infraredguonstone_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
		BuildSynergyPrefab();
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Infraredder Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ((Component)upgradeOrbitalPrefab).gameObject;
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/redbeam_seg_001", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_002", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_003", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/redbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_004" };
		Projectile val2 = ProjectileUtility.SetupProjectile(86);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/redbeam_seg_001", new Vector2(18f, 2f), new Vector2(0f, 8f), list, 8, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		val2.baseData.damage = 50f;
		val2.baseData.range = 100f;
		val2.baseData.speed = 25f;
		val3.boneType = (BeamBoneType)0;
		val3.interpolateStretchedBones = false;
		val3.endAudioEvent = "Stop_WPN_All";
		val3.startAudioEvent = "Play_WPN_radiationlaser_shot_01";
		InfraredBeam = val2;
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("InfraredGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("infraredguonstone_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Infrared Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(7, 7));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.shouldRotate = false;
			orbitalPrefab.perfectOrbitalFactor = 10f;
			orbitalPrefab.orbitRadius = 2.5f;
			orbitalPrefab.orbitDegreesPerSecond = 120f;
			orbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public static void BuildSynergyPrefab()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)upgradeOrbitalPrefab == (Object)null)
		{
			GameObject val = ItemBuilder.SpriteFromBundle("InfraredGuonOrbitalSynergy", Initialisation.itemCollection.GetSpriteIdByName("infraredguonstone_synergy"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Infrared Guon Orbital Synergy Form";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(10, 10));
			upgradeOrbitalPrefab = val.AddComponent<PlayerOrbital>();
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			upgradeOrbitalPrefab.shouldRotate = false;
			upgradeOrbitalPrefab.orbitRadius = 2.5f;
			upgradeOrbitalPrefab.orbitDegreesPerSecond = 60f;
			upgradeOrbitalPrefab.perfectOrbitalFactor = 10f;
			upgradeOrbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public override void Update()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (((Object)(object)base.m_extantOrbital != (Object)null) & Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (((PassiveItem)this).Owner.IsInCombat && (Object)(object)extantBeam == (Object)null)
			{
				extantBeam = BeamAPI.FreeFireBeamFromAnywhere(InfraredBeam, ((PassiveItem)this).Owner, base.m_extantOrbital, Vector2.zero, 0f, float.MaxValue, false, false, 0f);
				((Component)((BraveBehaviour)extantBeam).projectile).gameObject.AddComponent<AlwaysPointAwayFromPlayerBeam>();
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Infraredder Guon Stone"))
				{
					ProjectileData baseData = ((BraveBehaviour)extantBeam).projectile.baseData;
					baseData.damage *= 2f;
				}
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Xenochrome"))
				{
					BasicBeamController component = ((Component)extantBeam).GetComponent<BasicBeamController>();
					component.penetration++;
					BasicBeamController component2 = ((Component)extantBeam).GetComponent<BasicBeamController>();
					component2.reflections++;
				}
			}
			else if (!((PassiveItem)this).Owner.IsInCombat && (Object)(object)extantBeam != (Object)null)
			{
				extantBeam.CeaseAttack();
				extantBeam = null;
			}
		}
		else if (((Object)(object)base.m_extantOrbital == (Object)null || (Object)(object)((PassiveItem)this).Owner == (Object)null) && (Object)(object)extantBeam != (Object)null)
		{
			extantBeam.CeaseAttack();
			extantBeam = null;
		}
		((AdvancedPlayerOrbitalItem)this).Update();
	}

	public GameObject GimmeOrbital()
	{
		if (Object.op_Implicit((Object)(object)base.m_extantOrbital))
		{
			return base.m_extantOrbital;
		}
		return null;
	}

	public override void Pickup(PlayerController player)
	{
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)extantBeam))
		{
			extantBeam.CeaseAttack();
			extantBeam = null;
		}
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)extantBeam))
		{
			extantBeam.CeaseAttack();
			extantBeam = null;
		}
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}
}
