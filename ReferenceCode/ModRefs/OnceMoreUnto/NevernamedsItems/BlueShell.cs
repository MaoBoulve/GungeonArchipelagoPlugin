using Alexandria.ItemAPI;
using Alexandria.VisualAPI;
using UnityEngine;

namespace NevernamedsItems;

public class BlueShell : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BlueShell>("Blue Shell", "Catch-Up Mechanic", "These shells are feared by Gundead and Gungeoneer alike for their relentless hunting nature. To be sought by a blue shell, is to be found by a blue shell...", "blueshell_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcess;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= PostProcess;
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void PostProcess(Projectile p, float i)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)p) && Random.value <= 0.15f * i)
		{
			p.AdjustPlayerProjectileTint(Color.blue, 2, 0f);
			if ((Object)(object)((Component)p).GetComponent<ImprovedAfterImage>() == (Object)null && (Object)(object)((BraveBehaviour)p).sprite != (Object)null)
			{
				ImprovedAfterImage val = ((Component)p).gameObject.AddComponent<ImprovedAfterImage>();
				val.spawnShadows = true;
				val.shadowLifetime = Random.Range(0.1f, 0.2f);
				val.shadowTimeDelay = 0.003f;
				val.dashColor = Color.blue;
				((Object)val).name = "BlueShellsTrail";
			}
			HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)p).gameObject);
			orAddComponent.AngularVelocity += 1200f;
			orAddComponent.HomingRadius += 600f;
			p.baseData.range = 1000f;
			ProjectileData baseData = p.baseData;
			baseData.damage *= 1.2f;
		}
	}
}
