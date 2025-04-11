using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ButchersKnife : AdvancedGunBehavior
{
	public static int ButchersKnifeID;

	private float rangeTime = 0f;

	private bool ProjectileReturned = true;

	private bool canAddToRangeTime = true;

	public static void Add()
	{
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Butchers Knife", "butchersknife");
		Game.Items.Rename("outdated_gun_mods:butchers_knife", "nn:butchers_knife");
		ButchersKnife butchersKnife = ((Component)val).gameObject.AddComponent<ButchersKnife>();
		((AdvancedGunBehavior)butchersKnife).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)butchersKnife).preventNormalFireAudio = true;
		((AdvancedGunBehavior)butchersKnife).overrideNormalFireAudio = "Play_WPN_blasphemy_shot_01";
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(417);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetShortDescription((PickupObject)(object)val, "Word of Kaliber");
		GunExt.SetLongDescription((PickupObject)(object)val, "Cuts enemies to bits.\n\nForged and sharpened by a Gun Cultist who believed she heard the voice of Kaliber speaking to her... asking her for a sacrifice... her son.");
		val.SetGunSprites("butchersknife");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 16);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 8);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 1);
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2f, (ModifyMethod)0);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 1f;
		val.gunClass = (GunClass)60;
		val.DefaultModule.angleVariance = 1f;
		val.DefaultModule.numberOfShotsInClip = 1;
		Projectile val2 = (Projectile)(object)DataCloners.CopyFields<SuperPierceProjectile>(Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]));
		val.DefaultModule.projectiles[0] = val2;
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 0.2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.7f;
		val2.pierceMinorBreakables = true;
		val2.AdditionalScaleMultiplier *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1000f;
		val2.SetProjectileSprite("butchersknife_projectile", 29, 7, lightened: false, (Anchor)4, 35, 14, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).specRigidbody.CollideWithTileMap = false;
		NoCollideBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<NoCollideBehaviour>(((Component)val2).gameObject);
		orAddComponent.worksOnEnemies = false;
		orAddComponent.worksOnProjectiles = true;
		PierceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.penetration = 1000;
		TickDamageBehaviour orAddComponent3 = GameObjectExtensions.GetOrAddComponent<TickDamageBehaviour>(((Component)val2).gameObject);
		orAddComponent3.damageSource = "Butchers Knife";
		orAddComponent3.starterDamage = 3f;
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("ButchersKnife Clip", "NevernamedsItems/Resources/CustomGunAmmoTypes/butchersknife_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/butchersknife_clipempty");
		val.reloadTime = 5f;
		val.SetBaseMaxAmmo(35);
		((PickupObject)val).quality = (ItemQuality)5;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 0;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.87f, 0.25f, 0f);
		ButchersKnifeID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		ProjectileReturned = false;
		if (projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			float range = rangeTime;
			if (rangeTime > 12f)
			{
				range = 12f;
			}
			KnifeReturnEffect orAddComponent = GameObjectExtensions.GetOrAddComponent<KnifeReturnEffect>(((Component)projectile).gameObject);
			orAddComponent.range = range;
			((MonoBehaviour)this).Invoke("ResetRangeTime", 0.1f);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void ResetRangeTime()
	{
		rangeTime = 0f;
	}

	public void OnProjectileReturn()
	{
		if (!ProjectileReturned && base.gun.IsReloading)
		{
			ProjectileReturned = true;
			base.gun.ForceImmediateReload(false);
			if (base.gun.CurrentOwner is PlayerController)
			{
				GameActor currentOwner = base.gun.CurrentOwner;
				int playerIDX = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).PlayerIDX;
				GameUIRoot.Instance.ForceClearReload(playerIDX);
			}
		}
	}

	private void FixedUpdate()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && (Object)(object)base.gun.CurrentOwner != (Object)null && base.gun.IsCharging && canAddToRangeTime)
		{
			canAddToRangeTime = false;
			rangeTime += 1f;
			((MonoBehaviour)this).Invoke("ChargeRangeCooldown", 0.25f);
		}
	}

	private void ChargeRangeCooldown()
	{
		canAddToRangeTime = true;
	}
}
