using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class VariableGun : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CChangeProjectileDamage_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile bullet;

		public float postmultiplier;

		public bool directSet;

		public VariableGun _003C_003E4__this;

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
		public _003CChangeProjectileDamage_003Ed__6(int _003C_003E1__state)
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
				if ((Object)(object)bullet != (Object)null)
				{
					if (directSet)
					{
						bullet.baseData.damage = postmultiplier;
					}
					else
					{
						ProjectileData baseData = bullet.baseData;
						baseData.damage *= postmultiplier;
					}
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

	public static AIActor LastHitEnemy;

	public static AIActor LegacyHitEnemy;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Variable", "variable");
		Game.Items.Rename("outdated_gun_mods:variable", "nn:variable");
		((Component)val).gameObject.AddComponent<VariableGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Boollet Value");
		GunExt.SetLongDescription((PickupObject)(object)val, "Deals double damage if the target you're shooting is different to the last enemy you shot.\n\nFavoured sidearm of a famous programmer, who came to the gungeon after being driven insane by the inane questions asked of him by other people.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "variable_idle_001", 8, "variable_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(35);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.43f, 0.81f, 0f);
		val.SetBaseMaxAmmo(256);
		val.ammo = 256;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 1.2f;
		val2.hitEffects.alwaysUseMidair = true;
		val2.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		val2.SetProjectileSprite("variable1_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		PickupObject byId3 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData3 = val3.baseData;
		baseData3.damage *= 1.6f;
		ProjectileData baseData4 = val3.baseData;
		baseData4.force *= 1.2f;
		val3.hitEffects.alwaysUseMidair = true;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.WhiteCircleVFX;
		val3.SetProjectileSprite("variable2_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.projectiles.Add(val3);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Variable Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/variable_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/variable_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			LastHitEnemy = null;
			LegacyHitEnemy = null;
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		if (Object.op_Implicit((Object)(object)otherRigidbody) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)otherRigidbody).healthHaver) && Object.op_Implicit((Object)(object)((BraveBehaviour)myRigidbody).projectile) && ((BraveBehaviour)myRigidbody).projectile.Owner is PlayerController)
		{
			GameActor owner = ((BraveBehaviour)myRigidbody).projectile.Owner;
			if (CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((owner is PlayerController) ? owner : null), "Backwards Compatible") && (Object)(object)((BraveBehaviour)otherRigidbody).aiActor != (Object)(object)LastHitEnemy && (Object)(object)((BraveBehaviour)otherRigidbody).aiActor != (Object)(object)LegacyHitEnemy && (Object)(object)LastHitEnemy != (Object)(object)LegacyHitEnemy)
			{
				float damage = ((BraveBehaviour)myRigidbody).projectile.baseData.damage;
				ProjectileData baseData = ((BraveBehaviour)myRigidbody).projectile.baseData;
				baseData.damage *= 3f;
				((MonoBehaviour)GameManager.Instance).StartCoroutine(ChangeProjectileDamage(((BraveBehaviour)myRigidbody).projectile, damage, directSet: true));
			}
			else if ((Object)(object)((BraveBehaviour)otherRigidbody).aiActor != (Object)(object)LastHitEnemy)
			{
				ProjectileData baseData2 = ((BraveBehaviour)myRigidbody).projectile.baseData;
				baseData2.damage *= 2f;
				((MonoBehaviour)GameManager.Instance).StartCoroutine(ChangeProjectileDamage(((BraveBehaviour)myRigidbody).projectile, 0.5f, directSet: false));
			}
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		if ((Object)(object)((BraveBehaviour)enemy).aiActor != (Object)null)
		{
			if ((Object)(object)LastHitEnemy != (Object)null)
			{
				LegacyHitEnemy = LastHitEnemy;
			}
			LastHitEnemy = ((BraveBehaviour)enemy).aiActor;
		}
	}

	private IEnumerator ChangeProjectileDamage(Projectile bullet, float postmultiplier, bool directSet)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CChangeProjectileDamage_003Ed__6(0)
		{
			_003C_003E4__this = this,
			bullet = bullet,
			postmultiplier = postmultiplier,
			directSet = directSet
		};
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		if (projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)projectile).specRigidbody;
			specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
			projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
