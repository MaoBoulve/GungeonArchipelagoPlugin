using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class MagicPaintbrush : GunBehaviour
{
	private class PaintbrushProjectile : BraveBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CHandleDamageCooldown_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AIActor damagedTarget;

			public PaintbrushProjectile _003C_003E4__this;

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
			public _003CHandleDamageCooldown_003Ed__4(int _003C_003E1__state)
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
				//IL_003d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0047: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E4__this.m_damagedEnemies.Add(damagedTarget);
					_003C_003E2__current = (object)new WaitForSeconds(0.5f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003C_003E4__this.m_damagedEnemies.Remove(damagedTarget);
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

		public Projectile paint;

		private HashSet<AIActor> m_damagedEnemies = new HashSet<AIActor>();

		private void Start()
		{
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile))
			{
				Projectile projectile = ((BraveBehaviour)this).projectile;
				projectile.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitenemy));
			}
		}

		private void OnHitenemy(Projectile proj, SpeculativeRigidbody body, bool fatal)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)body) || !Object.op_Implicit((Object)(object)((BraveBehaviour)body).aiActor))
			{
				return;
			}
			((MonoBehaviour)this).StartCoroutine(HandleDamageCooldown(((BraveBehaviour)body).aiActor));
			for (int i = 0; i < 12; i++)
			{
				Projectile component = ProjectileUtility.InstantiateAndFireInDirection(paint, proj.SafeCenter, BraveUtility.RandomAngle(), 0f, (PlayerController)null).GetComponent<Projectile>();
				component.Owner = proj.Owner;
				component.Shooter = proj.Shooter;
				if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(component)))
				{
					component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(proj));
				}
				((BraveBehaviour)component).specRigidbody.RegisterTemporaryCollisionException(body, 0.01f, (float?)null);
				body.RegisterTemporaryCollisionException(((BraveBehaviour)component).specRigidbody, 0.01f, (float?)null);
			}
		}

		private IEnumerator HandleDamageCooldown(AIActor damagedTarget)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CHandleDamageCooldown_003Ed__4(0)
			{
				_003C_003E4__this = this,
				damagedTarget = damagedTarget
			};
		}
	}

	public static int ID;

	public static void Add()
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Magic Paintbrush", "magicpaintbrush");
		Game.Items.Rename("outdated_gun_mods:magic_paintbrush", "nn:magic_paintbrush");
		((Component)val).gameObject.AddComponent<MagicPaintbrush>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Scrybe of Magicks");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires multicoloured magical gems which explode into bursts of paint on passing through Gundead.\n\nNothing beautiful can last.");
		val.SetGunSprites("magicpaintbrush", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 14);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(145);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.gunHandedness = (GunHandedness)2;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(145);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.5f;
		val.DefaultModule.numberOfShotsInClip = 5;
		val.SetBarrel(36, 17);
		val.SetBaseMaxAmmo(100);
		val.ammo = 200;
		val.gunClass = (GunClass)50;
		Color val2 = default(Color);
		((Color)(ref val2))._002Ector(82f / 85f, 43f / 85f, 0.14509805f);
		Color val3 = default(Color);
		((Color)(ref val3))._002Ector(21f / 85f, 54f / 85f, 23f / 51f);
		Color val4 = default(Color);
		((Color)(ref val4))._002Ector(52f / 85f, 0.7490196f, 1f / 3f);
		Projectile val5 = ProjectileSetupUtility.MakeProjectile(86, 12f);
		val5.SetProjectileSprite("magicpaintbrush_proj_ruby", 7, 7, lightened: false, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val5).gameObject.AddComponent<ProjectileSpriteRotation>().RotPerFrame = 2f;
		EasyTrailBullet easyTrailBullet = ((Component)val5).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val5).transform.position);
		easyTrailBullet.StartWidth = 0.1875f;
		easyTrailBullet.EndWidth = 0f;
		easyTrailBullet.LifeTime = 0.1f;
		easyTrailBullet.BaseColor = val2;
		easyTrailBullet.EndColor = val2;
		easyTrailBullet.StartColor = val2;
		ref ProjectileImpactVFXPool hitEffects = ref val5.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(Bejeweler.ID);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[2].hitEffects;
		Projectile val6 = ProjectileSetupUtility.MakeProjectile(86, 2.5f, -1f, 3f);
		val6.SetProjectileSprite("magicpaintbrush_subproj_orange", 5, 5, lightened: false, (Anchor)4, 5, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val6).gameObject.AddComponent<FungoRandomBullets>().HunterSporeChance = -1f;
		EasyTrailBullet easyTrailBullet2 = ((Component)val6).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet2.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val5).transform.position);
		easyTrailBullet2.StartWidth = 0.1875f;
		easyTrailBullet2.EndWidth = 0f;
		easyTrailBullet2.LifeTime = 0.3f;
		easyTrailBullet2.BaseColor = val2;
		easyTrailBullet2.EndColor = val2;
		easyTrailBullet2.StartColor = val2;
		val6.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofOrange;
		val6.hitEffects.alwaysUseMidair = true;
		((Component)val5).gameObject.AddComponent<PierceProjModifier>().penetration = 3;
		((Component)val5).gameObject.AddComponent<PaintbrushProjectile>().paint = val6;
		Projectile val7 = ProjectileSetupUtility.MakeProjectile(86, 12f);
		val7.SetProjectileSprite("magicpaintbrush_proj_sapphire", 7, 7, lightened: false, (Anchor)4, 7, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val7).gameObject.AddComponent<ProjectileSpriteRotation>().RotPerFrame = 2f;
		EasyTrailBullet easyTrailBullet3 = ((Component)val7).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet3.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val7).transform.position);
		easyTrailBullet3.StartWidth = 0.1875f;
		easyTrailBullet3.EndWidth = 0f;
		easyTrailBullet3.LifeTime = 0.1f;
		easyTrailBullet3.BaseColor = val3;
		easyTrailBullet3.EndColor = val3;
		easyTrailBullet3.StartColor = val3;
		ref ProjectileImpactVFXPool hitEffects2 = ref val7.hitEffects;
		PickupObject byId5 = PickupObjectDatabase.GetById(Bejeweler.ID);
		hitEffects2 = ((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0].hitEffects;
		val7.hitEffects.alwaysUseMidair = true;
		Projectile val8 = ProjectileSetupUtility.MakeProjectile(86, 2.5f, -1f, 3f);
		val8.SetProjectileSprite("magicpaintbrush_subproj_blue", 5, 5, lightened: false, (Anchor)4, 5, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val8).gameObject.AddComponent<FungoRandomBullets>().HunterSporeChance = -1f;
		EasyTrailBullet easyTrailBullet4 = ((Component)val8).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet4.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val5).transform.position);
		easyTrailBullet4.StartWidth = 0.1875f;
		easyTrailBullet4.EndWidth = 0f;
		easyTrailBullet4.LifeTime = 0.3f;
		easyTrailBullet4.BaseColor = val3;
		easyTrailBullet4.EndColor = val3;
		easyTrailBullet4.StartColor = val3;
		val8.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofBlue;
		val8.hitEffects.alwaysUseMidair = true;
		((Component)val7).gameObject.AddComponent<PierceProjModifier>().penetration = 3;
		((Component)val7).gameObject.AddComponent<PaintbrushProjectile>().paint = val8;
		Projectile val9 = ProjectileSetupUtility.MakeProjectile(86, 12f);
		val9.SetProjectileSprite("magicpaintbrush_proj_emerald", 7, 6, lightened: false, (Anchor)4, 7, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val9).gameObject.AddComponent<ProjectileSpriteRotation>().RotPerFrame = 2f;
		EasyTrailBullet easyTrailBullet5 = ((Component)val9).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet5.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val9).transform.position);
		easyTrailBullet5.StartWidth = 0.1875f;
		easyTrailBullet5.EndWidth = 0f;
		easyTrailBullet5.LifeTime = 0.1f;
		easyTrailBullet5.BaseColor = val4;
		easyTrailBullet5.EndColor = val4;
		easyTrailBullet5.StartColor = val4;
		ref ProjectileImpactVFXPool hitEffects3 = ref val9.hitEffects;
		PickupObject byId6 = PickupObjectDatabase.GetById(Bejeweler.ID);
		hitEffects3 = ((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[1].hitEffects;
		Projectile val10 = ProjectileSetupUtility.MakeProjectile(86, 2.5f, -1f, 3f);
		val10.SetProjectileSprite("magicpaintbrush_subproj_green", 5, 5, lightened: false, (Anchor)4, 5, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		((Component)val10).gameObject.AddComponent<FungoRandomBullets>().HunterSporeChance = -1f;
		EasyTrailBullet easyTrailBullet6 = ((Component)val10).gameObject.AddComponent<EasyTrailBullet>();
		easyTrailBullet6.TrailPos = Vector2.op_Implicit(((BraveBehaviour)val5).transform.position);
		easyTrailBullet6.StartWidth = 0.1875f;
		easyTrailBullet6.EndWidth = 0f;
		easyTrailBullet6.LifeTime = 0.3f;
		easyTrailBullet6.BaseColor = val4;
		easyTrailBullet6.EndColor = val4;
		easyTrailBullet6.StartColor = val4;
		val10.hitEffects.overrideMidairDeathVFX = SharedVFX.ColouredPoofGreen;
		val10.hitEffects.alwaysUseMidair = true;
		((Component)val9).gameObject.AddComponent<PierceProjModifier>().penetration = 3;
		((Component)val9).gameObject.AddComponent<PaintbrushProjectile>().paint = val10;
		val.DefaultModule.projectiles[0] = val5;
		val.DefaultModule.projectiles.Add(val7);
		val.DefaultModule.projectiles.Add(val9);
		val.AddClipSprites("magicpaintbrush");
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
