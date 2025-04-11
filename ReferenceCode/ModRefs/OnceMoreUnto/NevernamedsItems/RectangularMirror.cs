using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RectangularMirror : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CKillTime_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MajorBreakable breaka;

		public RectangularMirror _003C_003E4__this;

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
		public _003CKillTime_003Ed__6(int _003C_003E1__state)
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
				_003C_003E2__current = (object)new WaitForSeconds(20f);
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

	public static Shader glint;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<RectangularMirror>("Rectangular Mirror", "Table Reflection", "Flipped tables reflect bullets. \n\nThis artefact was used by ancient acolytes of the Tabla Sutra to study their own flips from a new perspective. In time it gained an almost mystical reputation.", "rectangularmirror_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		glint = Shader.Find("Brave/ItemSpecific/LootGlintAdditivePass");
	}

	public override void Pickup(PlayerController player)
	{
		player.OnTableFlipCompleted = (Action<FlippableCover>)Delegate.Combine(player.OnTableFlipCompleted, new Action<FlippableCover>(TableFlipCompleted));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		player.OnTableFlipCompleted = (Action<FlippableCover>)Delegate.Remove(player.OnTableFlipCompleted, new Action<FlippableCover>(TableFlipCompleted));
		((PassiveItem)this).DisableEffect(player);
	}

	private void TableFlipCompleted(FlippableCover obj)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		MeshRenderer componentInChildren = ((Component)obj).gameObject.GetComponentInChildren<MeshRenderer>();
		if (!Object.op_Implicit((Object)(object)componentInChildren))
		{
			return;
		}
		Material[] array = ((Renderer)componentInChildren).sharedMaterials;
		for (int i = 0; i < array.Length; i++)
		{
			if ((Object)(object)array[i].shader == (Object)(object)glint)
			{
				return;
			}
		}
		Array.Resize(ref array, array.Length + 1);
		Material val = new Material(glint);
		val.SetTexture("_MainTex", array[0].GetTexture("_MainTex"));
		array[array.Length - 1] = val;
		((Renderer)componentInChildren).sharedMaterials = array;
		AkSoundEngine.PostEvent("Play_OBJ_metalskin_end_01", ((Component)((PassiveItem)this).Owner).gameObject);
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)obj).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(PreCollision));
		if (Object.op_Implicit((Object)(object)((Component)obj).gameObject.GetComponentInChildren<MajorBreakable>()))
		{
			((MonoBehaviour)this).StartCoroutine(KillTime(((Component)obj).gameObject.GetComponentInChildren<MajorBreakable>()));
		}
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
		return new _003CKillTime_003Ed__6(0)
		{
			_003C_003E4__this = this,
			breaka = breaka
		};
	}
}
