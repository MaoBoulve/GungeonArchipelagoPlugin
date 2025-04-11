using System;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

internal class BrownGuonStone : AdvancedPlayerOrbitalItem
{
	public static Hook guonHook;

	public static PlayerOrbital orbitalPrefab;

	public static PlayerOrbital brownGuonOrbital;

	private int currentItems;

	private int lastItems;

	private int currentGuns;

	private int lastGuns;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BrownGuonStone>("Brown Guon Stone", "Humble Stone", "This simple river rock was given meagre magical abilities by the mad wizard Alben Smallbore as part of his experiments. While it can’t do fancy things like heal it’s bearer’s wounds, slow time, or create black holes, it doesn’t mind.\n\nGets excited at the appearance of other relics of a similar calibre to itself.", "brownguonstone_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
	}

	public static void BuildPrefab()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("BrownGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("brownguonstone_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Brown Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(7, 13));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.shouldRotate = false;
			orbitalPrefab.orbitRadius = 5f;
			orbitalPrefab.orbitDegreesPerSecond = 40f;
			orbitalPrefab.SetOrbitalTier(0);
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		guonHook = new Hook((MethodBase)typeof(PlayerOrbital).GetMethod("Initialize"), typeof(BrownGuonStone).GetMethod("GuonInit"));
		GameManager.Instance.OnNewLevelFullyLoaded += OnNewFloor;
		((MonoBehaviour)this).Invoke("RecalculateSpeed", 1f);
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		guonHook.Dispose();
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		guonHook.Dispose();
		GameManager.Instance.OnNewLevelFullyLoaded -= OnNewFloor;
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}

	private void OnNewFloor()
	{
		RecalculateSpeed();
	}

	public static void GuonInit(Action<PlayerOrbital, PlayerController> orig, PlayerOrbital self, PlayerController player)
	{
		orig(self, player);
		if (((Object)self).name == "Brown Guon Orbital(Clone)")
		{
			brownGuonOrbital = self;
		}
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CheckItems(((PassiveItem)this).Owner);
		}
	}

	private void RecalculateSpeed()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		float num = 40f;
		brownGuonOrbital.orbitDegreesPerSecond = num;
		foreach (PassiveItem passiveItem in ((PassiveItem)this).Owner.passiveItems)
		{
			if ((int)((PickupObject)passiveItem).quality == 1 || ((PickupObject)passiveItem).PickupObjectId == 127)
			{
				num += 10f;
			}
		}
		foreach (Gun allGun in ((PassiveItem)this).Owner.inventory.AllGuns)
		{
			if ((int)((PickupObject)allGun).quality == 1)
			{
				num += 10f;
			}
		}
		brownGuonOrbital.orbitDegreesPerSecond = num;
	}

	private void CheckItems(PlayerController player)
	{
		currentItems = player.passiveItems.Count;
		currentGuns = player.inventory.AllGuns.Count;
		bool flag = currentItems != lastItems;
		bool flag2 = currentGuns != lastGuns;
		if (flag || flag2)
		{
			RecalculateSpeed();
			lastItems = currentItems;
			lastGuns = currentGuns;
		}
	}
}
