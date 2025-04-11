using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class BlankBoots : PassiveItem
{
	public static void Init()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BlankBoots>("Blank Boots", "Boots of Banishment", "Rolling over enemy bullets has a chance to trigger a microblank.\n\nMade by a senile old man who misheard a conversation about the legendary 'Blank Bullets'.", "blankboots_icon", assetbundle: true);
		ItemBuilder.AddPassiveStatModifier(val, (StatType)14, 1f, (ModifyMethod)0);
		val.quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop(val, (ShopType)4, 1f);
	}

	private void onDodgeRolledOverBullet(Projectile bullet)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.2f;
		if (((PassiveItem)this).Owner.HasPickupID(564) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:true_blank"].PickupObjectId) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:false_blank"].PickupObjectId) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:spare_blank"].PickupObjectId) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:blank_stare"].PickupObjectId))
		{
			num = 0.4f;
		}
		if (Random.value < num)
		{
			if (((PassiveItem)this).Owner.HasPickupID(579) && Random.value < 0.25f)
			{
				((PassiveItem)this).Owner.ForceBlank(25f, 0.5f, false, true, (Vector2?)null, true, -1f);
			}
			else
			{
				DoMicroBlank(((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter);
			}
		}
	}

	private void DoMicroBlank(Vector2 center)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		PlayerController owner = ((PassiveItem)this).Owner;
		GameObject val = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX_Ghost");
		AkSoundEngine.PostEvent("Play_OBJ_silenceblank_small_01", ((Component)this).gameObject);
		GameObject val2 = new GameObject("silencer");
		SilencerInstance val3 = val2.AddComponent<SilencerInstance>();
		float num = 0.25f;
		val3.TriggerSilencer(center, 25f, 5f, val, 0f, 3f, 3f, 3f, 250f, 5f, num, owner, false, false);
	}

	public override void Pickup(PlayerController player)
	{
		player.OnDodgedProjectile += onDodgeRolledOverBullet;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnDodgedProjectile -= onDodgeRolledOverBullet;
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.OnDodgedProjectile -= onDodgeRolledOverBullet;
		}
		((PassiveItem)this).OnDestroy();
	}
}
