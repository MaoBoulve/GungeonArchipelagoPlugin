using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class Bayonet : PassiveItem
{
	public static void Init()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Bayonet>("Bayonet", "They Don't Like The Cold Steel", "Cuts at your enemies when you reload your weapon.\n\nAn old fashioned blade attached to the end of rifles to add melee proficiency. Angers the Jammed.", "bayonet_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)2;
	}

	private void OnReloadPressed(PlayerController player, Gun gun)
	{
		Slash(player);
	}

	private void PostProcessProjectile(Projectile proj, float thingy)
	{
		if (!proj.TreatedAsNonProjectileForChallenge && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(proj)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(proj), "Hack n' Slash"))
		{
			float num = 0.2f;
			num *= thingy;
			if (Random.value <= num)
			{
				Slash(ProjectileUtility.ProjectilePlayerOwner(proj));
			}
		}
	}

	private void Slash(PlayerController player)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		Vector2 centerPosition = ((GameActor)player).CenterPosition;
		Vector2 val = Vector3Extensions.XY(player.unadjustedAimPoint) - centerPosition;
		Vector2 normalized = ((Vector2)(ref val)).normalized;
		Vector2 val2 = ((GameActor)player).CenterPosition + normalized;
		float currentAngle = ((GameActor)player).CurrentGun.CurrentAngle;
		SlashData val3 = new SlashData();
		val3.damage = 20f * player.stats.GetStatValue((StatType)5);
		val3.enemyKnockbackForce = 10f * player.stats.GetStatValue((StatType)12);
		SlashDoer.DoSwordSlash(val2, currentAngle, (GameActor)(object)player, val3, (Transform)null);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(OnReloadPressed));
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(OnReloadPressed));
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(owner.OnReloadedGun, new Action<PlayerController, Gun>(OnReloadPressed));
		}
		((PassiveItem)this).OnDestroy();
	}
}
