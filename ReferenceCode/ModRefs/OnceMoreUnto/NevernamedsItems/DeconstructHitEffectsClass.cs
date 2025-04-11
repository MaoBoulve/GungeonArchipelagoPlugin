using UnityEngine;

namespace NevernamedsItems;

public static class DeconstructHitEffectsClass
{
	public static void DeconstructHitEffects(this ProjectileImpactVFXPool pool)
	{
		ETGModConsole.Log((object)"<color=#09b022>-------------------------------------</color>", false);
		ETGModConsole.Log((object)"<color=#09b022>Bools:</color>", false);
		ETGModConsole.Log((object)("<color=#ff0000ff>AlwaysUseMidair:</color> " + pool.alwaysUseMidair), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>CenterDeathVFXOnProj:</color> " + pool.CenterDeathVFXOnProjectile), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>HasProjectileDeathVFX:</color> " + pool.HasProjectileDeathVFX), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>SuppressMidairDeathVFX:</color> " + pool.suppressMidairDeathVfx), false);
		ETGModConsole.Log((object)("<color=#ff0000ff>SuppressHitEffectsIfOffscreen:</color> " + pool.suppressHitEffectsIfOffscreen), false);
		ETGModConsole.Log((object)"<color=#09b022>Effects:</color>", false);
		if (Object.op_Implicit((Object)(object)pool.overrideEarlyDeathVfx))
		{
			ETGModConsole.Log((object)("<color=#ff0000ff>    OverrideEarlyDeathVFX: </color>" + ((Object)pool.overrideEarlyDeathVfx).name), false);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   OverrideEarlyDeathVFX: </color>NULL", false);
		}
		if (Object.op_Implicit((Object)(object)pool.overrideMidairDeathVFX))
		{
			ETGModConsole.Log((object)("<color=#ff0000ff>    OverrideMidairDeathVFX: </color>" + ((Object)pool.overrideMidairDeathVFX).name), false);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   OverrideMidairDeathVFX: </color>NULL", false);
		}
		if (pool.deathAny != null)
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathAny: </color>", false);
			DeconstructVFXPool(pool.deathAny);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathAny: </color>NULL", false);
		}
		if (pool.deathEnemy != null)
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathEnemy: </color>", false);
			DeconstructVFXPool(pool.deathEnemy);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathEnemy: </color>NULL", false);
		}
		if (pool.deathTileMapHorizontal != null)
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathTilemapHorizontal: </color>", false);
			DeconstructVFXPool(pool.deathTileMapHorizontal);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathTilemapHorizontal: </color>NULL", false);
		}
		if (pool.deathTileMapVertical != null)
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathTilemapVertical: </color>", false);
			DeconstructVFXPool(pool.deathTileMapVertical);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   DeathTilemapVertical: </color>NULL", false);
		}
		if (pool.enemy != null)
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   Enemy(?): </color>", false);
			DeconstructVFXPool(pool.enemy);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   Enemy(?): </color>NULL", false);
		}
		if (pool.tileMapHorizontal != null)
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   TilemapHorizontal: </color>", false);
			DeconstructVFXPool(pool.tileMapHorizontal);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   TilemapHorizontal: </color>NULL", false);
		}
		if (pool.tileMapVertical != null)
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   TilemapVertical: </color>", false);
			DeconstructVFXPool(pool.tileMapVertical);
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>   TilemapVertical: </color>NULL", false);
		}
	}

	private static void DeconstructVFXPool(VFXPool pool)
	{
		int num = 0;
		if (pool.effects != null && pool.effects.Length != 0)
		{
			VFXComplex[] effects = pool.effects;
			foreach (VFXComplex val in effects)
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>      VFXPoolEffect: </color>" + num), false);
				if (val.effects != null && val.effects.Length != 0)
				{
					VFXObject[] effects2 = val.effects;
					foreach (VFXObject val2 in effects2)
					{
						ETGModConsole.Log((object)("<color=#ff0000ff>      VFXObject: </color>" + num), false);
						if ((Object)(object)val2.effect != (Object)null)
						{
							ETGModConsole.Log((object)("<color=#ff0000ff>           Effect: </color>" + ((Object)val2.effect).name), false);
						}
						else
						{
							ETGModConsole.Log((object)"<color=#ff0000ff>           Effect: </color>NULL", false);
						}
					}
				}
				else
				{
					ETGModConsole.Log((object)"<color=#ff0000ff>        VFXObject: </color>NULL", false);
				}
			}
		}
		else
		{
			ETGModConsole.Log((object)"<color=#ff0000ff>      VFXPoolEffects: </color>NULL", false);
		}
	}
}
