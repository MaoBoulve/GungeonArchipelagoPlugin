using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NevernamedsItems;

public class StatusEffectBulletMod : MonoBehaviour
{
	public class StatusData
	{
		public GameActorEffect effect;

		public float applyChance;

		public Color effectTint;

		public bool applyTint = false;
	}

	private Projectile self;

	public List<StatusData> datasToApply = new List<StatusData>();

	public bool pickRandom;

	public StatusEffectBulletMod()
	{
		pickRandom = false;
	}

	private void Start()
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		self = ((Component)this).GetComponent<Projectile>();
		if (pickRandom)
		{
			List<StatusData> list = new List<StatusData>();
			foreach (StatusData item in datasToApply)
			{
				if (Random.value <= item.applyChance)
				{
					list.Add(item);
				}
			}
			if (list.Count() > 0)
			{
				StatusData statusData = BraveUtility.RandomElement<StatusData>(list);
				if (statusData.applyTint)
				{
					self.AdjustPlayerProjectileTint(statusData.effectTint, 1, 0f);
				}
				self.statusEffectsToApply.Add(statusData.effect);
			}
			return;
		}
		foreach (StatusData item2 in datasToApply)
		{
			if (Random.value <= item2.applyChance)
			{
				if (item2.applyTint)
				{
					self.AdjustPlayerProjectileTint(item2.effectTint, 1, 0f);
				}
				self.statusEffectsToApply.Add(item2.effect);
			}
		}
	}
}
