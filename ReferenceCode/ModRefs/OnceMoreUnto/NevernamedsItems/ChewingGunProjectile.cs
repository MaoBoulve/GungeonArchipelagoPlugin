using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class ChewingGunProjectile : MonoBehaviour
{
	private Projectile self;

	private PlayerController owner;

	public bool inflating = true;

	public Gun lastframeGun;

	private float origSpeed = 0f;

	private int inflationLevel;

	private bool released = false;

	public static ChewingGunProjectile currentBlowingBubble;

	private Vector2 BarrelSticky()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)owner))
		{
			return Vector2.zero;
		}
		if (!Object.op_Implicit((Object)(object)((GameActor)owner).CurrentGun))
		{
			return Vector2.zero;
		}
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GameActor)owner).CurrentGun.barrelOffset.position.x, ((GameActor)owner).CurrentGun.barrelOffset.position.y);
		Bounds bounds = ((BraveBehaviour)self).sprite.GetBounds();
		float num = ((Bounds)(ref bounds)).size.x / 2f;
		Vector2 val2 = MathsAndLogicHelper.DegreeToVector2(((GameActor)owner).CurrentGun.CurrentAngle);
		Vector2 val3 = ((Vector2)(ref val2)).normalized * num;
		return val + val3;
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		owner = ProjectileUtility.ProjectilePlayerOwner(self);
		self.OnDestruction += Destruction;
		Projectile obj = self;
		obj.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(obj.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHit));
		if ((Object)(object)currentBlowingBubble != (Object)null)
		{
			inflating = false;
			((BraveBehaviour)((BraveBehaviour)self).sprite).renderer.enabled = false;
			currentBlowingBubble.Inflate();
			Object.Destroy((Object)(object)((Component)self).gameObject);
			return;
		}
		GameObjectExtensions.SetLayerRecursively(((Component)this).gameObject, LayerMask.NameToLayer("Default"));
		if (Object.op_Implicit((Object)(object)owner) && Object.op_Implicit((Object)(object)((GameActor)owner).CurrentGun))
		{
			lastframeGun = ((GameActor)owner).CurrentGun;
		}
		((BraveBehaviour)self).specRigidbody.CollideWithOthers = false;
		((BraveBehaviour)self).specRigidbody.CollideWithTileMap = false;
		((BraveBehaviour)self).specRigidbody.Reinitialize();
		origSpeed = self.baseData.speed;
		self.baseData.speed = 0.001f;
		self.UpdateSpeed();
		AkSoundEngine.PostEvent("Play_WPN_superdowser_shot_01", ((Component)self).gameObject);
		currentBlowingBubble = this;
	}

	private void Update()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)owner) && Object.op_Implicit((Object)(object)((GameActor)owner).CurrentGun) && inflating)
		{
			self.baseData.speed = 0.001f;
			self.UpdateSpeed();
			Vector2 val = BarrelSticky();
			if (val != Vector2.zero)
			{
				((BraveBehaviour)self).specRigidbody.Position = new Position(BarrelSticky());
				((BraveBehaviour)self).sprite.PlaceAtPositionByAnchor(Vector2.op_Implicit(BarrelSticky()), (Anchor)4);
			}
			if ((Object)(object)((GameActor)owner).CurrentGun != (Object)(object)lastframeGun || owner.IsDodgeRolling)
			{
				inflating = false;
				Pop();
			}
			if (!BraveInput.GetInstanceForPlayer(owner.PlayerIDX).GetButton((GungeonActionType)8))
			{
				Release();
			}
		}
	}

	private void OnHit(Projectile self, SpeculativeRigidbody enemy, bool fatal)
	{
		if (!fatal && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
		{
			GumEnemy(((BraveBehaviour)enemy).aiActor, (float)inflationLevel / 50f);
		}
	}

	private void Destruction(Projectile self)
	{
		if (released)
		{
			Pop(kill: false);
		}
		else
		{
			AkSoundEngine.PostEvent("Stop_WPN_superdowser_loop_01", ((Component)self).gameObject);
		}
	}

	private void Release()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Stop_WPN_superdowser_loop_01", ((Component)self).gameObject);
		currentBlowingBubble = null;
		released = true;
		inflating = false;
		Vector2 val = BarrelSticky();
		if (val != Vector2.zero)
		{
			((BraveBehaviour)self).specRigidbody.Position = new Position(BarrelSticky());
		}
		((BraveBehaviour)self).specRigidbody.CollideWithOthers = true;
		((BraveBehaviour)self).specRigidbody.CollideWithTileMap = true;
		self.baseData.speed = origSpeed;
		self.UpdateSpeed();
		((BraveBehaviour)self).specRigidbody.Reinitialize();
		self.SendInDirection(MathsAndLogicHelper.DegreeToVector2(((GameActor)owner).CurrentGun.CurrentAngle), true, false);
		ProjectileData baseData = self.baseData;
		baseData.damage *= (float)inflationLevel / 50f;
		SlowDownOverTimeModifier slowDownOverTimeModifier = ((Component)self).gameObject.AddComponent<SlowDownOverTimeModifier>();
		slowDownOverTimeModifier.extendTimeByRangeStat = true;
		slowDownOverTimeModifier.activateDriftAfterstop = true;
		slowDownOverTimeModifier.doRandomTimeMultiplier = true;
		slowDownOverTimeModifier.killAfterCompleteStop = false;
		slowDownOverTimeModifier.timeTillKillAfterCompleteStop = 1f;
		slowDownOverTimeModifier.timeToSlowOver = 0.5f;
		slowDownOverTimeModifier.targetSpeed = self.baseData.speed * 0.1f;
		DriftModifier driftModifier = ((Component)self).gameObject.AddComponent<DriftModifier>();
		driftModifier.startInactive = true;
		driftModifier.DriftTimer = 0.5f;
		driftModifier.degreesOfVariance = 40f;
	}

	private void Pop(bool kill = true)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnVFX(ChewingGun.popVFX, Vector2.op_Implicit(((BraveBehaviour)self).sprite.WorldCenter), Quaternion.identity);
		val.transform.localScale = ((BraveBehaviour)self).sprite.scale * 1.5f;
		AkSoundEngine.PostEvent("Play_MouthPopSound", ((Component)this).gameObject);
		List<AIActor> activeEnemies = ProjectileUtility.GetAbsoluteRoom(self).GetActiveEnemies((ActiveEnemyType)0);
		if (activeEnemies != null)
		{
			for (int i = 0; i < activeEnemies.Count; i++)
			{
				AIActor val2 = activeEnemies[i];
				if (!val2.IsNormalEnemy)
				{
					continue;
				}
				float num = Vector2.Distance(Vector2.op_Implicit(self.LastPosition), ((GameActor)val2).CenterPosition);
				if (num <= 5f)
				{
					if (Object.op_Implicit((Object)(object)((BraveBehaviour)val2).healthHaver))
					{
						((BraveBehaviour)val2).healthHaver.ApplyDamage(5f * ((float)inflationLevel / 50f), Vector2.zero, "Gum", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
					}
					GumEnemy(val2, (float)inflationLevel / 50f * 0.9f);
				}
			}
		}
		if (CustomSynergies.PlayerHasActiveSynergy(owner, "Gumzookie"))
		{
			PickupObject byId = PickupObjectDatabase.GetById(519);
			Projectile val3 = ((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0];
			GameObject val4 = ProjectileUtility.InstantiateAndFireTowardsPosition(val3, Vector2.op_Implicit(self.LastPosition), MathsAndLogicHelper.GetPositionOfNearestEnemy(((BraveBehaviour)self).sprite.WorldCenter, (ActorCenter)2, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null), 0f, 0f, (PlayerController)null);
			Projectile component = val4.GetComponent<Projectile>();
			if ((Object)(object)component != (Object)null)
			{
				component.Owner = (GameActor)(object)owner;
				component.Shooter = ((BraveBehaviour)owner).specRigidbody;
				component.baseData.damage = 20f * ((float)inflationLevel / 50f);
				component.ScaleByPlayerStats(owner);
				owner.DoPostProcessProjectile(component);
				component.RuntimeUpdateScale((float)inflationLevel / 50f);
				((Component)component).gameObject.AddComponent<PierceDeadActors>();
			}
		}
		if (kill)
		{
			self.DieInAir(false, true, true, false);
		}
	}

	public void Inflate()
	{
		if (inflating)
		{
			inflationLevel++;
			self.RuntimeUpdateScale(1.05f);
			if (inflationLevel > 50)
			{
				inflating = false;
				Pop();
			}
		}
	}

	public void GumEnemy(AIActor target, float gumamount)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)target) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).aiActor) && Object.op_Implicit((Object)(object)((BraveBehaviour)target).healthHaver) && ((BraveBehaviour)target).healthHaver.IsAlive)
		{
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)target).behaviorSpeculator))
			{
				((BraveBehaviour)target).behaviorSpeculator.Stun(2f * gumamount, true);
			}
			GameObject val = SpawnManager.SpawnVFX(ChewingGun.gummedVFX, true);
			tk2dBaseSprite component = val.GetComponent<tk2dBaseSprite>();
			val.transform.position = Vector2.op_Implicit(new Vector2(((BraveBehaviour)target).sprite.WorldBottomCenter.x + 0.5f, ((BraveBehaviour)target).sprite.WorldBottomCenter.y));
			val.transform.parent = ((BraveBehaviour)target).transform;
			component.HeightOffGround = 0.2f;
			((BraveBehaviour)target).sprite.AttachRenderer(component);
			GumPile component2 = val.GetComponent<GumPile>();
			if (Object.op_Implicit((Object)(object)component2))
			{
				component2.lifetime = 20f * gumamount;
				component2.target = ((BraveBehaviour)target).specRigidbody;
			}
		}
	}
}
