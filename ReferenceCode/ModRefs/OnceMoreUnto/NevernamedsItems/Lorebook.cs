using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Lorebook : AdvancedGunBehavior
{
	public static int LorebookID;

	public static void Add()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Lorebook", "lorebook");
		Game.Items.Rename("outdated_gun_mods:lorebook", "nn:lorebook");
		Lorebook lorebook = ((Component)val).gameObject.AddComponent<Lorebook>();
		((AdvancedGunBehavior)lorebook).preventNormalFireAudio = true;
		((AdvancedGunBehavior)lorebook).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)lorebook).overrideNormalFireAudio = "Play_ENM_wizard_summon_01";
		((AdvancedGunBehavior)lorebook).overrideNormalReloadAudio = "Play_ENM_book_blast_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Party Cohesion");
		GunExt.SetLongDescription((PickupObject)(object)val, "Summons brave and noble bullet warriors of several different classes to destroy everything in sight and wreak havoc.\n(Like real heroes!)\n\nThis magical tome of stories and scenarios was stolen from one of the most evil creatures in the Gungeon; a Lore Gunjurer.");
		val.SetGunSprites("lorebook");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 18);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.6f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 4;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.87f, 0f);
		val.SetBaseMaxAmmo(110);
		val.gunClass = (GunClass)50;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.7f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 5f;
		val2.SetProjectileSprite("smallspark_projectile", 7, 7, lightened: true, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData4 = val3.baseData;
		baseData4.damage *= 3f;
		ProjectileData baseData5 = val3.baseData;
		baseData5.speed *= 0.08f;
		ProjectileData baseData6 = val3.baseData;
		baseData6.range *= 5f;
		LorebookFantasyBullet orAddComponent = GameObjectExtensions.GetOrAddComponent<LorebookFantasyBullet>(((Component)val3).gameObject);
		orAddComponent.Class = LorebookFantasyBullet.PartyMember.WIZARD;
		val3.pierceMinorBreakables = true;
		SpawnProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<SpawnProjModifier>(((Component)val3).gameObject);
		orAddComponent2.usesComplexSpawnInFlight = true;
		orAddComponent2.spawnOnObjectCollisions = false;
		orAddComponent2.spawnProjecitlesOnDieInAir = false;
		orAddComponent2.spawnProjectilesOnCollision = false;
		orAddComponent2.spawnProjectilesInFlight = true;
		orAddComponent2.projectileToSpawnInFlight = val2;
		orAddComponent2.inFlightAimAtEnemies = true;
		orAddComponent2.inFlightSpawnCooldown = 1.15f;
		orAddComponent2.numberToSpawnOnCollison = 0;
		orAddComponent2.numToSpawnInFlight = 1;
		orAddComponent2.PostprocessSpawnedProjectiles = true;
		HomingModifier val4 = ((Component)val3).gameObject.AddComponent<HomingModifier>();
		val4.AngularVelocity = 120f;
		val4.HomingRadius = 1000f;
		BounceProjModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val3).gameObject);
		orAddComponent3.numberOfBounces = 10;
		ProjectileBuilders.AnimateProjectileBundle(val3, "LorebookWizardProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "LorebookWizardProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(17, 22), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(11, 16), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val3.shouldFlipHorizontally = true;
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		ProjectileData baseData7 = val5.baseData;
		baseData7.damage *= 4f;
		ProjectileData baseData8 = val5.baseData;
		baseData8.range *= 5f;
		ProjectileData baseData9 = val5.baseData;
		baseData9.speed *= 0.25f;
		LorebookFantasyBullet orAddComponent4 = GameObjectExtensions.GetOrAddComponent<LorebookFantasyBullet>(((Component)val5).gameObject);
		orAddComponent4.Class = LorebookFantasyBullet.PartyMember.BARD;
		val5.pierceMinorBreakables = true;
		HomingModifier val6 = ((Component)val5).gameObject.AddComponent<HomingModifier>();
		val6.AngularVelocity = 120f;
		val6.HomingRadius = 1000f;
		ExtremelySimpleStatusEffectBulletBehaviour extremelySimpleStatusEffectBulletBehaviour = ((Component)val5).gameObject.AddComponent<ExtremelySimpleStatusEffectBulletBehaviour>();
		extremelySimpleStatusEffectBulletBehaviour.usesCharmEffect = true;
		extremelySimpleStatusEffectBulletBehaviour.charmEffect = StaticStatusEffects.charmingRoundsEffect;
		BounceProjModifier orAddComponent5 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val5).gameObject);
		orAddComponent5.numberOfBounces = 10;
		ProjectileBuilders.AnimateProjectileBundle(val5, "LorebookBardProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "LorebookBardProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(16, 15), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(10, 9), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val5.shouldFlipHorizontally = true;
		PickupObject byId5 = PickupObjectDatabase.GetById(86);
		Projectile val7 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val7).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val7).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val7);
		ProjectileData baseData10 = val7.baseData;
		baseData10.damage *= 4f;
		ProjectileData baseData11 = val7.baseData;
		baseData11.speed *= 0.3f;
		ProjectileData baseData12 = val7.baseData;
		baseData12.range *= 5f;
		LorebookFantasyBullet orAddComponent6 = GameObjectExtensions.GetOrAddComponent<LorebookFantasyBullet>(((Component)val7).gameObject);
		orAddComponent6.Class = LorebookFantasyBullet.PartyMember.ROGUE;
		val7.shouldFlipHorizontally = true;
		val7.pierceMinorBreakables = true;
		HomingModifier val8 = ((Component)val7).gameObject.AddComponent<HomingModifier>();
		val8.AngularVelocity = 120f;
		val8.HomingRadius = 1000f;
		BounceProjModifier orAddComponent7 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val7).gameObject);
		orAddComponent7.numberOfBounces = 10;
		GameObject bulletObject = ((BraveBehaviour)EnemyDatabase.GetOrLoadByGuid("56fb939a434140308b8f257f0f447829")).bulletBank.GetBullet("rogue").BulletObject;
		Projectile component = bulletObject.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			TeleportProjModifier component2 = ((Component)component).GetComponent<TeleportProjModifier>();
			if ((Object)(object)component2 != (Object)null)
			{
				PlayerProjectileTeleportModifier playerProjectileTeleportModifier = ((Component)val7).gameObject.AddComponent<PlayerProjectileTeleportModifier>();
				playerProjectileTeleportModifier.teleportVfx = component2.teleportVfx;
				playerProjectileTeleportModifier.teleportCooldown = component2.teleportCooldown;
				playerProjectileTeleportModifier.teleportPauseTime = component2.teleportPauseTime;
				playerProjectileTeleportModifier.trigger = PlayerProjectileTeleportModifier.TeleportTrigger.DistanceFromTarget;
				playerProjectileTeleportModifier.distToTeleport = component2.distToTeleport * 2f;
				playerProjectileTeleportModifier.behindTargetDistance = component2.behindTargetDistance;
				playerProjectileTeleportModifier.leadAmount = component2.leadAmount;
				playerProjectileTeleportModifier.minAngleToTeleport = component2.minAngleToTeleport;
				playerProjectileTeleportModifier.numTeleports = component2.numTeleports;
				playerProjectileTeleportModifier.type = PlayerProjectileTeleportModifier.TeleportType.BehindTarget;
			}
			else
			{
				ETGModConsole.Log((object)"Base Eney TeleportProjModifier was null???", false);
			}
		}
		else
		{
			ETGModConsole.Log((object)"Base Enemy Rogue Bullet had no projectile component???", false);
		}
		ProjectileBuilders.AnimateProjectileBundle(val7, "LorebookRogueProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "LorebookRogueProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(16, 15), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(10, 9), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		Projectile val9 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val9).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val9).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val9);
		ProjectileData baseData13 = val9.baseData;
		baseData13.range *= 5f;
		ProjectileData baseData14 = val9.baseData;
		baseData14.damage *= 5f;
		LorebookFantasyBullet orAddComponent8 = GameObjectExtensions.GetOrAddComponent<LorebookFantasyBullet>(((Component)val9).gameObject);
		orAddComponent8.Class = LorebookFantasyBullet.PartyMember.KNIGHT;
		val9.pierceMinorBreakables = true;
		ProjectileData baseData15 = val9.baseData;
		baseData15.speed *= 0.25f;
		HomingModifier val10 = ((Component)val9).gameObject.AddComponent<HomingModifier>();
		val10.AngularVelocity = 120f;
		val10.HomingRadius = 1000f;
		BounceProjModifier orAddComponent9 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val9).gameObject);
		orAddComponent9.numberOfBounces = 10;
		ProjectileBuilders.AnimateProjectileBundle(val9, "LorebookKnightProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "LorebookKnightProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(19, 15), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(13, 9), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val9.shouldFlipHorizontally = true;
		val.DefaultModule.projectiles[0] = val9;
		val.DefaultModule.projectiles.Add(val3);
		val.DefaultModule.projectiles.Add(val5);
		val.DefaultModule.projectiles.Add(val7);
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		LorebookID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		if (projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			LorebookFantasyBullet component = ((Component)projectile).gameObject.GetComponent<LorebookFantasyBullet>();
			if ((Object)(object)component != (Object)null)
			{
				if (component.Class == LorebookFantasyBullet.PartyMember.KNIGHT)
				{
					if (CustomSynergies.PlayerHasActiveSynergy(val, "Level 20 Fighter"))
					{
						ProjectileData baseData = projectile.baseData;
						baseData.damage *= 1.25f;
						ProjectileData baseData2 = projectile.baseData;
						baseData2.speed *= 1.15f;
						projectile.UpdateSpeed();
						PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)projectile).gameObject);
						orAddComponent.penetration += 5;
						MakeLookLikeJammedBullet(projectile);
					}
				}
				else if (component.Class == LorebookFantasyBullet.PartyMember.ROGUE)
				{
					if (CustomSynergies.PlayerHasActiveSynergy(val, "Level 20 Rogue"))
					{
						ProjectileData baseData3 = projectile.baseData;
						baseData3.damage *= 1.25f;
						ExtremelySimpleStatusEffectBulletBehaviour orAddComponent2 = GameObjectExtensions.GetOrAddComponent<ExtremelySimpleStatusEffectBulletBehaviour>(((Component)projectile).gameObject);
						orAddComponent2.usesPoisonEffect = true;
						orAddComponent2.poisonEffect = StaticStatusEffects.irradiatedLeadEffect;
						MakeLookLikeJammedBullet(projectile);
					}
				}
				else if (component.Class == LorebookFantasyBullet.PartyMember.WIZARD)
				{
					if (CustomSynergies.PlayerHasActiveSynergy(val, "Level 20 Wizard"))
					{
						ProjectileData baseData4 = projectile.baseData;
						baseData4.damage *= 1.25f;
						SpawnProjModifier component2 = ((Component)projectile).gameObject.GetComponent<SpawnProjModifier>();
						if ((Object)(object)component2 != (Object)null)
						{
							component2.inFlightSpawnCooldown = 0.35f;
						}
						MakeLookLikeJammedBullet(projectile);
					}
				}
				else if (component.Class == LorebookFantasyBullet.PartyMember.BARD && CustomSynergies.PlayerHasActiveSynergy(val, "Level 20 Bard"))
				{
					ProjectileData baseData5 = projectile.baseData;
					baseData5.damage *= 1.25f;
					GameActorCharmEffect charmEffect = new GameActorCharmEffect
					{
						duration = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).duration * 3f,
						TintColor = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).TintColor,
						DeathTintColor = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).DeathTintColor,
						effectIdentifier = "Charm",
						AppliesTint = true,
						AppliesDeathTint = true,
						resistanceType = (EffectResistanceType)4,
						OverheadVFX = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).OverheadVFX,
						AffectsEnemies = true,
						AffectsPlayers = false,
						AppliesOutlineTint = false,
						OutlineTintColor = ((GameActorEffect)StaticStatusEffects.charmingRoundsEffect).OutlineTintColor,
						PlaysVFXOnActor = false
					};
					ExtremelySimpleStatusEffectBulletBehaviour component3 = ((Component)projectile).gameObject.GetComponent<ExtremelySimpleStatusEffectBulletBehaviour>();
					component3.charmEffect = charmEffect;
					component3.usesCharmEffect = true;
					MakeLookLikeJammedBullet(projectile);
				}
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public void MakeLookLikeJammedBullet(Projectile bullet)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		bullet.AdjustPlayerProjectileTint(ExtendedColours.maroon, 1, 0f);
	}
}
