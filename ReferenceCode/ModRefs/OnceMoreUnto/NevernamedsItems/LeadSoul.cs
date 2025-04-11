using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class LeadSoul : PassiveItem
{
	public static List<string> OverheadVFXPaths = new List<string>
	{
		"NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_001", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_002", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_003", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_004", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_005", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_006", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_007", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_008", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_009", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_010",
		"NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_011", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_012", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_013", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_014", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_015", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_016", "NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_017"
	};

	public static GameObject VFXPrefab;

	private GameObject extantOverhead;

	public static int LeadSoulID;

	private bool shieldCharged;

	private int enemiesKilledSinceShieldReset;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		PickupObject obj = ItemSetup.NewItem<LeadSoul>("Lead Soul", "No Voice To Cry Suffering", "Grants a regenerating shield.\n\nSteel yourself against the tribulations ahead, for the world is dark and cold...", "leadsoul_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)5;
		LeadSoulID = ((PickupObject)val).PickupObjectId;
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.LICH_BEATEN_SHADE, requiredFlagValue: true);
		GameObject val2 = SpriteBuilder.SpriteFromResource("NevernamedsItems/Resources/MiscVFX/LeadSoulVFX/leadsouloverhead_001", new GameObject("LeadSoulOverhead"), (Assembly)null);
		val2.SetActive(false);
		tk2dBaseSprite orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dBaseSprite>(val2);
		GunTools.ConstructOffsetsFromAnchor(orAddComponent.GetCurrentSpriteDef(), (Anchor)1, (Vector2?)Vector2.op_Implicit(orAddComponent.GetCurrentSpriteDef().position3), false, true);
		FakePrefab.MarkAsFakePrefab(val2);
		Object.DontDestroyOnLoad((Object)(object)val2);
		tk2dSpriteAnimator val3 = val2.AddComponent<tk2dSpriteAnimator>();
		val3.Library = val2.AddComponent<tk2dSpriteAnimation>();
		val3.Library.clips = (tk2dSpriteAnimationClip[])(object)new tk2dSpriteAnimationClip[0];
		tk2dSpriteAnimationClip val4 = new tk2dSpriteAnimationClip();
		val4.name = "LeadSoulOverheadClip";
		val4.fps = 10f;
		val4.frames = (tk2dSpriteAnimationFrame[])(object)new tk2dSpriteAnimationFrame[0];
		tk2dSpriteAnimationClip val5 = val4;
		foreach (string overheadVFXPath in OverheadVFXPaths)
		{
			int num = SpriteBuilder.AddSpriteToCollection(overheadVFXPath, val2.GetComponent<tk2dBaseSprite>().Collection, (Assembly)null);
			GunTools.ConstructOffsetsFromAnchor(val2.GetComponent<tk2dBaseSprite>().Collection.spriteDefinitions[num], (Anchor)1, (Vector2?)null, false, true);
			tk2dSpriteAnimationFrame val6 = new tk2dSpriteAnimationFrame
			{
				spriteId = num,
				spriteCollection = val2.GetComponent<tk2dBaseSprite>().Collection
			};
			val5.frames = val5.frames.Concat((IEnumerable<tk2dSpriteAnimationFrame>)(object)new tk2dSpriteAnimationFrame[1] { val6 }).ToArray();
		}
		val3.Library.clips = val3.Library.clips.Concat((IEnumerable<tk2dSpriteAnimationClip>)(object)new tk2dSpriteAnimationClip[1] { val5 }).ToArray();
		val3.playAutomatically = true;
		val3.DefaultClipId = val3.GetClipIdByName("LeadSoulOverheadClip");
		VFXPrefab = val2;
	}

	public override void Pickup(PlayerController player)
	{
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(EnemyHurt));
		if (!base.m_pickedUpThisRun)
		{
			shieldCharged = true;
		}
		((PassiveItem)this).Pickup(player);
		if (shieldCharged)
		{
			AddOverhead();
		}
	}

	public override DebrisObject Drop(PlayerController player)
	{
		ClearOverhead();
		HealthHaver healthHaver = ((BraveBehaviour)player).healthHaver;
		healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		player.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Remove(player.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(EnemyHurt));
		return ((PassiveItem)this).Drop(player);
	}

	private void EnemyHurt(float dmg, bool fatal, HealthHaver enemy)
	{
		if (fatal)
		{
			enemiesKilledSinceShieldReset++;
		}
	}

	private void ModifyDamage(HealthHaver player, ModifyDamageEventArgs args)
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		if (args.InitialDamage > 0f && shieldCharged)
		{
			shieldCharged = false;
			enemiesKilledSinceShieldReset = 0;
			args.ModifiedDamage = 0f;
			ClearOverhead();
			AkSoundEngine.PostEvent("Play_OBJ_crystal_shatter_01", ((Component)((PassiveItem)this).Owner).gameObject);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "No Will To Break"))
			{
				PlayerUtility.DoEasyBlank(((PassiveItem)this).Owner, ((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, (EasyBlankType)1);
			}
			GameActor gameActor = ((BraveBehaviour)player).gameActor;
			PlayerUtility.GetExtComp((PlayerController)(object)((gameActor is PlayerController) ? gameActor : null)).TriggerInvulnerableFrames(2f, false);
			ScreenShakeSettings val = new ScreenShakeSettings(0.25f, 7f, 0.1f, 0.3f);
			GameManager.Instance.MainCameraController.DoScreenShake(val, (Vector2?)((BraveBehaviour)((PassiveItem)this).Owner).specRigidbody.UnitCenter, false);
		}
	}

	public override void Update()
	{
		if (enemiesKilledSinceShieldReset >= 15 && !shieldCharged)
		{
			shieldCharged = true;
		}
		if (shieldCharged && (Object)(object)extantOverhead == (Object)null)
		{
			AddOverhead();
		}
		else if (!shieldCharged && (Object)(object)extantOverhead != (Object)null)
		{
			ClearOverhead();
		}
		((PassiveItem)this).Update();
	}

	private void AddOverhead()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)VFXPrefab) && Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			AkSoundEngine.PostEvent("Play_OBJ_metalskin_deflect_01", ((Component)((PassiveItem)this).Owner).gameObject);
			GameObject val = Object.Instantiate<GameObject>(VFXPrefab);
			val.transform.parent = ((BraveBehaviour)((PassiveItem)this).Owner).transform;
			val.transform.position = ((BraveBehaviour)((PassiveItem)this).Owner).transform.position + new Vector3(0.7f, 2f);
			extantOverhead = val;
			Object.Instantiate<GameObject>(SharedVFX.ColouredPoofWhite, Vector2.op_Implicit(extantOverhead.GetComponent<tk2dBaseSprite>().WorldCenter), Quaternion.identity);
		}
	}

	private void ClearOverhead()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)extantOverhead))
		{
			Object.Instantiate<GameObject>(SharedVFX.ColouredPoofWhite, Vector2.op_Implicit(extantOverhead.GetComponent<tk2dBaseSprite>().WorldCenter), Quaternion.identity);
			Object.Destroy((Object)(object)extantOverhead);
			extantOverhead = null;
		}
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)extantOverhead))
		{
			ClearOverhead();
		}
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			PlayerController owner = ((PassiveItem)this).Owner;
			owner.OnAnyEnemyReceivedDamage = (Action<float, bool, HealthHaver>)Delegate.Combine(owner.OnAnyEnemyReceivedDamage, new Action<float, bool, HealthHaver>(EnemyHurt));
			HealthHaver healthHaver = ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver;
			healthHaver.ModifyDamage = (Action<HealthHaver, ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, ModifyDamageEventArgs>(ModifyDamage));
		}
		((PassiveItem)this).OnDestroy();
	}
}
