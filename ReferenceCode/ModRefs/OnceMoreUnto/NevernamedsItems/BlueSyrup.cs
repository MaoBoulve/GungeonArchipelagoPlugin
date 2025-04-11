using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BlueSyrup : PassiveItem
{
	public static int ID;

	public float countdownToNextBubble = 10f;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BlueSyrup>("Blue Syrup", "Blank Label", "Goes down smooth, comes up rough.\n\nAn old fashioned cure-all for whatever ails you. It tastes like gasoline.", "bluesyrup_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop(val, (ShopType)0, 1f);
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
		ID = val.PickupObjectId;
	}

	public override void Update()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.IsInCombat)
		{
			if (countdownToNextBubble > 0f)
			{
				countdownToNextBubble -= BraveTime.DeltaTime;
			}
			else
			{
				AkSoundEngine.PostEvent("Play_WPN_Bubbler_Drink_01", ((Component)this).gameObject);
				PickupObject byId = PickupObjectDatabase.GetById(599);
				GameObject val = ProjectileUtility.InstantiateAndFireInDirection(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[Random.Range(0, 3)], ((GameActor)((PassiveItem)this).Owner).CenterPosition, Object.op_Implicit((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun) ? ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle : 0f, 10f, (PlayerController)null);
				Projectile component = val.GetComponent<Projectile>();
				if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)component))
				{
					component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
					component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
					val.AddComponent<BlankProjModifier>().blankType = (EasyBlankType)0;
					DistortionWaveDamager distortionWaveDamager = val.AddComponent<DistortionWaveDamager>();
					distortionWaveDamager.Damage = 5f;
					distortionWaveDamager.Range = 3.5f;
					distortionWaveDamager.stunDuration = 5f;
					HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(val);
					orAddComponent.AngularVelocity = 1000f;
					orAddComponent.HomingRadius = 1000f;
					component.AdjustPlayerProjectileTint(Color.blue, 1, 0f);
					ProjectileData baseData = component.baseData;
					baseData.speed *= 3f;
					component.UpdateSpeed();
				}
				countdownToNextBubble = Random.Range(10f, 20f);
			}
		}
		((PassiveItem)this).Update();
	}
}
