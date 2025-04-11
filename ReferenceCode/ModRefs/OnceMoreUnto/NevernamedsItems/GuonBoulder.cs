using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GuonBoulder : AdvancedPlayerOrbitalItem
{
	public static PlayerOrbital orbitalPrefab;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GuonBoulder>("Guon Boulder", "Hefty Chunk", "An experiment to see just how huge a Guon Stone can be.\n\nAll the magic in this stone is solely dedicated just to keeping it aloft, and thus no further special effects are able to fit inside.", "guonboulder_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("GuonBoulderOrbital", Initialisation.itemCollection.GetSpriteIdByName("guonboulder_icon"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Guon Boulder Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(30, 30));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.shouldRotate = false;
			orbitalPrefab.orbitRadius = 7f;
			orbitalPrefab.orbitDegreesPerSecond = 5f;
			orbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}
}
