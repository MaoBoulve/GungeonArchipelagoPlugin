using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class SpacersFancy : AdvancedGunBehavior
{
	public static int ID;

	public int timesPurchased;

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Spacers Fancy", "spacersfancy");
		Game.Items.Rename("outdated_gun_mods:spacers_fancy", "nn:spacers_fancy");
		((Component)val).gameObject.AddComponent<SpacersFancy>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Not the Best Choice");
		GunExt.SetLongDescription((PickupObject)(object)val, "A cheaply made sidearm from a far flung solar system.\n\nBecomes stronger each time it's slinger basks in the light of glorious commerce.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "spacersfancy_idle_001", 8, "spacersfancy_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 0);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.9f;
		val.DefaultModule.cooldownTime = 0.14f;
		val.DefaultModule.numberOfShotsInClip = 9;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5625f, 0.8125f, 0f);
		val.SetBaseMaxAmmo(330);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.2f;
		val2.SetProjectileSprite("spacersfancy_proj", 9, 4, lightened: true, (Anchor)4, 9, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= (float)timesPurchased * 0.1f + 1f;
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Mag-2-Zap"))
		{
			projectile.AppliesStun = true;
			projectile.StunApplyChance += (float)timesPurchased * 0.1f;
			projectile.AppliedStunDuration = 1f;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void Purchase(PlayerController player, ShopItemController item)
	{
		timesPurchased++;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.OnItemPurchased += Purchase;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnItemPurchased -= Purchase;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			GunTools.GunPlayerOwner(base.gun).OnItemPurchased -= Purchase;
		}
		((BraveBehaviour)this).OnDestroy();
	}
}
