using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Multiplicator : AdvancedGunBehavior
{
	public static int mode = 1;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Multiplicator", "multiplicator");
		Game.Items.Rename("outdated_gun_mods:multiplicator", "nn:multiplicator");
		((Component)val).gameObject.AddComponent<Multiplicator>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Times Gone By");
		GunExt.SetLongDescription((PickupObject)(object)val, "This gun is capable of merging multiple bullets together to multiply their damage. Reload on a full clip to select multiplication intensity.\n\nBrought to the Gungeon by a great mathematician who stole everything he ever published.");
		val.SetGunSprites("multiplicator");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.25f, 0.5f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 1f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 1f;
		val2.SetProjectileSprite("multiplicator_projectile", 14, 7, lightened: false, (Anchor)4, 14, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Multiplicator Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/multiplicator_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/multiplicator_clipempty");
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Multiplicator";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= (float)mode;
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	protected override void Update()
	{
		int num = mode;
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Times Tables") && mode != 1)
		{
			num = mode - 1;
		}
		if (base.gun.DefaultModule.ammoCost != num)
		{
			base.gun.DefaultModule.ammoCost = num;
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, bSOMETHING);
		if (gun.ClipCapacity == gun.ClipShotsRemaining || gun.CurrentAmmo == gun.ClipShotsRemaining)
		{
			if (mode != 10)
			{
				mode++;
				TextBubble.DoAmbientTalk(((BraveBehaviour)player).transform, new Vector3(1f, 2f, 0f), "Using " + mode + " ammo for " + mode + "x damage.", 4f);
			}
			else
			{
				mode = 1;
				TextBubble.DoAmbientTalk(((BraveBehaviour)player).transform, new Vector3(1f, 2f, 0f), "Using 1 ammo for normal damage.", 4f);
			}
		}
	}
}
