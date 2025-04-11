using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GrandfatherGlock : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CDoChimes_003Ed__7 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GrandfatherGlock _003C_003E4__this;

		private int _003Ci_003E5__1;

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
		public _003CDoChimes_003Ed__7(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				break;
			}
			if (_003Ci_003E5__1 < 3)
			{
				AkSoundEngine.PostEvent("Play_BOSS_mineflayer_bellshot_01", ((Component)_003C_003E4__this).gameObject);
				_003C_003E2__current = (object)new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
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

	public static int GrandfatherGlockID;

	private int currentHour;

	private int lastHour;

	public static void Add()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Grandfather Glock", "grandfatherglock");
		Game.Items.Rename("outdated_gun_mods:grandfather_glock", "nn:grandfather_glock");
		GrandfatherGlock grandfatherGlock = ((Component)val).gameObject.AddComponent<GrandfatherGlock>();
		((AdvancedGunBehavior)grandfatherGlock).overrideNormalReloadAudio = "Play_BOSS_mineflayer_bellshot_01";
		((AdvancedGunBehavior)grandfatherGlock).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "It's About Time");
		GunExt.SetLongDescription((PickupObject)(object)val, "Fires bullets in directions that correspond to it's hands in order to tell the current time.\n\nThe Gunslinger's clock was too large for the case,\nSo it sat ninety years on the floor.\nIt was longer by half than the old man himself,\nThough it weighed not a pennyweight more.\n\nIt was forged on the morn on the day that he was born,\nAnd was always his treasure and pride.\nBut it jammed, hard, never to shoot again,\nWhen the old man died.");
		val.SetGunSprites("grandfatherglock");
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(56);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		for (int i = 0; i < 3; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(56);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		float cooldownTime = 0.35f;
		int numberOfShotsInClip = 12;
		int num = 0;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			if (num <= 0)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)0;
				projectile.cooldownTime = cooldownTime;
				projectile.angleVariance = 0.1f;
				projectile.numberOfShotsInClip = numberOfShotsInClip;
				Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
				projectile.projectiles[0] = val2;
				((Component)val2).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
				Object.DontDestroyOnLoad((Object)(object)val2);
				ProjectileData baseData = val2.baseData;
				baseData.damage *= 5f;
				ProjectileData baseData2 = val2.baseData;
				baseData2.speed *= 0.6f;
				ProjectileData baseData3 = val2.baseData;
				baseData3.range *= 2f;
				val2.pierceMinorBreakables = true;
				TimeBasedBulletAimer orAddComponent = GameObjectExtensions.GetOrAddComponent<TimeBasedBulletAimer>(((Component)val2).gameObject);
				orAddComponent.aimType = TimeBasedBulletAimer.ClockHandAimType.HOUR_HAND;
				val2.SetProjectileSprite("grandfatherglock_hourhand_projectile", 19, 11, lightened: true, (Anchor)4, 18, 10, anchorChangesCollider: true, fixesScale: false, null, null);
				num++;
			}
			else if (num == 1)
			{
				projectile.ammoCost = 1;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)0;
				projectile.cooldownTime = cooldownTime;
				projectile.angleVariance = 0.1f;
				projectile.numberOfShotsInClip = numberOfShotsInClip;
				Projectile val3 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
				projectile.projectiles[0] = val3;
				((Component)val3).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
				Object.DontDestroyOnLoad((Object)(object)val3);
				ProjectileData baseData4 = val3.baseData;
				baseData4.damage *= 3f;
				ProjectileData baseData5 = val3.baseData;
				baseData5.speed *= 0.7f;
				val3.pierceMinorBreakables = true;
				ProjectileData baseData6 = val3.baseData;
				baseData6.range *= 2f;
				TimeBasedBulletAimer orAddComponent2 = GameObjectExtensions.GetOrAddComponent<TimeBasedBulletAimer>(((Component)val3).gameObject);
				orAddComponent2.aimType = TimeBasedBulletAimer.ClockHandAimType.MINUTE_HAND;
				val3.SetProjectileSprite("grandfatherglock_minutehand_projectile", 26, 9, lightened: true, (Anchor)4, 25, 8, anchorChangesCollider: true, fixesScale: false, null, null);
				num++;
			}
			else if (num >= 2)
			{
				projectile.ammoCost = 0;
				projectile.sequenceStyle = (ProjectileSequenceStyle)0;
				projectile.shootStyle = (ShootStyle)0;
				projectile.cooldownTime = cooldownTime;
				projectile.angleVariance = 0.1f;
				projectile.numberOfShotsInClip = numberOfShotsInClip;
				Projectile val4 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
				projectile.projectiles[0] = val4;
				((Component)val4).gameObject.SetActive(false);
				FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
				Object.DontDestroyOnLoad((Object)(object)val4);
				ProjectileData baseData7 = val4.baseData;
				baseData7.damage *= 1f;
				val4.pierceMinorBreakables = true;
				ProjectileData baseData8 = val4.baseData;
				baseData8.speed *= 0.7f;
				ProjectileData baseData9 = val4.baseData;
				baseData9.range *= 2f;
				TimeBasedBulletAimer orAddComponent3 = GameObjectExtensions.GetOrAddComponent<TimeBasedBulletAimer>(((Component)val4).gameObject);
				orAddComponent3.aimType = TimeBasedBulletAimer.ClockHandAimType.SECOND_HAND;
				val4.SetProjectileSprite("grandfatherglock_secondhand_projectile", 22, 5, lightened: true, (Anchor)4, 21, 4, anchorChangesCollider: true, fixesScale: false, null, null);
				num++;
			}
		}
		val.reloadTime = 1.4f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.37f, 0.68f, 0f);
		val.SetBaseMaxAmmo(300);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Grandfather Glock Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/grandfatherglock_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/grandfatherglock_clipempty");
		val.gunClass = (GunClass)50;
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GrandfatherGlockID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (projectile.Owner is PlayerController)
		{
			GameActor owner = projectile.Owner;
			PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
			if ((Object)(object)val != (Object)null)
			{
				if (CustomSynergies.PlayerHasActiveSynergy(val, "Mechanical Hands"))
				{
					BounceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)projectile).gameObject);
					orAddComponent.bouncesTrackEnemies = true;
					orAddComponent.numberOfBounces++;
					orAddComponent.bounceTrackRadius = 100f;
				}
				if (CustomSynergies.PlayerHasActiveSynergy(val, "Six Sharp") || CustomSynergies.PlayerHasActiveSynergy(val, "Kellys Eye"))
				{
					TimeBasedBulletAimer component = ((Component)projectile).GetComponent<TimeBasedBulletAimer>();
					if ((Object)(object)component != (Object)null)
					{
						if (component.aimType == TimeBasedBulletAimer.ClockHandAimType.HOUR_HAND)
						{
							int num = DateTime.Now.Hour;
							if (num > 12)
							{
								num -= 12;
							}
							if (num == 0)
							{
								num = 12;
							}
							if (CustomSynergies.PlayerHasActiveSynergy(val, "Six Sharp") && num.ToString().Contains("6"))
							{
								ProjectileData baseData = projectile.baseData;
								baseData.damage *= 3f;
							}
							if (CustomSynergies.PlayerHasActiveSynergy(val, "Kellys Eye") && num.ToString().Contains("1"))
							{
								ProjectileData baseData2 = projectile.baseData;
								baseData2.damage *= 3f;
							}
						}
						if (component.aimType == TimeBasedBulletAimer.ClockHandAimType.MINUTE_HAND)
						{
							int minute = DateTime.Now.Minute;
							if (CustomSynergies.PlayerHasActiveSynergy(val, "Kellys Eye") && minute.ToString().Contains("1"))
							{
								ProjectileData baseData3 = projectile.baseData;
								baseData3.damage *= 3f;
							}
							if (CustomSynergies.PlayerHasActiveSynergy(val, "Six Sharp") && minute.ToString().Contains("6"))
							{
								ProjectileData baseData4 = projectile.baseData;
								baseData4.damage *= 3f;
							}
						}
						if (component.aimType == TimeBasedBulletAimer.ClockHandAimType.SECOND_HAND)
						{
							int second = DateTime.Now.Second;
							if (CustomSynergies.PlayerHasActiveSynergy(val, "Kellys Eye") && second.ToString().Contains("1"))
							{
								ProjectileData baseData5 = projectile.baseData;
								baseData5.damage *= 3f;
							}
							if (CustomSynergies.PlayerHasActiveSynergy(val, "Six Sharp") && second.ToString().Contains("6"))
							{
								ProjectileData baseData6 = projectile.baseData;
								baseData6.damage *= 3f;
							}
						}
					}
				}
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	protected override void Update()
	{
		currentHour = DateTime.Now.Hour;
		if (currentHour != lastHour)
		{
			lastHour = currentHour;
			((MonoBehaviour)GameManager.Instance).StartCoroutine(DoChimes());
		}
		((AdvancedGunBehavior)this).Update();
	}

	private IEnumerator DoChimes()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoChimes_003Ed__7(0)
		{
			_003C_003E4__this = this
		};
	}
}
