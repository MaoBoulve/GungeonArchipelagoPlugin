using System;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class UnderbarrelShotgun : PassiveItem
{
	public static int ID;

	public bool canActivate = true;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<UnderbarrelShotgun>("Underbarrel Shotgun", "Triple Barrel", "Fires a shotgun blast upon reloading.\n\nCreated by the infamous gunslinger \"Glass-wrists Junders\" to add more power to his sidearm. After the end of his ill-fated shooting career, this ridiculous artefact found its way to the Gungeon.", "underbarrelshotgun_icon", assetbundle: true);
		val.quality = (ItemQuality)1;
		ID = val.PickupObjectId;
		val.SetupUnlockOnCustomStat(CustomTrackedStats.BEGGAR_TOTAL_DONATIONS, 154f, (PrerequisiteOperation)2);
	}

	public override void Pickup(PlayerController player)
	{
		player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(HandleGunReloaded));
		}
		((PassiveItem)this).DisableEffect(player);
	}

	private void HandleGunReloaded(PlayerController player, Gun playerGun)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		if (canActivate)
		{
			for (int i = 0; i < 5; i++)
			{
				PickupObject byId = PickupObjectDatabase.GetById(56);
				Projectile component = ProjectileUtility.InstantiateAndFireInDirection(((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0], Vector2.op_Implicit(playerGun.barrelOffset.position), ((Object)(object)((GameActor)((PassiveItem)this).Owner).CurrentGun == (Object)null) ? 0f : ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle, 40f, player).GetComponent<Projectile>();
				component.Owner = (GameActor)(object)player;
				component.Shooter = ((BraveBehaviour)player).specRigidbody;
				component.baseData.range = 10f;
				ProjectileData baseData = component.baseData;
				baseData.speed *= Random.Range(0.8f, 1.2f);
				component.ScaleByPlayerStats(player);
				player.DoPostProcessProjectile(component);
			}
			AkSoundEngine.PostEvent("Play_WPN_smileyrevolver_shot_01", ((Component)player).gameObject);
			PickupObject byId2 = PickupObjectDatabase.GetById(83);
			((Gun)((byId2 is Gun) ? byId2 : null)).muzzleFlashEffects.SpawnAtPosition(playerGun.barrelOffset.position, ((GameActor)((PassiveItem)this).Owner).CurrentGun.CurrentAngle, (Transform)null, (Vector2?)null, (Vector2?)null, (float?)(-0.05f), false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
			canActivate = false;
			((MonoBehaviour)this).Invoke("Reset", 1f);
		}
	}

	private void Reset()
	{
		canActivate = true;
	}
}
