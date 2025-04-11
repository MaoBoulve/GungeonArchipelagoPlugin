using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class ExistantGunModifiers
{
	public static List<Projectile> Planets;

	public static void Init()
	{
		PickupObject byId = PickupObjectDatabase.GetById(748);
		((Component)((byId is Gun) ? byId : null)).gameObject.AddComponent<SunlightJavelinModifiers>();
		PickupObject byId2 = PickupObjectDatabase.GetById(539);
		((Component)((byId2 is Gun) ? byId2 : null)).gameObject.AddComponent<BoxingGloveModifiers>();
		PickupObject byId3 = PickupObjectDatabase.GetById(506);
		((Component)((byId3 is Gun) ? byId3 : null)).gameObject.AddComponent<ReallySpecialLuteModifiers>();
		PickupObject byId4 = PickupObjectDatabase.GetById(93);
		((Component)((byId4 is Gun) ? byId4 : null)).gameObject.AddComponent<OldGoldieModifiers>();
		PickupObject byId5 = PickupObjectDatabase.GetById(32);
		((Component)((byId5 is Gun) ? byId5 : null)).gameObject.AddComponent<VoidMarshalModifiers>();
		PickupObject byId6 = PickupObjectDatabase.GetById(184);
		((Component)((byId6 is Gun) ? byId6 : null)).gameObject.AddComponent<JudgeModifiers>();
		PickupObject byId7 = PickupObjectDatabase.GetById(562);
		((Component)((byId7 is Gun) ? byId7 : null)).gameObject.AddComponent<FatLineModifiers>();
		PickupObject byId8 = PickupObjectDatabase.GetById(50);
		((Component)((byId8 is Gun) ? byId8 : null)).gameObject.AddComponent<SAAModifiers>();
		PickupObject byId9 = PickupObjectDatabase.GetById(197);
		((Component)((byId9 is Gun) ? byId9 : null)).gameObject.AddComponent<PeashooterModifiers>();
		PickupObject byId10 = PickupObjectDatabase.GetById(476);
		((Component)((byId10 is Gun) ? byId10 : null)).gameObject.AddComponent<MTXGunModifiers>();
		PickupObject byId11 = PickupObjectDatabase.GetById(576);
		((Component)((byId11 is Gun) ? byId11 : null)).gameObject.AddComponent<RobotsLeftHandModifiers>();
		PickupObject byId12 = PickupObjectDatabase.GetById(149);
		((Component)((byId12 is Gun) ? byId12 : null)).gameObject.AddComponent<FaceMelterModifiers>();
		PickupObject byId13 = PickupObjectDatabase.GetById(275);
		((Component)((byId13 is Gun) ? byId13 : null)).gameObject.AddComponent<FlareGunModifiers>();
		PickupObject byId14 = PickupObjectDatabase.GetById(481);
		((Component)((byId14 is Gun) ? byId14 : null)).gameObject.AddComponent<CameraModifiers>();
		PickupObject byId15 = PickupObjectDatabase.GetById(402);
		((Component)((byId15 is Gun) ? byId15 : null)).gameObject.AddComponent<SnowballerModifiers>();
		PickupObject byId16 = PickupObjectDatabase.GetById(33);
		((Component)((byId16 is Gun) ? byId16 : null)).gameObject.AddComponent<TearJerkerModifiers>();
		PickupObject byId17 = PickupObjectDatabase.GetById(596);
		((Component)((byId17 is Gun) ? byId17 : null)).gameObject.AddComponent<TeapotModifiers>();
		PickupObject byId18 = PickupObjectDatabase.GetById(79);
		((Component)((byId18 is Gun) ? byId18 : null)).gameObject.AddComponent<MakarovModifiers>();
		List<Projectile> list = new List<Projectile>();
		PickupObject byId19 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId19 is Gun) ? byId19 : null)).DefaultModule.projectiles[0]);
		PickupObject byId20 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId20 is Gun) ? byId20 : null)).DefaultModule.projectiles[1]);
		PickupObject byId21 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId21 is Gun) ? byId21 : null)).DefaultModule.projectiles[2]);
		PickupObject byId22 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId22 is Gun) ? byId22 : null)).DefaultModule.projectiles[3]);
		PickupObject byId23 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId23 is Gun) ? byId23 : null)).DefaultModule.projectiles[4]);
		PickupObject byId24 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId24 is Gun) ? byId24 : null)).DefaultModule.projectiles[5]);
		PickupObject byId25 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId25 is Gun) ? byId25 : null)).DefaultModule.projectiles[6]);
		PickupObject byId26 = PickupObjectDatabase.GetById(597);
		list.Add(((Gun)((byId26 is Gun) ? byId26 : null)).DefaultModule.projectiles[7]);
		Planets = list;
	}
}
