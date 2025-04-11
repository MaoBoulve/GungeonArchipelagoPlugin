using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class HelmOfChaos : PlayerItem
{
	public static List<Projectile> PossibleProj = new List<Projectile>();

	public static List<Projectile> PowerfulProj = new List<Projectile>();

	private static int activatedSpriteID;

	private static int deactivatedSpriteID;

	private bool isActivated = false;

	public static void Init()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<HelmOfChaos>("Helm Of Chaos", "Embraced", "Don the helm to embrace chaos!\n\nThis helmet was created spontaneously out of loose particles colliding in the void of space via a process known as 'Boltzmann Forging'.", "helmofchaos_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		activatedSpriteID = Initialisation.itemCollection.GetSpriteIdByName("helmofchaos_activated");
		deactivatedSpriteID = Initialisation.itemCollection.GetSpriteIdByName("helmofchaos_icon");
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 2.5f, (ModifyMethod)0);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 0f);
		((PickupObject)val).quality = (ItemQuality)5;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BEATEN_HELL_BOSS_TURBO_MODE, requiredFlagValue: true);
		PossibleProj.AddRange(new List<Projectile>
		{
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).Volley.projectiles[1].projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).Volley.projectiles[4].projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).Volley.projectiles[0].projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).Volley.projectiles[2].projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).Volley.projectiles[3].projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).Volley.projectiles[4].projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.chargeProjectiles[0].Projectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.chargeProjectiles[0].Projectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.chargeProjectiles[0].Projectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.chargeProjectiles[0].Projectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.finalProjectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.finalProjectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[1]
		});
		PowerfulProj.AddRange(new List<Projectile>
		{
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.finalProjectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.finalProjectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.finalProjectile,
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0],
			((Gun)/*isinst with value type is only supported in some contexts*/).DefaultModule.projectiles[0]
		});
	}

	public override void OnPreDrop(PlayerController user)
	{
		if (isActivated)
		{
			Deactivate(user);
		}
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.LastOwner) && isActivated)
		{
			Deactivate(base.LastOwner);
		}
	}

	public override void DoEffect(PlayerController user)
	{
		if (isActivated)
		{
			Deactivate(user);
		}
		else
		{
			Activate(user);
		}
	}

	public void Activate(PlayerController pl)
	{
		isActivated = true;
		if (Object.op_Implicit((Object)(object)pl))
		{
			pl.OnPreFireProjectileModifier = (Func<Gun, Projectile, Projectile>)Delegate.Combine(pl.OnPreFireProjectileModifier, new Func<Gun, Projectile, Projectile>(PreFireProj));
		}
		((BraveBehaviour)this).sprite.SetSprite(activatedSpriteID);
	}

	public void Deactivate(PlayerController pl)
	{
		isActivated = false;
		if (Object.op_Implicit((Object)(object)pl))
		{
			pl.OnPreFireProjectileModifier = (Func<Gun, Projectile, Projectile>)Delegate.Remove(pl.OnPreFireProjectileModifier, new Func<Gun, Projectile, Projectile>(PreFireProj));
		}
		((BraveBehaviour)this).sprite.SetSprite(deactivatedSpriteID);
	}

	public Projectile PreFireProj(Gun gu, Projectile proj)
	{
		if (Object.op_Implicit((Object)(object)base.LastOwner) && !gu.InfiniteAmmo)
		{
			int num = 0;
			int num2 = PossibleProj.Count - 1;
			if (CustomSynergies.PlayerHasActiveSynergy(base.LastOwner, "Liber Null"))
			{
				num2 += PowerfulProj.Count - 1;
			}
			num = Random.Range(0, num2 + 1);
			if (num > PossibleProj.Count - 1)
			{
				return PowerfulProj[num - PossibleProj.Count - 1];
			}
			return PossibleProj[num];
		}
		return proj;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
