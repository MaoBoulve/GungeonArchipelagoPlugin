using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class ServiceWeapon : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CDoBoardDialogue_003Ed__9 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> text;

		public PlayerController player;

		public ServiceWeapon _003C_003E4__this;

		private GameObject _003CboardInst_003E5__1;

		private List<string>.Enumerator _003C_003Es__2;

		private string _003Cdialogue_003E5__3;

		private RelativeLabelAttacher _003Clabel_003E5__4;

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
		public _003CDoBoardDialogue_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003CboardInst_003E5__1 = null;
			_003C_003Es__2 = default(List<string>.Enumerator);
			_003Cdialogue_003E5__3 = null;
			_003Clabel_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (_003C_003E4__this.talking)
					{
						return false;
					}
					_003C_003E4__this.talking = true;
					VFXToolbox.GlitchScreenForSeconds(0.5f);
					_003CboardInst_003E5__1 = ((GameActor)player).PlayEffectOnActor(board, new Vector3(1f, 2f, 0f), true, false, true);
					_003C_003Es__2 = text.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					Object.Destroy((Object)(object)_003Clabel_003E5__4);
					_003Clabel_003E5__4 = null;
					_003Cdialogue_003E5__3 = null;
					break;
				}
				if (_003C_003Es__2.MoveNext())
				{
					_003Cdialogue_003E5__3 = _003C_003Es__2.Current;
					_003Clabel_003E5__4 = _003CboardInst_003E5__1.AddComponent<RelativeLabelAttacher>();
					_003Clabel_003E5__4.colour = Color.red;
					_003Clabel_003E5__4.offset = new Vector3(0f, 3f, 0f);
					_003Clabel_003E5__4.labelValue = _003Cdialogue_003E5__3;
					_003Clabel_003E5__4.centered = true;
					AkSoundEngine.PostEvent("Play_BoardCommunication", ((Component)player).gameObject);
					_003C_003E2__current = (object)new WaitForSeconds(5f);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003Es__2 = default(List<string>.Enumerator);
				VFXToolbox.GlitchScreenForSeconds(0.5f);
				Object.Destroy((Object)(object)_003CboardInst_003E5__1);
				_003C_003E4__this.talking = false;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003Es__2/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static int ID;

	public bool talking;

	public float timeSinceLastFired;

	public float timeSinceLastAmmoIncremented = 0f;

	public bool critical;

	public static GameObject board;

	public static void Add()
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Service Weapon", "serviceweapon");
		Game.Items.Rename("outdated_gun_mods:service_weapon", "nn:service_weapon");
		((Component)val).gameObject.AddComponent<ServiceWeapon>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Last Line of Defence");
		GunExt.SetLongDescription((PickupObject)(object)val, "This weapon is officially categorised as a F.O.P, or 'Firearm of Power', a highly anomalous, highly powerful weapon.\n\nDespite not belonging within the Gungeon, something about the shifting nature of the Gungeon's depths seems to soothe it.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "serviceweapon_idle_001", 8, "serviceweapon_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(47);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		val.muzzleFlashEffects = VFXToolbox.CreateVFXPool("ServiceWeapon Muzzleflash", new List<string> { "NevernamedsItems/Resources/MiscVFX/GunVFX/ServiceWeapon/serviceweapon_muzzle_001", "NevernamedsItems/Resources/MiscVFX/GunVFX/ServiceWeapon/serviceweapon_muzzle_002", "NevernamedsItems/Resources/MiscVFX/GunVFX/ServiceWeapon/serviceweapon_muzzle_003", "NevernamedsItems/Resources/MiscVFX/GunVFX/ServiceWeapon/serviceweapon_muzzle_004" }, 12, new IntVector2(27, 10), (Anchor)3, usesZHeight: false, 0f, persist: false, (VFXAlignment)0, -1f, null, (WrapMode)2);
		val.muzzleFlashEffects.effects[0].effects[0].attached = false;
		ref ScreenShakeSettings gunScreenShake = ref val.gunScreenShake;
		PickupObject byId2 = PickupObjectDatabase.GetById(47);
		gunScreenShake = ((Gun)((byId2 is Gun) ? byId2 : null)).gunScreenShake;
		PickupObject byId3 = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId3 is Gun) ? byId3 : null), true, false);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).loopStart = 2;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.13f;
		val.DefaultModule.numberOfShotsInClip = -1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(2.0625f, 1.0625f, 0f);
		val.SetBaseMaxAmmo(14);
		val.gunClass = (GunClass)1;
		Projectile val2 = ProjectileUtility.InstantiateAndFakeprefab(val.DefaultModule.projectiles[0]);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 20f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 2f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 2f;
		val2.SetProjectileSprite("serviceweapon_proj", 11, 6, lightened: true, (Anchor)4, 10, 5, anchorChangesCollider: true, fixesScale: false, null, null);
		ref ProjectileImpactVFXPool hitEffects = ref val2.hitEffects;
		PickupObject byId4 = PickupObjectDatabase.GetById(15);
		hitEffects = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.projectiles[0].hitEffects;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Service Weapon Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/serviceweapon_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/serviceweapon_clipempty");
		CustomClipAmmoTypeToolbox.AddCustomAmmoType("Service Weapon Bullets Critical", "NevernamedsItems/Resources/CustomGunAmmoTypes/serviceweapon_critical_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/serviceweapon_critical_clipempty");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		board = VFXToolbox.CreateVFXBundle("TheBoard", usesZHeight: false, 0f, -1f, -1f, null);
	}

	protected override void Update()
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Invalid comparison between Unknown and I4
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner))
		{
			if (critical)
			{
				base.gun.RuntimeModuleData[base.gun.DefaultModule].onCooldown = true;
			}
			if (timeSinceLastFired <= 1.5f)
			{
				if (!base.gun.IsCharging)
				{
					timeSinceLastFired += BraveTime.DeltaTime;
				}
			}
			else if (base.gun.CurrentAmmo < base.gun.AdjustedMaxAmmo)
			{
				float num = 0.15f;
				if ((int)base.gun.DefaultModule.shootStyle == 3)
				{
					num = 0.25f;
				}
				if (timeSinceLastAmmoIncremented <= num)
				{
					timeSinceLastAmmoIncremented += BraveTime.DeltaTime;
				}
				else
				{
					base.gun.GainAmmo(1);
					base.gun.MoveBulletsIntoClip(1);
					timeSinceLastAmmoIncremented = 0f;
				}
			}
			if (critical && base.gun.ClipShotsRemaining == base.gun.ClipCapacity)
			{
				Criticalise(state: false);
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	public void Criticalise(bool state)
	{
		if (critical != state && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			if (state)
			{
				base.gun.DefaultModule.customAmmoType = "Service Weapon Bullets Critical";
				base.gun.RuntimeModuleData[base.gun.DefaultModule].onCooldown = true;
			}
			else
			{
				base.gun.DefaultModule.customAmmoType = "Service Weapon Bullets";
				base.gun.RuntimeModuleData[base.gun.DefaultModule].onCooldown = false;
			}
			ForceUpdateClip(GameUIRoot.Instance.ammoControllers[GunTools.GunPlayerOwner(base.gun).IsPrimaryPlayer ? 1 : 0], GunTools.GunPlayerOwner(base.gun).inventory);
			critical = state;
		}
	}

	private void ForceUpdateClip(GameUIAmmoController controller, GunInventory inv)
	{
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		if (!controller.m_initialized)
		{
			controller.Initialize();
		}
		Gun currentGun = inv.CurrentGun;
		Gun currentSecondaryGun = inv.CurrentSecondaryGun;
		int num = 0;
		for (int i = 0; i < currentGun.Volley.projectiles.Count; i++)
		{
			ProjectileModule val = currentGun.Volley.projectiles[i];
			if (val == currentGun.DefaultModule || (val.IsDuctTapeModule && val.ammoCost > 0))
			{
				num++;
			}
		}
		if (Object.op_Implicit((Object)(object)currentSecondaryGun))
		{
			for (int j = 0; j < currentSecondaryGun.Volley.projectiles.Count; j++)
			{
				ProjectileModule val2 = currentSecondaryGun.Volley.projectiles[j];
				if (val2 == currentSecondaryGun.DefaultModule || (val2.IsDuctTapeModule && val2.ammoCost > 0))
				{
					num++;
				}
			}
		}
		bool flag = (Object)(object)currentGun != (Object)(object)controller.m_cachedGun || currentGun.DidTransformGunThisFrame;
		currentGun.DidTransformGunThisFrame = false;
		controller.CleanupLists(num);
		int num2 = 0;
		int num3 = currentGun.Volley.projectiles.Count;
		if (Object.op_Implicit((Object)(object)currentSecondaryGun))
		{
			num3 += currentSecondaryGun.Volley.projectiles.Count;
		}
		for (int k = 0; k < num3; k++)
		{
			Gun val3 = ((k < currentGun.Volley.projectiles.Count) ? currentGun : currentSecondaryGun);
			int index = ((!((Object)(object)val3 == (Object)(object)currentGun)) ? (k - currentGun.Volley.projectiles.Count) : k);
			ProjectileModule val4 = val3.Volley.projectiles[index];
			if (val4 == val3.DefaultModule || (val4.IsDuctTapeModule && val4.ammoCost > 0))
			{
				controller.EnsureInitialization(num2);
				dfTiledSprite value = controller.fgSpritesForModules[num2];
				dfTiledSprite value2 = controller.bgSpritesForModules[num2];
				List<dfTiledSprite> list = controller.addlFgSpritesForModules[num2];
				List<dfTiledSprite> list2 = controller.addlBgSpritesForModules[num2];
				dfSprite val5 = controller.topCapsForModules[num2];
				dfSprite val6 = controller.bottomCapsForModules[num2];
				AmmoType value3 = controller.cachedAmmoTypesForModules[num2];
				string value4 = controller.cachedCustomAmmoTypesForModules[num2];
				int value5 = controller.m_cachedModuleShotsRemaining[num2];
				controller.UpdateAmmoUIForModule(ref value, ref value2, list, list2, val5, val6, val4, val3, ref value3, ref value4, ref value5, flag, num - (num2 + 1));
				controller.fgSpritesForModules[num2] = value;
				controller.bgSpritesForModules[num2] = value2;
				controller.cachedAmmoTypesForModules[num2] = value3;
				controller.cachedCustomAmmoTypesForModules[num2] = value4;
				controller.m_cachedModuleShotsRemaining[num2] = value5;
				num2++;
			}
		}
		if (!((dfControl)controller.bottomCapsForModules[0]).IsVisible)
		{
			for (int l = 0; l < controller.bgSpritesForModules.Count; l++)
			{
				((dfControl)controller.fgSpritesForModules[l]).IsVisible = true;
				((dfControl)controller.bgSpritesForModules[l]).IsVisible = true;
			}
			for (int m = 0; m < controller.topCapsForModules.Count; m++)
			{
				((dfControl)controller.topCapsForModules[m]).IsVisible = true;
				((dfControl)controller.bottomCapsForModules[m]).IsVisible = true;
			}
		}
		((dfControl)controller.GunClipCountLabel).IsVisible = false;
		controller.m_cachedGun = currentGun;
		controller.m_cachedNumberModules = num;
		controller.m_cachedTotalAmmo = currentGun.CurrentAmmo;
		controller.m_cachedMaxAmmo = currentGun.AdjustedMaxAmmo;
		controller.m_cachedUndertaleness = currentGun.IsUndertaleGun;
		controller.UpdateAdditionalSprites();
	}

	public override void OnSwitchedToThisGun()
	{
		if (critical)
		{
			ForceUpdateClip(GameUIRoot.Instance.ammoControllers[GunTools.GunPlayerOwner(base.gun).IsPrimaryPlayer ? 1 : 0], GunTools.GunPlayerOwner(base.gun).inventory);
		}
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		timeSinceLastFired = 0f;
		timeSinceLastAmmoIncremented = 0f;
		if (base.gun.LastShotIndex == base.gun.ClipCapacity - 1)
		{
			Criticalise(state: true);
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (!base.everPickedUpByPlayer)
		{
			((MonoBehaviour)player).StartCoroutine(DoBoardDialogue(new List<string> { "<This is an unauthorized/unusual/exciting turn of events.>", "<The service weapon is a gun/weapon/you.>", "<Wield the gun/weapon/you well>", "<Welcome to the Bureau, Director/Boss/Head-Honcho>" }, player));
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		((MonoBehaviour)player).StartCoroutine(DoBoardDialogue(new List<string> { "<Please be aware/advised>", "<This action constitutes dereliction of duty/treason/oopsie>", "<Please reconsider/reconcile/change>" }, player));
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public IEnumerator DoBoardDialogue(List<string> text, PlayerController player)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDoBoardDialogue_003Ed__9(0)
		{
			_003C_003E4__this = this,
			text = text,
			player = player
		};
	}
}
