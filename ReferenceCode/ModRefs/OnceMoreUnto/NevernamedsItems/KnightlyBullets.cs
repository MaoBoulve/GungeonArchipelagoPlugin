using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class KnightlyBullets : PassiveItem
{
	public static int KnightlyBulletsID;

	private RoomHandler lastCheckedRoom;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<KnightlyBullets>("Knightly Bullets", "Charthurian", "These high class slugs are reluctant to harm those higher than them in status, but they have no problem squashing the peasantry.\n\nFavoured by the mighty Ser Lammorack, famed Knight of the Octagonal Table, before his untimely demise...", "knightlybullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.CanBeDropped = true;
		KnightlyBulletsID = val.PickupObjectId;
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public override void Update()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && ((PassiveItem)this).Owner.CurrentRoom != null && ((PassiveItem)this).Owner.CurrentRoom != lastCheckedRoom)
		{
			RoomHandler currentRoom = ((PassiveItem)this).Owner.CurrentRoom;
			bool flag = false;
			if ((int)currentRoom.area.PrototypeRoomCategory == 3)
			{
				flag = true;
			}
			else
			{
				for (int i = 0; i < currentRoom.connectedRooms.Count; i++)
				{
					if ((int)currentRoom.connectedRooms[i].area.PrototypeRoomCategory == 3)
					{
						flag = true;
					}
				}
			}
			if (flag && ((PickupObject)this).CanBeDropped)
			{
				((PickupObject)this).CanBeDropped = false;
			}
			else if (!((PickupObject)this).CanBeDropped)
			{
				((PickupObject)this).CanBeDropped = true;
			}
			lastCheckedRoom = ((PassiveItem)this).Owner.CurrentRoom;
		}
		((PassiveItem)this).Update();
	}

	private void PostProcess(Projectile bullet, float th)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)))
		{
			if ((int)ProjectileUtility.ProjectilePlayerOwner(bullet).CurrentRoom.area.PrototypeRoomCategory == 3)
			{
				ProjectileData baseData = bullet.baseData;
				baseData.damage *= 0.8f;
			}
			else
			{
				ProjectileData baseData2 = bullet.baseData;
				baseData2.damage *= 1.3f;
				bullet.RuntimeUpdateScale(1.2f);
			}
		}
	}

	private void PostProcessBem(BeamController bem)
	{
		if (Object.op_Implicit((Object)(object)bem) && Object.op_Implicit((Object)(object)((Component)bem).GetComponent<Projectile>()))
		{
			PostProcess(((Component)bem).GetComponent<Projectile>(), 0f);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcess;
		player.PostProcessBeam += PostProcessBem;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcess;
		player.PostProcessBeam -= PostProcessBem;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
			((PassiveItem)this).Owner.PostProcessBeam -= PostProcessBem;
		}
		((PassiveItem)this).OnDestroy();
	}
}
