using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ChestAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class TruthKnowersTrance : PassiveItem
{
	public class ChestIsFading : MonoBehaviour
	{
	}

	[CompilerGenerated]
	private sealed class _003CprocessChest_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Chest chest;

		public TruthKnowersTrance _003C_003E4__this;

		private bool _003CisValidTier_003E5__1;

		private RoomHandler _003CcurrentRoom_003E5__2;

		private GameObject _003Calbern_003E5__3;

		private float _003Celapsed_003E5__4;

		private float _003Cduration_003E5__5;

		private float _003CsparkleAccum_003E5__6;

		private GameObject _003CtruthChest_003E5__7;

		private Chest _003CtruthChestComponent_003E5__8;

		private Shader _003CTruthChestRevertShader_003E5__9;

		private float _003Calbernelapsed_003E5__10;

		private float _003Calbernduration_003E5__11;

		private tk2dBaseSprite _003CalbernSprite_003E5__12;

		private int _003Cnum_003E5__13;

		private Vector2 _003Cminpos_003E5__14;

		private Vector2 _003Cmaxpos_003E5__15;

		private int _003Ci_003E5__16;

		private GameObject _003Cpiss_003E5__17;

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
		public _003CprocessChest_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CcurrentRoom_003E5__2 = null;
			_003Calbern_003E5__3 = null;
			_003CtruthChest_003E5__7 = null;
			_003CtruthChestComponent_003E5__8 = null;
			_003CTruthChestRevertShader_003E5__9 = null;
			_003CalbernSprite_003E5__12 = null;
			_003Cpiss_003E5__17 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Expected O, but got Unknown
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0702: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Invalid comparison between Unknown and I4
			//IL_041f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0424: Unknown result type (might be due to invalid IL or missing references)
			//IL_0435: Unknown result type (might be due to invalid IL or missing references)
			//IL_043a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_048d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CisValidTier_003E5__1 = (int)ChestUtility.GetChestTier(chest) == 0 || (Object.op_Implicit((Object)(object)((PassiveItem)_003C_003E4__this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)_003C_003E4__this).Owner, "Several Truths") && (int)ChestUtility.GetChestTier(chest) == 1);
				if (!_003CisValidTier_003E5__1 || Chest.m_IsCoopMode || chest.IsMirrorChest || (Object)(object)((Component)chest).GetComponent<ChestIsFading>() != (Object)null)
				{
					return false;
				}
				_003CcurrentRoom_003E5__2 = ((DungeonPlaceableBehaviour)chest).GetAbsoluteParentRoom();
				chest.ForceKillFuse();
				chest.PreventFuse = true;
				((BraveBehaviour)chest).majorBreakable.TemporarilyInvulnerable = true;
				chest.m_temporarilyUnopenable = true;
				((Component)chest).gameObject.AddComponent<ChestIsFading>();
				_003CcurrentRoom_003E5__2.DeregisterInteractable((IPlayerInteractable)(object)chest);
				SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)chest).sprite, true);
				chest.DeregisterChestOnMinimap();
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Calbern_003E5__3 = Object.Instantiate<GameObject>(hoveringAlbernVFX, Vector2.op_Implicit(((BraveBehaviour)chest).sprite.WorldCenter + new Vector2(0f, 1f)), Quaternion.identity);
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003Celapsed_003E5__4 = 0f;
				_003Cduration_003E5__5 = 5f;
				_003CsparkleAccum_003E5__6 = 0f;
				((BraveBehaviour)((BraveBehaviour)chest).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/Internal/SimpleAlphaFadeUnlit");
				if ((Object)(object)chest.LockAnimator != (Object)null)
				{
					((BraveBehaviour)chest.LockAnimator).renderer.material.shader = ShaderCache.Acquire("Brave/Internal/SimpleAlphaFadeUnlit");
				}
				_003CtruthChest_003E5__7 = Object.Instantiate<GameObject>(TruthChest, ((BraveBehaviour)chest).transform.position + new Vector3(0.25f, 0f, 0f), Quaternion.identity);
				_003CtruthChestComponent_003E5__8 = _003CtruthChest_003E5__7.GetComponent<Chest>();
				_003CtruthChestComponent_003E5__8.m_room = _003CcurrentRoom_003E5__2;
				((BraveBehaviour)_003CtruthChestComponent_003E5__8).sprite.UpdateZDepth();
				((BraveBehaviour)_003CtruthChestComponent_003E5__8).majorBreakable.TemporarilyInvulnerable = true;
				_003CtruthChestComponent_003E5__8.m_temporarilyUnopenable = true;
				_003CtruthChestComponent_003E5__8.Initialize();
				SpriteOutlineManager.RemoveOutlineFromSprite(((BraveBehaviour)_003CtruthChestComponent_003E5__8).sprite, true);
				PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)_003CtruthChestComponent_003E5__8).specRigidbody, (int?)null, false);
				_003CTruthChestRevertShader_003E5__9 = ((BraveBehaviour)((BraveBehaviour)_003CtruthChestComponent_003E5__8).sprite).renderer.material.shader;
				((BraveBehaviour)((BraveBehaviour)_003CtruthChestComponent_003E5__8).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/Internal/SimpleAlphaFadeUnlit");
				if ((Object)(object)_003CtruthChestComponent_003E5__8.LockAnimator != (Object)null)
				{
					((BraveBehaviour)_003CtruthChestComponent_003E5__8.LockAnimator).renderer.material.shader = ShaderCache.Acquire("Brave/Internal/SimpleAlphaFadeUnlit");
				}
				goto IL_065b;
			case 3:
				_003C_003E1__state = -1;
				goto IL_065b;
			case 4:
				_003C_003E1__state = -1;
				if ((Object)(object)_003CtruthChestComponent_003E5__8.LockAnimator != (Object)null)
				{
					_003CtruthChestComponent_003E5__8.LockAnimator.PlayAndDestroyObject("truth_lock_open", (Action)null);
				}
				((BraveBehaviour)((BraveBehaviour)_003CtruthChestComponent_003E5__8).sprite).renderer.material.shader = _003CTruthChestRevertShader_003E5__9;
				if ((Object)(object)_003CtruthChestComponent_003E5__8.LockAnimator != (Object)null)
				{
					((BraveBehaviour)_003CtruthChestComponent_003E5__8.LockAnimator).renderer.material.shader = _003CTruthChestRevertShader_003E5__9;
				}
				if (Chest.m_IsCoopMode)
				{
					_003CtruthChestComponent_003E5__8.BecomeCoopChest();
				}
				_003Calbernelapsed_003E5__10 = 0f;
				_003Calbernduration_003E5__11 = 4f;
				_003CalbernSprite_003E5__12 = _003Calbern_003E5__3.GetComponent<tk2dBaseSprite>();
				((BraveBehaviour)_003CalbernSprite_003E5__12).renderer.material.shader = ShaderCache.Acquire("Brave/Internal/SimpleAlphaFadeUnlit");
				_003CalbernSprite_003E5__12.usesOverrideMaterial = true;
				break;
			case 5:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_065b:
				if (_003Celapsed_003E5__4 < _003Cduration_003E5__5)
				{
					_003Celapsed_003E5__4 += BraveTime.DeltaTime;
					_003CsparkleAccum_003E5__6 += BraveTime.DeltaTime * 3f;
					if (_003CsparkleAccum_003E5__6 > 1f)
					{
						_003Cnum_003E5__13 = Mathf.FloorToInt(_003CsparkleAccum_003E5__6);
						_003CsparkleAccum_003E5__6 %= 1f;
						_003Cminpos_003E5__14 = ((BraveBehaviour)chest).sprite.WorldBottomLeft;
						_003Cmaxpos_003E5__15 = ((BraveBehaviour)chest).sprite.WorldTopRight;
						_003Ci_003E5__16 = 0;
						while (_003Ci_003E5__16 < _003Cnum_003E5__13)
						{
							_003Cpiss_003E5__17 = Object.Instantiate<GameObject>(SharedVFX.GoldenSparkle, Vector2.op_Implicit(new Vector2(Random.Range(_003Cminpos_003E5__14.x, _003Cmaxpos_003E5__15.x), Random.Range(_003Cminpos_003E5__14.y, _003Cmaxpos_003E5__15.y))), Quaternion.identity);
							_003Cpiss_003E5__17.transform.parent = ((BraveBehaviour)chest).transform;
							_003Cpiss_003E5__17.GetComponent<tk2dBaseSprite>().HeightOffGround = 0.2f;
							((BraveBehaviour)chest).sprite.AttachRenderer(_003Cpiss_003E5__17.GetComponent<tk2dBaseSprite>());
							_003Cpiss_003E5__17 = null;
							_003Ci_003E5__16++;
						}
					}
					((BraveBehaviour)((BraveBehaviour)chest).sprite).renderer.material.SetFloat("_Fade", Mathf.Lerp(1f, 0f, _003Celapsed_003E5__4 / _003Cduration_003E5__5));
					if ((Object)(object)chest.LockAnimator != (Object)null)
					{
						((BraveBehaviour)chest.LockAnimator).renderer.material.SetFloat("_Fade", Mathf.Lerp(1f, 0f, _003Celapsed_003E5__4 / _003Cduration_003E5__5));
					}
					((BraveBehaviour)((BraveBehaviour)_003CtruthChestComponent_003E5__8).sprite).renderer.material.SetFloat("_Fade", Mathf.Lerp(0f, 1f, _003Celapsed_003E5__4 / _003Cduration_003E5__5));
					if ((Object)(object)_003CtruthChestComponent_003E5__8.LockAnimator != (Object)null)
					{
						((BraveBehaviour)_003CtruthChestComponent_003E5__8.LockAnimator).renderer.material.SetFloat("_Fade", Mathf.Lerp(0f, 1f, _003Celapsed_003E5__4 / _003Cduration_003E5__5));
					}
					_003C_003E2__current = null;
					_003C_003E1__state = 3;
					return true;
				}
				Object.Destroy((Object)(object)((Component)chest).gameObject);
				_003CcurrentRoom_003E5__2.RegisterInteractable((IPlayerInteractable)(object)_003CtruthChestComponent_003E5__8);
				SpriteOutlineManager.AddOutlineToSprite(((BraveBehaviour)_003CtruthChestComponent_003E5__8).sprite, Color.black);
				((BraveBehaviour)_003CtruthChestComponent_003E5__8).majorBreakable.TemporarilyInvulnerable = false;
				_003CtruthChestComponent_003E5__8.m_temporarilyUnopenable = false;
				_003CtruthChestComponent_003E5__8.IsLocked = false;
				_003CtruthChestComponent_003E5__8.IsSealed = false;
				_003CtruthChestComponent_003E5__8.RegisterChestOnMinimap(_003CcurrentRoom_003E5__2);
				_003C_003E2__current = (object)new WaitForSeconds(0.5f);
				_003C_003E1__state = 4;
				return true;
			}
			if (_003Calbernelapsed_003E5__10 < _003Calbernduration_003E5__11)
			{
				_003Calbernelapsed_003E5__10 += BraveTime.DeltaTime;
				((BraveBehaviour)_003CalbernSprite_003E5__12).renderer.material.SetFloat("_Fade", Mathf.Lerp(1f, 0f, _003Calbernelapsed_003E5__10 / _003Calbernduration_003E5__11));
				_003C_003E2__current = null;
				_003C_003E1__state = 5;
				return true;
			}
			Object.Destroy((Object)(object)_003Calbern_003E5__3);
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

	public static int ID;

	public static GameObject hoveringAlbernVFX;

	public RoomHandler lastCheckedRoom;

	public static GameObject TruthChest = LoadHelper.LoadAssetFromAnywhere<GameObject>("truthchest");

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<TruthKnowersTrance>("Truth Knowers Trance", "Several Truths!", "Coaxes low quality chests into revealing their TRUE form!\n\nA heightened state of meditative candour only attainable by the most adept and honest Brothers of the Order of Truth Knowers.", "truthknowerstrance_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		ID = ((PickupObject)val).PickupObjectId;
		CustomActions.OnChestPostSpawn = (Action<Chest>)Delegate.Combine(CustomActions.OnChestPostSpawn, new Action<Chest>(OnChestSpawned));
		hoveringAlbernVFX = VFXToolbox.CreateVFXBundle("HoveringAlbern", usesZHeight: true, 5f, -1f, -1f, null);
	}

	public override void Update()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) || Dungeon.IsGenerating || ((PassiveItem)this).Owner.CurrentRoom == null || ((PassiveItem)this).Owner.CurrentRoom == lastCheckedRoom)
		{
			return;
		}
		Chest[] array = Object.FindObjectsOfType<Chest>();
		Chest[] array2 = array;
		foreach (Chest val in array2)
		{
			if (Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)val).transform.position) == ((PassiveItem)this).Owner.CurrentRoom && !val.IsOpen && !val.IsBroken)
			{
				((MonoBehaviour)this).StartCoroutine(processChest(val));
			}
		}
		lastCheckedRoom = ((PassiveItem)this).Owner.CurrentRoom;
	}

	public void ReactToRuntimeSpawnedChest(Chest chest)
	{
		((MonoBehaviour)this).StartCoroutine(processChest(chest));
	}

	public static void OnChestSpawned(Chest chest)
	{
		if (Dungeon.IsGenerating || !GameManagerUtility.AnyPlayerHasPickupID(GameManager.Instance, ID))
		{
			return;
		}
		if ((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null)
		{
			foreach (PassiveItem passiveItem in GameManager.Instance.PrimaryPlayer.passiveItems)
			{
				if ((Object)(object)((Component)passiveItem).GetComponent<TruthKnowersTrance>() != (Object)null)
				{
					((Component)passiveItem).GetComponent<TruthKnowersTrance>().ReactToRuntimeSpawnedChest(chest);
				}
			}
		}
		if (!((Object)(object)GameManager.Instance.SecondaryPlayer != (Object)null))
		{
			return;
		}
		foreach (PassiveItem passiveItem2 in GameManager.Instance.SecondaryPlayer.passiveItems)
		{
			if ((Object)(object)((Component)passiveItem2).GetComponent<TruthKnowersTrance>() != (Object)null)
			{
				((Component)passiveItem2).GetComponent<TruthKnowersTrance>().ReactToRuntimeSpawnedChest(chest);
			}
		}
	}

	public IEnumerator processChest(Chest chest)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CprocessChest_003Ed__9(0)
		{
			_003C_003E4__this = this,
			chest = chest
		};
	}
}
