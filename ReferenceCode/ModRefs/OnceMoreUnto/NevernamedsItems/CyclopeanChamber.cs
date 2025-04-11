using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class CyclopeanChamber : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CyclopeanChamber>("Cyclopean Cylinder", "Make It Count", "Reduces clips to one shot, but increases damage for every bullet removed.\n\nOnce thought to be the cylinder of a powerful one-chambered firerarm, further research suggests this artefact may be the chamber of an ancient Elephant Gun.", "cyclopeancylinder_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)16, 1E-09f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)3;
		ID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcess;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcess;
		return ((PassiveItem)this).Drop(player);
	}

	private void PostProcess(Projectile bullet, float flot)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		if (!Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)))
		{
			return;
		}
		Gun currentGun = ((GameActor)ProjectileUtility.ProjectilePlayerOwner(bullet)).CurrentGun;
		if (!Object.op_Implicit((Object)(object)currentGun) || (int)currentGun.DefaultModule.shootStyle == 2)
		{
			return;
		}
		float num = currentGun.ClipCapacity;
		float num2 = currentGun.DefaultModule.numberOfShotsInClip;
		if (num2 - num > 0f)
		{
			float num3 = (num2 - num) * 0.25f;
			if (currentGun.reloadTime < 1f)
			{
				num3 *= currentGun.reloadTime;
			}
			ProjectileData baseData = bullet.baseData;
			baseData.damage *= 1f + num3;
		}
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
		}
		((PassiveItem)this).OnDestroy();
	}
}
