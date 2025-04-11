using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class Confusion
{
	public static GameObject ConfusionDecoyTarget;

	public static void Init()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		ConfusionDecoyTarget = new GameObject();
		SpeculativeRigidbody orAddComponent = GameObjectExtensions.GetOrAddComponent<SpeculativeRigidbody>(ConfusionDecoyTarget);
		PixelCollider val = new PixelCollider();
		val.ColliderGenerationMode = (PixelColliderGeneration)0;
		val.CollisionLayer = (CollisionLayer)3;
		val.ManualWidth = 5;
		val.ManualHeight = 5;
		val.ManualOffsetX = 0;
		val.ManualOffsetY = 0;
		orAddComponent.PixelColliders = new List<PixelCollider> { val };
		ConfusionDecoyTarget.AddComponent<ConfusionDecoyTargetController>();
		FakePrefabExtensions.MakeFakePrefab(ConfusionDecoyTarget);
		StaticStatusEffects.ConfusionEffect = StatusEffectHelper.GenerateConfusionEfffect(5f);
	}
}
