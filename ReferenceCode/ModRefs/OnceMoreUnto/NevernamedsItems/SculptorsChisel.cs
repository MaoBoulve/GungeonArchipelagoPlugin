using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class SculptorsChisel : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CBecomeDecoy_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FlippableCover table;

		public SculptorsChisel _003C_003E4__this;

		private GameObject _003Cdecoy_003E5__1;

		private tk2dBaseSprite _003CdecoySprite_003E5__2;

		private MeshRenderer _003Ccomponent_003E5__3;

		private Material[] _003CsharedMaterials_003E5__4;

		private bool _003Cskip_003E5__5;

		private int _003Ci_003E5__6;

		private Material _003Cmaterial_003E5__7;

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
		public _003CBecomeDecoy_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cdecoy_003E5__1 = null;
			_003CdecoySprite_003E5__2 = null;
			_003Ccomponent_003E5__3 = null;
			_003CsharedMaterials_003E5__4 = null;
			_003Cmaterial_003E5__7 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Expected O, but got Unknown
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Expected O, but got Unknown
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e6: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)table) && Object.op_Implicit((Object)(object)((PassiveItem)_003C_003E4__this).Owner))
				{
					PickupObject byId = PickupObjectDatabase.GetById(37);
					SpawnManager.SpawnVFX(((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX, Vector2.op_Implicit(((BraveBehaviour)table).specRigidbody.UnitCenter), Quaternion.identity);
					_003Cdecoy_003E5__1 = Object.Instantiate<GameObject>(((Component)PickupObjectDatabase.GetById(71)).GetComponent<SpawnObjectPlayerItem>().objectToSpawn.gameObject, Vector2.op_Implicit(((BraveBehaviour)table).sprite.WorldBottomCenter), Quaternion.identity);
					_003CdecoySprite_003E5__2 = _003Cdecoy_003E5__1.GetComponent<tk2dBaseSprite>();
					if (Object.op_Implicit((Object)(object)_003CdecoySprite_003E5__2))
					{
						_003CdecoySprite_003E5__2.PlaceAtPositionByAnchor(Vector2.op_Implicit(((BraveBehaviour)table).sprite.WorldCenter), (Anchor)4);
					}
					AkSoundEngine.PostEvent("Play_ITM_Folding_Table_Use_01", ((Component)((PassiveItem)_003C_003E4__this).Owner).gameObject);
					Object.Destroy((Object)(object)((Component)table).gameObject);
					_003Ccomponent_003E5__3 = _003Cdecoy_003E5__1.gameObject.GetComponentInChildren<MeshRenderer>();
					if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)_003C_003E4__this).Owner, "Sterling") && Object.op_Implicit((Object)(object)_003Ccomponent_003E5__3))
					{
						_003CsharedMaterials_003E5__4 = ((Renderer)_003Ccomponent_003E5__3).sharedMaterials;
						_003Cskip_003E5__5 = false;
						_003Ci_003E5__6 = 0;
						while (_003Ci_003E5__6 < _003CsharedMaterials_003E5__4.Length)
						{
							if ((Object)(object)_003CsharedMaterials_003E5__4[_003Ci_003E5__6].shader == (Object)(object)RectangularMirror.glint)
							{
								_003Cskip_003E5__5 = true;
							}
							_003Ci_003E5__6++;
						}
						if (!_003Cskip_003E5__5)
						{
							Array.Resize(ref _003CsharedMaterials_003E5__4, _003CsharedMaterials_003E5__4.Length + 1);
							_003Cmaterial_003E5__7 = new Material(RectangularMirror.glint);
							_003Cmaterial_003E5__7.SetTexture("_MainTex", _003CsharedMaterials_003E5__4[0].GetTexture("_MainTex"));
							_003CsharedMaterials_003E5__4[_003CsharedMaterials_003E5__4.Length - 1] = _003Cmaterial_003E5__7;
							((Renderer)_003Ccomponent_003E5__3).sharedMaterials = _003CsharedMaterials_003E5__4;
							_003Cmaterial_003E5__7 = null;
						}
						if (Object.op_Implicit((Object)(object)_003Cdecoy_003E5__1.GetComponent<SpeculativeRigidbody>()))
						{
							SpeculativeRigidbody component = _003Cdecoy_003E5__1.GetComponent<SpeculativeRigidbody>();
							component.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)component.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(_003C_003E4__this.PreCollision));
						}
						if (Object.op_Implicit((Object)(object)_003Cdecoy_003E5__1.gameObject.GetComponentInChildren<MajorBreakable>()))
						{
							((MonoBehaviour)_003C_003E4__this).StartCoroutine(_003C_003E4__this.KillTime(_003Cdecoy_003E5__1.gameObject.GetComponentInChildren<MajorBreakable>()));
						}
						_003CsharedMaterials_003E5__4 = null;
					}
					_003Cdecoy_003E5__1 = null;
					_003CdecoySprite_003E5__2 = null;
					_003Ccomponent_003E5__3 = null;
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

	[CompilerGenerated]
	private sealed class _003CKillTime_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MajorBreakable breaka;

		public SculptorsChisel _003C_003E4__this;

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
		public _003CKillTime_003Ed__7(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(8f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)breaka) && !breaka.m_isBroken)
				{
					breaka.Break(Vector2.zero);
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

	public static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<SculptorsChisel>("Sculptors Chisel", "A Real Boy", "Chance to sculpt flipped tables into immaculate decoys.\n\nThe chisel of an ancient sculptor who came to the gungeon in search of a way to cure his petrified beloved.", "sculptorschisel_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		player.OnTableFlipCompleted = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipCompleted, new Action<FlippableCover>(OnFlip));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnTableFlipCompleted = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipCompleted, new Action<FlippableCover>(OnFlip));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	public void OnFlip(FlippableCover table)
	{
		if (Object.op_Implicit((Object)(object)table) && Object.op_Implicit((Object)(object)((Component)table).gameObject) && Random.value <= 0.25f)
		{
			((MonoBehaviour)this).StartCoroutine(BecomeDecoy(table));
		}
	}

	private IEnumerator BecomeDecoy(FlippableCover table)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBecomeDecoy_003Ed__5(0)
		{
			_003C_003E4__this = this,
			table = table
		};
	}

	private void PreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)other) && (Object)(object)((Component)other).GetComponent<Projectile>() != (Object)null && (Object)(object)ProjectileUtility.ProjectilePlayerOwner(((Component)other).GetComponent<Projectile>()) == (Object)null)
		{
			ProjectileUtility.ReflectBullet(((Component)other).GetComponent<Projectile>(), true, (GameActor)(object)((PassiveItem)this).Owner, 15f, true, 1f, 5f, 5f, (string)null);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Fast Pass"))
			{
				ProjectileData baseData = ((Component)other).GetComponent<Projectile>().baseData;
				baseData.speed *= 2f;
			}
			((Component)other).GetComponent<Projectile>().UpdateSpeed();
			PhysicsEngine.SkipCollision = true;
		}
	}

	private IEnumerator KillTime(MajorBreakable breaka)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CKillTime_003Ed__7(0)
		{
			_003C_003E4__this = this,
			breaka = breaka
		};
	}
}
