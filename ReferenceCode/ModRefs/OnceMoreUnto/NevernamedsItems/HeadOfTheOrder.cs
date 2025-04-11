using Alexandria.Assetbundle;
using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class HeadOfTheOrder : AdvancedGunBehavior
{
	public static int HeadOfTheOrderID;

	public static void Add()
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Head of the Order", "headoftheorder");
		Game.Items.Rename("outdated_gun_mods:head_of_the_order", "nn:head_of_the_order");
		HeadOfTheOrder headOfTheOrder = ((Component)val).gameObject.AddComponent<HeadOfTheOrder>();
		((AdvancedGunBehavior)headOfTheOrder).preventNormalFireAudio = true;
		((AdvancedGunBehavior)headOfTheOrder).overrideNormalFireAudio = "Play_ENM_highpriest_blast_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Guns, Immortal");
		GunExt.SetLongDescription((PickupObject)(object)val, "Though torn from the rest of it's corporeal form, the immortal soul of the High Priest remains bound to this weapon.");
		ItemBuilder.AddPassiveStatModifier((PickupObject)(object)val, (StatType)14, 1f, (ModifyMethod)0);
		GunInt.SetupSprite(val, Initialisation.gunCollection, "headoftheorder_idle_001", 8, "headoftheorder_ammonomicon_001");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 10);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(79);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)1;
		val.reloadTime = 2f;
		val.DefaultModule.cooldownTime = 0.65f;
		val.DefaultModule.numberOfShotsInClip = 6;
		ref VFXPool muzzleFlashEffects = ref val.muzzleFlashEffects;
		PickupObject byId3 = PickupObjectDatabase.GetById(79);
		muzzleFlashEffects = ((Gun)((byId3 is Gun) ? byId3 : null)).muzzleFlashEffects;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.62f, 0.75f, 0f);
		val.SetBaseMaxAmmo(100);
		val.ammo = 100;
		val.gunClass = (GunClass)1;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 6f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.force *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 2f;
		val2.pierceMinorBreakables = true;
		HomingModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<HomingModifier>(((Component)val2).gameObject);
		orAddComponent.HomingRadius = 20f;
		orAddComponent.AngularVelocity = 400f;
		ProjectileBuilders.AnimateProjectileBundle(val2, "HeadOfTheOrderProjectile", Initialisation.ProjectileCollection, Initialisation.projectileAnimationCollection, "HeadOfTheOrderProjectile", MiscTools.DupeList<IntVector2>(new IntVector2(24, 20), 10), MiscTools.DupeList(value: true, 10), MiscTools.DupeList<Anchor>((Anchor)4, 10), MiscTools.DupeList(value: true, 10), MiscTools.DupeList(value: false, 10), MiscTools.DupeList<Vector3?>(null, 10), MiscTools.DupeList((IntVector2?)new IntVector2(8, 8), 10), MiscTools.DupeList<IntVector2?>(null, 10), MiscTools.DupeList<Projectile>(null, 10));
		val.DefaultModule.projectiles[0] = val2;
		((PickupObject)val).quality = (ItemQuality)5;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		HeadOfTheOrderID = ((PickupObject)val).PickupObjectId;
	}

	protected override void Update()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Non Desistas Non Exieris") && base.gun.reloadTime == 2f)
			{
				base.gun.reloadTime = 1f;
				base.gun.SetBaseMaxAmmo(200);
				base.gun.DefaultModule.cooldownTime = 0.4f;
			}
			else if (!CustomSynergies.PlayerHasActiveSynergy(val, "Non Desistas Non Exieris") && base.gun.reloadTime == 1f)
			{
				base.gun.reloadTime = 2f;
				base.gun.SetBaseMaxAmmo(100);
				base.gun.DefaultModule.cooldownTime = 0.65f;
			}
			val.stats.RecalculateStats(val, true, false);
		}
		((AdvancedGunBehavior)this).Update();
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			RemoveFlight((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	public override void OnSwitchedToThisGun()
	{
		if (Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			GiveFlight((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
		((AdvancedGunBehavior)this).OnSwitchedToThisGun();
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		GiveFlight(player);
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		RemoveFlight(player);
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			RemoveFlight((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null));
		}
		((BraveBehaviour)this).OnDestroy();
	}

	private void GiveFlight(PlayerController playerController)
	{
		((GameActor)playerController).SetIsFlying(true, "HeadOfTheOrder", true, false);
		playerController.AdditionalCanDodgeRollWhileFlying.AddOverride("HeadOfTheOrder", (float?)null);
	}

	private void RemoveFlight(PlayerController playerController)
	{
		((GameActor)playerController).SetIsFlying(false, "HeadOfTheOrder", true, false);
		playerController.AdditionalCanDodgeRollWhileFlying.RemoveOverride("HeadOfTheOrder");
	}
}
