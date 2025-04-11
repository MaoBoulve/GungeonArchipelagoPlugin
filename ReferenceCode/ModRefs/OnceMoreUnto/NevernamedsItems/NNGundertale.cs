using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.Assetbundle;
using Alexandria.EnemyAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class NNGundertale : AdvancedGunBehavior
{
	public static List<int> lootIDlist = new List<int> { 78, 600, 565, 73, 85, 120 };

	public static void Add()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gundertale", "gundertale");
		Game.Items.Rename("outdated_gun_mods:gundertale", "nn:gundertale");
		NNGundertale nNGundertale = ((Component)val).gameObject.AddComponent<NNGundertale>();
		((AdvancedGunBehavior)nNGundertale).preventNormalFireAudio = true;
		((AdvancedGunBehavior)nNGundertale).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Filled With Determination");
		GunExt.SetLongDescription((PickupObject)(object)val, "Doesnt shoot. Befriends your enemies with your masterful dodges.\n\nAn antique Revolver. On days like these...");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "gundertale_idle_001", 8, "gundertale_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 0;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1E+10f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.5f, 0.68f, 0f);
		val.SetBaseMaxAmmo(50);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0f;
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		val.AddClipSprites("gundertale");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	protected override void Update()
	{
		if ((Object)(object)base.gun != (Object)null && base.gun.DefaultModule != null && base.gun.RuntimeModuleData != null && base.gun.RuntimeModuleData.ContainsKey(base.gun.DefaultModule) && !base.gun.RuntimeModuleData[base.gun.DefaultModule].onCooldown)
		{
			base.gun.RuntimeModuleData[base.gun.DefaultModule].onCooldown = true;
		}
		((AdvancedGunBehavior)this).Update();
	}

	private bool DetermineCanMakeNPC(AIActor target)
	{
		CustomEnemyTagsSystem component = ((Component)target).gameObject.GetComponent<CustomEnemyTagsSystem>();
		if ((Object)(object)component != (Object)null && component.isGundertaleFriendly)
		{
			return false;
		}
		if (!((BraveBehaviour)target).healthHaver.IsBoss)
		{
			Gun currentGun = base.gun.CurrentOwner.CurrentGun;
			if (Object.op_Implicit((Object)(object)currentGun) && (Object)(object)currentGun == (Object)(object)base.gun && currentGun.CurrentAmmo > 0 && currentGun.ClipShotsRemaining > 0)
			{
				currentGun.CurrentAmmo -= 1;
				currentGun.ClipShotsRemaining -= 1;
				return true;
			}
			return false;
		}
		return false;
	}

	private void onDodgeRolledOverBullet(Projectile bullet)
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && GunTools.IsCurrentGun(base.gun) && !base.gun.IsReloading && Object.op_Implicit((Object)(object)bullet.Owner) && bullet.Owner is AIActor && DetermineCanMakeNPC((AIActor)/*isinst with value type is only supported in some contexts*/))
		{
			MakeEnemyNPC(((BraveBehaviour)bullet.Owner).aiActor);
		}
	}

	private void onDodgeRolledIntoEnemy(PlayerController player, AIActor enemy)
	{
		if ((Object)(object)base.gun.CurrentOwner.CurrentGun == (Object)(object)base.gun && Object.op_Implicit((Object)(object)enemy) && enemy != null && DetermineCanMakeNPC(enemy))
		{
			((BraveBehaviour)enemy).healthHaver.flashesOnDamage = false;
			((BraveBehaviour)((BraveBehaviour)enemy).healthHaver).RegenerateCache();
			MakeEnemyNPC(((BraveBehaviour)enemy).aiActor);
		}
	}

	private void HandleSpawnLoot(AIActor enemy)
	{
		Type typeFromHandle = typeof(AIActor);
		MethodInfo method = typeFromHandle.GetMethod("HandleRewards", BindingFlags.Instance | BindingFlags.NonPublic);
		object obj = method.Invoke(enemy, null);
	}

	private void MakeEnemyNPC(AIActor enemy)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_OBJ_enemy_charmed_01", ((Component)base.gun).gameObject);
		HandleSpawnLoot(enemy);
		RoomHandler absoluteRoom = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)enemy).transform.position);
		Object.Instantiate<GameObject>(SharedVFX.GundetaleSpareVFX, Vector2.op_Implicit(((BraveBehaviour)enemy).sprite.WorldTopCenter + new Vector2(0f, 0.25f)), Quaternion.identity);
		if (Object.op_Implicit((Object)(object)((Component)enemy).GetComponent<KillOnRoomUnseal>()))
		{
			Object.Destroy((Object)(object)((Component)enemy).GetComponent<KillOnRoomUnseal>());
		}
		absoluteRoom.DeregisterEnemy(enemy, false);
		CustomEnemyTagsSystem orAddComponent = GameObjectExtensions.GetOrAddComponent<CustomEnemyTagsSystem>(((Component)enemy).gameObject);
		AIActorUtility.DeleteOwnedBullets(((BraveBehaviour)enemy).gameActor, 1f, false);
		if ((Object)(object)orAddComponent != (Object)null)
		{
			orAddComponent.isGundertaleFriendly = true;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).specRigidbody))
		{
			Object.Destroy((Object)(object)((BraveBehaviour)enemy).specRigidbody);
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).behaviorSpeculator))
		{
			Object.Destroy((Object)(object)((BraveBehaviour)enemy).behaviorSpeculator);
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver))
		{
			((BraveBehaviour)enemy).healthHaver.IsVulnerable = false;
			((BraveBehaviour)enemy).healthHaver.bossHealthBar = (BossBarType)0;
			((BraveBehaviour)enemy).healthHaver.EndBossState(false);
		}
		if (Object.op_Implicit((Object)(object)((Component)enemy).gameObject.GetComponent<FloatingEyeController>()))
		{
			Object.Destroy((Object)(object)((Component)enemy).gameObject.GetComponent<FloatingEyeController>());
		}
		if (Object.op_Implicit((Object)(object)((Component)enemy).gameObject.GetComponent<CrazedController>()))
		{
			Object.Destroy((Object)(object)((Component)enemy).gameObject.GetComponent<CrazedController>());
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiAnimator))
		{
			((BraveBehaviour)enemy).aiAnimator.PlayUntilCancelled("idle", false, (string)null, -1f, false);
		}
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		player.OnDodgedProjectile += onDodgeRolledOverBullet;
		player.OnRolledIntoEnemy += onDodgeRolledIntoEnemy;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.OnDodgedProjectile -= onDodgeRolledOverBullet;
		player.OnRolledIntoEnemy -= onDodgeRolledIntoEnemy;
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			GunTools.GunPlayerOwner(base.gun).OnDodgedProjectile -= onDodgeRolledOverBullet;
			GunTools.GunPlayerOwner(base.gun).OnRolledIntoEnemy -= onDodgeRolledIntoEnemy;
		}
		((BraveBehaviour)this).OnDestroy();
	}
}
