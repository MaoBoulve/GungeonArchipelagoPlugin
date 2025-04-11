using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Pinaka : AdvancedGunBehavior
{
	public class PinakaRailgun : MonoBehaviour
	{
		public Projectile self;

		private void Start()
		{
			self = ((Component)this).GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)self))
			{
				self.OnDestruction += OnDestroy;
			}
		}

		private void OnDestroy(Projectile me)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			Vector2 safeCenter = self.SafeCenter;
			RoomHandler absoluteRoom = ProjectileUtility.GetAbsoluteRoom(self);
			if (absoluteRoom == null)
			{
				return;
			}
			List<AIActor> activeEnemies = absoluteRoom.GetActiveEnemies((ActiveEnemyType)1);
			if (activeEnemies == null)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				if (activeEnemies.Count <= 0)
				{
					continue;
				}
				AIActor nearestActor = GetNearestActor(activeEnemies, safeCenter);
				if (!((Object)(object)nearestActor != (Object)null))
				{
					continue;
				}
				activeEnemies.Remove(nearestActor);
				GameObject val = ProjectileUtility.InstantiateAndFireTowardsPosition(Bejeweler.railgun, safeCenter, ((GameActor)nearestActor).CenterPosition, 0f, 0f, (PlayerController)null);
				Projectile component = val.GetComponent<Projectile>();
				if (Object.op_Implicit((Object)(object)component))
				{
					component.Owner = me.Owner;
					component.Shooter = me.Shooter;
					if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(me)))
					{
						component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(me));
						ProjectileUtility.ProjectilePlayerOwner(me).DoPostProcessProjectile(component);
					}
					component.RenderTilePiercingForSeconds(0.1f);
				}
			}
		}

		private AIActor GetNearestActor(List<AIActor> enemies, Vector2 pos)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			AIActor result = null;
			float num = float.MaxValue;
			foreach (AIActor enemy in enemies)
			{
				float num2 = Vector2.Distance(Vector2.op_Implicit(enemy.Position), pos);
				if (num2 < num)
				{
					result = enemy;
					num = num2;
				}
			}
			return result;
		}
	}

	public static int ID;

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pinaka", "pinaka");
		Game.Items.Rename("outdated_gun_mods:pinaka", "nn:pinaka");
		Pinaka pinaka = ((Component)val).gameObject.AddComponent<Pinaka>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Restored");
		GunExt.SetLongDescription((PickupObject)(object)val, "An ancient and powerful divine weapon, broken and cast aside to win the hand of a Goddess in marriage.\n\nThough much of its power was lost when it was splintered in two, the weapon has slowly healed deep within the Gungeons chambers, awaiting a new master.");
		val.SetGunSprites("pinaka", 8, noAmmonomicon: false, 2);
		PickupObject byId = PickupObjectDatabase.GetById(12);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		GunExt.SetAnimationFPS(val, val.chargeAnimation, 16);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.chargeAnimation).loopStart = 6;
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 10);
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.reloadAnimation).wrapMode = (WrapMode)0;
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(8);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)3;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 1f;
		val.DefaultModule.angleVariance = 0f;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(210);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.DefaultModule.numberOfShotsInClip = 1;
		val.SetBarrel(30, 25);
		val.SetBaseMaxAmmo(30);
		val.ammo = 30;
		val.carryPixelOffset = new IntVector2(10, 0);
		val.gunClass = (GunClass)60;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 20f);
		val2.baseData.speed = 35f;
		val2.baseData.range = 1000f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "PinakaProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "PinakaProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(23, 5), 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList<Anchor>((Anchor)4, 3), MiscTools.DupeList(value: true, 3), MiscTools.DupeList(value: false, 3), MiscTools.DupeList<Vector3?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<IntVector2?>(null, 3), MiscTools.DupeList<Projectile>(null, 3));
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration++;
		orAddComponent.penetratesBreakables = true;
		ref GameObject overrideMidairDeathVFX = ref val2.hitEffects.overrideMidairDeathVFX;
		PickupObject byId4 = PickupObjectDatabase.GetById(8);
		overrideMidairDeathVFX = ((Gun)((byId4 is Gun) ? byId4 : null)).DefaultModule.chargeProjectiles[1].Projectile.hitEffects.enemy.effects[0].effects[0].effect;
		val2.hitEffects.alwaysUseMidair = true;
		GameObjectExtensions.GetOrAddComponent<PinakaRailgun>(((Component)val2).gameObject);
		ChargeProjectile item = new ChargeProjectile
		{
			Projectile = val2,
			ChargeTime = 0.5f
		};
		val.DefaultModule.chargeProjectiles = new List<ChargeProjectile> { item };
		val.AddClipSprites("pinaka");
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
		ID = ((PickupObject)val).PickupObjectId;
	}
}
