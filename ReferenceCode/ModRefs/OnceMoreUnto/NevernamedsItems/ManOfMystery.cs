using UnityEngine;

namespace NevernamedsItems;

public class ManOfMystery : ExtendedCompanionItem
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
		ManOfMystery manOfMystery = ItemSetup.NewItem<ManOfMystery>("Man of Mystery", "International", "A mysterious companion.\n\nWhile their goals and motivations remain unknown, it's clear they're in this for the long haul.", "manofmystery_icon", assetbundle: true) as ManOfMystery;
		((PickupObject)manOfMystery).quality = (ItemQuality)2;
		((CompanionItem)manOfMystery).CompanionGuid = RandomisedBuddyController.guid;
		ID = ((PickupObject)manOfMystery).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		if (!((PassiveItem)this).m_pickedUpThisRun)
		{
			Recalculate();
		}
		((CompanionItem)this).Pickup(player);
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
