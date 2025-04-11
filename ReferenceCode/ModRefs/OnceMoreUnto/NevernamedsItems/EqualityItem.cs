using UnityEngine;

namespace NevernamedsItems;

public class EqualityItem : PassiveItem
{
	private int cachedKeys;

	private int cachedBlanks;

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<EqualityItem>("Equality", "Blanks And Keys Are Equal", "Constantly equalises the bearer's stocks of blanks and keys.\n\nOf debatable usefulness.", "equality_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = false;
		((PickupObject)val).quality = (ItemQuality)3;
	}

	private void DoInitialBalancing()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		int blanks = ((PassiveItem)this).Owner.Blanks;
		int keyBullets = ((PassiveItem)this).Owner.carriedConsumables.KeyBullets;
		if (blanks != keyBullets)
		{
			if (blanks > keyBullets)
			{
				((PassiveItem)this).Owner.carriedConsumables.KeyBullets = blanks;
			}
			else if (keyBullets > blanks)
			{
				((PassiveItem)this).Owner.Blanks = keyBullets;
			}
		}
		cachedBlanks = blanks;
		cachedKeys = keyBullets;
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (((PassiveItem)this).Owner.carriedConsumables.KeyBullets != cachedKeys)
			{
				if (((PassiveItem)this).Owner.carriedConsumables.KeyBullets != ((PassiveItem)this).Owner.Blanks)
				{
					((PassiveItem)this).Owner.Blanks = ((PassiveItem)this).Owner.carriedConsumables.KeyBullets;
				}
				cachedBlanks = ((PassiveItem)this).Owner.Blanks;
				cachedKeys = ((PassiveItem)this).Owner.carriedConsumables.KeyBullets;
			}
			if (((PassiveItem)this).Owner.Blanks != cachedBlanks)
			{
				if (((PassiveItem)this).Owner.carriedConsumables.KeyBullets != ((PassiveItem)this).Owner.Blanks)
				{
					((PassiveItem)this).Owner.carriedConsumables.KeyBullets = ((PassiveItem)this).Owner.Blanks;
				}
				cachedKeys = ((PassiveItem)this).Owner.carriedConsumables.KeyBullets;
				cachedBlanks = ((PassiveItem)this).Owner.Blanks;
			}
		}
		((PassiveItem)this).Update();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		if (!base.m_pickedUpThisRun)
		{
			DoInitialBalancing();
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((PassiveItem)this).Drop(player);
	}
}
