using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class RiteOfPassage : GunBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStabby_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public RiteOfPassage _003C_003E4__this;

		private bool _003CignoreArmour_003E5__1;

		private bool _003Cflawless_003E5__2;

		private List<AIActor> _003CactiveEnemies_003E5__3;

		private int _003Ci_003E5__4;

		private AIActor _003Caiactor_003E5__5;

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
		public _003CStabby_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CactiveEnemies_003E5__3 = null;
			_003Caiactor_003E5__5 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03af: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Expected O, but got Unknown
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E4__this.isBusy = true;
				((GunBehaviour)_003C_003E4__this).gun.Play(StabAnim);
				player.inventory.GunLocked.AddOverride("Rite of Passage", (float?)null);
				_003C_003E2__current = (object)new WaitForSeconds(0.625f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (!_003C_003E4__this.ValidForStab(player))
				{
					break;
				}
				_003CignoreArmour_003E5__1 = ((BraveBehaviour)player).healthHaver.Armor > 0f && ((BraveBehaviour)player).healthHaver.currentHealth > 0f;
				_003Cflawless_003E5__2 = player.CurrentRoom != null && !player.CurrentRoom.PlayerHasTakenDamageInThisRoom;
				((BraveBehaviour)player).healthHaver.NextDamageIgnoresArmor = _003CignoreArmour_003E5__1;
				((BraveBehaviour)player).healthHaver.ApplyDamage(0.5f, Vector2.zero, "Rite of Passage", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
				if (!((GunBehaviour)_003C_003E4__this).gun.InfiniteAmmo && ((GunBehaviour)_003C_003E4__this).gun.CanGainAmmo)
				{
					((GunBehaviour)_003C_003E4__this).gun.GainAmmo(100);
				}
				SpawnManager.SpawnVFX(SharedVFX.BloodExplosion, Vector2.op_Implicit(((BraveBehaviour)player).specRigidbody.UnitCenter), Quaternion.identity);
				Pixelator.Instance.FadeToColor(0.5f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)0, (byte)0, (byte)100)), true, 0.1f);
				StickyFrictionManager.Instance.RegisterCustomStickyFriction(0.15f, 1f, false, false);
				if (player.CurrentRoom != null)
				{
					_003CactiveEnemies_003E5__3 = player.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
					if (_003CactiveEnemies_003E5__3 != null)
					{
						_003Ci_003E5__4 = 0;
						while (_003Ci_003E5__4 < _003CactiveEnemies_003E5__3.Count)
						{
							_003Caiactor_003E5__5 = _003CactiveEnemies_003E5__3[_003Ci_003E5__4];
							if (_003Caiactor_003E5__5.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)_003Caiactor_003E5__5).healthHaver))
							{
								((BraveBehaviour)_003Caiactor_003E5__5).healthHaver.ApplyDamage(100f, Vector2.zero, "Rite of Passage", (CoreDamageTypes)2, (DamageCategory)5, false, (PixelCollider)null, false);
								SpawnManager.SpawnVFX(SharedVFX.BloodImpactVFX, Vector2.op_Implicit(((BraveBehaviour)player).specRigidbody.UnitCenter), Quaternion.identity);
								if (Random.value <= 0.5f)
								{
									((GameActor)_003Caiactor_003E5__5).ApplyEffect((GameActorEffect)(object)new GameActorExsanguinationEffect
									{
										duration = 10f
									}, 1f, (Projectile)null);
								}
							}
							_003Caiactor_003E5__5 = null;
							_003Ci_003E5__4++;
						}
					}
					_003CactiveEnemies_003E5__3 = null;
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.1f);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				if (_003Cflawless_003E5__2 && player.CurrentRoom != null)
				{
					player.CurrentRoom.PlayerHasTakenDamageInThisRoom = false;
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.275f);
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				break;
			}
			((GunBehaviour)_003C_003E4__this).gun.PlayIdleAnimation();
			_003C_003E4__this.isBusy = false;
			if ((Object)(object)((GunBehaviour)_003C_003E4__this).gun != (Object)null && ((GunBehaviour)_003C_003E4__this).gun.DefaultModule != null && ((GunBehaviour)_003C_003E4__this).gun.RuntimeModuleData != null && ((GunBehaviour)_003C_003E4__this).gun.RuntimeModuleData.ContainsKey(((GunBehaviour)_003C_003E4__this).gun.DefaultModule) && ((GunBehaviour)_003C_003E4__this).gun.RuntimeModuleData[((GunBehaviour)_003C_003E4__this).gun.DefaultModule].onCooldown)
			{
				((GunBehaviour)_003C_003E4__this).gun.RuntimeModuleData[((GunBehaviour)_003C_003E4__this).gun.DefaultModule].onCooldown = false;
			}
			player.inventory.GunLocked.RemoveOverride("Rite of Passage");
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

	public static string StabAnim;

	public bool isBusy = false;

	public static void Add()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Rite of Passage", "riteofpassage");
		Game.Items.Rename("outdated_gun_mods:rite_of_passage", "nn:rite_of_passage");
		((Component)val).gameObject.AddComponent<RiteOfPassage>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Blood Ritual");
		GunExt.SetLongDescription((PickupObject)(object)val, "Attempting to reload a full clip of this heretical weapon will harm all Gundead in the room- at the cost of the wielders own blood!\n\nIn a forgotten age, a Blood Cult within the Gungeon used blades such as these to carve out the hearts of sacrifices to their dark god.");
		val.SetGunSprites("riteofpassage", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 15);
		StabAnim = GunExt.UpdateAnimation(val, "stab", Initialisation.gunCollection2, false);
		GunExt.SetAnimationFPS(val, StabAnim, 8);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(377);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.DefaultModule.numberOfShotsInClip = 15;
		val.SetBarrel(51, 17);
		val.SetBaseMaxAmmo(500);
		val.gunClass = (GunClass)10;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 10f);
		val2.SetProjectileSprite("riteofpassage_proj", 11, 13, lightened: true, (Anchor)4, 9, 9, anchorChangesCollider: true, fixesScale: false, null, null);
		val2.baseData.UsesCustomAccelerationCurve = true;
		val2.baseData.AccelerationCurve = AnimationCurve.Linear(0f, 0.1f, 0.2f, 2f);
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.PaleRedImpact;
		VFXPool val3 = VFXToolbox.CreateBlankVFXPool(SharedVFX.PaleRedImpact);
		val2.hitEffects.tileMapVertical = val3;
		val2.hitEffects.tileMapHorizontal = val3;
		val2.hitEffects.enemy = VFXToolbox.CreateBlankVFXPool(SharedVFX.BloodImpactVFX);
		((Component)val2).gameObject.AddComponent<PierceProjModifier>();
		val.DefaultModule.projectiles[0] = val2;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPoolBundle("RiteOfPassageMuzzle", usesZHeight: false, 0f, (VFXAlignment)0, 5f, Color32.op_Implicit(new Color32(byte.MaxValue, (byte)117, (byte)117, byte.MaxValue)));
		val.gunHandedness = (GunHandedness)0;
		val.AddClipSprites("riteofpassage");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void Update()
	{
		if (isBusy && (Object)(object)base.gun != (Object)null && base.gun.DefaultModule != null && base.gun.RuntimeModuleData != null && base.gun.RuntimeModuleData.ContainsKey(base.gun.DefaultModule) && !base.gun.RuntimeModuleData[base.gun.DefaultModule].onCooldown)
		{
			base.gun.RuntimeModuleData[base.gun.DefaultModule].onCooldown = true;
		}
		((GunBehaviour)this).Update();
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manual)
	{
		if (!isBusy && gun.ClipShotsRemaining == gun.ClipCapacity && Object.op_Implicit((Object)(object)player) && Object.op_Implicit((Object)(object)((BraveBehaviour)player).healthHaver) && ValidForStab(player))
		{
			((MonoBehaviour)this).StartCoroutine(Stabby(player));
		}
		((GunBehaviour)this).OnReloadPressed(player, gun, manual);
	}

	public bool ValidForStab(PlayerController player)
	{
		float num = ((BraveBehaviour)player).healthHaver.currentHealth / 0.5f + ((BraveBehaviour)player).healthHaver.Armor;
		return num > 1f && !((BraveBehaviour)player).healthHaver.NextShotKills && ((BraveBehaviour)player).healthHaver.IsVulnerable && !player.IsDodgeRolling;
	}

	public IEnumerator Stabby(PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CStabby_003Ed__6(0)
		{
			_003C_003E4__this = this,
			player = player
		};
	}
}
