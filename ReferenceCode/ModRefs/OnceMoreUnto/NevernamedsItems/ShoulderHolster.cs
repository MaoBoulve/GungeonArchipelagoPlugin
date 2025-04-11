using System;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class ShoulderHolster : PassiveItem
{
	public static int ShoulderHolsterID;

	public bool isActive;

	private static Hook hipHolsterShootHook;

	public static void Init()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		PickupObject val = ItemSetup.NewItem<ShoulderHolster>("Shoulder Holster", "Bonus Bullets", "Chance for random bonus shots.\n\nA more than awkward shooting style, that's for certain.", "shoulderholster_icon", assetbundle: true);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)2;
		ShoulderHolsterID = val.PickupObjectId;
		hipHolsterShootHook = new Hook((MethodBase)typeof(FireOnReloadItem).GetMethod("HandleHipHolsterProcessing", BindingFlags.Instance | BindingFlags.NonPublic), typeof(ShoulderHolster).GetMethod("HipHolsterHook", BindingFlags.Instance | BindingFlags.Public), (object)typeof(FireOnReloadItem));
	}

	public void HipHolsterHook(Action<FireOnReloadItem, Projectile> orig, FireOnReloadItem self, Projectile bullet)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)self).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)self).Owner, "Heads, Shoulders, Knees, and Toes"))
		{
			ProjectileData baseData = bullet.baseData;
			baseData.damage *= 2f;
		}
		orig(self, bullet);
	}

	private void PostProcess(Projectile bullet, float th)
	{
		RecalculateVolley();
	}

	private void RecalculateVolley()
	{
		bool flag = Random.value <= 0.33f;
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
		float angleFromAim = Random.Range(1, 360);
		int count = volleyToModify.projectiles.Count;
		for (int i = 0; i < count; i++)
		{
			ProjectileModule val = volleyToModify.projectiles[i];
			int num = i;
			if (val.CloneSourceIndex >= 0)
			{
				num = val.CloneSourceIndex;
			}
			ProjectileModule val2 = ProjectileModule.CreateClone(val, false, num);
			val2.angleFromAim = angleFromAim;
			val2.ignoredForReloadPurposes = true;
			val2.ammoCost = 0;
			if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Heads, Shoulders, Knees, and Toes"))
			{
				for (int j = 0; j < val.projectiles.Count; j++)
				{
					Projectile val3 = val.projectiles[j];
					if (Object.op_Implicit((Object)(object)val3))
					{
						Projectile component = FakePrefab.Clone(((Component)val3).gameObject).GetComponent<Projectile>();
						if (Object.op_Implicit((Object)(object)component))
						{
							ProjectileData baseData = component.baseData;
							baseData.damage *= 2f;
							val2.projectiles[j] = component;
						}
					}
				}
			}
			volleyToModify.projectiles.Add(val2);
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
