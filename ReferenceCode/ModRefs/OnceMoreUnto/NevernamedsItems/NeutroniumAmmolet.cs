using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class NeutroniumAmmolet : BlankModificationItem
{
	private static int ID;

	public static void Init()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<NeutroniumAmmolet>("Neutronium Ammolet", "Blanks Unravel", "An impossible element with no protons, created in the mantle of a neutron star.\n\nCrushes nearby spacetime when agitated by a blank.", "neutroniumammolet_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 1f, (ModifyMethod)0);
		((PickupObject)val).quality = (ItemQuality)4;
		ID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_NEUTRONIUMAMMOLET, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToDougMetaShop(60, null);
		AlexandriaTags.SetTag((PickupObject)(object)val, "ammolet");
	}

	public override void Pickup(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Combine(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((BlankModificationItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		ExtendedPlayerComponent extComp = PlayerUtility.GetExtComp(player);
		extComp.OnBlankModificationItemProcessed = (Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>)Delegate.Remove(extComp.OnBlankModificationItemProcessed, new Action<PlayerController, SilencerInstance, Vector2, BlankModificationItem>(OnBlankModTriggered));
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnBlankModTriggered(PlayerController user, SilencerInstance blank, Vector2 pos, BlankModificationItem item)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (item is NeutroniumAmmolet)
		{
			Projectile val = ((Gun)Databases.Items["black_hole_gun"]).DefaultModule.projectiles[0];
			GameObject val2 = SpawnManager.SpawnProjectile(((Component)val).gameObject, Vector2.op_Implicit(pos), Quaternion.identity, true);
			Projectile component = val2.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)user;
				component.Shooter = ((BraveBehaviour)user).specRigidbody;
				component.baseData.speed = 0f;
				ProjectileData baseData = component.baseData;
				baseData.range *= 100f;
				BulletLifeTimer bulletLifeTimer = ((Component)component).gameObject.AddComponent<BulletLifeTimer>();
				bulletLifeTimer.secondsTillDeath = 7f;
				user.DoPostProcessProjectile(component);
			}
		}
	}
}
