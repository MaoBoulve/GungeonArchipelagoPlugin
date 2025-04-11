using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class Prescription : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CExplosiveDiarrhea_003Ed__27 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController user;

		public Prescription _003C_003E4__this;

		private int _003Ci_003E5__1;

		private SpawnObjectPlayerItem _003Ccomponent3_003E5__2;

		private GameObject _003CgameObject3_003E5__3;

		private GameObject _003CgameObject4_003E5__4;

		private tk2dBaseSprite _003Ccomponent4_003E5__5;

		private bool _003Cflag6_003E5__6;

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
		public _003CExplosiveDiarrhea_003Ed__27(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Ccomponent3_003E5__2 = null;
			_003CgameObject3_003E5__3 = null;
			_003CgameObject4_003E5__4 = null;
			_003Ccomponent4_003E5__5 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.Notify(null, "Explosive Diarrhea");
				_003Ci_003E5__1 = 0;
				goto IL_0140;
			case 1:
				_003C_003E1__state = -1;
				_003Ccomponent3_003E5__2 = null;
				_003CgameObject3_003E5__3 = null;
				_003CgameObject4_003E5__4 = null;
				_003Ccomponent4_003E5__5 = null;
				_003Ci_003E5__1++;
				goto IL_0140;
			case 2:
				{
					_003C_003E1__state = -1;
					return false;
				}
				IL_0140:
				if (_003Ci_003E5__1 < 5)
				{
					_003Ccomponent3_003E5__2 = ((Component)PickupObjectDatabase.GetById(108)).GetComponent<SpawnObjectPlayerItem>();
					_003CgameObject3_003E5__3 = _003Ccomponent3_003E5__2.objectToSpawn.gameObject;
					_003CgameObject4_003E5__4 = Object.Instantiate<GameObject>(_003CgameObject3_003E5__3, Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), Quaternion.identity);
					_003Ccomponent4_003E5__5 = _003CgameObject4_003E5__4.GetComponent<tk2dBaseSprite>();
					_003Cflag6_003E5__6 = Object.op_Implicit((Object)(object)_003Ccomponent4_003E5__5);
					if (_003Cflag6_003E5__6)
					{
						_003Ccomponent4_003E5__5.PlaceAtPositionByAnchor(Vector2.op_Implicit(((BraveBehaviour)user).specRigidbody.UnitCenter), (Anchor)4);
					}
					_003C_003E2__current = (object)new WaitForSeconds(1f);
					_003C_003E1__state = 1;
					return true;
				}
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

	public static List<string> pillEffectPool = new List<string> { "badgas", "badtrip", "ballsofsteel", "blanksarekey", "explosivediarrhea" };

	public static bool PillPoolsAssigned = false;

	public static string BlueBluePillEffect;

	public static string BlueWhitePillEffect;

	public static string OrangeOrangePillEffect;

	public static string WhiteWhitePillEffect;

	public static string RedWhiteSpeckledPillEffect;

	public static string RedWhitePillEffect;

	public static string GreenBluePillEffect;

	public static string OrangeYellowPillEffect;

	public static string WhiteOrangeSpeckledPillEffect;

	public static string LightBlueWhitePillEffect;

	public static string YellowBlackPillEffect;

	public static string BlackWhitePillEffect;

	public static string YellowWhitePillEffect;

	private GameActorHealthEffect poisonEffect = ((Component)Game.Items["irradiated_lead"]).GetComponent<BulletStatusEffectItem>().HealthModifierEffect;

	public static void Init()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		string text = "Prescription";
		string text2 = "NevernamedsItems/Resources/ringofoddlyspecificbenefits_icon";
		GameObject val = new GameObject(text);
		Prescription prescription = val.AddComponent<Prescription>();
		ItemBuilder.AddSpriteToObject(text, text2, val, (Assembly)null);
		string text3 = "Ultimate";
		string text4 = "Apparently being rich = being cool these days.\n\nMaybe you should write a song about how rich you are.";
		ItemBuilder.SetupItem((PickupObject)(object)prescription, text3, text4, "nn");
		((PickupObject)prescription).quality = (ItemQuality)(-100);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		if (!base.m_pickedUpThisRun && !PillPoolsAssigned)
		{
			AssignPillPools();
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		((PassiveItem)this).OnDestroy();
	}

	private void AssignPillPools()
	{
		BlueBluePillEffect = BraveUtility.RandomElement<string>(pillEffectPool);
		pillEffectPool.Remove(BlueBluePillEffect);
		PillPoolsAssigned = true;
	}

	private void OnPillUse(PlayerController user, string pillEffect)
	{
		switch (pillEffect)
		{
		case "badgas":
			BadGas(user);
			break;
		case "badtrip":
			BadTrip(user);
			break;
		case "ballsofsteel":
			BallsOfSteel(user);
			break;
		case "blanksarekey":
			BlanksAreKey(user);
			break;
		}
	}

	private void Notify(string header, string text)
	{
		tk2dBaseSprite notificationObjectSprite = GameUIRoot.Instance.notificationController.notificationObjectSprite;
		GameUIRoot.Instance.notificationController.DoCustomNotification(header, text, notificationObjectSprite.Collection, notificationObjectSprite.spriteId, (NotificationColor)2, false, true);
	}

	public void BadGas(PlayerController user)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		PlayerController owner = ((PassiveItem)this).Owner;
		GameObject val = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX_Ghost");
		AkSoundEngine.PostEvent("Play_OBJ_silenceblank_small_01", ((Component)this).gameObject);
		GameObject val2 = new GameObject("silencer");
		SilencerInstance val3 = val2.AddComponent<SilencerInstance>();
		float num = 0.25f;
		val3.TriggerSilencer(((BraveBehaviour)user).specRigidbody.UnitCenter, 25f, 5f, val, 0f, 3f, 3f, 3f, 250f, 5f, num, owner, false, false);
		user.CurrentRoom.ApplyActionToNearbyEnemies(((GameActor)user).CenterPosition, 30f, (Action<AIActor, float>)delegate(AIActor enemy, float dist)
		{
			((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)poisonEffect, 1f, (Projectile)null);
		});
		Notify(null, "Bad Gas");
	}

	public void BadTrip(PlayerController user)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		if ((int)user.characterIdentity == 2)
		{
			if (((BraveBehaviour)user).healthHaver.GetCurrentHealth() > 1f)
			{
				((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyDamage(1f, Vector2.zero, "Pills", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			}
			else if (((BraveBehaviour)user).healthHaver.GetCurrentHealth() == 1f)
			{
				((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyDamage(0.5f, Vector2.zero, "Pills", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			}
		}
		else if (((BraveBehaviour)user).healthHaver.Armor > 1f)
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyDamage(0.5f, Vector2.zero, "Pills", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
		}
		Notify(null, "Bad Trip");
	}

	public void BallsOfSteel(PlayerController user)
	{
		LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
		LootEngine.GivePrefabToPlayer(((Component)PickupObjectDatabase.GetById(120)).gameObject, user);
		Notify(null, "Balls of Steel");
	}

	public void BlanksAreKey(PlayerController user)
	{
		int blanks = user.Blanks;
		int keyBullets = user.carriedConsumables.KeyBullets;
		user.Blanks = keyBullets;
		user.carriedConsumables.KeyBullets = blanks;
		Notify(null, "Blanks are Key");
	}

	public IEnumerator ExplosiveDiarrhea(PlayerController user)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CExplosiveDiarrhea_003Ed__27(0)
		{
			_003C_003E4__this = this,
			user = user
		};
	}
}
