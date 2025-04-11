using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public static class AnimationUtilityExtensions
{
	public class DirectionalAnimationData
	{
		public string subAnimationName;

		public WrapMode wrapMode = (WrapMode)0;

		public int fps;

		public string pathDirectory;
	}

	public static void PlayUntilFinished(this tk2dSpriteAnimator animator, string clipName, string revertClip)
	{
		tk2dSpriteAnimationClip clipByName = animator.GetClipByName(clipName);
		if (clipByName == null)
		{
			Debug.LogError((object)("Selected clip '" + clipName + "' does not exist."));
			return;
		}
		if (clipByName.frames.Length == 0)
		{
			Debug.LogError((object)("Selected clip '" + clipName + "' has no frames."));
			return;
		}
		if (clipByName.fps <= 0f)
		{
			Debug.LogError((object)("Selected clip '" + clipName + "' has a framerate of 0 or lower, and as such cannot be played until finished."));
			return;
		}
		float num = (float)clipByName.frames.Length / clipByName.fps;
		ETGModConsole.Log((object)num.ToString(), false);
		animator.PlayForDuration(clipName, num, revertClip, false);
	}

	public static void AddAnimationToObject(this GameObject target, tk2dSpriteCollectionData spriteCollection, string animationName, List<string> spritePaths, int fps, Vector2 colliderDimensions, Vector2 colliderOffsets, Anchor anchor, WrapMode wrapMode, bool isDefaultAnimation = false)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(target);
		tk2dSpriteAnimation orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimation>(target);
		orAddComponent2.clips = (tk2dSpriteAnimationClip[])(object)new tk2dSpriteAnimationClip[0];
		orAddComponent.Library = orAddComponent2;
		tk2dSpriteAnimationClip val = new tk2dSpriteAnimationClip();
		val.name = animationName;
		val.frames = (tk2dSpriteAnimationFrame[])(object)new tk2dSpriteAnimationFrame[0];
		val.fps = fps;
		tk2dSpriteAnimationClip val2 = val;
		List<tk2dSpriteAnimationFrame> list = new List<tk2dSpriteAnimationFrame>();
		foreach (string spritePath in spritePaths)
		{
			int num = SpriteBuilder.AddSpriteToCollection(spritePath, spriteCollection, (Assembly)null);
			tk2dSpriteDefinition val3 = spriteCollection.spriteDefinitions[num];
			val3.colliderVertices = (Vector3[])(object)new Vector3[2]
			{
				new Vector3(colliderOffsets.x / 16f, colliderOffsets.y / 16f, 0f),
				new Vector3(colliderDimensions.x / 16f, colliderDimensions.y / 16f, 0f)
			};
			GunTools.ConstructOffsetsFromAnchor(val3, anchor, (Vector2?)null, false, true);
			list.Add(new tk2dSpriteAnimationFrame
			{
				spriteId = num,
				spriteCollection = spriteCollection
			});
		}
		val2.frames = list.ToArray();
		val2.wrapMode = wrapMode;
		orAddComponent2.clips = orAddComponent2.clips.Concat((IEnumerable<tk2dSpriteAnimationClip>)(object)new tk2dSpriteAnimationClip[1] { val2 }).ToArray();
		if (isDefaultAnimation)
		{
			orAddComponent.DefaultClipId = orAddComponent2.GetClipIdByName(animationName);
			orAddComponent.playAutomatically = true;
		}
	}

	public static void AddAnimationToObjectAssetBundle(this GameObject target, tk2dSpriteCollectionData spriteCollection, string animationName, List<string> sprites, int fps, Vector2 colliderDimensions, Vector2 colliderOffsets, Anchor anchor, WrapMode wrapMode, bool isDefaultAnimation = false)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(target);
		tk2dSpriteAnimation orAddComponent2 = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimation>(target);
		orAddComponent2.clips = (tk2dSpriteAnimationClip[])(object)new tk2dSpriteAnimationClip[0];
		orAddComponent.Library = orAddComponent2;
		tk2dSpriteAnimationClip val = new tk2dSpriteAnimationClip();
		val.name = animationName;
		val.frames = (tk2dSpriteAnimationFrame[])(object)new tk2dSpriteAnimationFrame[0];
		val.fps = fps;
		tk2dSpriteAnimationClip val2 = val;
		List<tk2dSpriteAnimationFrame> list = new List<tk2dSpriteAnimationFrame>();
		foreach (string sprite in sprites)
		{
			int spriteIdByName = spriteCollection.GetSpriteIdByName(sprite);
			tk2dSpriteDefinition val3 = spriteCollection.spriteDefinitions[spriteIdByName];
			val3.colliderVertices = (Vector3[])(object)new Vector3[2]
			{
				new Vector3(colliderOffsets.x / 16f, colliderOffsets.y / 16f, 0f),
				new Vector3(colliderDimensions.x / 16f, colliderDimensions.y / 16f, 0f)
			};
			GunTools.ConstructOffsetsFromAnchor(val3, anchor, (Vector2?)null, false, true);
			list.Add(new tk2dSpriteAnimationFrame
			{
				spriteId = spriteIdByName,
				spriteCollection = spriteCollection
			});
		}
		val2.frames = list.ToArray();
		val2.wrapMode = wrapMode;
		orAddComponent2.clips = orAddComponent2.clips.Concat((IEnumerable<tk2dSpriteAnimationClip>)(object)new tk2dSpriteAnimationClip[1] { val2 }).ToArray();
		if (isDefaultAnimation)
		{
			orAddComponent.DefaultClipId = orAddComponent2.GetClipIdByName(animationName);
			orAddComponent.playAutomatically = true;
		}
	}

	public static void AdvAddAnimation(this AIAnimator targetAnimator, string animationName, DirectionType directionality, AnimationType AnimationType, List<DirectionalAnimationData> AnimData)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Invalid comparison between Unknown and I4
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected I4, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		foreach (DirectionalAnimationData AnimDatum in AnimData)
		{
			list.Add(AnimDatum.subAnimationName);
			tk2dSpriteCollectionData val = ((Component)targetAnimator).GetComponent<tk2dSpriteCollectionData>();
			if (!Object.op_Implicit((Object)(object)val))
			{
				val = SpriteBuilder.ConstructCollection(((Component)targetAnimator).gameObject, ((Object)targetAnimator).name + "_collection", false);
			}
			string[] resourceNames = ResourceExtractor.GetResourceNames((Assembly)null);
			List<int> list2 = new List<int>();
			for (int i = 0; i < resourceNames.Length; i++)
			{
				if (resourceNames[i].StartsWith(AnimDatum.pathDirectory.Replace('/', '.'), StringComparison.OrdinalIgnoreCase))
				{
					list2.Add(SpriteBuilder.AddSpriteToCollection(resourceNames[i], val, (Assembly)null));
				}
			}
			tk2dSpriteAnimationClip val2 = SpriteBuilder.AddAnimation(((BraveBehaviour)targetAnimator).spriteAnimator, val, list2, AnimDatum.subAnimationName, AnimDatum.wrapMode, 15f);
			val2.fps = AnimDatum.fps;
		}
		if ((int)AnimationType != 6)
		{
			DirectionalAnimation val3 = new DirectionalAnimation();
			val3.Type = directionality;
			val3.Flipped = (FlipType[])(object)new FlipType[list.Count];
			val3.AnimNames = list.ToArray();
			val3.Prefix = string.Empty;
			DirectionalAnimation val4 = val3;
			switch ((int)AnimationType)
			{
			case 1:
				targetAnimator.IdleAnimation = val4;
				break;
			case 0:
				targetAnimator.MoveAnimation = val4;
				break;
			case 4:
				targetAnimator.HitAnimation = val4;
				break;
			case 5:
				targetAnimator.TalkAnimation = val4;
				break;
			case 3:
				targetAnimator.FlightAnimation = val4;
				break;
			case 2:
				if (targetAnimator.IdleFidgetAnimations == null)
				{
					targetAnimator.IdleFidgetAnimations = new List<DirectionalAnimation>();
				}
				targetAnimator.IdleFidgetAnimations.Add(val4);
				break;
			}
		}
		else
		{
			NamedDirectionalAnimation val5 = new NamedDirectionalAnimation();
			val5.name = animationName;
			DirectionalAnimation val3 = new DirectionalAnimation();
			val3.Prefix = animationName;
			val3.Type = directionality;
			val3.Flipped = (FlipType[])(object)new FlipType[list.Count];
			val3.AnimNames = list.ToArray();
			val5.anim = val3;
			NamedDirectionalAnimation item = val5;
			if (targetAnimator.OtherAnimations == null)
			{
				targetAnimator.OtherAnimations = new List<NamedDirectionalAnimation>();
			}
			targetAnimator.OtherAnimations.Add(item);
		}
	}
}
