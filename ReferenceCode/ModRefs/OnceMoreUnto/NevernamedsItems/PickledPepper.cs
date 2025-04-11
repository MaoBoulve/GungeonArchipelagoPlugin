namespace NevernamedsItems;

public class PickledPepper : AffectEnemiesInProximityTickItem
{
	public static void Init()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		AffectEnemiesInProximityTickItem affectEnemiesInProximityTickItem = ItemSetup.NewItem<PickledPepper>("Pickled Pepper", "Picked In Pecks", "Poisons enemies who come too close. \n\nA Gungeon Pepper soaked in pickling brine until it turns a bright green colour. \n\nThe noxious vapour from this delicacy is enough to dissolve your foes from the inside out.", "pickledpepper_icon", assetbundle: true) as AffectEnemiesInProximityTickItem;
		affectEnemiesInProximityTickItem.range = 3.5f;
		((PickupObject)affectEnemiesInProximityTickItem).CanBeDropped = true;
		((PickupObject)affectEnemiesInProximityTickItem).quality = (ItemQuality)3;
	}

	public override void AffectEnemy(AIActor aiactor)
	{
		((GameActor)aiactor).ApplyEffect((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect, 1f, (Projectile)null);
		base.AffectEnemy(aiactor);
	}
}
