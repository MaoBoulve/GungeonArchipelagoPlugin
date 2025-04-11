using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alexandria.EnemyAPI;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using UnityEngine;

namespace NevernamedsItems;

public class GravityGun : AdvancedGunBehavior
{
	public class GravityGunObjectDeathHandler : MonoBehaviour
	{
		private Projectile m_projectile;

		public bool AppliesGlitter;

		private void Start()
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			m_projectile = ((Component)this).GetComponent<Projectile>();
			Projectile projectile = m_projectile;
			VFXPool val = new VFXPool();
			val.type = (VFXPoolType)0;
			val.effects = (VFXComplex[])(object)new VFXComplex[0];
			projectile.wallDecals = val;
			m_projectile.damageTypes = (CoreDamageTypes)0;
			m_projectile.damagesWalls = false;
			m_projectile.OnDestruction += Destruction;
			SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
			specRigidbody.OnCollision = (Action<CollisionData>)Delegate.Combine(specRigidbody.OnCollision, new Action<CollisionData>(ProjectileCollision));
			SpeculativeRigidbody specRigidbody2 = ((BraveBehaviour)m_projectile).specRigidbody;
			specRigidbody2.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody2.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnPreCollision));
			Projectile projectile2 = m_projectile;
			projectile2.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(projectile2.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(OnHitEnemy));
			((BraveBehaviour)m_projectile).specRigidbody.CollideWithOthers = true;
			((BraveBehaviour)m_projectile).specRigidbody.CollideWithTileMap = true;
			m_projectile.UpdateCollisionMask();
			AppliesGlitter = false;
			if ((Object)(object)((Component)m_projectile).GetComponent<AIActor>() != (Object)null)
			{
				AIActor component = ((Component)m_projectile).GetComponent<AIActor>();
				if (Object.op_Implicit((Object)(object)((BraveBehaviour)component).specRigidbody))
				{
					((BraveBehaviour)component).specRigidbody.CollideWithOthers = true;
					((BraveBehaviour)component).specRigidbody.CollideWithTileMap = true;
				}
			}
		}

		private void OnHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
		{
			if (!fatal && AppliesGlitter && Object.op_Implicit((Object)(object)enemy) && Object.op_Implicit((Object)(object)((BraveBehaviour)enemy).aiActor))
			{
				AIActorUtility.ApplyGlitter(((BraveBehaviour)enemy).aiActor);
			}
		}

		private void OnPreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
		{
			if (Object.op_Implicit((Object)(object)otherRigidbody) && (Object)(object)((BraveBehaviour)otherRigidbody).projectile != (Object)null && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((BraveBehaviour)otherRigidbody).projectile)))
			{
				PhysicsEngine.SkipCollision = true;
			}
		}

		private void ProjectileCollision(CollisionData data)
		{
			if (Object.op_Implicit((Object)(object)data.OtherRigidbody) && Object.op_Implicit((Object)(object)((Component)data.OtherRigidbody).GetComponent<MinorBreakable>()) && !Object.op_Implicit((Object)(object)((Component)data.OtherRigidbody).GetComponent<Projectile>()) && Object.op_Implicit((Object)(object)((Component)data.MyRigidbody).GetComponent<MinorBreakable>()))
			{
				((Component)data.OtherRigidbody).GetComponent<MinorBreakable>().Break();
			}
		}

		private void Destruction(Projectile bullet)
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)((Component)bullet).GetComponent<AIActorIsKevin>()) && Object.op_Implicit((Object)(object)bullet) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)))
			{
				PlayerUtility.DoEasyBlank(ProjectileUtility.ProjectilePlayerOwner(bullet), ((BraveBehaviour)bullet).specRigidbody.UnitCenter, (EasyBlankType)0);
			}
			if (Object.op_Implicit((Object)(object)((Component)bullet).gameObject.GetComponent<MinorBreakable>()))
			{
				((Component)bullet).gameObject.GetComponent<MinorBreakable>().Break();
				Type typeFromHandle = typeof(MinorBreakable);
				MethodInfo method = typeFromHandle.GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic);
				object obj = method.Invoke(((Component)bullet).gameObject.GetComponent<MinorBreakable>(), null);
			}
			else if (Object.op_Implicit((Object)(object)((Component)bullet).gameObject.GetComponent<MajorBreakable>()))
			{
				Object.Instantiate<GameObject>(MajorBreakableImpactVFX, Vector2.op_Implicit(((BraveBehaviour)bullet).sprite.WorldCenter), Quaternion.identity);
				if (Object.op_Implicit((Object)(object)((Component)bullet).gameObject.GetComponentInChildren<Chest>()) && !((Component)bullet).gameObject.GetComponentInChildren<Chest>().IsOpen)
				{
					if (((Component)bullet).gameObject.GetComponentInChildren<Chest>().IsMimic)
					{
						GameActor owner = bullet.Owner;
						HandleMimicOverrideBreak((PlayerController)(object)((owner is PlayerController) ? owner : null), ((Component)bullet).gameObject.GetComponentInChildren<Chest>());
					}
					else
					{
						GameActor owner2 = bullet.Owner;
						HandleChestOverrideBreak((PlayerController)(object)((owner2 is PlayerController) ? owner2 : null), ((Component)bullet).gameObject.GetComponentInChildren<Chest>());
						Exploder.Explode(Vector2.op_Implicit(((BraveBehaviour)bullet).specRigidbody.UnitCenter), ChestExplosionData, Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
					}
				}
				((Component)bullet).gameObject.GetComponent<MajorBreakable>().Break(Vector2.zero);
			}
			else if (Object.op_Implicit((Object)(object)((Component)bullet).gameObject.GetComponent<AIActor>()) && Object.op_Implicit((Object)(object)((Component)bullet).gameObject.GetComponent<HealthHaver>()))
			{
				if (ProjectileUtility.GetAbsoluteRoom(bullet) != ((Component)bullet).gameObject.GetComponent<AIActor>().ParentRoom && (Object)(object)((Component)bullet).gameObject.GetComponent<SpawnEnemyOnDeath>() != (Object)null)
				{
					Object.Destroy((Object)(object)((Component)bullet).gameObject.GetComponent<SpawnEnemyOnDeath>());
				}
				((Component)bullet).gameObject.GetComponent<HealthHaver>().ApplyDamage(2.1474836E+09f, Vector2.zero, "Yeet", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
				((Component)bullet).gameObject.AddComponent<AIActorConstantKill>();
			}
		}
	}

	public class AIActorConstantKill : MonoBehaviour
	{
		private AIActor actor;

		public void Start()
		{
			actor = ((Component)this).GetComponent<AIActor>();
		}

		public void Update()
		{
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			if (Object.op_Implicit((Object)(object)actor) && Object.op_Implicit((Object)(object)((BraveBehaviour)actor).healthHaver) && ((BraveBehaviour)actor).healthHaver.IsAlive)
			{
				((BraveBehaviour)actor).healthHaver.ApplyDamage(2.1474836E+09f, Vector2.zero, "ConstantKill", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			}
		}
	}

	private static DamageTypeModifier ElectricImmunity;

	public static int GravityGunID;

	private static ExplosionData ChestExplosionData;

	private static GameObject MajorBreakableImpactVFX;

	private bool PlayerIsElectricImmune = false;

	private bool isUsingPropFly = false;

	public Projectile CurrentCaughtProjectile;

	public static List<string> GravityGunOverrideGrabGuids = new List<string>
	{
		"f38686671d524feda75261e469f30e0b", "b5e699a0abb94666bda567ab23bd91c4", "d4dd2b2bbda64cc9bcec534b4e920518", "02a14dec58ab45fb8aacde7aacd25b01", "76bc43539fc24648bff4568c75c686d1", "f155fd2759764f4a9217db29dd21b7eb", "ac986dabc5a24adab11d48a4bccf4cb1", "48d74b9c65f44b888a94f9e093554977", "c5a0fd2774b64287bf11127ca59dd8b4", "b67ffe82c66742d1985e5888fd8e6a03",
		"d9632631a18849539333a92332895ebd", "1898f6fe1ee0408e886aaf05c23cc216", "abd816b0bcbf4035b95837ca931169df", "07d06d2b23cc48fe9f95454c839cb361"
	};

	public static List<string> BlobGuids = new List<string>
	{
		"0239c0680f9f467dbe5c4aab7dd1eca6", "042edb1dfb614dc385d5ad1b010f2ee3", "42be66373a3d4d89b91a35c9ff8adfec", "e61cab252cfb435db9172adc96ded75f", "fe3fe59d867347839824d5d9ae87f244", "b8103805af174924b578c98e95313074", "022d7c822bc146b58fe3b0287568aaa2", "ccf6d241dad64d989cbcaca2a8477f01", "062b9b64371e46e195de17b6f10e47c8", "116d09c26e624bca8cca09fc69c714b3",
		"864ea5a6a9324efc95a0dd2407f42810", "0b547ac6b6fc4d68876a241a88f5ca6a", "1bc2a07ef87741be90c37096910843ab"
	};

	public static void Add()
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Gravity Gun", "gravitygun");
		Game.Items.Rename("outdated_gun_mods:gravity_gun", "nn:gravity_gun");
		GravityGun gravityGun = ((Component)val).gameObject.AddComponent<GravityGun>();
		((AdvancedGunBehavior)gravityGun).preventNormalFireAudio = true;
		((AdvancedGunBehavior)gravityGun).preventNormalReloadAudio = true;
		((AdvancedGunBehavior)gravityGun).overrideNormalReloadAudio = "Play_wpn_chargelaser_shot_01";
		GunExt.SetShortDescription((PickupObject)(object)val, "Not A Toy");
		GunExt.SetLongDescription((PickupObject)(object)val, "Picks up and throws objects, and weak enemies.\n\nOriginally developed for hazardous materials transport by an alien empire.\nUtilises negative mass and counter-resonant fluctuators to maintain a stable zero-point field.");
		val.SetGunSprites("gravitygun");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 25);
		ref string gunSwitchGroup = ref val.gunSwitchGroup;
		PickupObject byId = PickupObjectDatabase.GetById(562);
		gunSwitchGroup = ((Gun)((byId is Gun) ? byId : null)).gunSwitchGroup;
		PickupObject byId2 = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId2 is Gun) ? byId2 : null), true, false);
		val.usesContinuousFireAnimation = true;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).wrapMode = (WrapMode)1;
		((Component)val).GetComponent<tk2dSpriteAnimator>().GetClipByName(val.shootAnimation).loopStart = 1;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1.31f, 0.5f, 0f);
		val.SetBaseMaxAmmo(10000);
		val.ammo = 10000;
		val.gunClass = (GunClass)60;
		val.doesScreenShake = false;
		val.DefaultModule.shootStyle = (ShootStyle)1;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.DefaultModule.cooldownTime = 0.1f;
		val.DefaultModule.numberOfShotsInClip = 10000;
		val.DefaultModule.angleVariance = 0f;
		val.InfiniteAmmo = true;
		val.reloadTime = 0f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.ammoCost = 0;
		val.DefaultModule.projectiles[0] = null;
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = "Y-Beam Laser";
		((PickupObject)val).quality = (ItemQuality)4;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		GravityGunID = ((PickupObject)val).PickupObjectId;
		ElectricImmunity = new DamageTypeModifier();
		ElectricImmunity.damageMultiplier = 0f;
		ElectricImmunity.damageType = (CoreDamageTypes)64;
		PickupObject byId3 = PickupObjectDatabase.GetById(37);
		MajorBreakableImpactVFX = ((Gun)((byId3 is Gun) ? byId3 : null)).DefaultModule.chargeProjectiles[0].Projectile.hitEffects.overrideMidairDeathVFX;
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		if (ChestExplosionData == null)
		{
			ChestExplosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData.CopyExplosionData();
			ChestExplosionData.breakSecretWalls = true;
			if (!ChestExplosionData.ignoreList.Contains(((BraveBehaviour)player).specRigidbody))
			{
				ChestExplosionData.ignoreList.Add(((BraveBehaviour)player).specRigidbody);
			}
		}
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	public override void OnSwitchedAwayFromThisGun()
	{
		if (Object.op_Implicit((Object)(object)CurrentCaughtProjectile))
		{
			CurrentCaughtProjectile.DieInAir(false, true, true, false);
		}
		if (isUsingPropFly)
		{
			HandlePropFly(AddsPropFly: false);
		}
		if (PlayerIsElectricImmune && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver.damageTypeModifiers.Remove(ElectricImmunity);
			PlayerIsElectricImmune = false;
		}
		((AdvancedGunBehavior)this).OnSwitchedAwayFromThisGun();
	}

	private Vector2 HoldPosition()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && Object.op_Implicit((Object)(object)((BraveBehaviour)base.gun).sprite))
		{
			PlayerController val = GunTools.GunPlayerOwner(base.gun);
			Vector2 centerPosition = ((GameActor)val).CenterPosition;
			Vector2 val2 = Vector3Extensions.XY(val.unadjustedAimPoint) - centerPosition;
			Vector2 normalized = ((Vector2)(ref val2)).normalized;
			return ((BraveBehaviour)base.gun).sprite.WorldCenter + normalized * 2f;
		}
		return Vector2.zero;
	}

	private void CheckForGrab()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Invalid comparison between Unknown and I4
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		List<GameObject> list = new List<GameObject>();
		List<MinorBreakable> allMinorBreakables = StaticReferenceManager.AllMinorBreakables;
		for (int num = allMinorBreakables.Count - 1; num >= 0; num--)
		{
			MinorBreakable val = allMinorBreakables[num];
			if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((BraveBehaviour)val).specRigidbody) && !val.IsBroken && Object.op_Implicit((Object)(object)((BraveBehaviour)val).sprite) && Vector2.Distance(HoldPosition(), val.CenterPoint) < 1.5f)
			{
				list.Add(((Component)val).gameObject);
			}
		}
		List<MajorBreakable> allMajorBreakables = StaticReferenceManager.AllMajorBreakables;
		for (int num2 = allMajorBreakables.Count - 1; num2 >= 0; num2--)
		{
			MajorBreakable val2 = allMajorBreakables[num2];
			if (Object.op_Implicit((Object)(object)val2) && Object.op_Implicit((Object)(object)((BraveBehaviour)val2).specRigidbody) && !val2.IsDestroyed && Object.op_Implicit((Object)(object)((BraveBehaviour)val2).sprite) && Vector2.Distance(HoldPosition(), val2.CenterPoint) < 1.5f)
			{
				bool flag = true;
				if (Object.op_Implicit((Object)(object)((Component)val2).GetComponent<Chest>()) && (int)((Component)val2).GetComponent<Chest>().ChestIdentifier == 1)
				{
					flag = false;
				}
				if ((Object)(object)((Component)val2).GetComponent<BashelliskBodyController>() != (Object)null)
				{
					flag = false;
				}
				if ((Object)(object)((Component)val2).GetComponent<Projectile>() != (Object)null)
				{
					flag = false;
				}
				if (((Object)val2).name.ToLower().Contains("boss_reward_pedestal") || ((Object)val2).name.ToLower().Contains("minecart_turret"))
				{
					flag = false;
				}
				if (flag)
				{
					list.Add(((Component)val2).gameObject);
				}
			}
		}
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			RoomHandler currentRoom = GunTools.GunPlayerOwner(base.gun).CurrentRoom;
			if (currentRoom != null)
			{
				List<AIActor> activeEnemies = currentRoom.GetActiveEnemies((ActiveEnemyType)0);
				if (activeEnemies != null && activeEnemies.Count > 0)
				{
					for (int i = 0; i < activeEnemies.Count; i++)
					{
						AIActor val3 = activeEnemies[i];
						if (Object.op_Implicit((Object)(object)val3) && Object.op_Implicit((Object)(object)((BraveBehaviour)val3).specRigidbody) && val3.IsNormalEnemy && !((GameActor)val3).IsGone && Object.op_Implicit((Object)(object)((BraveBehaviour)val3).healthHaver) && ((BraveBehaviour)val3).healthHaver.IsVulnerable && !((BraveBehaviour)val3).healthHaver.IsBoss && Vector2.Distance(HoldPosition(), ((BraveBehaviour)val3).sprite.WorldCenter) < 1.5f && !AIActorUtility.IsInMinecart(val3))
						{
							if (((BraveBehaviour)val3).healthHaver.GetMaxHealth() <= HealthMaxValue() || GravityGunOverrideGrabGuids.Contains(val3.EnemyGuid))
							{
								list.Add(((Component)val3).gameObject);
							}
							else if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Xenobiology") && BlobGuids.Contains(val3.EnemyGuid))
							{
								list.Add(((Component)val3).gameObject);
							}
						}
					}
				}
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		GameObject val4 = null;
		float num3 = float.MaxValue;
		for (int num4 = list.Count - 1; num4 >= 0; num4--)
		{
			float num5 = Vector2.Distance(HoldPosition(), Vector2.op_Implicit(list[num4].transform.position));
			if (num5 < num3)
			{
				val4 = list[num4];
				num3 = num5;
			}
		}
		if ((Object)(object)val4 != (Object)null)
		{
			CatchObject(val4);
		}
	}

	protected override void OnPostDroppedByPlayer(PlayerController player)
	{
		if (Object.op_Implicit((Object)(object)CurrentCaughtProjectile))
		{
			CurrentCaughtProjectile.DieInAir(false, true, true, false);
		}
		if (isUsingPropFly)
		{
			HandlePropFly(AddsPropFly: false);
		}
		if (PlayerIsElectricImmune)
		{
			((BraveBehaviour)player).healthHaver.damageTypeModifiers.Remove(ElectricImmunity);
			PlayerIsElectricImmune = false;
		}
		((AdvancedGunBehavior)this).OnPostDroppedByPlayer(player);
	}

	private void HandlePropFly(bool AddsPropFly)
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			PlayerController val = GunTools.GunPlayerOwner(base.gun);
			GunTools.RemoveStatFromGun(base.gun, (StatType)0);
			if (!AddsPropFly)
			{
				((GameActor)val).SetIsFlying(false, "GravityGunPropFly", true, false);
				val.AdditionalCanDodgeRollWhileFlying.RemoveOverride("GravityGunPropFly");
			}
			if (AddsPropFly)
			{
				((GameActor)val).SetIsFlying(true, "GravityGunPropFly", true, false);
				val.AdditionalCanDodgeRollWhileFlying.AddOverride("GravityGunPropFly", (float?)null);
				GunTools.AddStatToGun(base.gun, (StatType)0, 2f, (ModifyMethod)0);
			}
			GunTools.GunPlayerOwner(base.gun).stats.RecalculateStats(GunTools.GunPlayerOwner(base.gun), false, false);
		}
	}

	protected override void Update()
	{
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			if (GunTools.GunPlayerOwner(base.gun).CharacterUsesRandomGuns)
			{
				if (isUsingPropFly)
				{
					HandlePropFly(AddsPropFly: false);
					isUsingPropFly = false;
				}
				GunTools.GunPlayerOwner(base.gun).ChangeToRandomGun();
			}
			if ((Object)(object)CurrentCaughtProjectile != (Object)null)
			{
				if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Prop Fly") && !isUsingPropFly)
				{
					HandlePropFly(AddsPropFly: true);
					isUsingPropFly = true;
				}
				else if (!CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Prop Fly") && isUsingPropFly)
				{
					HandlePropFly(AddsPropFly: false);
					isUsingPropFly = false;
				}
			}
			else if (isUsingPropFly)
			{
				HandlePropFly(AddsPropFly: false);
				isUsingPropFly = false;
			}
		}
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Negative Matter"))
			{
				if (((PickupObject)((GameActor)GunTools.GunPlayerOwner(base.gun)).CurrentGun).PickupObjectId == GravityGunID)
				{
					if (!PlayerIsElectricImmune)
					{
						((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver.damageTypeModifiers.Add(ElectricImmunity);
						PlayerIsElectricImmune = true;
					}
				}
				else if (PlayerIsElectricImmune)
				{
					((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver.damageTypeModifiers.Remove(ElectricImmunity);
					PlayerIsElectricImmune = false;
				}
			}
			else if (PlayerIsElectricImmune)
			{
				((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).healthHaver.damageTypeModifiers.Remove(ElectricImmunity);
				PlayerIsElectricImmune = false;
			}
		}
		if (base.gun.IsFiring && !Object.op_Implicit((Object)(object)CurrentCaughtProjectile))
		{
			CheckForGrab();
		}
		else if (base.gun.IsFiring && Object.op_Implicit((Object)(object)CurrentCaughtProjectile))
		{
			if ((Object)(object)((BraveBehaviour)CurrentCaughtProjectile).specRigidbody == (Object)null)
			{
				CurrentCaughtProjectile.DieInAir(false, true, true, false);
			}
			((BraveBehaviour)CurrentCaughtProjectile).transform.position = Vector2.op_Implicit(HoldPosition() - ObjectCenterOffset(((Component)CurrentCaughtProjectile).gameObject));
			if ((Object)(object)((BraveBehaviour)CurrentCaughtProjectile).specRigidbody != (Object)null)
			{
				((BraveBehaviour)CurrentCaughtProjectile).specRigidbody.Position = new Position(HoldPosition() - ObjectCenterOffset(((Component)CurrentCaughtProjectile).gameObject));
				((BraveBehaviour)CurrentCaughtProjectile).specRigidbody.UpdateColliderPositions();
			}
		}
		else if (!base.gun.IsFiring && Object.op_Implicit((Object)(object)CurrentCaughtProjectile))
		{
			AkSoundEngine.PostEvent("Play_wpn_chargelaser_shot_01", ((Component)GunTools.GunPlayerOwner(base.gun)).gameObject);
			LaunchProjectile();
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void LaunchProjectile()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner) && base.gun.CurrentOwner is PlayerController)
		{
			CurrentCaughtProjectile.SuppressHitEffects = true;
			CurrentCaughtProjectile.collidesWithProjectiles = true;
			CurrentCaughtProjectile.UpdateCollisionMask();
			((BraveBehaviour)CurrentCaughtProjectile).transform.parent = null;
			((BraveBehaviour)CurrentCaughtProjectile).specRigidbody.Position = new Position(HoldPosition() - ObjectCenterOffset(((Component)CurrentCaughtProjectile).gameObject));
			CurrentCaughtProjectile.baseData.speed = 30f;
			if (CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Negative Matter"))
			{
				ProjectileData baseData = CurrentCaughtProjectile.baseData;
				baseData.speed *= 1.5f;
			}
			CurrentCaughtProjectile.UpdateSpeed();
			Vector2 centerPosition = base.gun.CurrentOwner.CenterPosition;
			GameActor currentOwner = base.gun.CurrentOwner;
			Vector2 val = Vector3Extensions.XY(((PlayerController)((currentOwner is PlayerController) ? currentOwner : null)).unadjustedAimPoint) - centerPosition;
			Vector2 normalized = ((Vector2)(ref val)).normalized;
			CurrentCaughtProjectile.SendInDirection(normalized, true, false);
			PostLaunchProjectile(CurrentCaughtProjectile);
			CurrentCaughtProjectile = null;
		}
	}

	private Vector2 ObjectCenterOffset(GameObject thing)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2.op_Implicit(thing.transform.position);
		Vector2 result = Vector2.zero;
		if (Object.op_Implicit((Object)(object)thing.GetComponent<tk2dSprite>()))
		{
			result = ((tk2dBaseSprite)thing.GetComponent<tk2dSprite>()).WorldCenter - val;
		}
		else if (Object.op_Implicit((Object)(object)thing.GetComponent<SpeculativeRigidbody>()))
		{
			result = thing.GetComponent<SpeculativeRigidbody>().UnitCenter - val;
		}
		else
		{
			Debug.LogError((object)"NN: tk2dSprite AND SpeculativeRigidbody are null in the selected gameobject!");
		}
		return result;
	}

	private void CatchObject(GameObject thingy)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Invalid comparison between Unknown and I4
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_078e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d1: Expected O, but got Unknown
		//IL_08b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		AkSoundEngine.PostEvent("Play_WPN_RechargeGun_Recharge_01", ((Component)GunTools.GunPlayerOwner(base.gun)).gameObject);
		if (!Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			return;
		}
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
			thingy.transform.position = Vector2.op_Implicit(HoldPosition() - ObjectCenterOffset(thingy));
			thingy.transform.parent = ((BraveBehaviour)base.gun).transform;
			Projectile orAddComponent = GameObjectExtensions.GetOrAddComponent<Projectile>(thingy);
			orAddComponent.Shooter = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).specRigidbody;
			orAddComponent.Owner = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).gameActor;
			orAddComponent.baseData.damage = 15f;
			orAddComponent.baseData.range = 1000f;
			orAddComponent.baseData.speed = 0f;
			orAddComponent.collidesWithProjectiles = false;
			orAddComponent.baseData.force = 50f;
			((BraveBehaviour)orAddComponent).specRigidbody.CollideWithTileMap = true;
			((BraveBehaviour)orAddComponent).specRigidbody.Reinitialize();
			((BraveBehaviour)orAddComponent).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
			orAddComponent.Start();
			orAddComponent.projectileHitHealth = 20;
			orAddComponent.UpdateCollisionMask();
			((Component)orAddComponent).gameObject.AddComponent<GravityGunObjectDeathHandler>();
			CurrentCaughtProjectile = orAddComponent;
		}
		else if (Object.op_Implicit((Object)(object)thingy.GetComponent<MajorBreakable>()))
		{
			bool flag = false;
			bool flag2 = false;
			thingy.GetComponent<MajorBreakable>().DamageReduction = 0.1f;
			thingy.GetComponent<MajorBreakable>().IgnoreExplosions = true;
			thingy.transform.position = Vector2.op_Implicit(HoldPosition() - ObjectCenterOffset(thingy));
			if (Object.op_Implicit((Object)(object)thingy.GetComponentInParent<FlippableCover>()))
			{
				flag2 = true;
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
			if (Object.op_Implicit((Object)(object)thingy.GetComponent<Chest>()))
			{
				thingy.GetComponent<Chest>().pickedUp = true;
				thingy.GetComponent<Chest>().contents = null;
				thingy.GetComponent<Chest>().ForceKillFuse();
				if ((int)thingy.GetComponent<Chest>().ChestIdentifier == 2)
				{
					thingy.GetComponent<Chest>().RevealSecretRainbow();
				}
				thingy.GetComponent<Chest>().DeregisterChestOnMinimap();
			}
			thingy.transform.parent = ((BraveBehaviour)base.gun).transform;
			Projectile orAddComponent2 = GameObjectExtensions.GetOrAddComponent<Projectile>(thingy);
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent2).specRigidbody))
			{
				((BraveBehaviour)orAddComponent2).specRigidbody.Initialize();
			}
			orAddComponent2.Shooter = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).specRigidbody;
			orAddComponent2.Owner = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).gameActor;
			orAddComponent2.baseData.damage = 30f;
			if (Object.op_Implicit((Object)(object)thingy.GetComponent<Chest>()) && !thingy.GetComponent<Chest>().IsOpen)
			{
				if (thingy.GetComponent<Chest>().IsRainbowChest || thingy.GetComponent<Chest>().IsGlitched)
				{
					ProjectileData baseData = orAddComponent2.baseData;
					baseData.damage *= 100000f;
				}
				else
				{
					ProjectileData baseData2 = orAddComponent2.baseData;
					baseData2.damage *= 2f;
				}
			}
			if (flag2 && Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Hidden Tech Nitro"))
			{
				ExplosiveModifier orAddComponent3 = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)orAddComponent2).gameObject);
				PickupObject byId = PickupObjectDatabase.GetById(398);
				orAddComponent3.explosionData = ((byId != null) ? ((Component)byId).GetComponent<TableFlipItem>().ProjectileExplosionData : null);
				if (GunTools.GunPlayerOwner(base.gun).HasActiveBonusSynergy((CustomSynergyType)90, false))
				{
					HomingModifier val = ((Component)orAddComponent2).gameObject.AddComponent<HomingModifier>();
					val.AssignProjectile(orAddComponent2);
					val.HomingRadius = 20f;
					val.AngularVelocity = 720f;
					BounceProjModifier val2 = ((Component)orAddComponent2).gameObject.AddComponent<BounceProjModifier>();
					val2.numberOfBounces = 4;
					val2.onlyBounceOffTiles = true;
				}
			}
			orAddComponent2.baseData.range = 1000f;
			orAddComponent2.baseData.speed = 0f;
			if (flag)
			{
				orAddComponent2.collidesWithProjectiles = true;
			}
			else
			{
				orAddComponent2.collidesWithProjectiles = false;
			}
			orAddComponent2.pierceMinorBreakables = true;
			orAddComponent2.baseData.force = 50f;
			((BraveBehaviour)orAddComponent2).specRigidbody.CollideWithTileMap = true;
			((BraveBehaviour)orAddComponent2).specRigidbody.Reinitialize();
			((BraveBehaviour)orAddComponent2).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
			orAddComponent2.Start();
			orAddComponent2.projectileHitHealth = 20;
			orAddComponent2.UpdateCollisionMask();
			thingy.AddComponent<GravityGunObjectDeathHandler>();
			CurrentCaughtProjectile = orAddComponent2;
		}
		else
		{
			if (!Object.op_Implicit((Object)(object)thingy.GetComponent<AIActor>()))
			{
				return;
			}
			SpeculativeRigidbody component2 = thingy.GetComponent<SpeculativeRigidbody>();
			HealthHaver component3 = thingy.GetComponent<HealthHaver>();
			bool flag3 = true;
			if (Object.op_Implicit((Object)(object)thingy.GetComponent<BulletKingToadieController>()))
			{
				for (int num2 = ((Delegate)(object)component2.OnPreRigidbodyCollision).GetInvocationList().Count() - 1; num2 >= 0; num2--)
				{
					Delegate delegate2 = ((Delegate)(object)component2.OnPreRigidbodyCollision).GetInvocationList()[num2];
					if (delegate2.Method.ToString().Contains("PreRigidbodyCollision"))
					{
						component2.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)component2.OnPreRigidbodyCollision, delegate2);
					}
				}
			}
			if (thingy.GetComponent<AIActor>().EnemyGuid == "78a8ee40dff2477e9c2134f6990ef297" && AIActorUtility.IsSecretlyTheMineFlayer(thingy.GetComponent<AIActor>()))
			{
				flag3 = false;
				thingy.GetComponent<HealthHaver>().ApplyDamage(2.1474836E+09f, Vector2.zero, "Begone Thot", (CoreDamageTypes)0, (DamageCategory)0, true, (PixelCollider)null, false);
			}
			if (flag3)
			{
				if (Object.op_Implicit((Object)(object)thingy.GetComponent<BehaviorSpeculator>()))
				{
					thingy.GetComponent<BehaviorSpeculator>().Stun(1E+12f, true);
				}
				((GameActor)thingy.GetComponent<AIActor>()).FallingProhibited = true;
				thingy.transform.position = Vector2.op_Implicit(HoldPosition() - ObjectCenterOffset(thingy));
				thingy.transform.parent = ((BraveBehaviour)base.gun).transform;
				Projectile orAddComponent4 = GameObjectExtensions.GetOrAddComponent<Projectile>(thingy);
				orAddComponent4.Shooter = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).specRigidbody;
				orAddComponent4.DestroyMode = (ProjectileDestroyMode)1;
				orAddComponent4.Owner = ((BraveBehaviour)GunTools.GunPlayerOwner(base.gun)).gameActor;
				if (thingy.GetComponent<HealthHaver>().GetMaxHealth() < 500f)
				{
					orAddComponent4.baseData.damage = thingy.GetComponent<HealthHaver>().GetMaxHealth();
				}
				else
				{
					orAddComponent4.baseData.damage = 500f;
				}
				orAddComponent4.baseData.range = 1000f;
				orAddComponent4.baseData.speed = 0f;
				orAddComponent4.baseData.force = 50f;
				orAddComponent4.collidesWithProjectiles = false;
				orAddComponent4.pierceMinorBreakables = true;
				((BraveBehaviour)orAddComponent4).specRigidbody.CollideWithTileMap = true;
				((BraveBehaviour)orAddComponent4).specRigidbody.CollideWithOthers = true;
				orAddComponent4.collidesWithEnemies = true;
				((BraveBehaviour)orAddComponent4).specRigidbody.Reinitialize();
				((BraveBehaviour)orAddComponent4).specRigidbody.PrimaryPixelCollider.CollisionLayer = (CollisionLayer)4;
				orAddComponent4.Start();
				orAddComponent4.projectileHitHealth = 20;
				orAddComponent4.UpdateCollisionMask();
				((Component)orAddComponent4).gameObject.AddComponent<GravityGunObjectDeathHandler>();
				CurrentCaughtProjectile = orAddComponent4;
			}
		}
	}

	private float HealthMaxValue()
	{
		float num = 15f;
		if (Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)) && CustomSynergies.PlayerHasActiveSynergy(GunTools.GunPlayerOwner(base.gun), "Negative Matter"))
		{
			num = 20f;
		}
		return num * AIActor.BaseLevelHealthModifier;
	}

	private void PostLaunchProjectile(Projectile bullet)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(bullet)))
		{
			return;
		}
		PlayerController val = ProjectileUtility.ProjectilePlayerOwner(bullet);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Negative Matter"))
		{
			bullet.damageTypes = (CoreDamageTypes)(bullet.damageTypes | 0x40);
		}
		ProjectileData baseData = bullet.baseData;
		baseData.damage *= val.stats.GetStatValue((StatType)5);
		ProjectileData baseData2 = bullet.baseData;
		baseData2.speed *= val.stats.GetStatValue((StatType)6);
		ProjectileData baseData3 = bullet.baseData;
		baseData3.force *= val.stats.GetStatValue((StatType)12);
		bullet.BossDamageMultiplier *= val.stats.GetStatValue((StatType)22);
		if (CustomSynergies.PlayerHasActiveSynergy(val, "Red Letter Day") && Object.op_Implicit((Object)(object)((Component)bullet).gameObject.GetComponent<MinorBreakable>()) && (Random.value <= 0.1f || ((Object)((Component)bullet).gameObject.GetComponent<MinorBreakable>()).name.ToLower().Contains("crate")))
		{
			switch (Random.Range(1, 5))
			{
			case 1:
				bullet.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.irradiatedLeadEffect);
				break;
			case 2:
				bullet.statusEffectsToApply.Add((GameActorEffect)(object)StaticStatusEffects.hotLeadEffect);
				break;
			case 3:
			{
				ExplosiveModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<ExplosiveModifier>(((Component)bullet).gameObject);
				orAddComponent.explosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData;
				break;
			}
			case 4:
			{
				GravityGunObjectDeathHandler component = ((Component)bullet).gameObject.GetComponent<GravityGunObjectDeathHandler>();
				if (Object.op_Implicit((Object)(object)component))
				{
					component.AppliesGlitter = true;
				}
				break;
			}
			}
		}
		bullet.UpdateSpeed();
		val.DoPostProcessProjectile(bullet);
		FakeVolleyModification(bullet, val);
	}

	private void FakeVolleyModification(Projectile bullet, PlayerController owner)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<Projectile, float> dictionary = new Dictionary<Projectile, float>();
		dictionary.Add(bullet, Vector2Extensions.ToAngle(bullet.Direction));
		foreach (PassiveItem passiveItem in owner.passiveItems)
		{
			if (((PickupObject)passiveItem).PickupObjectId == 241)
			{
				int count = dictionary.Count;
				for (int i = 0; i < count; i++)
				{
					float accuracyAngled = ProjSpawnHelper.GetAccuracyAngled(dictionary[dictionary.Keys.ElementAt(i)], 25f, owner);
					float accuracyAngled2 = ProjSpawnHelper.GetAccuracyAngled(dictionary[dictionary.Keys.ElementAt(i)], 25f, owner);
					Projectile key = CloneProjectileForFakeVolley(dictionary.Keys.ElementAt(i), accuracyAngled, owner);
					Projectile key2 = CloneProjectileForFakeVolley(dictionary.Keys.ElementAt(i), accuracyAngled2, owner);
					dictionary.Add(key, accuracyAngled);
					dictionary.Add(key2, accuracyAngled2);
				}
			}
			if (((PickupObject)passiveItem).PickupObjectId == 287)
			{
				int count2 = dictionary.Count;
				for (int j = 0; j < count2; j++)
				{
					float accuracyAngled3 = ProjSpawnHelper.GetAccuracyAngled(dictionary[dictionary.Keys.ElementAt(j)] + 180f, 5f, owner);
					Projectile key3 = CloneProjectileForFakeVolley(dictionary.Keys.ElementAt(j), accuracyAngled3, owner);
					dictionary.Add(key3, accuracyAngled3);
				}
			}
			if (((PickupObject)passiveItem).PickupObjectId == CrossBullets.CrossBulletsID && Object.op_Implicit((Object)(object)((Component)passiveItem).GetComponent<CrossBullets>()) && ((Component)passiveItem).GetComponent<CrossBullets>().isActive)
			{
				int count3 = dictionary.Count;
				for (int k = 0; k < count3; k++)
				{
					float accuracyAngled4 = ProjSpawnHelper.GetAccuracyAngled(dictionary[dictionary.Keys.ElementAt(k)] - 90f, 10f, owner);
					float accuracyAngled5 = ProjSpawnHelper.GetAccuracyAngled(dictionary[dictionary.Keys.ElementAt(k)] + 90f, 10f, owner);
					float accuracyAngled6 = ProjSpawnHelper.GetAccuracyAngled(dictionary[dictionary.Keys.ElementAt(k)] + 180f, 10f, owner);
					Projectile key4 = CloneProjectileForFakeVolley(dictionary.Keys.ElementAt(k), accuracyAngled4, owner);
					Projectile key5 = CloneProjectileForFakeVolley(dictionary.Keys.ElementAt(k), accuracyAngled5, owner);
					Projectile key6 = CloneProjectileForFakeVolley(dictionary.Keys.ElementAt(k), accuracyAngled6, owner);
					dictionary.Add(key4, accuracyAngled4);
					dictionary.Add(key5, accuracyAngled5);
					dictionary.Add(key6, accuracyAngled6);
				}
			}
		}
		foreach (PlayerItem activeItem in owner.activeItems)
		{
			if (((PickupObject)activeItem).PickupObjectId == 168 && activeItem.IsCurrentlyActive)
			{
				int count4 = dictionary.Count;
				for (int l = 0; l < count4; l++)
				{
					float accuracyAngled7 = ProjSpawnHelper.GetAccuracyAngled(dictionary[dictionary.Keys.ElementAt(l)], 20f, owner);
					Projectile key7 = CloneProjectileForFakeVolley(dictionary.Keys.ElementAt(l), accuracyAngled7, owner);
					dictionary.Add(key7, accuracyAngled7);
				}
			}
		}
	}

	private Projectile CloneProjectileForFakeVolley(Projectile bullet, float angle, PlayerController owner)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.SpawnProjectile(((Component)bullet).gameObject, Vector2.op_Implicit(((BraveBehaviour)bullet).sprite.WorldCenter), Quaternion.Euler(0f, 0f, angle), true);
		Projectile component = val.GetComponent<Projectile>();
		((BraveBehaviour)component).specRigidbody.Reinitialize();
		component.collidesWithPlayer = false;
		component.Owner = (GameActor)(object)owner;
		component.Shooter = ((BraveBehaviour)owner).specRigidbody;
		AIActor component2 = ((Component)bullet).GetComponent<AIActor>();
		AIActor component3 = val.GetComponent<AIActor>();
		if ((Object)(object)component3 != (Object)null && (Object)(object)component2 != (Object)null)
		{
			component3.CustomLootTable = component2.CustomLootTable;
			component3.CustomLootTableMaxDrops = component2.CustomLootTableMaxDrops;
			component3.CustomLootTableMinDrops = component2.CustomLootTableMinDrops;
			component3.CanDropCurrency = component2.CanDropCurrency;
			component3.AssignedCurrencyToDrop = component2.AssignedCurrencyToDrop;
			component.DestroyMode = (ProjectileDestroyMode)1;
			component3.ParentRoom = ProjectileUtility.GetAbsoluteRoom(bullet);
		}
		Chest component4 = ((Component)bullet).GetComponent<Chest>();
		Chest component5 = val.GetComponent<Chest>();
		if ((Object)(object)component4 != (Object)null && (Object)(object)component5 != (Object)null && component4.IsMimic)
		{
			component5.MaybeBecomeMimic();
		}
		return component;
	}

	public override void OnReloadPressed(PlayerController player, Gun gun, bool manualReload)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)CurrentCaughtProjectile))
		{
			((BraveBehaviour)CurrentCaughtProjectile).transform.parent = null;
			if ((Object)(object)((BraveBehaviour)CurrentCaughtProjectile).specRigidbody != (Object)null)
			{
				((BraveBehaviour)CurrentCaughtProjectile).specRigidbody.Position = new Position(HoldPosition() - ObjectCenterOffset(((Component)CurrentCaughtProjectile).gameObject));
			}
			CurrentCaughtProjectile.DieInAir(false, true, true, false);
		}
		((AdvancedGunBehavior)this).OnReloadPressed(player, gun, manualReload);
	}

	private static void HandleMimicOverrideBreak(PlayerController player, Chest mimic)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		List<PickupObject> list = mimic.PredictContents(player);
		if (list.Count <= 0)
		{
			return;
		}
		if (GameStatsManager.Instance.IsRainbowRun)
		{
			LootEngine.SpawnBowlerNote(GameManager.Instance.RewardManager.BowlerNoteMimic, ((BraveBehaviour)mimic).sprite.WorldCenter, GameManager.Instance.Dungeon.GetRoomFromPosition(Vector2Extensions.ToIntVector2(((BraveBehaviour)mimic).sprite.WorldCenter, (VectorConversions)2)), true);
			return;
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			LootEngine.SpawnItem(((Component)list[num]).gameObject, Vector2.op_Implicit(((BraveBehaviour)mimic).sprite.WorldCenter), Vector2.zero, 1f, false, true, false);
		}
	}

	private static void HandleChestOverrideBreak(PlayerController player, Chest chest)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		Dungeon dungeon = GameManager.Instance.Dungeon;
		dungeon.GeneratedMagnificence -= chest.GeneratedMagnificence;
		if (chest.spawnAnimName.StartsWith("wood_"))
		{
			GameStatsManager.Instance.RegisterStatChange((TrackedStats)93, 1f);
		}
		if ((int)GameManager.Instance.CurrentGameType == 1 && GameManager.Instance.NumberOfLivingPlayers == 1)
		{
			PlayerController val = ((!((BraveBehaviour)GameManager.Instance.PrimaryPlayer).healthHaver.IsDead) ? GameManager.Instance.SecondaryPlayer : GameManager.Instance.PrimaryPlayer);
			((Behaviour)((BraveBehaviour)val).specRigidbody).enabled = true;
			((Component)val).gameObject.SetActive(true);
			((BraveBehaviour)((BraveBehaviour)val).sprite).renderer.enabled = true;
			val.ResurrectFromChest(((BraveBehaviour)chest).sprite.WorldBottomCenter);
		}
		else
		{
			List<PickupObject> list = new List<PickupObject>();
			bool flag = PassiveItem.IsFlagSetAtAll(typeof(ChestBrokenImprovementItem));
			bool flag2 = GameStatsManager.Instance.GetFlag((GungeonFlags)171004);
			float num = GameManager.Instance.RewardManager.ChestDowngradeChance;
			float num2 = GameManager.Instance.RewardManager.ChestHalfHeartChance;
			float num3 = GameManager.Instance.RewardManager.ChestExplosionChance;
			float num4 = GameManager.Instance.RewardManager.ChestJunkChance;
			float num5 = ((!flag2) ? 0f : 0.005f);
			bool flag3 = GameStatsManager.Instance.GetFlag((GungeonFlags)150002);
			float num6 = ((!flag3 || Chest.HasDroppedSerJunkanThisSession) ? 0f : GameManager.Instance.RewardManager.ChestJunkanUnlockedChance);
			if (Object.op_Implicit((Object)(object)GameManager.Instance.PrimaryPlayer) && GameManager.Instance.PrimaryPlayer.carriedConsumables.KeyBullets > 0)
			{
				num4 *= GameManager.Instance.RewardManager.HasKeyJunkMultiplier;
			}
			if (SackKnightController.HasJunkan())
			{
				num4 *= GameManager.Instance.RewardManager.HasJunkanJunkMultiplier;
				num5 *= 3f;
			}
			if (chest.IsTruthChest)
			{
				num = 0f;
				num2 = 0f;
				num3 = 0f;
				num4 = 1f;
			}
			num4 -= num5;
			float num7 = num5 + num + num2 + num3 + num4 + num6;
			float num8 = Random.value * num7;
			bool flag4 = false;
			if (flag2 && num8 < num5)
			{
				int goldJunk = GlobalItemIds.GoldJunk;
				list.Add(PickupObjectDatabase.GetById(goldJunk));
			}
			else if (num8 < num || flag)
			{
				int tierShift = -4;
				flag4 = true;
				bool flag5 = false;
				if (flag)
				{
					float value = Random.value;
					if (!(value < ChestBrokenImprovementItem.PickupQualChance))
					{
						tierShift = ((value < ChestBrokenImprovementItem.PickupQualChance + ChestBrokenImprovementItem.MinusOneQualChance) ? (-1) : ((!(value < ChestBrokenImprovementItem.PickupQualChance + ChestBrokenImprovementItem.EqualQualChance + ChestBrokenImprovementItem.MinusOneQualChance)) ? 1 : 0));
					}
					else
					{
						flag5 = true;
						PickupObject val2 = null;
						while ((Object)(object)val2 == (Object)null)
						{
							GameObject val3 = GameManager.Instance.RewardManager.CurrentRewardData.SingleItemRewardTable.SelectByWeight(false);
							if (Object.op_Implicit((Object)(object)val3))
							{
								val2 = val3.GetComponent<PickupObject>();
							}
						}
						list.Add(val2);
					}
				}
				if (!flag5)
				{
					if (chest.forceContentIds.Count > 0)
					{
						for (int i = 0; i < chest.forceContentIds.Count; i++)
						{
							list.Add(PickupObjectDatabase.GetById(chest.forceContentIds[i]));
						}
					}
					if (list.Count == 0 && !flag)
					{
						FloorRewardManifest seededManifestForCurrentFloor = GameManager.Instance.RewardManager.GetSeededManifestForCurrentFloor();
						list = ((seededManifestForCurrentFloor == null || !seededManifestForCurrentFloor.PregeneratedChestContents.ContainsKey(chest)) ? OverrideGenerateChestContents(player, chest, tierShift, new Random()) : seededManifestForCurrentFloor.PregeneratedChestContents[chest]);
					}
				}
			}
			else if (num8 < num + num2)
			{
				list.Add(GameManager.Instance.RewardManager.HalfHeartPrefab);
			}
			else if (num8 < num + num2 + num4)
			{
				bool flag6 = false;
				if (!Chest.HasDroppedSerJunkanThisSession && !flag3 && Random.value < 0.2f)
				{
					Chest.HasDroppedSerJunkanThisSession = true;
					flag6 = true;
				}
				int num9 = ((chest.overrideJunkId < 0) ? GlobalItemIds.Junk : chest.overrideJunkId);
				if (flag6)
				{
					num9 = GlobalItemIds.SackKnightBoon;
				}
				list.Add(PickupObjectDatabase.GetById(num9));
			}
			else if (num8 < num + num2 + num4 + num6)
			{
				Chest.HasDroppedSerJunkanThisSession = true;
				list.Add(PickupObjectDatabase.GetById(GlobalItemIds.SackKnightBoon));
			}
			else
			{
				Exploder.DoDefaultExplosion(Vector2.op_Implicit(((BraveBehaviour)chest).sprite.WorldCenter), Vector2.zero, (Action)null, false, (CoreDamageTypes)0, false);
			}
			if (list.Count > 0)
			{
				if (flag4 && GameStatsManager.Instance.IsRainbowRun)
				{
					LootEngine.SpawnBowlerNote(GameManager.Instance.RewardManager.BowlerNoteChest, ((BraveBehaviour)chest).sprite.WorldCenter, GameManager.Instance.Dungeon.GetRoomFromPosition(Vector2Extensions.ToIntVector2(((BraveBehaviour)chest).sprite.WorldCenter, (VectorConversions)2)), true);
				}
				else
				{
					for (int num10 = list.Count - 1; num10 >= 0; num10--)
					{
						LootEngine.SpawnItem(((Component)list[num10]).gameObject, Vector2.op_Implicit(((BraveBehaviour)chest).sprite.WorldCenter), Vector2.zero, 1f, false, true, false);
					}
				}
			}
		}
		for (int j = 0; j < GameManager.Instance.AllPlayers.Length; j++)
		{
			if (GameManager.Instance.AllPlayers[j].OnChestBroken != null)
			{
				GameManager.Instance.AllPlayers[j].OnChestBroken(GameManager.Instance.AllPlayers[j], chest);
			}
		}
	}

	private static List<PickupObject> OverrideGenerateChestContents(PlayerController player, Chest chest, int tierShift, Random safeRandom = null)
	{
		List<PickupObject> list = new List<PickupObject>();
		if ((Object)(object)chest.lootTable.lootTable == (Object)null)
		{
			list.Add(GameManager.Instance.Dungeon.baseChestContents.SelectByWeight(false).GetComponent<PickupObject>());
		}
		else if (chest.lootTable != null)
		{
			if (tierShift <= -1)
			{
				list = ((!((Object)(object)chest.breakertronLootTable.lootTable != (Object)null)) ? chest.lootTable.GetItemsForPlayer(player, tierShift, (GenericLootTable)null, safeRandom) : chest.breakertronLootTable.GetItemsForPlayer(player, -1, (GenericLootTable)null, safeRandom));
			}
			else
			{
				list = chest.lootTable.GetItemsForPlayer(player, tierShift, (GenericLootTable)null, safeRandom);
				if (chest.lootTable.CompletesSynergy)
				{
					float num = Mathf.Clamp01(0.6f - 0.1f * (float)chest.lootTable.LastGenerationNumSynergiesCalculated);
					num = Mathf.Clamp(num, 0.2f, 1f);
					if (num > 0f)
					{
						float num2 = ((safeRandom == null) ? Random.value : ((float)safeRandom.NextDouble()));
						if (num2 < num)
						{
							chest.lootTable.CompletesSynergy = false;
							list = chest.lootTable.GetItemsForPlayer(player, tierShift, (GenericLootTable)null, safeRandom);
							chest.lootTable.CompletesSynergy = true;
						}
					}
				}
			}
		}
		return list;
	}
}
