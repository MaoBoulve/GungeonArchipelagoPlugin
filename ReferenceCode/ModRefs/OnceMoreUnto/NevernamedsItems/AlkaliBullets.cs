using Alexandria.ItemAPI;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class AlkaliBullets : PassiveItem
{
	public static int AlkaliBulletsID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<AlkaliBullets>("Alkali Bullets", "Violent Reaction", "The alkali metals that make up these slugs react violently with the copious amounts of fluid present in Blobulonian creatures.", "alkalibullets_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddToSubShop(val, (ShopType)0, 1f);
		val.SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_ALKALIBULLETS, requiredFlagValue: true);
		val.AddItemToGooptonMetaShop(30, null);
		AlkaliBulletsID = val.PickupObjectId;
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
		orAddComponent.tagsToKill.Add("blobulon");
		orAddComponent.protectBosses = false;
		orAddComponent.enemyGUIDSToEraseFromExistence.Add(EnemyGuidDatabase.Entries["bloodbulon"]);
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
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		((PassiveItem)this).DisableEffect(player);
	}
}
