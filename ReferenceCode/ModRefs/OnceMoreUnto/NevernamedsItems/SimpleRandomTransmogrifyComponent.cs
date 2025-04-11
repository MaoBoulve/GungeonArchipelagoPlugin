using System;
using System.Collections.Generic;
using Alexandria.EnemyAPI;
using UnityEngine;

namespace NevernamedsItems;

public class SimpleRandomTransmogrifyComponent : MonoBehaviour
{
	public bool maintainHPPercent;

	public List<string> RandomStringList = new List<string>();

	private Projectile self;

	public bool chaosPalette;

	public SimpleRandomTransmogrifyComponent()
	{
		chaosPalette = false;
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self))
		{
			Projectile obj = self;
			obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
		}
		if (chaosPalette)
		{
			RandomStringList = MagickeCauldron.GenerateChaosPalette();
		}
	}

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).healthHaver) && !fatal && !((BraveBehaviour)enemy).healthHaver.IsBoss && !((BraveBehaviour)enemy).healthHaver.IsDead && RandomStringList.Count > 0)
		{
			string text = BraveUtility.RandomElement<string>(RandomStringList);
			AIActorUtility.AdvancedTransmogrify(((BraveBehaviour)enemy).aiActor, EnemyDatabase.GetOrLoadByGuid(text), (GameObject)ResourceCache.Acquire("Global VFX/VFX_Item_Spawn_Poof"), "Play_ENM_wizardred_appear_01", false, (List<string>)null, (List<string>)null, true, true, maintainHPPercent, true, false, false);
		}
	}
}
