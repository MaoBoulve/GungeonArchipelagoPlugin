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

public class PumpChargeShotgun : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CShowChargeLevel_003Ed__14 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameActor gunOwner;

		public int chargeLevel;

		public PumpChargeShotgun _003C_003E4__this;

		private GameObject _003CnewSprite_003E5__1;

		private tk2dSprite _003Cm_ItemSprite_003E5__2;

		private int _003CspriteID_003E5__3;

		private int _003Ci_003E5__4;

		private int _003C_003Es__5;

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
		public _003CShowChargeLevel_003Ed__14(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CnewSprite_003E5__1 = null;
			_003Cm_ItemSprite_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this.extantSprites.Count > 0)
				{
					_003Ci_003E5__4 = _003C_003E4__this.extantSprites.Count - 1;
					while (_003Ci_003E5__4 >= 0)
					{
						Object.Destroy((Object)(object)_003C_003E4__this.extantSprites[_003Ci_003E5__4].gameObject);
						_003Ci_003E5__4--;
					}
					_003C_003E4__this.extantSprites.Clear();
				}
				_003CnewSprite_003E5__1 = new GameObject("Level Popup", new Type[1] { typeof(tk2dSprite) })
				{
					layer = 0
				};
				_003CnewSprite_003E5__1.transform.position = ((BraveBehaviour)gunOwner).transform.position + new Vector3(0.5f, 2f);
				_003Cm_ItemSprite_003E5__2 = _003CnewSprite_003E5__1.AddComponent<tk2dSprite>();
				_003C_003E4__this.extantSprites.Add(_003CnewSprite_003E5__1);
				_003CspriteID_003E5__3 = -1;
				int num = chargeLevel;
				_003C_003Es__5 = num;
				switch (_003C_003Es__5)
				{
				case 1:
					_003CspriteID_003E5__3 = Meter1ID;
					break;
				case 2:
					_003CspriteID_003E5__3 = Meter2ID;
					break;
				case 3:
					_003CspriteID_003E5__3 = Meter3ID;
					break;
				case 4:
					_003CspriteID_003E5__3 = Meter4ID;
					break;
				case 5:
					_003CspriteID_003E5__3 = Meter5ID;
					break;
				}
				((tk2dBaseSprite)_003Cm_ItemSprite_003E5__2).SetSprite(GunVFXCollection, _003CspriteID_003E5__3);
				((tk2dBaseSprite)_003Cm_ItemSprite_003E5__2).PlaceAtPositionByAnchor(_003CnewSprite_003E5__1.transform.position, (Anchor)1);
				((BraveBehaviour)_003Cm_ItemSprite_003E5__2).transform.localPosition = dfVectorExtensions.Quantize(((BraveBehaviour)_003Cm_ItemSprite_003E5__2).transform.localPosition, 0.0625f);
				_003CnewSprite_003E5__1.transform.parent = ((BraveBehaviour)gunOwner).transform;
				if (Object.op_Implicit((Object)(object)_003Cm_ItemSprite_003E5__2))
				{
					((BraveBehaviour)_003C_003E4__this).sprite.AttachRenderer((tk2dBaseSprite)(object)_003Cm_ItemSprite_003E5__2);
					((tk2dBaseSprite)_003Cm_ItemSprite_003E5__2).depthUsesTrimmedBounds = true;
					((tk2dBaseSprite)_003Cm_ItemSprite_003E5__2).UpdateZDepth();
				}
				((BraveBehaviour)_003C_003E4__this).sprite.UpdateZDepth();
				_003C_003E2__current = (object)new WaitForSeconds(2f);
				_003C_003E1__state = 1;
				return true;
			}
			case 1:
				_003C_003E1__state = -1;
				if (Object.op_Implicit((Object)(object)_003CnewSprite_003E5__1))
				{
					_003C_003E4__this.extantSprites.Remove(_003CnewSprite_003E5__1);
					Object.Destroy((Object)(object)_003CnewSprite_003E5__1.gameObject);
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

	public static Projectile Level2Projectile;

	public static Projectile Level3Projectile;

	public static Projectile Level4Projectile;

	public List<GameObject> extantSprites;

	private static tk2dSpriteCollectionData GunVFXCollection;

	private static GameObject VFXScapegoat;

	private static int Meter1ID;

	private static int Meter2ID;

	private static int Meter3ID;

	private static int Meter4ID;

	private static int Meter5ID;

	public int currentChargeLevel = 1;

	public static void Add()
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pump-Charge Shotgun", "pumpchargeshotgun");
		Game.Items.Rename("outdated_gun_mods:pumpcharge_shotgun", "nn:pump_charge_shotgun");
		((Component)val).gameObject.AddComponent<PumpChargeShotgun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "HELL IS FULL");
		GunExt.SetLongDescription((PickupObject)(object)val, "Continuing to reload this shotgun when it's already full will charge it up. Be careful not to overcharge it!\n\nForged by a bloodthirsty adventurer who sought to cleanse Bullet Hell.");
		val.SetGunSprites("pumpchargeshotgun");
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(55);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.CanReloadNoMatterAmmo = true;
		val.reloadTime = 1f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.06f, 0.62f, 0f);
		val.SetBaseMaxAmmo(80);
		val.ammo = 80;
		val.gunClass = (GunClass)5;
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId3 = PickupObjectDatabase.GetById(56);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		}
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = 1;
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.5f;
			projectile.angleVariance = 20f;
			projectile.numberOfShotsInClip = 5;
			Projectile val2 = Object.Instantiate<Projectile>(projectile.projectiles[0]);
			projectile.projectiles[0] = val2;
			((Component)val2).gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
			Object.DontDestroyOnLoad((Object)(object)val2);
			ProjectileData baseData = val2.baseData;
			baseData.speed *= 1f;
			ProjectileData baseData2 = val2.baseData;
			baseData2.damage *= 1f;
			val2.hitEffects.alwaysUseMidair = true;
			val2.hitEffects.overrideMidairDeathVFX = SharedVFX.GreenLaserCircleVFX;
			val2.SetProjectileSprite("pumpcharge_green_projectile", 8, 6, lightened: true, (Anchor)4, 7, 5, anchorChangesCollider: true, fixesScale: false, null, null);
			((Component)val2).gameObject.AddComponent<BloodBurstOnKill>();
			if (projectile != val.DefaultModule)
			{
				projectile.ammoCost = 0;
			}
		}
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Pump-Charge Shotgun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/pumpchargeshotgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/pumpchargeshotgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PickupObject byId4 = PickupObjectDatabase.GetById(56);
		Projectile val3 = Object.Instantiate<Projectile>(((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0]);
		((Component)val3).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val3).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val3);
		ProjectileData baseData3 = val3.baseData;
		baseData3.speed *= 1f;
		ProjectileData baseData4 = val3.baseData;
		baseData4.damage *= 1.4f;
		val3.hitEffects.alwaysUseMidair = true;
		val3.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		((Component)val3).gameObject.AddComponent<BloodBurstOnKill>();
		val3.SetProjectileSprite("pumpcharge_yellow_projectile", 10, 6, lightened: true, (Anchor)4, 9, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		Level2Projectile = val3;
		PickupObject byId5 = PickupObjectDatabase.GetById(56);
		Projectile val4 = Object.Instantiate<Projectile>(((Gun)((byId5 is Gun) ? byId5 : null)).DefaultModule.projectiles[0]);
		((Component)val4).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val4).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val4);
		ProjectileData baseData5 = val4.baseData;
		baseData5.speed *= 1f;
		val4.hitEffects.alwaysUseMidair = true;
		val4.hitEffects.overrideMidairDeathVFX = SharedVFX.YellowLaserCircleVFX;
		((Component)val4).gameObject.AddComponent<BloodBurstOnKill>();
		ProjectileData baseData6 = val4.baseData;
		baseData6.damage *= 1.8f;
		val4.SetProjectileSprite("pumpcharge_orange_projectile", 12, 6, lightened: true, (Anchor)4, 11, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		Level3Projectile = val4;
		PickupObject byId6 = PickupObjectDatabase.GetById(56);
		Projectile val5 = Object.Instantiate<Projectile>(((Gun)((byId6 is Gun) ? byId6 : null)).DefaultModule.projectiles[0]);
		((Component)val5).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val5).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val5);
		((Component)val5).gameObject.AddComponent<BloodBurstOnKill>();
		ProjectileData baseData7 = val5.baseData;
		baseData7.speed *= 1f;
		val5.hitEffects.alwaysUseMidair = true;
		val5.hitEffects.overrideMidairDeathVFX = SharedVFX.RedLaserCircleVFX;
		ProjectileData baseData8 = val5.baseData;
		baseData8.damage *= 2.2f;
		val5.SetProjectileSprite("pumpcharge_red_projectile", 17, 8, lightened: true, (Anchor)4, 16, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		Level4Projectile = val5;
		SetupCollection();
	}

	public override Projectile OnPreFireProjectileModifier(Gun gun, Projectile projectile, ProjectileModule mod)
	{
		if (currentChargeLevel == 2)
		{
			return Level2Projectile;
		}
		if (currentChargeLevel == 3)
		{
			return Level3Projectile;
		}
		if (currentChargeLevel == 4)
		{
			return Level4Projectile;
		}
		return ((AdvancedGunBehavior)this).OnPreFireProjectileModifier(gun, projectile, mod);
	}

	private static void SetupCollection()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		VFXScapegoat = new GameObject();
		Object.DontDestroyOnLoad((Object)(object)VFXScapegoat);
		GunVFXCollection = SpriteBuilder.ConstructCollection(VFXScapegoat, "PumpChargeVFX_Collection", false);
		Object.DontDestroyOnLoad((Object)(object)GunVFXCollection);
		Meter1ID = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/MiscVFX/PumpChargeMeter1", GunVFXCollection, (Assembly)null);
		Meter2ID = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/MiscVFX/PumpChargeMeter2", GunVFXCollection, (Assembly)null);
		Meter3ID = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/MiscVFX/PumpChargeMeter3", GunVFXCollection, (Assembly)null);
		Meter4ID = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/MiscVFX/PumpChargeMeter4", GunVFXCollection, (Assembly)null);
		Meter5ID = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/MiscVFX/PumpChargeMeter5", GunVFXCollection, (Assembly)null);
	}

	private IEnumerator ShowChargeLevel(GameActor gunOwner, int chargeLevel)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CShowChargeLevel_003Ed__14(0)
		{
			_003C_003E4__this = this,
			gunOwner = gunOwner,
			chargeLevel = chargeLevel
		};
	}

	private void DoExplosion(PlayerController player, Gun gun)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)gun).sprite.WorldCenter), Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		if (currentChargeLevel <= 0 || currentChargeLevel >= 6)
		{
			currentChargeLevel = 1;
		}
		if (gun.ClipShotsRemaining == gun.ClipCapacity)
		{
			if (!gun.IsReloading)
			{
				gun.ClipShotsRemaining = gun.ClipCapacity - 1;
				gun.Reload();
				gun.MoveBulletsIntoClip(1);
				switch (currentChargeLevel)
				{
				case 1:
					currentChargeLevel = 2;
					((MonoBehaviour)player).StartCoroutine(ShowChargeLevel(((BraveBehaviour)player).gameActor, 2));
					break;
				case 2:
					currentChargeLevel = 3;
					((MonoBehaviour)player).StartCoroutine(ShowChargeLevel(((BraveBehaviour)player).gameActor, 3));
					break;
				case 3:
					currentChargeLevel = 4;
					((MonoBehaviour)player).StartCoroutine(ShowChargeLevel(((BraveBehaviour)player).gameActor, 4));
					break;
				case 4:
					currentChargeLevel = 1;
					((MonoBehaviour)player).StartCoroutine(ShowChargeLevel(((BraveBehaviour)player).gameActor, 5));
					DoExplosion(player, gun);
					break;
				}
			}
		}
		else
		{
			currentChargeLevel = 1;
			((MonoBehaviour)player).StartCoroutine(ShowChargeLevel(((BraveBehaviour)player).gameActor, 1));
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, manualReload);
	}

	protected override void OnPickup(GameActor owner)
	{
		currentChargeLevel = 1;
		((MonoBehaviour)owner).StartCoroutine(ShowChargeLevel(owner, 1));
		((AdvancedGunBehavior)this).OnPickup(owner);
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		currentChargeLevel = 1;
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}
}
