using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Viscerifle : AdvancedGunBehavior
{
	public static Projectile armourProjectile;

	public static Projectile crestProjectile;

	public static Projectile fuckyouprojectile;

	public static Projectile shadeProjectile;

	private float currentHP;

	private float lastHP;

	private float currentArmour;

	private float lastArmour;

	private bool currentHasCrest;

	private bool lastHasCrest;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Viscerifle", "viscerifle");
		Game.Items.Rename("outdated_gun_mods:viscerifle", "nn:viscerifle");
		((Component)val).gameObject.AddComponent<Viscerifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bloody Stream");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires hearts and armour as ammunition.\n\nThis, by definition, is not a rifle. The name is purely marketing.\n\nFires nothing if fired while invincible.");
		val.SetGunSprites("viscerifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 0;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 10;
		val.CanGainAmmo = false;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.5f, 0.81f, 0f);
		val.SetBaseMaxAmmo(0);
		val.gunClass = (GunClass)55;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 20f;
		val2.pierceMinorBreakables = true;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		val2.ignoreDamageCaps = true;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 10f;
		val2.SetProjectileSprite("viscerifle_heart_projectile", 16, 7, lightened: false, (Anchor)4, 16, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.goopDefinition = EasyGoopDefinitions.BlobulonGoopDef;
		val3.SpawnGoopInFlight = true;
		val3.InFlightSpawnFrequency = 0.05f;
		val3.InFlightSpawnRadius = 1f;
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 2f;
		shadeProjectile = ProjectileSetupUtility.MakeProjectile(56, 20f, 35f, 23f);
		shadeProjectile.SetProjectileSprite("shadeviscerifle_proj", 16, 7, lightened: false, (Anchor)4, 16, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		armourProjectile = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)armourProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)armourProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)armourProjectile);
		ProjectileData baseData4 = armourProjectile.baseData;
		baseData4.damage *= 24f;
		armourProjectile.ignoreDamageCaps = true;
		ProjectileData baseData5 = armourProjectile.baseData;
		baseData5.speed *= 1f;
		ProjectileData baseData6 = armourProjectile.baseData;
		baseData6.range *= 10f;
		armourProjectile.pierceMinorBreakables = true;
		armourProjectile.SetProjectileSprite("viscerifle_armour_projectile", 12, 8, lightened: false, (Anchor)4, 12, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)armourProjectile).transform.parent = val.barrelOffset;
		BlankProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BlankProjModifier>(((Component)armourProjectile).gameObject);
		orAddComponent.blankType = (EasyBlankType)0;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		crestProjectile = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)crestProjectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)crestProjectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)crestProjectile);
		crestProjectile.ignoreDamageCaps = true;
		ProjectileData baseData7 = crestProjectile.baseData;
		baseData7.damage *= 1000f;
		ProjectileData baseData8 = crestProjectile.baseData;
		baseData8.speed *= 1f;
		ProjectileData baseData9 = crestProjectile.baseData;
		baseData9.range *= 10f;
		crestProjectile.pierceMinorBreakables = true;
		crestProjectile.SetProjectileSprite("viscerifle_crest_projectile", 12, 9, lightened: false, (Anchor)4, 12, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)crestProjectile).transform.parent = val.barrelOffset;
		BlankProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BlankProjModifier>(((Component)crestProjectile).gameObject);
		orAddComponent2.blankType = (EasyBlankType)0;
		BounceProjModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)crestProjectile).gameObject);
		orAddComponent3.numberOfBounces = 1;
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		fuckyouprojectile = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)fuckyouprojectile).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)fuckyouprojectile).gameObject);
		Object.DontDestroyOnLoad((Object)(object)fuckyouprojectile);
		ProjectileData baseData10 = fuckyouprojectile.baseData;
		baseData10.damage *= 0f;
		ProjectileData baseData11 = fuckyouprojectile.baseData;
		baseData11.speed *= 0f;
		ProjectileData baseData12 = fuckyouprojectile.baseData;
		baseData12.range *= 0f;
		DieFuckYou orAddComponent4 = GameObjectExtensions.GetOrAddComponent<DieFuckYou>(((Component)fuckyouprojectile).gameObject);
		((BraveBehaviour)((BraveBehaviour)fuckyouprojectile).sprite).renderer.enabled = false;
		((BraveBehaviour)fuckyouprojectile).transform.parent = val.barrelOffset;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Viscerifle";
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_VISCERIFLE, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToGooptonMetaShop(23, null);
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		GameActor currentOwner = gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		PlayableCharacters characterIdentity = val.characterIdentity;
		return (Projectile)(DeterminedUsedHealth(val) switch
		{
			"heart" => projectile, 
			"armour" => armourProjectile, 
			"crest" => crestProjectile, 
			"shade" => shadeProjectile, 
			_ => projectile, 
		});
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.2f;
		if (((double)((BraveBehaviour)player).healthHaver.GetCurrentHealth() == 0.5 && ((BraveBehaviour)player).healthHaver.Armor == 0f) || (player.HasPickupID(Game.Items["nn:meat_shield"].PickupObjectId) && ((BraveBehaviour)player).healthHaver.GetCurrentHealth() == 0f && ((BraveBehaviour)player).healthHaver.Armor == 1f && !player.HasPickupID(Game.Items["old_crest"].PickupObjectId)))
		{
			num = 0.5f;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Danger Is My Middle Name") && Random.value <= num)
		{
			return;
		}
		if (((Object)player).name != "PlayerShade(Clone)")
		{
			switch (DeterminedUsedHealth(player))
			{
			case "heart":
				((BraveBehaviour)player).healthHaver.ApplyHealing(-0.5f);
				break;
			case "armour":
			{
				HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
				healthHaver.Armor -= 1f;
				break;
			}
			case "crest":
				player.RemovePassiveItem(305);
				break;
			}
			if (((BraveBehaviour)player).healthHaver.GetCurrentHealth() == 0f && ((BraveBehaviour)player).healthHaver.Armor == 0f)
			{
				((BraveBehaviour)player).healthHaver.Die(Vector2.zero);
			}
		}
		else if (((Object)player).name == "PlayerShade(Clone)" && player.HasPickupID(305))
		{
			player.RemovePassiveItem(305);
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			if (GunTools.GunPlayerOwner(base.gun).CharacterUsesRandomGuns)
			{
				GunTools.GunPlayerOwner(base.gun).ChangeToRandomGun();
			}
			ref bool reference = ref currentHasCrest;
			GameActor currentOwner = base.gun.CurrentOwner;
			reference = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).HasPickupID(305);
			currentArmour = ((BraveBehaviour)base.gun.CurrentOwner).healthHaver.Armor;
			currentHP = ((BraveBehaviour)base.gun.CurrentOwner).healthHaver.GetCurrentHealth();
			if (currentHP != lastHP || currentArmour != lastArmour || currentHasCrest != lastHasCrest)
			{
				GameActor currentOwner2 = base.gun.CurrentOwner;
				RecalculateClip((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null));
			}
			lastHP = currentHP;
			lastArmour = currentArmour;
			lastHasCrest = currentHasCrest;
			if (base.gun.CurrentAmmo == 0 || base.gun.DefaultModule.numberOfShotsInClip != base.gun.CurrentAmmo)
			{
				GameActor currentOwner3 = base.gun.CurrentOwner;
				RecalculateClip((PlayerController)(object)((currentOwner3 is PlayerController) ? currentOwner3 : null));
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void RecalculateClip(PlayerController gunOwner)
	{
		int num = Convert.ToInt32(((BraveBehaviour)gunOwner).healthHaver.GetCurrentHealth() * 2f);
		int num2 = Convert.ToInt32(((BraveBehaviour)gunOwner).healthHaver.Armor);
		int num3 = num + num2;
		if (gunOwner.HasPickupID(305))
		{
			num3++;
		}
		base.gun.CurrentAmmo = num3;
		base.gun.DefaultModule.numberOfShotsInClip = num3;
		base.gun.ClipShotsRemaining = num3;
	}

	private string DeterminedUsedHealth(PlayerController player)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (player.characterIdentity == OMITBChars.Shade)
		{
			return "shade";
		}
		if (player.HasPickupID(Game.Items["nn:meat_shield"].PickupObjectId))
		{
			if (((BraveBehaviour)player).healthHaver.GetCurrentHealth() > 0f)
			{
				return "heart";
			}
			if (player.HasPickupID(305))
			{
				return "crest";
			}
			return "armour";
		}
		if (((BraveBehaviour)player).healthHaver.Armor > 0f)
		{
			if (player.HasPickupID(305))
			{
				return "crest";
			}
			return "armour";
		}
		return "heart";
	}
}
