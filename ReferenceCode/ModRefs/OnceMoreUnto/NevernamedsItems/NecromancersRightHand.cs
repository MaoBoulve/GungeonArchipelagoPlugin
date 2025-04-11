using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class NecromancersRightHand : PlayerItem
{
	public static void Init()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<NecromancersRightHand>("Necromancer's Right Hand", "Spacebar To Necromance", "The severed hand of an ancient purple necromancer.\n\nRaise an army of the dead!", "necromancersrighthand_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 210f);
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		Game.Items.Rename("nn:necromancer's_right_hand", "nn:necromancers_right_hand");
	}

	public override bool CanBeUsed(PlayerController user)
	{
		if ((Object)(object)user != (Object)null && user.CurrentRoom != null && user.CurrentRoom.IsSealed)
		{
			return true;
		}
		return false;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_OBJ_dead_again_01", ((Component)this).gameObject);
		for (int i = 0; i < StaticReferenceManager.AllCorpses.Count; i++)
		{
			GameObject val = StaticReferenceManager.AllCorpses[i];
			if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)val.GetComponent<tk2dBaseSprite>()) && Vector3Extensions.GetAbsoluteRoom(val.transform.position) == user.CurrentRoom && Vector3Extensions.GetAbsoluteRoom(val.transform.position).IsSealed)
			{
				Vector2 worldCenter = val.GetComponent<tk2dBaseSprite>().WorldCenter;
				string text = "249db525a9464e5282d02162c88e0357";
				if (CustomSynergies.PlayerHasActiveSynergy(user, "Roll Dem Bones") && Random.value <= 0.25f)
				{
					text = "336190e29e8a4f75ab7486595b700d4a";
				}
				AIActor val2 = CompanionisedEnemyUtility.SpawnCompanionisedEnemy(user, text, Vector2Extensions.ToIntVector2(worldCenter, (VectorConversions)2), doTint: true, ExtendedColours.purple, 5, 2, shouldBeJammed: false, doFriendlyOverhead: true);
				if (Object.op_Implicit((Object)(object)((Component)val2).GetComponent<SpawnEnemyOnDeath>()))
				{
					Object.Destroy((Object)(object)((Component)val2).GetComponent<SpawnEnemyOnDeath>());
				}
				if ((Object)(object)val2.CorpseObject != (Object)null)
				{
					val2.CorpseObject = null;
				}
				if (text == "249db525a9464e5282d02162c88e0357")
				{
					val2.OverrideHitEnemies = true;
					val2.CollisionDamage = 1f;
					val2.CollisionDamageTypes = (CoreDamageTypes)(val2.CollisionDamageTypes | 0x40);
				}
				if (CustomSynergies.PlayerHasActiveSynergy(user, "The Sprinting Dead"))
				{
					val2.MovementSpeed *= 2f;
				}
				Object.Destroy((Object)(object)val.gameObject);
			}
		}
	}
}
