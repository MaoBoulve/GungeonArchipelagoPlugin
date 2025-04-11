using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class CameraModifiers : GunBehaviour
{
	public override void PostProcessProjectile(Projectile projectile)
	{
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile)))
		{
			PlayerController val = ProjectileUtility.ProjectilePlayerOwner(projectile);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Infrared Camera"))
			{
				foreach (PassiveItem passiveItem in val.passiveItems)
				{
					if (!(passiveItem is InfraredGuonStone))
					{
						continue;
					}
					GameObject val2 = (passiveItem as InfraredGuonStone).GimmeOrbital();
					if ((Object)(object)val2 != (Object)null)
					{
						float num = 0f;
						for (int i = 0; i < 8; i++)
						{
							BeamAPI.FreeFireBeamFromAnywhere(InfraredGuonStone.InfraredBeam, val, val2, Vector2.zero, num, 1f, false, false, 0f);
							num += 45f;
						}
					}
				}
			}
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Behind the Goops"))
			{
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(CustomSynergies.PlayerHasActiveSynergy(val, "Hot Pics") ? GoopUtility.GreenFireDef : GoopUtility.PoisonDef).AddGoopCircle(((BraveBehaviour)val).sprite.WorldCenter, 10f, -1, false, -1);
			}
			else if (CustomSynergies.PlayerHasActiveSynergy(val, "Hot Pics"))
			{
				DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(GoopUtility.FireDef).AddGoopCircle(((BraveBehaviour)val).sprite.WorldCenter, 10f, -1, false, -1);
			}
		}
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}
}
