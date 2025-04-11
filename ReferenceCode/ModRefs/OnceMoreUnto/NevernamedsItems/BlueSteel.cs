using UnityEngine;

namespace NevernamedsItems;

public class BlueSteel : AffectEnemiesInProximityTickItem
{
	public static GameActorSpeedEffect lockdownToApply;

	public static void Init()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		AffectEnemiesInProximityTickItem affectEnemiesInProximityTickItem = ItemSetup.NewItem<BlueSteel>("Blue Steel", ":o", "Freeze enemies in place with your captivating trademark stare!", "bluesteel_icon", assetbundle: true) as AffectEnemiesInProximityTickItem;
		affectEnemiesInProximityTickItem.range = 5f;
		((PickupObject)affectEnemiesInProximityTickItem).CanBeDropped = true;
		((PickupObject)affectEnemiesInProximityTickItem).quality = (ItemQuality)3;
		lockdownToApply = new GameActorSpeedEffect
		{
			duration = 0.5f,
			TintColor = Color.grey,
			DeathTintColor = Color.grey,
			effectIdentifier = "Lockdown",
			AppliesTint = true,
			AppliesDeathTint = false,
			resistanceType = (EffectResistanceType)0,
			SpeedMultiplier = 0f,
			OverheadVFX = SharedVFX.LockdownOverhead,
			AffectsEnemies = true,
			AffectsPlayers = false,
			AppliesOutlineTint = false,
			OutlineTintColor = Color.grey,
			PlaysVFXOnActor = false,
			stackMode = (EffectStackingMode)0
		};
	}

	public override void AffectEnemy(AIActor aiactor)
	{
		((GameActor)aiactor).ApplyEffect((GameActorEffect)(object)lockdownToApply, 1f, (Projectile)null);
		base.AffectEnemy(aiactor);
	}
}
