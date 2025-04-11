using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AntimagicRounds : PassiveItem
{
	public static int AntimagicRoundsID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<AntimagicRounds>("Antimagic Rounds", "Casting Time: 1 Action", "The arcane runes and nullifying antimagic field of these bullets allows them to break through the protective wards of Gunjurers with ease.", "antimagicrounds_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		Doug.AddToLootPool(val.PickupObjectId);
		AntimagicRoundsID = val.PickupObjectId;
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
		orAddComponent.tagsToKill.AddRange(new List<string> { "gunjurer", "gunsinger", "bookllet" });
		orAddComponent.enemyGUIDsToKill.AddRange(new List<string>
		{
			EnemyGuidDatabase.Entries["wizbang"],
			EnemyGuidDatabase.Entries["pot_fairy"]
		});
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)sourceBeam).projectile))
		{
			PostProcessProjectile(((BraveBehaviour)sourceBeam).projectile, 1f);
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.PostProcessProjectile -= PostProcessProjectile;
			player.PostProcessBeam -= PostProcessBeam;
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
