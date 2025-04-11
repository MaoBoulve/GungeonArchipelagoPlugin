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

public class Snaker : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CDoShadowDelayed_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int amount;

		public Projectile projectile;

		public Snaker _003C_003E4__this;

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
		public _003CDoShadowDelayed_003Ed__8(int _003C_003E1__state)
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
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				ShadowBulletDoer.SpawnChainedShadowBullets(projectile, amount, 0.01f, 1f, (Projectile)null, false);
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

	public static Projectile AppleBullet;

	public int ApplesEatenThisRoom = 0;

	private RoomHandler currentRoom;

	private RoomHandler lastRoom;

	public static void Add()
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Snaker", "snaker");
		Game.Items.Rename("outdated_gun_mods:snaker", "nn:snaker");
		Snaker snaker = ((Component)val).gameObject.AddComponent<Snaker>();
		((AdvancedGunBehavior)snaker).overrideNormalReloadAudio = "Play_OBJ_mine_beep_01";
		((AdvancedGunBehavior)snaker).overrideNormalFireAudio = "Play_OBJ_mine_beep_01";
		((AdvancedGunBehavior)snaker).preventNormalFireAudio = true;
		((AdvancedGunBehavior)snaker).preventNormalReloadAudio = true;
		GunExt.SetShortDescription((PickupObject)(object)val, "Tail As Old As Time");
		GunExt.SetLongDescription((PickupObject)(object)val, "Firing creates red 'apples' around the room. Shooting through these 'apples' buffs shots.\n\nA very hungry snake... or maybe it's a worm? It's hard to tell with so few pixels.");
		val.SetGunSprites("snaker");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.idleAnimation, 8);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 24);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(328);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1.1f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(334);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.cooldownTime = 0.45f;
		val.DefaultModule.numberOfShotsInClip = 10;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.06f, 0.68f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		((Component)val2).gameObject.AddComponent<SnakerBulletController>();
		ProjectileData baseData = val2.baseData;
		baseData.range *= 2f;
		val2.BossDamageMultiplier = 5f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.damage *= 2f;
		val2.SetProjectileSprite("snaker_projectile", 6, 6, lightened: true, (Anchor)4, 4, 4, anchorChangesCollider: true, fixesScale: false, null, null);
		PickupObject byId4 = PickupObjectDatabase.GetById(86);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		val3.baseData.damage = 0f;
		val3.baseData.speed = 0f;
		NoCollideBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<NoCollideBehaviour>(((Component)val3).gameObject);
		((Component)val3).gameObject.AddComponent<SnakerAppleController>();
		orAddComponent.worksOnEnemies = true;
		orAddComponent.worksOnProjectiles = false;
		((BraveBehaviour)val3).specRigidbody.CollideWithTileMap = false;
		val3.SetProjectileSprite("snakerapple_projectile", 12, 12, lightened: true, (Anchor)4, 12, 12, anchorChangesCollider: true, fixesScale: false, null, null);
		AppleBullet = val3;
		val.DefaultModule.projectiles[0] = val2;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Snaker Ammo", "NevernamedsItems/Resources/CustomGunAmmoTypes/snaker_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/snaker_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			ref RoomHandler reference = ref currentRoom;
			GameActor currentOwner = base.gun.CurrentOwner;
			reference = ((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).CurrentRoom;
			if (currentRoom != lastRoom)
			{
				ApplesEatenThisRoom = 0;
				lastRoom = currentRoom;
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		SnakerBulletController component = ((Component)projectile).GetComponent<SnakerBulletController>();
		if (Object.op_Implicit((Object)(object)component) && Object.op_Implicit((Object)(object)((Component)base.gun).GetComponent<Snaker>()))
		{
			component.sourceGun = ((Component)base.gun).GetComponent<Snaker>();
		}
		if (Object.op_Implicit((Object)(object)projectile.Owner) && projectile.Owner is PlayerController && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Snake World Champion"))
		{
			int amount = Math.Min(10, ApplesEatenThisRoom);
			((MonoBehaviour)projectile).StartCoroutine(DoShadowDelayed(amount, projectile));
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	private IEnumerator DoShadowDelayed(int amount, Projectile projectile)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoShadowDelayed_003Ed__8(0)
		{
			_003C_003E4__this = this,
			amount = amount,
			projectile = projectile
		};
	}

	public override void OnPostFired(PlayerController player, Gun gun)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)player) && player.CurrentRoom != null)
		{
			IntVector2 randomVisibleClearSpot = player.CurrentRoom.GetRandomVisibleClearSpot(1, 1);
			Vector3 val = ((IntVector2)(ref randomVisibleClearSpot)).ToVector3();
			GameObject val2 = SpawnManager.SpawnProjectile(((Component)AppleBullet).gameObject, val, Quaternion.identity, true);
			Projectile component = val2.GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.Owner = (GameActor)(object)player;
				component.Shooter = ((BraveBehaviour)player).specRigidbody;
				component.TreatedAsNonProjectileForChallenge = true;
				if (CustomSynergies.PlayerHasActiveSynergy(player, "High Score"))
				{
					HungryProjectileModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HungryProjectileModifier>(((Component)component).gameObject);
					orAddComponent.HungryRadius = 1.5f;
					orAddComponent.MaximumBulletsEaten = 8;
					orAddComponent.DamagePercentGainPerSnack = 0.1f;
					component.AdjustPlayerProjectileTint(ExtendedColours.purple, 1, 0f);
				}
			}
		}
		((AdvancedGunBehavior)this).OnPostFired(player, gun);
	}
}
