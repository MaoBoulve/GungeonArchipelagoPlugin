using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RocketPistol : GunBehaviour
{
	public static int ID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rocket Pistol", "rocketpistol");
		Game.Items.Rename("outdated_gun_mods:rocket_pistol", "nn:rocket_pistol");
		((Component)val).gameObject.AddComponent<RocketPistol>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Hell... Maybe");
		GunExt.SetLongDescription((PickupObject)(object)val, "Made by a weak Gungeoneer whos atrophied muscles were incapable of holding the heavy Yari Launcher.\n\nWhile lacking in the sheer destructive potential that the Yari Launcher's rapid-fire provides, this Rocket Pistol can still do a lot of damage.");
		val.SetGunSprites("rocketpistol");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 20);
		PickupObject byId = PickupObjectDatabase.GetById(16);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 6;
		val.SetBaseMaxAmmo(600);
		val.gunClass = (GunClass)45;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
