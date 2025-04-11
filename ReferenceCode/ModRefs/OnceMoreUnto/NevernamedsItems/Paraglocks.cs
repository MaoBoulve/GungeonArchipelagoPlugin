using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Dungeonator;
using Gungeon;
using SaveAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Paraglocks : AdvancedGunBehavior
{
	private bool currentFormBuffedBySynergy = false;

	private static Shader paradoxShader;

	public List<int> idsBuffedByAssociatedDissasociationsSynergy = new List<int>();

	private bool isTransformed = false;

	private float timeSinceLastTransform = 0f;

	private List<int> starterGunIDs = new List<int>
	{
		417, 604, 24, 89, 86, 99, 80, 88, 603, 809,
		810, 811, 812, 813, 652, 651
	};

	public static int ParaglocksID;

	public static void Add()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		Gun val = Databases.Items.NewGun("Paraglocks", "paraglocks");
		Game.Items.Rename("outdated_gun_mods:paraglocks", "nn:paraglocks");
		((Component)val).gameObject.AddComponent<Paraglocks>();
		GunExt.SetShortDescription((PickupObject)(object)val, "Corrupts Absolutely");
		GunExt.SetLongDescription((PickupObject)(object)val, "The Rusty Sidearm was brou-to the Gungeon by an infamous fug-a low-ranking Primerdyne soldier-It's never let him down.\n\nJust because children are young, doesn't mea-ssault robot that fled to the Gunge-legendary gunplay expert.\n\nBetrayer!");
		val.SetGunSprites("paraglocks");
		GunExt.SetAnimationFPS(val, val.shootAnimation, 14);
		PickupObject byId = PickupObjectDatabase.GetById(38);
		GunExt.AddProjectileModuleFrom(val, (Gun)(object)((byId is Gun) ? byId : null), true, false);
		val.DefaultModule.ammoCost = 1;
		val.DefaultModule.shootStyle = (ShootStyle)0;
		val.DefaultModule.sequenceStyle = (ProjectileSequenceStyle)0;
		val.reloadTime = 1f;
		val.gunHandedness = (GunHandedness)2;
		val.DefaultModule.cooldownTime = 0.15f;
		val.DefaultModule.angleVariance = 7f;
		val.muzzleFlashEffects.type = (VFXPoolType)0;
		val.DefaultModule.numberOfShotsInClip = 6;
		((Component)val.barrelOffset).transform.localPosition = new Vector3(1f, 1f, 0f);
		val.SetBaseMaxAmmo(300);
		val.ammo = 300;
		val.gunClass = (GunClass)50;
		((PickupObject)val).quality = (ItemQuality)1;
		Databases.Items.Add(val, (tk2dSpriteCollectionData)null, "ANY");
		ParaglocksID = ((PickupObject)val).PickupObjectId;
		paradoxShader = ShaderCache.Acquire("Brave/PlayerShaderEevee");
		((PickupObject)(object)val).SetupUnlockOnCustomFlag(CustomDungeonFlags.BOSSRUSH_PARADOX, requiredFlagValue: true);
	}

	protected override void Update()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		if (!Dungeon.IsGenerating && !Dungeon.ShouldAttemptToLoadFromMidgameSave)
		{
			if (Object.op_Implicit((Object)(object)base.gun) && Object.op_Implicit((Object)(object)base.gun.CurrentOwner))
			{
				if (timeSinceLastTransform <= 0f)
				{
					currentFormBuffedBySynergy = false;
					int num = BraveUtility.RandomElement<int>(starterGunIDs);
					timeSinceLastTransform = Random.Range(1f, 20f);
					_003F val = base.gun;
					PickupObject byId = PickupObjectDatabase.GetById(num);
					((Gun)val).TransformToTargetGun((Gun)(object)((byId is Gun) ? byId : null));
					ProcessGunShader();
					base.gun.gunHandedness = (GunHandedness)2;
					if (idsBuffedByAssociatedDissasociationsSynergy.Contains(num))
					{
						currentFormBuffedBySynergy = true;
					}
					isTransformed = true;
				}
				else
				{
					timeSinceLastTransform -= BraveTime.DeltaTime;
				}
			}
			else if (Object.op_Implicit((Object)(object)base.gun) && isTransformed)
			{
				isTransformed = false;
				_003F val2 = base.gun;
				PickupObject byId2 = PickupObjectDatabase.GetById(ParaglocksID);
				((Gun)val2).TransformToTargetGun((Gun)(object)((byId2 is Gun) ? byId2 : null));
				RemoveGunShader();
			}
		}
		((AdvancedGunBehavior)this).Update();
	}

	private void ProcessGunShader()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		MeshRenderer component = ((Component)base.gun).GetComponent<MeshRenderer>();
		if (!Object.op_Implicit((Object)(object)component))
		{
			return;
		}
		Material[] array = ((Renderer)component).sharedMaterials;
		for (int i = 0; i < array.Length; i++)
		{
			if ((Object)(object)array[i].shader == (Object)(object)ShaderCache.Acquire("Brave/PlayerShaderEevee"))
			{
				return;
			}
		}
		Array.Resize(ref array, array.Length + 1);
		Material val = new Material(paradoxShader);
		val.SetTexture("_EeveeTex", (Texture)(object)ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset<Texture2D>("nebula_reducednoise"));
		val.SetTexture("_MainTex", array[0].GetTexture("_MainTex"));
		array[array.Length - 1] = val;
		((Renderer)component).sharedMaterials = array;
	}

	private void RemoveGunShader()
	{
		if (!Object.op_Implicit((Object)(object)base.gun))
		{
			return;
		}
		MeshRenderer component = ((Component)base.gun).GetComponent<MeshRenderer>();
		if (!Object.op_Implicit((Object)(object)component))
		{
			return;
		}
		Material[] sharedMaterials = ((Renderer)component).sharedMaterials;
		List<Material> list = new List<Material>();
		for (int i = 0; i < sharedMaterials.Length; i++)
		{
			if ((Object)(object)sharedMaterials[i].shader != (Object)(object)paradoxShader)
			{
				list.Add(sharedMaterials[i]);
			}
		}
		((Renderer)component).sharedMaterials = list.ToArray();
	}

	protected override void OnPickedUpByPlayer(PlayerController player)
	{
		isTransformed = false;
		timeSinceLastTransform = 0f;
		((AdvancedGunBehavior)this).OnPickedUpByPlayer(player);
	}

	public override void PostProcessProjectile(Projectile projectile)
	{
		ProjectileData baseData = projectile.baseData;
		baseData.damage *= 1.3f;
		if (currentFormBuffedBySynergy)
		{
			ProjectileData baseData2 = projectile.baseData;
			baseData2.damage *= 2f;
		}
		((AdvancedGunBehavior)this).PostProcessProjectile(projectile);
	}
}
