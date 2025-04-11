using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NevernamedsItems;

internal static class ProjSpawnHelper
{
	[CompilerGenerated]
	private sealed class _003CNoCollideTilesForSeconds_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile proj;

		public float time;

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
		public _003CNoCollideTilesForSeconds_003Ed__2(int _003C_003E1__state)
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
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)proj) && Object.op_Implicit((Object)(object)((BraveBehaviour)proj).specRigidbody))
				{
					((BraveBehaviour)proj).specRigidbody.CollideWithTileMap = false;
					proj.UpdateCollisionMask();
					_003C_003E2__current = (object)new WaitForSeconds(time);
					_003C_003E1__state = 1;
					return true;
				}
				break;
			case 1:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)proj) && Object.op_Implicit((Object)(object)((BraveBehaviour)proj).specRigidbody))
				{
					((BraveBehaviour)proj).specRigidbody.CollideWithTileMap = true;
					proj.UpdateCollisionMask();
				}
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

	public static void EasyAnimate(this Projectile proj, List<string> projectileNames, int frames, IntVector2 dimensions, int fps, bool light, WrapMode wrapmode)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		proj.AnimateProjectile(projectileNames, fps, wrapmode, MiscTools.DupeList<IntVector2>(dimensions, frames), MiscTools.DupeList(light, frames), MiscTools.DupeList<Anchor>((Anchor)4, frames), MiscTools.DupeList(value: true, frames), MiscTools.DupeList(value: false, frames), MiscTools.DupeList<Vector3?>(null, frames), MiscTools.DupeList<IntVector2?>(null, frames), MiscTools.DupeList<IntVector2?>(null, frames), MiscTools.DupeList<Projectile>(null, frames), 0);
	}

	public static void RenderTilePiercingForSeconds(this Projectile proj, float seconds)
	{
		((MonoBehaviour)proj).StartCoroutine(NoCollideTilesForSeconds(proj, seconds));
	}

	private static IEnumerator NoCollideTilesForSeconds(Projectile proj, float time)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CNoCollideTilesForSeconds_003Ed__2(0)
		{
			proj = proj,
			time = time
		};
	}

	public static void ScaleByPlayerStats(this Projectile proj, PlayerController player)
	{
		if ((Object)(object)player != (Object)null)
		{
			ProjectileData baseData = proj.baseData;
			baseData.damage *= player.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = proj.baseData;
			baseData2.speed *= player.stats.GetStatValue((StatType)6);
			ProjectileData baseData3 = proj.baseData;
			baseData3.range *= player.stats.GetStatValue((StatType)26);
			ProjectileData baseData4 = proj.baseData;
			baseData4.force *= player.stats.GetStatValue((StatType)12);
			proj.BossDamageMultiplier *= player.stats.GetStatValue((StatType)22);
			proj.UpdateSpeed();
		}
	}

	public static float GetAccuracyAngled(float startFloat, float variance, PlayerController playerToScaleAccuracyOff = null)
	{
		if ((Object)(object)playerToScaleAccuracyOff != (Object)null)
		{
			variance *= playerToScaleAccuracyOff.stats.GetStatValue((StatType)2);
		}
		float num = variance * 0.5f;
		float num2 = num * -1f;
		float num3 = Random.Range(num2, num);
		return startFloat + num3;
	}

	public static GameObject SpawnProjectileTowardsPoint(GameObject projectile, Vector2 startingPosition, Vector2 targetPosition, float angleOffset = 0f, float angleVariance = 0f, PlayerController playerToScaleAccuracyOff = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = targetPosition - startingPosition;
		if (angleOffset != 0f)
		{
			val = Vector2Extensions.Rotate(val, angleOffset);
		}
		if (angleVariance != 0f)
		{
			if ((Object)(object)playerToScaleAccuracyOff != (Object)null)
			{
				angleVariance *= playerToScaleAccuracyOff.stats.GetStatValue((StatType)2);
			}
			float num = angleVariance * 0.5f;
			float num2 = num * -1f;
			float num3 = Random.Range(num2, num);
			val = Vector2Extensions.Rotate(val, num3);
		}
		return SpawnManager.SpawnProjectile(projectile, Vector2.op_Implicit(startingPosition), Quaternion.Euler(0f, 0f, Vector2Extensions.ToAngle(val)), true);
	}
}
