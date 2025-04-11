using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class OsteoporosisBullets : PassiveItem
{
	public static List<string> Skellebosses = new List<string>
	{
		EnemyGuidDatabase.Entries["lich"],
		EnemyGuidDatabase.Entries["megalich"],
		EnemyGuidDatabase.Entries["infinilich"],
		EnemyGuidDatabase.Entries["cannonbalrog"]
	};

	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<OsteoporosisBullets>("Osteoporosis Bullets", "Bad To The Bone", "These bullets are a skele-TON of trouble for the various BONEheads found throughout the Gungeon, leaving them well and truly BONED", "osteoporosisbullets_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		ProjectileInstakillBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)sourceProjectile).gameObject);
		orAddComponent.tagsToKill.Add("skeleton");
		orAddComponent.bossBonusDMG = 7f;
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)sourceBeam).projectile))
		{
			ProjectileInstakillBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)((BraveBehaviour)sourceBeam).projectile).gameObject);
			orAddComponent.tagsToKill.Add("skeleton");
			orAddComponent.bossBonusDMG = 1f;
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProjectile;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
