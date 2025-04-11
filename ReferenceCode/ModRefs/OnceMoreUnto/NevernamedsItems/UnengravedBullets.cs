using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class UnengravedBullets : PlayerItem
{
	private float duration = 4f;

	private bool ableToGiveItem;

	public static string engravedEnemy;

	public List<string> enemyBlacklist = new List<string>
	{
		"fa6a7ac20a0e4083a4c2ee0d86f8bbf7", "47bdfec22e8e4568a619130a267eab5b", "ea40fcc863d34b0088f490f4e57f8913", "c00390483f394a849c36143eb878998f", "ec6b674e0acd4553b47ee94493d66422", "ffca09398635467da3b1f4a54bcfda80", "1b5810fafbec445d89921a4efb4e42b7", "4b992de5b4274168a8878ef9bf7ea36b", "c367f00240a64d5d9f3c26484dc35833", "da797878d215453abba824ff902e21b4",
		"5729c8b5ffa7415bb3d01205663a33ef", "fa76c8cfdf1c4a88b55173666b4bc7fb", "8b0dd96e2fe74ec7bebc1bc689c0008a", "5e0af7f7d9de4755a68d2fd3bbc15df4", "9189f46c47564ed588b9108965f975c9", "6868795625bd46f3ae3e4377adce288b", "4d164ba3f62648809a4a82c90fc22cae", "6c43fddfd401456c916089fdd1c99b1c", "3f11bbbc439c4086a180eb0fb9990cb4", "f3b04a067a65492f8b279130323b41f0",
		"41ee1c8538e8474a82a74c4aff99c712", "465da2bb086a4a88a803f79fe3a27677", "05b8afe0b6cc4fffa9dc6036fa24c8ec", "cd88c3ce60c442e9aa5b3904d31652bc", "68a238ed6a82467ea85474c595c49c6e", "7c5d5f09911e49b78ae644d2b50ff3bf", "76bc43539fc24648bff4568c75c686d1", "0ff278534abb4fbaaa65d3f638003648", "6ad1cafc268f4214a101dca7af61bc91", "14ea47ff46b54bb4a98f91ffcffb656d"
	};

	public static void Init()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<UnengravedBullets>("Unengraved Bullets", "Waiting for the right moment...", "The first enemy shot while this item is active becomes permanently insta-killable.\n\nThese bullets, while unremarkable at the moment, are brimming with murderous potential.", "unengravedbullets_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 500f);
		((PickupObject)val).quality = (ItemQuality)3;
		AlexandriaTags.SetTag((PickupObject)(object)val, "bullet_modifier");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_UNENGRAVEDBULLETS, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToTrorcMetaShop(15, null);
		Doug.AddToLootPool(((PickupObject)val).PickupObjectId);
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		sourceProjectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(sourceProjectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		try
		{
			Projectile projectile = ((BraveBehaviour)sourceBeam).projectile;
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
		}
	}

	public override void DoEffect(PlayerController user)
	{
		StartEffect(user);
		((MonoBehaviour)this).StartCoroutine(ItemBuilder.HandleDuration((PlayerItem)(object)this, duration, user, (Action<PlayerController>)EndEffect));
	}

	private void StartEffect(PlayerController user)
	{
		ableToGiveItem = true;
		user.PostProcessProjectile += PostProcessProjectile;
		user.PostProcessBeam += PostProcessBeam;
	}

	private void EndEffect(PlayerController user)
	{
		ableToGiveItem = false;
		user.PostProcessProjectile -= PostProcessProjectile;
		user.PostProcessBeam -= PostProcessBeam;
	}

	public override void OnPreDrop(PlayerController user)
	{
		if (((PlayerItem)this).IsCurrentlyActive)
		{
			((PlayerItem)this).IsCurrentlyActive = false;
			EndEffect(user);
		}
	}

	private void OnHitEnemy(Projectile arg1, SpeculativeRigidbody arg2, bool arg3)
	{
		string text = ((arg2 == null) ? null : ((BraveBehaviour)arg2).aiActor?.EnemyGuid);
		if (!string.IsNullOrEmpty(text))
		{
			if (enemyBlacklist.Contains(text))
			{
				Debug.Log((object)("The selected enemy (" + text + ") is on the enemy Blacklist, either because it is a boss, unkillable, or some sort of harmless thing I can't imagine someone wanting to instakill - NN"));
			}
			else if (ableToGiveItem)
			{
				ableToGiveItem = false;
				engravedEnemy = text;
				string header = "Bullets Engraved";
				string text2 = "";
				Notify(header, text2);
				EndEffect(base.LastOwner);
				GiveEngravedBulletsRemoveUnengravedBullets();
			}
			else if (ableToGiveItem)
			{
			}
		}
	}

	private void Notify(string header, string text)
	{
		tk2dBaseSprite notificationObjectSprite = GameUIRoot.Instance.notificationController.notificationObjectSprite;
		GameUIRoot.Instance.notificationController.DoCustomNotification(header, text, notificationObjectSprite.Collection, notificationObjectSprite.spriteId, (NotificationColor)2, true, true);
	}

	private void GiveEngravedBulletsRemoveUnengravedBullets()
	{
		PickupObject val = Game.Items["nn:engraved_bullets"];
		base.LastOwner.AcquirePassiveItemPrefabDirectly((PassiveItem)(object)((val is PassiveItem) ? val : null));
		base.LastOwner.RemoveActiveItem(((PickupObject)this).PickupObjectId);
	}
}
