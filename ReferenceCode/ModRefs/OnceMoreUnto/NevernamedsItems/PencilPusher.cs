using System.Collections.Generic;
using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class PencilPusher : GunBehaviour
{
	public class PencilSketcher : BraveBehaviour
	{
		private float time = 0f;

		private void Update()
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).projectile))
			{
				return;
			}
			if (time > 0.0001f)
			{
				Projectile component = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)pencilSketch).gameObject, Vector2.op_Implicit(((BraveBehaviour)this).transform.Find("PencilTip").position), ((BraveBehaviour)this).projectile.Direction).GetComponent<Projectile>();
				component.Shooter = ((BraveBehaviour)this).projectile.Shooter;
				component.Owner = ((BraveBehaviour)this).projectile.Owner;
				if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)this).projectile)))
				{
					component.ScaleByPlayerStats(ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)this).projectile));
				}
			}
			else
			{
				time += BraveTime.DeltaTime;
			}
		}
	}

	public static int ID;

	public static Projectile pencilSketch;

	public static void Add()
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_0392: Expected O, but got Unknown
		//IL_039e: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Pencil Pusher", "pencilpusher");
		Game.Items.Rename("outdated_gun_mods:pencil_pusher", "nn:pencil_pusher");
		((Component)val).gameObject.AddComponent<PencilPusher>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Official");
		GunExt.SetLongDescription((PickupObject)(object)val, "Launches pencils.\n\nThis ill-advised device is the result of inter-office warfare taken too far.");
		val.SetGunSprites("pencilpusher", 8, noAmmonomicon: false, 2);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		GunExt.SetAnimationFPS(val, val.reloadAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(56);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(806);
		gunSwitchGroup = ((Gun)((byId2 is Gun) ? byId2 : null)).gunSwitchGroup;
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 0.7f;
		val.DefaultModule.cooldownTime = 0.4f;
		val.DefaultModule.numberOfShotsInClip = 1;
		val.SetBarrel(28, 16);
		val.SetBaseMaxAmmo(70);
		val.gunClass = (GunClass)15;
		Projectile val2 = ProjectileSetupUtility.MakeProjectile(56, 20f);
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 1.3f;
		GameObject val3 = new GameObject("PencilTip");
		val3.transform.SetParent(((BraveBehaviour)val2).transform);
		val3.transform.localPosition = new Vector3(1.3125f, 0.1875f, 0f);
		GameObjectExtensions.GetOrAddComponent<PencilSketcher>(((Component)val2).gameObject);
		ProjectileBuilders.AnimateProjectileBundle(val2, "PencilPusherProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "PencilPusherProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(22, 5), 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Anchor>((Anchor)4, 5), MiscTools.DupeList(value: true, 5), MiscTools.DupeList(value: false, 5), MiscTools.DupeList<Vector3?>(null, 5), MiscTools.DupeList((IntVector2?)new IntVector2(20, 3), 5), MiscTools.DupeList<IntVector2?>(null, 5), MiscTools.DupeList<Projectile>(null, 5));
		val2.hitEffects.deathTileMapHorizontal = VFXToolbox.CreateVFXPoolBundle("PencilPusherImpactHoriz", usesZHeight: false, 0f, (VFXAlignment)1, -1f, null, persist: true);
		val2.hitEffects.deathTileMapVertical = VFXToolbox.CreateVFXPoolBundle("PencilPusherImpactVert", usesZHeight: false, 0f, (VFXAlignment)1, -1f, null, persist: true);
		VFXPool deathEnemy = new VFXPool
		{
			type = (VFXPoolType)1,
			effects = new List<VFXComplex>
			{
				new VFXComplex
				{
					effects = new List<VFXObject>
					{
						new VFXObject
						{
							attached = true,
							persistsOnDeath = true,
							usesZHeight = false,
							zHeight = 0f,
							alignment = (VFXAlignment)2,
							destructible = false,
							orphaned = true,
							effect = ((Component)Breakables.GenerateDebrisObject(Initialisation.GunDressingCollection, "pencilpusher_debris_001", debrisObjectsCanRotate: true, 1f, 1f, 45f, 20f)).gameObject
						},
						new VFXObject
						{
							attached = true,
							persistsOnDeath = true,
							usesZHeight = false,
							zHeight = 0f,
							alignment = (VFXAlignment)2,
							destructible = false,
							orphaned = true,
							effect = ((Component)Breakables.GenerateDebrisObject(Initialisation.GunDressingCollection, "pencilpusher_debris_002", debrisObjectsCanRotate: true, 1f, 1f, 45f, 20f)).gameObject
						}
					}.ToArray()
				}
			}.ToArray()
		};
		val2.hitEffects.HasProjectileDeathVFX = true;
		val2.hitEffects.deathEnemy = deathEnemy;
		val.DefaultModule.projectiles[0] = val2;
		val.carryPixelOffset = new IntVector2(8, -2);
		val.carryPixelDownOffset = new IntVector2(-6, 0);
		val.carryPixelUpOffset = new IntVector2(-6, 0);
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(12);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		val.gunHandedness = (GunHandedness)0;
		val.AddClipSprites("pencilpusher");
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
		ID = ((PickupObject)val).PickupObjectId;
		pencilSketch = ProjectileSetupUtility.MakeProjectile(86, 0.5f);
		pencilSketch.objectImpactEventName = null;
		pencilSketch.enemyImpactEventName = null;
		pencilSketch.onDestroyEventName = null;
		pencilSketch.additionalStartEventName = null;
		ProjectileData baseData2 = pencilSketch.baseData;
		baseData2.force *= 0.1f;
		ProjectileData baseData3 = pencilSketch.baseData;
		baseData3.speed *= 0.0001f;
		pencilSketch.SetProjectileSprite("pencil_projectile", 4, 4, lightened: false, (Anchor)0, null, null, anchorChangesCollider: true, fixesScale: false, null, null);
		pencilSketch.hitEffects.enemy = null;
		pencilSketch.hitEffects.tileMapHorizontal = null;
		pencilSketch.hitEffects.tileMapVertical = null;
		pencilSketch.hitEffects.deathTileMapVertical = null;
		pencilSketch.hitEffects.deathTileMapHorizontal = null;
		pencilSketch.hitEffects.overrideMidairDeathVFX = null;
		GameObjectExtensions.GetOrAddComponent<DieWhenOwnerNotInRoom>(((Component)pencilSketch).gameObject);
	}
}
