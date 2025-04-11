using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class FingerGuns : GunBehaviour
{
	private bool hasPolydactylySynergyAlready = false;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Finger Guns", "fingerguns");
		Game.Items.Rename("outdated_gun_mods:finger_guns", "nn:finger_guns");
		((Component)val).gameObject.AddComponent<FingerGuns>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Ayyyyy");
		GunExt.SetLongDescription((PickupObject)(object)val, "A universal gesture, laden with rogueish charm.\n\nEven this simple hand movement is enough for use in combat in the gungeon.");
		val.SetGunSprites("fingerguns");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.8f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.gunHandedness = (GunHandedness)3;
		val.DefaultModule.numberOfShotsInClip = 5;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.81f, 0.43f, 0f);
		val.SetBaseMaxAmmo(250);
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.9f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.damage *= 1.4f;
		val2.SetProjectileSprite("fingerguns_projectile", 8, 3, lightened: true, (Anchor)4, 7, 2, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		AdvancedVolleyModificationSynergyProcessor advancedVolleyModificationSynergyProcessor = ((Component)val).gameObject.AddComponent<AdvancedVolleyModificationSynergyProcessor>();
		AdvancedVolleyModificationSynergyData advancedVolleyModificationSynergyData = ScriptableObject.CreateInstance<AdvancedVolleyModificationSynergyData>();
		advancedVolleyModificationSynergyData.AddsDuplicatesOfBaseModule = true;
		advancedVolleyModificationSynergyData.DuplicatesOfBaseModule = 4;
		advancedVolleyModificationSynergyData.RequiredSynergy = "Five Finger Guns";
		advancedVolleyModificationSynergyProcessor.synergies.Add(advancedVolleyModificationSynergyData);
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
	}

	public override void Update()
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Polydactyly"))
		{
			if (!hasPolydactylySynergyAlready)
			{
				base.gun.SetBaseMaxAmmo(350);
				base.gun.DefaultModule.numberOfShotsInClip = 6;
				hasPolydactylySynergyAlready = true;
			}
		}
		else if (hasPolydactylySynergyAlready)
		{
			base.gun.SetBaseMaxAmmo(250);
			base.gun.DefaultModule.numberOfShotsInClip = 5;
			hasPolydactylySynergyAlready = false;
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			PlayerController val = ProjectileUtility.ProjectilePlayerOwner(projectile);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Polydactyly"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 1.142857f;
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Five Finger Guns"))
			{
				((BraveBehaviour)((BraveBehaviour)projectile).sprite).renderer.enabled = true;
			}
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
