using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ExpandingBullets : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<ExpandingBullets>("Expanding Bullets", "Dummy!", "Designed to expand upon impact with a target, these bullets are too dim to understand where they are- continually expanding and contracting in the air.", "expandingbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddPassiveStatModifier(val, (StatType)26, 1.3f, (ModifyMethod)1);
		ID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += OnPost;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= OnPost;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnPost(Projectile bullet, float ch)
	{
		if (Object.op_Implicit((Object)(object)((Component)bullet).gameObject.GetComponent<OscillatingProjectileModifier>()))
		{
			OscillatingProjectileModifier component = ((Component)bullet).gameObject.GetComponent<OscillatingProjectileModifier>();
			component.multiplyDamage = true;
			component.multiplyScale = true;
			component.multiplySpeed = true;
			component.maxDamageMult += 0.8f;
			component.minDamageMult = Mathf.Max(0f, component.minDamageMult - 0.2f);
		}
		else
		{
			OscillatingProjectileModifier oscillatingProjectileModifier = ((Component)bullet).gameObject.AddComponent<OscillatingProjectileModifier>();
			oscillatingProjectileModifier.multiplyDamage = true;
			oscillatingProjectileModifier.multiplyScale = true;
			oscillatingProjectileModifier.multiplySpeed = true;
			oscillatingProjectileModifier.maxDamageMult = 1.8f;
			oscillatingProjectileModifier.minDamageMult = 0.8f;
		}
	}
}
