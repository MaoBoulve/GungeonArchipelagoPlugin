using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alexandria.Assetbundle;
using Alexandria.CharacterAPI;
using Alexandria.EnemyAPI;
using BepInEx;
using Dungeonator;
using GungeonAPI;
using HarmonyLib;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

[BepInPlugin("nevernamed.etg.omitb", "Once More Into The Breach", "1.32.0")]
[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInDependency(/*Could not decode attribute arguments.*/)]
[BepInDependency(/*Could not decode attribute arguments.*/)]
public class Initialisation : BaseUnityPlugin
{
	[CompilerGenerated]
	private sealed class _003Cdelayedstarthandler_003Ed__32 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Initialisation _003C_003E4__this;

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
		public _003Cdelayedstarthandler_003Ed__32(int _003C_003E1__state)
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
				_003C_003E4__this.DelayedInitialisation();
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

	public const string GUID = "nevernamed.etg.omitb";

	public static Initialisation instance;

	public static string FilePathFolder;

	public static bool DEBUG_ITEM_DISABLE = false;

	public static AssetBundle assetBundle;

	public static tk2dSpriteCollectionData itemCollection;

	public static tk2dSpriteCollectionData gunCollection;

	public static tk2dSpriteCollectionData gunCollection2;

	public static tk2dSpriteCollectionData companionCollection;

	public static tk2dSpriteCollectionData VFXCollection;

	public static tk2dSpriteCollectionData NPCCollection;

	public static tk2dSpriteCollectionData ProjectileCollection;

	public static tk2dSpriteCollectionData MysteriousStrangerCollection;

	public static tk2dSpriteCollectionData TrapCollection;

	public static tk2dSpriteCollectionData EnvironmentCollection;

	public static tk2dSpriteCollectionData GunDressingCollection;

	public static tk2dSpriteAnimation projectileAnimationCollection;

	public static tk2dSpriteAnimation gunAnimationCollection;

	public static tk2dSpriteAnimation itemAnimationCollection;

	public static tk2dSpriteAnimation vfxAnimationCollection;

	public static tk2dSpriteAnimation npcAnimationCollection;

	public static tk2dSpriteAnimation companionAnimationCollection;

	public static tk2dSpriteAnimation mysteriousStrangerAnimationCollection;

	public static tk2dSpriteAnimation trapAnimationCollection;

	public static tk2dSpriteAnimation environmentAnimationCollection;

	public static SharedInjectionData GungeonProperInjections;

	public static Dictionary<string, GameObject> tempdict;

	public static GameObject toSpawn;

	public static string[] BundlePrereqs = new string[27]
	{
		"dungeon_scene_001", "encounters_base_001", "enemies_base_001", "flows_base_001", "foyer_001", "foyer_002", "foyer_003", "shared_base_001", "dungeons/base_bullethell", "dungeons/base_castle",
		"dungeons/base_catacombs", "dungeons/base_cathedral", "dungeons/base_forge", "dungeons/base_foyer", "dungeons/base_gungeon", "dungeons/base_mines", "dungeons/base_nakatomi", "dungeons/base_resourcefulrat", "dungeons/base_sewer", "dungeons/base_tutorial",
		"dungeons/finalscenario_bullet", "dungeons/finalscenario_convict", "dungeons/finalscenario_coop", "dungeons/finalscenario_guide", "dungeons/finalscenario_pilot", "dungeons/finalscenario_robot", "dungeons/finalscenario_soldier"
	};

	public void Awake()
	{
	}

	public void Start()
	{
		ETGModMainBehaviour.WaitForGameManagerStart((Action<GameManager>)GMStart);
	}

	public void GMStart(GameManager manager)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_149f: Unknown result type (might be due to invalid IL or missing references)
		//IL_14af: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ETGModConsole.Log((object)"Once More Into The Breach started initialising...", false);
			Harmony val = new Harmony("nevernamed.etg.omitb");
			val.PatchAll(Assembly.GetExecutingAssembly());
			instance = this;
			Assets.SetupSpritesFromFolder(Path.Combine(ETGMod.FolderPath((BaseUnityPlugin)(object)this), "sprites"));
			FilePathFolder = ETGMod.FolderPath((BaseUnityPlugin)(object)this);
			assetBundle = AssetBundleLoader.LoadAssetBundleFromLiterallyAnywhere("omitbbundle");
			itemCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "ItemCollection", "ItemCollectionMaterial.mat");
			gunCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "GunCollection", "GunCollectionMaterial.mat");
			gunCollection2 = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "GunCollection2", "GunCollection2Material.mat");
			ProjectileCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "ProjectileCollection", "ProjectileCollectionMaterial.mat");
			VFXCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "VFXCollection", "VFXCollectionMaterial.mat");
			NPCCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "NPCCollection", "NPCCollectionMaterial.mat");
			companionCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "CompanionCollection", "CompanionCollectionMaterial.mat");
			MysteriousStrangerCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "MysteriousStrangerCollection", "MysteriousStrangerCollectionMaterial.mat");
			TrapCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "TrapCollection", "TrapCollectionMaterial.mat");
			EnvironmentCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "EnvironmentCollection", "EnvironmentCollectionMaterial.mat");
			GunDressingCollection = AssetBundleLoader.FastLoadSpriteCollection(assetBundle, "GunDressing", "GunDressingMaterial.mat");
			projectileAnimationCollection = assetBundle.LoadAsset<GameObject>("ProjectileAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			gunAnimationCollection = assetBundle.LoadAsset<GameObject>("GunAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			itemAnimationCollection = assetBundle.LoadAsset<GameObject>("ItemAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			vfxAnimationCollection = assetBundle.LoadAsset<GameObject>("VFXAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			npcAnimationCollection = assetBundle.LoadAsset<GameObject>("NPCAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			companionAnimationCollection = assetBundle.LoadAsset<GameObject>("CompanionAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			mysteriousStrangerAnimationCollection = assetBundle.LoadAsset<GameObject>("MysteriousStrangerAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			trapAnimationCollection = assetBundle.LoadAsset<GameObject>("TrapAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			environmentAnimationCollection = assetBundle.LoadAsset<GameObject>("EnvironmentAnimationCollection").GetComponent<tk2dSpriteAnimation>();
			JsonEmbedder.EmbedJsonDataFromAssembly(Assembly.GetExecutingAssembly(), gunCollection, "NevernamedsItems/Resources/GunJsons");
			JsonEmbedder.EmbedJsonDataFromAssembly(Assembly.GetExecutingAssembly(), gunCollection2, "NevernamedsItems/Resources/GunJsons2");
			StaticReferences.Init();
			ExoticPlaceables.Init();
			Tools.Init();
			Gunfigs.Init();
			EnemyTools.Init();
			SaveAPIManager.Setup("nn");
			AudioResourceLoader.InitAudio();
			CurseManager.Init();
			((Component)ETGModMainBehaviour.Instance).gameObject.AddComponent<GlobalUpdate>();
			((Component)ETGModMainBehaviour.Instance).gameObject.AddComponent<CustomDarknessHandler>();
			GameOfLifeHandler.Init();
			Challenges.Init();
			PlayerToolsSetup.Init();
			CompanionisedEnemyUtility.InitHooks();
			FloorAndGenerationToolbox.Init();
			ComplexProjModBeamCompatibility.Init();
			SharedVFX.Init();
			ShadeFlightHookFix.Init();
			StaticStatusEffects.InitCustomEffects();
			PlagueStatusEffectSetup.Init();
			Confusion.Init();
			ExsanguinationSetup.Init();
			EasyGoopDefinitions.DefineDefaultGoops();
			HoleGoop.Init();
			JarateGoop.Init();
			Commands.Init();
			AllJammedState.Init();
			JammedChests.Init();
			EnemyHealthModifiers.Init();
			MiscUnlockHooks.InitHooks();
			if (!DEBUG_ITEM_DISABLE)
			{
				ActiveTestingItem.Init();
				PassiveTestingItem.Init();
				BulletComponentLister.Init();
				ObjectComponentLister.Init();
				StandardisedProjectiles.Init();
				ShadeHand.Init();
				ShadeHeart.Init();
				EggSalad.Init();
				PrimaBean.Init();
				BashingBullets.Init();
				TitanBullets.Init();
				MistakeBullets.Init();
				FiftyCalRounds.Init();
				UnengravedBullets.Init();
				EngravedBullets.Init();
				HardReloadBullets.Init();
				NitroBullets.Init();
				SupersonicShots.Init();
				GlassRounds.Init();
				Junkllets.Init();
				BloodthirstyBullets.Init();
				CleansingRounds.Init();
				HallowedBullets.Init();
				PromethianBullets.Init();
				EpimethianBullets.Init();
				RandoRounds.Init();
				HematicRounds.Init();
				FullArmourJacket.Init();
				MirrorBullets.Init();
				CrowdedClip.Init();
				BashfulShot.Init();
				OneShot.Init();
				BulletBullets.Init();
				AntimatterBullets.Init();
				SpectreBullets.Init();
				ExpandingBullets.Init();
				Tabullets.Init();
				BombardierShells.Init();
				GildedLead.Init();
				DemoterBullets.Init();
				Voodoollets.Init();
				TracerRound.Init();
				EndlessBullets.Init();
				HellfireRounds.Init();
				Birdshot.Init();
				Unpredictabullets.Init();
				WarpBullets.Init();
				BulletsWithGuns.Init();
				LaserBullets.Init();
				WoodenBullets.Init();
				ComicallyGiganticBullets.Init();
				KnightlyBullets.Init();
				EmptyRounds.Init();
				LongswordShot.Init();
				DrillBullets.Init();
				FoamDarts.Init();
				BatterBullets.Init();
				ElectrumRounds.Init();
				BreachingRounds.Init();
				MagnetItem.Init();
				BlueShell.Init();
				EargesplittenLoudenboomerRounds.Init();
				RoundsOfTheReaver.Init();
				TheShell.Init();
				JammedBullets.Init();
				SnailBullets.Init();
				LockdownBullets.Init();
				PestiferousLead.Init();
				Shrinkshot.Init();
				RazorBullets.Init();
				FlamingShells.Init();
				ShroomedBullets.Init();
				Splattershot.Init();
				BackwardsBullets.Init();
				CrossBullets.Init();
				ShadeShot.Init();
				MinersBullets.Init();
				AntimagicRounds.Init();
				AlkaliBullets.Init();
				ShutdownShells.Init();
				ERRORShells.Init();
				OsteoporosisBullets.Init();
				MicroAIContact.Init();
				LuckyCoin.Init();
				IronSights.Init();
				Lewis.Init();
				MysticOil.Init();
				VenusianBars.Init();
				NumberOneBossMug.Init();
				LibramOfTheChambers.Init();
				OrganDonorCard.Init();
				GlassGod.Init();
				ChaosRuby.Init();
				BlobulonRage.Init();
				OverpricedHeadband.Init();
				GunslingerEmblem.Init();
				MobiusClip.Init();
				ClipOnAmmoPouch.Init();
				JawsOfDefeat.Init();
				IridiumSnakeMilk.Init();
				Starfruit.Init();
				ArmourBandage.Init();
				GoldenArmour.Init();
				ExoskeletalArmour.Init();
				PowerArmour.Init();
				ArmouredArmour.Init();
				HEVSuit.Init();
				LooseChange.Init();
				SpaceMetal.Init();
				TrueBlank.Init();
				FalseBlank.Init();
				SpareBlank.Init();
				OpulentBlank.Init();
				GrimBlanks.Init();
				NNBlankPersonality.Init();
				BlankDie.Init();
				Blombk.Init();
				Blanket.Init();
				Blankh.Init();
				BlankKey.Init();
				SharpKey.Init();
				SpareKey.Init();
				KeyChain.Init();
				KeyBullwark.Init();
				KeyBulletEffigy.Init();
				FrostKey.Init();
				ShadowKey.Init();
				Keygen.Init();
				CursedTumbler.Init();
				TheShellactery.Init();
				BloodyAmmo.Init();
				MengerAmmoBox.Init();
				AmmoTrap.Init();
				BloodyBox.Init();
				MaidenShapedBox.Init();
				SetOfAllSets.Init();
				Toolbox.Init();
				PocketChest.Init();
				DeliveryBox.Init();
				Wonderchest.Init();
				HeartPadlock.Init();
				Mutagen.Init();
				ForsakenHeart.Init();
				HeartOfGold.Init();
				GooeyHeart.Init();
				ExaltedHeart.Init();
				CheeseHeart.Init();
				TinHeart.Init();
				HeartContainer.Init();
				HeartBox.Init();
				BarrelChamber.Init();
				GlassChamber.Init();
				FlameChamber.Init();
				Recyclinder.Init();
				Nitroglycylinder.Init();
				SpringloadedChamber.Init();
				WitheringChamber.Init();
				HeavyChamber.Init();
				CyclopeanChamber.Init();
				ElectricCylinder.Init();
				SonicCylinder.Init();
				Chamembert.Init();
				Dreamcatcher.Init();
				FiringMechanism.Init();
				TableTechTable.Init();
				TableTechSpeed.Init();
				TableTechInvulnerability.Init();
				TableTechAmmo.Init();
				TableTechGuon.Init();
				TableTechSpectre.Init();
				TableTechAstronomy.Init();
				TableTechVitality.Init();
				TableTechNology.Init();
				UnsTableTech.Init();
				RectangularMirror.Init();
				WoodGuonStone.Init();
				YellowGuonStone.Init();
				GreyGuonStone.Init();
				BlackGuonStone.Init();
				GoldGuonStone.Init();
				BrownGuonStone.Init();
				CyanGuonStone.Init();
				IndigoGuonStone.Init();
				SilverGuonStone.Init();
				MaroonGuonStone.Init();
				UltraVioletGuonStone.Init();
				InfraredGuonStone.Init();
				LimeGuonStone.Init();
				RainbowGuonStone.Init();
				KaleidoscopicGuonStone.Init();
				GuonBoulder.Init();
				BloodglassGuonStone.Init();
				GlassAmmolet.Init();
				WickerAmmolet.Init();
				FuriousAmmolet.Init();
				SilverAmmolet.Init();
				IvoryAmmolet.Init();
				KinAmmolet.Init();
				Autollet.Init();
				Keymmolet.Init();
				Ammolock.Init();
				HepatizonAmmolet.Init();
				BronzeAmmolet.Init();
				PearlAmmolet.Init();
				NeutroniumAmmolet.Init();
				Shatterblank.Init();
				CycloneCylinder.Init();
				BootLeg.Init();
				BlankBoots.Init();
				BulletBoots.Init();
				FriendshipBracelet.Init();
				ShellNecklace.Init();
				DiamondBracelet.Init();
				PearlBracelet.Init();
				AmethystBracelet.Init();
				PanicPendant.Init();
				GunknightAmulet.Init();
				AmuletOfShelltan.Init();
				CrosshairNecklace.Init();
				HauntedAmulet.Init();
				Gracelets.Init();
				SubstitutiaryLocomotion.Init();
				RingOfOddlySpecificBenefits.Init();
				FowlRing.Init();
				RingOfAmmoRedemption.Init();
				RiskyRing.Init();
				WidowsRing.Init();
				ShadowRing.Init();
				RingOfFortune.Init();
				RingOfInvisibility.Init();
				BlackHolster.Init();
				TheBeholster.Init();
				HiveHolster.Init();
				ShoulderHolster.Init();
				ArtilleryBelt.Init();
				BeltFeeder.Init();
				BulletShuffle.Init();
				MolotovBuddy.Init();
				BabyGoodChanceKin.Init();
				Potty.Init();
				Peanut.Init();
				DarkPrince.Init();
				Diode.Init();
				DroneCompanion.Init();
				GregTheEgg.Init();
				FunGuy.Init();
				Gungineer.Init();
				BabyGoodDet.Init();
				AngrySpirit.Init();
				Gusty.Init();
				ScrollOfExactKnowledge.Init();
				LilMunchy.Init();
				Cubud.Init();
				Hapulon.Init();
				PrismaticSnail.Init();
				RandomisedBuddyController.Init();
				ManOfMystery.Init();
				Goobleck.Init();
				SpeedPotion.Init();
				LovePotion.Init();
				HoneyPot.Init();
				ChemicalBurn.Init();
				WitchsBrew.Init();
				Nigredo.Init();
				Albedo.Init();
				Citrinitas.Init();
				Rubedo.Init();
				HoleyWater.Init();
				Jarate.Init();
				BlueSyrup.Init();
				ColdOne.Init();
				ReinforcementRadio.Init();
				BloodThinner.Init();
				BoosterShot.Init();
				ShotInTheArm.Init();
				WoodenKnife.Init();
				DaggerOfTheAimgel.Init();
				CombatKnife.Init();
				Bayonet.Init();
				LaserKnife.Init();
				BookOfMimicAnatomy.Init();
				KalibersPrayer.Init();
				GunidaeSolvitHaatelis.Init();
				MapFragment.Init();
				TatteredMap.Init();
				CloakOfDarkness.Init();
				TimeFuddlersRobe.Init();
				BlueSteel.Init();
				CartographersEye.Init();
				BloodshotEye.Init();
				ShadesEye.Init();
				BeholsterEye.Init();
				KalibersEye.Init();
				Lefthandedness.Init();
				NecromancersRightHand.Init();
				FiveFingerDiscount.Init();
				InfantryGrenade.Init();
				DiceGrenade.Init();
				PickledPepper.Init();
				LaserPepper.Init();
				PepperPoppers.Init();
				PercussionCap.Init();
				BlastingCap.Init();
				Lvl2Molotov.Init();
				GoldenAppleCore.Init();
				AppleCore.Init();
				AppleActive.Init();
				LibationtoIcosahedrax.Init();
				BagOfHolding.Init();
				ItemCoupon.Init();
				IdentityCrisis.Init();
				Pyromania.Init();
				LiquidMetalBody.Init();
				GunGrease.Init();
				BomberJacket.Init();
				DragunsScale.Init();
				GTCWTVRP.Init();
				BlightShell.Init();
				BulletKinPlushie.Init();
				Kevin.Init();
				PurpleProse.Init();
				RustyCasing.Init();
				HikingPack.Init();
				GunpowderPheromones.Init();
				GunsmokePerfume.Init();
				Pestilence.Init();
				ElevatorButton.Init();
				Bullut.Init();
				GSwitch.Init();
				FaultyHoverboots.Init();
				Accelerant.Init();
				HornedHelmet.Init();
				HelmOfChaos.Init();
				TruthKnowersTrance.Init();
				RocketMan.Init();
				Roulette.Init();
				FinishedBullet.Init();
				ChanceKinEffigy.Init();
				MagickeCauldron.Init();
				Bombinomicon.Init();
				ClaySculpture.Init();
				GracefulGoop.Init();
				MrFahrenheit.Init();
				MagicQuiver.Init();
				FocalLenses.Init();
				MagicMissile.Init();
				AmberDie.Init();
				ObsidianPistol.Init();
				Showdown.Init();
				UnderbarrelShotgun.Init();
				LootEngineItem.Init();
				Ammolite.Init();
				PortableHole.Init();
				CardinalsMitre.Init();
				GunjurersBelt.Init();
				GoomperorsCrown.Init();
				ChemGrenade.Init();
				EightButton.Init();
				TitaniumClip.Init();
				PaperBadge.Init();
				SculptorsChisel.Init();
				Permafrost.Init();
				GlassShard.Init();
				EqualityItem.Init();
				BitBucket.Init();
				Eraser.Init();
				GunpowderGreen.Init();
				TackShooter.Init();
				ChanceCard.Init();
				Moonrock.Init();
				Telekinesis.Init();
				DeathMask.Init();
				TabletOfOrder.Init();
				Bambarrage.Init();
				AmmoGland.Init();
				RabbitsFoot.Init();
				GlobeSight.Init();
				Payback.Init();
				MasterPin.Init();
				GuruMeditation.Init();
				BeggarsBelief.Init();
				LeadSoul.Init();
				LeadOfLife.Init();
				AWholeBulletKin.Init();
				WailingMagnum.Add();
				Defender.Add();
				TestGun.Add();
				Gunycomb.Add();
				GlobbitSMALL.Add();
				GlobbitMED.Add();
				GlobbitMEGA.Add();
				ElderMagnum.Add();
				FlayedRevolver.Add();
				G20.Add();
				MamaGun.Add();
				LovePistol.Add();
				DiscGun.Add();
				Repeatovolver.Add();
				Pista.Add();
				NNGundertale.Add();
				DiamondGun.Add();
				NNMinigun.Add();
				ShroomedGun.Add();
				GoldenRevolver.Add();
				Nocturne.Add();
				BackWarder.Add();
				Redhawk.Add();
				ToolGun.Add();
				StickGun.Add();
				Glock42.Add();
				StarterPistol.Add();
				ScrapStrap.Add();
				PopGun.Add();
				UnusCentum.Add();
				StunGun.Add();
				CopperSidearm.Add();
				Rekeyter.Add();
				HotGlueGun.Add();
				UpNUp.Add();
				RedRobin.Add();
				DarkLady.Add();
				VariableGun.Add();
				CrescendoBlaster.Add();
				Glasster.Add();
				HandGun.Add();
				Viper.Add();
				DiamondCutter.Add();
				MarchGun.Add();
				RebarGun.Add();
				MinuteGun.Add();
				Ulfberht.Add();
				SpacersFancy.Add();
				FractalGun.Add();
				SalvatorDormus.Add();
				MoltenHeat.Add();
				ServiceWeapon.Add();
				HeadOfTheOrder.Add();
				GunOfAThousandSins.Add();
				DoubleGun.Add();
				JusticeGun.Add();
				Orgun.Add();
				Octagun.Add();
				ClownShotgun.Add();
				Ranger.Add();
				RustyShotgun.Add();
				TheBride.Add();
				TheGroom.Add();
				IrregularShotgun.Add();
				GrenadeShotgun.Add();
				Jackhammer.Add();
				Tomahawk.Add();
				SaltGun.Add();
				SoapGun.Add();
				Felissile.Add();
				HandCannon.Add();
				Lantaka.Add();
				GreekFire.Add();
				EmberCannon.Add();
				Dulcannon.Add();
				ElysiumCannon.Add();
				DisplacerCannon.Add();
				BusterGun.Add();
				Rewarp.Add();
				Blasmaster.Add();
				St4ke.Add();
				Robogun.Add();
				CortexBlaster.Add();
				RedBlaster.Add();
				BeamBlade.Add();
				Neutrino.Add();
				Rico.Add();
				TheThinLine.Add();
				RocketPistol.Add();
				Repetitron.Add();
				Dimensionaliser.Add();
				Purpler.Add();
				VacuumGun.Add();
				Oxygun.Add();
				XRay.Add();
				LtBluesPhaser.Add();
				TriBeam.Add();
				WaveformLens.Add();
				KineticBlaster.Add();
				LaserWelder.Add();
				QBeam.Add();
				HighVelocityRifle.Add();
				Demolitionist.Add();
				PumpChargeShotgun.Add();
				TheOutbreak.Add();
				Multiplicator.Add();
				PunishmentRay.Add();
				YBeam.Add();
				WallRay.Add();
				BolaGun.Add();
				AlphaBeam.Add();
				Glazerbeam.Add();
				StasisRifle.Add();
				Gravitron.Add();
				Ferrobolt.Add();
				ParticleBeam.Add();
				TauCannon.Add();
				GravityGun.Add();
				GalaxyCrusher.Add();
				ARCPistol.Add();
				ARCShotgun.Add();
				ARCRifle.Add();
				ARCTactical.Add();
				ARCCannon.Add();
				IceBow.Add();
				TitanSlayer.Add();
				PencilPusher.Add();
				Boltcaster.Add();
				VulcanRepeater.Add();
				Pinaka.Add();
				Clicker.Add();
				WheelLock.Add();
				Welrod.Add();
				Welgun.Add();
				TheLodger.Add();
				Gonne.Add();
				Hwacha.Add();
				FireLance.Add();
				HandMortar.Add();
				GrandfatherGlock.Add();
				GatlingGun.Add();
				Blowgun.Add();
				Smoker.Add();
				Gaxe.Add();
				WoodenHorse.Add();
				AgarGun.Add();
				MusketRifle.Add();
				Arquebus.Add();
				TheBlackSpot.Add();
				Javelin.Add();
				Carnwennan.Add();
				MantidAugment.Add();
				HookGun.Add();
				RiteOfPassage.Add();
				KillDevil.Add();
				Claymore.Add();
				Scythe.Add();
				HeatRay.Add();
				Welder.Add();
				BlueGun.Add();
				BarcodeScanner.Add();
				AntimaterielRifle.Add();
				Primos1.Add();
				DartRifle.Add();
				AM0.Add();
				RiskRifle.Add();
				AverageJoe.Add();
				RiotGun.Add();
				Kalashnirang.Add();
				Schwarzlose.Add();
				MaidenRifle.Add();
				Blizzkrieg.Add();
				Copygat.Add();
				Skorpion.Add();
				HeavyAssaultRifle.Add();
				DynamiteLauncher.Add();
				BouncerUzi.Add();
				Borz.Add();
				Borchardt.Add();
				MarbledUzi.Add();
				BurstRifle.Add();
				DublDuck.Add();
				Type56.Add();
				M70.Add();
				G11.Add();
				C7A2.Add();
				Rheinmetole.Add();
				OlReliable.Add();
				FlamethrowerMk1.Add();
				FlamethrowerMk2.Add();
				Wex.Add();
				BouncerRPG.Add();
				Clamshell.Add();
				BottleRocket.Add();
				Betsy.Add();
				NNBazooka.Add();
				BoomBeam.Add();
				Pillarocket.Add();
				DoomBoom.Add();
				Pallbearer.Add();
				Gunion.Add();
				Cornnon.Add();
				SporeLauncher.Add();
				PoisonDartFrog.Add();
				Corgun.Add();
				FungoCannon.Add();
				PhaserSpiderling.Add();
				Guneonate.Add();
				KillithidTendril.Add();
				Gunger.Add();
				SickWorm.Add();
				DomeLord.Add();
				MiniMonger.Add();
				CarrionFormeTwo.Add();
				CarrionFormeThree.Add();
				Carrion.Add();
				UterinePolyp.Add();
				Wrinkler.Add();
				BrainBlast.Add();
				HornetsNest.Add();
				SnakePistol.Add();
				SnakeMinigun.Add();
				ButchersKnife.Add();
				RapidRiposte.Add();
				Spitballer.Add();
				ConfettiCannon.Add();
				Gumgun.Add();
				BubbleFist.Add();
				Glooper.Add();
				ChewingGun.Add();
				Makatov.Add();
				Accelerator.Add();
				PaintballGun.Add();
				Converter.Add();
				Spiral.Add();
				Gunshark.Add();
				FingerGuns.Add();
				OBrienFist.Add();
				GolfRifle.Add();
				Pandephonium.Add();
				Sweeper.Add();
				DeskFan.Add();
				Pencil.Add();
				SquareBracket.Add();
				SquarePeg.Add();
				Ringer.Add();
				Snaker.Add();
				GayK47.Add();
				LaundromaterielRifle.Add();
				DecretionCarbine.Add();
				Amalgun.Add();
				RC360.Add();
				RazorRifle.Add();
				UziSpineMM.Add();
				PineNeedler.Add();
				AlternatingFire.Add();
				Autogun.Add();
				Rebondir.Add();
				BigShot.Add();
				W3irdstar.Add();
				Seismograph.Add();
				CashBlaster.Add();
				PocoLoco.Add();
				Monsoon.Add();
				BioTranstater2100.Add();
				Bejeweler.Add();
				TotemOfGundying.Add();
				Icicle.Add();
				GunjurersStaff.Add();
				InitiateWand.Add();
				LightningRod.Add();
				OrbOfTheGun.Add();
				SpearOfJustice.Add();
				Protean.Add();
				BulletBlade.Add();
				Bookllet.Add();
				Lorebook.Add();
				Beastclaw.Add();
				Bullatterer.Add();
				Entropew.Add();
				Missinguno.Add();
				Paraglocks.Add();
				BlueMoon.Add();
				MagicPaintbrush.Add();
				TheGreyStaff.Add();
				Solstice.Add();
				Creditor.Add();
				Blankannon.Add();
				Viscerifle.Add();
				MastersGun.Add();
				Wrench.Add();
				Pumhart.Add();
				GunsharkMegasharkSynergyForme.Add();
				DiscGunSuperDiscForme.Add();
				OrgunHeadacheSynergyForme.Add();
				Wolfgun.Add();
				MinigunMiniShotgunSynergyForme.Add();
				PenPencilSynergy.Add();
				ReShelletonKeyter.Add();
				AM0SpreadForme.Add();
				BulletBladeGhostForme.Add();
				GlueGunGlueGunnerSynergy.Add();
				KingBullatterer.Add();
				WrenchNullRefException.Add();
				GatlingGunGatterUp.Add();
				GravityGunNegativeMatterForm.Add();
				GonneElder.Add();
				UterinePolypWombular.Add();
				DiamondGaxe.Add();
				RedRebondir.Add();
				DiamondCutterRangerClass.Add();
				StickGunQuickDraw.Add();
				StormRod.Add();
				UnrustyShotgun.Add();
				DARCPistol.Add();
				DARCRifle.Add();
				DARCShotgun.Add();
				DARCTactical.Add();
				DARCCannon.Add();
				Bloodwash.Add();
				SalvatorDormusM1893.Add();
				ServiceWeaponShatter.Add();
				ServiceWeaponSpin.Add();
				ServiceWeaponPierce.Add();
				ServiceWeaponCharge.Add();
				BigBorz.Add();
				Spitfire.Add();
				RepeatovolverInfinite.Add();
				ShrineSetup.Init();
				GenericPlaceables.Init();
				StatueTraps.Init();
				GuillotineTrap.Init();
				LowWalls.Init();
				GoldButton.Init();
				BloodCandle.Init();
				Breakables.Init();
				Rusty.Init();
				Ironside.Init();
				Boomhildr.Init();
				Doug.Init();
				BowlerShop.Init();
				Dispenser.Init();
				SlotMachine.Init();
				Chancellot.Init();
				MysteriousStranger.Init();
				Beggar.Init();
				Jammomaster.Init();
				GenericCultist.Init();
				ChromaGun.Add();
				GoodMimic.Add();
				CustomCharacterData val2 = Loader.BuildCharacter("NevernamedsItems/Characters/Shade", "nevernamed.etg.omitb", new Vector3(12.3f, 21.3f), false, new Vector3(13.1f, 19.1f), false, false, true, true, false, (GlowMatDoer)null, (GlowMatDoer)null, 0, false, "");
				AdditionalMasteries.Init();
				CadenceAndOxShopPoolAdditions.Init();
				CustomHuntingQuest.Init();
				InitialiseSynergies.DoInitialisation();
				SynergyFormInitialiser.AddSynergyForms();
				ExistantGunModifiers.Init();
				Tags.Init();
				LeadOfLifeInitCompanions.BuildPrefabs();
			}
			BeggarsBelief.InitRooms();
			ChanceCard.InitRooms();
			KillUnlockHandler.Init();
			ETGModConsole.Commands.GetGroup("nn").AddUnit("listassets", (Action<string[]>)delegate
			{
				string[] bundlePrereqs = BundlePrereqs;
				foreach (string text in bundlePrereqs)
				{
					string[] allAssetNames = ResourceManager.LoadAssetBundle(text).GetAllAssetNames();
					string[] array = allAssetNames;
					foreach (string text2 in array)
					{
						ETGModConsole.Log((object)text2, false);
					}
				}
			}, (AutocompletionSettings)null);
			ETGModConsole.Commands.GetGroup("nn").AddUnit("setObj", (Action<string[]>)delegate(string[] args)
			{
				if (tempdict == null)
				{
					tempdict = new Dictionary<string, GameObject>
					{
						{
							"rattrap",
							((Component)EnemyDatabase.GetOrLoadByGuid("6868795625bd46f3ae3e4377adce288b")).GetComponent<ResourcefulRatController>().MouseTraps[1]
						},
						{
							"oubdrop",
							ExoticPlaceables.OubTrapdoor
						},
						{
							"telesign",
							ExoticPlaceables.TeleporterSign
						},
						{
							"shoplayout",
							ExoticPlaceables.ShopLayout
						},
						{
							"shopcrates",
							ExoticPlaceables.Crates
						},
						{
							"shopcrate",
							ExoticPlaceables.Crate
						},
						{
							"shopsack",
							ExoticPlaceables.Sack
						},
						{
							"shopshellbarrel",
							ExoticPlaceables.ShellBarrel
						},
						{
							"shopshelf",
							ExoticPlaceables.Shelf
						},
						{
							"shopmask",
							ExoticPlaceables.Mask
						},
						{
							"shopwallsword",
							ExoticPlaceables.Wallsword
						},
						{
							"shopstandingshelf",
							ExoticPlaceables.StandingShelf
						},
						{
							"shopakbarrel",
							ExoticPlaceables.AKBarrel
						},
						{
							"shopstool",
							ExoticPlaceables.Stool
						},
						{
							"upsign",
							ExoticPlaceables.SignUp
						},
						{
							"rightsign",
							ExoticPlaceables.SignRight
						},
						{
							"leftsign",
							ExoticPlaceables.SignLeft
						},
						{
							"secretroom",
							ExoticPlaceables.secretroomlayout
						}
					};
				}
				string text3 = "UNDEFINED";
				if (args != null && args.Length != 0 && args[0] != null && !string.IsNullOrEmpty(args[0]))
				{
					text3 = args[0];
				}
				text3 = text3.Replace("=", " ");
				bool flag = false;
				if (tempdict.ContainsKey(text3))
				{
					toSpawn = tempdict[text3];
					flag = true;
				}
				else if (Object.op_Implicit((Object)(object)LoadHelper.LoadAssetFromAnywhere<GameObject>(text3)))
				{
					toSpawn = LoadHelper.LoadAssetFromAnywhere<GameObject>(text3);
					flag = true;
				}
				else if (Object.op_Implicit((Object)(object)LoadHelper.LoadAssetFromAnywhere<DungeonPlaceable>(text3)))
				{
					toSpawn = LoadHelper.LoadAssetFromAnywhere<DungeonPlaceable>(text3).variantTiers[0].GetOrLoadPlaceableObject;
					flag = true;
				}
				if (!flag)
				{
					ETGModConsole.Log((object)"FAILED", false);
				}
			}, (AutocompletionSettings)null);
			ETGMod.StartGlobalCoroutine(delayedstarthandler());
			ETGModConsole.Log((object)"'If you're reading this, I must have done something right' - NN", false);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	public IEnumerator delayedstarthandler()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003Cdelayedstarthandler_003Ed__32(0)
		{
			_003C_003E4__this = this
		};
	}

	public void DelayedInitialisation()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LibramOfTheChambers.LateInit();
			CrossmodNPCLootPoolSetup.CheckItems();
			OMITBChars.Shade = ETGModCompatibility.ExtendEnum<PlayableCharacters>("nevernamed.etg.omitb", "Shade");
			ETGModConsole.Log((object)"(Also finished DelayedInitialisation)", false);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}
}
