using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class WitheringChamber : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<WitheringChamber>("Withering Chamber", "Decay", "Guns with higher max ammo deal more damage, but suffering damage withers away your ammo capacity.\n\nThe spiteful creation of a cruel Chamberlord.", "witheringchamber_icon_001", assetbundle: true);
		val.quality = (ItemQuality)3;
		ID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnReceivedDamage += OnHit;
		player.PostProcessBeam += PostProcessBeam;
		player.PostProcessProjectile += PostProcessProjectile;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.OnReceivedDamage -= OnHit;
		player.PostProcessBeam -= PostProcessBeam;
		player.PostProcessProjectile -= PostProcessProjectile;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnReceivedDamage -= OnHit;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
		}
		((PassiveItem)this).OnDestroy();
	}

	private void OnHit(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player) && Object.op_Implicit((Object)(object)((GameActor)player).CurrentGun))
		{
			float num = 1f;
			if (CustomSynergies.PlayerHasActiveSynergy(player, "Chamrock"))
			{
				num = 0.5f;
			}
			if (!((GameActor)player).CurrentGun.InfiniteAmmo && ((GameActor)player).CurrentGun.GetBaseMaxAmmo() > 0 && Random.value <= num)
			{
				int currentAmmo = ((GameActor)player).CurrentGun.CurrentAmmo;
				((GameActor)player).CurrentGun.SetBaseMaxAmmo(currentAmmo);
			}
		}
	}

	private void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)beam) && (Object)(object)((Component)beam).GetComponent<Projectile>() != (Object)null)
		{
			PostProcessProjectile(((Component)beam).GetComponent<Projectile>(), 1f);
		}
	}

	private void PostProcessProjectile(Projectile sourceBullet, float thing)
	{
		if (!Object.op_Implicit((Object)(object)sourceBullet) || !Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(sourceBullet)) || !((Object)(object)((GameActor)ProjectileUtility.ProjectilePlayerOwner(sourceBullet)).CurrentGun != (Object)null))
		{
			return;
		}
		if (((GameActor)ProjectileUtility.ProjectilePlayerOwner(sourceBullet)).CurrentGun.InfiniteAmmo)
		{
			ProjectileData baseData = sourceBullet.baseData;
			baseData.damage *= 1.25f;
			return;
		}
		int adjustedMaxAmmo = ((GameActor)ProjectileUtility.ProjectilePlayerOwner(sourceBullet)).CurrentGun.AdjustedMaxAmmo;
		if (adjustedMaxAmmo > 0)
		{
			float num = adjustedMaxAmmo / 200 + 1;
			ProjectileData baseData2 = sourceBullet.baseData;
			baseData2.damage *= num;
		}
	}
}
