using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class LaserBullets : PassiveItem
{
	public static Projectile SimpleRedBeam;

	public static void Init()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<LaserBullets>("Laser Bullets", "Hybrid", "A beam and bullet crossbreed that defies nature, these bullets make your bullets shoot... beams!", "laserbullets_icon", assetbundle: true);
		val.CanBeDropped = true;
		val.quality = (ItemQuality)3;
		Doug.AddToLootPool(val.PickupObjectId);
		AlexandriaTags.SetTag(val, "bullet_modifier");
		List<string> list = new List<string> { "NevernamedsItems/Resources/BeamSprites/redbeam_seg_001", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_002", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_003", "NevernamedsItems/Resources/BeamSprites/redbeam_seg_004" };
		List<string> list2 = new List<string> { "NevernamedsItems/Resources/BeamSprites/redbeam_impact_001", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_002", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_003", "NevernamedsItems/Resources/BeamSprites/redbeam_impact_004" };
		PickupObject byId = PickupObjectDatabase.GetById(86);
		Projectile val2 = Object.Instantiate<Projectile>(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]);
		BasicBeamController val3 = BeamAPI.GenerateBeamPrefab(val2, "NevernamedsItems/Resources/BeamSprites/redbeam_seg_001", new Vector2(18f, 2f), new Vector2(0f, 8f), list, 8, list2, 13, (Vector2?)new Vector2(4f, 4f), (Vector2?)new Vector2(7f, 7f), (List<string>)null, -1, (Vector2?)null, (Vector2?)null, (List<string>)null, -1, (Vector2?)null, (Vector2?)null, 0f, 0f);
		((Component)val2).gameObject.SetActive(false);
		ProjectileData baseData = val2.baseData;
		baseData.damage *= 4f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.speed *= 4f;
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val3.boneType = (BeamBoneType)0;
		val3.interpolateStretchedBones = false;
		val3.ContinueBeamArtToWall = true;
		SimpleRedBeam = val2;
	}

	private void PostProcess(Projectile bullet, float thing)
	{
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Invalid comparison between Unknown and I4
		float num = 0.2f;
		num *= thing;
		if (!(Random.value <= num) || !((Object)(object)((Component)bullet).GetComponent<BeamBulletsBehaviour>() == (Object)null) || !((Object)(object)((Component)bullet).GetComponent<BulletIsFromBeam>() == (Object)null))
		{
			return;
		}
		BeamBulletsBehaviour beamBulletsBehaviour = ((Component)bullet).gameObject.AddComponent<BeamBulletsBehaviour>();
		if (Random.value <= 0.5f)
		{
			beamBulletsBehaviour.firetype = BeamBulletsBehaviour.FireType.PLUS;
		}
		else
		{
			beamBulletsBehaviour.firetype = BeamBulletsBehaviour.FireType.CROSS;
		}
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "new Vector2(x, y)"))
		{
			beamBulletsBehaviour.firetype = BeamBulletsBehaviour.FireType.STAR;
		}
		beamBulletsBehaviour.beamToFire = SimpleRedBeam;
		List<Projectile> list = new List<Projectile>();
		if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Beam Me Up!") && Random.value <= 0.2f)
		{
			for (int i = 0; i < ((PassiveItem)this).Owner.inventory.AllGuns.Count; i++)
			{
				if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner.inventory.AllGuns[i]) && !((PassiveItem)this).Owner.inventory.AllGuns[i].InfiniteAmmo)
				{
					ProjectileModule defaultModule = ((PassiveItem)this).Owner.inventory.AllGuns[i].DefaultModule;
					if ((int)defaultModule.shootStyle == 2)
					{
						list.Add(defaultModule.GetCurrentProjectile());
					}
				}
			}
			beamBulletsBehaviour.beamToFire = BraveUtility.RandomElement<Projectile>(list);
		}
		ProjectileData baseData = bullet.baseData;
		baseData.speed *= 0.2f;
		bullet.UpdateSpeed();
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += PostProcess;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcess;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcess;
		}
		((PassiveItem)this).OnDestroy();
	}
}
