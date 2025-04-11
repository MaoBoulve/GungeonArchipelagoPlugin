using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brave.BulletScript;
using UnityEngine;

namespace NevernamedsItems;

public class GunjurerSlamPlayerScript : Script
{
	public class ExpandingBullet : Bullet
	{
		[CompilerGenerated]
		private sealed class _003CTop_003Ed__1 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExpandingBullet _003C_003E4__this;

			private Vector2 _003CcenterPosition_003E5__1;

			private int _003Ci_003E5__2;

			private Vector2 _003CactualOffset_003E5__3;

			private int _003Cj_003E5__4;

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
			public _003CTop_003Ed__1(int _003C_003E1__state)
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
				//IL_0045: Unknown result type (might be due to invalid IL or missing references)
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_006a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0075: Unknown result type (might be due to invalid IL or missing references)
				//IL_007f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0084: Unknown result type (might be due to invalid IL or missing references)
				//IL_0089: Unknown result type (might be due to invalid IL or missing references)
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_009a: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00db: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0180: Unknown result type (might be due to invalid IL or missing references)
				//IL_018b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0195: Unknown result type (might be due to invalid IL or missing references)
				//IL_019a: Unknown result type (might be due to invalid IL or missing references)
				//IL_019f: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					((Bullet)_003C_003E4__this).ManualControl = true;
					_003CcenterPosition_003E5__1 = ((Bullet)_003C_003E4__this).Position;
					_003Ci_003E5__2 = 0;
					goto IL_0129;
				case 1:
					_003C_003E1__state = -1;
					_003Ci_003E5__2++;
					goto IL_0129;
				case 2:
					{
						_003C_003E1__state = -1;
						_003Cj_003E5__4++;
						break;
					}
					IL_0129:
					if (_003Ci_003E5__2 < 15)
					{
						((Bullet)_003C_003E4__this).UpdateVelocity();
						_003CcenterPosition_003E5__1 += ((Bullet)_003C_003E4__this).Velocity / 60f;
						_003CactualOffset_003E5__3 = Vector2.Lerp(Vector2.zero, _003C_003E4__this.m_offset, (float)_003Ci_003E5__2 / 14f);
						_003CactualOffset_003E5__3 = Vector2Extensions.Rotate(_003CactualOffset_003E5__3, 3f * (float)_003Ci_003E5__2);
						((Bullet)_003C_003E4__this).Position = _003CcenterPosition_003E5__1 + _003CactualOffset_003E5__3;
						_003C_003E2__current = ((Bullet)_003C_003E4__this).Wait(1);
						_003C_003E1__state = 1;
						return true;
					}
					((Bullet)_003C_003E4__this).Direction = _003C_003E4__this.m_parent.aimDirection;
					((Bullet)_003C_003E4__this).Speed = 10f;
					_003Cj_003E5__4 = 0;
					break;
				}
				if (_003Cj_003E5__4 < 300)
				{
					((Bullet)_003C_003E4__this).UpdateVelocity();
					_003CcenterPosition_003E5__1 += ((Bullet)_003C_003E4__this).Velocity / 60f;
					((Bullet)_003C_003E4__this).Position = _003CcenterPosition_003E5__1 + Vector2Extensions.Rotate(_003C_003E4__this.m_offset, 3f * (float)(15 + _003Cj_003E5__4));
					_003C_003E2__current = ((Bullet)_003C_003E4__this).Wait(1);
					_003C_003E1__state = 2;
					return true;
				}
				((Bullet)_003C_003E4__this).Vanish(false);
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

		private GunjurerSlamPlayerScript m_parent;

		private Vector2 m_offset;

		public ExpandingBullet(GunjurerSlamPlayerScript parent, Vector2 offset)
			: base((string)null, false, false, false)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			m_parent = parent;
			m_offset = offset;
		}

		public override IEnumerator Top()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CTop_003Ed__1(0)
			{
				_003C_003E4__this = this
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CTop_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GunjurerSlamPlayerScript _003C_003E4__this;

		private int _003C_003Es__1;

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
		public _003CTop_003Ed__2(int _003C_003E1__state)
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
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			((Bullet)_003C_003E4__this).EndOnBlank = false;
			int num = Random.Range(0, 4);
			_003C_003Es__1 = num;
			switch (_003C_003Es__1)
			{
			case 0:
				_003C_003E4__this.FireX();
				break;
			case 1:
				_003C_003E4__this.FireSquare();
				break;
			case 2:
				_003C_003E4__this.FireTriangle();
				break;
			case 3:
				_003C_003E4__this.FireCircle();
				break;
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

	public float aimDirection;

	public float overrideSpeed = 10f;

	public const float Radius = 2f;

	public const int GrowTime = 15;

	public const float RotationSpeed = 180f;

	public const float BulletSpeed = 10f;

	public override IEnumerator Top()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CTop_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	private void FireX()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		Vector2 start = Vector2Extensions.Rotate(new Vector2(2f, 0f), 45f);
		Vector2 start2 = Vector2Extensions.Rotate(new Vector2(2f, 0f), 135f);
		Vector2 end = Vector2Extensions.Rotate(new Vector2(2f, 0f), 225f);
		Vector2 end2 = Vector2Extensions.Rotate(new Vector2(2f, 0f), -45f);
		FireExpandingLine(start, end, 11);
		FireExpandingLine(start2, end2, 11);
	}

	private void FireSquare()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2Extensions.Rotate(new Vector2(2f, 0f), 45f);
		Vector2 val2 = Vector2Extensions.Rotate(new Vector2(2f, 0f), 135f);
		Vector2 val3 = Vector2Extensions.Rotate(new Vector2(2f, 0f), 225f);
		Vector2 val4 = Vector2Extensions.Rotate(new Vector2(2f, 0f), -45f);
		FireExpandingLine(val, val2, 9);
		FireExpandingLine(val2, val3, 9);
		FireExpandingLine(val3, val4, 9);
		FireExpandingLine(val4, val, 9);
	}

	private void FireTriangle()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2Extensions.Rotate(new Vector2(2f, 0f), 90f);
		Vector2 val2 = Vector2Extensions.Rotate(new Vector2(2f, 0f), 210f);
		Vector2 val3 = Vector2Extensions.Rotate(new Vector2(2f, 0f), 330f);
		FireExpandingLine(val, val2, 10);
		FireExpandingLine(val2, val3, 10);
		FireExpandingLine(val3, val, 10);
	}

	private void FireCircle()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 36; i++)
		{
			((Bullet)this).Fire((Bullet)(object)new ExpandingBullet(this, Vector2Extensions.Rotate(new Vector2(2f, 0f), (float)i / 35f * 360f)));
		}
	}

	private void FireExpandingLine(Vector2 start, Vector2 end, int numBullets)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < numBullets; i++)
		{
			((Bullet)this).Fire((Bullet)(object)new ExpandingBullet(this, Vector2.Lerp(start, end, (float)i / ((float)numBullets - 1f))));
		}
	}
}
