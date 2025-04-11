using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class AdjustGunPosition
{
	public static List<tk2dSpriteAnimationClip> GetGunAnimationClips(Gun gun)
	{
		List<tk2dSpriteAnimationClip> list = new List<tk2dSpriteAnimationClip>();
		if (!string.IsNullOrEmpty(gun.shootAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.shootAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.shootAnimation));
		}
		if (!string.IsNullOrEmpty(gun.reloadAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.reloadAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.reloadAnimation));
		}
		if (!string.IsNullOrEmpty(gun.emptyReloadAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.emptyReloadAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.emptyReloadAnimation));
		}
		if (!string.IsNullOrEmpty(gun.idleAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.idleAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.idleAnimation));
		}
		if (!string.IsNullOrEmpty(gun.chargeAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation));
		}
		if (!string.IsNullOrEmpty(gun.dischargeAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.dischargeAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.dischargeAnimation));
		}
		if (!string.IsNullOrEmpty(gun.emptyAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.emptyAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.emptyAnimation));
		}
		if (!string.IsNullOrEmpty(gun.introAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.introAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.introAnimation));
		}
		if (!string.IsNullOrEmpty(gun.finalShootAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.finalShootAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.finalShootAnimation));
		}
		if (!string.IsNullOrEmpty(gun.enemyPreFireAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.enemyPreFireAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.enemyPreFireAnimation));
		}
		if (!string.IsNullOrEmpty(gun.outOfAmmoAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.outOfAmmoAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.outOfAmmoAnimation));
		}
		if (!string.IsNullOrEmpty(gun.criticalFireAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.criticalFireAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.criticalFireAnimation));
		}
		if (!string.IsNullOrEmpty(gun.dodgeAnimation) && ((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.dodgeAnimation) != null)
		{
			list.Add(((Component)gun).GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.dodgeAnimation));
		}
		return list;
	}
}
