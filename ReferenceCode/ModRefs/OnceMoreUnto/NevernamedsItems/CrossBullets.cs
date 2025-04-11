using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class CrossBullets : PassiveItem
{
	public static int CrossBulletsID;

	public bool isActive;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<CrossBullets>("Cross Bullets", "Quad Shot", "Occasionally grants quad shot along the cardinal directions.\n\nTrademark ability of an ancient viking gunslinger.", "crossbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		CrossBulletsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcess(Projectile bullet, float th)
	{
		RecalculateVolley();
	}

	private void RecalculateVolley()
	{
		bool flag = (double)Random.value <= 0.25;
		if ((!flag || !isActive) && (flag || isActive))
		{
			if (flag && !isActive)
			{
				((PassiveItem)this).Owner.stats.AdditionalVolleyModifiers += ModifyVolley;
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
				isActive = true;
			}
			else if (!flag && isActive)
			{
				((PassiveItem)this).Owner.stats.AdditionalVolleyModifiers -= ModifyVolley;
				((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
				isActive = false;
			}
		}
	}

	private void PostProcessBeam(BeamController beam)
	{
		RecalculateVolley();
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessBeam += PostProcessBeam;
		player.PostProcessProjectile += PostProcess;
		((PassiveItem)this).Pickup(player);
	}

	public void ModifyVolley(ProjectileVolleyData volleyToModify)
	{
		int count = volleyToModify.projectiles.Count;
		for (int i = 0; i < count; i++)
		{
			ProjectileModule val = volleyToModify.projectiles[i];
			float num = -15f;
			int num2 = 0;
			for (int j = 0; j < 3; j++)
			{
				int num3 = i;
				if (val.CloneSourceIndex >= 0)
				{
					num3 = val.CloneSourceIndex;
				}
				ProjectileModule val2 = ProjectileModule.CreateClone(val, false, num3);
				float angleFromAim = num + 10f * (float)j;
				val2.angleFromAim = angleFromAim;
				val2.ignoredForReloadPurposes = true;
				val2.ammoCost = 0;
				switch (num2)
				{
				case 0:
					val2.angleFromAim += 90f;
					num2++;
					break;
				case 1:
					val2.angleFromAim += 180f;
					num2++;
					break;
				case 2:
					val2.angleFromAim -= 90f;
					num2++;
					break;
				}
				volleyToModify.projectiles.Add(val2);
			}
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessBeam -= PostProcessBeam;
		player.PostProcessProjectile -= PostProcess;
		player.stats.AdditionalVolleyModifiers -= ModifyVolley;
		player.stats.RecalculateStats(player, false, false);
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
			((PassiveItem)this).Owner.stats.AdditionalVolleyModifiers -= ModifyVolley;
			((PassiveItem)this).Owner.stats.RecalculateStats(((PassiveItem)this).Owner, false, false);
		}
		((PassiveItem)this).OnDestroy();
	}
}
