using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Goobleck : ExtendedCompanionItem
{
	public string soundEvent;

	public VFXPool muzzleFlash;

	public Projectile chosenProjectile;

	public string companionIdentity;

	public float damageMultiplier = 1f;

	public float angleVariance = 5f;

	public float cooldowntime = 0.25f;

	public int clipsize = 5;

	public float reloadTime = 1f;

	public float shotSpeedMult = 1f;

	public static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		Goobleck goobleck = ItemSetup.NewItem<Goobleck>("Goobleck", "A Friend In There Somewhere", "A friendly glob of psychoputty.\n\nShapes itself around concepts blindly pulled from the noosphere of the collective unconscious, but it cannot maintain one form for too long.", "goobleck_icon", assetbundle: true) as Goobleck;
		((PickupObject)goobleck).quality = (ItemQuality)2;
		((CompanionItem)goobleck).CompanionGuid = RandomisedBuddyController.guid;
		ID = ((PickupObject)goobleck).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Combine(player.OnNewFloorLoaded, new Action<PlayerController>(NewLevel));
		player.OnRollStarted += Roll;
		if (!((PassiveItem)this).m_pickedUpThisRun)
		{
			Recalculate();
		}
		((CompanionItem)this).Pickup(player);
	}

	private void Roll(PlayerController p, Vector2 v)
	{
		if (Object.op_Implicit((Object)(object)p) && CustomSynergies.PlayerHasActiveSynergy(p, "Re Roll We Roll"))
		{
			Recalculate();
			((CompanionItem)this).ForceCompanionRegeneration(p, (Vector2?)null);
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Remove(player.OnNewFloorLoaded, new Action<PlayerController>(NewLevel));
			player.OnRollStarted -= Roll;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public void NewLevel(PlayerController pl)
	{
		Recalculate();
	}

	public void Recalculate()
	{
		companionIdentity = BraveUtility.RandomElement<string>(RandomisedBuddyController.validForms);
		damageMultiplier = Random.Range(0.8f, 1.2f);
		angleVariance = Random.Range(0f, 10f);
		cooldowntime = Random.Range(0.35f, 1f);
		reloadTime = Random.Range(1f, 3f);
		shotSpeedMult = Random.Range(0.5f, 1.5f);
		clipsize = Random.Range(1, 8);
		soundEvent = BraveUtility.RandomElement<string>(RandomisedBuddyController.fireSoundEffects);
		muzzleFlash = BraveUtility.RandomElement<VFXPool>(RandomisedBuddyController.validMuzzleFlashes);
		chosenProjectile = BraveUtility.RandomElement<Projectile>(HelmOfChaos.PossibleProj);
	}

	public override void OnCompanionCreation(PlayerController owner)
	{
		if (Object.op_Implicit((Object)(object)((CompanionItem)this).m_extantCompanion) && Object.op_Implicit((Object)(object)((CompanionItem)this).m_extantCompanion.GetComponent<RandomisedBuddyController>()) && ((CompanionItem)this).m_extantCompanion.GetComponent<RandomisedBuddyController>().currentForm != companionIdentity)
		{
			RandomisedBuddyController component = ((CompanionItem)this).m_extantCompanion.GetComponent<RandomisedBuddyController>();
			component.currentForm = companionIdentity;
			component.shotsInClip = clipsize;
			component.reloadTime = reloadTime;
			component.cooldownTime = cooldowntime;
			component.soundEvent = soundEvent;
			component.MuzzleFlash = muzzleFlash;
			component.chosenProjectile = chosenProjectile;
			component.angleVariance = angleVariance;
			component.setUp = true;
		}
		base.OnCompanionCreation(owner);
	}
}
