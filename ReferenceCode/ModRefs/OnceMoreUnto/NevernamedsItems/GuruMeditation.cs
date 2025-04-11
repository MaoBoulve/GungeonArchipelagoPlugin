using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

internal class GuruMeditation : PassiveItem
{
	public float timeStandingStill = 0f;

	public bool effectEnabled = false;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GuruMeditation>("Guru Meditation", "Peace Fire", "Standing still increases the firerate and accuracy of the practitioners weapons.\n\nOnly the most ancient and revered gunslingers remember the ancient art of putting one foot in front of the other, and squaring their shoulders before they fire.", "gurumeditation_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	public override void Update()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if ((Object)(object)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody != (Object)null)
			{
				if (((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.Velocity == Vector2.zero)
				{
					timeStandingStill += BraveTime.DeltaTime;
				}
				else
				{
					timeStandingStill = 0f;
				}
			}
			if (timeStandingStill >= 0.7f)
			{
				if (!effectEnabled)
				{
					Enable(((PassiveItem)this).Owner);
				}
			}
			else if (effectEnabled)
			{
				Disable(((PassiveItem)this).Owner);
			}
		}
		((PassiveItem)this).Update();
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			Disable(player);
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public void Enable(PlayerController target)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		if (!effectEnabled)
		{
			AkSoundEngine.PostEvent("Play_ITM_Macho_Brace_Active_01", ((Component)this).gameObject);
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)25);
			ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, new StatModifier
			{
				statToBoost = (StatType)25,
				amount = 1.5f,
				modifyType = (ModifyMethod)1
			});
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)1);
			ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, new StatModifier
			{
				statToBoost = (StatType)1,
				amount = 1.5f,
				modifyType = (ModifyMethod)1
			});
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)2);
			ItemBuilder.AddPassiveStatModifier((PickupObject)(object)this, new StatModifier
			{
				statToBoost = (StatType)2,
				amount = 0.6f,
				modifyType = (ModifyMethod)1
			});
			VolleyRebuildHelpers.RecalculateStatsWithoutRebuildingGunVolleys(target.stats, target);
			Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)target).sprite);
			if ((Object)(object)outlineMaterial != (Object)null)
			{
				outlineMaterial.SetColor("_OverrideColor", new Color(100f, 0f, 0f));
			}
			effectEnabled = true;
		}
	}

	public void Disable(PlayerController target)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		if (effectEnabled)
		{
			AkSoundEngine.PostEvent("Play_ITM_Macho_Brace_Fade_01", ((Component)this).gameObject);
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)25);
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)2);
			ItemBuilder.RemovePassiveStatModifier((PickupObject)(object)this, (StatType)1);
			VolleyRebuildHelpers.RecalculateStatsWithoutRebuildingGunVolleys(target.stats, target);
			Material outlineMaterial = SpriteOutlineManager.GetOutlineMaterial(((BraveBehaviour)target).sprite);
			if ((Object)(object)outlineMaterial != (Object)null)
			{
				outlineMaterial.SetColor("_OverrideColor", new Color(0f, 0f, 0f));
			}
			effectEnabled = false;
		}
	}
}
