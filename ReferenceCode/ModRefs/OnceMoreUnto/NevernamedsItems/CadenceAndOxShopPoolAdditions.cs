using SaveAPI;

namespace NevernamedsItems;

internal class CadenceAndOxShopPoolAdditions
{
	public static void Init()
	{
		BreachShopTool.AddBaseMetaShopTier(RiskRifle.RiskRifleID, 20, Creditor.CreditorID, 25, OverpricedHeadband.OverpricedHeadbandID, 35, null);
		BreachShopTool.AddBaseMetaShopTier(PowerArmour.PowerArmourID, 10, Recyclinder.RecyclinderID, 25, Blasmaster.BlasmasterID, 10, null);
		BreachShopTool.AddBaseMetaShopTier(DartRifle.DartRifleID, 30, Demolitionist.DemolitionistID, 25, Repeatovolver.RepeatovolverID, 20, null);
		BreachShopTool.AddBaseMetaShopTier(Spiral.SpiralID, 40, StunGun.StunGunID, 10, DroneCompanion.DroneID, 25, null);
		BreachShopTool.AddBaseMetaShopTier(Autogun.AutogunID, 20, Rebondir.ID, 30, Converter.ConverterID, 40, null);
	}
}
