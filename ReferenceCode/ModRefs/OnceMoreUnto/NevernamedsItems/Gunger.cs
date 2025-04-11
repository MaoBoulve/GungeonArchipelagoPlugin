using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Gunger : AdvancedGunBehavior
{
	public class GungerBaseProjectile : MonoBehaviour
	{
	}

	public static List<int> InvalidGuns = new List<int>();

	public static void Add()
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gunger", "gunger");
		Game.Items.Rename("outdated_gun_mods:gunger", "nn:gunger");
		((Component)val).gameObject.AddComponent<Gunger>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Hungry Gun");
		GunExt.SetLongDescription((PickupObject)(object)val, "Reloading this strange creature near guns on the ground will cause them to be... consumed?\n\nThese creatures are worshipped as gods in some cultures, though they know it not.");
		val.SetGunSprites("gunger");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 9);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(599);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.2f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.31f, 0.62f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.8f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		ProjectileData baseData4 = val2.baseData;
		baseData4.force *= 1.2f;
		GungerBaseProjectile gungerBaseProjectile = ((Component)val2).gameObject.AddComponent<GungerBaseProjectile>();
		val2.SetProjectileSprite("gunger_projectile", 17, 9, lightened: false, (Anchor)4, 16, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Gunger Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/gunger_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/gunger_clipempty");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (base.gun.ClipShotsRemaining == base.gun.ClipCapacity - 1 && projectile.Owner is PlayerController && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Famished"))
		{
			HungryProjectileModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HungryProjectileModifier>(((Component)projectile).gameObject);
			orAddComponent.HungryRadius = 1.5f;
			projectile.AdjustPlayerProjectileTint(ExtendedColours.purple, 1, 0f);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public override void OnReloadPressedSafe(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		IPlayerInteractable nearestInteractable = player.CurrentRoom.GetNearestInteractable(((GameActor)player).CenterPosition, 1f, player);
		if (nearestInteractable != null && nearestInteractable is Gun)
		{
			Gun val = (Gun)(object)((nearestInteractable is Gun) ? nearestInteractable : null);
			if ((Object)(object)val != (Object)null && !InvalidGuns.Contains(((PickupObject)val).PickupObjectId) && (int)val.DefaultModule.shootStyle != 2)
			{
				EatAndAbsorbGun(gun, val);
			}
		}
		((AdvancedGunBehavior)this).OnReloadPressedSafe(player, gun, manualReload);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			foreach (Projectile projectile in base.gun.RawSourceVolley.projectiles[0].projectiles)
			{
				GungerBaseProjectile component = ((Component)projectile).GetComponent<GungerBaseProjectile>();
				if ((Object)(object)component == (Object)null)
				{
					base.gun.RawSourceVolley.projectiles[0].projectiles.Remove(projectile);
				}
			}
			if ((Object)(object)player != (Object)null)
			{
				player.stats.RecalculateStats(player, true, false);
			}
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	private void EatAndAbsorbGun(Gun baseGun, Gun absorbedgun)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		int pickupObjectId = ((PickupObject)absorbedgun).PickupObjectId;
		Projectile val = null;
		val = (((int)absorbedgun.DefaultModule.shootStyle != 3) ? ((BraveBehaviour)GunTools.RawDefaultModule(absorbedgun).projectiles[0]).projectile : GunTools.RawDefaultModule(absorbedgun).chargeProjectiles[0].Projectile);
		if ((Object)(object)val != (Object)null)
		{
			baseGun.RawSourceVolley.projectiles[0].projectiles.Add(val);
		}
		if ((Object)(object)baseGun.CurrentOwner != (Object)null && baseGun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = baseGun.CurrentOwner;
			_003F val2 = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).stats;
			GameActor currentOwner2 = baseGun.CurrentOwner;
			((PlayerStats)val2).RecalculateStats((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null), true, false);
		}
		Object.Destroy((Object)(object)((Component)absorbedgun).gameObject);
	}
}
