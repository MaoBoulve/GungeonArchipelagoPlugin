using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BigShotProjectileComp : MonoBehaviour
{
	private List<string> dialogue = new List<string>
	{
		"NOW'S YOUR CHANCE TO BE A BIG SHOT", "LOW, LOW, PRICE!", "BIGGER AND BETTER THAN EVER", "All Alone On A Late Night?", "BIG SHOT!!!!!", "Hyperlink Blocked.", "FREE KROMER", "WELL HAVE I GOT A DEAL FOR YOU!!", "$VALUES$", "$$DEALS$",
		"$'CHEAP'", "$$49.998", "Press F1 for Help"
	};

	private Projectile self;

	private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)enemy) && Random.value <= 0.05f)
		{
			string text = BraveUtility.RandomElement<string>(dialogue);
			Position position = enemy.Position;
			VFXToolbox.DoStringSquirt(text, ((Position)(ref position)).GetPixelVector2(), ExtendedColours.honeyYellow);
			if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)) && CustomSynergies.PlayerHasActiveSynergy(ProjectileUtility.ProjectilePlayerOwner(bullet), "De4l 0f 4 Lif3tim3"))
			{
				position = enemy.Position;
				LootEngine.SpawnCurrency(((Position)(ref position)).GetPixelVector2(), Random.Range(2, 5), false);
			}
		}
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self))
		{
			Projectile obj = self;
			obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
			switch (Random.Range(1, 7))
			{
			case 1:
			{
				PierceProjModifier orAddComponent5 = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)self).gameObject);
				orAddComponent5.penetration += 2;
				break;
			}
			case 2:
			{
				BounceProjModifier orAddComponent4 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)self).gameObject);
				orAddComponent4.numberOfBounces += 2;
				break;
			}
			case 3:
			{
				RemoteBulletsProjectileBehaviour orAddComponent3 = GameObjectExtensions.GetOrAddComponent<RemoteBulletsProjectileBehaviour>(((Component)self).gameObject);
				break;
			}
			case 4:
			{
				AngryBulletsProjectileBehaviour orAddComponent2 = GameObjectExtensions.GetOrAddComponent<AngryBulletsProjectileBehaviour>(((Component)self).gameObject);
				break;
			}
			case 5:
			{
				OrbitalBulletsBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<OrbitalBulletsBehaviour>(((Component)self).gameObject.gameObject);
				break;
			}
			case 6:
			{
				HomingModifier val = ((Component)self).gameObject.gameObject.AddComponent<HomingModifier>();
				val.HomingRadius = 100f;
				break;
			}
			}
		}
	}
}
