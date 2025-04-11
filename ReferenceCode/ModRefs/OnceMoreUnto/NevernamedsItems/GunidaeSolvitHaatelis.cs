using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GunidaeSolvitHaatelis : PlayerItem
{
	private float duration = 15f;

	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GunidaeSolvitHaatelis>("Gunidae solvit Haatelis", "As It Is Written", "An excerpt from an ancient holy text of the Order.\n\nReading it has enough power to bend the motion of bullets to your will.", "gunidaesolvithaatelis_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 350f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.ALLJAMMED_BEATEN_ABBEY, requiredFlagValue: true);
	}

	public override void DoEffect(PlayerController user)
	{
		List<AIActor> activeEnemies = user.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies != null)
		{
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor val = activeEnemies[i];
				if (val.IsBlackPhantom)
				{
					val.UnbecomeBlackPhantom();
				}
			}
		}
		foreach (Projectile allProjectile in StaticReferenceManager.AllProjectiles)
		{
			if (Object.op_Implicit((Object)(object)allProjectile) && ((Behaviour)allProjectile).isActiveAndEnabled && !(allProjectile.Owner is PlayerController) && allProjectile.IsBlackBullet)
			{
				allProjectile.ReturnFromBlackBullet();
			}
		}
		Projectile.BaseEnemyBulletSpeedMultiplier *= 0.5f;
		((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndEffect));
	}

	private void EndEffect(PlayerController user)
	{
		Projectile.BaseEnemyBulletSpeedMultiplier /= 0.5f;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return true;
	}
}
