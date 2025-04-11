using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class LimeGuonStone : AdvancedPlayerOrbitalItem
{
	public static Projectile orbitalShot;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<LimeGuonStone>("Lime Guon Stone", "Bright and Trig", "Releases orbital energy when struck. \n\nThis guon stone has been somewhat overenchanted, and is unable to fully constrain all of it's rotational magic.", "limeguonstone_icon", assetbundle: true);
		AdvancedPlayerOrbitalItem val = (AdvancedPlayerOrbitalItem)(object)((obj is AdvancedPlayerOrbitalItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		val.OrbitalPrefab = ItemSetup.CreateOrbitalObject("Lime Guon Stone", "limeguonstone_ingame", new IntVector2(8, 8), new IntVector2(-4, -4), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0).GetComponent<PlayerOrbital>();
		((Component)val.OrbitalPrefab).gameObject.AddComponent<LimeGuonStoneController>();
		AlexandriaTags.SetTag((PickupObject)(object)val, "guon_stone");
		val.HasAdvancedUpgradeSynergy = true;
		val.AdvancedUpgradeSynergy = "Limer Guon Stone";
		val.AdvancedUpgradeOrbitalPrefab = ItemSetup.CreateOrbitalObject("Limer Guon Stone", "limeguonstone_synergy", new IntVector2(12, 12), new IntVector2(-6, -6), null, 2.5f, 120f, 0, (OrbitalMotionStyle)0, 10f);
		val.AdvancedUpgradeOrbitalPrefab.AddComponent<LimeGuonStoneController>();
		orbitalShot = ProjectileUtility.InstantiateAndFakeprefab(((Gun)PickupObjectDatabase.GetById(86)).DefaultModule.projectiles[0]);
		orbitalShot.SetProjectileSprite("limebullet", 5, 5, lightened: true, (Anchor)4, 3, 3, anchorChangesCollider: true, fixesScale: false, null, null);
		orbitalShot.baseData.range = 1000f;
		((Component)orbitalShot).gameObject.AddComponent<PierceProjModifier>();
		((Component)orbitalShot).gameObject.AddComponent<PierceDeadActors>();
	}
}
