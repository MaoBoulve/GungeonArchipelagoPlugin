using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ChallengeUnlocks
{
	[CompilerGenerated]
	private sealed class _003CSaveDeaths_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string guid;

		private AIActor _003CprefabForGUID_003E5__1;

		private ValidTilesets _003CcurrentTileset_003E5__2;

		private ChallengeType _003C_003Es__3;

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
		public _003CSaveDeaths_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CprefabForGUID_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Invalid comparison between Unknown and I4
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Invalid comparison between Unknown and I4
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Invalid comparison between Unknown and I4
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			_003CprefabForGUID_003E5__1 = EnemyDatabase.GetOrLoadByGuid(guid);
			_003CcurrentTileset_003E5__2 = GameManager.Instance.Dungeon.tileIndices.tilesetId;
			if ((Object)(object)_003CprefabForGUID_003E5__1 != (Object)null && Object.op_Implicit((Object)(object)((BraveBehaviour)_003CprefabForGUID_003E5__1).healthHaver) && ((BraveBehaviour)_003CprefabForGUID_003E5__1).healthHaver.IsBoss && !((BraveBehaviour)_003CprefabForGUID_003E5__1).healthHaver.IsSubboss && (int)GameManager.Instance.CurrentGameMode != 2)
			{
				if ((int)_003CcurrentTileset_003E5__2 == 32 && Challenges.CurrentChallenge == ChallengeType.KEEP_IT_COOL && !SaveAPIManager.GetFlag(CustomDungeonFlags.CHALLENGE_KEEPITCOOL_BEATEN))
				{
					SaveAPIManager.SetFlag(CustomDungeonFlags.CHALLENGE_KEEPITCOOL_BEATEN, value: true);
				}
				if ((int)_003CcurrentTileset_003E5__2 == 64)
				{
					ChallengeType currentChallenge = Challenges.CurrentChallenge;
					_003C_003Es__3 = currentChallenge;
					switch (_003C_003Es__3)
					{
					case ChallengeType.WHAT_ARMY:
						if (!SaveAPIManager.GetFlag(CustomDungeonFlags.CHALLENGE_WHATARMY_BEATEN))
						{
							SaveAPIManager.SetFlag(CustomDungeonFlags.CHALLENGE_WHATARMY_BEATEN, value: true);
						}
						break;
					case ChallengeType.TOIL_AND_TROUBLE:
						if (!SaveAPIManager.GetFlag(CustomDungeonFlags.CHALLENGE_TOILANDTROUBLE_BEATEN))
						{
							SaveAPIManager.SetFlag(CustomDungeonFlags.CHALLENGE_TOILANDTROUBLE_BEATEN, value: true);
						}
						break;
					case ChallengeType.INVISIBLEO:
						if (!SaveAPIManager.GetFlag(CustomDungeonFlags.CHALLENGE_INVISIBLEO_BEATEN))
						{
							SaveAPIManager.SetFlag(CustomDungeonFlags.CHALLENGE_INVISIBLEO_BEATEN, value: true);
						}
						break;
					}
				}
			}
			return false;
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

	public static void Init()
	{
		CustomActions.OnAnyHealthHaverDie = (Action<HealthHaver>)Delegate.Combine(CustomActions.OnAnyHealthHaverDie, new Action<HealthHaver>(AnyHealthHaverKilled));
	}

	public static void AnyHealthHaverKilled(HealthHaver target)
	{
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer))
		{
			ETGMod.StartGlobalCoroutine(SaveDeaths(((BraveBehaviour)target).aiActor.EnemyGuid));
		}
	}

	public static IEnumerator SaveDeaths(string guid)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSaveDeaths_003Ed__2(0)
		{
			guid = guid
		};
	}
}
