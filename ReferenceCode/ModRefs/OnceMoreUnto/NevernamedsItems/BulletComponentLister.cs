using UnityEngine;

namespace NevernamedsItems;

internal class BulletComponentLister : PassiveItem
{
	public static void Init()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		BulletComponentLister bulletComponentLister = ItemSetup.NewItem<BulletComponentLister>("Bullet Component Lister", "Work In Progress", "Lists the components present in fired projectiles.", "workinprogress_icon", assetbundle: true) as BulletComponentLister;
		((PickupObject)bulletComponentLister).quality = (ItemQuality)(-100);
		((PickupObject)bulletComponentLister).CanBeDropped = true;
		((PickupObject)bulletComponentLister).CanBeSold = true;
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		ListComponents(((Component)bullet).gameObject);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += onFired;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= onFired;
		return result;
	}

	public static void ListComponents(GameObject obj, int defaultIndentationLevel = 0)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		for (int i = 0; i < defaultIndentationLevel; i++)
		{
			text += "    ";
		}
		Component[] componentsInChildren = obj.GetComponentsInChildren<Component>();
		foreach (Component val in componentsInChildren)
		{
			ETGModConsole.Log((object)(text + ((object)val).GetType().ToString()), false);
			if (val is Projectile)
			{
				Projectile val2 = (Projectile)(object)((val is Projectile) ? val : null);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    DestroyMode: </color>{val2.DestroyMode}", false);
			}
			if (val is TrailController)
			{
				TrailController val3 = (TrailController)(object)((val is TrailController) ? val : null);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    usesStartAnimation: </color>{val3.usesStartAnimation}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    usesAnimation: </color>{val3.usesAnimation}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    usesCascadeTimer: </color>{val3.usesCascadeTimer}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    cascadeTimer: </color>{val3.cascadeTimer}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    usesSoftMaxLength: </color>{val3.usesSoftMaxLength}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    softMaxLength: </color>{val3.softMaxLength}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    usesGlobalTimer: </color>{val3.usesGlobalTimer}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    globalTimer: </color>{val3.globalTimer}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    destroyOnEmpty: </color>{val3.destroyOnEmpty}", false);
			}
			if (val is StrafeBleedBuff)
			{
				StrafeBleedBuff val4 = (StrafeBleedBuff)(object)((val is StrafeBleedBuff) ? val : null);
				if (Object.op_Implicit((Object)(object)val4.vfx))
				{
					ETGModConsole.Log((object)("<color=#ff0000ff>" + text + "    VFX Object</color>"), false);
					ListComponents(val4.vfx, 1);
				}
			}
			if (val is HealthHaver)
			{
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    Max HP: </color>{((HealthHaver)((val is HealthHaver) ? val : null)).GetMaxHealth()}", false);
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    BossBarType: </color>{((HealthHaver)((val is HealthHaver) ? val : null)).bossHealthBar}", false);
			}
			if (val is AIActor)
			{
				ETGModConsole.Log((object)$"<color=#ff0000ff>{text}    Normal Enemy: </color>{((AIActor)((val is AIActor) ? val : null)).IsNormalEnemy}", false);
			}
			if (val is BehaviorSpeculator)
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>" + text + "    Attack Behaviours</color>"), false);
				foreach (AttackBehaviorBase attackBehavior in ((BehaviorSpeculator)((val is BehaviorSpeculator) ? val : null)).AttackBehaviors)
				{
					ETGModConsole.Log((object)(text + "        " + ((object)attackBehavior).GetType().ToString()), false);
				}
			}
			if (val is MinorBreakable)
			{
				ETGModConsole.Log((object)("<color=#ff0000ff>" + text + "    BreakAnimName: </color>" + ((MinorBreakable)((val is MinorBreakable) ? val : null)).breakAnimName), false);
			}
		}
		ETGModConsole.Log((object)"<color=#ff0000ff>---------------------------------</color>", false);
	}
}
