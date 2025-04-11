using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public static class MiscToolbox
{
	public static void AssignToPlayer(this Projectile bullet, PlayerController player, bool postProcess = false)
	{
		if (Object.op_Implicit((Object)(object)player) && Object.op_Implicit((Object)(object)bullet))
		{
			bullet.Owner = (GameActor)(object)player;
			bullet.Shooter = ((BraveBehaviour)player).specRigidbody;
			ProjectileData baseData = bullet.baseData;
			baseData.damage *= player.stats.GetStatValue((StatType)5);
			ProjectileData baseData2 = bullet.baseData;
			baseData2.speed *= player.stats.GetStatValue((StatType)6);
			ProjectileData baseData3 = bullet.baseData;
			baseData3.range *= player.stats.GetStatValue((StatType)26);
			ProjectileData baseData4 = bullet.baseData;
			baseData4.force *= player.stats.GetStatValue((StatType)12);
			bullet.BossDamageMultiplier *= player.stats.GetStatValue((StatType)12);
			if (postProcess)
			{
				player.DoPostProcessProjectile(bullet);
			}
		}
	}

	public static void SpawnShield(PlayerController user, Vector3 location)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		Gun currentGun = ((GameActor)user).CurrentGun;
		PickupObject byId = PickupObjectDatabase.GetById(380);
		GameObject gameObject = ((Gun)((byId is Gun) ? byId : null)).ObjectToInstantiateOnReload.gameObject;
		GameObject val = Object.Instantiate<GameObject>(gameObject, location, Quaternion.identity);
		SingleSpawnableGunPlacedObject @interface = GameObjectExtensions.GetInterface<SingleSpawnableGunPlacedObject>(val);
		BreakableShieldController component = val.GetComponent<BreakableShieldController>();
		if (Object.op_Implicit((Object)(object)val))
		{
			@interface.Initialize(currentGun);
			component.Initialize(currentGun);
		}
		if (location != Vector3.zero)
		{
			((BraveBehaviour)component).transform.position = location;
			((BraveBehaviour)component).specRigidbody.Reinitialize();
		}
	}

	public static RoomHandler GetAbsoluteRoomFromProjectile(Projectile bullet)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		Vector2 worldCenter = ((BraveBehaviour)bullet).sprite.WorldCenter;
		IntVector2 val = Vector2Extensions.ToIntVector2(worldCenter, (VectorConversions)2);
		return GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(val);
	}

	public static float Vector2ToDegree(Vector2 p_vector2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (p_vector2.x < 0f)
		{
			return 360f - Mathf.Atan2(p_vector2.x, p_vector2.y) * 57.29578f * -1f;
		}
		return Mathf.Atan2(p_vector2.x, p_vector2.y) * 57.29578f;
	}

	public static void ApplyFear(this AIActor enemy, PlayerController player, float fearLength, float fearStartDistance, float fearStopDistance)
	{
		EnemyFeared enemyFeared = ((Component)enemy).gameObject.AddComponent<EnemyFeared>();
		enemyFeared.player = player;
		enemyFeared.fearLength = fearLength;
		enemyFeared.fearStartDistance = fearStartDistance;
		enemyFeared.fearStopDistance = fearStopDistance;
	}
}
