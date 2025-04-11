using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class MistakeBullets : PassiveItem
{
	public static int MistakeBulletsID;

	public static void Init()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MistakeBullets>("Mistake Bullets", "Your Bullets Suck!", "Gain a firerate and reload speed bonus, in exchange for negative knockback.\n\nNo relation to the actual Mistake though. These bullets were made by a hunchbacked hermit living in space Albania or something.", "mistakebullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)12, -3f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)1, 1.2f, (ModifyMethod)1);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)10, 0.7f, (ModifyMethod)1);
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.quality = (ItemQuality)1;
		MistakeBulletsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void PostProcess(Projectile bullet, float bleh)
	{
		if (Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(bullet), "For Big Mistakes"))
		{
			ProjectileData baseData = bullet.baseData;
			baseData.force *= -1f;
		}
	}

	private void ProcessBeam(BeamController beam)
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

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			PickupObject byId = PickupObjectDatabase.GetById(565);
			player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId is PassiveItem) ? byId : null));
			PickupObject byId2 = PickupObjectDatabase.GetById(127);
			player.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((byId2 is PassiveItem) ? byId2 : null));
		}
		player.PostProcessProjectile += PostProcess;
		player.PostProcessBeam += ProcessBeam;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcess;
		player.PostProcessBeam -= ProcessBeam;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
			((PassiveItem)this).Owner.PostProcessBeam -= ProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
