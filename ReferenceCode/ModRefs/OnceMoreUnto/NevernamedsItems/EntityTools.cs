using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public static class EntityTools
{
	public static GameObject BuildEntity(string name, string guid, string defaultSprite, tk2dSpriteCollectionData Collection, IntVector2 colliderDimensions, IntVector2 colliderOffsets)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		if (!CompanionBuilder.companionDictionary.ContainsKey(guid))
		{
			GameObject val = ItemBuilder.SpriteFromBundle(defaultSprite, Collection.GetSpriteIdByName(defaultSprite), Collection, new GameObject(name));
			val.AddComponent<ObjectVisibilityManager>();
			((Object)val).name = name;
			tk2dSprite component = val.GetComponent<tk2dSprite>();
			((tk2dBaseSprite)component).collection = Collection;
			SpeculativeRigidbody val2 = SpriteBuilder.SetUpSpeculativeRigidbody(val.GetComponent<tk2dSprite>(), colliderOffsets, colliderDimensions);
			val2.CanBeCarried = true;
			val2.CanBePushed = false;
			val2.CanCarry = false;
			val2.CanPush = false;
			val2.CapVelocity = false;
			val2.CollideWithOthers = true;
			val2.CollideWithTileMap = true;
			HealthHaver val3 = val.AddComponent<HealthHaver>();
			val3.PreventAllDamage = true;
			val3.SetHealthMaximum(15000f, (float?)null, false);
			val3.FullHeal();
			AIActor val4 = val.AddComponent<AIActor>();
			val4.State = (ActorState)2;
			val4.EnemyGuid = guid;
			KnockbackDoer val5 = val.AddComponent<KnockbackDoer>();
			val5.weight = 35f;
			tk2dSpriteAnimator val6 = val.AddComponent<tk2dSpriteAnimator>();
			((BraveBehaviour)val6).RegenerateCache();
			AIAnimator val7 = val.AddComponent<AIAnimator>();
			BehaviorSpeculator val8 = val.AddComponent<BehaviorSpeculator>();
			val8.MovementBehaviors = new List<MovementBehaviorBase>();
			val8.AttackBehaviors = new List<AttackBehaviorBase>();
			val8.TargetBehaviors = new List<TargetBehaviorBase>();
			val8.OverrideBehaviors = new List<OverrideBehaviorBase>();
			val8.OtherBehaviors = new List<BehaviorBase>();
			EnemyDatabaseEntry item = new EnemyDatabaseEntry
			{
				myGuid = guid,
				placeableWidth = 2,
				placeableHeight = 2,
				isNormalEnemy = false
			};
			((AssetBundleDatabase<AIActor, EnemyDatabaseEntry>)(object)EnemyDatabase.Instance).Entries.Add(item);
			CompanionBuilder.companionDictionary.Add(guid, val);
			FakePrefabExtensions.MakeFakePrefab(val);
			return val;
		}
		return null;
	}
}
