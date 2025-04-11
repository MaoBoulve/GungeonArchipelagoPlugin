using System.Collections.Generic;
using Alexandria.BreakableAPI;
using Alexandria.DungeonAPI;
using Alexandria.ItemAPI;
using Dungeonator;
using UnityEngine;
using UnityEngine.Rendering;

namespace NevernamedsItems;

internal class GoldButton : BasicTrapController
{
	public static void Init()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = ItemBuilder.SpriteFromBundle("goldbutton_idle_001", Initialisation.TrapCollection.GetSpriteIdByName("goldbutton_idle_001"), Initialisation.TrapCollection, new GameObject("Gold Button"));
		FakePrefabExtensions.MakeFakePrefab(val);
		tk2dSprite component = val.GetComponent<tk2dSprite>();
		((tk2dBaseSprite)((Component)component).GetComponent<tk2dSprite>()).HeightOffGround = -5f;
		((tk2dBaseSprite)component).usesOverrideMaterial = true;
		((tk2dBaseSprite)component).SortingOrder = 0;
		((tk2dBaseSprite)component).IsPerpendicular = false;
		((Renderer)val.GetComponent<MeshRenderer>()).lightProbeUsage = (LightProbeUsage)0;
		GameObjectExtensions.SetLayerRecursively(val, LayerMask.NameToLayer("FG_Critical"));
		((Renderer)val.GetComponent<MeshRenderer>()).material.shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTilted");
		GoldButton goldButton = val.AddComponent<GoldButton>();
		((DungeonPlaceableBehaviour)goldButton).isPassable = true;
		((DungeonPlaceableBehaviour)goldButton).placeableHeight = 2;
		((DungeonPlaceableBehaviour)goldButton).placeableWidth = 2;
		((BasicTrapController)goldButton).triggerMethod = (TriggerMethod)1;
		((BasicTrapController)goldButton).resetDelay = float.MaxValue;
		((BasicTrapController)goldButton).triggerDelay = 0f;
		((BasicTrapController)goldButton).triggerAnimName = "goldbutton_press";
		tk2dSpriteAnimator orAddComponent = GameObjectExtensions.GetOrAddComponent<tk2dSpriteAnimator>(val);
		orAddComponent.Library = Initialisation.trapAnimationCollection;
		orAddComponent.defaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("goldbutton_idle");
		orAddComponent.DefaultClipId = Initialisation.trapAnimationCollection.GetClipIdByName("goldbutton_idle");
		orAddComponent.playAutomatically = true;
		DungeonPlaceable val2 = BreakableAPIToolbox.GenerateDungeonPlaceable(new Dictionary<GameObject, float> { { val, 1f } }, 1, 1, (DungeonPrerequisite[])null);
		val2.isPassable = true;
		val2.width = 2;
		val2.height = 2;
		StaticReferences.StoredDungeonPlaceables.Add("goldbutton", val2);
		StaticReferences.customPlaceables.Add("nn:goldbutton", val2);
	}

	public override void TriggerTrap(SpeculativeRigidbody target)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		((BasicTrapController)this).TriggerTrap(target);
		List<AIActor> activeEnemies = base.m_parentRoom.GetActiveEnemies((ActiveEnemyType)0);
		GameManager.Instance.MainCameraController.DoScreenShake(StaticExplosionDatas.genericLargeExplosion.ss, (Vector2?)null, false);
		Pixelator.Instance.FadeToColor(0.1f, Color.white, true, 0.1f);
		Exploder.DoDistortionWave(((BraveBehaviour)this).sprite.WorldCenter, 0.4f, 0.15f, 10f, 0.4f);
		AkSoundEngine.PostEvent("Play_VO_lichA_cackle_01", ((Component)this).gameObject);
		GameObject val = new GameObject("silencer");
		SilencerInstance val2 = val.AddComponent<SilencerInstance>();
		val2.TriggerSilencer(((BraveBehaviour)this).sprite.WorldCenter, 25f, 3.5f, (GameObject)null, 0f, 3f, 3f, 3f, 250f, 5f, 0.25f, (PlayerController)null, false, false);
		if (activeEnemies == null)
		{
			return;
		}
		for (int i = 0; i < activeEnemies.Count; i++)
		{
			AIActor val3 = activeEnemies[i];
			if (Object.op_Implicit((Object)(object)((BraveBehaviour)val3).healthHaver))
			{
				((BraveBehaviour)val3).healthHaver.ApplyDamage(((BraveBehaviour)val3).healthHaver.IsBoss ? 100f : 10000000f, Vector2.zero, string.Empty, (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
			}
		}
	}
}
