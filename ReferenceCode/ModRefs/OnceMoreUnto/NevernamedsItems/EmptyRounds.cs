using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class EmptyRounds : PassiveItem
{
	public static void Init()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<EmptyRounds>("Empty Rounds", "Less is More", "Increases damage by how empty your guns are of ammo.\n\nBrought to the Gungeon by a dopey gnome who felt it suited his spray-and-pray combat style.\nHe lost it within an hour.\nTypical.", "emptybullets_improved", assetbundle: true);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcessBeam(BeamController beam)
	{
		if (Object.op_Implicit((Object)(object)beam))
		{
			Projectile projectile = ((BraveBehaviour)beam).projectile;
			if (Object.op_Implicit((Object)(object)projectile))
			{
				PostProcess(projectile, 1f);
			}
		}
	}

	private void PostProcess(Projectile bullet, float var)
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		foreach (Gun allGun in ((PassiveItem)this).Owner.inventory.AllGuns)
		{
			if (!allGun.InfiniteAmmo)
			{
				num += allGun.AdjustedMaxAmmo;
				num2 += allGun.CurrentAmmo;
			}
		}
		float num3 = num - num2;
		float num4 = num3 / (float)num;
		ProjectileData baseData = bullet.baseData;
		baseData.damage *= num4 + 1f;
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcess;
		player.PostProcessBeam += PostProcessBeam;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcess;
		player.PostProcessBeam -= PostProcessBeam;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
