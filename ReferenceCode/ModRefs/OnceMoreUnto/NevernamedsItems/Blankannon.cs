using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Blankannon : AdvancedGunBehavior
{
	public static int BlankannonId;

	public static void Add()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Blankannon", "blankannon");
		Game.Items.Rename("outdated_gun_mods:blankannon", "nn:blankannon");
		((Component)val).gameObject.AddComponent<Blankannon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Fires Blanks");
		GunExt.SetLongDescription((PickupObject)(object)val, "It takes a very delicate pin to fire blanks instead of simply destroying them.\n\nThis elaborate device was put together from the scrapped parts of a laser-accurate surgical machine.");
		val.SetGunSprites("blankannon");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 2f, (ModifyMethod)0);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 0;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.angleVariance = 0f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.98f, 0.75f, 0f);
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
		BlankProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BlankProjModifier>(((Component)val2).gameObject);
		orAddComponent.blankType = (EasyBlankType)0;
		val2.SetProjectileSprite("blankannon_projectile", 10, 7, lightened: false, (Anchor)4, 10, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Blank UI Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/blankannon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/blankannon_clipempty");
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "override_cangainammo_check");
		BlankannonId = ((PickupObject)val).PickupObjectId;
	}

	public override bool CollectedAmmoPickup(PlayerController player, Gun self, AmmoPickup pickup)
	{
		LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		AmmoPickupFixer.ForcePickupWithoutGainingAmmo(pickup, player, false);
		return false;
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		int num = 1;
		if (player.HasPickupID(TitaniumClip.TitaniumClipID))
		{
			num = 2;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Secrets of the Ancients") && (double)Random.value <= 0.25)
		{
			num = 0;
		}
		if (player.Blanks >= num)
		{
			player.Blanks -= num;
		}
		else
		{
			player.Blanks = 0;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(player, "Paned Expression"))
		{
			_003F val = player;
			PickupObject byId = PickupObjectDatabase.GetById(565);
			((PlayerController)val).AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
		}
		DoMicroBlank(Vector2.op_Implicit(gun.barrelOffset.position));
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
		if (!base.everPickedUpByPlayer)
		{
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
			LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(224)).gameObject, player);
		}
		RecalculateClip(player);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		try
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)val) && CustomSynergies.PlayerHasActiveSynergy(val, "Paned Expression"))
			{
				foreach (PassiveItem passiveItem in val.passiveItems)
				{
					if (((PickupObject)passiveItem).PickupObjectId == 565)
					{
						ProjectileData baseData = projectile.baseData;
						baseData.damage *= 1.04f;
					}
				}
			}
			((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void DoMicroBlank(Vector2 center)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)val))
			{
				GameObject val2 = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX_Ghost");
				AkSoundEngine.PostEvent("Play_OBJ_silenceblank_small_01", ((Component)this).gameObject);
				GameObject val3 = new GameObject("silencer");
				SilencerInstance val4 = val3.AddComponent<SilencerInstance>();
				float num = 0.25f;
				val4.TriggerSilencer(center, 25f, 5f, val2, 0f, 3f, 3f, 3f, 250f, 5f, num, val, false, false);
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && base.gun.CurrentAmmo != GunTools.GunPlayerOwner(base.gun).Blanks)
		{
			RecalculateClip(GunTools.GunPlayerOwner(base.gun));
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void RecalculateClip(PlayerController gunOwner)
	{
		int blanks = gunOwner.Blanks;
		base.gun.CurrentAmmo = blanks;
		base.gun.ForceImmediateReload(true);
		gunOwner.stats.RecalculateStats(gunOwner, false, false);
	}
}
