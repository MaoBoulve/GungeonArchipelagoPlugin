using System;
using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class DeconstructGun
{
	protected static AutocompletionSettings deconstructAutocomplete = new AutocompletionSettings((Func<string, string[]>)delegate
	{
		List<string> list = new List<string> { "projcomp", "vfx" };
		return list.ToArray();
	});

	public static void Init()
	{
		ETGModConsole.Commands.GetGroup("nn").AddUnit("deconstructgun", (Action<string[]>)delegate(string[] args)
		{
			bool flag = false;
			bool deconstructProjectileComponents = false;
			if (args != null && args.Length != 0 && args[0] != null && !string.IsNullOrEmpty(args[0]))
			{
				if (args[0] == "vfx")
				{
					flag = true;
				}
				if (args[0] == "projcomp")
				{
					deconstructProjectileComponents = true;
				}
			}
			if ((Object)(object)GameManager.Instance == (Object)null)
			{
				ETGModConsole.Log((object)"Somehow the fucking game manager was null lol rip get fucked mate.", false);
			}
			else if ((Object)(object)GameManager.Instance.PrimaryPlayer == (Object)null)
			{
				ETGModConsole.Log((object)"<size=100><color=#ff0000ff>ERROR: There is no player 1 to check for a gun.</color></size>", false);
			}
			else if ((Object)(object)((GameActor)GameManager.Instance.PrimaryPlayer).CurrentGun == (Object)null)
			{
				ETGModConsole.Log((object)"<size=100><color=#ff0000ff>ERROR: Player 1 is not holding a gun to deconstruct.</color></size>", false);
			}
			else
			{
				Gun currentGun = ((GameActor)GameManager.Instance.PrimaryPlayer).CurrentGun;
				ETGModConsole.Log((object)"<color=#09b022>-------------------------------------</color>", false);
				ETGModConsole.Log((object)"<color=#09b022>Base Gun Stats:</color>", false);
				ETGModConsole.Log((object)("<color=#ff0000ff>Display Name: </color>" + ((PickupObject)currentGun).DisplayName), false);
				ETGModConsole.Log((object)("<color=#ff0000ff>Object Name: </color>" + ((Object)currentGun).name), false);
				ETGModConsole.Log((object)("<color=#ff0000ff>Internal Name:</color>" + currentGun.gunName), false);
				ETGModConsole.Log((object)("<color=#ff0000ff>ID: </color>" + ((PickupObject)currentGun).PickupObjectId), false);
				ETGModConsole.Log((object)("<color=#ff0000ff>Class: </color>" + ((object)(GunClass)(ref currentGun.gunClass)/*cast due to .constrained prefix*/).ToString()), false);
				ETGModConsole.Log((object)"<color=#09b022>Numerical Base Stats:</color>", false);
				ETGModConsole.Log((object)("<color=#ff0000ff>Infinite Ammo: </color>" + currentGun.InfiniteAmmo), false);
				ETGModConsole.Log((object)("<color=#ff0000ff>Ammo Max: </color>" + currentGun.GetBaseMaxAmmo()), false);
				ETGModConsole.Log((object)("<color=#ff0000ff>Reload Time: </color>" + currentGun.reloadTime), false);
				if (flag)
				{
					ETGModConsole.Log((object)"<color=#09b022>Muzzle Flash Effects:</color>", false);
					if (currentGun.muzzleFlashEffects != null)
					{
						ETGModConsole.Log((object)("<color=#ff0000ff>    Type: </color>" + ((object)(VFXPoolType)(ref currentGun.muzzleFlashEffects.type)/*cast due to .constrained prefix*/).ToString()), false);
						if (currentGun.muzzleFlashEffects.effects != null && currentGun.muzzleFlashEffects.effects.Length != 0)
						{
							int num = 0;
							VFXComplex[] effects = currentGun.muzzleFlashEffects.effects;
							foreach (VFXComplex val in effects)
							{
								ETGModConsole.Log((object)$"<color=#ff0000ff>    VFXComplex  [{num}]</color>", false);
								num++;
							}
						}
						else
						{
							ETGModConsole.Log((object)"<color=#ff0000ff>    Gun's Muzzle Flash Effects contain no list of VFXComplexes? </color>", false);
						}
					}
					else
					{
						ETGModConsole.Log((object)("<color=#ff0000ff>    Gun has no Muzzle Flash Effects.</color>" + currentGun.reloadTime), false);
					}
				}
				ETGModConsole.Log((object)"<color=#ff0000ff>Components:</color>", false);
				Component[] components = ((Component)currentGun).GetComponents<Component>();
				foreach (Component val2 in components)
				{
					ETGModConsole.Log((object)((object)val2).GetType().ToString(), false);
					if (val2 is DualWieldSynergyProcessor)
					{
						ETGModConsole.Log((object)("<color=#ff0000ff>    Req Synergy: </color>" + ((object)(CustomSynergyType)(ref ((DualWieldSynergyProcessor)((val2 is DualWieldSynergyProcessor) ? val2 : null)).SynergyToCheck)/*cast due to .constrained prefix*/).ToString()), false);
						ETGModConsole.Log((object)("<color=#ff0000ff>    Other Gun: </color>" + PickupObjectDatabase.GetById(((DualWieldSynergyProcessor)((val2 is DualWieldSynergyProcessor) ? val2 : null)).PartnerGunID).DisplayName + " (" + ((DualWieldSynergyProcessor)((val2 is DualWieldSynergyProcessor) ? val2 : null)).PartnerGunID + ")"), false);
					}
					if (val2 is GunFormeSynergyProcessor)
					{
						int num2 = 0;
						GunFormeData[] formes = ((GunFormeSynergyProcessor)((val2 is GunFormeSynergyProcessor) ? val2 : null)).Formes;
						foreach (GunFormeData val3 in formes)
						{
							ETGModConsole.Log((object)$"<color=#ff0000ff>    Forme ({num2})</color>", false);
							ETGModConsole.Log((object)("<color=#ff0000ff>        Requires Synergy: </color>" + val3.RequiresSynergy), false);
							if (val3.RequiresSynergy)
							{
								ETGModConsole.Log((object)("<color=#ff0000ff>        Required Synergy: </color>" + ((object)(CustomSynergyType)(ref val3.RequiredSynergy)/*cast due to .constrained prefix*/).ToString()), false);
							}
							ETGModConsole.Log((object)("<color=#ff0000ff>        Forme ID: </color>" + val3.FormeID + "(" + PickupObjectDatabase.GetById(val3.FormeID).DisplayName + ")"), false);
							num2++;
						}
					}
					else if (val2 is FireOnReloadSynergyProcessor)
					{
						ETGModConsole.Log((object)("<color=#ff0000ff>    Req Synergy: </color>" + ((object)(CustomSynergyType)(ref ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).SynergyToCheck)/*cast due to .constrained prefix*/).ToString()), false);
						ETGModConsole.Log((object)("<color=#ff0000ff>    Use Gun Proj: </color>" + ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.UseCurrentGunProjectile), false);
						if ((Object)(object)((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile != (Object)null)
						{
							ETGModConsole.Log((object)("<color=#ff0000ff>    Proj Name: </color>" + ((Object)((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile).name), false);
							ETGModConsole.Log((object)("<color=#ff0000ff>    Proj Damage: </color>" + ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.baseData.damage), false);
							ETGModConsole.Log((object)("<color=#ff0000ff>    Proj Speed: </color>" + ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.baseData.speed), false);
							ETGModConsole.Log((object)("<color=#ff0000ff>    Proj Range: </color>" + ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.baseData.range), false);
							ETGModConsole.Log((object)("<color=#ff0000ff>    Proj Knockback: </color>" + ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.baseData.force), false);
							ETGModConsole.Log((object)("<color=#ff0000ff>    Proj BossDMGMult: </color>" + ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.BossDamageMultiplier), false);
							ETGModConsole.Log((object)("<color=#ff0000ff>    Proj DMGTypes: </color>" + ((object)(CoreDamageTypes)(ref ((FireOnReloadSynergyProcessor)((val2 is FireOnReloadSynergyProcessor) ? val2 : null)).DirectedBurstSettings.ProjectileInterface.SpecifiedProjectile.damageTypes)/*cast due to .constrained prefix*/).ToString()), false);
						}
					}
					if (val2 is TransformGunSynergyProcessor)
					{
						ETGModConsole.Log((object)("<color=#ff0000ff>    Req Synergy: </color>" + ((object)(CustomSynergyType)(ref ((TransformGunSynergyProcessor)((val2 is TransformGunSynergyProcessor) ? val2 : null)).SynergyToCheck)/*cast due to .constrained prefix*/).ToString()), false);
						ETGModConsole.Log((object)("<color=#ff0000ff>    Transform Target: </color>" + PickupObjectDatabase.GetById(((TransformGunSynergyProcessor)((val2 is TransformGunSynergyProcessor) ? val2 : null)).SynergyGunId).DisplayName + " (" + ((TransformGunSynergyProcessor)((val2 is TransformGunSynergyProcessor) ? val2 : null)).SynergyGunId + ")"), false);
					}
				}
				ETGModConsole.Log((object)"<color=#09b022>Volleys and Modules:</color>", false);
				int num3 = 0;
				if ((Object)(object)currentGun.RawSourceVolley != (Object)null)
				{
					if (currentGun.RawSourceVolley.projectiles != null)
					{
						foreach (ProjectileModule projectile in currentGun.RawSourceVolley.projectiles)
						{
							ETGModConsole.Log((object)("<color=#09b022>Volley Module: </color>" + num3), false);
							DeconstructProjModule(projectile, flag, deconstructProjectileComponents, "This");
							num3++;
						}
					}
					else
					{
						ETGModConsole.Log((object)"<color=#ff0000ff>Gun has a volley, but no ProjectileModules within it.</color>", false);
					}
				}
				else
				{
					ETGModConsole.Log((object)"<color=#ff0000ff>Gun has no volley.</color>", false);
				}
				if (currentGun.DefaultModule != null)
				{
					ProjectileModule defaultModule = currentGun.DefaultModule;
					ETGModConsole.Log((object)"<color=#09b022>Default Module: </color>", false);
					DeconstructProjModule(defaultModule, flag, deconstructProjectileComponents, "Default");
				}
				else
				{
					ETGModConsole.Log((object)"<color=#ff0000ff>Gun has no Default Module.</color>", false);
				}
				if ((Object)(object)currentGun.modifiedFinalVolley != (Object)null)
				{
					int num4 = 0;
					{
						foreach (ProjectileModule projectile2 in currentGun.modifiedFinalVolley.projectiles)
						{
							ETGModConsole.Log((object)("<color=#09b022>Modified Final Volley Module: </color>" + num4), false);
							DeconstructProjModule(projectile2, flag, deconstructProjectileComponents, "This Final Volley");
							num4++;
						}
						return;
					}
				}
				ETGModConsole.Log((object)"<color=#ff0000ff>Gun has no Modified Final Volleys.</color>", false);
			}
		}, deconstructAutocomplete);
	}

	public static void DeconstructProjModule(ProjectileModule module, bool deconstructVFX, bool deconstructProjectileComponents, string ModName = "Unspecified")
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Invalid comparison between Unknown and I4
		ETGModConsole.Log((object)"<color=#ff0000ff>    Module Stats:</color>", false);
		ETGModConsole.Log((object)("<color=#ff0000ff>    ShootStyle: </color>" + ((object)(ShootStyle)(ref module.shootStyle)/*cast due to .constrained prefix*/).ToString()), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>    Sequence: </color>" + ((object)(ProjectileSequenceStyle)(ref module.sequenceStyle)/*cast due to .constrained prefix*/).ToString()), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>    Fire Delay: </color>" + module.cooldownTime), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>    Ammo Cost: </color>" + module.ammoCost), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>    UI Ammo Type: </color>" + ((object)(AmmoType)(ref module.ammoType)/*cast due to .constrained prefix*/).ToString()), false);
		if ((int)module.ammoType == 14)
		{
			ETGModConsole.Log((object)("<color=#ff0000ff>    Custom UI Ammo Type: </color>" + module.customAmmoType), false);
		}
		ETGModConsole.Log((object)("<color=#ff0000ff>    AngleFromAim: </color>" + module.angleFromAim), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>    AngleVariance: </color>" + module.angleVariance), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>    ClipShots: </color>" + module.numberOfShotsInClip), false);
		if (module.projectiles != null && module.projectiles.Count > 0)
		{
			ETGModConsole.Log((object)"<color=#09b022>    Projectiles:</color>", false);
			int num = 0;
			foreach (Projectile projectile2 in module.projectiles)
			{
				ETGModConsole.Log((object)("<color=#09b022>        Bullet: </color>" + num), false);
				num++;
				if ((Object)(object)projectile2 != (Object)null)
				{
					DeconstructProjectile(projectile2, deconstructVFX, deconstructProjectileComponents);
				}
				else
				{
					ETGModConsole.Log((object)"<color=#ff0000ff>       Bullet is somehow null.</color>", false);
				}
			}
		}
		else
		{
			ETGModConsole.Log((object)("<color=#ff0000ff>    " + ModName + " module has no normal projectiles.</color>"), false);
		}
		ETGModConsole.Log((object)"<color=#09b022>    Charge Projectiles:</color>", false);
		if (module.chargeProjectiles != null && module.chargeProjectiles.Count > 0)
		{
			int num2 = 0;
			{
				foreach (ChargeProjectile chargeProjectile in module.chargeProjectiles)
				{
					if ((Object)(object)chargeProjectile.Projectile != (Object)null)
					{
						Projectile projectile = chargeProjectile.Projectile;
						ETGModConsole.Log((object)("<color=#09b022>        Bullet: </color>" + num2), false);
						ETGModConsole.Log((object)("<color=#ff0000ff>        Charge Time: </color>" + chargeProjectile.ChargeTime), false);
						DeconstructProjectile(projectile, deconstructVFX, deconstructProjectileComponents);
						num2++;
					}
					else
					{
						ETGModConsole.Log((object)"<color=#ff0000ff>       Bullet is somehow null.</color>", false);
					}
				}
				return;
			}
		}
		ETGModConsole.Log((object)("<color=#ff0000ff>    " + ModName + " module has no charge projectiles.</color>"), false);
	}

	public static void DeconstructProjectile(Projectile bullet, bool vfx, bool deconstructProjectileComponents)
	{
		if (!string.IsNullOrEmpty(((Object)bullet).name))
		{
			ETGModConsole.Log((object)("<color=#ff0000ff>        Name: </color>" + ((Object)bullet).name), false);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>        Bullet has no name.</color>", false);
		}
		ETGModConsole.Log((object)"<color=#ff0000ff>        BaseData:</color>", false);
		if (bullet.baseData != null)
		{
			ETGModConsole.Log((object)("<color=#ff0000ff>        Damage: </color>" + bullet.baseData.damage), false);
			ETGModConsole.Log((object)("<color=#ff0000ff>        Speed: </color>" + bullet.baseData.speed), false);
			ETGModConsole.Log((object)("<color=#ff0000ff>        Range: </color>" + bullet.baseData.range), false);
			ETGModConsole.Log((object)("<color=#ff0000ff>        Knockback: </color>" + bullet.baseData.force), false);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>           BaseData is somehow null?</color>", false);
		}
		ETGModConsole.Log((object)"<color=#ff0000ff>        Other Stats:</color>", false);
		ETGModConsole.Log((object)("<color=#ff0000ff>        BossDMGMult: </color>" + bullet.BossDamageMultiplier), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>        Damage Types: </color>" + ((object)(CoreDamageTypes)(ref bullet.damageTypes)/*cast due to .constrained prefix*/).ToString()), false);
		if (!deconstructProjectileComponents)
		{
			return;
		}
		ETGModConsole.Log((object)"<color=#ff0000ff>        Components:</color>", false);
		Component[] components = ((Component)bullet).GetComponents<Component>();
		foreach (Component val in components)
		{
			ETGModConsole.Log((object)("        " + ((object)val).GetType().ToString()), false);
		}
		int num = 0;
		foreach (object item in ((Component)bullet).gameObject.transform)
		{
			ETGModConsole.Log((object)$"<color=#ff0000ff>        Found Child [{num}]:</color>", false);
			if (Object.op_Implicit((Object)(object)((Component)((item is Transform) ? item : null)).gameObject))
			{
				GameObject gameObject = ((Component)((item is Transform) ? item : null)).gameObject;
				ETGModConsole.Log((object)("<color=#ff0000ff>           Child Name:</color> " + ((Object)gameObject).name), false);
				Component[] components2 = gameObject.GetComponents<Component>();
				foreach (Component val2 in components2)
				{
					ETGModConsole.Log((object)("               " + ((object)val2).GetType().ToString()), false);
					if (!((object)val2).GetType().ToString().ToLower()
						.Contains("trailcontroller"))
					{
						continue;
					}
					TrailController val3 = (TrailController)(object)((val2 is TrailController) ? val2 : null);
					ETGModConsole.Log((object)("<color=#ff0000ff>                UsesStartAnim: </color>" + val3.usesStartAnimation), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                StartAnim: </color>" + val3.startAnimation), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                UsesAnim: </color>" + val3.usesAnimation), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                Anim: </color>" + val3.animation), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                UsesCascadeTimer: </color>" + val3.usesCascadeTimer), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                CascadeTimer: </color>" + val3.cascadeTimer), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                UsesSoftMaxLength: </color>" + val3.usesSoftMaxLength), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                SoftMaxLength: </color>" + val3.softMaxLength), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                UsesGlobalTimer: </color>" + val3.usesGlobalTimer), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                GlobalTimer: </color>" + val3.globalTimer), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                DestroyOnEmpty: </color>" + val3.destroyOnEmpty), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                GlobalTimer: </color>" + val3.globalTimer), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                UsesDispersalParticles: </color>" + val3.UsesDispersalParticles), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                DispersalDensity: </color>" + val3.DispersalDensity), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                DispersalMinCoherency: </color>" + val3.DispersalMinCoherency), false);
					ETGModConsole.Log((object)("<color=#ff0000ff>                DispersalMaxCoherency: </color>" + val3.DispersalMaxCoherency), false);
					if ((Object)(object)val3.DispersalParticleSystemPrefab != (Object)null)
					{
						ETGModConsole.Log((object)("<color=#ff0000ff>                Dispersal Particle System: </color>" + ((Object)val3.DispersalParticleSystemPrefab).name), false);
						Component[] componentsInChildren = val3.DispersalParticleSystemPrefab.GetComponentsInChildren<Component>();
						foreach (Component val4 in componentsInChildren)
						{
							ETGModConsole.Log((object)("                        " + ((object)val4).GetType().ToString()), false);
						}
					}
				}
			}
			num++;
		}
	}
}
