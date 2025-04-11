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

public class KillDevil : GunBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSlash_003Ed__8 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController player;

		public Gun gun;

		public KillDevil _003C_003E4__this;

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
		public _003CSlash_003Ed__8(int _003C_003E1__state)
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
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(0.25f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				SlashDoer.DoSwordSlash(Vector2.op_Implicit(gun.CasingLaunchPoint), gun.CurrentAngle, (GameActor)(object)player, SlashData, (Transform)null);
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

	public static int ID;

	public static SlashData SlashData;

	public static ExplosionData MineData;

	public bool MinefieldMode = false;

	public static void Add()
	{
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Kill-Devil", "killdevil");
		Game.Items.Rename("outdated_gun_mods:killdevil", "nn:killdevil");
		((Component)val).gameObject.AddComponent<KillDevil>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Hellbrand");
		GunExt.SetLongDescription((PickupObject)(object)val, "Press reload on a full clip to alternate fire modes. Every part of this gun is designed from the ground up to obliterate the demons found deep within the Gungeon.\n\nFor anyone familiar with demon hunters, it should come as no surprise that it takes its name from Brandy.");
		val.SetGunSprites("killdevil", 8, noAmmonomicon: false, 2);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(81);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		for (int i = 0; i < 5; i++)
		{
			PickupObject byId2 = PickupObjectDatabase.GetById(86);
			GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		}
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(45);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		int num = 1;
		foreach (ProjectileModule projectile in val.Volley.projectiles)
		{
			projectile.ammoCost = ((projectile == val.DefaultModule) ? 1 : 0);
			projectile.shootStyle = (ShootStyle)0;
			projectile.sequenceStyle = (ProjectileSequenceStyle)0;
			projectile.cooldownTime = 0.66f;
			projectile.angleVariance = 33f;
			projectile.numberOfShotsInClip = 3;
			Projectile val2 = ProjectileSetupUtility.MakeProjectile(86, 5f, 5 + num, 30f);
			ProjectileBuilders.AnimateProjectileBundle(val2, "KillDevilProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "KillDevilProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(9, 9), 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList((IntVector2?)new IntVector2(7, 7), 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
			CustomVFXTrail customVFXTrail = ((Component)val2).gameObject.AddComponent<CustomVFXTrail>();
			customVFXTrail.timeBetweenSpawns = 0.15f;
			customVFXTrail.anchor = CustomVFXTrail.Anchor.Center;
			customVFXTrail.VFX = VFXToolbox.CreateBlankVFXPool(VFXToolbox.CreateVFXBundle("TinyBluePoof", usesZHeight: false, 0f, -1f, -1f, null), isDebris: true);
			customVFXTrail.heightOffset = -1f;
			val2.baseData.UsesCustomAccelerationCurve = true;
			val2.baseData.AccelerationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			((Object)((Component)val2).gameObject).name = "KillDevilProj";
			ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)val2).gameObject);
			orAddComponent.doExplosion = true;
			orAddComponent.explosionData = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
			orAddComponent.explosionData.damageRadius = 2f;
			orAddComponent.explosionData.damage = 15f;
			orAddComponent.explosionData.effect = SharedVFX.KillDevilExplosion;
			orAddComponent.explosionData.pushRadius = 0.2f;
			val2.hitEffects.overrideMidairDeathVFX = SharedVFX.BlueLaserCircleVFX;
			val2.hitEffects.alwaysUseMidair = true;
			val2.BlackPhantomDamageMultiplier = 3f;
			projectile.projectiles[0] = val2;
			num++;
		}
		val.AddShellCasing(1, 1, 0, 0, "shell_killdevil");
		val.AddClipSprites("killdevil");
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		val.Volley.UsesShotgunStyleVelocityRandomizer = true;
		val.reloadTime = 1.5f;
		val.SetBarrel(55, 25);
		val.SetBaseMaxAmmo(50);
		val.gunClass = (GunClass)45;
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)2, 1f);
		ID = ((PickupObject)val).PickupObjectId;
		SlashData = ScriptableObject.CreateInstance<SlashData>();
		SlashData.damage = 20f;
		SlashData.damagesBreakables = true;
		SlashData.doHitVFX = true;
		SlashData.doVFX = false;
		SlashData.enemyKnockbackForce = 10f;
		SlashData.jammedDamageMult = 3f;
		SlashData.playerKnockbackForce = 0f;
		SlashData.slashDegrees = 25f;
		SlashData.slashRange = 1.6f;
		SlashData.soundEvent = "Play_WPN_blasphemy_shot_01";
		MineData = StaticExplosionDatas.explosiveRoundsExplosion.CopyExplosionData();
		MineData.damageRadius = 4f;
		MineData.damage = 15f;
		MineData.effect = SharedVFX.KillDevilExplosion;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		if (MinefieldMode && ((Object)((Component)projectile).gameObject).name.Contains("KillDevilProj"))
		{
			SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)projectile).gameObject.AddComponent<SlowDownOverTimeModifier>();
			slowDownOverTimeModifier.timeToSlowOver = 0.75f;
			slowDownOverTimeModifier.targetSpeed = 0.01f;
			projectile.baseData.range = 1000f;
			((Component)projectile).gameObject.AddComponent<DieWhenOwnerNotInRoom>();
			((Component)projectile).GetComponent<ExplosiveModifier>().explosionData = MineData;
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manual)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		if ((Object.op_Implicit((Object)(object)player) & Object.op_Implicit((Object)(object)gun)) && manual && gun.ClipShotsRemaining == gun.ClipCapacity)
		{
			MinefieldMode = !MinefieldMode;
			VFXToolbox.DoRisingStringFade(MinefieldMode ? "MINEFIELD MODE" : "BLAST MODE", ((BraveBehaviour)player).specRigidbody.UnitTopCenter + new Vector2(0f, 1f), Color32.op_Implicit(new Color32((byte)149, (byte)197, (byte)246, byte.MaxValue)));
			AkSoundEngine.PostEvent("Play_OBJ_power_up_01", ((Component)player).gameObject);
		}
		((GunBehaviour)this).OnReloadPressed(player, gun, manual);
	}

	public override void OnReloadedPlayer(PlayerController owner, Gun gun)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		SlashDoer.DoSwordSlash(Vector2.op_Implicit(gun.barrelOffset.position), gun.CurrentAngle, (GameActor)(object)owner, SlashData, (Transform)null);
		((GunBehaviour)this).OnReloadedPlayer(owner, gun);
	}

	private IEnumerator Slash(PlayerController player, Gun gun)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSlash_003Ed__8(0)
		{
			_003C_003E4__this = this,
			player = player,
			gun = gun
		};
	}
}
