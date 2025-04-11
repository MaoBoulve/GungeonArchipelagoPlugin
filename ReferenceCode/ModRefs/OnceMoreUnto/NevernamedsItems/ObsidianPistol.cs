using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ObsidianPistol : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CDoReward_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public Vector2 positionToSpawn;

		public int pickupObject;

		public ObsidianPistol _003C_003E4__this;

		private float _003CcurseAmount_003E5__1;

		private StatModifier _003CstatModifier4_003E5__2;

		private StatModifier _003Cdamageup_003E5__3;

		private PassiveItem _003CitemOfTypeAndQuality_003E5__4;

		private Gun _003CitemOfTypeAndQuality_003E5__5;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CDoReward_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CstatModifier4_003E5__2 = null;
			_003Cdamageup_003E5__3 = null;
			_003CitemOfTypeAndQuality_003E5__4 = null;
			_003CitemOfTypeAndQuality_003E5__5 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Expected O, but got Unknown
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CcurseAmount_003E5__1 = 1f;
				if (pickupObject == 442)
				{
					_003CcurseAmount_003E5__1 = 3f;
					_003Cdamageup_003E5__3 = new StatModifier();
					_003Cdamageup_003E5__3.statToBoost = (StatType)5;
					_003Cdamageup_003E5__3.amount = 1.2f;
					_003Cdamageup_003E5__3.modifyType = (ModifyMethod)1;
					user.ownerlessStatModifiers.Add(_003Cdamageup_003E5__3);
					user.stats.RecalculateStats(user, false, false);
					_003Cdamageup_003E5__3 = null;
				}
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (Random.value <= 0.5f)
				{
					_003CitemOfTypeAndQuality_003E5__4 = LootEngine.GetItemOfTypeAndQuality<PassiveItem>(_003C_003E4__this.AOrSWhatWillItBe(), GameManager.Instance.RewardManager.ItemsLootTable, false);
					LootEngine.SpawnItem(((Component)_003CitemOfTypeAndQuality_003E5__4).gameObject, Vector2.op_Implicit(positionToSpawn), Vector2.left, 0f, false, true, true);
					_003CitemOfTypeAndQuality_003E5__4 = null;
				}
				else
				{
					_003CitemOfTypeAndQuality_003E5__5 = LootEngine.GetItemOfTypeAndQuality<Gun>(_003C_003E4__this.AOrSWhatWillItBe(), GameManager.Instance.RewardManager.GunsLootTable, false);
					LootEngine.SpawnItem(((Component)_003CitemOfTypeAndQuality_003E5__5).gameObject, Vector2.op_Implicit(positionToSpawn), Vector2.left, 0f, false, true, true);
					_003CitemOfTypeAndQuality_003E5__5 = null;
				}
				_003CstatModifier4_003E5__2 = new StatModifier();
				_003CstatModifier4_003E5__2.statToBoost = (StatType)14;
				_003CstatModifier4_003E5__2.amount = _003CcurseAmount_003E5__1;
				_003CstatModifier4_003E5__2.modifyType = (ModifyMethod)0;
				user.ownerlessStatModifiers.Add(_003CstatModifier4_003E5__2);
				user.stats.RecalculateStats(user, false, false);
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CKillInventoryCompanion_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public ObsidianPistol _003C_003E4__this;

		private PickupObject _003Citem_003E5__1;

		private Gun _003Cgunness_003E5__2;

		private DebrisObject _003CdebrisObject_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CKillInventoryCompanion_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Citem_003E5__1 = null;
			_003Cgunness_003E5__2 = null;
			_003CdebrisObject_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Citem_003E5__1 = BraveUtility.RandomElement<PickupObject>(CompanionItems);
				_003Cgunness_003E5__2 = ((Component)_003Citem_003E5__1).gameObject.GetComponent<Gun>();
				_003CdebrisObject_003E5__3 = SpecialDrop.DropItem(user, _003Citem_003E5__1, (Object)(object)_003Cgunness_003E5__2 != (Object)null);
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if ((Object)(object)_003CdebrisObject_003E5__3 != (Object)null)
				{
					AkSoundEngine.PostEvent("Play_WPN_smileyrevolver_shot_01", ((Component)_003C_003E4__this).gameObject);
					Object.Instantiate<GameObject>(SharedVFX.TeleporterPrototypeTelefragVFX, Vector2.op_Implicit(((BraveBehaviour)_003CdebrisObject_003E5__3).sprite.WorldCenter), Quaternion.identity);
					((MonoBehaviour)GameManager.Instance).StartCoroutine(_003C_003E4__this.DoReward(user, ((BraveBehaviour)_003CdebrisObject_003E5__3).sprite.WorldCenter, _003Citem_003E5__1.PickupObjectId));
					Object.Destroy((Object)(object)((Component)_003CdebrisObject_003E5__3).gameObject);
				}
				else
				{
					ETGModConsole.Log((object)"DebrisObject was null in the kill code, this should never happen.", false);
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static List<PickupObject> CompanionItems = new List<PickupObject>();

	public static List<DebrisObject> DebrisCompanionItems = new List<DebrisObject>();

	public static List<Gun> DebrisGuns = new List<Gun>();

	public static List<int> BannedItems = new List<int> { 263, 262 };

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<ObsidianPistol>("Obsidian Pistol", "Sacrifice I’m Willing to Take", "Sacrifices those you hold dear in a bloody ritual of reverence to Kaliber, the Gun Mother.\n\nThose who worship shall be rewarded for their faith.\n\nPraise Be", "obsidianpistol_icon", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)0, 0.5f);
		val.consumable = false;
		((PickupObject)val).quality = (ItemQuality)2;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		ClearItemLists();
		GetCompanionItemsOnUser(user);
		GetCompanionItemsOnGround();
		int num = CompanionItems.Count + DebrisCompanionItems.Count + DebrisGuns.Count;
		if (num <= 0)
		{
			return;
		}
		int num2 = Random.Range(1, num + 1);
		if (num2 > CompanionItems.Count + DebrisCompanionItems.Count)
		{
			if (DebrisGuns.Count > 0)
			{
				KillGroundCompanion(user, ((Component)BraveUtility.RandomElement<Gun>(DebrisGuns)).gameObject);
			}
			else
			{
				ETGModConsole.Log((object)"DebrisGuns had nothing in it? This should never happen.", false);
			}
		}
		else if (num2 > CompanionItems.Count)
		{
			if (DebrisCompanionItems.Count > 0)
			{
				KillGroundCompanion(user, ((Component)BraveUtility.RandomElement<DebrisObject>(DebrisCompanionItems)).gameObject);
			}
			else
			{
				ETGModConsole.Log((object)"DebrisCompanionItems had nothing in it? This should never happen.", false);
			}
		}
		else if (CompanionItems.Count > 0)
		{
			((MonoBehaviour)GameManager.Instance).StartCoroutine(KillInventoryCompanion(user));
		}
		else
		{
			ETGModConsole.Log((object)"CompanionItems had nothing in it? This should never happen.", false);
		}
	}

	private void KillGroundCompanion(PlayerController user, GameObject companion)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)companion != (Object)null)
		{
			PickupObject component = companion.gameObject.GetComponent<PickupObject>();
			if ((Object)(object)component != (Object)null)
			{
				AkSoundEngine.PostEvent("Play_WPN_smileyrevolver_shot_01", ((Component)this).gameObject);
				Object.Instantiate<GameObject>(SharedVFX.TeleporterPrototypeTelefragVFX, Vector2.op_Implicit(((BraveBehaviour)component).sprite.WorldCenter), Quaternion.identity);
				((MonoBehaviour)GameManager.Instance).StartCoroutine(DoReward(user, ((BraveBehaviour)component).sprite.WorldCenter, component.PickupObjectId));
				Object.Destroy((Object)(object)companion.gameObject);
			}
		}
		else
		{
			ETGModConsole.Log((object)"Companion was Null in the Debris Object handler, this should never happen.", false);
		}
	}

	private IEnumerator KillInventoryCompanion(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CKillInventoryCompanion_003Ed__3(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	private ItemQuality AOrSWhatWillItBe()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value < 0.35f)
		{
			return (ItemQuality)5;
		}
		return (ItemQuality)4;
	}

	private IEnumerator DoReward(PlayerController user, Vector2 positionToSpawn, int pickupObject)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoReward_003Ed__5(0)
		{
			_003C_003E4__this = this,
			user = user,
			positionToSpawn = positionToSpawn,
			pickupObject = pickupObject
		};
	}

	private void ClearItemLists()
	{
		CompanionItems.Clear();
		DebrisCompanionItems.Clear();
		DebrisGuns.Clear();
	}

	private void GetCompanionItemsOnUser(PlayerController user)
	{
		foreach (PassiveItem passiveItem in user.passiveItems)
		{
			if (ItemIsValid((PickupObject)(object)passiveItem))
			{
				CompanionItems.Add((PickupObject)(object)passiveItem);
			}
		}
		foreach (PlayerItem activeItem in user.activeItems)
		{
			if (ItemIsValid((PickupObject)(object)activeItem))
			{
				CompanionItems.Add((PickupObject)(object)activeItem);
			}
		}
		foreach (Gun allGun in user.inventory.AllGuns)
		{
			if (ItemIsValid((PickupObject)(object)allGun))
			{
				CompanionItems.Add((PickupObject)(object)allGun);
			}
		}
	}

	private bool ItemIsValid(PickupObject item)
	{
		CompanionItem component = ((Component)item).GetComponent<CompanionItem>();
		MulticompanionItem component2 = ((Component)item).GetComponent<MulticompanionItem>();
		BankMaskItem component3 = ((Component)item).GetComponent<BankMaskItem>();
		PlayerOrbitalItem component4 = ((Component)item).GetComponent<PlayerOrbitalItem>();
		if ((Object)(object)component != (Object)null || (Object)(object)component2 != (Object)null || (Object)(object)component3 != (Object)null || ((Object)(object)component4 != (Object)null && !AlexandriaTags.HasTag(item, "guon_stone")) || AlexandriaTags.HasTag(item, "non_companion_living_item"))
		{
			if (!BannedItems.Contains(item.PickupObjectId))
			{
				if (item.DisplayName != "Magic Lamp")
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private void GetCompanionItemsOnGround()
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		DebrisObject[] array = Object.FindObjectsOfType<DebrisObject>();
		DebrisObject[] array2 = array;
		foreach (DebrisObject val in array2)
		{
			PickupObject component = ((Component)val).gameObject.GetComponent<PickupObject>();
			Gun component2 = ((Component)val).gameObject.GetComponent<Gun>();
			if (((Object)(object)component != (Object)null || (Object)(object)component2 != (Object)null) && ItemIsValid(component))
			{
				DebrisCompanionItems.Add(val);
			}
		}
		Gun[] array3 = Object.FindObjectsOfType<Gun>();
		Gun[] array4 = array3;
		foreach (Gun val2 in array4)
		{
			PickupObject component3 = ((Component)val2).gameObject.GetComponent<PickupObject>();
			if ((Object)(object)component3 != (Object)null && (Object)(object)val2.CurrentOwner == (Object)null && ((Component)val2).gameObject.transform.position != Vector3.zero && ItemIsValid(component3))
			{
				DebrisGuns.Add(val2);
			}
		}
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return true;
	}
}
