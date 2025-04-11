using UnityEngine;

namespace NevernamedsItems;

public class AdvancedVolleyModificationSynergyData : ScriptableObject
{
	public string RequiredSynergy;

	public bool AddsChargeProjectile;

	public ChargeProjectile ChargeProjectileToAdd;

	public bool AddsModules;

	public ProjectileModule[] ModulesToAdd;

	public bool AddsDuplicatesOfBaseModule;

	public int DuplicatesOfBaseModule;

	public float BaseModuleDuplicateAngle = 10f;

	public bool ReplacesSourceProjectile;

	public float ReplacementChance = 1f;

	public bool OnlyReplacesAdditionalProjectiles;

	public Projectile ReplacementProjectile;

	public bool UsesMultipleReplacementProjectiles;

	public bool MultipleReplacementsSequential;

	public Projectile[] MultipleReplacementProjectiles;

	public bool ReplacementSkipsChargedShots;

	public bool SetsNumberFinalProjectiles;

	public int NumberFinalProjectiles = 1;

	public bool AddsNewFinalProjectile;

	public Projectile NewFinalProjectile;

	public string NewFinalProjectileAmmoType;

	public bool SetsBurstCount;

	public bool MakesDefaultModuleBurst;

	public float BurstMultiplier = 1f;

	public int BurstShift;

	public bool AddsPossibleProjectileToPrimaryModule;

	public Projectile AdditionalModuleProjectile;

	public int multipleSequentialReplacementIndex;
}
