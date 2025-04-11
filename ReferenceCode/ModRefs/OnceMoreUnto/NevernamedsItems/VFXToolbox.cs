using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class VFXToolbox
{
	[CompilerGenerated]
	private sealed class _003CDoScreenGlitch_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float seconds;

		private Material _003CglitchPass_003E5__1;

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
		public _003CDoScreenGlitch_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CglitchPass_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CglitchPass_003E5__1 = new Material(Shader.Find("Brave/Internal/GlitchUnlit"));
				Pixelator.Instance.RegisterAdditionalRenderPass(_003CglitchPass_003E5__1);
				_003C_003E2__current = (object)new WaitForSeconds(seconds);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				Pixelator.Instance.DeregisterAdditionalRenderPass(_003CglitchPass_003E5__1);
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
	private sealed class _003CHandleDamageNumberCR_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 startWorldPosition;

		public float worldFloorHeight;

		public dfLabel damageLabel;

		private float _003Celapsed_003E5__1;

		private float _003Cduration_003E5__2;

		private float _003CholdTime_003E5__3;

		private Camera _003CmainCam_003E5__4;

		private Vector3 _003CworldPosition_003E5__5;

		private Vector3 _003ClastVelocity_003E5__6;

		private float _003Cdt_003E5__7;

		private float _003Ct_003E5__8;

		private Vector3 _003Cvector_003E5__9;

		private float _003Cnum_003E5__10;

		private float _003Cnum2_003E5__11;

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
		public _003CHandleDamageNumberCR_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CmainCam_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Celapsed_003E5__1 = 0f;
				_003Cduration_003E5__2 = 1.5f;
				_003CholdTime_003E5__3 = 0f;
				_003CmainCam_003E5__4 = GameManager.Instance.MainCameraController.Camera;
				_003CworldPosition_003E5__5 = startWorldPosition;
				_003ClastVelocity_003E5__6 = new Vector3(Mathf.Lerp(-8f, 8f, Random.value), Random.Range(15f, 25f), 0f);
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__1 < _003Cduration_003E5__2)
			{
				_003Cdt_003E5__7 = BraveTime.DeltaTime;
				_003Celapsed_003E5__1 += _003Cdt_003E5__7;
				if (!GameManager.Instance.IsPaused)
				{
					if (_003Celapsed_003E5__1 > _003CholdTime_003E5__3)
					{
						_003ClastVelocity_003E5__6 += new Vector3(0f, -50f, 0f) * _003Cdt_003E5__7;
						_003Cvector_003E5__9 = _003ClastVelocity_003E5__6 * _003Cdt_003E5__7 + _003CworldPosition_003E5__5;
						if (_003Cvector_003E5__9.y < worldFloorHeight)
						{
							_003Cnum_003E5__10 = worldFloorHeight - _003Cvector_003E5__9.y;
							_003Cnum2_003E5__11 = worldFloorHeight + _003Cnum_003E5__10;
							_003Cvector_003E5__9.y = _003Cnum2_003E5__11 * 0.5f;
							_003ClastVelocity_003E5__6.y *= -0.5f;
						}
						_003CworldPosition_003E5__5 = _003Cvector_003E5__9;
						((Component)damageLabel).transform.position = Vector3Extensions.WithZ(dfFollowObject.ConvertWorldSpaces(_003CworldPosition_003E5__5, _003CmainCam_003E5__4, GameUIRoot.Instance.Manager.RenderCamera), 0f);
					}
					_003Ct_003E5__8 = _003Celapsed_003E5__1 / _003Cduration_003E5__2;
					((dfControl)damageLabel).Opacity = 1f - _003Ct_003E5__8;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			((Component)damageLabel).gameObject.SetActive(false);
			Object.Destroy((Object)(object)((Component)damageLabel).gameObject, 1f);
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

	[CompilerGenerated]
	private sealed class _003CHandleDamageNumberRiseCR_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 startWorldPosition;

		public float worldFloorHeight;

		public dfLabel damageLabel;

		private float _003Celapsed_003E5__1;

		private float _003Cduration_003E5__2;

		private float _003CholdTime_003E5__3;

		private Camera _003CmainCam_003E5__4;

		private Vector3 _003CworldPosition_003E5__5;

		private Vector3 _003ClastVelocity_003E5__6;

		private float _003Cdt_003E5__7;

		private float _003Ct_003E5__8;

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
		public _003CHandleDamageNumberRiseCR_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CmainCam_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Celapsed_003E5__1 = 0f;
				_003Cduration_003E5__2 = 1.5f;
				_003CholdTime_003E5__3 = 0f;
				_003CmainCam_003E5__4 = GameManager.Instance.MainCameraController.Camera;
				_003CworldPosition_003E5__5 = startWorldPosition;
				_003ClastVelocity_003E5__6 = new Vector3(Mathf.Lerp(-8f, 8f, Random.value), Random.Range(15f, 25f), 0f);
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__1 < _003Cduration_003E5__2)
			{
				_003Cdt_003E5__7 = BraveTime.DeltaTime;
				_003Celapsed_003E5__1 += _003Cdt_003E5__7;
				if (!GameManager.Instance.IsPaused)
				{
					if (_003Celapsed_003E5__1 > _003CholdTime_003E5__3)
					{
						((Component)damageLabel).transform.position = Vector3Extensions.WithZ(dfFollowObject.ConvertWorldSpaces(new Vector3(_003CworldPosition_003E5__5.x, _003CworldPosition_003E5__5.y + _003Celapsed_003E5__1 / _003Cduration_003E5__2), _003CmainCam_003E5__4, GameUIRoot.Instance.Manager.RenderCamera), 0f);
					}
					_003Ct_003E5__8 = _003Celapsed_003E5__1 / _003Cduration_003E5__2;
					((dfControl)damageLabel).Opacity = 1f - _003Ct_003E5__8;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			((Component)damageLabel).gameObject.SetActive(false);
			Object.Destroy((Object)(object)((Component)damageLabel).gameObject, 1f);
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

	public static GameObject RenderLaserSight(Vector2 position, float length, float width, float angle, bool alterColour = false, Color? colour = null)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnVFX(SharedVFX.LaserSight, Vector2.op_Implicit(position), Quaternion.Euler(0f, 0f, angle));
		tk2dTiledSprite component = val.GetComponent<tk2dTiledSprite>();
		float num = 1f;
		if (width != -1f)
		{
			num = width;
		}
		component.dimensions = new Vector2(length, num);
		if (alterColour && colour.HasValue)
		{
			((tk2dBaseSprite)component).usesOverrideMaterial = true;
			((BraveBehaviour)((BraveBehaviour)component).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			((BraveBehaviour)((BraveBehaviour)component).sprite).renderer.material.SetColor("_OverrideColor", colour.Value);
			((BraveBehaviour)((BraveBehaviour)component).sprite).renderer.material.SetColor("_EmissiveColor", colour.Value);
			((BraveBehaviour)((BraveBehaviour)component).sprite).renderer.material.SetFloat("_EmissivePower", 100f);
			((BraveBehaviour)((BraveBehaviour)component).sprite).renderer.material.SetFloat("_EmissiveColorPower", 1.55f);
		}
		return val;
	}

	public static void GlitchScreenForSeconds(float seconds)
	{
		((MonoBehaviour)GameManager.Instance).StartCoroutine(DoScreenGlitch(seconds));
	}

	private static IEnumerator DoScreenGlitch(float seconds)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoScreenGlitch_003Ed__2(0)
		{
			seconds = seconds
		};
	}

	public static void DoRisingStringFade(string text, Vector2 point, Color colour, float heightOffGround = 3f, float opacity = 1f)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (GameObject)Object.Instantiate(BraveResources.Load("DamagePopupLabel", ".prefab"), ((BraveBehaviour)GameUIRoot.Instance).transform);
		dfLabel component = val.GetComponent<dfLabel>();
		((Component)component).gameObject.SetActive(true);
		component.Text = text;
		((dfControl)component).Color = Color32.op_Implicit(colour);
		((dfControl)component).Opacity = opacity;
		component.TextAlignment = (TextAlignment)1;
		((dfControl)component).Anchor = (dfAnchorStyle)2;
		((dfControl)component).Pivot = (dfPivotPoint)7;
		((dfControl)component).Invalidate();
		((Component)component).transform.position = Vector3Extensions.WithZ(dfFollowObject.ConvertWorldSpaces(Vector2.op_Implicit(point), GameManager.Instance.MainCameraController.Camera, GameManager.Instance.MainCameraController.Camera), 0f);
		((Component)component).transform.position = dfVectorExtensions.QuantizeFloor(((Component)component).transform.position, ((dfControl)component).PixelsToUnits() / (Pixelator.Instance.ScaleTileScale / Pixelator.Instance.CurrentTileScale));
		((MonoBehaviour)component).StartCoroutine(HandleDamageNumberRiseCR(Vector2.op_Implicit(point), point.y - heightOffGround, component));
	}

	private static IEnumerator HandleDamageNumberRiseCR(Vector3 startWorldPosition, float worldFloorHeight, dfLabel damageLabel)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDamageNumberRiseCR_003Ed__4(0)
		{
			startWorldPosition = startWorldPosition,
			worldFloorHeight = worldFloorHeight,
			damageLabel = damageLabel
		};
	}

	public static void DoStringSquirt(string text, Vector2 point, Color colour, float heightOffGround = 3f, float opacity = 1f)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (GameObject)Object.Instantiate(BraveResources.Load("DamagePopupLabel", ".prefab"), ((BraveBehaviour)GameUIRoot.Instance).transform);
		dfLabel component = val.GetComponent<dfLabel>();
		((Component)component).gameObject.SetActive(true);
		component.Text = text;
		((dfControl)component).Color = Color32.op_Implicit(colour);
		((dfControl)component).Opacity = opacity;
		component.TextAlignment = (TextAlignment)1;
		((Component)component).transform.position = Vector2.op_Implicit(point);
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(((Component)component).transform.position.x - (((dfControl)component).GetCenter().x - ((Component)component).transform.position.x), point.y);
		((Component)component).transform.position = dfVectorExtensions.QuantizeFloor(((Component)component).transform.position, ((dfControl)component).PixelsToUnits() / (Pixelator.Instance.ScaleTileScale / Pixelator.Instance.CurrentTileScale));
		((MonoBehaviour)component).StartCoroutine(HandleDamageNumberCR(Vector2.op_Implicit(val2), val2.y - heightOffGround, component));
	}

	private static IEnumerator HandleDamageNumberCR(Vector3 startWorldPosition, float worldFloorHeight, dfLabel damageLabel)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleDamageNumberCR_003Ed__6(0)
		{
			startWorldPosition = startWorldPosition,
			worldFloorHeight = worldFloorHeight,
			damageLabel = damageLabel
		};
	}

	public static GameObject CreateVFXBundle(string name, IntVector2 Dimensions, Anchor anchor, bool usesZHeight, float zHeightOffset, float emissivePower = -1f, Color? emissiveColour = null, bool persist = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		VFXObject val2 = new VFXObject();
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		Object.DontDestroyOnLoad((Object)(object)val);
		tk2dSpriteCollectionData vFXCollection = Initialisation.VFXCollection;
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		tk2dSpriteAnimation vfxAnimationCollection = Initialisation.vfxAnimationCollection;
		orAddComponent2.Library = vfxAnimationCollection;
		((tk2dBaseSprite)orAddComponent).collection = vFXCollection;
		Vector3[] colliderVertices = (Vector3[])(object)new Vector3[2]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3((float)(Dimensions.x / 16), (float)(Dimensions.y / 16), 0f)
		};
		tk2dSpriteAnimationClip clipByName = orAddComponent2.GetClipByName(name);
		List<tk2dSpriteDefinition> list = new List<tk2dSpriteDefinition>();
		tk2dSpriteAnimationFrame[] frames = clipByName.frames;
		foreach (tk2dSpriteAnimationFrame val3 in frames)
		{
			list.Add(vFXCollection.spriteDefinitions[val3.spriteId]);
		}
		foreach (tk2dSpriteDefinition item in list)
		{
			GunTools.ConstructOffsetsFromAnchor(item, anchor, (Vector2?)null, false, true);
			item.colliderVertices = colliderVertices;
			if (emissivePower > 0f)
			{
				item.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				item.material.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				item.material.SetColor("_EmissiveColor", emissiveColour.Value);
			}
			if (emissivePower > 0f)
			{
				item.materialInst.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				item.materialInst.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				item.materialInst.SetColor("_EmissiveColor", emissiveColour.Value);
			}
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetFloat("_EmissiveColorPower", emissivePower);
		}
		if (emissiveColour.HasValue)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetColor("_EmissiveColor", emissiveColour.Value);
		}
		if (!persist)
		{
			SpriteAnimatorKiller val4 = ((Component)orAddComponent2).gameObject.AddComponent<SpriteAnimatorKiller>();
			val4.fadeTime = -1f;
			val4.animator = orAddComponent2;
			val4.delayDestructionTime = -1f;
		}
		orAddComponent2.playAutomatically = true;
		orAddComponent2.DefaultClipId = orAddComponent2.GetClipIdByName(name);
		val2.attached = true;
		val2.persistsOnDeath = false;
		val2.usesZHeight = usesZHeight;
		val2.zHeight = zHeightOffset;
		val2.alignment = (VFXAlignment)1;
		val2.destructible = false;
		val2.effect = val;
		return val;
	}

	public static GameObject CreateVFXBundle(string name, bool usesZHeight, float zHeightOffset, float emissivePower = -1f, float emissiveColourPower = -1f, Color? emissiveColour = null, bool persist = false, tk2dSpriteCollectionData overrideCollection = null)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		VFXObject val2 = new VFXObject();
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		Object.DontDestroyOnLoad((Object)(object)val);
		tk2dSpriteCollectionData val3 = (((Object)(object)overrideCollection != (Object)null) ? overrideCollection : Initialisation.VFXCollection);
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		tk2dSpriteAnimation vfxAnimationCollection = Initialisation.vfxAnimationCollection;
		orAddComponent2.Library = vfxAnimationCollection;
		((tk2dBaseSprite)orAddComponent).collection = val3;
		tk2dSpriteAnimationClip clipByName = orAddComponent2.GetClipByName(name);
		List<tk2dSpriteDefinition> list = new List<tk2dSpriteDefinition>();
		tk2dSpriteAnimationFrame[] frames = clipByName.frames;
		foreach (tk2dSpriteAnimationFrame val4 in frames)
		{
			list.Add(val3.spriteDefinitions[val4.spriteId]);
		}
		((tk2dBaseSprite)orAddComponent).usesOverrideMaterial = true;
		((BraveBehaviour)orAddComponent).renderer.material.shader = ShaderCache.Acquire("tk2d/CutoutVertexColorTintableTilted");
		if (emissivePower > 0f)
		{
			Material val5 = new Material(((BraveBehaviour)((BraveBehaviour)EnemyDatabase.GetOrLoadByName("GunNut")).sprite).renderer.material);
			val5.mainTexture = ((BraveBehaviour)orAddComponent).renderer.material.mainTexture;
			val5.SetColor("_EmissiveColor", emissiveColour.Value);
			val5.SetFloat("_EmissiveColorPower", emissiveColourPower);
			val5.SetFloat("_EmissivePower", emissivePower);
			((BraveBehaviour)orAddComponent).renderer.material = val5;
		}
		if (!persist)
		{
			SpriteAnimatorKiller val6 = ((Component)orAddComponent2).gameObject.AddComponent<SpriteAnimatorKiller>();
			val6.fadeTime = -1f;
			val6.animator = orAddComponent2;
			val6.delayDestructionTime = -1f;
		}
		orAddComponent2.playAutomatically = true;
		orAddComponent2.DefaultClipId = orAddComponent2.GetClipIdByName(name);
		val2.attached = false;
		val2.persistsOnDeath = false;
		val2.usesZHeight = usesZHeight;
		val2.zHeight = zHeightOffset;
		val2.alignment = (VFXAlignment)1;
		val2.destructible = false;
		val2.effect = val;
		val2.orphaned = true;
		return val;
	}

	public static VFXPool CreateVFXPoolBundle(string name, bool usesZHeight, float zHeightOffset, VFXAlignment alignment = 1, float emissivePower = -1f, Color? emissiveColour = null, bool persist = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		VFXPool val2 = new VFXPool();
		val2.type = (VFXPoolType)1;
		VFXComplex val3 = new VFXComplex();
		VFXObject val4 = new VFXObject();
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		Object.DontDestroyOnLoad((Object)(object)val);
		tk2dSpriteCollectionData vFXCollection = Initialisation.VFXCollection;
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		tk2dSpriteAnimation vfxAnimationCollection = Initialisation.vfxAnimationCollection;
		orAddComponent2.Library = vfxAnimationCollection;
		if (emissivePower > 0f)
		{
			((tk2dBaseSprite)orAddComponent).usesOverrideMaterial = true;
			Material val5 = new Material(((BraveBehaviour)((BraveBehaviour)EnemyDatabase.GetOrLoadByName("GunNut")).sprite).renderer.material);
			val5.mainTexture = ((BraveBehaviour)orAddComponent).renderer.material.mainTexture;
			val5.SetColor("_EmissiveColor", emissiveColour.Value);
			val5.SetFloat("_EmissiveColorPower", emissivePower);
			val5.SetFloat("_EmissivePower", emissivePower);
			((BraveBehaviour)orAddComponent).renderer.material = val5;
		}
		if (!persist)
		{
			SpriteAnimatorKiller val6 = ((Component)orAddComponent2).gameObject.AddComponent<SpriteAnimatorKiller>();
			val6.fadeTime = -1f;
			val6.animator = orAddComponent2;
			val6.delayDestructionTime = -1f;
		}
		orAddComponent2.playAutomatically = true;
		orAddComponent2.DefaultClipId = orAddComponent2.GetClipIdByName(name);
		val4.attached = true;
		val4.persistsOnDeath = persist;
		val4.usesZHeight = usesZHeight;
		val4.zHeight = zHeightOffset;
		val4.alignment = alignment;
		val4.destructible = false;
		val4.effect = val;
		val3.effects = (VFXObject[])(object)new VFXObject[1] { val4 };
		val2.effects = (VFXComplex[])(object)new VFXComplex[1] { val3 };
		return val2;
	}

	public static GameObject CreateVFX(string name, List<string> spritePaths, int fps, IntVector2 Dimensions, Anchor anchor, bool usesZHeight, float zHeightOffset, float emissivePower = -1f, Color? emissiveColour = null, WrapMode wrap = 2, bool persist = false, int loopStart = 0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		VFXObject val2 = new VFXObject();
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		Object.DontDestroyOnLoad((Object)(object)val);
		tk2dSpriteCollectionData val3 = SpriteBuilder.ConstructCollection(val, name + "_Collection", false);
		int num = SpriteBuilder.AddSpriteToCollection(spritePaths[0], val3, (Assembly)null);
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		((tk2dBaseSprite)orAddComponent).SetSprite(val3, num);
		tk2dSpriteDefinition currentSpriteDef = ((tk2dBaseSprite)orAddComponent).GetCurrentSpriteDef();
		currentSpriteDef.colliderVertices = (Vector3[])(object)new Vector3[2]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3((float)(Dimensions.x / 16), (float)(Dimensions.y / 16), 0f)
		};
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		tk2dSpriteAnimation orAddComponent3 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimation>(val);
		orAddComponent3.clips = (tk2dSpriteAnimationClip[])(object)new tk2dSpriteAnimationClip[0];
		orAddComponent2.Library = orAddComponent3;
		tk2dSpriteAnimationClip val4 = new tk2dSpriteAnimationClip();
		val4.name = "start";
		val4.frames = (tk2dSpriteAnimationFrame[])(object)new tk2dSpriteAnimationFrame[0];
		val4.fps = fps;
		tk2dSpriteAnimationClip val5 = val4;
		List<tk2dSpriteAnimationFrame> list = new List<tk2dSpriteAnimationFrame>();
		for (int i = 0; i < spritePaths.Count; i++)
		{
			tk2dSpriteCollectionData val6 = val3;
			int num2 = SpriteBuilder.AddSpriteToCollection(spritePaths[i], val6, (Assembly)null);
			tk2dSpriteDefinition val7 = val6.spriteDefinitions[num2];
			GunTools.ConstructOffsetsFromAnchor(val7, anchor, (Vector2?)null, false, true);
			val7.colliderVertices = currentSpriteDef.colliderVertices;
			if (emissivePower > 0f)
			{
				val7.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				val7.material.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				val7.material.SetColor("_EmissiveColor", emissiveColour.Value);
			}
			if (emissivePower > 0f)
			{
				val7.materialInst.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				val7.materialInst.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				val7.materialInst.SetColor("_EmissiveColor", emissiveColour.Value);
			}
			list.Add(new tk2dSpriteAnimationFrame
			{
				spriteId = num2,
				spriteCollection = val6
			});
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetFloat("_EmissiveColorPower", emissivePower);
		}
		if (emissiveColour.HasValue)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetColor("_EmissiveColor", emissiveColour.Value);
		}
		val5.frames = list.ToArray();
		val5.wrapMode = wrap;
		val5.loopStart = loopStart;
		orAddComponent3.clips = orAddComponent3.clips.Concat((IEnumerable<tk2dSpriteAnimationClip>)(object)new tk2dSpriteAnimationClip[1] { val5 }).ToArray();
		if (!persist)
		{
			SpriteAnimatorKiller val8 = ((Component)orAddComponent2).gameObject.AddComponent<SpriteAnimatorKiller>();
			val8.fadeTime = -1f;
			val8.animator = orAddComponent2;
			val8.delayDestructionTime = -1f;
		}
		orAddComponent2.playAutomatically = true;
		orAddComponent2.DefaultClipId = orAddComponent2.GetClipIdByName("start");
		val2.attached = true;
		val2.persistsOnDeath = false;
		val2.usesZHeight = usesZHeight;
		val2.zHeight = zHeightOffset;
		val2.alignment = (VFXAlignment)1;
		val2.destructible = false;
		val2.effect = val;
		return val;
	}

	public static VFXComplex CreateVFXComplex(string name, List<string> spritePaths, int fps, IntVector2 Dimensions, Anchor anchor, bool usesZHeight, float zHeightOffset, bool persist = false, float emissivePower = -1f, Color? emissiveColour = null)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		VFXPool val2 = new VFXPool();
		val2.type = (VFXPoolType)1;
		VFXComplex val3 = new VFXComplex();
		VFXObject val4 = new VFXObject();
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		Object.DontDestroyOnLoad((Object)(object)val);
		tk2dSpriteCollectionData val5 = SpriteBuilder.ConstructCollection(val, name + "_Collection", false);
		int num = SpriteBuilder.AddSpriteToCollection(spritePaths[0], val5, (Assembly)null);
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		((tk2dBaseSprite)orAddComponent).SetSprite(val5, num);
		tk2dSpriteDefinition currentSpriteDef = ((tk2dBaseSprite)orAddComponent).GetCurrentSpriteDef();
		currentSpriteDef.colliderVertices = (Vector3[])(object)new Vector3[2]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3((float)(Dimensions.x / 16), (float)(Dimensions.y / 16), 0f)
		};
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		tk2dSpriteAnimation orAddComponent3 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimation>(val);
		orAddComponent3.clips = (tk2dSpriteAnimationClip[])(object)new tk2dSpriteAnimationClip[0];
		orAddComponent2.Library = orAddComponent3;
		tk2dSpriteAnimationClip val6 = new tk2dSpriteAnimationClip();
		val6.name = "start";
		val6.frames = (tk2dSpriteAnimationFrame[])(object)new tk2dSpriteAnimationFrame[0];
		val6.fps = fps;
		tk2dSpriteAnimationClip val7 = val6;
		List<tk2dSpriteAnimationFrame> list = new List<tk2dSpriteAnimationFrame>();
		for (int i = 0; i < spritePaths.Count; i++)
		{
			tk2dSpriteCollectionData val8 = val5;
			int num2 = SpriteBuilder.AddSpriteToCollection(spritePaths[i], val8, (Assembly)null);
			tk2dSpriteDefinition val9 = val8.spriteDefinitions[num2];
			GunTools.ConstructOffsetsFromAnchor(val9, anchor, (Vector2?)null, false, true);
			val9.colliderVertices = currentSpriteDef.colliderVertices;
			if (emissivePower > 0f)
			{
				val9.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				val9.material.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				val9.material.SetColor("_EmissiveColor", emissiveColour.Value);
			}
			if (emissivePower > 0f)
			{
				val9.materialInst.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				val9.materialInst.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				val9.materialInst.SetColor("_EmissiveColor", emissiveColour.Value);
			}
			list.Add(new tk2dSpriteAnimationFrame
			{
				spriteId = num2,
				spriteCollection = val8
			});
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetFloat("_EmissiveColorPower", emissivePower);
		}
		if (emissiveColour.HasValue)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetColor("_EmissiveColor", emissiveColour.Value);
		}
		val7.frames = list.ToArray();
		val7.wrapMode = (WrapMode)2;
		orAddComponent3.clips = orAddComponent3.clips.Concat((IEnumerable<tk2dSpriteAnimationClip>)(object)new tk2dSpriteAnimationClip[1] { val7 }).ToArray();
		SpriteAnimatorKiller val10 = ((Component)orAddComponent2).gameObject.AddComponent<SpriteAnimatorKiller>();
		val10.fadeTime = -1f;
		val10.animator = orAddComponent2;
		val10.delayDestructionTime = -1f;
		orAddComponent2.playAutomatically = true;
		orAddComponent2.DefaultClipId = orAddComponent2.GetClipIdByName("start");
		val4.attached = true;
		val4.persistsOnDeath = persist;
		val4.usesZHeight = usesZHeight;
		val4.zHeight = zHeightOffset;
		val4.alignment = (VFXAlignment)1;
		val4.destructible = false;
		val4.effect = val;
		val3.effects = (VFXObject[])(object)new VFXObject[1] { val4 };
		val2.effects = (VFXComplex[])(object)new VFXComplex[1] { val3 };
		return val3;
	}

	public static VFXComplex CreateBlankVFXComplex()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		VFXComplex val = new VFXComplex();
		val.effects = (VFXObject[])(object)new VFXObject[0];
		return val;
	}

	public static VFXPool CreateBlankVFXPool()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		VFXPool val = new VFXPool();
		val.type = (VFXPoolType)0;
		VFXComplex[] array = new VFXComplex[1];
		VFXComplex val2 = new VFXComplex();
		val2.effects = (VFXObject[])(object)new VFXObject[1]
		{
			new VFXObject()
		};
		array[0] = val2;
		val.effects = (VFXComplex[])(object)array;
		return val;
	}

	public static VFXPool CreateBlankVFXPool(GameObject effect, bool isDebris = false, bool attached = true)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		VFXPool val;
		VFXComplex val2;
		if (isDebris)
		{
			val = new VFXPool();
			val.type = (VFXPoolType)4;
			VFXPool obj = val;
			VFXComplex[] array = new VFXComplex[1];
			val2 = new VFXComplex();
			val2.effects = (VFXObject[])(object)new VFXObject[1]
			{
				new VFXObject
				{
					effect = effect,
					alignment = (VFXAlignment)0,
					attached = false,
					destructible = false,
					orphaned = true,
					persistsOnDeath = false,
					usesZHeight = false,
					zHeight = 0f
				}
			};
			array[0] = val2;
			obj.effects = (VFXComplex[])(object)array;
			return val;
		}
		val = new VFXPool();
		val.type = (VFXPoolType)4;
		VFXPool obj2 = val;
		VFXComplex[] array2 = new VFXComplex[1];
		val2 = new VFXComplex();
		val2.effects = (VFXObject[])(object)new VFXObject[1]
		{
			new VFXObject
			{
				effect = effect,
				attached = attached
			}
		};
		array2[0] = val2;
		obj2.effects = (VFXComplex[])(object)array2;
		return val;
	}

	public static VFXPool CreateVFXPool(string name, List<string> spritePaths, int fps, IntVector2 Dimensions, Anchor anchor, bool usesZHeight, float zHeightOffset, bool persist = false, VFXAlignment alignment = 1, float emissivePower = -1f, Color? emissiveColour = null, WrapMode wrapmode = 2, int loopStart = 0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		VFXPool val2 = new VFXPool();
		val2.type = (VFXPoolType)1;
		VFXComplex val3 = new VFXComplex();
		VFXObject val4 = new VFXObject();
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		Object.DontDestroyOnLoad((Object)(object)val);
		tk2dSpriteCollectionData val5 = SpriteBuilder.ConstructCollection(val, name + "_Collection", false);
		int num = SpriteBuilder.AddSpriteToCollection(spritePaths[0], val5, (Assembly)null);
		tk2dSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSprite>(val);
		((tk2dBaseSprite)orAddComponent).SetSprite(val5, num);
		tk2dSpriteDefinition currentSpriteDef = ((tk2dBaseSprite)orAddComponent).GetCurrentSpriteDef();
		currentSpriteDef.colliderVertices = (Vector3[])(object)new Vector3[2]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3((float)(Dimensions.x / 16), (float)(Dimensions.y / 16), 0f)
		};
		tk2dSpriteAnimator orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		tk2dSpriteAnimation orAddComponent3 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimation>(val);
		orAddComponent3.clips = (tk2dSpriteAnimationClip[])(object)new tk2dSpriteAnimationClip[0];
		orAddComponent2.Library = orAddComponent3;
		tk2dSpriteAnimationClip val6 = new tk2dSpriteAnimationClip();
		val6.name = "start";
		val6.frames = (tk2dSpriteAnimationFrame[])(object)new tk2dSpriteAnimationFrame[0];
		val6.fps = fps;
		tk2dSpriteAnimationClip val7 = val6;
		List<tk2dSpriteAnimationFrame> list = new List<tk2dSpriteAnimationFrame>();
		for (int i = 0; i < spritePaths.Count; i++)
		{
			tk2dSpriteCollectionData val8 = val5;
			int num2 = SpriteBuilder.AddSpriteToCollection(spritePaths[i], val8, (Assembly)null);
			tk2dSpriteDefinition val9 = val8.spriteDefinitions[num2];
			GunTools.ConstructOffsetsFromAnchor(val9, anchor, (Vector2?)null, false, true);
			val9.colliderVertices = currentSpriteDef.colliderVertices;
			if (emissivePower > 0f)
			{
				val9.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				val9.material.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				val9.material.SetColor("_EmissiveColor", emissiveColour.Value);
			}
			if (emissivePower > 0f)
			{
				val9.materialInst.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
			}
			if (emissivePower > 0f)
			{
				val9.materialInst.SetFloat("_EmissiveColorPower", emissivePower);
			}
			if (emissiveColour.HasValue)
			{
				val9.materialInst.SetColor("_EmissiveColor", emissiveColour.Value);
			}
			list.Add(new tk2dSpriteAnimationFrame
			{
				spriteId = num2,
				spriteCollection = val8
			});
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTintableTiltedCutoutEmissive");
		}
		if (emissivePower > 0f)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetFloat("_EmissiveColorPower", emissivePower);
		}
		if (emissiveColour.HasValue)
		{
			((BraveBehaviour)orAddComponent).renderer.material.SetColor("_EmissiveColor", emissiveColour.Value);
		}
		val7.frames = list.ToArray();
		val7.wrapMode = wrapmode;
		val7.loopStart = loopStart;
		orAddComponent3.clips = orAddComponent3.clips.Concat((IEnumerable<tk2dSpriteAnimationClip>)(object)new tk2dSpriteAnimationClip[1] { val7 }).ToArray();
		if (!persist)
		{
			SpriteAnimatorKiller val10 = ((Component)orAddComponent2).gameObject.AddComponent<SpriteAnimatorKiller>();
			val10.fadeTime = -1f;
			val10.animator = orAddComponent2;
			val10.delayDestructionTime = -1f;
		}
		orAddComponent2.playAutomatically = true;
		orAddComponent2.DefaultClipId = orAddComponent2.GetClipIdByName("start");
		val4.attached = true;
		val4.persistsOnDeath = persist;
		val4.usesZHeight = usesZHeight;
		val4.zHeight = zHeightOffset;
		val4.alignment = alignment;
		val4.destructible = false;
		val4.effect = val;
		val3.effects = (VFXObject[])(object)new VFXObject[1] { val4 };
		val2.effects = (VFXComplex[])(object)new VFXComplex[1] { val3 };
		return val2;
	}
}
