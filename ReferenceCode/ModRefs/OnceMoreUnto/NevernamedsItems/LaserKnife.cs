using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class LaserKnife : PlayerItem
{
	[CompilerGenerated]
	private sealed class _003CHandleEnemyDeath_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor target;

		public Vector2 motionDirection;

		private CombineEvaporateEffect _003CorigEvap_003E5__1;

		private Transform _003CcopyTransform_003E5__2;

		private tk2dSprite _003CcopySprite_003E5__3;

		private GameObject _003CgameObject_003E5__4;

		private ParticleSystem _003Ccomponent_003E5__5;

		private float _003Celapsed_003E5__6;

		private float _003Cduration_003E5__7;

		private int _003CemId_003E5__8;

		private Bounds _003Cbounds_003E5__9;

		private ShapeModule _003CshapeVar_003E5__10;

		private float _003Ct_003E5__11;

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
		public _003CHandleEnemyDeath_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			_003CorigEvap_003E5__1 = null;
			_003CcopyTransform_003E5__2 = null;
			_003CcopySprite_003E5__3 = null;
			_003CgameObject_003E5__4 = null;
			_003Ccomponent_003E5__5 = null;
			_003CshapeVar_003E5__10 = default(ShapeModule);
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				ref CombineEvaporateEffect reference = ref _003CorigEvap_003E5__1;
				PickupObject byId = PickupObjectDatabase.GetById(519);
				reference = ((Component)((Gun)((byId is Gun) ? byId : null)).alternateVolley.projectiles[0].projectiles[0]).GetComponent<CombineEvaporateEffect>();
				target.EraseFromExistenceWithRewards(false);
				_003CcopyTransform_003E5__2 = CreateEmptySprite(target);
				_003CcopySprite_003E5__3 = ((Component)_003CcopyTransform_003E5__2).GetComponentInChildren<tk2dSprite>();
				_003CgameObject_003E5__4 = Object.Instantiate<GameObject>(_003CorigEvap_003E5__1.ParticleSystemToSpawn, Vector2Extensions.ToVector3ZisY(((tk2dBaseSprite)_003CcopySprite_003E5__3).WorldCenter, 0f), Quaternion.identity);
				_003Ccomponent_003E5__5 = _003CgameObject_003E5__4.GetComponent<ParticleSystem>();
				_003CgameObject_003E5__4.transform.parent = _003CcopyTransform_003E5__2;
				if (Object.op_Implicit((Object)(object)_003CcopySprite_003E5__3))
				{
					_003CgameObject_003E5__4.transform.position = Vector2.op_Implicit(((tk2dBaseSprite)_003CcopySprite_003E5__3).WorldCenter);
					_003Cbounds_003E5__9 = ((tk2dBaseSprite)_003CcopySprite_003E5__3).GetBounds();
					_003CshapeVar_003E5__10 = _003Ccomponent_003E5__5.shape;
					((ShapeModule)(ref _003CshapeVar_003E5__10)).scale = new Vector3(((Bounds)(ref _003Cbounds_003E5__9)).extents.x * 2f, ((Bounds)(ref _003Cbounds_003E5__9)).extents.y * 2f, 0.125f);
					_003CshapeVar_003E5__10 = default(ShapeModule);
				}
				_003Celapsed_003E5__6 = 0f;
				_003Cduration_003E5__7 = 2.5f;
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.DisableKeyword("TINTING_OFF");
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.EnableKeyword("TINTING_ON");
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.DisableKeyword("EMISSIVE_OFF");
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.EnableKeyword("EMISSIVE_ON");
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.DisableKeyword("BRIGHTNESS_CLAMP_ON");
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.EnableKeyword("BRIGHTNESS_CLAMP_OFF");
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.SetFloat("_EmissiveThresholdSensitivity", 5f);
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.SetFloat("_EmissiveColorPower", 1f);
				_003CemId_003E5__8 = Shader.PropertyToID("_EmissivePower");
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__6 < _003Cduration_003E5__7)
			{
				_003Celapsed_003E5__6 += BraveTime.DeltaTime;
				_003Ct_003E5__11 = _003Celapsed_003E5__6 / _003Cduration_003E5__7;
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.SetFloat(_003CemId_003E5__8, Mathf.Lerp(1f, 10f, _003Ct_003E5__11));
				((BraveBehaviour)_003CcopySprite_003E5__3).renderer.material.SetFloat("_BurnAmount", _003Ct_003E5__11);
				Transform obj = _003CcopyTransform_003E5__2;
				Vector3 position = obj.position;
				Vector3 val = Vector2Extensions.ToVector3ZisY(motionDirection, 0f);
				obj.position = position + ((Vector3)(ref val)).normalized * BraveTime.DeltaTime * 1f;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			Object.Destroy((Object)(object)((Component)_003CcopyTransform_003E5__2).gameObject);
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
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<LaserKnife>("Laser Knife", "He Couldn't See The Stars", "Vaporises the nearest enemy. \n\nA standard issue military pocket plasma blade for hand-to-hand combat.", "laserknife_improved", assetbundle: true);
		PlayerItem val = (PlayerItem)(object)((obj is PlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType(val, (CooldownType)1, 600f);
		((PickupObject)val).quality = (ItemQuality)2;
	}

	public override void DoEffect(PlayerController user)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(((GameActor)user).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
		Object.Instantiate<GameObject>(SharedVFX.LaserSlashUndertale, Vector2.op_Implicit(((BraveBehaviour)nearestEnemyToPosition).sprite.WorldCenter), Quaternion.identity);
		if (Object.op_Implicit((Object)(object)nearestEnemyToPosition) && (!Object.op_Implicit((Object)(object)((BraveBehaviour)nearestEnemyToPosition).healthHaver) || !((BraveBehaviour)nearestEnemyToPosition).healthHaver.IsBoss))
		{
			((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(HandleEnemyDeath(nearestEnemyToPosition, MathsAndLogicHelper.GetVectorToNearestEnemy(((GameActor)user).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null)));
		}
		else if (Object.op_Implicit((Object)(object)nearestEnemyToPosition) && Object.op_Implicit((Object)(object)((BraveBehaviour)nearestEnemyToPosition).healthHaver) && ((BraveBehaviour)nearestEnemyToPosition).healthHaver.IsBoss)
		{
			((BraveBehaviour)nearestEnemyToPosition).healthHaver.ApplyDamage(100f, Vector2.zero, "Laser Knife", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, true);
		}
		AkSoundEngine.PostEvent("Play_WPN_bountyhunterarm_shot_03", ((Component)user).gameObject);
	}

	public static IEnumerator HandleEnemyDeath(AIActor target, Vector2 motionDirection)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleEnemyDeath_003Ed__2(0)
		{
			target = target,
			motionDirection = motionDirection
		};
	}

	private static Transform CreateEmptySprite(AIActor target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("suck image");
		val.layer = ((Component)target).gameObject.layer;
		tk2dSprite val2 = val.AddComponent<tk2dSprite>();
		val.transform.parent = SpawnManager.Instance.VFX;
		((tk2dBaseSprite)val2).SetSprite(((BraveBehaviour)target).sprite.Collection, ((BraveBehaviour)target).sprite.spriteId);
		((BraveBehaviour)val2).transform.position = ((BraveBehaviour)((BraveBehaviour)target).sprite).transform.position;
		GameObject val3 = new GameObject("image parent");
		val3.transform.position = Vector2.op_Implicit(((tk2dBaseSprite)val2).WorldCenter);
		((BraveBehaviour)val2).transform.parent = val3.transform;
		((tk2dBaseSprite)val2).usesOverrideMaterial = true;
		if ((Object)(object)target.optionalPalette != (Object)null)
		{
			((BraveBehaviour)val2).renderer.material.SetTexture("_PaletteTex", (Texture)(object)target.optionalPalette);
		}
		return val3.transform;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)MathsAndLogicHelper.GetNearestEnemyToPosition(((GameActor)user).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null) != (Object)null && Vector2.Distance(Vector2.op_Implicit(MathsAndLogicHelper.GetNearestEnemyToPosition(((GameActor)user).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null).Position), ((GameActor)user).CenterPosition) <= 5f)
		{
			return true;
		}
		return false;
	}
}
