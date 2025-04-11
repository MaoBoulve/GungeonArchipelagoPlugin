using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Alexandria.SoundAPI;
using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

public static class MiscTools
{
	public static List<string> addedAmmos = new List<string>();

	public static List<T> DupeList<T>(T value, int length)
	{
		List<T> list = new List<T>();
		for (int i = 0; i < length; i++)
		{
			list.Add(value);
		}
		return list;
	}

	public static void AddShellCasing(this Gun gun, int numToLaunchOnFire = 1, int fireFrameToLaunch = 0, int numToLaunchOnReload = 0, int reloadFrameToLaunch = 0, string shellSpriteName = null, string audioEvent = "Play_WPN_magnum_shells_01")
	{
		if (!string.IsNullOrEmpty(shellSpriteName))
		{
			DebrisObject val = Breakables.GenerateDebrisObject(Initialisation.GunDressingCollection, shellSpriteName, debrisObjectsCanRotate: true, 1f, 5f, 900f, 180f);
			val.audioEventName = audioEvent;
			gun.shellCasing = ((Component)val).gameObject;
		}
		else
		{
			ref GameObject shellCasing = ref gun.shellCasing;
			PickupObject byId = PickupObjectDatabase.GetById(15);
			shellCasing = ((Gun)((byId is Gun) ? byId : null)).shellCasing;
		}
		gun.shellCasingOnFireFrameDelay = fireFrameToLaunch;
		gun.reloadShellLaunchFrame = reloadFrameToLaunch;
		gun.shellsToLaunchOnFire = numToLaunchOnFire;
		gun.shellsToLaunchOnReload = numToLaunchOnReload;
	}

	public static void AddClipSprites(this Gun gun, string name, string fullNameOverride = null, string emptyNameOverride = null)
	{
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		if (!addedAmmos.Contains(name))
		{
			Texture2D val = Initialisation.assetBundle.LoadAsset<Texture2D>((!string.IsNullOrEmpty(fullNameOverride)) ? fullNameOverride : (name + "_clipfull"));
			Texture2D val2 = Initialisation.assetBundle.LoadAsset<Texture2D>((!string.IsNullOrEmpty(emptyNameOverride)) ? emptyNameOverride : (name + "_clipempty"));
			GameObject val3 = new GameObject("sprite fg");
			FakePrefabExtensions.MakeFakePrefab(val3);
			GameObject val4 = new GameObject("sprite bg");
			FakePrefabExtensions.MakeFakePrefab(val4);
			dfTiledSprite ammoBarFG = CustomClipAmmoTypeToolbox.SetupDfSpriteFromTexture<dfTiledSprite>(val3, val, ShaderCache.Acquire("Daikon Forge/Default UI Shader"));
			dfTiledSprite ammoBarBG = CustomClipAmmoTypeToolbox.SetupDfSpriteFromTexture<dfTiledSprite>(val4, val2, ShaderCache.Acquire("Daikon Forge/Default UI Shader"));
			GameUIAmmoType val5 = new GameUIAmmoType
			{
				ammoBarBG = ammoBarBG,
				ammoBarFG = ammoBarFG,
				ammoType = (AmmoType)14,
				customAmmoType = name
			};
			CustomClipAmmoTypeToolbox.addedAmmoTypes.Add(val5);
			foreach (GameUIAmmoController ammoController in GameUIRoot.Instance.ammoControllers)
			{
				Add(ref ammoController.ammoTypes, val5);
			}
			addedAmmos.Add(name);
		}
		gun.DefaultModule.ammoType = (AmmoType)14;
		gun.DefaultModule.customAmmoType = name;
	}

	public static void AddCustomSwitchGroup(this Gun gun, string name, string fire, string reload)
	{
		gun.gunSwitchGroup = name;
		SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Reload_01", (SwitchedEvent[])(object)new SwitchedEvent[1] { SwitchedEvent.op_Implicit(reload) });
		SoundManager.AddCustomSwitchData("WPN_Guns", gun.gunSwitchGroup, "Play_WPN_Gun_Shot_01", (SwitchedEvent[])(object)new SwitchedEvent[1] { SwitchedEvent.op_Implicit(fire) });
	}

	public static void Add<T>(ref T[] array, T toAdd)
	{
		List<T> list = array.ToList();
		list.Add(toAdd);
		array = Enumerable.ToArray(list);
	}

	public static void SetBarrel(this Gun gun, int xoffset, int yoffset)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		((Component)gun.barrelOffset).transform.localScale = Vector3.one;
		((Component)gun.barrelOffset).transform.localPosition = new Vector3((float)xoffset / 16f, (float)yoffset / 16f, 0f);
	}

	public static void AddClipDebris(this Gun gun, int frameToLaunch, int numToLaunch, string clipSpriteName = null)
	{
		if (!string.IsNullOrEmpty(clipSpriteName))
		{
			gun.clipObject = ((Component)Breakables.GenerateDebrisObject(Initialisation.GunDressingCollection, clipSpriteName, debrisObjectsCanRotate: true, 1f, 5f, 60f, 20f)).gameObject;
		}
		else
		{
			ref GameObject clipObject = ref gun.clipObject;
			PickupObject byId = PickupObjectDatabase.GetById(15);
			clipObject = ((Gun)((byId is Gun) ? byId : null)).clipObject;
		}
		gun.reloadClipLaunchFrame = frameToLaunch;
		gun.clipsToLaunchOnReload = numToLaunch;
	}

	public static string FlipAnimation(this tk2dSpriteAnimator anim, string origAnimation, string newAnimation)
	{
		if ((Object)(object)anim == (Object)null || (Object)(object)anim.Library == (Object)null)
		{
			return "";
		}
		return anim.Library.FlipAnimation(origAnimation, newAnimation);
	}

	public static string FlipAnimation(this tk2dSpriteAnimation anim, string origAnimation, string newAnimation)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00f7: Expected O, but got Unknown
		if ((Object)(object)anim == (Object)null)
		{
			return "";
		}
		tk2dSpriteAnimationClip clipByName = anim.GetClipByName(origAnimation);
		if (clipByName == null)
		{
			return "";
		}
		tk2dSpriteAnimationClip val = new tk2dSpriteAnimationClip
		{
			name = newAnimation,
			fps = clipByName.fps,
			loopStart = clipByName.loopStart,
			wrapMode = clipByName.wrapMode,
			minFidgetDuration = clipByName.minFidgetDuration,
			maxFidgetDuration = clipByName.maxFidgetDuration
		};
		anim.clips = CollectionExtensions.AddToArray<tk2dSpriteAnimationClip>(anim.clips, val);
		if (clipByName.frames == null)
		{
			val.frames = null;
			return val.name;
		}
		val.frames = (tk2dSpriteAnimationFrame[])(object)new tk2dSpriteAnimationFrame[clipByName.frames.Length];
		for (int i = 0; i < clipByName.frames.Length; i++)
		{
			tk2dSpriteAnimationFrame val2 = clipByName.frames[i];
			if (val2 == null)
			{
				continue;
			}
			tk2dSpriteAnimationFrame[] frames = val.frames;
			int num = i;
			tk2dSpriteAnimationFrame val3 = new tk2dSpriteAnimationFrame();
			tk2dSpriteAnimationFrame val4 = val3;
			frames[num] = val3;
			tk2dSpriteAnimationFrame val5 = val4;
			val5.CopyFrom(val2);
			tk2dSpriteDefinition val6 = val2.spriteCollection.spriteDefinitions[val2.spriteId];
			if (val6 != null)
			{
				tk2dSpriteDefinition val7 = val6.FlipSprite();
				if (val7 != null)
				{
					val5.spriteId = SpriteBuilder.AddSpriteToCollection(val7, val2.spriteCollection);
				}
			}
		}
		return val.name;
	}

	private static tk2dSpriteDefinition FlipSprite(this tk2dSpriteDefinition orig)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		if (orig == null || orig.uvs == null || orig.uvs.Length != 4)
		{
			return null;
		}
		tk2dSpriteDefinition val = new tk2dSpriteDefinition();
		val.name = orig.name;
		val.boundsDataCenter = orig.boundsDataCenter;
		val.boundsDataExtents = orig.boundsDataExtents;
		val.untrimmedBoundsDataCenter = orig.untrimmedBoundsDataCenter;
		val.untrimmedBoundsDataExtents = orig.untrimmedBoundsDataExtents;
		val.texelSize = orig.texelSize;
		val.position0 = orig.position0;
		val.position1 = orig.position1;
		val.position2 = orig.position2;
		val.position3 = orig.position3;
		val.uvs = (Vector2[])(object)new Vector2[4]
		{
			orig.uvs[1],
			orig.uvs[0],
			orig.uvs[3],
			orig.uvs[2]
		};
		val.material = orig.material;
		val.materialInst = ((!((Object)(object)orig.materialInst != (Object)null)) ? ((Material)null) : new Material(orig.materialInst));
		val.materialId = orig.materialId;
		val.extractRegion = orig.extractRegion;
		val.regionX = orig.regionX;
		val.regionY = orig.regionY;
		val.regionW = orig.regionW;
		val.regionH = orig.regionH;
		val.flipped = orig.flipped;
		val.complexGeometry = orig.complexGeometry;
		val.physicsEngine = orig.physicsEngine;
		val.colliderType = orig.colliderType;
		val.collisionLayer = orig.collisionLayer;
		val.colliderVertices = orig.colliderVertices.ToArray();
		val.colliderConvex = orig.colliderConvex;
		val.colliderSmoothSphereCollisions = orig.colliderSmoothSphereCollisions;
		return val;
	}
}
