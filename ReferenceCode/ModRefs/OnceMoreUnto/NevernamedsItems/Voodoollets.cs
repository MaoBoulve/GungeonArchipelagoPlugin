using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

internal class Voodoollets : PassiveItem
{
	private GameActorCharmEffect charmEffect = ((Component)Game.Items["charming_rounds"]).GetComponent<BulletStatusEffectItem>().CharmModifierEffect;

	public static bool OnCooldownVoodoo;

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<Voodoollets>("Voodoollets", "Doll-ay, Oh, Oh, We Come Doll-ay!", "Whenever any enemy suffers damage, another shall be wounded in kind.\n\nA relic left behind by a strange cult of voodoo worshippers, who sought to open a portal to Bullet Heaven.\nThey vanished without a trace. Perhaps what awaited them was not the heaven they had hoped.\n\nKaliba Eleison", "voodoollets_icon", assetbundle: true);
		val.quality = (ItemQuality)4;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		ItemBuilder.AddToSubShop(val, (ShopType)2, 1f);
		Doug.AddToLootPool(val.PickupObjectId);
	}

	private void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemy)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor) || !Object.op_Implicit((Object)(object)enemy))
			{
				return;
			}
			if (fatal && ((PassiveItem)this).Owner.HasPickupID(71) && Random.value < 0.1f)
			{
				SpawnObjectPlayerItem component = ((Component)PickupObjectDatabase.GetById(71)).GetComponent<SpawnObjectPlayerItem>();
				GameObject gameObject = component.objectToSpawn.gameObject;
				GameObject val = Object.Instantiate<GameObject>(gameObject, Vector2.op_Implicit(((BraveBehaviour)enemy).sprite.WorldBottomCenter), Quaternion.identity);
				tk2dBaseSprite component2 = val.GetComponent<tk2dBaseSprite>();
				if (Object.op_Implicit((Object)(object)component2))
				{
					component2.PlaceAtPositionByAnchor(Vector2.op_Implicit(((BraveBehaviour)enemy).sprite.WorldBottomCenter), (Anchor)4);
				}
			}
			float num = damage;
			if (((PassiveItem)this).Owner.HasPickupID(442))
			{
				num *= 2f;
			}
			RoomHandler absoluteRoom = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position);
			List<AIActor> list = new List<AIActor>();
			if (absoluteRoom.GetActiveEnemies((ActiveEnemyType)1) != null)
			{
				foreach (AIActor activeEnemy in absoluteRoom.GetActiveEnemies((ActiveEnemyType)1))
				{
					list.Add(activeEnemy);
				}
			}
			AIActor val2 = null;
			AIActor val3 = null;
			if (list.Count > 1)
			{
				list.Remove(((BraveBehaviour)enemy).aiActor);
				val2 = BraveUtility.RandomElement<AIActor>(list);
				if (list.Count > 2 && (((PassiveItem)this).Owner.HasPickupID(276) || ((PassiveItem)this).Owner.HasPickupID(149) || ((PassiveItem)this).Owner.HasPickupID(482) || ((PassiveItem)this).Owner.HasPickupID(506) || ((PassiveItem)this).Owner.HasPickupID(172) || ((PassiveItem)this).Owner.HasPickupID(198) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:spectre_bullets"].PickupObjectId)))
				{
					list.Remove(val2);
					val3 = BraveUtility.RandomElement<AIActor>(list);
				}
			}
			if (!((Object)(object)val2 != (Object)null) || !((Object)(object)val2 != (Object)(object)((BraveBehaviour)enemy).aiActor) || !Object.op_Implicit((Object)(object)((BraveBehaviour)val2).healthHaver) || !((BraveBehaviour)val2).healthHaver.IsAlive || !((BraveBehaviour)val2).healthHaver.IsVulnerable || OnCooldownVoodoo)
			{
				return;
			}
			OnCooldownVoodoo = true;
			if (((PassiveItem)this).Owner.HasPickupID(527) && Random.value < 0.25f)
			{
				((BraveBehaviour)val2).gameActor.ApplyEffect((GameActorEffect)(object)charmEffect, 1f, (Projectile)null);
			}
			((BraveBehaviour)val2).healthHaver.ApplyDamage(num, Vector2.zero, "Voodoo Magic", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			if ((((PassiveItem)this).Owner.HasPickupID(276) || ((PassiveItem)this).Owner.HasPickupID(149) || ((PassiveItem)this).Owner.HasPickupID(482) || ((PassiveItem)this).Owner.HasPickupID(506) || ((PassiveItem)this).Owner.HasPickupID(172) || ((PassiveItem)this).Owner.HasPickupID(198) || ((PassiveItem)this).Owner.HasPickupID(Game.Items["nn:spectre_bullets"].PickupObjectId)) && (Object)(object)val3 != (Object)null && (Object)(object)val3 != (Object)(object)((BraveBehaviour)enemy).aiActor && Object.op_Implicit((Object)(object)((BraveBehaviour)val3).healthHaver) && ((BraveBehaviour)val3).healthHaver.IsAlive && ((BraveBehaviour)val3).healthHaver.IsVulnerable)
			{
				if (((PassiveItem)this).Owner.HasPickupID(527) && Random.value < 0.25f)
				{
					((BraveBehaviour)val3).gameActor.ApplyEffect((GameActorEffect)(object)charmEffect, 1f, (Projectile)null);
				}
				((BraveBehaviour)val3).healthHaver.ApplyDamage(num, Vector2.zero, "Voodoo Magic", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			}
			((MonoBehaviour)this).Invoke("Cooldown", 0.01f);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
			ETGModConsole.Log((object)"IF YOU SEE THIS PLEASE REPORT IT TO NEVERNAMED (WITH SCREENSHOTS)", false);
		}
	}

	private void Cooldown()
	{
		OnCooldownVoodoo = false;
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		return result;
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(owner.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(OnEnemyDamaged));
		}
		((PassiveItem)this).OnDestroy();
	}
}
