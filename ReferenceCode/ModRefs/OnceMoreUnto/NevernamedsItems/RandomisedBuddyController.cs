using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class RandomisedBuddyController : CompanionController
{
	public static tk2dSpriteCollectionData RandomisedBuddyCollection;

	public static tk2dSpriteAnimation RandomCompanionAnimationCollection;

	public static GameObject prefab;

	public static readonly string guid = "randomisedBuddy_abiyykwgdidsi6cx373248873286";

	public static List<string> validForms = new List<string>
	{
		"8bomb", "amogus", "amogusded", "adventurer", "artifactmonger", "apachethunder", "baba", "blinky", "boo", "bunnybullet",
		"birdblue", "birdgreen", "birdpurple", "birdyellow", "blackstache", "blasthelmet", "blocknerghost", "brotheralbern", "bubbleblack", "bulletfrost",
		"bulletshadow", "bulletshockrounds", "buddyalexandria", "buddyandromeda", "buddyantipus", "buddyarrowkin", "buddyaseprite", "buddybattery", "buddybee", "buddybello",
		"buddyblobulon", "buddyblueshotgun", "buddybookllet", "buddybubs", "buddybulletkin", "buddybulletplayer", "buddycompanioncube", "buddydisarmingpersonality", "buddyfairy", "buddyfallenbulletkin",
		"buddyflynt", "buddykyle", "buddymistake", "buddyoldred", "buddypetrock", "buddypig", "buddypoisonvial", "buddypooka", "buddyprismatism", "buddyredshotgun",
		"buddyrobot", "buddyrusty", "buddyshade", "buddyskeleton", "buddyskilotar", "buddyskullet", "buddysnipershell", "buddytentacle", "buddytim", "buddytnt",
		"buddytrorc", "buddywilson", "clickanddrag", "clyde", "crimsonchamber", "cuphead", "cuteghost", "carrot", "chocoboblack", "chocoboyellow",
		"clippy", "clone", "coolbullet", "cooltist", "cosmonaut", "cubeflesh", "cubelead", "cubemountain", "cultist", "cultistgreenapple",
		"cultistorange", "cultistredapple", "cultiststrawberry", "claygod", "crappysword", "defaultman", "darumablue", "darumabrown", "darumared", "decoy",
		"decoyice", "decoypoison", "demonhead", "detex", "detplus", "ddebot1", "ddebot2", "drifloon", "elquilliam", "eyeball",
		"elevatoractionbadguy", "evilcryptbug", "evilcryptdemon", "evilcryptevillord", "evilcryptghost", "evilcryptsnake", "evilcryptspaceman", "evilcrypttreeman", "fygar", "froggy",
		"fuselier", "flemoid", "fredchexter", "freetvs", "ghostsword", "gregtheeggbuddy", "grimora", "glocktorock", "gunslingking", "guongold",
		"guongreen", "guonwhite", "helious", "hitboxdraw", "hologramkin", "hazmat", "hazmatgasmask", "hungryhippo", "inky", "iris",
		"iceogre", "indianajones", "jellyblorb", "jetpackcat", "kingslime", "kernal", "leshy", "labtech", "lala", "lamey",
		"lameyalt", "lasthuman", "lichbullets", "lolo", "looplich", "lowpriest", "lonelywizard", "magnificus", "mainframe", "minesweepersmiley",
		"miru", "mrdonut", "mrmatt", "mrspacman", "magnet", "manny", "marinegray", "marinegreen", "marinered", "marineyellow",
		"marketdoor", "maskred", "mauser", "metroidbaby", "monk", "moogleff4", "mooglemodern", "moon", "mushroom1up", "mushroomlife",
		"mushroomred", "mushroomstar", "mushroomvarg", "meowitzerchievo", "mrmagnum", "nanomachine", "ninja", "notabotclassic", "notabot2000", "oldnevernamed",
		"octorok", "oldblood", "oldknight", "owlskeleton", "p03", "pacman", "perfection", "pinky", "poglizard", "personalityfear",
		"personalityrage", "phanto", "phantogold", "piku", "plasmacube", "peglin", "randal", "revolvenant", "rippy", "rubberjester",
		"sansyskeleton", "scaredghost", "semibot", "settingsbutton", "slenderman", "stickman", "sue", "scientistchilds", "scientistdukes", "sepulchergeist",
		"serenade", "skullred", "snitchbrick", "spaceboy", "spacehole", "spiketrap", "spindrone", "steambot", "stonehead", "sun",
		"skifreeyeti", "spoilsportrobot", "tcboutblue", "tcboutred", "technoblade", "textfilebuddy", "thedreamer", "thepointyone", "thomasthebullet", "turtlemelon",
		"terminator", "tootscraze", "toughguy", "theguyfromelevatoraction", "ufo", "voidcore", "vvvvvv", "wallmongerthing", "whatface", "witch",
		"wolfenclaw", "williethewizard", "wx78", "witchbot", "yumyum"
	};

	public string currentForm = "amogus";

	public bool setUp = false;

	public static List<string> fireSoundEffects = new List<string>
	{
		"Play_WPN_Gun_Shot_01", "Play_WPN_Gun_Shot_02", "Play_WPN_Gun_Shot_03", "Play_WPN_Gun_Shot_04", "Play_WPN_Gun_Shot_05", "Play_WPN_gunhand_shot_01", "Play_WPN_h4mmer_shot_01", "Play_WPN_iceogre_shot_01", "Play_WPN_knav3_shot_01", "Play_WPN_kthulu_blast_01",
		"Play_WPN_lamp_shot_01", "Play_WPN_looper_shot_01", "Play_WPN_m1911_shot_01", "Play_WPN_magnum_shot_01", "Play_WPN_mailbox_shot_01", "Play_WPN_makarov_shot_01", "Play_WPN_megablaster_shot_01", "Play_WPN_minigun_shot_01", "Play_WPN_peashooter_shot_01", "Play_WPN_rustysidearm_shot_01"
	};

	public static List<VFXPool> validMuzzleFlashes = new List<VFXPool>
	{
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects,
		((Gun)/*isinst with value type is only supported in some contexts*/).muzzleFlashEffects
	};

	public float timer = 0f;

	public float reloadTime = 1f;

	public float cooldownTime = 1f;

	public float angleVariance = 5f;

	public int shotsFired = 0;

	public int shotsInClip = 0;

	public VFXPool MuzzleFlash = null;

	public Projectile chosenProjectile = null;

	public string soundEvent = null;

	public override void Update()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		((BraveBehaviour)this).sprite.FlipX = ((GameActor)((BraveBehaviour)this).aiActor).FacingDirection > 90f || ((GameActor)((BraveBehaviour)this).aiActor).FacingDirection < -90f;
		if (((BraveBehaviour)this).aiAnimator.IdleAnimation.AnimNames[0] != currentForm)
		{
			((BraveBehaviour)this).aiAnimator.IdleAnimation.AnimNames[0] = currentForm;
			((BraveBehaviour)this).aiAnimator.IdleAnimation.AnimNames[1] = currentForm;
		}
		if ((Object)(object)((BraveBehaviour)this).aiActor.TargetRigidbody != (Object)null && Vector2.Distance(((BraveBehaviour)this).aiActor.TargetRigidbody.UnitCenter, ((BraveBehaviour)this).specRigidbody.UnitCenter) <= 9f)
		{
			if (timer <= 0f)
			{
				Fire();
				shotsFired++;
				if (shotsFired >= shotsInClip)
				{
					timer = reloadTime;
					shotsFired = 0;
				}
				else
				{
					timer = cooldownTime;
				}
			}
			else
			{
				timer -= BraveTime.DeltaTime;
			}
		}
		((CompanionController)this).Update();
	}

	public void Fire()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = BraveMathCollege.ClosestPointOnRectangle(((BraveBehaviour)this).aiActor.TargetRigidbody.UnitCenter, ((BraveBehaviour)this).specRigidbody.UnitBottomLeft, ((BraveBehaviour)this).specRigidbody.UnitDimensions);
		Vector2 val2 = MathsAndLogicHelper.CalculateVectorBetween(val, ((Object)(object)((BraveBehaviour)((BraveBehaviour)this).aiActor.TargetRigidbody).aiActor != (Object)null) ? ((GameActor)((BraveBehaviour)((BraveBehaviour)this).aiActor.TargetRigidbody).aiActor).CenterPosition : ((BraveBehaviour)this).aiActor.TargetRigidbody.UnitCenter);
		float num = Vector2Extensions.ToAngle(val2);
		if (MuzzleFlash != null)
		{
			MuzzleFlash.SpawnAtPosition(Vector2.op_Implicit(val), num, ((BraveBehaviour)this).transform, (Vector2?)null, (Vector2?)null, (float?)null, false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
		}
		if (!string.IsNullOrEmpty(soundEvent))
		{
			AkSoundEngine.PostEvent(soundEvent, ((Component)this).gameObject);
		}
		if ((Object)(object)chosenProjectile != (Object)null)
		{
			Projectile component = ProjectileUtility.InstantiateAndFireInDirection(chosenProjectile, val, Vector2Extensions.ToAngle(val2), angleVariance, (PlayerController)null).GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)component) && Object.op_Implicit((Object)(object)base.m_owner))
			{
				component.Owner = (GameActor)(object)base.m_owner;
				component.Shooter = ((BraveBehaviour)base.m_owner).specRigidbody;
				component.ScaleByPlayerStats(base.m_owner);
				ProjectileUtility.ApplyCompanionModifierToBullet(component, base.m_owner);
				base.m_owner.DoPostProcessProjectile(component);
			}
		}
	}

	private void Start()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		LootEngine.DoDefaultPurplePoof(((BraveBehaviour)this).gameActor.CenterPosition, false);
		if (!setUp)
		{
			ETGModConsole.Log((object)"NOTSETUP", false);
		}
	}

	public static void Init()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		RandomisedBuddyCollection = AssetBundleLoader.FastLoadSpriteCollection(Initialisation.assetBundle, "RandomCompanionCollection", "RandomCompanionCollectionMaterial.mat");
		RandomCompanionAnimationCollection = Initialisation.assetBundle.LoadAsset<GameObject>("RandomCompanionAnimationCollection").GetComponent<tk2dSpriteAnimation>();
		if ((Object)(object)prefab == (Object)null || !CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			prefab = EntityTools.BuildEntity("RandomisedBuddy", guid, "amogus_idle_001", RandomisedBuddyCollection, new IntVector2(8, 8), new IntVector2(-4, 0));
			RandomisedBuddyController randomisedBuddyController = prefab.AddComponent<RandomisedBuddyController>();
			((CompanionController)randomisedBuddyController).companionID = (CompanionIdentifier)0;
			tk2dSpriteAnimator component = prefab.GetComponent<tk2dSpriteAnimator>();
			component.Library = RandomCompanionAnimationCollection;
			AIActor component2 = prefab.GetComponent<AIActor>();
			component2.CanDropCurrency = false;
			component2.CanDropItems = false;
			component2.BaseMovementSpeed = 6f;
			component2.IgnoreForRoomClear = false;
			component2.TryDodgeBullets = false;
			((GameActor)component2).ActorName = "Randomised Buddy";
			((GameActor)component2).DoDustUps = true;
			((GameActor)component2).SetIsFlying(true, "hovering", false, true);
			AIAnimator component3 = prefab.GetComponent<AIAnimator>();
			DirectionalAnimation val = new DirectionalAnimation();
			val.Type = (DirectionType)2;
			val.Flipped = (FlipType[])(object)new FlipType[2]
			{
				default(FlipType),
				(FlipType)1
			};
			val.AnimNames = new List<string> { "amogus", "amogus" }.ToArray();
			val.Prefix = string.Empty;
			component3.IdleAnimation = val;
			BehaviorSpeculator component4 = prefab.GetComponent<BehaviorSpeculator>();
			component4.MovementBehaviors.Add((MovementBehaviorBase)new CompanionFollowPlayerBehavior
			{
				CatchUpRadius = 6f,
				CatchUpMaxSpeed = 10f,
				CatchUpAccelTime = 1f,
				CatchUpSpeed = 7f
			});
			component4.MovementBehaviors.Add((MovementBehaviorBase)new SeekTargetBehavior
			{
				CustomRange = 7f,
				PathInterval = 0.25f
			});
			component4.TargetBehaviors = new List<TargetBehaviorBase> { (TargetBehaviorBase)new TargetPlayerBehavior
			{
				LineOfSight = false,
				ObjectPermanence = false,
				PauseOnTargetSwitch = false,
				PauseTime = 0f,
				Radius = 200f,
				SearchInterval = 0.25f
			} };
		}
	}
}
