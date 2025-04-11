using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class MarchGunBulletController : MonoBehaviour
{
	private Projectile self;

	private float correctDirDamageMult;

	private float correctDirScaleMult;

	private float oppositeDirDamageMult;

	private float oppositeDirScaleMult;

	public MarchGunBulletController()
	{
		correctDirDamageMult = 2f;
		correctDirScaleMult = 1.2f;
		oppositeDirDamageMult = 1f;
		oppositeDirScaleMult = 1f;
	}

	private void Start()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		self = ((Component)this).GetComponent<Projectile>();
		PlayerController val = ProjectileUtility.ProjectilePlayerOwner(self);
		if (!Object.op_Implicit((Object)(object)val))
		{
			return;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Tappy Toes"))
		{
			oppositeDirDamageMult = 3f;
			oppositeDirScaleMult = 1.4f;
		}
		if (((BraveBehaviour)val).specRigidbody.Velocity != Vector2.zero)
		{
			float num = Vector2Extensions.ToAngle(val.LastCommandedDirection);
			float num2 = Vector2Extensions.ToAngle(self.Direction);
			if (CustomSynergies.PlayerHasActiveSynergy(val, "Step To The Beat"))
			{
				self.SendInDirection(MathsAndLogicHelper.DegreeToVector2(num), false, false);
				num2 = num;
				ProjectileData baseData = self.baseData;
				baseData.damage *= 2f;
			}
			if (MathsAndLogicHelper.IsBetweenRange(num2, -45f, 45f))
			{
				if (MathsAndLogicHelper.IsBetweenRange(num, -45f, 45f))
				{
					ProjectileData baseData2 = self.baseData;
					baseData2.damage *= correctDirDamageMult;
					self.RuntimeUpdateScale(correctDirScaleMult);
				}
				else if (MathsAndLogicHelper.IsBetweenRange(num, 135f, 180f) || MathsAndLogicHelper.IsBetweenRange(num, -180f, -135f))
				{
					ProjectileData baseData3 = self.baseData;
					baseData3.damage *= oppositeDirDamageMult;
					self.RuntimeUpdateScale(oppositeDirScaleMult);
				}
			}
			else if (MathsAndLogicHelper.IsBetweenRange(num2, 46f, 134f))
			{
				if (MathsAndLogicHelper.IsBetweenRange(num, 46f, 134f))
				{
					ProjectileData baseData4 = self.baseData;
					baseData4.damage *= correctDirDamageMult;
					self.RuntimeUpdateScale(correctDirScaleMult);
				}
				else if (MathsAndLogicHelper.IsBetweenRange(num, -134f, -46f))
				{
					ProjectileData baseData5 = self.baseData;
					baseData5.damage *= oppositeDirDamageMult;
					self.RuntimeUpdateScale(oppositeDirScaleMult);
				}
			}
			else if (MathsAndLogicHelper.IsBetweenRange(num2, -134f, -46f))
			{
				if (MathsAndLogicHelper.IsBetweenRange(num, -134f, -46f))
				{
					ProjectileData baseData6 = self.baseData;
					baseData6.damage *= correctDirDamageMult;
					self.RuntimeUpdateScale(correctDirScaleMult);
				}
				else if (MathsAndLogicHelper.IsBetweenRange(num, 46f, 136f) || MathsAndLogicHelper.IsBetweenRange(num, -135f, -180f))
				{
					ProjectileData baseData7 = self.baseData;
					baseData7.damage *= oppositeDirDamageMult;
					self.RuntimeUpdateScale(oppositeDirScaleMult);
				}
			}
			else if (MathsAndLogicHelper.IsBetweenRange(num2, 135f, 180f) || MathsAndLogicHelper.IsBetweenRange(num2, -180f, -135f))
			{
				if (MathsAndLogicHelper.IsBetweenRange(num, 135f, 180f) || MathsAndLogicHelper.IsBetweenRange(num, -180f, -135f))
				{
					ProjectileData baseData8 = self.baseData;
					baseData8.damage *= correctDirDamageMult;
					self.RuntimeUpdateScale(correctDirScaleMult);
				}
				else if (MathsAndLogicHelper.IsBetweenRange(num, -45f, 45f))
				{
					ProjectileData baseData9 = self.baseData;
					baseData9.damage *= oppositeDirDamageMult;
					self.RuntimeUpdateScale(oppositeDirScaleMult);
				}
			}
			if (MathsAndLogicHelper.IsBetweenRange(num, -45f, 45f))
			{
				((BraveBehaviour)self).sprite.spriteId = Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_right_projectile");
			}
			else if (MathsAndLogicHelper.IsBetweenRange(num, 46f, 134f))
			{
				((BraveBehaviour)self).sprite.spriteId = Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_up_projectile");
			}
			else if (MathsAndLogicHelper.IsBetweenRange(num, -134f, -46f))
			{
				((BraveBehaviour)self).sprite.spriteId = Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_down_projectile");
			}
			else if (MathsAndLogicHelper.IsBetweenRange(num, 135f, 180f) || MathsAndLogicHelper.IsBetweenRange(num, -180f, -135f))
			{
				((BraveBehaviour)self).sprite.spriteId = Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_left_projectile");
			}
		}
		else
		{
			((BraveBehaviour)self).sprite.spriteId = Databases.Items.ProjectileCollection.inst.GetSpriteIdByName("march_none_projectile");
			ProjectileData baseData10 = self.baseData;
			baseData10.damage *= 0.7f;
		}
	}
}
