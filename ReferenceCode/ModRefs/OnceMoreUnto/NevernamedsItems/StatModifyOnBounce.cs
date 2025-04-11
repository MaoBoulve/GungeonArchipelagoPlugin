using System;
using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class StatModifyOnBounce : MonoBehaviour
{
	public enum ProjectileStatType
	{
		DAMAGE,
		SPEED,
		RANGE,
		SCALE,
		KNOCKBACK,
		BOSSDAMAGE,
		JAMMEDDAMAGE
	}

	public class Modifiers
	{
		public ProjectileStatType stattype;

		public float amount;

		public bool additive;
	}

	public List<Modifiers> mods = new List<Modifiers>();

	public Projectile self;

	public BounceProjModifier bouncer;

	public void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		bouncer = ((Component)this).GetComponent<BounceProjModifier>();
		if (Object.op_Implicit((Object)(object)bouncer))
		{
			BounceProjModifier obj = bouncer;
			obj.OnBounceContext = (Action<BounceProjModifier, SpeculativeRigidbody>)Delegate.Combine(obj.OnBounceContext, new Action<BounceProjModifier, SpeculativeRigidbody>(OnBounceContext));
		}
	}

	public void OnBounceContext(BounceProjModifier modifier, SpeculativeRigidbody body)
	{
		foreach (Modifiers mod in mods)
		{
			switch (mod.stattype)
			{
			case ProjectileStatType.DAMAGE:
				if (mod.additive)
				{
					ProjectileData baseData3 = self.baseData;
					baseData3.damage += mod.amount;
				}
				else
				{
					ProjectileData baseData4 = self.baseData;
					baseData4.damage *= mod.amount;
				}
				break;
			case ProjectileStatType.SPEED:
				if (mod.additive)
				{
					ProjectileData baseData = self.baseData;
					baseData.speed += mod.amount;
				}
				else
				{
					ProjectileData baseData2 = self.baseData;
					baseData2.speed *= mod.amount;
				}
				self.UpdateSpeed();
				break;
			case ProjectileStatType.RANGE:
				if (mod.additive)
				{
					ProjectileData baseData5 = self.baseData;
					baseData5.range += mod.amount;
				}
				else
				{
					ProjectileData baseData6 = self.baseData;
					baseData6.range *= mod.amount;
				}
				break;
			case ProjectileStatType.SCALE:
				self.RuntimeUpdateScale(mod.amount);
				break;
			case ProjectileStatType.KNOCKBACK:
				if (mod.additive)
				{
					ProjectileData baseData7 = self.baseData;
					baseData7.force += mod.amount;
				}
				else
				{
					ProjectileData baseData8 = self.baseData;
					baseData8.force *= mod.amount;
				}
				break;
			case ProjectileStatType.BOSSDAMAGE:
				if (mod.additive)
				{
					Projectile obj3 = self;
					obj3.BossDamageMultiplier += mod.amount;
				}
				else
				{
					Projectile obj4 = self;
					obj4.BossDamageMultiplier *= mod.amount;
				}
				break;
			case ProjectileStatType.JAMMEDDAMAGE:
				if (mod.additive)
				{
					Projectile obj = self;
					obj.BlackPhantomDamageMultiplier += mod.amount;
				}
				else
				{
					Projectile obj2 = self;
					obj2.BlackPhantomDamageMultiplier *= mod.amount;
				}
				break;
			}
		}
	}
}
