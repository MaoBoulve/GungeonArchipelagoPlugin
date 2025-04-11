using System;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BlastingCap : PassiveItem
{
	public static int ID;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<BlastingCap>("Blasting Cap", "Dire Spore", "Empowers explosions with damaging spores.\n\nThe fruiting caps of this fantastic fungus is known to contain a small gunpowder payload- allowing it to violently detonate in order to spread it's spores.", "blastingcap_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)2;
		ID = ((PickupObject)val).PickupObjectId;
	}

	public override void Pickup(PlayerController player)
	{
		CustomActions.OnExplosionComplex = (Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>)(object)Delegate.Combine((Delegate)(object)CustomActions.OnExplosionComplex, (Delegate)(object)new Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>(Explosion));
		((PassiveItem)this).Pickup(player);
	}

	public void Explosion(Vector3 position, ExplosionData data, Vector2 dir, Action onbegin, bool ignoreQueues, CoreDamageTypes damagetypes, bool ignoreDamageCaps)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		AkSoundEngine.PostEvent("Play_ENM_mushroom_cloud_01", ((Component)this).gameObject);
		int num = ((data.damageRadius > 2f) ? Mathf.CeilToInt(data.damageRadius * 10f) : Mathf.CeilToInt(data.damageRadius * 5f));
		for (int i = 0; i < num; i++)
		{
			PickupObject byId = PickupObjectDatabase.GetById(FungoCannon.FungoCannonID);
			GameObject gameObject = ((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile).gameObject;
			GameObject val = Object.Instantiate<GameObject>(gameObject, position, Quaternion.Euler(new Vector3(0f, 0f, (float)Random.Range(0, 360))));
			Projectile component = val.GetComponent<Projectile>();
			if (Object.op_Implicit((Object)(object)component))
			{
				component.Owner = (GameActor)(object)((PassiveItem)this).Owner;
				component.Shooter = ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody;
				((Component)component).gameObject.AddComponent<BounceProjModifier>();
				((Component)component).gameObject.AddComponent<PierceProjModifier>();
				ProjectileData baseData = component.baseData;
				baseData.damage *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)5);
				ProjectileData baseData2 = component.baseData;
				baseData2.speed *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)6);
				ProjectileData baseData3 = component.baseData;
				baseData3.range *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)26);
				ProjectileData baseData4 = component.baseData;
				baseData4.force *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)12);
				component.BossDamageMultiplier *= ((PassiveItem)this).Owner.stats.GetStatValue((StatType)22);
				component.UpdateSpeed();
				if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Screamosynthesis") && Random.value <= 0.07f)
				{
					BlankProjModifier blankProjModifier = ((Component)component).gameObject.AddComponent<BlankProjModifier>();
				}
				((PassiveItem)this).Owner.DoPostProcessProjectile(component);
			}
		}
	}

	public override void DisableEffect(PlayerController player)
	{
		CustomActions.OnExplosionComplex = (Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>)(object)Delegate.Remove((Delegate)(object)CustomActions.OnExplosionComplex, (Delegate)(object)new Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool>(Explosion));
		((PassiveItem)this).DisableEffect(player);
	}
}
