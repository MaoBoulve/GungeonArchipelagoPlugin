using System;
using System.Reflection;
using Gungeon;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class Ammolite : PassiveItem
{
	public class AmmoliteModifier : GunBehaviour
	{
		public int TimesPickedUpAmmo = 1;

		public override void PostProcessProjectile(Projectile projectile)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			float num = 0.05f * (float)TimesPickedUpAmmo + 1f;
			ProjectileData baseData = projectile.baseData;
			baseData.damage *= num;
			((GunBehaviour)this).PostProcessProjectile(projectile);
		}
	}

	private Hook ammoPickupHook = new Hook((MethodBase)typeof(AmmoPickup).GetMethod("Pickup", BindingFlags.Instance | BindingFlags.Public), typeof(Ammolite).GetMethod("ammoPickupHookMethod"));

	private static bool canGiveDMG;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Ammolite>("Ammolite", "Gemmed Shells", "Refilling a gun with ammo permanently increases it's damage by 5%.\n\nThese beautiful opal-like gemstones are found in strange abundance within Gunymede's crust.", "ammolite_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
	}

	public static void ammoPickupHookMethod(Action<AmmoPickup, PlayerController> orig, AmmoPickup self, PlayerController player)
	{
		orig(self, player);
		if (!player.HasPickupID(Game.Items["nn:ammolite"].PickupObjectId))
		{
			return;
		}
		if (canGiveDMG)
		{
			if (Object.op_Implicit((Object)(object)((Component)((GameActor)player).CurrentGun).GetComponent<AmmoliteModifier>()))
			{
				AmmoliteModifier component = ((Component)((GameActor)player).CurrentGun).GetComponent<AmmoliteModifier>();
				component.TimesPickedUpAmmo++;
			}
			else
			{
				((Component)((GameActor)player).CurrentGun).gameObject.AddComponent<AmmoliteModifier>();
			}
			canGiveDMG = false;
		}
		else
		{
			canGiveDMG = true;
		}
	}
}
