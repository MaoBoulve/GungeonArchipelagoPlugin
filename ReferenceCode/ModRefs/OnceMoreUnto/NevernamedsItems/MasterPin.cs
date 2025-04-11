using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

public class MasterPin : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CUnlockAllDoors_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MasterPin _003C_003E4__this;

		private List<InteractableDoorController> _003Cgates_003E5__1;

		private List<DungeonDoorController> _003Cdoors_003E5__2;

		private bool _003ChasVisitedOubliette_003E5__3;

		private List<SecretRoomManager> _003CsecretRooms_003E5__4;

		private ValidTilesets _003Ctileset_003E5__5;

		private List<InteractableDoorController>.Enumerator _003C_003Es__6;

		private InteractableDoorController _003Cgate_003E5__7;

		private int _003Ci_003E5__8;

		private List<DungeonDoorController>.Enumerator _003C_003Es__9;

		private DungeonDoorController _003Cdoor_003E5__10;

		private List<SecretRoomManager>.Enumerator _003C_003Es__11;

		private SecretRoomManager _003CsecretRoom_003E5__12;

		private List<SecretFloorInteractableController> _003CsecretTrapdoors_003E5__13;

		private List<SecretFloorInteractableController>.Enumerator _003C_003Es__14;

		private SecretFloorInteractableController _003CsecretTrapdoor_003E5__15;

		private int _003Ci_003E5__16;

		private bool _003ChasVisitedAbbey_003E5__17;

		private List<CrestDoorController> _003CabbeyDoors_003E5__18;

		private List<CrestDoorController>.Enumerator _003C_003Es__19;

		private CrestDoorController _003CabbeyDoor_003E5__20;

		private bool _003ChasVisitedRat_003E5__21;

		private List<ResourcefulRatMinesHiddenTrapdoor>.Enumerator _003C_003Es__22;

		private ResourcefulRatMinesHiddenTrapdoor _003Ctrapdoor_003E5__23;

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
		public _003CUnlockAllDoors_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cgates_003E5__1 = null;
			_003Cdoors_003E5__2 = null;
			_003CsecretRooms_003E5__4 = null;
			_003C_003Es__6 = default(List<InteractableDoorController>.Enumerator);
			_003Cgate_003E5__7 = null;
			_003C_003Es__9 = default(List<DungeonDoorController>.Enumerator);
			_003Cdoor_003E5__10 = null;
			_003C_003Es__11 = default(List<SecretRoomManager>.Enumerator);
			_003CsecretRoom_003E5__12 = null;
			_003CsecretTrapdoors_003E5__13 = null;
			_003C_003Es__14 = default(List<SecretFloorInteractableController>.Enumerator);
			_003CsecretTrapdoor_003E5__15 = null;
			_003CabbeyDoors_003E5__18 = null;
			_003C_003Es__19 = default(List<CrestDoorController>.Enumerator);
			_003CabbeyDoor_003E5__20 = null;
			_003C_003Es__22 = default(List<ResourcefulRatMinesHiddenTrapdoor>.Enumerator);
			_003Ctrapdoor_003E5__23 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fc: Invalid comparison between Unknown and I4
			//IL_056d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0573: Invalid comparison between Unknown and I4
			//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b5: Invalid comparison between Unknown and I4
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Invalid comparison between Unknown and I4
			//IL_0613: Unknown result type (might be due to invalid IL or missing references)
			//IL_0627: Unknown result type (might be due to invalid IL or missing references)
			//IL_062c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Invalid comparison between Unknown and I4
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				goto IL_0076;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0076;
			case 2:
				_003C_003E1__state = -1;
				_003Cdoors_003E5__2 = Object.FindObjectsOfType<DungeonDoorController>().ToList();
				_003C_003Es__9 = _003Cdoors_003E5__2.GetEnumerator();
				try
				{
					while (_003C_003Es__9.MoveNext())
					{
						_003Cdoor_003E5__10 = _003C_003Es__9.Current;
						if (Object.op_Implicit((Object)(object)_003Cdoor_003E5__10) && !_003Cdoor_003E5__10.m_open)
						{
							if (_003Cdoor_003E5__10.isLocked)
							{
								_003Cdoor_003E5__10.Unlock();
							}
							if (_003Cdoor_003E5__10.OneWayDoor)
							{
								_003Cdoor_003E5__10.DoUnseal(_003Cdoor_003E5__10.downstreamRoom);
							}
						}
						_003Cdoor_003E5__10 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__9/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__9 = default(List<DungeonDoorController>.Enumerator);
				_003C_003E2__current = null;
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				_003ChasVisitedOubliette_003E5__3 = GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)35) > 0f;
				_003CsecretRooms_003E5__4 = Object.FindObjectsOfType<SecretRoomManager>().ToList();
				_003C_003Es__11 = _003CsecretRooms_003E5__4.GetEnumerator();
				try
				{
					while (_003C_003Es__11.MoveNext())
					{
						_003CsecretRoom_003E5__12 = _003C_003Es__11.Current;
						if (Object.op_Implicit((Object)(object)_003CsecretRoom_003E5__12) && !_003CsecretRoom_003E5__12.m_isOpen && (((int)_003CsecretRoom_003E5__12.revealStyle != 3) | _003ChasVisitedOubliette_003E5__3))
						{
							_003CsecretRoom_003E5__12.OpenDoor();
						}
						_003CsecretRoom_003E5__12 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__11/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__11 = default(List<SecretRoomManager>.Enumerator);
				_003C_003E2__current = null;
				_003C_003E1__state = 4;
				return true;
			case 4:
				_003C_003E1__state = -1;
				_003Ctileset_003E5__5 = GameManager.Instance.Dungeon.tileIndices.tilesetId;
				if ((int)_003Ctileset_003E5__5 == 2)
				{
					_003CsecretTrapdoors_003E5__13 = Object.FindObjectsOfType<SecretFloorInteractableController>().ToList();
					_003C_003Es__14 = _003CsecretTrapdoors_003E5__13.GetEnumerator();
					try
					{
						while (_003C_003Es__14.MoveNext())
						{
							_003CsecretTrapdoor_003E5__15 = _003C_003Es__14.Current;
							if (Object.op_Implicit((Object)(object)_003CsecretTrapdoor_003E5__15) && !_003CsecretTrapdoor_003E5__15.GoesToRatFloor && !_003CsecretTrapdoor_003E5__15.m_hasOpened)
							{
								_003Ci_003E5__16 = 0;
								while (_003Ci_003E5__16 < _003CsecretTrapdoor_003E5__15.WorldLocks.Count)
								{
									if (Object.op_Implicit((Object)(object)_003CsecretTrapdoor_003E5__15.WorldLocks[_003Ci_003E5__16]) && _003CsecretTrapdoor_003E5__15.WorldLocks[_003Ci_003E5__16].IsLocked)
									{
										_003CsecretTrapdoor_003E5__15.WorldLocks[_003Ci_003E5__16].ForceUnlock();
									}
									_003Ci_003E5__16++;
								}
							}
							_003CsecretTrapdoor_003E5__15 = null;
						}
					}
					finally
					{
						((IDisposable)_003C_003Es__14/*cast due to .constrained prefix*/).Dispose();
					}
					_003C_003Es__14 = default(List<SecretFloorInteractableController>.Enumerator);
					_003CsecretTrapdoors_003E5__13 = null;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 5;
				return true;
			case 5:
				_003C_003E1__state = -1;
				if ((int)_003Ctileset_003E5__5 == 1)
				{
					_003ChasVisitedAbbey_003E5__17 = GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)36) > 0f;
					_003CabbeyDoors_003E5__18 = Object.FindObjectsOfType<CrestDoorController>().ToList();
					_003C_003Es__19 = _003CabbeyDoors_003E5__18.GetEnumerator();
					try
					{
						while (_003C_003Es__19.MoveNext())
						{
							_003CabbeyDoor_003E5__20 = _003C_003Es__19.Current;
							if ((Object.op_Implicit((Object)(object)_003CabbeyDoor_003E5__20) && !_003CabbeyDoor_003E5__20.m_isOpen) & _003ChasVisitedAbbey_003E5__17)
							{
								Transform transform = ((Component)_003CabbeyDoor_003E5__20.SarcoRigidbody).gameObject.transform;
								transform.position += new Vector3(0f, -2f, 0f);
								_003CabbeyDoor_003E5__20.SarcoRigidbody.Reinitialize();
								_003CabbeyDoor_003E5__20.m_isOpen = true;
							}
							_003CabbeyDoor_003E5__20 = null;
						}
					}
					finally
					{
						((IDisposable)_003C_003Es__19/*cast due to .constrained prefix*/).Dispose();
					}
					_003C_003Es__19 = default(List<CrestDoorController>.Enumerator);
					_003CabbeyDoors_003E5__18 = null;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 6;
				return true;
			case 6:
				_003C_003E1__state = -1;
				if ((int)_003Ctileset_003E5__5 == 16)
				{
					_003ChasVisitedRat_003E5__21 = GameStatsManager.Instance.GetPlayerStatValue((TrackedStats)86) > 0f;
					_003C_003Es__22 = StaticReferenceManager.AllRatTrapdoors.GetEnumerator();
					try
					{
						while (_003C_003Es__22.MoveNext())
						{
							_003Ctrapdoor_003E5__23 = _003C_003Es__22.Current;
							if (Object.op_Implicit((Object)(object)_003Ctrapdoor_003E5__23) && !_003Ctrapdoor_003E5__23.m_hasCreatedRoom)
							{
								_003Ctrapdoor_003E5__23.RevealPercentage = 1f;
								_003Ctrapdoor_003E5__23.UpdatePlayerDustups();
								_003Ctrapdoor_003E5__23.BlendMaterial.SetFloat("_BlendMin", _003Ctrapdoor_003E5__23.RevealPercentage);
								_003Ctrapdoor_003E5__23.LockBlendMaterial.SetFloat("_BlendMin", _003Ctrapdoor_003E5__23.RevealPercentage);
								_003Ctrapdoor_003E5__23.Lock.ForceUnlock();
							}
							_003Ctrapdoor_003E5__23 = null;
						}
					}
					finally
					{
						((IDisposable)_003C_003Es__22/*cast due to .constrained prefix*/).Dispose();
					}
					_003C_003Es__22 = default(List<ResourcefulRatMinesHiddenTrapdoor>.Enumerator);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 7;
				return true;
			case 7:
				{
					_003C_003E1__state = -1;
					return false;
				}
				IL_0076:
				if (GameManager.Instance.IsLoadingLevel)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				_003Cgates_003E5__1 = Object.FindObjectsOfType<InteractableDoorController>().ToList();
				_003C_003Es__6 = _003Cgates_003E5__1.GetEnumerator();
				try
				{
					while (_003C_003Es__6.MoveNext())
					{
						_003Cgate_003E5__7 = _003C_003Es__6.Current;
						if (Object.op_Implicit((Object)(object)_003Cgate_003E5__7) && !_003Cgate_003E5__7.m_hasOpened)
						{
							_003Ci_003E5__8 = 0;
							while (_003Ci_003E5__8 < _003Cgate_003E5__7.WorldLocks.Count)
							{
								if (Object.op_Implicit((Object)(object)_003Cgate_003E5__7.WorldLocks[_003Ci_003E5__8]) && _003Cgate_003E5__7.WorldLocks[_003Ci_003E5__8].IsLocked && (int)_003Cgate_003E5__7.WorldLocks[_003Ci_003E5__8].lockMode != 2)
								{
									_003Cgate_003E5__7.WorldLocks[_003Ci_003E5__8].ForceUnlock();
								}
								_003Ci_003E5__8++;
							}
						}
						_003Cgate_003E5__7 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__6/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__6 = default(List<InteractableDoorController>.Enumerator);
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
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

	public static int ID;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<MasterPin>("Master Pin", "Open Sesame", "Opens most doors. The mark of a skilled 'reverse-escape-artist', otherwise known as an 'intrusionist'.\n\nFor these maestros of the craft, the infinite locked doors and hidden passageways of the Gungeon represent the ultimate challenge.", "masterpin_icon", assetbundle: true);
		val.quality = (ItemQuality)3;
		val.additionalMagnificenceModifier = 1f;
		ID = val.PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		((MonoBehaviour)this).StartCoroutine(UnlockAllDoors());
		GameManager.Instance.OnNewLevelFullyLoaded += OnPostLevelLoad;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= OnPostLevelLoad;
		((PassiveItem)this).DisableEffect(player);
	}

	private void OnPostLevelLoad()
	{
		((MonoBehaviour)this).StartCoroutine(UnlockAllDoors());
	}

	private IEnumerator UnlockAllDoors()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CUnlockAllDoors_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}
}
