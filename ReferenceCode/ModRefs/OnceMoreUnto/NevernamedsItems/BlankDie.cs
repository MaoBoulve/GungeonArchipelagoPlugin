using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BlankDie : PassiveItem
{
	public static int ID;

	private float timer = 10f;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<BlankDie>("Blank Die", "Roll On", "Triggers blanks at random.\n\nA six sided die with no pips on any of it's faces. Used by gamblers to clumsily cheat games in ages gone by.", "blankdie_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		ID = val.PickupObjectId;
	}

	public override void Update()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (timer >= 0f)
			{
				timer -= BraveTime.DeltaTime;
			}
			else
			{
				PlayerUtility.DoEasyBlank(((PassiveItem)this).Owner, ((GameActor)((PassiveItem)this).Owner).CenterPosition, (EasyBlankType)0);
				timer = Random.Range(1f, 70f);
			}
		}
		((PassiveItem)this).Update();
	}
}
