using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class FiringMechanismController : BraveBehaviour
{
	public class FiringMechanismCloned : MonoBehaviour
	{
	}

	public static GameObject DischargeVFX;

	public static GameObject MechanismPrefab;

	public RoomHandler currentRoom;

	public bool PlayerOnly = false;

	public bool targetsEnemies = false;

	public float initialDelay = 1f;

	public float lifetime = 25f;

	private float timeActive = 0f;

	private float timeSinceLastBullet = 0f;

	public List<float> angles = new List<float> { 25f, -25f };

	public string spawnAnimation = null;

	public string idleAnimation = null;

	public string spinAnimation = null;

	private bool isSpinning = false;

	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		MechanismPrefab = ItemBuilder.SpriteFromBundle("firingmechanism_idle_001", Initialisation.EnvironmentCollection.GetSpriteIdByName("firingmechanism_idle_001"), Initialisation.EnvironmentCollection, new GameObject("Firing Mechanism"));
		FakePrefabExtensions.MakeFakePrefab(MechanismPrefab);
		SpeculativeRigidbody val = SpriteBuilder.SetUpSpeculativeRigidbody(MechanismPrefab.GetComponent<tk2dSprite>(), new IntVector2(0, 0), new IntVector2(23, 23));
		val.CollideWithTileMap = false;
		val.CollideWithOthers = true;
		((tk2dBaseSprite)((Component)MechanismPrefab.GetComponent<tk2dSprite>()).GetComponent<tk2dSprite>()).HeightOffGround = -1f;
		((BraveBehaviour)MechanismPrefab.GetComponent<tk2dSprite>()).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)MechanismPrefab.GetComponent<tk2dSprite>()).usesOverrideMaterial = true;
		val.PixelColliders = new List<PixelCollider>
		{
			new PixelCollider
			{
				ColliderGenerationMode = (PixelColliderGeneration)0,
				CollisionLayer = (CollisionLayer)8,
				ManualWidth = 19,
				ManualHeight = 15,
				ManualOffsetX = 2,
				ManualOffsetY = 15
			}
		};
		GameObject val2 = ItemBuilder.SpriteFromBundle("firingmechanism_shadow", Initialisation.EnvironmentCollection.GetSpriteIdByName("firingmechanism_shadow"), Initialisation.EnvironmentCollection, new GameObject("Shadow"));
		val2.transform.SetParent(MechanismPrefab.transform);
		val2.transform.localPosition = new Vector3(-0.0625f, -0.25f, 50f);
		tk2dSprite component = val2.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)component).HeightOffGround = -2f;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((BraveBehaviour)component).renderer.material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(MechanismPrefab);
		orAddComponent.Library = Initialisation.environmentAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.environmentAnimationCollection.GetClipIdByName("firingmechanism_idle");
		orAddComponent.DefaultClipId = Initialisation.environmentAnimationCollection.GetClipIdByName("firingmechanism_idle");
		orAddComponent.playAutomatically = true;
		FiringMechanismController firingMechanismController = MechanismPrefab.AddComponent<FiringMechanismController>();
		firingMechanismController.idleAnimation = "firingmechanism_idle";
		firingMechanismController.spawnAnimation = "firingmechanism_spawn";
		firingMechanismController.spinAnimation = "firingmechanism_spin";
		firingMechanismController.PlayerOnly = true;
		firingMechanismController.targetsEnemies = true;
		GameObjectExtensions.SetLayerRecursively(MechanismPrefab, LayerMask.NameToLayer("FG_Critical"));
		DischargeVFX = VFXToolbox.CreateVFXBundle("FiringMechanismDischarge", usesZHeight: true, 3f, -1f, -1f, null);
	}

	public void Start()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		currentRoom = Vector3Extensions.GetAbsoluteRoom(((BraveBehaviour)this).transform.position);
		SpeculativeRigidbody specRigidbody = ((BraveBehaviour)this).specRigidbody;
		specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnCollision));
		if (!string.IsNullOrEmpty(spawnAnimation))
		{
			((BraveBehaviour)this).spriteAnimator.PlayUntilFinished(spawnAnimation, idleAnimation);
		}
	}

	public void Update()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		timeActive += BraveTime.DeltaTime;
		timeSinceLastBullet += BraveTime.DeltaTime;
		if (timeSinceLastBullet > 1f && isSpinning)
		{
			((BraveBehaviour)this).spriteAnimator.Play(idleAnimation);
			isSpinning = false;
			GameObject val = SpawnManager.SpawnVFX(DischargeVFX, ((BraveBehaviour)this).transform.position + new Vector3(-0.125f, 1.25f), Quaternion.identity, true);
			tk2dBaseSprite component = val.GetComponent<tk2dBaseSprite>();
			component.HeightOffGround = 4f;
			component.UpdateZDepth();
		}
		if (lifetime > 0f && timeActive > lifetime)
		{
			AkSoundEngine.PostEvent("Play_OBJ_boulder_break_01", ((Component)this).gameObject);
			PickupObject byId = PickupObjectDatabase.GetById(37);
			SpawnManager.SpawnVFX(((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX, Vector2.op_Implicit(((BraveBehaviour)this).sprite.WorldCenter), Quaternion.identity);
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	private bool ProjectileShouldBeReflected(Projectile proj)
	{
		if ((Object)(object)proj == (Object)null)
		{
			return false;
		}
		if (((Object)(object)proj.Owner == (Object)null || proj.Owner is AIActor) && PlayerOnly)
		{
			return false;
		}
		if (Object.op_Implicit((Object)(object)((Component)proj).gameObject.GetComponent<FiringMechanismCloned>()))
		{
			return false;
		}
		return true;
	}

	private void OnCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)otherRigidbody != (Object)null && (Object)(object)((BraveBehaviour)otherRigidbody).projectile != (Object)null && ProjectileShouldBeReflected(((BraveBehaviour)otherRigidbody).projectile))
		{
			timeSinceLastBullet = 0f;
			if (!string.IsNullOrEmpty(spinAnimation) && !isSpinning)
			{
				((BraveBehaviour)this).spriteAnimator.Play(spinAnimation);
				isSpinning = true;
			}
			((Component)otherRigidbody).gameObject.AddComponent<FiringMechanismCloned>();
			AkSoundEngine.PostEvent("Play_WPN_burninghand_shot_01", ((Component)this).gameObject);
			Object.Instantiate<GameObject>(SharedVFX.RedFireBlastVFX, Vector2.op_Implicit(((BraveBehaviour)otherRigidbody).projectile.SafeCenter), Quaternion.identity);
			if (targetsEnemies && (Object)(object)MathsAndLogicHelper.GetNearestEnemyToPosition(((BraveBehaviour)otherRigidbody).projectile.SafeCenter, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null) != (Object)null)
			{
				((BraveBehaviour)otherRigidbody).projectile.SendInDirection(ProjectileUtility.GetVectorToNearestEnemy(((BraveBehaviour)otherRigidbody).projectile, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null), false, true);
			}
			foreach (float angle in angles)
			{
				Projectile component = ProjectileUtility.InstantiateAndFireInDirection(((BraveBehaviour)otherRigidbody).projectile, ((BraveBehaviour)otherRigidbody).projectile.SafeCenter, Vector2Extensions.ToAngle(((BraveBehaviour)otherRigidbody).projectile.Direction) + angle, 5f, (PlayerController)null).GetComponent<Projectile>();
				component.Owner = ((BraveBehaviour)otherRigidbody).projectile.Owner;
				component.Shooter = ((BraveBehaviour)otherRigidbody).projectile.Shooter;
			}
		}
		PhysicsEngine.SkipCollision = true;
	}
}
