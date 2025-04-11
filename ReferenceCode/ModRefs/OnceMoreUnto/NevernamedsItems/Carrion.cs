using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Carrion : AdvancedGunBehavior
{
	public static int CarrionForme1ID;

	public static int CarrionForme2ID;

	public static int CarrionForme3ID;

	private int currentForme;

	private int enemiesKilledSinceTransform;

	public static Projectile EscapingWigglerProjectile;

	private int enemieskilledlastCheck;

	private List<BeamController> ExtantBeams = new List<BeamController>();

	public static void Add()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("CARRION", "carrion2");
		Game.Items.Rename("outdated_gun_mods:carrion", "nn:carrion");
		Carrion carrion = ((Component)val).gameObject.AddComponent<Carrion>();
		((AdvancedGunBehavior)carrion).preventNormalFireAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Fresh Meat");
		GunExt.SetLongDescription((PickupObject)(object)val, "A wormlike colony of bizarre organisms. Unknown origin.\n\nIt has three base desires. \nTo grow. \nTo Spread. \nTo Feed.");
		val.SetGunSprites("carrion2");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 13);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 13);
		val.isAudioLoop = true;
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.doesScreenShake = false;
		val.DefaultModule.ammoCost = 5;
		val.DefaultModule.shootStyle = (ShootStyle)2;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.cooldownTime = 0.001f;
		val.DefaultModule.numberOfShotsInClip = 600;
		val.DefaultModule.ammoType = (AmmoType)2;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.75f, 0.56f, 0f);
		val.SetBaseMaxAmmo(600);
		val.ammo = 600;
		val.gunClass = (GunClass)50;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 0;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_mid_001", new Vector2(4f, 2f), new Vector2(0f, 1f), new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_mid_001" }, 13, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_end_001" }, 13, (Vector2?)new Vector2(6f, 2f), (Vector2?)new Vector2(0f, 1f), new List<string> { "NevernamedsItems/Resources/BeamSprites/carrionsubtendril_start_001" }, 13, (Vector2?)new Vector2(7f, 2f), (Vector2?)new Vector2(0f, 1f), 0f, 0f);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 10f;
		ProjectileData baseData = val2.baseData;
		baseData.force *= 1f;
		val2.baseData.range = 3.5f;
		val3.ProjectileAndBeamMotionModule = (ProjectileAndBeamMotionModule)new HelixProjectileMotionModule();
		val3.boneType = (BeamBoneType)2;
		val3.penetration = 1;
		val3.homingRadius = 10f;
		val3.homingAngularVelocity = 1000f;
		CarrionSubTendrilController carrionSubTendrilController = ((Component)val2).gameObject.AddComponent<CarrionSubTendrilController>();
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/carrion2_mid_001", "NevernamedsItems/Resources/BeamSprites/carrion2_mid_002", "NevernamedsItems/Resources/BeamSprites/carrion2_mid_003", "NevernamedsItems/Resources/BeamSprites/carrion2_mid_004", "NevernamedsItems/Resources/BeamSprites/carrion2_mid_005" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/carrion2_end_001", "NevernamedsItems/Resources/BeamSprites/carrion2_end_002", "NevernamedsItems/Resources/BeamSprites/carrion2_end_003", "NevernamedsItems/Resources/BeamSprites/carrion2_end_004", "NevernamedsItems/Resources/BeamSprites/carrion2_end_005" };
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		BasicBeamController val5 = BeamAPI.GenerateBeamPrefab(val4, "NevernamedsItems/Resources/BeamSprites/carrion2_mid_001", new Vector2(16f, 5f), new Vector2(0f, 6f), list, 13, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, list2, 13, (Vector2?)new Vector2(10f, 5f), (Vector2?)new Vector2(0f, 6f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		val4.baseData.damage = 30f;
		ProjectileData baseData2 = val4.baseData;
		baseData2.force *= 1f;
		val4.baseData.range = 8f;
		ProjectileData baseData3 = val4.baseData;
		baseData3.speed *= 3f;
		val5.boneType = (BeamBoneType)2;
		val5.startAudioEvent = "Play_WPN_demonhead_shot_01";
		val5.endAudioEvent = "Stop_WPN_All";
		val5.penetration = 1;
		val5.homingRadius = 5f;
		val5.homingAngularVelocity = 300f;
		CarrionMainTendrilController carrionMainTendrilController = ((Component)val4).gameObject.AddComponent<CarrionMainTendrilController>();
		carrionMainTendrilController.subTendrilPrefab = ((Component)val2).gameObject;
		val.DefaultModule.projectiles[0] = val4;
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		Projectile val6 = (Projectile)(object)DataCloners.CopyFields<HelixProjectile>(Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]));
		((Component)val6).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val6).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val6);
		ProjectileData baseData4 = val6.baseData;
		baseData4.speed *= 1f;
		val6.baseData.damage = 20f;
		ProjectileData baseData5 = val6.baseData;
		baseData5.range *= 10f;
		HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)val6).gameObject);
		orAddComponent.HomingRadius = 10f;
		orAddComponent.AngularVelocity = 200f;
		PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val6).gameObject);
		orAddComponent2.penetratesBreakables = true;
		orAddComponent2.penetration++;
		val6.SetProjectileSprite("carrion_wiggler", 5, 5, lightened: true, (Anchor)4, 5, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		EasyTrailBullet easyTrailBullet = ((Component)val6).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val4).transform.position);
		easyTrailBullet.StartWidth = 0.31f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 0.3f;
		easyTrailBullet.BaseColor = ExtendedColours.carrionRed;
		easyTrailBullet.EndColor = ExtendedColours.carrionRed;
		EscapingWigglerProjectile = val6;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Carrion Clip";
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		CarrionForme1ID = ((PickupObject)val).PickupObjectId;
	}

	private void ModifyIncomingPlayerDamage(HealthHaver player, ModifyDamageEventArgs args)
	{
		ETGModConsole.Log((object)"ModifyIncomingDamage Ran", false);
		if (args.InitialDamage > 0f && currentForme > 1)
		{
			ETGModConsole.Log((object)("CurrentForme = " + currentForme), false);
			args.ModifiedDamage = 0f;
			DoEscapingWigglies();
			AkSoundEngine.PostEvent("Play_ENM_bombshee_scream_01", ((Component)base.gun).gameObject);
			if (currentForme == 2)
			{
				SwitchForme(1);
			}
			if (currentForme == 3)
			{
				SwitchForme(2);
			}
			ETGModConsole.Log((object)("CurrentForme After = " + currentForme), false);
			if (((BraveBehaviour)player).gameActor is PlayerController)
			{
				GameActor gameActor = ((BraveBehaviour)player).gameActor;
				PlayerUtility.TriggerInvulnerableFrames((PlayerController)(object)((gameActor is PlayerController) ? gameActor : null), 1f);
			}
		}
	}

	private void SwitchForme(int targetForme)
	{
		if (targetForme <= 0 || targetForme >= 4)
		{
			return;
		}
		currentForme = targetForme;
		enemiesKilledSinceTransform = 0;
		switch (targetForme)
		{
		case 1:
		{
			_003F val3 = base.gun;
			PickupObject byId3 = PickupObjectDatabase.GetById(CarrionForme1ID);
			((Gun)val3).TransformToTargetGun((Gun)(object)((byId3 is Gun) ? byId3 : null));
			break;
		}
		case 2:
		{
			_003F val2 = base.gun;
			PickupObject byId2 = PickupObjectDatabase.GetById(CarrionForme2ID);
			((Gun)val2).TransformToTargetGun((Gun)(object)((byId2 is Gun) ? byId2 : null));
			break;
		}
		case 3:
		{
			_003F val = base.gun;
			PickupObject byId = PickupObjectDatabase.GetById(CarrionForme3ID);
			((Gun)val).TransformToTargetGun((Gun)(object)((byId is Gun) ? byId : null));
			break;
		}
		}
		int num = ExtantBeams.Count();
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			if ((Object)(object)ExtantBeams[num2] != (Object)null)
			{
				ExtantBeams[num2].CeaseAttack();
			}
		}
		ExtantBeams.Clear();
	}

	private void DoEscapingWigglies()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		int num = Random.Range(5, 11);
		for (int i = 0; i < num; i++)
		{
			GameObject val = SpawnManager.SpawnProjectile(((Component)EscapingWigglerProjectile).gameObject, Vector2.op_Implicit(((tk2dBaseSprite)((Component)base.gun).GetComponent<tk2dSprite>()).WorldCenter), Quaternion.Euler(0f, 0f, (float)Random.Range(1, 360)), true);
			Projectile component = val.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)GunTools.GunPlayerOwner(base.gun);
				component.Shooter = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).specRigidbody;
				ProjectileData baseData = component.baseData;
				baseData.damage *= GunTools.GunPlayerOwner(base.gun).stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= GunTools.GunPlayerOwner(base.gun).stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.force *= GunTools.GunPlayerOwner(base.gun).stats.GetStatValue((StatType)12);
				component.AdditionalScaleMultiplier *= GunTools.GunPlayerOwner(base.gun).stats.GetStatValue((StatType)15);
				component.UpdateSpeed();
				GunTools.GunPlayerOwner(base.gun).DoPostProcessProjectile(component);
			}
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			enemiesKilledSinceTransform = 0;
		}
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyIncomingPlayerDamage));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyIncomingPlayerDamage));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			HealthHaver healthHaver = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyIncomingPlayerDamage));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	protected override void PostProcessBeam(BeamController beam)
	{
		Projectile projectile = ((BraveBehaviour)beam).projectile;
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		if (Object.op_Implicit((Object)(object)((Component)beam).GetComponent<CarrionMainTendrilController>()))
		{
			((Component)beam).GetComponent<CarrionMainTendrilController>().forme = currentForme;
			ExtantBeams.Add(beam);
		}
		((AdvancedGunBehavior)this).PostProcessBeam(beam);
	}

	private void OnHitEnemy(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Object.op_Implicit((Object)(object)proj) && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && fatal)
		{
			enemiesKilledSinceTransform++;
		}
	}

	public void FixedUpdate()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (currentForme > 1 && base.gun.IsFiring)
		{
			float num = 2f;
			if (currentForme == 3)
			{
				num = 4f;
			}
			if (Object.op_Implicit((Object)(object)((AdvancedGunBehavior)this).Owner))
			{
				((BraveBehaviour)((AdvancedGunBehavior)this).Owner).knockbackDoer.ApplyKnockback(MathsAndLogicHelper.DegreeToVector2(base.gun.CurrentAngle), num, false);
			}
		}
	}

	protected override void Update()
	{
		if (currentForme == 0)
		{
			currentForme = 1;
		}
		if (currentForme == 1 && enemiesKilledSinceTransform >= 30)
		{
			SwitchForme(2);
		}
		if (currentForme == 2 && enemiesKilledSinceTransform >= 60)
		{
			SwitchForme(3);
		}
		if (enemieskilledlastCheck != enemiesKilledSinceTransform)
		{
			enemieskilledlastCheck = enemiesKilledSinceTransform;
		}
		((AdvancedGunBehavior)this).Update();
	}
}
