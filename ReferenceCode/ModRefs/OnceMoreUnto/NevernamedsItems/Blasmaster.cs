using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Blasmaster : AdvancedGunBehavior
{
	public static int BlasmasterID;

	private bool hasBonusDamageFromSynergy;

	public static void Add()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Blasmaster", "blasmaster");
		Game.Items.Rename("outdated_gun_mods:blasmaster", "nn:blasmaster");
		((Component)val).gameObject.AddComponent<Blasmaster>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Platoon Onboard");
		GunExt.SetLongDescription((PickupObject)(object)val, "Standard issue blasma blaster from the far reaches of space, outfitted with a special ruby from deep within the Black Powder Mines to maximise it's power.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "blasmaster_idle_001", 8, "blasmaster_ammonomicon_001");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(599);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		PickupObject byId2 = PickupObjectDatabase.GetById(809);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 8;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.12f, 0.56f, 0f);
		val.SetBaseMaxAmmo(250);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.damage *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.range *= 0.3f;
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Blasmaster";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_BLASMASTER, requiredFlagValue: true);
		BlasmasterID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
		if (hasBonusDamageFromSynergy)
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
		}
	}

	private void onUsedPlayerItem(PlayerController player, PlayerItem activeItem)
	{
		if (((PickupObject)activeItem).PickupObjectId == 250 || ((PickupObject)activeItem).PickupObjectId == 69)
		{
			hasBonusDamageFromSynergy = true;
			((MonoBehaviour)this).Invoke("ResetDamage", 3f);
		}
	}

	public void ResetDamage()
	{
		hasBonusDamageFromSynergy = false;
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
		player.OnUsedPlayerItem -= onUsedPlayerItem;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
		player.OnUsedPlayerItem += onUsedPlayerItem;
	}
}
