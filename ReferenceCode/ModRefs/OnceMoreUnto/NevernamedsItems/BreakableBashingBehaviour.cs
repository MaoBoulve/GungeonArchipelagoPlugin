using System;
using System.Linq;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class BreakableBashingBehaviour : MonoBehaviour
{
	private PlayerController owner;

	private Projectile self;

	private SpeculativeRigidbody rigidBody;

	private void Start()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		self = ((Component)this).GetComponent<Projectile>();
		if (Object.op_Implicit((Object)(object)self))
		{
			rigidBody = ((BraveBehaviour)self).specRigidbody;
			owner = ProjectileUtility.ProjectilePlayerOwner(self);
			if (Object.op_Implicit((Object)(object)rigidBody) && Object.op_Implicit((Object)(object)owner))
			{
				SpeculativeRigidbody obj = rigidBody;
				obj.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)obj.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnCollide));
			}
		}
	}

	private void OnCollide(SpeculativeRigidbody selfbody, PixelCollider selfcollider, SpeculativeRigidbody otherbody, PixelCollider othercollider)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)otherbody) && Object.op_Implicit((Object)(object)((Component)otherbody).gameObject) && (Object.op_Implicit((Object)(object)((Component)otherbody).gameObject.GetComponent<MinorBreakable>()) || Object.op_Implicit((Object)(object)((Component)otherbody).gameObject.GetComponent<MajorBreakable>())))
		{
			PickupObject byId = PickupObjectDatabase.GetById(541);
			GameObject effect = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.enemy.effects[0].effects[0].effect;
			Object.Instantiate<GameObject>(effect, Vector2.op_Implicit(((BraveBehaviour)self).specRigidbody.UnitCenter), Quaternion.identity);
			Smack(((Component)otherbody).gameObject);
			PhysicsEngine.SkipCollision = true;
		}
	}

	public void Smack(GameObject thingy)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		Projectile val = null;
		IPlayerInteractable @interface = GameObjectExtensions.GetInterface<IPlayerInteractable>(thingy);
		if (@interface != null)
		{
			RoomHandler roomFromPosition = GameManager.Instance.Dungeon.GetRoomFromPosition(Vector3Extensions.IntXY(thingy.transform.position, (VectorConversions)2));
			if (roomFromPosition.IsRegistered(@interface))
			{
				roomFromPosition.DeregisterInteractable(@interface);
			}
		}
		if (Object.op_Implicit((Object)(object)thingy.GetComponent<MinorBreakable>()))
		{
			thingy.GetComponent<MinorBreakable>().OnlyBrokenByCode = true;
			thingy.GetComponent<MinorBreakable>().isInvulnerableToGameActors = true;
			thingy.GetComponent<MinorBreakable>().resistsExplosions = true;
			Projectile orAddComponent = GameObjectExtensions.GetOrAddComponent<Projectile>(thingy);
			orAddComponent.Shooter = ((BraveBehaviour)owner).specRigidbody;
			orAddComponent.Owner = (GameActor)(object)owner;
			orAddComponent.baseData.damage = 15f * owner.stats.GetStatValue((StatType)5);
			orAddComponent.baseData.range = 1000f;
			orAddComponent.baseData.speed = 20f;
			orAddComponent.collidesWithProjectiles = false;
			orAddComponent.shouldRotate = false;
			orAddComponent.baseData.force = 30f;
			((BraveBehaviour)orAddComponent).specRigidbody.CollideWithTileMap = true;
			((BraveBehaviour)orAddComponent).specRigidbody.Reinitialize();
			((BraveBehaviour)orAddComponent).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
			orAddComponent.Start();
			orAddComponent.projectileHitHealth = 20;
			orAddComponent.UpdateCollisionMask();
			((Component)orAddComponent).gameObject.AddComponent<GravityGun.GravityGunObjectDeathHandler>();
			val = orAddComponent;
		}
		else if (Object.op_Implicit((Object)(object)thingy.GetComponent<MajorBreakable>()))
		{
			if (Object.op_Implicit((Object)(object)thingy.GetComponent<Chest>()))
			{
				return;
			}
			bool flag = false;
			thingy.GetComponent<MajorBreakable>().DamageReduction = 0.1f;
			thingy.GetComponent<MajorBreakable>().IgnoreExplosions = true;
			if (Object.op_Implicit((Object)(object)thingy.GetComponentInParent<FlippableCover>()))
			{
				MajorBreakable component = thingy.GetComponent<MajorBreakable>();
				FlippableCover componentInParent = thingy.GetComponentInParent<FlippableCover>();
				SpeculativeRigidbody componentInParent2 = thingy.GetComponentInParent<SpeculativeRigidbody>();
				((BraveBehaviour)componentInParent.shadowSprite).renderer.enabled = false;
				if (componentInParent.IsFlipped)
				{
					flag = true;
				}
				component.OnDamaged = (Action<float>)Delegate.Remove(component.OnDamaged, new Action<float>(componentInParent.Damaged));
				component.OnBreak = (Action)Delegate.Remove(component.OnBreak, new Action(componentInParent.DestroyCover));
				for (int num = componentInParent2.OnPostRigidbodyMovement.GetInvocationList().Count() - 1; num >= 0; num--)
				{
					Delegate @delegate = componentInParent2.OnPostRigidbodyMovement.GetInvocationList()[num];
					if (@delegate.Method.ToString().Contains("OnPostMovement"))
					{
						componentInParent2.OnPostRigidbodyMovement = (Action<SpeculativeRigidbody, Vector2, IntVector2>)Delegate.Remove(componentInParent2.OnPostRigidbodyMovement, @delegate);
					}
				}
				Object.Destroy((Object)(object)thingy.GetComponentInParent<FlippableCover>());
			}
			Projectile orAddComponent2 = GameObjectExtensions.GetOrAddComponent<Projectile>(thingy);
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent2).specRigidbody))
			{
				((BraveBehaviour)orAddComponent2).specRigidbody.Initialize();
			}
			orAddComponent2.Shooter = ((BraveBehaviour)owner).specRigidbody;
			orAddComponent2.Owner = (GameActor)(object)owner;
			orAddComponent2.baseData.damage = 30f;
			orAddComponent2.baseData.range = 1000f;
			orAddComponent2.baseData.speed = 20f;
			if (flag)
			{
				orAddComponent2.collidesWithProjectiles = true;
			}
			else
			{
				orAddComponent2.collidesWithProjectiles = false;
			}
			orAddComponent2.pierceMinorBreakables = true;
			orAddComponent2.shouldRotate = false;
			orAddComponent2.baseData.force = 50f;
			((BraveBehaviour)orAddComponent2).specRigidbody.CollideWithTileMap = true;
			((BraveBehaviour)orAddComponent2).specRigidbody.Reinitialize();
			((BraveBehaviour)orAddComponent2).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
			orAddComponent2.Start();
			orAddComponent2.projectileHitHealth = 20;
			orAddComponent2.UpdateCollisionMask();
			thingy.AddComponent<GravityGun.GravityGunObjectDeathHandler>();
			val = orAddComponent2;
		}
		if ((Object)(object)val != (Object)null)
		{
			ProjectileSpriteRotation projectileSpriteRotation = ((Component)val).gameObject.AddComponent<ProjectileSpriteRotation>();
			val.pierceMinorBreakables = true;
			BounceProjModifier val2 = ((Component)val).gameObject.AddComponent<BounceProjModifier>();
			val2.numberOfBounces = 1;
			val.SendInDirection(((Component)this).GetComponent<Projectile>().Direction, false, false);
		}
	}
}
