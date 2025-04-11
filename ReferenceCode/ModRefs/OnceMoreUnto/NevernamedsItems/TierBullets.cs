using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class TierBullets : PassiveItem
{
	private static int[] spriteIDs;

	private static readonly string[] spritePaths = new string[5] { "NevernamedsItems/Resources/tierbullets_d_icon", "NevernamedsItems/Resources/tierbullets_c_icon", "NevernamedsItems/Resources/tierbullets_b_icon", "NevernamedsItems/Resources/tierbullets_a_icon", "NevernamedsItems/Resources/tierbullets_s_icon" };

	private int id;

	private int currentItems;

	private int lastItems;

	private int currentGuns;

	private int lastGuns;

	private int currentActives;

	private int lastActives;

	private FieldInfo m_dockItems = typeof(MinimapUIController).GetField("dockItems", BindingFlags.Instance | BindingFlags.NonPublic);

	public ItemQuality selectedTier;

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<TierBullets>("Tier Bullets", "Typecast", "Picks an item tier at random when first collected. Gives a damage bonus for every item of that tier held.\n\nThese bullets were made eagerly, as a proof of concept for something much, much cooler...", "tierbullets_default_icon", assetbundle: true);
		val.quality = (ItemQuality)(-100);
		spriteIDs = new int[spritePaths.Length];
		spriteIDs[0] = SpriteBuilder.AddSpriteToCollection(spritePaths[0], ((BraveBehaviour)val).sprite.Collection, (Assembly)null);
		spriteIDs[1] = SpriteBuilder.AddSpriteToCollection(spritePaths[1], ((BraveBehaviour)val).sprite.Collection, (Assembly)null);
		spriteIDs[2] = SpriteBuilder.AddSpriteToCollection(spritePaths[2], ((BraveBehaviour)val).sprite.Collection, (Assembly)null);
		spriteIDs[2] = SpriteBuilder.AddSpriteToCollection(spritePaths[3], ((BraveBehaviour)val).sprite.Collection, (Assembly)null);
		spriteIDs[2] = SpriteBuilder.AddSpriteToCollection(spritePaths[4], ((BraveBehaviour)val).sprite.Collection, (Assembly)null);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CalculateStats(((PassiveItem)this).Owner);
		}
	}

	private void CalculateStats(PlayerController player)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Invalid comparison between Unknown and I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Invalid comparison between Unknown and I4
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Invalid comparison between Unknown and I4
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Invalid comparison between Unknown and I4
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Invalid comparison between Unknown and I4
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Invalid comparison between Unknown and I4
		currentItems = player.passiveItems.Count;
		currentGuns = player.inventory.AllGuns.Count;
		currentActives = player.activeItems.Count;
		bool flag = currentItems != lastItems;
		bool flag2 = currentGuns != lastGuns;
		bool flag3 = currentActives != lastActives;
		if (!(flag || flag2 || flag3))
		{
			return;
		}
		RemoveStat((StatType)5);
		foreach (PassiveItem passiveItem in player.passiveItems)
		{
			if (((PickupObject)passiveItem).quality == selectedTier)
			{
				if ((int)selectedTier == 4 || (int)selectedTier == 5)
				{
					AddStat((StatType)5, 1.2f, (ModifyMethod)1);
				}
				else
				{
					AddStat((StatType)5, 1.1f, (ModifyMethod)1);
				}
			}
		}
		foreach (PlayerItem activeItem in player.activeItems)
		{
			if (((PickupObject)activeItem).quality == selectedTier)
			{
				if ((int)selectedTier == 4 || (int)selectedTier == 5)
				{
					AddStat((StatType)5, 1.2f, (ModifyMethod)1);
				}
				else
				{
					AddStat((StatType)5, 1.1f, (ModifyMethod)1);
				}
			}
		}
		foreach (Gun allGun in player.inventory.AllGuns)
		{
			if (((PickupObject)allGun).quality == selectedTier)
			{
				if ((int)selectedTier == 4 || (int)selectedTier == 5)
				{
					AddStat((StatType)5, 1.2f, (ModifyMethod)1);
				}
				else
				{
					AddStat((StatType)5, 1.1f, (ModifyMethod)1);
				}
			}
		}
		lastItems = currentItems;
		player.stats.RecalculateStats(player, true, false);
	}

	private void AlterSprite(int spriteId)
	{
		((BraveBehaviour)this).sprite.SetSprite(spriteId);
		SetDockItemSprite(spriteId);
	}

	private void SetDockItemSprite(int id)
	{
		List<Tuple<tk2dSprite, PassiveItem>> list = (List<Tuple<tk2dSprite, PassiveItem>>)m_dockItems.GetValue(Minimap.Instance.UIMinimap);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Second is TierBullets)
			{
				((tk2dBaseSprite)list[i].First).SetSprite(((BraveBehaviour)this).sprite.Collection, id);
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (!base.m_pickedUpThisRun)
		{
			int num = Random.Range(1, 6);
			if (num == 1)
			{
				selectedTier = (ItemQuality)1;
			}
			if (num == 2)
			{
				selectedTier = (ItemQuality)2;
			}
			if (num == 3)
			{
				selectedTier = (ItemQuality)3;
			}
			if (num == 4)
			{
				selectedTier = (ItemQuality)4;
			}
			if (num == 5)
			{
				selectedTier = (ItemQuality)5;
			}
			id = num;
			AlterSprite(id);
		}
		((PassiveItem)this).Pickup(player);
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		StatModifier val = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (base.passiveStatModifiers == null)
		{
			base.passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val };
		}
		else
		{
			base.passiveStatModifiers = base.passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val }).ToArray();
		}
	}

	private void RemoveStat(StatType statType)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < base.passiveStatModifiers.Length; i++)
		{
			if (base.passiveStatModifiers[i].statToBoost != statType)
			{
				list.Add(base.passiveStatModifiers[i]);
			}
		}
		base.passiveStatModifiers = list.ToArray();
	}
}
