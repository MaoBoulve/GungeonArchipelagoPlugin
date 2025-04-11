using System;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Welgun : AdvancedGunBehavior
{
	public static int WelgunID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Welgun", "welgun");
		Game.Items.Rename("outdated_gun_mods:welgun", "nn:welgun");
		Welgun welgun = ((Component)val).gameObject.AddComponent<Welgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Yoink");
		GunExt.SetLongDescription((PickupObject)(object)val, "This gun has been specially manufactured to be compatible with the same shells used by the Gundead.\n\nAllows for the stealing of ammo from fallen foes.");
		val.SetGunSprites("welgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 17);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.3f;
		val.DefaultModule.cooldownTime = 0.21f;
		val.DefaultModule.numberOfShotsInClip = 15;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.81f, 0f);
		val.SetBaseMaxAmmo(300);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 5f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 10f;
		val2.SetProjectileSprite("welgun_projectile", 4, 4, lightened: true, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		WelgunID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private void OnHitEnemy(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
	{
		if (Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && fatal && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && Random.value <= 0.1f)
		{
			base.gun.GainAmmo(Random.Range(10, 16));
		}
	}
}
