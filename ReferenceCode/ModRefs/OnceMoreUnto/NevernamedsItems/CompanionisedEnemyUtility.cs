using System;
using System.Reflection;
using Alexandria.EnemyAPI;
using Alexandria.ItemAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

internal class CompanionisedEnemyUtility
{
	public static Hook DisplaceHook;

	public static void InitHooks()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		DisplaceHook = new Hook((MethodBase)typeof(DisplaceBehavior).GetMethod("SpawnImage", BindingFlags.Instance | BindingFlags.NonPublic), typeof(CompanionisedEnemyUtility).GetMethod("DisplacedImageSpawnHook", BindingFlags.Instance | BindingFlags.NonPublic), (object)typeof(DisplaceBehavior));
	}

	private void DisplacedImageSpawnHook(Action<DisplaceBehavior> orig, DisplaceBehavior sourceBehaviour)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		orig(sourceBehaviour);
		AIActor attackBehaviourOwner = AttackBehaviourUtility.GetAttackBehaviourOwner((BehaviorBase)(object)sourceBehaviour);
		if (!((Object)(object)attackBehaviourOwner != (Object)null) || !((Object)(object)((Component)attackBehaviourOwner).GetComponent<CustomEnemyTagsSystem>() != (Object)null) || !((Component)attackBehaviourOwner).GetComponent<CustomEnemyTagsSystem>().isKalibersEyeMinion)
		{
			return;
		}
		AIActor image = sourceBehaviour.m_image;
		if ((Object)(object)image != (Object)null)
		{
			PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)image).specRigidbody, (int?)null, false);
			CustomEnemyTagsSystem orAddComponent = GameObjectExtensions.GetOrAddComponent<CustomEnemyTagsSystem>(((Component)image).gameObject);
			orAddComponent.isKalibersEyeMinion = true;
			orAddComponent.ignoreForGoodMimic = true;
			if ((Object)(object)attackBehaviourOwner.CompanionOwner != (Object)null)
			{
				CompanionController orAddComponent2 = GameObjectExtensions.GetOrAddComponent<CompanionController>(((Component)image).gameObject);
				orAddComponent2.companionID = (CompanionIdentifier)0;
				orAddComponent2.Initialize(attackBehaviourOwner.CompanionOwner);
			}
			image.OverrideHitEnemies = true;
			image.CollisionDamage = 0.5f;
			image.CollisionDamageTypes = (CoreDamageTypes)(image.CollisionDamageTypes | 0x40);
			CompanionisedEnemyBulletModifiers orAddComponent3 = GameObjectExtensions.GetOrAddComponent<CompanionisedEnemyBulletModifiers>(((Component)image).gameObject);
			orAddComponent3.jammedDamageMultiplier = 2f;
			orAddComponent3.TintBullets = true;
			orAddComponent3.TintColor = ExtendedColours.honeyYellow;
			orAddComponent3.baseBulletDamage = 10f;
			orAddComponent3.scaleSpeed = true;
			orAddComponent3.scaleDamage = true;
			orAddComponent3.scaleSize = false;
			orAddComponent3.doPostProcess = false;
			if ((Object)(object)attackBehaviourOwner.CompanionOwner != (Object)null)
			{
				orAddComponent3.enemyOwner = attackBehaviourOwner.CompanionOwner;
			}
			((GameActor)image).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
			ContinualKillOnRoomClear continualKillOnRoomClear = ((Component)image).gameObject.AddComponent<ContinualKillOnRoomClear>();
			if (AlexandriaTags.HasTag(image, "multiple_phase_enemy"))
			{
				continualKillOnRoomClear.forceExplode = true;
				continualKillOnRoomClear.eraseInsteadOfKill = true;
			}
			image.IsHarmlessEnemy = true;
			((GameActor)image).RegisterOverrideColor(Color.grey, "Ressurection");
			image.IgnoreForRoomClear = true;
			if (Object.op_Implicit((Object)(object)((Component)image).gameObject.GetComponent<SpawnEnemyOnDeath>()))
			{
				Object.Destroy((Object)(object)((Component)image).gameObject.GetComponent<SpawnEnemyOnDeath>());
			}
		}
	}

	public static AIActor SpawnCompanionisedEnemy(PlayerController owner, string enemyGuid, IntVector2 position, bool doTint, Color enemyTint, int baseDMG, int jammedDMGMult, bool shouldBeJammed, bool doFriendlyOverhead)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(enemyGuid);
		Object.Instantiate<GameObject>(SharedVFX.BloodiedScarfPoofVFX, ((IntVector2)(ref position)).ToVector3(), Quaternion.identity);
		AIActor val = AIActor.Spawn(orLoadByGuid, position, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(position), true, (AwakenAnimationType)0, true);
		PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)val).specRigidbody, (int?)null, false);
		CompanionController orAddComponent = GameObjectExtensions.GetOrAddComponent<CompanionController>(((Component)val).gameObject);
		orAddComponent.companionID = (CompanionIdentifier)0;
		orAddComponent.Initialize(owner);
		if (shouldBeJammed)
		{
			val.BecomeBlackPhantom();
		}
		CompanionisedEnemyBulletModifiers orAddComponent2 = GameObjectExtensions.GetOrAddComponent<CompanionisedEnemyBulletModifiers>(((Component)val).gameObject);
		orAddComponent2.jammedDamageMultiplier = jammedDMGMult;
		orAddComponent2.TintBullets = true;
		orAddComponent2.TintColor = ExtendedColours.honeyYellow;
		orAddComponent2.baseBulletDamage = baseDMG;
		((GameActor)val).ApplyEffect((GameActorEffect)(object)GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect, 1f, (Projectile)null);
		((Component)val).gameObject.AddComponent<KillOnRoomClear>();
		ContinualKillOnRoomClear continualKillOnRoomClear = ((Component)val).gameObject.AddComponent<ContinualKillOnRoomClear>();
		if (AlexandriaTags.HasTag(val, "multiple_phase_enemy"))
		{
			continualKillOnRoomClear.forceExplode = true;
			continualKillOnRoomClear.eraseInsteadOfKill = true;
		}
		val.IsHarmlessEnemy = true;
		if (doTint)
		{
			((GameActor)val).RegisterOverrideColor(enemyTint, "CompanionisedEnemyTint");
		}
		val.IgnoreForRoomClear = true;
		if (doFriendlyOverhead)
		{
			GameObject val2 = Object.Instantiate<GameObject>(SharedVFX.FriendlyOverhead);
			tk2dBaseSprite component = val2.GetComponent<tk2dBaseSprite>();
			val2.transform.parent = ((BraveBehaviour)val).transform;
			if (((BraveBehaviour)val).healthHaver.IsBoss)
			{
				val2.transform.position = Vector2.op_Implicit(((BraveBehaviour)val).specRigidbody.HitboxPixelCollider.UnitTopCenter);
			}
			else
			{
				Bounds bounds = ((BraveBehaviour)val).sprite.GetBounds();
				Vector3 val3 = ((BraveBehaviour)val).transform.position + dfVectorExtensions.Quantize(new Vector3((((Bounds)(ref bounds)).max.x + ((Bounds)(ref bounds)).min.x) / 2f, ((Bounds)(ref bounds)).max.y, 0f), 0.0625f);
				val2.transform.position = Vector3Extensions.WithY(Vector2Extensions.ToVector3ZUp(((BraveBehaviour)val).sprite.WorldCenter, 0f), val3.y);
			}
			component.HeightOffGround = 0.5f;
			((BraveBehaviour)val).sprite.AttachRenderer(component);
		}
		return val;
	}
}
