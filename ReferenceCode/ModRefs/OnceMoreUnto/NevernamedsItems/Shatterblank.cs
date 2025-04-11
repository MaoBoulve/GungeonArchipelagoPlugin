using System;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class Shatterblank : BlankModificationItem
{
	private static int ShatterblankID;

	public static Projectile shatterProj;

	private static Hook BlankHook = new Hook((MethodBase)typeof(SilencerInstance).GetMethod("ProcessBlankModificationItemAdditionalEffects", BindingFlags.Instance | BindingFlags.NonPublic), typeof(Shatterblank).GetMethod("BlankModHook", BindingFlags.Instance | BindingFlags.Public), (object)typeof(SilencerInstance));

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Shatterblank>("Shatterblank", "Fragmentation", "Blanks release dangerous shrapnel.\n\nThis artefact was originally part of a brittle Ammolet, before the whole thing was shattered into a thousand tiny pieces.", "shatterblank_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 1f, (ModifyMethod)0);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ShatterblankID = ((PickupObject)val).PickupObjectId;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val2.baseData.damage = 6f;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 4f;
		BounceProjModifier val3 = ((Component)val2).gameObject.AddComponent<BounceProjModifier>();
		val3.numberOfBounces += 3;
		shatterProj = val2;
	}

	public override void Pickup(PlayerController player)
	{
		((BlankModificationItem)this).Pickup(player);
	}

	public void BlankModHook(Action<SilencerInstance, BlankModificationItem, Vector2, PlayerController> orig, SilencerInstance silencer, BlankModificationItem bmi, Vector2 centerPoint, PlayerController user)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Invalid comparison between Unknown and I4
		orig(silencer, bmi, centerPoint, user);
		if (!user.HasPickupID(ShatterblankID))
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < 15; i++)
		{
			GameObject gameObject = ((Component)shatterProj).gameObject;
			bool flag = false;
			bool flag2 = false;
			if (CustomSynergies.PlayerHasActiveSynergy(user, "Frag Mental") && Object.op_Implicit((Object)(object)((GameActor)user).CurrentGun) && Random.value <= 0.2f)
			{
				if ((int)((GameActor)user).CurrentGun.DefaultModule.shootStyle == 3)
				{
					for (int j = 0; j < ((GameActor)user).CurrentGun.DefaultModule.chargeProjectiles.Count; j++)
					{
						if (((GameActor)user).CurrentGun.DefaultModule.chargeProjectiles[j] != null && (Object)(object)((GameActor)user).CurrentGun.DefaultModule.chargeProjectiles[j].Projectile != (Object)null)
						{
							gameObject = ((Component)((GameActor)user).CurrentGun.DefaultModule.chargeProjectiles[j].Projectile).gameObject;
							break;
						}
					}
				}
				else if ((int)((GameActor)user).CurrentGun.DefaultModule.shootStyle == 2)
				{
					gameObject = ((Component)((GameActor)user).CurrentGun.DefaultModule.projectiles[0]).gameObject;
					flag2 = true;
				}
				else
				{
					gameObject = ((Component)((GameActor)user).CurrentGun.DefaultModule.projectiles[0]).gameObject;
				}
				flag = true;
			}
			if (flag2)
			{
				BeamController val = BeamController.FreeFireBeam(gameObject.GetComponent<Projectile>(), user, num, 3f, true);
				if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((Component)val).GetComponent<Projectile>()))
				{
					Projectile component = ((Component)val).GetComponent<Projectile>();
					if (user.stats.GetStatValue((StatType)5) >= 1f)
					{
						ProjectileData baseData = component.baseData;
						baseData.damage *= user.stats.GetStatValue((StatType)5);
					}
					ProjectileData baseData2 = component.baseData;
					baseData2.range *= user.stats.GetStatValue((StatType)26);
					ProjectileData baseData3 = component.baseData;
					baseData3.speed *= user.stats.GetStatValue((StatType)6);
					component.UpdateSpeed();
					ProjectileData baseData4 = component.baseData;
					baseData4.range *= 4f;
					BounceProjModifier val2 = ((Component)component).gameObject.AddComponent<BounceProjModifier>();
					val2.numberOfBounces += 3;
				}
			}
			else
			{
				GameObject val3 = SpawnManager.SpawnProjectile(gameObject, Vector2.op_Implicit(centerPoint), Quaternion.Euler(0f, 0f, num), true);
				Projectile component2 = val3.GetComponent<Projectile>();
				if ((Object)(object)component2 != (Object)null)
				{
					component2.TreatedAsNonProjectileForChallenge = true;
					component2.Owner = (GameActor)(object)user;
					component2.Shooter = ((BraveBehaviour)user).specRigidbody;
					user.DoPostProcessProjectile(component2);
					if (user.stats.GetStatValue((StatType)5) >= 1f)
					{
						ProjectileData baseData5 = component2.baseData;
						baseData5.damage *= user.stats.GetStatValue((StatType)5);
					}
					ProjectileData baseData6 = component2.baseData;
					baseData6.range *= user.stats.GetStatValue((StatType)26);
					ProjectileData baseData7 = component2.baseData;
					baseData7.speed *= user.stats.GetStatValue((StatType)6);
					component2.UpdateSpeed();
					if (flag)
					{
						ProjectileData baseData8 = component2.baseData;
						baseData8.range *= 4f;
						BounceProjModifier val4 = ((Component)component2).gameObject.AddComponent<BounceProjModifier>();
						val4.numberOfBounces += 3;
					}
				}
			}
			num += 24f;
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((BlankModificationItem)this).Drop(player);
	}
}
