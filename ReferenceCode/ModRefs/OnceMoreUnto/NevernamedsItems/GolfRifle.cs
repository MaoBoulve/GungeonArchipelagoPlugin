using Alexandria.ItemAPI;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GolfRifle : AdvancedGunBehavior
{
	public static int GolfRifleID;

	private bool GaveFlight;

	private bool hasBirdieNow;

	private bool hadBirdieLastWeChecked;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Golf Rifle", "golfrifle");
		Game.Items.Rename("outdated_gun_mods:golf_rifle", "nn:golf_rifle");
		((Component)val).gameObject.AddComponent<GolfRifle>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Bullet Hole In 1");
		GunExt.SetLongDescription((PickupObject)(object)val, "Golf is a popular game among the Gundead of the Keep, though it's rules are very peculiar to outsiders.\n\nThere's a lot more violence involved.");
		val.SetGunSprites("golfrifle");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.3f;
		val.DefaultModule.numberOfShotsInClip = 8;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(3f, 0.43f, 0f);
		val.SetBaseMaxAmmo(200);
		val.gunClass = (GunClass)15;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 1.2f;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetratesBreakables = true;
		orAddComponent.penetration += 30;
		BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)val2).gameObject);
		orAddComponent2.numberOfBounces = 30;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 60f;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		val2.SetProjectileSprite("golfrifle_projectile", 7, 7, lightened: false, (Anchor)4, 6, 6, anchorChangesCollider: true, fixesScale: false, null, null);
		((PickupObject)val).quality = (ItemQuality)2;
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Golf Rifle";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		GolfRifleID = ((PickupObject)val).PickupObjectId;
	}

	private void changedGun(Gun oldGun, Gun newGun, bool what)
	{
		flightCheck(newGun);
	}

	private void flightCheck(Gun currentGun)
	{
		GameActor currentOwner = currentGun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		if ((Object)(object)currentGun == (Object)(object)base.gun && !GaveFlight && CustomSynergies.PlayerHasActiveSynergy(val, "Birdie!"))
		{
			((GameActor)((AdvancedGunBehavior)this).Player).SetIsFlying(true, "GolfBirdie", false, false);
			((AdvancedGunBehavior)this).Player.AdditionalCanDodgeRollWhileFlying.AddOverride("GolfBirdie", (float?)null);
			GaveFlight = true;
		}
		else if (((Object)(object)currentGun != (Object)(object)base.gun || !CustomSynergies.PlayerHasActiveSynergy(val, "Birdie!")) && GaveFlight)
		{
			((GameActor)((AdvancedGunBehavior)this).Player).SetIsFlying(false, "GolfBirdie", false, false);
			((AdvancedGunBehavior)this).Player.AdditionalCanDodgeRollWhileFlying.RemoveOverride("GolfBirdie");
			GaveFlight = false;
		}
	}

	protected override void Update()
	{
		((AdvancedGunBehavior)this).Update();
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		hasBirdieNow = CustomSynergies.PlayerHasActiveSynergy(val, "Birdie!");
		if (hasBirdieNow != hadBirdieLastWeChecked)
		{
			flightCheck(((GameActor)val).CurrentGun);
			hadBirdieLastWeChecked = hasBirdieNow;
		}
	}

	public override void OnReload(PlayerController player, Gun gun)
	{
		((AdvancedGunBehavior)this).OnReload(player, gun);
		flightCheck(gun);
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
		player.GunChanged += changedGun;
		flightCheck(((GameActor)player).CurrentGun);
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		player.GunChanged -= changedGun;
		flightCheck(((GameActor)player).CurrentGun);
		player.stats.RecalculateStats(player, true, false);
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}
}
