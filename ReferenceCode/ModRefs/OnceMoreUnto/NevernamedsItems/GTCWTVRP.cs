using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class GTCWTVRP : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CHandleReload_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public GTCWTVRP _003C_003E4__this;

		private string[] _003Clevel_003E5__1;

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
		public _003CHandleReload_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Clevel_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Invalid comparison between Unknown and I4
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Invalid comparison between Unknown and I4
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Expected O, but got Unknown
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				GameManager.Instance.LoadCustomFlowForDebug(_003Clevel_003E5__1[2], _003Clevel_003E5__1[1], _003Clevel_003E5__1[0]);
				goto IL_0172;
			}
			_003C_003E1__state = -1;
			if (GameManager.Instance.Dungeon.IsGlitchDungeon)
			{
				GameManager.Instance.InjectedFlowPath = "Core Game Flows/Secret_DoubleBeholster_Flow";
			}
			if (floors.ContainsKey(GameManager.Instance.Dungeon.tileIndices.tilesetId))
			{
				if ((int)GameManager.Instance.CurrentGameMode == 2 || (int)GameManager.Instance.CurrentGameMode == 3)
				{
					_003Clevel_003E5__1 = floors[GameManager.Instance.Dungeon.tileIndices.tilesetId];
					if (_003Clevel_003E5__1[0] != null && _003Clevel_003E5__1[1] != null && _003Clevel_003E5__1[2] != null)
					{
						Pixelator.Instance.FadeToBlack(0.5f, false, 0f);
						GameUIRoot.Instance.HideCoreUI(string.Empty);
						GameUIRoot.Instance.ToggleLowerPanels(false, false, string.Empty);
						_003C_003E2__current = (object)new WaitForSeconds(0.5f);
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003E4__this.FallBack(user);
					goto IL_0172;
				}
				Pixelator.Instance.FadeToBlack(0.5f, false, 0f);
				GameUIRoot.Instance.HideCoreUI(string.Empty);
				GameUIRoot.Instance.ToggleLowerPanels(false, false, string.Empty);
				GameManager.Instance.DelayedLoadCustomLevel(0.5f, floors[GameManager.Instance.Dungeon.tileIndices.tilesetId][0]);
			}
			else
			{
				_003C_003E4__this.FallBack(user);
			}
			goto IL_01fd;
			IL_01fd:
			return false;
			IL_0172:
			_003Clevel_003E5__1 = null;
			goto IL_01fd;
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

	public static Dictionary<ValidTilesets, string[]> floors = new Dictionary<ValidTilesets, string[]>
	{
		{
			(ValidTilesets)2,
			new string[3] { "tt_castle", "Base_Castle", "Bossrush_01_Castle" }
		},
		{
			(ValidTilesets)8192,
			new string[3] { "tt_jungle", null, null }
		},
		{
			(ValidTilesets)4096,
			new string[3] { "tt_belly", null, null }
		},
		{
			(ValidTilesets)4,
			new string[3] { "tt_sewer", "Base_Sewer", "Bossrush_01a_Sewer" }
		},
		{
			(ValidTilesets)1,
			new string[3] { "tt5", "Base_Gungeon", "Bossrush_02_Gungeon" }
		},
		{
			(ValidTilesets)8,
			new string[3] { "tt_cathedral", "Base_Cathedral", "Bossrush_02a_Cathedral" }
		},
		{
			(ValidTilesets)16,
			new string[3] { "tt_mines", "Base_Mines", "Bossrush_03_Mines" }
		},
		{
			(ValidTilesets)32768,
			new string[3] { "ss_resourcefulrat", null, null }
		},
		{
			(ValidTilesets)32,
			new string[3] { "tt_catacombs", "Base_Catacombs", "Bossrush_04_Catacombs" }
		},
		{
			(ValidTilesets)2048,
			new string[3] { "tt_nakatomi", null, null }
		},
		{
			(ValidTilesets)64,
			new string[3] { "tt_forge", "Base_Forge", "Bossrush_05_Forge" }
		},
		{
			(ValidTilesets)1024,
			new string[3] { "tt_canyon", null, null }
		},
		{
			(ValidTilesets)128,
			new string[3] { "tt_bullethell", "Base_BulletHell", "Bossrush_06_BulletHell" }
		}
	};

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GTCWTVRP>("GTCWTVRP", "'Tis but a copy", "'Gun That Can Wound The Very Recent Past'\n\nReloads the current floor. A cheap plastic knockoff of The Gun That Can Kill The Past.", "gtcwtvrp_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)3, 1000f);
		val.consumable = true;
		((PickupObject)val).quality = (ItemQuality)4;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)3, 1f);
	}

	public override void DoEffect(PlayerController user)
	{
		((MonoBehaviour)user).StartCoroutine(HandleReload(user));
	}

	public IEnumerator HandleReload(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleReload_003Ed__3(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}

	private void FallBack(PlayerController user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		IntVector2 bestRewardLocation = user.CurrentRoom.GetBestRewardLocation(IntVector2.One * 3, (RewardLocationStyle)1, true);
		Chest rainbow_Chest = GameManager.Instance.RewardManager.Rainbow_Chest;
		Chest.Spawn(rainbow_Chest, bestRewardLocation);
	}
}
