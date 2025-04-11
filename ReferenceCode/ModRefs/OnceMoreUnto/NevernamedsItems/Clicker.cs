using System;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using Dungeonator;
using Gungeon;
using InControl;
using UnityEngine;

namespace NevernamedsItems;

public class Clicker : AdvancedGunBehavior
{
	public static tk2dSpriteCollectionData clickerCollection;

	public static int crosshairSpriteID;

	public static int ID;

	public RoomHandler lastRoom;

	public tk2dBaseSprite m_extantReticleQuad;

	private float m_currentAngle;

	private float m_currentDistance = 5f;

	public static void Add()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Clicker", "clicker");
		Game.Items.Rename("outdated_gun_mods:clicker", "nn:clicker");
		Clicker clicker = ((Component)val).gameObject.AddComponent<Clicker>();
		((AdvancedGunBehavior)clicker).preventNormalFireAudio = true;
		((AdvancedGunBehavior)clicker).overrideNormalFireAudio = "Play_MouseClickNoise";
		GunExt.SetShortDescription((PickupObject)(object)val, "Clacker");
		GunExt.SetLongDescription((PickupObject)(object)val, "A remarkably strange invention, this arrow requires no bow to fire.\n\nCan shred enemies apart as fast as you can click on them!");
		val.SetGunSprites("clicker", 13);
		GunExt.SetAnimationFPS(val, val.shootAnimation, 12);
		PickupObject byId = PickupObjectDatabase.GetById(86);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.reloadTime = 1.1f;
		val.DefaultModule.cooldownTime = 0f;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(0.5f, 0.62f, 0f);
		val.DefaultModule.numberOfShotsInClip = -1;
		val.SetBaseMaxAmmo(1000);
		val.gunClass = (GunClass)50;
		Projectile val2 = Object.Instantiate<Projectile>(val.DefaultModule.projectiles[0]);
		((Component)val2).gameObject.SetActive(false);
		FakePrefab.MarkAsFakePrefab(((Component)val2).gameObject);
		Object.DontDestroyOnLoad((Object)(object)val2);
		val.DefaultModule.projectiles[0] = val2;
		PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)val2).gameObject);
		orAddComponent.penetration = 100;
		orAddComponent.penetratesBreakables = true;
		val2.pierceMinorBreakables = true;
		((BraveBehaviour)val2).specRigidbody.CollideWithTileMap = false;
		val2.baseData.damage = 4f;
		val2.baseData.speed = 0.1f;
		val2.baseData.force = 0f;
		ProjectileData baseData = val2.baseData;
		baseData.range *= 1f;
		val2.SetProjectileSprite("16x16_white_circle", 16, 16, lightened: false, (Anchor)4, 16, 16, anchorChangesCollider: true, fixesScale: false, null, null);
		val.DefaultModule.ammoType = (AmmoType)14;
		val.DefaultModule.customAmmoType = CustomClipAmmoTypeToolbox.AddCustomAmmoType("Clicker Bullets", "NevernamedsItems/Resources/CustomGunAmmoTypes/clicker_clipfull", "NevernamedsItems/Resources/CustomGunAmmoTypes/clicker_clipempty");
		((Component)val2).gameObject.AddComponent<ClickProjMod>();
		((BraveBehaviour)((BraveBehaviour)val2).sprite).renderer.enabled = false;
		((PickupObject)val).quality = (ItemQuality)3;
		Databases.Items.Add((PickupObject)(object)val, false, "ANY");
		ID = ((PickupObject)val).PickupObjectId;
		AlexandriaTags.SetTag((PickupObject)(object)val, "arrow_bolt_weapon");
		clickerCollection = SpriteBuilder.ConstructCollection(((Component)val).gameObject, "Clicker_Collection", false);
		crosshairSpriteID = SpriteBuilder.AddSpriteToCollection("NevernamedsItems/Resources/MiscVFX/clicker_crosshair", clickerCollection, (Assembly)null);
	}

	public static bool isHeld(PlayerController player)
	{
		if ((Object)(object)((GameActor)player).CurrentGun != (Object)null && ((PickupObject)((GameActor)player).CurrentGun).PickupObjectId == ID)
		{
			return true;
		}
		if ((Object)(object)player.CurrentSecondaryGun != (Object)null && ((PickupObject)player.CurrentSecondaryGun).PickupObjectId == ID)
		{
			return true;
		}
		return false;
	}

	public void regenerateExtantCrosshair(PlayerController user)
	{
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			removeManualCrosshair();
			createManualCrosshairForController(user);
		}
		else
		{
			Debug.LogError((object)"Clicker: Attempted to regenerate a crosshair that didn't exist?");
		}
	}

	public void removeManualCrosshair()
	{
		if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			m_currentAngle = 0f;
			m_currentDistance = 0f;
			Object.Destroy((Object)(object)m_extantReticleQuad);
		}
		else
		{
			Debug.LogError((object)"Clicker: Attempted to remove a crosshair that didn't exist?");
		}
	}

	public void createManualCrosshairForController(PlayerController playerOwner)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		if (BraveInput.GetInstanceForPlayer(playerOwner.PlayerIDX).IsKeyboardAndMouse(false))
		{
			Debug.LogError((object)"Clicker: Attempted to create a crosshair for a user playing on keyboard and mouse.");
			return;
		}
		GameObject val = new GameObject("Controller_Crosshair", new Type[1] { typeof(tk2dSprite) })
		{
			layer = 0
		};
		val.transform.position = ((BraveBehaviour)playerOwner).transform.position + new Vector3(0.5f, 2f);
		tk2dSprite val2 = val.AddComponent<tk2dSprite>();
		((tk2dBaseSprite)val2).SetSprite(clickerCollection, crosshairSpriteID);
		((tk2dBaseSprite)val2).PlaceAtPositionByAnchor(val.transform.position, (Anchor)4);
		((BraveBehaviour)val2).transform.localPosition = dfVectorExtensions.Quantize(((BraveBehaviour)val2).transform.localPosition, 0.0625f);
		if (Object.op_Implicit((Object)(object)val2))
		{
			((BraveBehaviour)playerOwner).sprite.AttachRenderer((tk2dBaseSprite)(object)val2);
			((tk2dBaseSprite)val2).depthUsesTrimmedBounds = true;
			((tk2dBaseSprite)val2).UpdateZDepth();
		}
		m_extantReticleQuad = (tk2dBaseSprite)(object)val2;
	}

	protected override void NonCurrentGunUpdate()
	{
		if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)GunTools.GunPlayerOwner(base.gun)))
		{
			if (!Object.op_Implicit((Object)(object)m_extantReticleQuad))
			{
				if (BraveInput.GetInstanceForPlayer(GunTools.GunPlayerOwner(base.gun).PlayerIDX).IsKeyboardAndMouse(false))
				{
					return;
				}
				if (isHeld(GunTools.GunPlayerOwner(base.gun)))
				{
					createManualCrosshairForController(GunTools.GunPlayerOwner(base.gun));
				}
			}
			if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
			{
				if (BraveInput.GetInstanceForPlayer(GunTools.GunPlayerOwner(base.gun).PlayerIDX).IsKeyboardAndMouse(false))
				{
					removeManualCrosshair();
				}
				else if (isHeld(GunTools.GunPlayerOwner(base.gun)))
				{
					if (GunTools.GunPlayerOwner(base.gun).CurrentRoom != lastRoom)
					{
						regenerateExtantCrosshair(GunTools.GunPlayerOwner(base.gun));
						lastRoom = GunTools.GunPlayerOwner(base.gun).CurrentRoom;
						m_currentAngle = 0f;
						m_currentDistance = 0f;
					}
					else
					{
						UpdateReticlePosition();
					}
				}
				else
				{
					removeManualCrosshair();
				}
			}
		}
		else if (Object.op_Implicit((Object)(object)m_extantReticleQuad))
		{
			removeManualCrosshair();
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void UpdateReticlePosition()
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		PlayerController val = GunTools.GunPlayerOwner(base.gun);
		if (!Object.op_Implicit((Object)(object)val))
		{
			return;
		}
		if (BraveInput.GetInstanceForPlayer(val.PlayerIDX).IsKeyboardAndMouse(false))
		{
			Debug.LogError((object)"Clicker: Attempted to update a crosshair for a user playing on keyboard and mouse???");
			return;
		}
		BraveInput instanceForPlayer = BraveInput.GetInstanceForPlayer(val.PlayerIDX);
		AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(Vector2.op_Implicit(((BraveBehaviour)m_extantReticleQuad).transform.position), true, (ActiveEnemyType)0, (List<AIActor>)null, (Func<AIActor, bool>)null);
		Bounds bounds;
		if (Object.op_Implicit((Object)(object)nearestEnemyToPosition) && ((TwoAxisInputControl)instanceForPlayer.ActiveActions.Aim).Vector.x == 0f && ((TwoAxisInputControl)instanceForPlayer.ActiveActions.Aim).Vector.y == 0f && Vector2.Distance(Vector2.op_Implicit(nearestEnemyToPosition.Position), ((GameActor)val).CenterPosition) <= 15f && Vector2.Distance(Vector2.op_Implicit(nearestEnemyToPosition.Position), Vector2.op_Implicit(((BraveBehaviour)m_extantReticleQuad).transform.position)) <= 1f)
		{
			m_currentDistance = Vector2.Distance(Vector2.op_Implicit(nearestEnemyToPosition.Position), ((GameActor)val).CenterPosition);
			m_currentAngle = Vector2Extensions.ToAngle(MathsAndLogicHelper.CalculateVectorBetween(((GameActor)val).CenterPosition, Vector2.op_Implicit(nearestEnemyToPosition.Position)));
			Vector2 val2 = ((GameActor)val).CenterPosition + Vector3Extensions.XY(Quaternion.Euler(0f, 0f, m_currentAngle) * Vector2.op_Implicit(Vector2.right)) * m_currentDistance;
			bounds = m_extantReticleQuad.GetBounds();
			Vector2 val3 = val2 - Vector3Extensions.XY(((Bounds)(ref bounds)).extents);
			((BraveBehaviour)m_extantReticleQuad).transform.position = Vector2.op_Implicit(val3);
		}
		else
		{
			Vector2 val4 = ((GameActor)val).CenterPosition + Vector3Extensions.XY(Quaternion.Euler(0f, 0f, m_currentAngle) * Vector2.op_Implicit(Vector2.right)) * m_currentDistance;
			val4 += ((TwoAxisInputControl)instanceForPlayer.ActiveActions.Aim).Vector * 12f * BraveTime.DeltaTime;
			m_currentAngle = BraveMathCollege.Atan2Degrees(val4 - ((GameActor)val).CenterPosition);
			m_currentDistance = Vector2.Distance(val4, ((GameActor)val).CenterPosition);
			m_currentDistance = Mathf.Min(m_currentDistance, 15f);
			val4 = ((GameActor)val).CenterPosition + Vector3Extensions.XY(Quaternion.Euler(0f, 0f, m_currentAngle) * Vector2.op_Implicit(Vector2.right)) * m_currentDistance;
			Vector2 val5 = val4;
			bounds = m_extantReticleQuad.GetBounds();
			Vector2 val6 = val5 - Vector3Extensions.XY(((Bounds)(ref bounds)).extents);
			((BraveBehaviour)m_extantReticleQuad).transform.position = Vector2.op_Implicit(val6);
		}
	}
}
