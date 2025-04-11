using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class SynergyFormInitialiser
{
	public static void AddSynergyForms()
	{
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		AddSynergyForm(Gunshark.GunsharkID, GunsharkMegasharkSynergyForme.GunsharkMegasharkSynergyFormeID, "Megashark");
		AddSynergyForm(DiscGun.DiscGunID, DiscGunSuperDiscForme.DiscGunSuperDiscSynergyFormeID, "Super Disc");
		AddSynergyForm(Orgun.OrgunID, OrgunHeadacheSynergyForme.OrgunHeadacheSynergyFormeID, "Headache");
		AddSynergyForm(NNMinigun.MiniGunID, MinigunMiniShotgunSynergyForme.MiniShotgunID, "Mini Shotgun");
		AddSynergyForm(Corgun.DoggunID, Wolfgun.WolfgunID, "Discord and Rhyme");
		AddSynergyForm(Pencil.pencilID, PenPencilSynergy.penID, "Mightier Than The Gun");
		AddSynergyForm(Rekeyter.RekeyterID, ReShelletonKeyter.ReShelletonKeyterID, "ReShelletonKeyter");
		AddSynergyForm(AM0.ID, AM0SpreadForme.AM0SpreadFormeID, "Spreadshot");
		AddSynergyForm(BulletBlade.BulletBladeID, BulletBladeGhostForme.GhostBladeID, "GHOST SWORD!!!");
		AddSynergyForm(HotGlueGun.HotGlueGunID, GlueGunGlueGunnerSynergy.GlueGunnerID, "Glue Gunner");
		AddSynergyForm(Bullatterer.BullattererID, KingBullatterer.KingBullattererID, "King Bullatterer");
		AddSynergyForm(Wrench.WrenchID, WrenchNullRefException.NullWrenchID, "NullReferenceException");
		AddSynergyForm(GravityGun.GravityGunID, GravityGunNegativeMatterForm.GravityGunNegativeMatterID, "Negative Matter");
		AddSynergyForm(GatlingGun.GatlingGunID, GatlingGunGatterUp.GatGunID, "Gatter Up");
		AddSynergyForm(Gonne.GonneID, GonneElder.ElderGonneId, "Discworld");
		AddSynergyForm(UterinePolyp.UterinePolypID, UterinePolypWombular.WombularPolypID, "Wombular");
		AddSynergyForm(Gaxe.ID, DiamondGaxe.ID, "Diamond Gaxe");
		AddSynergyForm(Rebondir.ID, RedRebondir.ID, "Rebondissement");
		AddSynergyForm(DiamondCutter.ID, DiamondCutterRangerClass.ID, "Ranger Class");
		AddSynergyForm(StickGun.ID, StickGunQuickDraw.ID, "Quick, Draw!");
		AddSynergyForm(LightningRod.ID, StormRod.ID, "Storm Rod");
		AddSynergyForm(RustyShotgun.ID, UnrustyShotgun.ID, "Proper Care & Maintenance");
		AddSynergyForm(ARCPistol.ID, DARCPistol.ID, "DARC Pistol");
		AddSynergyForm(ARCRifle.ID, DARCRifle.ID, "DARC Rifle");
		AddSynergyForm(ARCShotgun.ID, DARCShotgun.ID, "DARC Shotgun");
		AddSynergyForm(ARCTactical.ID, DARCTactical.ID, "DARC Tactical");
		AddSynergyForm(ARCCannon.ID, DARCCannon.ID, "DARC Cannon");
		AddSynergyForm(LaundromaterielRifle.ID, Bloodwash.ID, "Bloodwash");
		AddSynergyForm(SalvatorDormus.ID, SalvatorDormusM1893.ID, "M1893");
		AddSynergyForm(Borz.ID, BigBorz.ID, "Big Borz");
		AddSynergyForm(Spitballer.ID, Spitfire.ID, "Spitfire");
		AddSynergyForm(Repeatovolver.RepeatovolverID, RepeatovolverInfinite.ID, "Ad Infinitum");
		AddSwappableSynergyForm(ServiceWeapon.ID, ServiceWeaponShatter.ID, "<shatter/break/unmake>");
		AddSwappableSynergyForm(ServiceWeapon.ID, ServiceWeaponSpin.ID, "<spin/rotate/shred>");
		AddSwappableSynergyForm(ServiceWeapon.ID, ServiceWeaponPierce.ID, "<pierce/penetrate/eviscerate>");
		AddSwappableSynergyForm(ServiceWeapon.ID, ServiceWeaponCharge.ID, "<charge/decimate/kaboom>");
		PickupObject byId = PickupObjectDatabase.GetById(StunGun.StunGunID);
		AdvancedDualWieldSynergyProcessor val = ((Component)((byId is Gun) ? byId : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val.PartnerGunID = 42;
		val.SynergyNameToCheck = "Non Lethal Solutions";
		PickupObject byId2 = PickupObjectDatabase.GetById(42);
		AdvancedDualWieldSynergyProcessor val2 = ((Component)((byId2 is Gun) ? byId2 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val2.PartnerGunID = StunGun.StunGunID;
		val2.SynergyNameToCheck = "Non Lethal Solutions";
		PickupObject byId3 = PickupObjectDatabase.GetById(Blowgun.BlowgunID);
		AdvancedDualWieldSynergyProcessor val3 = ((Component)((byId3 is Gun) ? byId3 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val3.PartnerGunID = PoisonDartFrog.PoisonDartFrogID;
		val3.SynergyNameToCheck = "Dartistry";
		PickupObject byId4 = PickupObjectDatabase.GetById(PoisonDartFrog.PoisonDartFrogID);
		AdvancedDualWieldSynergyProcessor val4 = ((Component)((byId4 is Gun) ? byId4 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val4.PartnerGunID = Blowgun.BlowgunID;
		val4.SynergyNameToCheck = "Dartistry";
		PickupObject byId5 = PickupObjectDatabase.GetById(Lorebook.LorebookID);
		AdvancedDualWieldSynergyProcessor val5 = ((Component)((byId5 is Gun) ? byId5 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val5.PartnerGunID = Bookllet.BooklletID;
		val5.SynergyNameToCheck = "Librarian";
		PickupObject byId6 = PickupObjectDatabase.GetById(Bookllet.BooklletID);
		AdvancedDualWieldSynergyProcessor val6 = ((Component)((byId6 is Gun) ? byId6 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val6.PartnerGunID = Lorebook.LorebookID;
		val6.SynergyNameToCheck = "Librarian";
		PickupObject byId7 = PickupObjectDatabase.GetById(Welrod.WelrodID);
		AdvancedDualWieldSynergyProcessor val7 = ((Component)((byId7 is Gun) ? byId7 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val7.PartnerGunID = Welgun.WelgunID;
		val7.SynergyNameToCheck = "Wel Wel Wel";
		PickupObject byId8 = PickupObjectDatabase.GetById(Welgun.WelgunID);
		AdvancedDualWieldSynergyProcessor val8 = ((Component)((byId8 is Gun) ? byId8 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val8.PartnerGunID = Welrod.WelrodID;
		val8.SynergyNameToCheck = "Wel Wel Wel";
		PickupObject byId9 = PickupObjectDatabase.GetById(TheBride.TheBrideID);
		AdvancedDualWieldSynergyProcessor val9 = ((Component)((byId9 is Gun) ? byId9 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val9.PartnerGunID = TheGroom.TheGroomID;
		val9.SynergyNameToCheck = "Shotgun Wedding";
		PickupObject byId10 = PickupObjectDatabase.GetById(TheGroom.TheGroomID);
		AdvancedDualWieldSynergyProcessor val10 = ((Component)((byId10 is Gun) ? byId10 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val10.PartnerGunID = TheBride.TheBrideID;
		val10.SynergyNameToCheck = "Shotgun Wedding";
		PickupObject byId11 = PickupObjectDatabase.GetById(Rico.RicoID);
		AdvancedDualWieldSynergyProcessor val11 = ((Component)((byId11 is Gun) ? byId11 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val11.PartnerGunID = Rebondir.ID;
		val11.SynergyNameToCheck = "Super Bounce Bros";
		PickupObject byId12 = PickupObjectDatabase.GetById(Rebondir.ID);
		AdvancedDualWieldSynergyProcessor val12 = ((Component)((byId12 is Gun) ? byId12 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val12.PartnerGunID = Rico.RicoID;
		val12.SynergyNameToCheck = "Super Bounce Bros";
		AddDualWield(Gaxe.ID, TotemOfGundying.ID, "Offhand Immortal");
		AddDualWield(Type56.ID, M70.ID, "Acceptable Substitutes");
		AdvancedHoveringGunSynergyProcessor advancedHoveringGunSynergyProcessor = ((Component)PickupObjectDatabase.GetById(SnakePistol.ID)).gameObject.AddComponent<AdvancedHoveringGunSynergyProcessor>();
		advancedHoveringGunSynergyProcessor.RequiredSynergy = "Serpents Reach";
		advancedHoveringGunSynergyProcessor.requiresTargetGunInInventory = true;
		advancedHoveringGunSynergyProcessor.fireDelayBasedOnGun = true;
		advancedHoveringGunSynergyProcessor.FireType = (FireType)0;
		advancedHoveringGunSynergyProcessor.Trigger = AdvancedHoveringGunSynergyProcessor.TriggerStyle.CONSTANT;
		advancedHoveringGunSynergyProcessor.PositionType = (HoverPosition)0;
		advancedHoveringGunSynergyProcessor.IDsToSpawn = new List<int> { SnakeMinigun.ID }.ToArray();
		AdvancedHoveringGunSynergyProcessor advancedHoveringGunSynergyProcessor2 = ((Component)PickupObjectDatabase.GetById(SnakeMinigun.ID)).gameObject.AddComponent<AdvancedHoveringGunSynergyProcessor>();
		advancedHoveringGunSynergyProcessor2.RequiredSynergy = "Serpents Reach";
		advancedHoveringGunSynergyProcessor2.requiresTargetGunInInventory = true;
		advancedHoveringGunSynergyProcessor2.fireDelayBasedOnGun = true;
		advancedHoveringGunSynergyProcessor2.FireType = (FireType)0;
		advancedHoveringGunSynergyProcessor2.Trigger = AdvancedHoveringGunSynergyProcessor.TriggerStyle.CONSTANT;
		advancedHoveringGunSynergyProcessor2.PositionType = (HoverPosition)0;
		advancedHoveringGunSynergyProcessor2.IDsToSpawn = new List<int> { SnakePistol.ID }.ToArray();
	}

	public static void AddSynergyForm(int baseGun, int newGun, string synergy)
	{
		PickupObject byId = PickupObjectDatabase.GetById(baseGun);
		GunTools.AddTransformSynergy((Gun)(object)((byId is Gun) ? byId : null), newGun, true, synergy, true);
	}

	public static void AddSwappableSynergyForm(int baseGun, int newGun, string synergy)
	{
		PickupObject byId = PickupObjectDatabase.GetById(baseGun);
		GunTools.AddTransformSynergy((Gun)(object)((byId is Gun) ? byId : null), newGun, true, synergy, false);
	}

	public static void AddDualWield(int gun1, int gun2, string synergy)
	{
		PickupObject byId = PickupObjectDatabase.GetById(gun1);
		AdvancedDualWieldSynergyProcessor val = ((Component)((byId is Gun) ? byId : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val.PartnerGunID = gun2;
		val.SynergyNameToCheck = synergy;
		PickupObject byId2 = PickupObjectDatabase.GetById(gun2);
		AdvancedDualWieldSynergyProcessor val2 = ((Component)((byId2 is Gun) ? byId2 : null)).gameObject.AddComponent<AdvancedDualWieldSynergyProcessor>();
		val2.PartnerGunID = gun1;
		val2.SynergyNameToCheck = synergy;
	}
}
