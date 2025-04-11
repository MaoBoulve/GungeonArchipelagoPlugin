using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BloodBurstOnKill : MonoBehaviour
{
	private Projectile projectile;

	private PlayerController owner;

	private void Start()
	{
		projectile = ((Component)this).GetComponent<Projectile>();
		if ((Object)(object)ProjectileUtility.ProjectilePlayerOwner(projectile) != (Object)null)
		{
			owner = ProjectileUtility.ProjectilePlayerOwner(projectile);
		}
		Projectile obj = projectile;
		obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		if (!(Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && fatal))
		{
			return;
		}
		float num = 0.1f;
		if (Object.op_Implicit((Object)(object)owner) && CustomSynergies.PlayerHasActiveSynergy(owner, "Blood For The Blood God"))
		{
			num = 0.2f;
		}
		if (Random.value <= num)
		{
			Object.Instantiate<GameObject>(SharedVFX.TeleporterPrototypeTelefragVFX, Vector2.op_Implicit(enemy.UnitCenter), Quaternion.identity);
			if (Object.op_Implicit((Object)(object)owner) && CustomSynergies.PlayerHasActiveSynergy(owner, "Blood For The Blood God"))
			{
				GoopDefinition val = EasyGoopDefinitions.GenerateBloodGoop(15f, Color.red);
				DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(val);
				goopManagerForGoopType.TimedAddGoopCircle(enemy.UnitCenter, 3f, 0.5f, false);
			}
			if (Object.op_Implicit((Object)(object)owner) && CustomSynergies.PlayerHasActiveSynergy(owner, "BLOOD IS FUEL") && Vector2.Distance(((BraveBehaviour)owner).sprite.WorldCenter, ((BraveBehaviour)enemy).sprite.WorldCenter) <= 4f)
			{
				((BraveBehaviour)owner).healthHaver.ApplyHealing(0.5f);
			}
		}
	}
}
