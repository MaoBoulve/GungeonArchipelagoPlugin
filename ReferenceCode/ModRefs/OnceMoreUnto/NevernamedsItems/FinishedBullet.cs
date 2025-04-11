using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class FinishedBullet : PlayerItem
{
	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<FinishedBullet>("Finished Bullet", "Let's Finish This", "A single bullet from the legendary 'Finished Gun'.\n\nEven without the Gun to fire it, a good throwing arm and plenty of resolve can achieve wonderful results.", "finishedbullet_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 240f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		Projectile finalProjectile = ((Gun)Databases.Items[762]).DefaultModule.finalProjectile;
		GameObject val = SpawnManager.SpawnProjectile(((Component)finalProjectile).gameObject, Vector2.op_Implicit(((BraveBehaviour)user).sprite.WorldCenter), Quaternion.Euler(0f, 0f, ((Object)(object)((GameActor)user).CurrentGun == (Object)null) ? 0f : ((GameActor)user).CurrentGun.CurrentAngle), true);
		Projectile component = val.GetComponent<Projectile>();
		if ((Object)(object)component != (Object)null)
		{
			component.Owner = (GameActor)(object)user;
			component.Shooter = ((BraveBehaviour)user).specRigidbody;
			component.baseData.damage = 1f;
		}
	}
}
