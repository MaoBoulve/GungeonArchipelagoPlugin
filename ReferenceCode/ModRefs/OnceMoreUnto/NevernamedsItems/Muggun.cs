using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class Muggun : GunBehaviour
{
	public static int PistaID;

	public static List<Projectile> ActiveBullets = new List<Projectile>();

	public static List<Projectile> BulletsToRemoveFromActiveBullets = new List<Projectile>();

	public static void Add()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Muggun", "muggun");
		Game.Items.Rename("outdated_gun_mods:muggun", "nn:muggun");
		((Component)val).gameObject.AddComponent<Muggun>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Yeeeeehaw!");
		GunExt.SetLongDescription((PickupObject)(object)val, "Six tiny spirits inhabit this gun, gleefully riding it's bullets into battle, and re-aiming them towards the nearest target when the owner signals them via reloading.\n\nThis gun smells vaguely Italian.");
		GunExt.SetupSprite(val, (tk2dSpriteCollectionData)null, "pista_idle_001", 8);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 15);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.81f, 0.62f, 0f);
		val.SetBaseMaxAmmo(400);
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		((BraveBehaviour)val2).transform.parent = val.barrelOffset;
		ProjectileData baseData = val2.baseData;
		baseData.speed *= 0.65f;
		ProjectileData baseData2 = val2.baseData;
		baseData2.range *= 2f;
		ProjectileData baseData3 = val2.baseData;
		baseData3.damage *= 1.6f;
		((PickupObject)val).quality = (ItemQuality)(-100);
		((BraveBehaviour)val).encounterTrackable.EncounterGuid = "this is the Pista";
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		PistaID = ((PickupObject)val).PickupObjectId;
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		ActiveBullets.Add(projectile);
		((GunBehaviour)this).PostProcessProjectile(projectile);
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveBullets.Count > 0)
		{
			foreach (Projectile activeBullet in ActiveBullets)
			{
				if (Object.op_Implicit((Object)(object)activeBullet))
				{
					Vector2 val = Random.insideUnitCircle;
					Vector2 worldCenter = ((BraveBehaviour)activeBullet).sprite.WorldCenter;
					Func<AIActor, bool> func = (AIActor a) => Object.op_Implicit((Object)(object)a) && a.HasBeenEngaged && Object.op_Implicit((Object)(object)((BraveBehaviour)a).healthHaver) && ((BraveBehaviour)a).healthHaver.IsVulnerable;
					IntVector2 val2 = Vector2Extensions.ToIntVector2(worldCenter, (VectorConversions)2);
					AIActor closestToPosition = BraveUtility.GetClosestToPosition<AIActor>(GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(val2).GetActiveEnemies((ActiveEnemyType)0), ((BraveBehaviour)activeBullet).sprite.WorldCenter, func, (AIActor[])(object)new AIActor[0]);
					if (Object.op_Implicit((Object)(object)closestToPosition))
					{
						val = ((GameActor)closestToPosition).CenterPosition - Vector3Extensions.XY(((BraveBehaviour)activeBullet).transform.position);
					}
					activeBullet.SendInDirection(val, false, true);
					if (!CustomSynergies.PlayerHasActiveSynergy(player, "Pistols Requiem"))
					{
						BulletsToRemoveFromActiveBullets.Add(activeBullet);
					}
				}
			}
			foreach (Projectile bulletsToRemoveFromActiveBullet in BulletsToRemoveFromActiveBullets)
			{
				ActiveBullets.Remove(bulletsToRemoveFromActiveBullet);
			}
			BulletsToRemoveFromActiveBullets.Clear();
		}
		((GunBehaviour)this).OnReloadPressed(player, gun, bSOMETHING);
	}
}
