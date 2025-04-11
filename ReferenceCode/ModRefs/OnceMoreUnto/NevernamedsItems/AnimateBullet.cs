using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public static class AnimateBullet
{
	public static List<T> ConstructListOfSameValues<T>(T value, int length)
	{
		List<T> list = new List<T>();
		for (int i = 0; i < length; i++)
		{
			list.Add(value);
		}
		return list;
	}

	public static void AnimateProjectile(this Projectile proj, List<string> names, int fps, WrapMode wrapmode, List<IntVector2> pixelSizes, List<bool> lighteneds, List<Anchor> anchors, List<bool> anchorsChangeColliders, List<bool> fixesScales, List<Vector3?> manualOffsets, List<IntVector2?> overrideColliderPixelSizes, List<IntVector2?> overrideColliderOffsets, List<Projectile> overrideProjectilesToCopyFrom, int framesToLoopAfter)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		tk2dSpriteAnimationClip val = new tk2dSpriteAnimationClip();
		val.name = "idle";
		val.fps = fps;
		List<tk2dSpriteAnimationFrame> list = new List<tk2dSpriteAnimationFrame>();
		for (int i = 0; i < names.Count; i++)
		{
			string text = names[i];
			IntVector2 val2 = pixelSizes[i];
			IntVector2? val3 = overrideColliderPixelSizes[i];
			IntVector2? val4 = overrideColliderOffsets[i];
			Vector3? val5 = manualOffsets[i];
			bool flag = anchorsChangeColliders[i];
			bool flag2 = fixesScales[i];
			if (!val5.HasValue)
			{
				val5 = Vector2.op_Implicit(Vector2.zero);
			}
			Anchor val6 = anchors[i];
			bool flag3 = lighteneds[i];
			Projectile val7 = overrideProjectilesToCopyFrom[i];
			tk2dSpriteAnimationFrame val8 = new tk2dSpriteAnimationFrame();
			val8.spriteId = Databases.Items.ProjectileCollection.inst.GetSpriteIdByName(text);
			val8.spriteCollection = Databases.Items.ProjectileCollection;
			list.Add(val8);
			int? num = null;
			int? num2 = null;
			if (val3.HasValue)
			{
				num = val3.Value.x;
				num2 = val3.Value.y;
			}
			int? num3 = null;
			int? num4 = null;
			if (val4.HasValue)
			{
				num3 = val4.Value.x;
				num4 = val4.Value.y;
			}
			tk2dSpriteDefinition val9 = GunTools.SetupDefinitionForProjectileSprite(text, val8.spriteId, val2.x, val2.y, flag3, num, num2, num3, num4, val7);
			GunTools.ConstructOffsetsFromAnchor(val9, val6, (Vector2?)Vector2.op_Implicit(val9.position3), flag2, flag);
			val9.position0 += val5.Value;
			val9.position1 += val5.Value;
			val9.position2 += val5.Value;
			val9.position3 += val5.Value;
			if (i == 0)
			{
				ETGMod.GetAnySprite((BraveBehaviour)(object)proj).SetSprite(val8.spriteCollection, val8.spriteId);
			}
		}
		val.wrapMode = wrapmode;
		if ((int)wrapmode == 1)
		{
			val.loopStart = framesToLoopAfter;
		}
		val.frames = list.ToArray();
		if ((Object)(object)((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator == (Object)null)
		{
			((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator = ((Component)((BraveBehaviour)proj).sprite).gameObject.AddComponent<tk2dSpriteAnimator>();
		}
		((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.playAutomatically = true;
		if ((Object)(object)((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.Library == (Object)null)
		{
			((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.Library = ((Component)((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator).gameObject.AddComponent<tk2dSpriteAnimation>();
			((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.Library.clips = (tk2dSpriteAnimationClip[])(object)new tk2dSpriteAnimationClip[0];
			((Behaviour)((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.Library).enabled = true;
		}
		((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.Library.clips = ((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.Library.clips.Concat((IEnumerable<tk2dSpriteAnimationClip>)(object)new tk2dSpriteAnimationClip[1] { val }).ToArray();
		((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.DefaultClipId = ((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.Library.GetClipIdByName("idle");
		((BraveBehaviour)((BraveBehaviour)proj).sprite).spriteAnimator.deferNextStartClip = false;
	}
}
