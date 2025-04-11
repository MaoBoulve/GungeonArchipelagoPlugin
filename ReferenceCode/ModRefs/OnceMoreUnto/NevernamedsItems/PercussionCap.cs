using System;
using System.Reflection;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

internal class PercussionCap : BlankModificationItem
{
	public static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<PercussionCap>("Percussion Cap", "Blanks Enspore", "This mushroom cap responds to the resonant frequency of blanks, letting it know that it's time to release it's spores.", "bluecap_icon", assetbundle: true);
		BlankModificationItem val = (BlankModificationItem)(object)((obj is BlankModificationItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)4, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)18, 1f, (ModifyMethod)0);
		val.BlankStunTime = 0f;
		new Hook((MethodBase)typeof(SilencerInstance).GetMethod("ProcessBlankModificationItemAdditionalEffects", BindingFlags.Instance | BindingFlags.NonPublic), typeof(PercussionCap).GetMethod("BlankModHook", BindingFlags.Instance | BindingFlags.Public), (object)typeof(SilencerInstance));
	}

	public void BlankModHook(Action<SilencerInstance, BlankModificationItem, Vector2, PlayerController> orig, SilencerInstance silencer, BlankModificationItem bmi, Vector2 centerPoint, PlayerController user)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		orig(silencer, bmi, centerPoint, user);
		if (!((Object)(object)bmi != (Object)null) || ((PickupObject)bmi).PickupObjectId != ID || !((Object)(object)user != (Object)null))
		{
			return;
		}
		AkSoundEngine.PostEvent("Play_ENM_mushroom_cloud_01", ((Component)user).gameObject);
		for (int i = 0; i < 30; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(FungoCannon.FungoCannonID);
			GameObject gameObject = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile).gameObject;
			GameObject val = Object.Instantiate<GameObject>(gameObject, Vector2.op_Implicit(centerPoint), Quaternion.Euler(new Vector3(0f, 0f, (float)Random.Range(0, 360))));
			Projectile component = val.GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.Owner = (GameActor)(object)user;
				component.Shooter = ((BraveBehaviour)user).specRigidbody;
				ProjectileData baseData = component.baseData;
				baseData.damage *= user.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= user.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.range *= user.stats.GetStatValue((StatType)26);
				ProjectileData baseData4 = component.baseData;
				baseData4.force *= user.stats.GetStatValue((StatType)12);
				component.BossDamageMultiplier *= user.stats.GetStatValue((StatType)22);
				component.UpdateSpeed();
				if (CustomSynergies.PlayerHasActiveSynergy(user, "Screamosynthesis") && Random.value <= 0.07f)
				{
					ExplosiveModifier val2 = ((Component)component).gameObject.AddComponent<ExplosiveModifier>();
					val2.doExplosion = true;
					val2.explosionData = StaticExplosionDatas.explosiveRoundsExplosion;
				}
				user.DoPostProcessProjectile(component);
			}
		}
	}
}
