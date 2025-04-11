using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class GunsmokePerfume : AffectEnemiesInProximityTickItem
{
	public static void Init()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		AffectEnemiesInProximityTickItem affectEnemiesInProximityTickItem = ItemSetup.NewItem<GunsmokePerfume>("Gunsmoke Perfume", "Ode To Glock 42", "Charms enemies who get too close.\n\nThe enticing aroma of a battle hardened gunslinger!", "gunsmokeperfume_icon", assetbundle: true) as AffectEnemiesInProximityTickItem;
		affectEnemiesInProximityTickItem.range = 2f;
		affectEnemiesInProximityTickItem.rangeMultSynergy = "Practically Pungent";
		affectEnemiesInProximityTickItem.synergyRangeMult = 2f;
		((PickupObject)affectEnemiesInProximityTickItem).CanBeDropped = true;
		((PickupObject)affectEnemiesInProximityTickItem).quality = (ItemQuality)3;
	}

	public override void AffectEnemy(AIActor aiactor)
	{
		((GameActor)aiactor).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.charmingRoundsEffect, 1f, (Projectile)null);
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Regular Hottie"))
		{
			((GameActor)aiactor).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect, 1f, (Projectile)null);
		}
		base.AffectEnemy(aiactor);
	}
}
