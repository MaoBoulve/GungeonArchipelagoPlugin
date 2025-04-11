using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Dungeonator;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

public class LeadOfLife : PassiveItem
{
	[CompilerGenerated]
	private sealed class _003CLateRecalculation_003Ed__70 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LeadOfLife _003C_003E4__this;

		private List<PassiveItem>.Enumerator _003C_003Es__1;

		private PassiveItem _003Citem_003E5__2;

		private List<PlayerItem>.Enumerator _003C_003Es__3;

		private PlayerItem _003Citem_003E5__4;

		private List<Gun>.Enumerator _003C_003Es__5;

		private Gun _003Citem_003E5__6;

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
		public _003CLateRecalculation_003Ed__70(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003Es__1 = default(List<PassiveItem>.Enumerator);
			_003Citem_003E5__2 = null;
			_003C_003Es__3 = default(List<PlayerItem>.Enumerator);
			_003Citem_003E5__4 = null;
			_003C_003Es__5 = default(List<Gun>.Enumerator);
			_003Citem_003E5__6 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.DestroyAllCompanions();
				_003C_003Es__1 = ((PassiveItem)_003C_003E4__this).Owner.passiveItems.GetEnumerator();
				try
				{
					while (_003C_003Es__1.MoveNext())
					{
						_003Citem_003E5__2 = _003C_003Es__1.Current;
						_003C_003E4__this.TrySpawnCompanionForID(((PickupObject)_003Citem_003E5__2).PickupObjectId, (PickupObject)(object)_003Citem_003E5__2);
						_003Citem_003E5__2 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__1/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__1 = default(List<PassiveItem>.Enumerator);
				_003C_003Es__3 = ((PassiveItem)_003C_003E4__this).Owner.activeItems.GetEnumerator();
				try
				{
					while (_003C_003Es__3.MoveNext())
					{
						_003Citem_003E5__4 = _003C_003Es__3.Current;
						_003C_003E4__this.TrySpawnCompanionForID(((PickupObject)_003Citem_003E5__4).PickupObjectId, (PickupObject)(object)_003Citem_003E5__4);
						_003Citem_003E5__4 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__3/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__3 = default(List<PlayerItem>.Enumerator);
				_003C_003Es__5 = ((PassiveItem)_003C_003E4__this).Owner.inventory.AllGuns.GetEnumerator();
				try
				{
					while (_003C_003Es__5.MoveNext())
					{
						_003Citem_003E5__6 = _003C_003Es__5.Current;
						_003C_003E4__this.TrySpawnCompanionForID(((PickupObject)_003Citem_003E5__6).PickupObjectId, (PickupObject)(object)_003Citem_003E5__6);
						_003Citem_003E5__6 = null;
					}
				}
				finally
				{
					((IDisposable)_003C_003Es__5/*cast due to .constrained prefix*/).Dispose();
				}
				_003C_003Es__5 = default(List<Gun>.Enumerator);
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

	public static Dictionary<int, List<string>> CompanionItemDictionary;

	public static LeadOfLifeCompanionStats HotLeadCompanion;

	public static LeadOfLifeCompanionStats IrradiatedLeadCompanion;

	public static LeadOfLifeCompanionStats BatteryBulletsCompanion;

	public static LeadOfLifeCompanionStats PlusOneBulletsCompanion;

	public static LeadOfLifeCompanionStats AngryBulletsCompanion;

	public static LeadOfLifeCompanionStats CursedBulletsCompanion;

	public static LeadOfLifeCompanionStats EasyReloadBulletsCompanion;

	public static LeadOfLifeCompanionStats GhostBulletsCompanion;

	public static LeadOfLifeCompanionStats FlakBulletsCompanion;

	public static LeadOfLifeCompanionStats HeavyBulletsCompanion;

	public static LeadOfLifeCompanionStats KatanaBulletsCompanion;

	public static LeadOfLifeCompanionStats RemoteBulletsCompanion;

	public static LeadOfLifeCompanionStats BouncyBulletsCompanion;

	public static LeadOfLifeCompanionStats SilverBulletsCompanion;

	public static LeadOfLifeCompanionStats ZombieBulletsCompanion;

	public static LeadOfLifeCompanionStats Bloody9mmCompanion;

	public static LeadOfLifeCompanionStats BumbulletsCompanion;

	public static LeadOfLifeCompanionStats ChanceBulletsCompanion;

	public static LeadOfLifeCompanionStats CharmingRoundsCompanion;

	public static LeadOfLifeCompanionStats DevolverRoundsCompanion;

	public static LeadOfLifeCompanionStats GildedBulletsCompanion;

	public static LeadOfLifeCompanionStats HelixBulletsCompanion;

	public static LeadOfLifeCompanionStats HomingBulletsCompanion;

	public static LeadOfLifeCompanionStats MagicBulletsCompanion;

	public static LeadOfLifeCompanionStats RocketPoweredBulletsCompanion;

	public static LeadOfLifeCompanionStats ScattershotCompanion;

	public static LeadOfLifeCompanionStats ShadowBulletsCompanion;

	public static LeadOfLifeCompanionStats StoutBulletsCompanion;

	public static LeadOfLifeCompanionStats AlphaBulletsCompanion;

	public static LeadOfLifeCompanionStats OmegaBulletsCompanion;

	public static LeadOfLifeCompanionStats ChaosBulletsCompanion;

	public static LeadOfLifeCompanionStats ExplosiveRoundsCompanion;

	public static LeadOfLifeCompanionStats FatBulletsCompanion;

	public static LeadOfLifeCompanionStats FrostBulletsCompanion;

	public static LeadOfLifeCompanionStats HungryBulletsCompanion;

	public static LeadOfLifeCompanionStats OrbitalBulletsCompanion;

	public static LeadOfLifeCompanionStats ShockRoundsCompanion;

	public static LeadOfLifeCompanionStats SnowballetsCompanion;

	public static LeadOfLifeCompanionStats VorpalBulletsCompanion;

	public static LeadOfLifeCompanionStats BlankBulletsCompanion;

	public static LeadOfLifeCompanionStats PlatinumBulletsCompanion;

	public static LeadOfLifeCompanionStats LichsEyeBulletsCompanionA;

	public static LeadOfLifeCompanionStats LichsEyeBulletsCompanionB;

	public static LeadOfLifeCompanionStats BulletTimeCompanion;

	public static LeadOfLifeCompanionStats DarumaCompanion;

	public static LeadOfLifeCompanionStats RiddleOfLeadCompanion;

	public static LeadOfLifeCompanionStats ShotgunCoffeeCompanion;

	public static LeadOfLifeCompanionStats ShotgaColaCompanion;

	public static LeadOfLifeCompanionStats ElderBlankCompanion;

	public static LeadOfLifeCompanionStats BulletGunCompanion;

	public static LeadOfLifeCompanionStats ShellGunCompanion;

	public static LeadOfLifeCompanionStats CaseyCompanion;

	public static LeadOfLifeCompanionStats BTCKTPCompanion;

	public static LeadOfLifeCompanionStats OneShotCompanion;

	public static LeadOfLifeCompanionStats FiftyCalRoundsCompanion;

	public static LeadOfLifeCompanionStats AlkaliBulletsCompanion;

	public static LeadOfLifeCompanionStats AntimagicRoundsCompanion;

	public static LeadOfLifeCompanionStats AntimatterBulletsCompanion;

	public static LeadOfLifeCompanionStats BashfulShotCompanion;

	public static LeadOfLifeCompanionStats BashingBulletsCompanion;

	public static LeadOfLifeCompanionStats BirdshotCompanion;

	public static LeadOfLifeCompanionStats BlightShellCompanion;

	public static LeadOfLifeCompanionStats BloodthirstyBulletsCompanion;

	public static LeadOfLifeCompanionStats TitanBulletsCompanion;

	public static int LeadOfLifeID;

	public static Hook activeItemDropHook;

	private int lastItems;

	public float globalCompanionFirerateMultiplier = 1f;

	public List<LeadOfLifeCompanion> extantCompanions = new List<LeadOfLifeCompanion>();

	public static void Init()
	{
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		HotLeadCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_hotlead"
		};
		IrradiatedLeadCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_irradiatedlead"
		};
		BatteryBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_batterybullets"
		};
		PlusOneBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_plusonebullets"
		};
		AngryBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_angrybullets"
		};
		CursedBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_cursedbullets"
		};
		EasyReloadBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_easyreloadbullets"
		};
		GhostBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_ghostbullets"
		};
		FlakBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_flakbullets"
		};
		HeavyBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_heavybullets"
		};
		KatanaBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_katanabullets"
		};
		RemoteBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_remotebullets"
		};
		BouncyBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bouncybullets"
		};
		SilverBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_silverbullets"
		};
		ZombieBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_zombiebullets"
		};
		Bloody9mmCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bloody9mm"
		};
		BumbulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bumbullets"
		};
		ChanceBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_chancebullets"
		};
		CharmingRoundsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_charmingrounds"
		};
		DevolverRoundsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_devolverrounds"
		};
		GildedBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_gildedbullets"
		};
		HelixBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_helixbullets"
		};
		HomingBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_homingbullets"
		};
		MagicBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_magicbullets"
		};
		RocketPoweredBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_rocketpoweredbullets"
		};
		ScattershotCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_scattershot"
		};
		ShadowBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_shadowbullets"
		};
		StoutBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_stoutbullets"
		};
		AlphaBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_alphabullets"
		};
		OmegaBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_omegabullets"
		};
		ChaosBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_chaosbullets"
		};
		ExplosiveRoundsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_explosiverounds"
		};
		FatBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_fatbullets"
		};
		FrostBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_frostbullets"
		};
		HungryBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_hungrybullets"
		};
		OrbitalBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_orbitalbullets"
		};
		ShockRoundsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_shockrounds"
		};
		SnowballetsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_snowballets"
		};
		VorpalBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_vorpalbullets"
		};
		BlankBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_blankbullets"
		};
		PlatinumBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_platinumbullets"
		};
		LichsEyeBulletsCompanionA = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_lichseyebullets_a"
		};
		LichsEyeBulletsCompanionB = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_lichseyebullets_b"
		};
		BulletTimeCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bullettime"
		};
		DarumaCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_daruma"
		};
		RiddleOfLeadCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_riddleoflead"
		};
		ShotgunCoffeeCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_shotguncoffee"
		};
		ShotgaColaCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_shotgacola"
		};
		ElderBlankCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_elderblank"
		};
		BulletGunCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bulletgun"
		};
		ShellGunCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_shellgun"
		};
		CaseyCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_casey"
		};
		BTCKTPCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_btcktp"
		};
		OneShotCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_oneshot"
		};
		FiftyCalRoundsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_fiftycalrounds"
		};
		AlkaliBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_alkalibullets"
		};
		AntimagicRoundsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_antimagicrounds"
		};
		AntimatterBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_antimatterbullets"
		};
		BashfulShotCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bashfulshot"
		};
		BashingBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bashingbullets"
		};
		BirdshotCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_birdshot"
		};
		BlightShellCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_blightshell"
		};
		BloodthirstyBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_bloodthirstybullets"
		};
		TitanBulletsCompanion = new LeadOfLifeCompanionStats
		{
			guid = "leadoflife_titanbullets"
		};
		PickupObject obj = ItemSetup.NewItem<LeadOfLife>("Lead of Life", "Forged Friends", "Brings bullet upgrades to life!\n\nA tiny fragment of lead left over from the creation of the very first Bullet Kin.\n\nIt still glows with lifegiving power...", "leadoflife_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)5;
		LeadOfLifeID = ((PickupObject)val).PickupObjectId;
		activeItemDropHook = new Hook((MethodBase)typeof(PlayerController).GetMethod("DropActiveItem"), typeof(LeadOfLife).GetMethod("DropActiveHook"));
		CompanionItemDictionary = new Dictionary<int, List<string>>();
	}

	public static DebrisObject DropActiveHook(Func<PlayerController, PlayerItem, float, bool, DebrisObject> orig, PlayerController self, PlayerItem item, float force = 4f, bool deathdrop = false)
	{
		try
		{
			if (Object.op_Implicit((Object)(object)self))
			{
				foreach (PassiveItem passiveItem in self.passiveItems)
				{
					if ((Object)(object)((Component)passiveItem).GetComponent<LeadOfLife>() != (Object)null)
					{
						((Component)passiveItem).GetComponent<LeadOfLife>().RecalculateCompanions(late: true);
					}
				}
			}
			return orig(self, item, force, deathdrop);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
			return null;
		}
	}

	public void RecalculateCompanions(bool late = false)
	{
		if (late)
		{
			((MonoBehaviour)this).StartCoroutine(LateRecalculation());
			return;
		}
		DestroyAllCompanions();
		foreach (PassiveItem passiveItem in ((PassiveItem)this).Owner.passiveItems)
		{
			TrySpawnCompanionForID(((PickupObject)passiveItem).PickupObjectId, (PickupObject)(object)passiveItem);
		}
		foreach (PlayerItem activeItem in ((PassiveItem)this).Owner.activeItems)
		{
			TrySpawnCompanionForID(((PickupObject)activeItem).PickupObjectId, (PickupObject)(object)activeItem);
		}
		foreach (Gun allGun in ((PassiveItem)this).Owner.inventory.AllGuns)
		{
			TrySpawnCompanionForID(((PickupObject)allGun).PickupObjectId, (PickupObject)(object)allGun);
		}
	}

	private IEnumerator LateRecalculation()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CLateRecalculation_003Ed__70(0)
		{
			_003C_003E4__this = this
		};
	}

	public void TrySpawnCompanionForID(int id, PickupObject correspondingItem = null)
	{
		if (!CompanionItemDictionary.ContainsKey(id))
		{
			return;
		}
		foreach (string item in CompanionItemDictionary[id])
		{
			SpawnNewCompanion(item, correspondingItem);
		}
	}

	private void SpawnNewCompanion(string guid, PickupObject correspondingItem = null)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = Object.Instantiate<GameObject>(((Component)EnemyDatabase.GetOrLoadByGuid(guid)).gameObject, ((BraveBehaviour)((PassiveItem)this).Owner).transform.position, Quaternion.identity);
		LeadOfLifeCompanion orAddComponent = GameObjectExtensions.GetOrAddComponent<LeadOfLifeCompanion>(val);
		extantCompanions.Add(orAddComponent);
		((CompanionController)orAddComponent).Initialize(((PassiveItem)this).Owner);
		globalCompanionFirerateMultiplier *= orAddComponent.globalCompanionFirerateMultiplier;
		if ((Object)(object)correspondingItem != (Object)null)
		{
			orAddComponent.correspondingItem = correspondingItem;
		}
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)orAddComponent).specRigidbody))
		{
			PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(((BraveBehaviour)orAddComponent).specRigidbody, (int?)null, false);
		}
	}

	private void DestroyAllCompanions()
	{
		globalCompanionFirerateMultiplier = 1f;
		if (extantCompanions.Count <= 0)
		{
			return;
		}
		for (int num = extantCompanions.Count - 1; num >= 0; num--)
		{
			if (Object.op_Implicit((Object)(object)extantCompanions[num]) && Object.op_Implicit((Object)(object)((Component)extantCompanions[num]).gameObject))
			{
				Object.Destroy((Object)(object)((Component)extantCompanions[num]).gameObject);
			}
		}
		extantCompanions.Clear();
	}

	public override void Update()
	{
		if (!Dungeon.IsGenerating && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			int num = ((PassiveItem)this).Owner.passiveItems.Count + ((PassiveItem)this).Owner.activeItems.Count + ((PassiveItem)this).Owner.inventory.AllGuns.Count;
			if (num != lastItems)
			{
				RecalculateCompanions();
				lastItems = num;
			}
		}
		((PassiveItem)this).Update();
	}

	private void OnNewFloor(PlayerController player)
	{
		RecalculateCompanions();
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		RecalculateCompanions();
		player.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Combine(player.OnNewFloorLoaded, new Action<PlayerController>(OnNewFloor));
	}

	public override void DisableEffect(PlayerController player)
	{
		DestroyAllCompanions();
		if (Object.op_Implicit((Object)(object)player))
		{
			player.OnNewFloorLoaded = (Action<PlayerController>)Delegate.Remove(player.OnNewFloorLoaded, new Action<PlayerController>(OnNewFloor));
		}
		((PassiveItem)this).DisableEffect(player);
	}
}
