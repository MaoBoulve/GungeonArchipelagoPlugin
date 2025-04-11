using System;
using System.Reflection;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Kalashnirang : GunBehaviour
{
	public static int KalashnirangID;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Kalashnirang", "kalashnirang");
		Game.Items.Rename("outdated_gun_mods:kalashnirang", "nn:kalashnirang");
		((Component)val).gameObject.AddComponent<Kalashnirang>();
		GunExt.SetShortDescription((PickupObject)(object)val, "What We Do Here");
		GunExt.SetLongDescription((PickupObject)(object)val, "Rapid-fires boomeraning bullets.\n\nFound among the remnants of an old abandoned circus in the Gungeon's third chamber. Where the performers went is a mystery.");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(15);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.SetGunSprites("kalashnirang");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId2 = PickupObjectDatabase.GetById(617);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.11f;
		val.DefaultModule.numberOfShotsInClip = 30;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.68f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)10;
		PickupObject byId3 = PickupObjectDatabase.GetById(617);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.chargeProjectiles[0].Projectile);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration = 5;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "kalashnikov");
		KalashnirangID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		((GunBehaviour)this).PostProcessProjectile(projectile);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Rangaround"))
		{
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= 2f;
			ProjectileData baseData2 = projectile.baseData;
			baseData2.speed *= 2f;
		}
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)projectile).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePierce));
	}

	private void HandlePierce(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		FieldInfo field = typeof(Projectile).GetField("m_hasPierced", BindingFlags.Instance | BindingFlags.NonPublic);
		field.SetValue(((BraveBehaviour)myRigidbody).projectile, false);
	}
}
