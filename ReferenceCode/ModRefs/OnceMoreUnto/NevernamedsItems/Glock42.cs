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

public class Glock42 : AdvancedGunBehavior
{
	[CompilerGenerated]
	private sealed class _003CUnstealthy_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Glock42 _003C_003E4__this;

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
		public _003CUnstealthy_003Ed__5(int _003C_003E1__state)
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
				_003C_003E2__current = (object)new WaitForSeconds(0.15f);
				_003C_003E1__state = 1;
				return true;
			case 1:
			{
				_003C_003E1__state = -1;
				GameActor currentOwner = ((AdvancedGunBehavior)_003C_003E4__this).gun.CurrentOwner;
				((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).OnDidUnstealthyAction += _003C_003E4__this.BreakStealth;
				return false;
			}
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

	public static int Glock42ID;

	public static void Add()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Glock 42", "glock42");
		Game.Items.Rename("outdated_gun_mods:glock_42", "nn:glock_42");
		((Component)val).gameObject.AddComponent<Glock42>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Discrete Sidearm");
		GunExt.SetLongDescription((PickupObject)(object)val, "A simple firearm designed for easy concealment.");
		GunInt.SetupSprite(val, Initialisation.gunCollection, "glock42_idle_001", 8, "glock42_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(79);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.5f;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.angleVariance = 16f;
		val.DefaultModule.numberOfShotsInClip = 5;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(79);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 0.5f, 0f);
		val.SetBaseMaxAmmo(200);
		val.ammo = 200;
		val.gunClass = (GunClass)55;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.4f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 0.6f;
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		Glock42ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile.Owner) && projectile.Owner is PlayerController)
		{
			if (Random.value <= 0.33f && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Song of my people"))
			{
				projectile.AdjustPlayerProjectileTint(ExtendedColours.charmPink, 2, 0f);
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect);
			}
			GameActor owner = projectile.Owner;
			if (CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((owner is PlayerController) ? owner : null), "Life, The Universe, and Everything"))
			{
				ProjectileData baseData = projectile.baseData;
				baseData.damage *= 2f;
				HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)projectile).gameObject);
				orAddComponent.HomingRadius = 1000f;
			}
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}

	public override void OnReloadSafe(PlayerController player, Gun gun)
	{
		if (gun.ClipShotsRemaining == 0 && Random.value <= 0.5f && CustomSynergies.PlayerHasActiveSynergy(player, "Concealed Carry"))
		{
			StealthEffect();
		}
		((AdvancedGunBehavior)this).OnReloadSafe(player, gun);
	}

	private void StealthEffect()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		BreakStealth(val);
		val.OnItemStolen += BreakStealthOnSteal;
		val.ChangeSpecialShaderFlag(1, 1f);
		((BraveBehaviour)val).healthHaver.OnDamaged += new OnDamagedEvent(OnDamaged);
		((GameActor)val).SetIsStealthed(true, "glock42");
		val.SetCapableOfStealing(true, "glock42", (float?)null);
		((MonoBehaviour)GameManager.Instance).StartCoroutine(Unstealthy());
	}

	private IEnumerator Unstealthy()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CUnstealthy_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
	{
		GameActor currentOwner = base.gun.CurrentOwner;
		BreakStealth((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		if (((GameActor)player).IsStealthed)
		{
			BreakStealth(player);
		}
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			BreakStealth((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	private void BreakStealthOnSteal(PlayerController arg1, ShopItemController arg2)
	{
		BreakStealth(arg1);
	}

	private void BreakStealth(PlayerController player)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		player.ChangeSpecialShaderFlag(1, 0f);
		player.OnItemStolen -= BreakStealthOnSteal;
		((GameActor)player).SetIsStealthed(false, "glock42");
		((BraveBehaviour)player).healthHaver.OnDamaged -= new OnDamagedEvent(OnDamaged);
		player.SetCapableOfStealing(false, "glock42", (float?)null);
		player.OnDidUnstealthyAction -= BreakStealth;
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
	}
}
