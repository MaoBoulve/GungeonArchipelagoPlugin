using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class FaceMelterModifiers : GunBehaviour
{
	private bool synergyBoostActive;

	private StatModifier movementMod;

	private StatModifier dodgeMod;

	private StatModifier damageMod;

	public override void Update()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		if (movementMod == null)
		{
			movementMod = new StatModifier
			{
				statToBoost = (StatType)0,
				amount = 1.45f,
				modifyType = (ModifyMethod)1
			};
		}
		if (damageMod == null)
		{
			damageMod = new StatModifier
			{
				statToBoost = (StatType)5,
				amount = 1.1f,
				modifyType = (ModifyMethod)1
			};
		}
		if (dodgeMod == null)
		{
			dodgeMod = new StatModifier
			{
				statToBoost = (StatType)28,
				amount = 1.45f,
				modifyType = (ModifyMethod)1
			};
		}
		if (!Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			return;
		}
		if ((Object)(object)base.gun.CurrentOwner.CurrentGun == (Object)(object)base.gun)
		{
			GameActor currentOwner = base.gun.CurrentOwner;
			if (CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null), "Underground") && !synergyBoostActive)
			{
				GiveSynergyBoost();
				synergyBoostActive = true;
				return;
			}
			GameActor currentOwner2 = base.gun.CurrentOwner;
			if (!CustomSynergies.PlayerHasActiveSynergy((PlayerController)(object)((currentOwner2 is PlayerController) ? currentOwner2 : null), "Underground") && synergyBoostActive)
			{
				RemoveSynergyBoost();
				synergyBoostActive = false;
			}
		}
		else if (synergyBoostActive)
		{
			RemoveSynergyBoost();
			synergyBoostActive = false;
		}
	}

	public override void OnDropped()
	{
		if (synergyBoostActive)
		{
			RemoveSynergyBoost();
			synergyBoostActive = false;
		}
		((GunBehaviour)this).OnDropped();
	}

	private void GiveSynergyBoost()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		ETGModConsole.Log((object)"Gave boost", false);
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		val.baseFlatColorOverride = Vector3Extensions.WithAlpha(Color.blue, 1f);
		val.ownerlessStatModifiers.Add(movementMod);
		val.ownerlessStatModifiers.Add(dodgeMod);
		val.ownerlessStatModifiers.Add(damageMod);
		val.stats.RecalculateStats(val, true, false);
	}

	private void RemoveSynergyBoost()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		GameActor currentOwner = base.gun.CurrentOwner;
		PlayerController val = (PlayerController)(object)((currentOwner is PlayerController) ? currentOwner : null);
		val.baseFlatColorOverride = Vector3Extensions.WithAlpha(Color.blue, 0f);
		val.ownerlessStatModifiers.Remove(movementMod);
		val.ownerlessStatModifiers.Remove(dodgeMod);
		val.ownerlessStatModifiers.Remove(damageMod);
		val.stats.RecalculateStats(val, true, false);
	}
}
