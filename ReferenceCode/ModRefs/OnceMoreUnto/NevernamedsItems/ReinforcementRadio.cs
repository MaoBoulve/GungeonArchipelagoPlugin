using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ReinforcementRadio : PlayerItem
{
	private List<List<string>> randomEnemyloadouts = new List<List<string>>
	{
		new List<string> { "01972dee89fc4404a5c408d50007dad5", "01972dee89fc4404a5c408d50007dad5", "01972dee89fc4404a5c408d50007dad5", "01972dee89fc4404a5c408d50007dad5" },
		new List<string> { "128db2f0781141bcb505d8f00f9e4d47", "128db2f0781141bcb505d8f00f9e4d47" },
		new List<string> { "b54d89f9e802455cbb2b8a96a31e8259", "01972dee89fc4404a5c408d50007dad5", "01972dee89fc4404a5c408d50007dad5" },
		new List<string> { "88b6b6a93d4b4234a67844ef4728382c", "88b6b6a93d4b4234a67844ef4728382c" },
		new List<string> { "4d37ce3d666b4ddda8039929225b7ede", "4d37ce3d666b4ddda8039929225b7ede", "c0260c286c8d4538a697c5bf24976ccf" }
	};

	private Dictionary<string, string> synergies = new Dictionary<string, string>
	{
		{ "Bullet+", "01972dee89fc4404a5c408d50007dad5" },
		{ "Red Shotgun+", "128db2f0781141bcb505d8f00f9e4d47" },
		{ "Blue Shotgun+", "b54d89f9e802455cbb2b8a96a31e8259" },
		{ "Bandana+", "88b6b6a93d4b4234a67844ef4728382c" },
		{ "Tank+", "df7fb62405dc4697b7721862c7b6b3cd" },
		{ "Devil+", "5f3abc2d561b4b9c9e72b879c6f10c7e" },
		{ "Execution+", "b1770e0f1c744d9d887cc16122882b4f" },
		{ "Sniper+", "31a3ea0c54a745e182e22ea54844a82d" },
		{ "Spirit+", "4db03291a12144d69fe940d5a01de376" },
		{ "Arrow+", "05891b158cd542b1a5f3df30fb67a7ff" },
		{ "Egg+", "ed37fa13e0fa4fcf8239643957c51293" },
		{ "Bubble+", "6e972cd3b11e4b429b888b488e308551" },
		{ "Eye+", "7b0b1b6d9ce7405b86b75ce648025dd6" },
		{ "Bomb+", "4d37ce3d666b4ddda8039929225b7ede" },
		{ "Magic+", "206405acad4d4c33aac6717d184dc8d4" }
	};

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ReinforcementRadio>("Reinforcement Radio", "I Need Backup!", "Taps into secret Gundead radio frequencies to confuse their reinforcement divisions, and get them to send aid to the wrong side.\n\nGundead are not the brightest of creatures.", "reinforcementradio_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 600f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)3;
		List<string> list = new List<string> { "nn:reinforcement_radio", "magnum" };
		CustomSynergies.Add("Bullet+", list, (List<string>)null, true);
		List<string> list2 = new List<string> { "nn:reinforcement_radio", "regular_shotgun" };
		CustomSynergies.Add("Red Shotgun+", list2, (List<string>)null, true);
		List<string> list3 = new List<string> { "nn:reinforcement_radio", "winchester" };
		CustomSynergies.Add("Blue Shotgun+", list3, (List<string>)null, true);
		List<string> list4 = new List<string> { "nn:reinforcement_radio", "machine_pistol" };
		CustomSynergies.Add("Bandana+", list4, (List<string>)null, true);
		List<string> list5 = new List<string> { "nn:reinforcement_radio", "ak47" };
		CustomSynergies.Add("Tank+", list5, (List<string>)null, true);
		List<string> list6 = new List<string> { "nn:reinforcement_radio", "pitchfork" };
		CustomSynergies.Add("Devil+", list6, (List<string>)null, true);
		List<string> list7 = new List<string> { "nn:reinforcement_radio", "huntsman" };
		CustomSynergies.Add("Execution+", list7, (List<string>)null, true);
		List<string> list8 = new List<string> { "nn:reinforcement_radio", "sniper_rifle" };
		CustomSynergies.Add("Sniper+", list8, (List<string>)null, true);
		List<string> list9 = new List<string> { "nn:reinforcement_radio", "thompson" };
		CustomSynergies.Add("Spirit+", list9, (List<string>)null, true);
		List<string> list10 = new List<string> { "nn:reinforcement_radio", "bow" };
		CustomSynergies.Add("Arrow+", list10, (List<string>)null, true);
		List<string> list11 = new List<string> { "nn:reinforcement_radio", "the_scrambler" };
		CustomSynergies.Add("Egg+", list11, (List<string>)null, true);
		List<string> list12 = new List<string> { "nn:reinforcement_radio", "bubble_blaster" };
		CustomSynergies.Add("Bubble+", list12, (List<string>)null, true);
		List<string> list13 = new List<string> { "nn:reinforcement_radio", "trank_gun" };
		CustomSynergies.Add("Eye+", list13, (List<string>)null, true);
		List<string> list14 = new List<string> { "nn:reinforcement_radio" };
		List<string> list15 = new List<string> { "bomb", "ice_bomb", "lil_bomber", "cluster_mine" };
		CustomSynergies.Add("Bomb+", list14, list15, true);
		List<string> list16 = new List<string> { "nn:reinforcement_radio" };
		List<string> list17 = new List<string> { "bundle_of_wands", "hexagun", "magic_bullets" };
		CustomSynergies.Add("Magic+", list16, list17, true);
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_OBJ_supplydrop_activate_01", ((Component)this).gameObject);
		List<string> list = new List<string>();
		list.AddRange(BraveUtility.RandomElement<List<string>>(randomEnemyloadouts));
		foreach (string key in synergies.Keys)
		{
			if (CustomSynergies.PlayerHasActiveSynergy(user, key))
			{
				list.Add(synergies[key]);
			}
		}
		foreach (string item in list)
		{
			AIActor val = CompanionisedEnemyUtility.SpawnCompanionisedEnemy(user, item, new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2)).Value, doTint: false, Color.red, 5, 2, shouldBeJammed: false, doFriendlyOverhead: true);
			val.HandleReinforcementFallIntoRoom(0f);
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return user.IsInCombat;
	}
}
