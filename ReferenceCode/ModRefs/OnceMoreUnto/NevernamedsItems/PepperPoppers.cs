using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class PepperPoppers : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CDelayedPep_003Ed__4 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Projectile sourceProjectile;

		public float effectChanceScalar;

		public PepperPoppers _003C_003E4__this;

		private float _003Cchance_003E5__1;

		private Projectile _003CinstancePopper_003E5__2;

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
		public _003CDelayedPep_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CinstancePopper_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
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
				_003Cchance_003E5__1 = 0.1f;
				if (Object.op_Implicit((Object)(object)sourceProjectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile)))
				{
					if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(sourceProjectile), "Pepper X"))
					{
						_003Cchance_003E5__1 = 0.15f;
					}
					_003Cchance_003E5__1 *= effectChanceScalar;
					if (Random.value <= _003Cchance_003E5__1)
					{
						_003CinstancePopper_003E5__2 = ProjectileUtility.InstantiateAndFireInDirection(PopperProjectile, Vector2.op_Implicit(((BraveBehaviour)sourceProjectile).transform.position), Vector2Extensions.ToAngle(sourceProjectile.Direction), 5f, ProjectileUtility.ProjectilePlayerOwner(sourceProjectile)).GetComponent<Projectile>();
						_003CinstancePopper_003E5__2.Owner = (GameActor)(object)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile);
						_003CinstancePopper_003E5__2.Shooter = ((BraveBehaviour)ProjectileUtility.ProjectilePlayerOwner(sourceProjectile)).specRigidbody;
						if (CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(sourceProjectile), "Pepper X"))
						{
							((PassiveItem)_003C_003E4__this).Owner.DoPostProcessProjectile(_003CinstancePopper_003E5__2);
						}
						_003CinstancePopper_003E5__2 = null;
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

	public static Projectile PopperProjectile;

	public static GameObject genericPopper;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<PepperPoppers>("Pepper Poppers", "Popping Off", "Launches young Gungeon Peppers.\n\nA spicy dish of stuffed Gungeon Peppers, and an important part of the Gungeon Pepper life cycle.", "pepperpoppers_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		genericPopper = BuildPrefab();
		PickupObject byId = PickupObjectDatabase.GetById(56);
		PopperProjectile = ProjectileUtility.InstantiateAndFakeprefab(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		PopperProjectile.baseData.damage = 5f;
		ProjectileData baseData = PopperProjectile.baseData;
		baseData.speed *= 0.6f;
		PopperProjectile.SetProjectileSprite("popperproj_1", 16, 7, lightened: false, (Anchor)4, 16, 7, anchorChangesCollider: true, fixesScale: false, null, null);
		SpawnObjectBehaviour spawnObjectBehaviour = ((Component)PopperProjectile).gameObject.AddComponent<SpawnObjectBehaviour>();
		spawnObjectBehaviour.objectToSpawn = genericPopper;
		ProjectileBuilders.AnimateProjectileBundle(PopperProjectile, "PepperPopperProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "PepperPopperProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(16, 7), 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Anchor>((Anchor)4, 4), MiscTools.DupeList(value: true, 4), MiscTools.DupeList(value: false, 4), MiscTools.DupeList<Vector3?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<IntVector2?>(null, 4), MiscTools.DupeList<Projectile>(null, 4));
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		((MonoBehaviour)this).StartCoroutine(DelayedPep(sourceProjectile, effectChanceScalar));
	}

	private IEnumerator DelayedPep(Projectile sourceProjectile, float effectChanceScalar)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDelayedPep_003Ed__4(0)
		{
			_003C_003E4__this = this,
			sourceProjectile = sourceProjectile,
			effectChanceScalar = effectChanceScalar
		};
	}

	private void PostProcessBeamChanceTick(BeamController beam)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)beam) && Object.op_Implicit((Object)(object)((BraveBehaviour)beam).projectile) && Random.value <= 0.1f && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile)))
		{
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(PopperProjectile, beam.Origin, Vector2Extensions.ToAngle(beam.Direction), 5f, ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile)).GetComponent<Projectile>();
			component.Owner = (GameActor)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile);
			component.Shooter = ((BraveBehaviour)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)beam).projectile)).specRigidbody;
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessBeamChanceTick += PostProcessBeamChanceTick;
		player.PostProcessProjectile += PostProcessProjectile;
	}

	public override void DisableEffect(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeamChanceTick -= PostProcessBeamChanceTick;
		((PassiveItem)this).DisableEffect(player);
	}

	public static GameObject BuildPrefab()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		GameObject val = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_idle_001.png", new GameObject("Popper"), (Assembly)null);
		val.SetActive(false);
		FakePrefab.MarkAsFakePrefab(val);
		tk2dSpriteAnimator val2 = val.AddComponent<tk2dSpriteAnimator>();
		PickupObject byId = PickupObjectDatabase.GetById(108);
		tk2dSpriteCollectionData spriteCollection = ((SpawnObjectPlayerItem)((byId is SpawnObjectPlayerItem) ? byId : null)).objectToSpawn.GetComponent<tk2dSpriteAnimator>().Library.clips[0].frames[0].spriteCollection;
		tk2dSpriteAnimationClip val3 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_003.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_004.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_005.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_006.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_007.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_008.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_deactivate_009.png", spriteCollection, (Assembly)null)
		}, "popper_deactivate", (WrapMode)1, 15f);
		val3.fps = 12f;
		val3.loopStart = 8;
		tk2dSpriteAnimationClip val4 = SpriteBuilder.AddAnimation(val2, spriteCollection, new List<int>
		{
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_idle_001.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_idle_002.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_idle_003.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_idle_004.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_idle_005.png", spriteCollection, (Assembly)null),
			SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/ThrowableActives/PepperPopper/popper_idle_006.png", spriteCollection, (Assembly)null)
		}, "popper_idle", (WrapMode)0, 15f);
		val4.fps = 12f;
		val2.DefaultClipId = val2.GetClipIdByName("popper_idle");
		val2.playAutomatically = true;
		val.AddComponent<PopperController>();
		return val;
	}
}
