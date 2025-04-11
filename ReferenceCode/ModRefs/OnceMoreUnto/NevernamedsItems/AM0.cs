using System;
using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class AM0 : AdvancedGunBehavior
{
	public static int ID;

	private float damageMult = 1f;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("AM-0", "am0");
		Game.Items.Rename("outdated_gun_mods:am0", "nn:am0");
		((Component)val).gameObject.AddComponent<AM0>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Fires Ammunition");
		GunExt.SetLongDescription((PickupObject)(object)val, "Becomes more powerful the more times it's ammo is refilled.\n\nThis gun is comically stuffed with whole ammo boxes.");
		val.SetGunSprites("am0");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(519);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 30;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.43f, 0.75f, 0f);
		val.SetBaseMaxAmmo(500);
		val.ammo = 500;
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.7f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 2f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "AM0Projectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "AM0Projectile", new List<IntVector2>
		{
			new IntVector2(11, 14),
			new IntVector2(13, 16),
			new IntVector2(13, 16),
			new IntVector2(13, 16),
			new IntVector2(11, 14),
			new IntVector2(13, 16),
			new IntVector2(13, 16),
			new IntVector2(13, 16),
			new IntVector2(11, 14),
			new IntVector2(13, 16),
			new IntVector2(13, 16),
			new IntVector2(13, 16),
			new IntVector2(11, 14),
			new IntVector2(13, 16),
			new IntVector2(13, 16),
			new IntVector2(13, 16)
		}, MiscTools.DupeList(value: false, 16), MiscTools.DupeList<Anchor>((Anchor)4, 16), MiscTools.DupeList(value: true, 16), MiscTools.DupeList(value: false, 16), MiscTools.DupeList<Vector3?>(null, 16), MiscTools.DupeList<IntVector2?>(null, 16), MiscTools.DupeList<IntVector2?>(null, 16), MiscTools.DupeList<Projectile>(null, 16));
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("AM0 Ammo Boxes", "NevernamedsItems/Resources/CustomGunAmmoTypes/am0_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/am0_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Combine(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmoCollected));
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnPickedUpAmmo = (Action<PlayerController, AmmoPickup>)Delegate.Remove(extComp.OnPickedUpAmmo, new Action<PlayerController, AmmoPickup>(OnAmmoCollected));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= damageMult;
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public void OnAmmoCollected(PlayerController player, AmmoPickup pickup)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Invalid comparison between Unknown and I4
		if ((int)pickup.mode == 1 && (Object)(object)((GameActor)player).CurrentGun != (Object)null)
		{
			if ((Object)(object)((Component)((GameActor)player).CurrentGun).GetComponent<AM0>() != (Object)null)
			{
				((Component)((GameActor)player).CurrentGun).GetComponent<AM0>().damageMult += 0.1f;
			}
			else
			{
				if (!CustomSynergies.PlayerHasActiveSynergy(player, "Menger Clip"))
				{
					return;
				}
				foreach (Gun allGun in player.inventory.AllGuns)
				{
					if ((Object)(object)allGun != (Object)null && (Object)(object)((Component)allGun).GetComponent<AM0>() != (Object)null)
					{
						((Component)allGun).GetComponent<AM0>().damageMult += 0.02f;
					}
				}
			}
		}
		else
		{
			if ((int)pickup.mode != 2 || !((Object)(object)((GameActor)player).CurrentGun != (Object)null))
			{
				return;
			}
			if (!((Object)(object)((Component)((GameActor)player).CurrentGun).GetComponent<AM0>() != (Object)null))
			{
				foreach (Gun allGun2 in player.inventory.AllGuns)
				{
					if ((Object)(object)allGun2 != (Object)null && (Object)(object)((Component)allGun2).GetComponent<AM0>() != (Object)null)
					{
						((Component)allGun2).GetComponent<AM0>().damageMult += 0.02f;
					}
				}
				return;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(player, "Menger Clip"))
			{
				((Component)((GameActor)player).CurrentGun).GetComponent<AM0>().damageMult += 0.1f;
			}
			else
			{
				((Component)((GameActor)player).CurrentGun).GetComponent<AM0>().damageMult += 0.05f;
			}
		}
	}

	public override void InheritData(Gun other)
	{
		((AdvancedGunBehavior)this).InheritData(other);
		AM0 component = ((Component)other).GetComponent<AM0>();
		if ((Object)(object)component != (Object)null)
		{
			damageMult = component.damageMult;
		}
	}

	public override void MidGameSerialize(List<object> data, int i)
	{
		((AdvancedGunBehavior)this).MidGameSerialize(data, i);
		data.Add(damageMult);
	}

	public override void MidGameDeserialize(List<object> data, ref int i)
	{
		((AdvancedGunBehavior)this).MidGameDeserialize(data, ref i);
		damageMult = (float)data[i];
		i++;
	}
}
