using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GoldGuonStone : AdvancedPlayerOrbitalItem
{
	public static int cashSpawnedThisRoom;

	public static PlayerOrbital orbitalPrefab;

	public static void Init()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GoldGuonStone>("Gold Guon Stone", "Greedy Rock", "This opulent stone will occasionally suck the casings right off of enemy bullets that make contact with it.\n\nDespite being illogical, bullets in the Gungeon are often fired casing and all for extra damage. That's 65% more bullet per bullet!", "goldguonstone_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		((PickupObject)val).quality = (ItemQuality)2;
		BuildPrefab();
		val.OrbitalPrefab = orbitalPrefab;
	}

	public static void BuildPrefab()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)orbitalPrefab != (Object)null))
		{
			GameObject val = ItemBuilder.SpriteFromBundle("GoldGuonOrbital", Initialisation.itemCollection.GetSpriteIdByName("goldguonstone_ingame"), Initialisation.itemCollection, (GameObject)null);
			((Object)val).name = "Gold Guon Orbital";
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), IntVector2.Zero, new IntVector2(7, 13));
			val2.CollideWithTileMap = false;
			val2.CollideWithOthers = true;
			val2.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
			orbitalPrefab = val.AddComponent<PlayerOrbital>();
			orbitalPrefab.motionStyle = (OrbitalMotionStyle)0;
			orbitalPrefab.shouldRotate = false;
			orbitalPrefab.orbitRadius = 2.5f;
			orbitalPrefab.SetOrbitalTier(0);
			orbitalPrefab.orbitDegreesPerSecond = 120f;
			Object.DontDestroyOnLoad((Object)(object)val);
			FakePrefab.MarkAsFakePrefab(val);
			val.SetActive(false);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(resetCash));
		((AdvancedPlayerOrbitalItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(resetCash));
		return ((AdvancedPlayerOrbitalItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnEnteredCombat = (Action)Delegate.Remove(owner.OnEnteredCombat, new Action(resetCash));
		}
		((AdvancedPlayerOrbitalItem)this).OnDestroy();
	}

	private void resetCash()
	{
		cashSpawnedThisRoom = 0;
	}

	public override void OnOrbitalCreated(GameObject orbital)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		SpeculativeRigidbody component = orbital.GetComponent<SpeculativeRigidbody>();
		if (Object.op_Implicit((Object)(object)component))
		{
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)component).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHit));
		}
		((AdvancedPlayerOrbitalItem)this).OnOrbitalCreated(orbital);
	}

	private void OnGuonHit(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		Projectile component = ((Component)other).GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null && !(component.Owner is PlayerController) && Random.value < 0.1f && cashSpawnedThisRoom < 20)
		{
			LootEngine.SpawnItem(((Component)PickupObjectDatabase.GetById(68)).gameObject, Vector2.op_Implicit(((BraveBehaviour)other).specRigidbody.UnitCenter), Vector2.zero, 1f, false, true, false);
			cashSpawnedThisRoom++;
		}
	}
}
