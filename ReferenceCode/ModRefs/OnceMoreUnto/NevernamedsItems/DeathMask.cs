using System.Collections.Generic;
using Dungeonator;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class DeathMask : PassiveItem
{
	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<DeathMask>("Death Mask", "Face Off", "Chance to clear the room when damage is taken or a blank is used. \n\nA cracked burial mask worn by a high class noble at their first funeral.", "deathmask_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.RAT_KILLED_SHADE, requiredFlagValue: true);
	}

	private void OnUseBlank(PlayerController cont, int idk)
	{
		if (Random.value <= 0.1f)
		{
			DeathCurse(cont);
		}
	}

	private void OnRecievedDamage(PlayerController player)
	{
		if (Random.value <= 0.1f)
		{
			DeathCurse(player);
		}
	}

	public override void Pickup(PlayerController player)
	{
		player.OnUsedBlank += OnUseBlank;
		player.OnReceivedDamage += OnRecievedDamage;
		((PassiveItem)this).Pickup(player);
	}

	public override void DisableEffect(PlayerController player)
	{
		player.OnUsedBlank -= OnUseBlank;
		player.OnReceivedDamage -= OnRecievedDamage;
		((PassiveItem)this).DisableEffect(player);
	}

	private void DeathCurse(PlayerController playa)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		List<AIActor> activeEnemies = playa.CurrentRoom.GetActiveEnemies((ActiveEnemyType)0);
		GameManager.Instance.MainCameraController.DoScreenShake(StaticExplosionDatas.genericLargeExplosion.ss, (Vector2?)null, false);
		Pixelator.Instance.FadeToColor(0.1f, Color.white, true, 0.1f);
		Exploder.DoDistortionWave(((GameActor)playa).CenterPosition, 0.4f, 0.15f, 10f, 0.4f);
		if (playa.CurrentRoom != null)
		{
			playa.CurrentRoom.ClearReinforcementLayers();
		}
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val = activeEnemies[i];
			if (val.IsNormalEnemy && Object.op_Implicit((Object)(object)((BraveBehaviour)val).healthHaver))
			{
				((BraveBehaviour)val).healthHaver.ApplyDamage(((BraveBehaviour)val).healthHaver.IsBoss ? 100f : 10000000f, Vector2.zero, string.Empty, (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
			}
		}
	}
}
