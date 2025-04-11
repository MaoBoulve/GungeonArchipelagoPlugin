using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class VacuumGun : GunBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleEnemySuck_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AIActor target;

		public VacuumGun _003C_003E4__this;

		private Transform _003CcopySprite_003E5__1;

		private Vector3 _003CstartPosition_003E5__2;

		private float _003Celapsed_003E5__3;

		private float _003Cduration_003E5__4;

		private Vector3 _003Cposition_003E5__5;

		private float _003Ct_003E5__6;

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
		public _003CHandleEnemySuck_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CcopySprite_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CcopySprite_003E5__1 = _003C_003E4__this.CreateEmptySprite(target);
				_003CstartPosition_003E5__2 = ((Component)_003CcopySprite_003E5__1).transform.position;
				_003Celapsed_003E5__3 = 0f;
				_003Cduration_003E5__4 = 0.5f;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__3 < _003Cduration_003E5__4)
			{
				_003Celapsed_003E5__3 += BraveTime.DeltaTime;
				if (Object.op_Implicit((Object)(object)((GunBehaviour)_003C_003E4__this).gun) && Object.op_Implicit((Object)(object)_003CcopySprite_003E5__1))
				{
					_003Cposition_003E5__5 = ((GunBehaviour)_003C_003E4__this).gun.PrimaryHandAttachPoint.position;
					_003Ct_003E5__6 = _003Celapsed_003E5__3 / _003Cduration_003E5__4 * (_003Celapsed_003E5__3 / _003Cduration_003E5__4);
					_003CcopySprite_003E5__1.position = Vector3.Lerp(_003CstartPosition_003E5__2, _003Cposition_003E5__5, _003Ct_003E5__6);
					_003CcopySprite_003E5__1.rotation = Quaternion.Euler(0f, 0f, 360f * BraveTime.DeltaTime) * _003CcopySprite_003E5__1.rotation;
					_003CcopySprite_003E5__1.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.1f, 0.1f, 0.1f), _003Ct_003E5__6);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (Object.op_Implicit((Object)(object)_003CcopySprite_003E5__1))
			{
				Object.Destroy((Object)(object)((Component)_003CcopySprite_003E5__1).gameObject);
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

	public static int ID;

	public string[] TargetEnemies;

	public float SuckRadius;

	public static void Add()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Vacuum Gun", "vacuumgun");
		Game.Items.Rename("outdated_gun_mods:vacuum_gun", "nn:vacuum_gun");
		((Component)val).gameObject.AddComponent<VacuumGun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Ranged Weapon");
		GunExt.SetLongDescription((PickupObject)(object)val, "Pressing reload sucks up nearby blobs, and uses them as ammo. Cannot gain ammo by any other method.\n\nDesigned specifically to combat Blobulonian creatures, in the case of a potential re-emergence of the empire.\n\nZZZZZZZ");
		val.SetGunSprites("vacuumgun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(150);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.ammo = 0;
		val.CanGainAmmo = false;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 10000;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.75f, 0.81f, 0f);
		val.SetBaseMaxAmmo(10000);
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		val2.baseData.damage = 30f;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 1f;
		val2.SetProjectileSprite("vacuumgun_projectile", 16, 14, lightened: false, (Anchor)4, 15, 13, anchorChangesCollider: true, fixesScale: false, null, null);
		GoopModifier val3 = ((Component)val2).gameObject.AddComponent<GoopModifier>();
		val3.SpawnGoopInFlight = false;
		val3.SpawnGoopOnCollision = true;
		val3.CollisionSpawnRadius = 2f;
		val3.goopDefinition = EasyGoopDefinitions.BlobulonGoopDef;
		CustomImpactSoundBehav customImpactSoundBehav = ((Component)val2).gameObject.AddComponent<CustomImpactSoundBehav>();
		customImpactSoundBehav.ImpactSFX = "Play_BlobulonDeath";
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Vacuum Gun Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/vacuumgun_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/vacuumgun_clipempty");
		((PickupObject)val).quality = (ItemQuality)2;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.PURCHASED_VACUUMGUN, requiredFlagValue: true);
		((PickupObject)(object)val).AddItemToGooptonMetaShop(16, null);
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)projectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			List<int> list = new List<int>();
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Poisbulonial"))
			{
				list.Add(1);
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Blizzbulonial"))
			{
				list.Add(2);
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.frostBulletsEffect);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Leadbulonial"))
			{
				list.Add(3);
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Poopulonial"))
			{
				list.Add(4);
				projectile.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.tripleCrossbowSlowEffect);
			}
			if (list.Count > 0)
			{
				switch (BraveUtility.RandomElement<int>(list))
				{
				case 1:
					((Component)projectile).gameObject.GetComponent<GoopModifier>().goopDefinition = EasyGoopDefinitions.PoisonDef;
					projectile.damageTypes = (CoreDamageTypes)(projectile.damageTypes | 0x10);
					projectile.AdjustPlayerProjectileTint(ExtendedColours.poisonGreen, 1, 0f);
					break;
				case 2:
					((Component)projectile).gameObject.GetComponent<GoopModifier>().goopDefinition = EasyGoopDefinitions.WaterGoop;
					projectile.damageTypes = (CoreDamageTypes)(projectile.damageTypes | 8);
					projectile.AdjustPlayerProjectileTint(ExtendedColours.skyblue, 1, 0f);
					break;
				case 3:
					((Component)projectile).gameObject.GetComponent<GoopModifier>().goopDefinition = EasyGoopDefinitions.FireDef;
					projectile.damageTypes = (CoreDamageTypes)(projectile.damageTypes | 4);
					projectile.AdjustPlayerProjectileTint(Color.grey, 1, 0f);
					break;
				case 4:
					projectile.AdjustPlayerProjectileTint(ExtendedColours.brown, 1, 0f);
					break;
				}
			}
			if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(projectile), "Bloodbulonial"))
			{
				SpawnProjModifier val = ((Component)projectile).gameObject.AddComponent<SpawnProjModifier>();
				ref Projectile projectileToSpawnOnCollision = ref val.projectileToSpawnOnCollision;
				PickupObject byId = PickupObjectDatabase.GetById(38);
				projectileToSpawnOnCollision = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
				val.PostprocessSpawnedProjectiles = true;
				val.numberToSpawnOnCollison = 10;
				val.spawnOnObjectCollisions = true;
				val.spawnProjecitlesOnDieInAir = true;
				val.spawnProjectilesInFlight = false;
				val.spawnProjectilesOnCollision = true;
				val.randomRadialStartAngle = true;
			}
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
		if (player.CurrentRoom != null)
		{
			player.CurrentRoom.ApplyActionToNearbyEnemies(((GameActor)player).CenterPosition, 8f, (Action<AIActor, float>)ProcessEnemy);
		}
	}

	private void ProcessEnemy(AIActor target, float distance)
	{
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && !((BraveBehaviour)target).healthHaver.IsBoss && AlexandriaTags.HasTag(target, "blobulon"))
		{
			((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(HandleEnemySuck(target));
			target.EraseFromExistence(true);
			Gun gun = base.gun;
			gun.ammo += Math.Max(Mathf.CeilToInt(((BraveBehaviour)target).healthHaver.GetMaxHealth() * 1.5f), 5);
		}
		else if (target.EnemyGuid == EnemyGuidDatabase.Entries["chicken"] && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && CustomSynergies.PlayerHasActiveSynergy((PlayerController)/*isinst with value type is only supported in some contexts*/, "Chickadoo"))
		{
			((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(HandleEnemySuck(target));
			target.EraseFromExistence(true);
			Gun gun2 = base.gun;
			gun2.ammo += 5;
		}
	}

	private IEnumerator HandleEnemySuck(AIActor target)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CHandleEnemySuck_003Ed__5(0)
		{
			_003C_003E4__this = this,
			target = target
		};
	}

	private Transform CreateEmptySprite(AIActor target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("suck image");
		val.layer = ((Component)target).gameObject.layer;
		tk2dSprite val2 = val.AddComponent<tk2dSprite>();
		val.transform.parent = SpawnManager.Instance.VFX;
		((tk2dBaseSprite)val2).SetSprite(((BraveBehaviour)target).sprite.Collection, ((BraveBehaviour)target).sprite.spriteId);
		((BraveBehaviour)val2).transform.position = ((BraveBehaviour)((BraveBehaviour)target).sprite).transform.position;
		GameObject val3 = new GameObject("image parent");
		val3.transform.position = Vector2.op_Implicit(((tk2dBaseSprite)val2).WorldCenter);
		((BraveBehaviour)val2).transform.parent = val3.transform;
		if ((Object)(object)target.optionalPalette != (Object)null)
		{
			((BraveBehaviour)val2).renderer.material.SetTexture("_PaletteTex", (Texture)(object)target.optionalPalette);
		}
		return val3.transform;
	}
}
