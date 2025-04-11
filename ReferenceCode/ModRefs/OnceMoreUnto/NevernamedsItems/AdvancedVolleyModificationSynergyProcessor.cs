using System;
using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AdvancedVolleyModificationSynergyProcessor : MonoBehaviour
{
	public List<AdvancedVolleyModificationSynergyData> synergies = new List<AdvancedVolleyModificationSynergyData>();

	private Gun m_gun;

	public void Awake()
	{
		m_gun = ((Component)this).GetComponent<Gun>();
		if (Object.op_Implicit((Object)(object)m_gun))
		{
			Gun gun = m_gun;
			gun.PostProcessVolley = (Action<ProjectileVolleyData>)Delegate.Combine(gun.PostProcessVolley, new Action<ProjectileVolleyData>(HandleVolleyRebuild));
			if ((Object)(object)synergies.ToList().Find((AdvancedVolleyModificationSynergyData x) => x.ReplacesSourceProjectile) != (Object)null)
			{
				Gun gun2 = m_gun;
				gun2.OnPreFireProjectileModifier = (Func<Gun, Projectile, ProjectileModule, Projectile>)Delegate.Combine(gun2.OnPreFireProjectileModifier, new Func<Gun, Projectile, ProjectileModule, Projectile>(HandlePreFireProjectileReplacement));
			}
		}
	}

	private Projectile HandlePreFireProjectileReplacement(Gun sourceGun, Projectile sourceProjectile, ProjectileModule sourceModule)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Invalid comparison between Unknown and I4
		Projectile result = sourceProjectile;
		PlayerController val = GunTools.GunPlayerOwner(sourceGun);
		if (synergies != null)
		{
			for (int i = 0; i < synergies.Count; i++)
			{
				AdvancedVolleyModificationSynergyData advancedVolleyModificationSynergyData = synergies[i];
				if (!advancedVolleyModificationSynergyData.ReplacesSourceProjectile || !Object.op_Implicit((Object)(object)val) || !CustomSynergies.PlayerHasActiveSynergy(val, advancedVolleyModificationSynergyData.RequiredSynergy) || (advancedVolleyModificationSynergyData.OnlyReplacesAdditionalProjectiles && !sourceModule.ignoredForReloadPurposes) || (Object.op_Implicit((Object)(object)sourceGun) && sourceGun.IsCharging) || (advancedVolleyModificationSynergyData.ReplacementSkipsChargedShots && (int)sourceModule.shootStyle == 3 && sourceModule.chargeProjectiles != null && sourceModule.chargeProjectiles.Find((ChargeProjectile x) => Object.op_Implicit((Object)(object)x.Projectile) && x.ChargeTime > 0f) != null) || !(Random.value < advancedVolleyModificationSynergyData.ReplacementChance))
				{
					continue;
				}
				if (advancedVolleyModificationSynergyData.UsesMultipleReplacementProjectiles)
				{
					if (advancedVolleyModificationSynergyData.MultipleReplacementsSequential)
					{
						result = advancedVolleyModificationSynergyData.MultipleReplacementProjectiles[advancedVolleyModificationSynergyData.multipleSequentialReplacementIndex];
						advancedVolleyModificationSynergyData.multipleSequentialReplacementIndex = (advancedVolleyModificationSynergyData.multipleSequentialReplacementIndex + 1) % advancedVolleyModificationSynergyData.MultipleReplacementProjectiles.Length;
					}
					else
					{
						result = advancedVolleyModificationSynergyData.MultipleReplacementProjectiles[Random.Range(0, advancedVolleyModificationSynergyData.MultipleReplacementProjectiles.Length)];
					}
				}
				else
				{
					result = advancedVolleyModificationSynergyData.ReplacementProjectile;
				}
			}
		}
		return result;
	}

	private void HandleVolleyRebuild(ProjectileVolleyData targetVolley)
	{
		PlayerController val = null;
		if (Object.op_Implicit((Object)(object)m_gun))
		{
			val = GunTools.GunPlayerOwner(m_gun);
		}
		if (!Object.op_Implicit((Object)(object)val) || synergies == null)
		{
			return;
		}
		for (int i = 0; i < synergies.Count; i++)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(val, synergies[i].RequiredSynergy))
			{
				ApplySynergy(targetVolley, synergies[i], val);
			}
		}
	}

	private void ApplySynergy(ProjectileVolleyData volley, AdvancedVolleyModificationSynergyData synergy, PlayerController owner)
	{
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Invalid comparison between Unknown and I4
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Invalid comparison between Unknown and I4
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		if (synergy.AddsChargeProjectile)
		{
			volley.projectiles[0].chargeProjectiles.Add(synergy.ChargeProjectileToAdd);
		}
		if (synergy.AddsModules)
		{
			bool flag = true;
			if ((Object)(object)volley != (Object)null && volley.projectiles.Count > 0 && volley.projectiles[0].projectiles != null && volley.projectiles[0].projectiles.Count > 0)
			{
				Projectile val = volley.projectiles[0].projectiles[0];
				if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((Component)val).GetComponent<ArtfulDodgerProjectileController>()))
				{
					flag = false;
				}
			}
			if (flag)
			{
				for (int i = 0; i < synergy.ModulesToAdd.Length; i++)
				{
					synergy.ModulesToAdd[i].isExternalAddedModule = true;
					volley.projectiles.Add(synergy.ModulesToAdd[i]);
				}
			}
		}
		if (synergy.AddsDuplicatesOfBaseModule)
		{
			GunVolleyModificationItem.AddDuplicateOfBaseModule(volley, GunTools.GunPlayerOwner(m_gun), synergy.DuplicatesOfBaseModule, synergy.BaseModuleDuplicateAngle, 0f);
		}
		if (synergy.SetsNumberFinalProjectiles)
		{
			bool flag2 = false;
			for (int j = 0; j < volley.projectiles.Count; j++)
			{
				if (!flag2 && synergy.AddsNewFinalProjectile && !volley.projectiles[j].usesOptionalFinalProjectile)
				{
					flag2 = true;
					m_gun.OverrideFinaleAudio = true;
					volley.projectiles[j].usesOptionalFinalProjectile = true;
					volley.projectiles[j].numberOfFinalProjectiles = 1;
					volley.projectiles[j].finalProjectile = synergy.NewFinalProjectile;
					volley.projectiles[j].finalAmmoType = (AmmoType)14;
					volley.projectiles[j].finalCustomAmmoType = synergy.NewFinalProjectileAmmoType;
					if (string.IsNullOrEmpty(m_gun.finalShootAnimation))
					{
						m_gun.finalShootAnimation = m_gun.shootAnimation;
					}
				}
				if (volley.projectiles[j].usesOptionalFinalProjectile)
				{
					volley.projectiles[j].numberOfFinalProjectiles = synergy.NumberFinalProjectiles;
				}
			}
		}
		if (synergy.SetsBurstCount)
		{
			if (synergy.MakesDefaultModuleBurst && volley.projectiles.Count > 0 && (int)volley.projectiles[0].shootStyle != 4)
			{
				volley.projectiles[0].shootStyle = (ShootStyle)4;
			}
			for (int k = 0; k < volley.projectiles.Count; k++)
			{
				if ((int)volley.projectiles[k].shootStyle == 4)
				{
					int burstShotCount = volley.projectiles[k].burstShotCount;
					int num = volley.projectiles[k].GetModNumberOfShotsInClip((GameActor)(object)owner);
					if (num < 0)
					{
						num = int.MaxValue;
					}
					int burstShotCount2 = Mathf.Clamp(Mathf.RoundToInt((float)burstShotCount * synergy.BurstMultiplier) + synergy.BurstShift, 1, num);
					volley.projectiles[k].burstShotCount = burstShotCount2;
				}
			}
		}
		if (synergy.AddsPossibleProjectileToPrimaryModule)
		{
			volley.projectiles[0].projectiles.Add(synergy.AdditionalModuleProjectile);
		}
	}
}
