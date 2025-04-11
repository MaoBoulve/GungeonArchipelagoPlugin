using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Bookllet : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CDoRingBullets_003Ed__6 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile bullet;

		public Gun gun;

		public Bookllet _003C_003E4__this;

		private float _003CspawnAngle_003E5__1;

		private int _003Ci_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CDoRingBullets_003Ed__6(int _003C_003E1__state)
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
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Expected O, but got Unknown
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
					_003C_003E4__this.SpawnProjectile(bullet, Vector2.op_Implicit(((BraveBehaviour)gun).sprite.WorldCenter), 90f);
					_003C_003E4__this.SpawnProjectile(bullet, Vector2.op_Implicit(((BraveBehaviour)gun).sprite.WorldCenter), -90f);
					_003C_003E2__current = (object)new WaitForSeconds(0.05f);
					_003C_003E1__state = 2;
					return true;
				}
				break;
			case 2:
				_003C_003E1__state = -1;
				_003CspawnAngle_003E5__1 = 0f;
				_003Ci_003E5__2 = 0;
				while (_003Ci_003E5__2 < 30)
				{
					_003C_003E4__this.SpawnProjectile(bullet, Vector2.op_Implicit(((BraveBehaviour)gun).sprite.WorldCenter), _003CspawnAngle_003E5__1);
					_003CspawnAngle_003E5__1 += 12f;
					_003Ci_003E5__2++;
				}
				_003C_003E2__current = (object)new WaitForSeconds(0.05f);
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				_003Ci_003E5__3 = 0;
				goto IL_021a;
			case 4:
				{
					_003C_003E1__state = -1;
					_003Ci_003E5__3++;
					goto IL_021a;
				}
				IL_021a:
				if (_003Ci_003E5__3 < 2)
				{
					_003C_003E4__this.SpawnProjectile(bullet, Vector2.op_Implicit(((BraveBehaviour)gun).sprite.WorldCenter), 90f);
					_003C_003E4__this.SpawnProjectile(bullet, Vector2.op_Implicit(((BraveBehaviour)gun).sprite.WorldCenter), -90f);
					_003C_003E2__current = (object)new WaitForSeconds(0.05f);
					_003C_003E1__state = 4;
					return true;
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

	public static int BooklletID;

	public static Projectile Ringbullet;

	private bool canReleaseRing = true;

	public static List<Projectile> ActiveBullets = new List<Projectile>();

	public static List<Projectile> BulletsToRemoveFromActiveBullets = new List<Projectile>();

	public static void Add()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Bookllet", "bookllet");
		Game.Items.Rename("outdated_gun_mods:bookllet", "nn:bookllet");
		Bookllet bookllet = ((Component)val).gameObject.AddComponent<Bookllet>();
		((AdvancedGunBehavior)bookllet).preventNormalFireAudio = true;
		((AdvancedGunBehavior)bookllet).overrideNormalFireAudio = "Play_OBJ_book_drop_01";
		((AdvancedGunBehavior)bookllet).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)bookllet).overrideNormalReloadAudio = "Play_ENM_book_blast_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Ammomancy For Beginners");
		GunExt.SetLongDescription((PickupObject)(object)val, "A powerful ammomantic textbook studied by Apprentice Gunjurers");
		val.SetGunSprites("bookllet");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 18);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.05f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 20;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.93f, 0.87f, 0f);
		val.SetBaseMaxAmmo(400);
		val.gunClass = (GunClass)10;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.speed *= 0.0001f;
		val2.SetProjectileSprite("yellow_enemystyle_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		BooklletTimedReAim booklletTimedReAim = ((Component)val2).gameObject.AddComponent<BooklletTimedReAim>();
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		Ringbullet = Object.Instantiate<Projectile>(((Gun)((byId2 is Gun) ? byId2 : null)).DefaultModule.projectiles[0]);
		((Component)Ringbullet).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)Ringbullet).gameObject);
		Object.DontDestroyOnLoad((Object)(object)Ringbullet);
		ProjectileData baseData3 = Ringbullet.baseData;
		baseData3.damage *= 1.4f;
		ProjectileData baseData4 = Ringbullet.baseData;
		baseData4.speed *= 0.6f;
		Ringbullet.SetProjectileSprite("yellow_enemystyle_projectile", 10, 10, lightened: true, (Anchor)4, 8, 8, anchorChangesCollider: true, fixesScale: false, null, null);
		((BraveBehaviour)Ringbullet).transform.parent = val.barrelOffset;
		((PickupObject)val).quality = (ItemQuality)3;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Bookllet";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		BooklletID = ((PickupObject)val).PickupObjectId;
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveBullets.Count > 0)
		{
			foreach (Projectile activeBullet in ActiveBullets)
			{
				if (Object.op_Implicit((Object)(object)activeBullet))
				{
					Vector2 vectorToNearestEnemy = ProjectileUtility.GetVectorToNearestEnemy(activeBullet, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
					activeBullet.SendInDirection(vectorToNearestEnemy, false, true);
					ProjectileData baseData = activeBullet.baseData;
					baseData.speed *= 7500f;
					activeBullet.UpdateSpeed();
					BulletsToRemoveFromActiveBullets.Add(activeBullet);
				}
			}
			foreach (Projectile bulletsToRemoveFromActiveBullet in BulletsToRemoveFromActiveBullets)
			{
				ActiveBullets.Remove(bulletsToRemoveFromActiveBullet);
			}
			BulletsToRemoveFromActiveBullets.Clear();
		}
		if (gun.ClipShotsRemaining == 0 && gun.CurrentAmmo != 0 && canReleaseRing)
		{
			((MonoBehaviour)GameManager.Instance).StartCoroutine(DoRingBullets(Ringbullet, gun));
			canReleaseRing = false;
			((MonoBehaviour)this).Invoke("HandleRingCooldown", 1f);
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, bSOMETHING);
	}

	private void HandleRingCooldown()
	{
		canReleaseRing = true;
	}

	private IEnumerator DoRingBullets(Projectile bullet, Gun gun)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoRingBullets_003Ed__6(0)
		{
			_003C_003E4__this = this,
			bullet = bullet,
			gun = gun
		};
	}

	private void SpawnProjectile(Projectile proj, Vector3 spawnPosition, float zRotation, SpeculativeRigidbody collidedRigidbody = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)proj).gameObject, spawnPosition, Quaternion.Euler(0f, 0f, zRotation), true);
		Projectile component = val.GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.SpawnedFromOtherPlayerProjectile = false;
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val2 = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if ((Object)(object)val2 != (Object)null)
			{
				ProjectileData baseData = component.baseData;
				baseData.damage *= val2.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= val2.stats.GetStatValue((StatType)6);
				val2.DoPostProcessProjectile(component);
			}
		}
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		GameActor owner = projectile.Owner;
		PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
		if ((Object)(object)val != (Object)null && CustomSynergies.PlayerHasActiveSynergy(val, "Advanced Ammomancy"))
		{
			if (Object.op_Implicit((Object)(object)((Component)projectile).gameObject.GetComponent<BooklletTimedReAim>()))
			{
				Object.Destroy((Object)(object)((Component)projectile).gameObject.GetComponent<BooklletTimedReAim>());
			}
			ActiveBullets.Add(projectile);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
