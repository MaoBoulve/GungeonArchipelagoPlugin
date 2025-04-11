using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

internal class LibramOfTheChambers : PassiveItem
{
	public class LibramOrbitalController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBreakBarrel_003Ed__5 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MinorBreakable breakable;

			public LibramOrbitalController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CBreakBarrel_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				_003C_003E1__state = -2;
			}

			private bool MoveNext()
			{
				//IL_0026: Unknown result type (might be due to invalid IL or missing references)
				//IL_0030: Expected O, but got Unknown
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = (object)new WaitForSeconds(15f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					breakable.Break();
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private GameObject self;

		private SpeculativeRigidbody body;

		private tk2dSprite sprite;

		public float shootDelay;

		private float timer;

		public bool shoots;

		public bool respondsToHit;

		public PlayerController owner;

		public int gunIDToShoot;

		public bool curseShot;

		public bool isCyclops;

		public bool isBarrel;

		public bool isGlass;

		public bool isRecycle;

		public LibramOrbitalController()
		{
			shootDelay = 4f;
			respondsToHit = false;
			shoots = false;
			gunIDToShoot = 56;
			isGlass = false;
			isRecycle = false;
		}

		private void Start()
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			timer = shootDelay;
			self = ((Component)this).gameObject;
			sprite = self.GetComponent<tk2dSprite>();
			if (Object.op_Implicit((Object)(object)self.GetComponent<SpeculativeRigidbody>()))
			{
				body = self.GetComponent<SpeculativeRigidbody>();
				if (respondsToHit)
				{
					SpeculativeRigidbody obj = body;
					obj.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)obj.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHitByBullet));
				}
			}
		}

		private void OnDestroy()
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			if (respondsToHit)
			{
				SpeculativeRigidbody obj = body;
				obj.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Remove((Delegate)(object)obj.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnGuonHitByBullet));
			}
		}

		private void OnGuonHitByBullet(SpeculativeRigidbody myRigidbody, PixelCollider myCollider, SpeculativeRigidbody other, PixelCollider otherCollider)
		{
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile) && Object.op_Implicit((Object)(object)((BraveBehaviour)other).projectile.Owner) && !(((BraveBehaviour)other).projectile.Owner is PlayerController) && isRecycle && Object.op_Implicit((Object)(object)owner) && Object.op_Implicit((Object)(object)((GameActor)owner).CurrentGun) && ((GameActor)owner).CurrentGun.CanGainAmmo)
			{
				((GameActor)owner).CurrentGun.GainAmmo(1);
			}
		}

		private void Update()
		{
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Invalid comparison between Unknown and I4
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0396: Expected O, but got Unknown
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Expected O, but got Unknown
			//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			if (timer >= 0f)
			{
				timer -= BraveTime.DeltaTime;
				return;
			}
			if (Object.op_Implicit((Object)(object)owner) && owner.IsInCombat)
			{
				if (shoots)
				{
					int num = 1;
					if (isGlass)
					{
						num += PlayerUtility.GetNumberOfItemInInventory(owner, 565);
					}
					for (int i = 0; i < num; i++)
					{
						AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(Vector2.op_Implicit(((Component)this).transform.position), true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
						if (!((Object)(object)nearestEnemyToPosition != (Object)null))
						{
							continue;
						}
						Vector2 targetPosition = Vector2.op_Implicit(((BraveBehaviour)nearestEnemyToPosition).transform.position);
						if (Object.op_Implicit((Object)(object)((BraveBehaviour)nearestEnemyToPosition).specRigidbody))
						{
							targetPosition = ((BraveBehaviour)nearestEnemyToPosition).specRigidbody.UnitCenter;
						}
						float angleVariance = 5f;
						if (i > 1 && isGlass)
						{
							angleVariance = 10f;
						}
						PickupObject byId = PickupObjectDatabase.GetById(gunIDToShoot);
						GameObject val = ProjSpawnHelper.SpawnProjectileTowardsPoint(((Component)((Gun)((byId is Gun) ? byId : null)).DefaultModule.projectiles[0]).gameObject, ((tk2dBaseSprite)sprite).WorldCenter, targetPosition, 0f, angleVariance, owner);
						Projectile component = val.GetComponent<Projectile>();
						if (Object.op_Implicit((Object)(object)component))
						{
							component.Owner = (GameActor)(object)owner;
							component.Shooter = body;
							ProjectileUtility.ApplyCompanionModifierToBullet(component, owner);
							ProjectileData baseData = component.baseData;
							baseData.damage *= owner.stats.GetStatValue((StatType)5);
							ProjectileData baseData2 = component.baseData;
							baseData2.range *= owner.stats.GetStatValue((StatType)26);
							ProjectileData baseData3 = component.baseData;
							baseData3.speed *= owner.stats.GetStatValue((StatType)6);
							ProjectileData baseData4 = component.baseData;
							baseData4.force *= owner.stats.GetStatValue((StatType)12);
							owner.DoPostProcessProjectile(component);
							if (curseShot)
							{
								component.AdjustPlayerProjectileTint(ExtendedColours.cursedBulletsPurple, 2, 0f);
								component.CurseSparks = true;
								ProjectileData baseData5 = component.baseData;
								baseData5.damage *= 0.15f * owner.stats.GetStatValue((StatType)14) + 1f;
							}
							if (isCyclops)
							{
								component.AdditionalScaleMultiplier *= 1.5f;
								ProjectileData baseData6 = component.baseData;
								baseData6.damage *= 3f;
								PierceProjModifier val2 = ((Component)component).gameObject.AddComponent<PierceProjModifier>();
								val2.penetration = 3;
							}
						}
					}
				}
				else if (isBarrel)
				{
					Vector2 worldCenter = ((tk2dBaseSprite)sprite).WorldCenter;
					CellData val3 = GameManager.Instance.Dungeon.data.cellData[(int)worldCenter.x][(int)worldCenter.y];
					if ((int)val3.type == 2)
					{
						GameObject val4 = Object.Instantiate<GameObject>(EasyPlaceableObjects.GenericBarrel, Vector2.op_Implicit(worldCenter), Quaternion.identity);
						val4.GetComponentInChildren<MinorBreakable>().OnlyBrokenByCode = true;
						SpeculativeRigidbody componentInChildren = val4.GetComponentInChildren<SpeculativeRigidbody>();
						componentInChildren.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)componentInChildren.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(HandlePreCollision));
						val4.GetComponentInChildren<SpeculativeRigidbody>().PrimaryPixelCollider.CollisionLayer = (CollisionLayer)15;
						((tk2dBaseSprite)val4.GetComponentInChildren<tk2dSprite>()).PlaceAtPositionByAnchor(Vector2.op_Implicit(worldCenter), (Anchor)1);
						((MonoBehaviour)this).StartCoroutine(BreakBarrel(val4.GetComponentInChildren<MinorBreakable>()));
					}
				}
			}
			timer = shootDelay;
		}

		private IEnumerator BreakBarrel(MinorBreakable breakable)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003CBreakBarrel_003Ed__5(0)
			{
				_003C_003E4__this = this,
				breakable = breakable
			};
		}

		private void HandlePreCollision(SpeculativeRigidbody myRigidbody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidbody, PixelCollider otherPixelCollider)
		{
			try
			{
				if (!Object.op_Implicit((Object)(object)otherRigidbody))
				{
					return;
				}
				if (Object.op_Implicit((Object)(object)((Component)otherRigidbody).GetComponent<GameActor>()))
				{
					PhysicsEngine.SkipCollision = true;
				}
				if (Object.op_Implicit((Object)(object)((Component)otherRigidbody).GetComponent<Projectile>()))
				{
					if (Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(((Component)otherRigidbody).GetComponent<Projectile>())))
					{
						PhysicsEngine.SkipCollision = true;
					}
					else
					{
						((Component)myRigidbody).GetComponentInChildren<MinorBreakable>().Break();
					}
				}
			}
			catch (Exception ex)
			{
				ETGModConsole.Log((object)ex.Message, false);
				ETGModConsole.Log((object)ex.StackTrace, false);
			}
		}
	}

	private int currentItems;

	private int lastItems;

	private int currentActives;

	private int lastActives;

	private int currentActiveID;

	private int lastActiveID;

	public static Dictionary<int, GameObject> chamberOrbitalPrefabs = new Dictionary<int, GameObject>();

	public static List<GameObject> currentOrbitals = new List<GameObject>();

	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<LibramOfTheChambers>("Libram of The Chambers", "Behold the Boss Eater!", "Converts Master Rounds from vitality upgrades to bullet damage instead.\n\nAn ancient tome of unreadable scripts and texts with regards to the many Chambers of the Gungeon.", "libramofthechambers_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
	}

	public static void LateInit()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = GuonToolbox.MakeAnimatedOrbital("Yellow Chamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_yellow_001", "libramorbtial_yellow_002", "libramorbtial_yellow_003", "libramorbtial_yellow_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController = val.AddComponent<LibramOrbitalController>();
		libramOrbitalController.shoots = true;
		libramOrbitalController.gunIDToShoot = LovePistol.LovePistolID;
		GameObject val2 = GuonToolbox.MakeAnimatedOrbital("Sixth Chamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_sixth_001", "libramorbtial_sixth_002", "libramorbtial_sixth_003", "libramorbtial_sixth_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController2 = val2.AddComponent<LibramOrbitalController>();
		libramOrbitalController2.shoots = true;
		libramOrbitalController2.shootDelay = 5f;
		libramOrbitalController2.curseShot = true;
		libramOrbitalController2.gunIDToShoot = 45;
		GameObject value = GuonToolbox.MakeAnimatedOrbital("Oiled Cylinder LibramOrbital", 3.5f, 240f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_oiled_001", "libramorbtial_oiled_002", "libramorbtial_oiled_003", "libramorbtial_oiled_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		GameObject val3 = GuonToolbox.MakeAnimatedOrbital("Nitroglycylinder LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_nitro_001", "libramorbtial_nitro_002", "libramorbtial_nitro_003", "libramorbtial_nitro_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController3 = val3.AddComponent<LibramOrbitalController>();
		libramOrbitalController3.shoots = true;
		libramOrbitalController3.gunIDToShoot = 81;
		libramOrbitalController3.shootDelay = 8f;
		GameObject val4 = GuonToolbox.MakeAnimatedOrbital("Glass Chamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_glass_001", "libramorbtial_glass_002", "libramorbtial_glass_003", "libramorbtial_glass_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController4 = val4.AddComponent<LibramOrbitalController>();
		libramOrbitalController4.shoots = true;
		libramOrbitalController4.gunIDToShoot = Glasster.GlassterID;
		libramOrbitalController4.isGlass = true;
		GameObject val5 = GuonToolbox.MakeAnimatedOrbital("Flamechamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_flame_001", "libramorbtial_flame_002", "libramorbtial_flame_003", "libramorbtial_flame_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController5 = val5.AddComponent<LibramOrbitalController>();
		libramOrbitalController5.shoots = true;
		libramOrbitalController5.gunIDToShoot = 336;
		GameObject val6 = GuonToolbox.MakeAnimatedOrbital("Springloaded Chamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_spring_001", "libramorbtial_spring_002", "libramorbtial_spring_003", "libramorbtial_spring_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController6 = val6.AddComponent<LibramOrbitalController>();
		libramOrbitalController6.shoots = true;
		libramOrbitalController6.shootDelay = 1f;
		libramOrbitalController6.gunIDToShoot = 50;
		GameObject val7 = GuonToolbox.MakeAnimatedOrbital("Withering Chamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_withered_001", "libramorbtial_withered_002", "libramorbtial_withered_003", "libramorbtial_withered_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController7 = val7.AddComponent<LibramOrbitalController>();
		libramOrbitalController7.shoots = true;
		libramOrbitalController7.gunIDToShoot = Redhawk.ID;
		GameObject value2 = GuonToolbox.MakeAnimatedOrbital("Heavy Chamber LibramOrbital", 1.7f, 60f, 0, (OrbitalMotionStyle)0, 5f, new List<string> { "libramorbtial_heavy_001", "libramorbtial_heavy_002", "libramorbtial_heavy_003", "libramorbtial_heavy_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		GameObject val8 = GuonToolbox.MakeAnimatedOrbital("Cyclopean Chamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_cyclop_001", "libramorbtial_cyclop_002", "libramorbtial_cyclop_003", "libramorbtial_cyclop_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController8 = val8.AddComponent<LibramOrbitalController>();
		libramOrbitalController8.shoots = true;
		libramOrbitalController8.shootDelay = 6f;
		libramOrbitalController8.gunIDToShoot = 404;
		libramOrbitalController8.isCyclops = true;
		GameObject val9 = GuonToolbox.MakeAnimatedOrbital("Recyclinder LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_recycle_001", "libramorbtial_recycle_002", "libramorbtial_recycle_003", "libramorbtial_recycle_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController9 = val9.AddComponent<LibramOrbitalController>();
		libramOrbitalController9.shoots = false;
		libramOrbitalController9.respondsToHit = true;
		libramOrbitalController9.isRecycle = true;
		GameObject val10 = GuonToolbox.MakeAnimatedOrbital("Barrel Chamber LibramOrbital", 3f, 120f, 0, (OrbitalMotionStyle)0, 0f, new List<string> { "libramorbtial_barrel_001", "libramorbtial_barrel_002", "libramorbtial_barrel_003", "libramorbtial_barrel_004" }, 6, new Vector2(9f, 9f), new Vector2(1f, 2f), (Anchor)0, (WrapMode)0);
		LibramOrbitalController libramOrbitalController10 = val10.AddComponent<LibramOrbitalController>();
		libramOrbitalController10.shoots = false;
		libramOrbitalController10.shootDelay = 1f;
		libramOrbitalController10.isBarrel = true;
		chamberOrbitalPrefabs.Add(570, val);
		chamberOrbitalPrefabs.Add(407, val2);
		chamberOrbitalPrefabs.Add(165, value);
		chamberOrbitalPrefabs.Add(Nitroglycylinder.NitroglycylinderID, val3);
		chamberOrbitalPrefabs.Add(GlassChamber.GlassChamberID, val4);
		chamberOrbitalPrefabs.Add(FlameChamber.ID, val5);
		chamberOrbitalPrefabs.Add(SpringloadedChamber.ID, val6);
		chamberOrbitalPrefabs.Add(WitheringChamber.ID, val7);
		chamberOrbitalPrefabs.Add(HeavyChamber.HeavyChamberID, value2);
		chamberOrbitalPrefabs.Add(CyclopeanChamber.ID, val8);
		chamberOrbitalPrefabs.Add(Recyclinder.RecyclinderID, val9);
		chamberOrbitalPrefabs.Add(BarrelChamber.ID, val10);
	}

	public override void Update()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			CalculateStats(((PassiveItem)this).Owner);
		}
	}

	private void CalculateStats(PlayerController player)
	{
		currentItems = player.passiveItems.Count;
		currentActives = player.activeItems.Count;
		bool flag = false;
		if (Object.op_Implicit((Object)(object)player.CurrentItem))
		{
			currentActiveID = ((PickupObject)player.CurrentItem).PickupObjectId;
			if (currentActiveID != lastActiveID && currentActives == 1)
			{
				flag = true;
			}
		}
		if (!(currentItems != lastItems || currentActives != lastActives || flag))
		{
			return;
		}
		RemoveStat((StatType)5);
		RemoveStat((StatType)3);
		foreach (PassiveItem passiveItem in player.passiveItems)
		{
			if (passiveItem is BasicStatPickup && ((BasicStatPickup)((passiveItem is BasicStatPickup) ? passiveItem : null)).IsMasteryToken)
			{
				AddStat((StatType)5, 1.15f, (ModifyMethod)1);
				AddStat((StatType)3, -1f, (ModifyMethod)0);
			}
		}
		SortOrbitals();
		lastItems = currentItems;
		lastActives = currentActives;
		lastActiveID = currentActiveID;
		player.stats.RecalculateStats(player, true, false);
	}

	private void SortOrbitals()
	{
		if (currentOrbitals != null && currentOrbitals.Count > 0)
		{
			for (int num = currentOrbitals.Count - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)currentOrbitals[num]);
			}
			currentOrbitals.Clear();
		}
		foreach (int key in chamberOrbitalPrefabs.Keys)
		{
			if (((PassiveItem)this).Owner.HasPickupID(key))
			{
				MakeOrbital(chamberOrbitalPrefabs[key]);
			}
		}
		PlayerUtility.RecalculateOrbitals(((PassiveItem)this).Owner);
	}

	private void MakeOrbital(GameObject prefab)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = Object.Instantiate<GameObject>(prefab, ((BraveBehaviour)((PassiveItem)this).Owner).transform.position, Quaternion.identity);
		PlayerOrbital component = val.GetComponent<PlayerOrbital>();
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			component.Initialize(((PassiveItem)this).Owner);
			LibramOrbitalController component2 = val.GetComponent<LibramOrbitalController>();
			if (Object.op_Implicit((Object)(object)component2))
			{
				component2.owner = ((PassiveItem)this).Owner;
			}
		}
		currentOrbitals.Add(val);
	}

	private void AddStat(StatType statType, float amount, ModifyMethod method = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		StatModifier val = new StatModifier
		{
			amount = amount,
			statToBoost = statType,
			modifyType = method
		};
		if (base.passiveStatModifiers == null)
		{
			base.passiveStatModifiers = (StatModifier[])(object)new StatModifier[1] { val };
		}
		else
		{
			base.passiveStatModifiers = base.passiveStatModifiers.Concat((IEnumerable<StatModifier>)(object)new StatModifier[1] { val }).ToArray();
		}
	}

	private void RemoveStat(StatType statType)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < base.passiveStatModifiers.Length; i++)
		{
			if (base.passiveStatModifiers[i].statToBoost != statType)
			{
				list.Add(base.passiveStatModifiers[i]);
			}
		}
		base.passiveStatModifiers = list.ToArray();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		SortOrbitals();
	}

	public override DebrisObject Drop(PlayerController player)
	{
		if (currentOrbitals != null && currentOrbitals.Count > 0)
		{
			for (int num = currentOrbitals.Count - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)currentOrbitals[num]);
			}
			currentOrbitals.Clear();
		}
		return ((PassiveItem)this).Drop(player);
	}
}
