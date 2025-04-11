using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class ActiveTestingItem : PlayerItem
{
	private class SlowingCircle : MagicCircle
	{
		public override void TickOnEnemy(AIActor enemy)
		{
			((BraveBehaviour)enemy).gameActor.ApplyEffect((GameActorEffect)(object)EasyGoopDefinitions.HoneyGoop.SpeedModifierEffect, 1f, (Projectile)null);
			base.TickOnEnemy(enemy);
		}

		public override void EnemyEnteredCircle(AIActor enemy)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			((GameActor)enemy).DeregisterOverrideColor("magiccircle");
			((GameActor)enemy).RegisterOverrideColor(Color.green, "magiccircle");
			base.EnemyEnteredCircle(enemy);
		}

		public override void EnemyLeftCircle(AIActor enemy)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			((GameActor)enemy).DeregisterOverrideColor("magiccircle");
			((GameActor)enemy).RegisterOverrideColor(Color.red, "magiccircle");
			base.EnemyLeftCircle(enemy);
		}
	}

	public static GameObject magicCircle;

	public static GoopDefinition def = EasyGoopDefinitions.BulletKingWine;

	public static string sound = "Stop_BOSS_tank_idle_01";

	public static List<GameObject> excluded = new List<GameObject>();

	public static void Init()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		ActiveTestingItem activeTestingItem = ItemSetup.NewItem<ActiveTestingItem>("<WIP> Active Testing Item <WIP>", "Work In Progress", "This item was created by an amateur gunsmith so that he may test different concepts instead of going the whole nine yards and making a whole new item.", "workinprogress_icon", assetbundle: true) as ActiveTestingItem;
		ItemBuilder.SetCooldownType((PlayerItem)(object)activeTestingItem, (CooldownType)3, 0f);
		((PlayerItem)activeTestingItem).consumable = false;
		((PickupObject)activeTestingItem).quality = (ItemQuality)(-100);
		magicCircle = new GameObject();
		FakePrefabExtensions.MakeFakePrefab(magicCircle);
		SlowingCircle slowingCircle = magicCircle.AddComponent<SlowingCircle>();
		slowingCircle.emitsParticles = true;
		slowingCircle.autoEnableAutoDisableTimer = 10f;
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return true;
	}

	public override void DoEffect(PlayerController user)
	{
		AkSoundEngine.PostEvent(sound, ((Component)user).gameObject);
	}

	public override void Update()
	{
		((PlayerItem)this).Update();
	}

	public override void Pickup(PlayerController player)
	{
		((PlayerItem)this).Pickup(player);
	}
}
