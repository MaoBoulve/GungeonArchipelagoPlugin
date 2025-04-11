using System;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class G20 : AdvancedGunBehavior
{
	public static int G20ID;

	private int ClipSize = -1;

	private float CooldownTime = -1f;

	private float damageMod = 1f;

	private float rangeMod = 1f;

	private float speedMod = 1f;

	private float knockbackMod = 1f;

	private float scaleMod = 1f;

	public static void Add()
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("G20", "g20");
		Game.Items.Rename("outdated_gun_mods:g20", "nn:g20");
		((Component)val).gameObject.AddComponent<G20>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Roll and Die");
		GunExt.SetLongDescription((PickupObject)(object)val, "Randomises stats upon entering combat.\n\nThe preferred weapon of a young disciple of Icosahedrax, stolen by his michevious nephew.");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "g20_idle_001", 8);
		GunInt.SetupSprite(val, Initialisation.gunCollection, "g20_idle_001", 14, "g20_ammonomicon_001");
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(38);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(83);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.0625f, 1.125f, 0f);
		val.SetBaseMaxAmmo(350);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 10f;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(519);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects.tileMapVertical.effects[0].effects[0].effect;
		val2.hitEffects.alwaysUseMidair = true;
		ProjectileBuilders.AnimateProjectileBundle(val2, "G20Projectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "G20Projectile", MiscTools.DupeList<IntVector2>(new IntVector2(11, 10), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val.AddShellCasing(0, 0, 5, 0, "shell_dice");
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		G20ID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnReloadPressedSafe(PlayerController player, Gun gun, bool manualReload)
	{
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Rerollin Rollin Rollin") && (gun.ClipCapacity == gun.ClipShotsRemaining || gun.CurrentAmmo == gun.ClipShotsRemaining) && gun.CurrentAmmo >= 10)
		{
			gun.CurrentAmmo -= 10;
			EnteredCombat();
		}
		((AdvancedGunBehavior)this).OnReloadPressedSafe(player, gun, manualReload);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(EnteredCombat));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(EnteredCombat));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	protected override void Update()
	{
		if (ClipSize != -1 && base.gun.DefaultModule.numberOfShotsInClip != ClipSize)
		{
			base.gun.DefaultModule.numberOfShotsInClip = ClipSize;
		}
		if (CooldownTime != -1f && base.gun.DefaultModule.cooldownTime != CooldownTime)
		{
			base.gun.DefaultModule.cooldownTime = CooldownTime;
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void EnteredCombat()
	{
		base.gun.reloadTime = Random.Range(10f, 191f) / 100f;
		CooldownTime = (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Critical Success") ? Random.Range(0.05f, 0.5f) : Random.Range(0.1f, 0.8f));
		ClipSize = Random.Range(1, 31);
		base.gun.DefaultModule.numberOfShotsInClip = ClipSize;
		base.gun.DefaultModule.cooldownTime = CooldownTime;
		damageMod = ((Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Critical Success")) ? Random.Range(0.5f, 2.5f) : Random.Range(0.1f, 2f));
		rangeMod = Random.Range(0.1f, 2f);
		speedMod = Random.Range(0.1f, 2f);
		knockbackMod = Random.Range(0.1f, 2f);
		scaleMod = Random.Range(0.5f, 2f);
		if (GunTools.IsCurrentGun(base.gun))
		{
			AkSoundEngine.PostEvent("Play_OBJ_Chest_Synergy_Slots_01", ((Component)this).gameObject);
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= damageMod;
		ProjectileData baseData2 = projectile.baseData;
		baseData2.force *= knockbackMod;
		ProjectileData baseData3 = projectile.baseData;
		baseData3.speed *= speedMod;
		ProjectileData baseData4 = projectile.baseData;
		baseData4.range *= rangeMod;
		projectile.UpdateSpeed();
		projectile.RuntimeUpdateScale(scaleMod);
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
