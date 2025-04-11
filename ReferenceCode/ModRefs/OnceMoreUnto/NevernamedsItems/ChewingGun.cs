using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ChewingGun : GunBehaviour
{
	public static int ID;

	public static GameObject popVFX;

	public static GameObject gummedVFX;

	public float timeSinceBazooka;

	public static void Add()
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Chewing Gun", "chewinggun");
		Game.Items.Rename("outdated_gun_mods:chewing_gun", "nn:chewing_gun");
		ChewingGun chewingGun = ((Component)val).gameObject.AddComponent<ChewingGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "How does it feel?");
		GunExt.SetLongDescription((PickupObject)(object)val, "Chewing gum is a common method of stress relief among experienced Gungeoneers.\n\nThis great wad has seen many mouths.");
		val.SetGunSprites("chewinggun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		val.AddCustomSwitchGroup("NN_WPN_ChewingGun", "", "Play_ENM_blobulord_bubble_01");
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId = PickupObjectDatabase.GetById(599);
		muzzleFlashEffects = ((Gun)((byId is Gun) ? byId : null)).muzzleFlashEffects;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.025f;
		val.DefaultModule.numberOfShotsInClip = 400;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.9375f, 1.3125f, 0f);
		val.SetBaseMaxAmmo(5000);
		val.ammo = 5000;
		val.gunClass = (GunClass)50;
		val.doesScreenShake = false;
		val.IgnoresAngleQuantization = true;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 35f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.5f;
		val2.baseData.range = 1E+12f;
		val2.AdditionalScaleMultiplier = 0.1f;
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(15);
		hitEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0].hitEffects;
		val2.pierceMinorBreakables = true;
		BounceProjModifier val3 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val3.numberOfBounces = 5;
		val2.hitEffects = new ProjectileImpactVFXPool();
		((Component)val2).gameObject.AddComponent<ChewingGunProjectile>();
		ProjectileBuilders.AnimateProjectileBundle(val2, "ChewingGumProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "ChewingGumProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(80, 80), 4), MiscTools.DupeList(value: false, 8), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Chewing Gun Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/chewinggun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/smoker_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		popVFX = VFXToolbox.CreateVFXBundle("GumExplosion", new IntVector2(71, 71), (Anchor)4, usesZHeight: true, 0.4f, -1f, null);
		gummedVFX = VFXToolbox.CreateVFXBundle("GummedEffect", new IntVector2(21, 17), (Anchor)1, usesZHeight: true, 0.4f, -1f, null, persist: true);
		gummedVFX.AddComponent<GumPile>();
	}

	public override void OnPlayerPickup(PlayerController playerOwner)
	{
		((GunBehaviour)this).OnPlayerPickup(playerOwner);
		playerOwner.OnUsedPlayerItem += ActiveItemUsed;
	}

	public override void DisableEffectPlayer(PlayerController player)
	{
		player.OnUsedPlayerItem -= ActiveItemUsed;
		((GunBehaviour)this).DisableEffectPlayer(player);
	}

	private void ActiveItemUsed(PlayerController player, PlayerItem item)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		if (((PickupObject)item).PickupObjectId != 203 || !CustomSynergies.PlayerHasActiveSynergy(player, "Addiction Breaker"))
		{
			return;
		}
		GameObject val = SpawnManager.SpawnVFX(popVFX, Vector2.op_Implicit(((BraveBehaviour)player).specRigidbody.UnitCenter), Quaternion.identity);
		AkSoundEngine.PostEvent("Play_MouthPopSound", ((Component)this).gameObject);
		List<AIActor> activeEnemies = player.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val2 = activeEnemies[i];
			if (val2.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val2).healthHaver) && ((BraveBehaviour)val2).healthHaver.IsAlive)
			{
				((BraveBehaviour)val2).healthHaver.ApplyDamage(5f, Vector2.zero, "Gum", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)val2).behaviorSpeculator))
				{
					((BraveBehaviour)val2).behaviorSpeculator.Stun(2f, true);
				}
				GameObject val3 = SpawnManager.SpawnVFX(gummedVFX, true);
				tk2dBaseSprite component = val3.GetComponent<tk2dBaseSprite>();
				val3.transform.position = Vector2.op_Implicit(new Vector2(((BraveBehaviour)val2).sprite.WorldBottomCenter.x + 0.5f, ((BraveBehaviour)val2).sprite.WorldBottomCenter.y));
				val3.transform.parent = ((BraveBehaviour)val2).transform;
				component.HeightOffGround = 0.2f;
				((BraveBehaviour)val2).sprite.AttachRenderer(component);
				GumPile component2 = val3.GetComponent<GumPile>();
				if (Object.op_Implicit((Object)(object)component2))
				{
					component2.lifetime = 20f;
					component2.target = ((BraveBehaviour)val2).specRigidbody;
				}
			}
		}
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manual)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		((GunBehaviour)this).OnReloadPressed(player, gun, manual);
		if (gun.ClipShotsRemaining != 0 || !CustomSynergies.PlayerHasActiveSynergy(player, "Bazooka Joe") || !(timeSinceBazooka <= 0f))
		{
			return;
		}
		timeSinceBazooka = 2f;
		PickupObject byId = PickupObjectDatabase.GetById(NNBazooka.BazookaID);
		Projectile val = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
		GameObject val2 = ProjectileUtility.InstantiateAndFireInDirection(val, Vector2.op_Implicit(gun.barrelOffset.position), gun.CurrentAngle, 0f, (PlayerController)null);
		Projectile component = val2.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)player;
			component.Shooter = ((BraveBehaviour)player).specRigidbody;
			component.ScaleByPlayerStats(player);
			player.DoPostProcessProjectile(component);
			((Component)component).GetComponent<FuckingExplodeYouCunt>().spawnedBySynergy = true;
			HomingModifier val3 = ((Component)component).gameObject.GetComponent<HomingModifier>();
			if ((Object)(object)val3 == (Object)null)
			{
				val3 = ((Component)component).gameObject.AddComponent<HomingModifier>();
				val3.HomingRadius = 0f;
				val3.AngularVelocity = 0f;
			}
			HomingModifier obj = val3;
			obj.HomingRadius += 7f;
			HomingModifier obj2 = val3;
			obj2.AngularVelocity += 360f;
		}
	}

	public override void Update()
	{
		((GunBehaviour)this).Update();
		if (timeSinceBazooka > 0f)
		{
			timeSinceBazooka -= BraveTime.DeltaTime;
		}
	}
}
