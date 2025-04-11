using UnityEngine;

namespace NevernamedsItems;

public class AmmoGland : PassiveItem
{
	public float timer = 0f;

	public float Interval => 1.5f;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<AmmoGland>("Ammo Gland", "Relorganic", "Gestates ammo slowly over time.\n\nLeeches lead and copper from the users bloodstream to generate organic munitions. While it might not be vegan, you're probably better off with less lead in your blood.", "ammogland_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)4;
	}

	public override void Update()
	{
		if ((Object)(object)((PassiveItem)this).Owner != (Object)null && (Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun != (Object)null)
		{
			if (((GameActor)((PassiveItem)this).Owner).CurrentGun.IsFiring)
			{
				timer = 0f;
			}
			if (timer > Interval)
			{
				timer = 0f;
				((GameActor)((PassiveItem)this).Owner).CurrentGun.GainAmmo(1);
			}
			else
			{
				timer += BraveTime.DeltaTime;
			}
		}
		((PassiveItem)this).Update();
	}
}
