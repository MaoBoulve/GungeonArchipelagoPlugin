using UnityEngine;

namespace NevernamedsItems;

public class InvisibleGun : MonoBehaviour
{
	public Gun gun;

	public void Start()
	{
		gun = ((Component)this).GetComponent<Gun>();
	}

	public void LateUpdate()
	{
		if ((Object)(object)gun != (Object)null && Challenges.CurrentChallenge == ChallengeType.INVISIBLEO)
		{
			HandleVFX(gun.muzzleFlashEffects, value: false);
			HandleVFX(gun.finalMuzzleFlashEffects, value: false);
			HandleVFX(gun.reloadEffects, value: false);
			HandleVFX(gun.emptyReloadEffects, value: false);
			HandleVFX(gun.activeReloadSuccessEffects, value: false);
			HandleVFX(gun.activeReloadFailedEffects, value: false);
			HandleVFX(gun.CriticalMuzzleFlashEffects, value: false);
			gun.ToggleRenderers(false);
		}
		else if ((Object)(object)gun != (Object)null)
		{
			HandleVFX(gun.muzzleFlashEffects, value: true);
			HandleVFX(gun.finalMuzzleFlashEffects, value: true);
			HandleVFX(gun.reloadEffects, value: true);
			HandleVFX(gun.emptyReloadEffects, value: true);
			HandleVFX(gun.activeReloadSuccessEffects, value: true);
			HandleVFX(gun.activeReloadFailedEffects, value: true);
			HandleVFX(gun.CriticalMuzzleFlashEffects, value: true);
		}
	}

	public void HandleVFX(VFXPool vfx, bool value)
	{
		if (vfx != null && vfx.effects != null)
		{
			vfx.ToggleRenderers(value);
		}
	}
}
