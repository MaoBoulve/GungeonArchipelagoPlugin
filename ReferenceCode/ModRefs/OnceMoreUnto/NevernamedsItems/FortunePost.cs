using HarmonyLib;
using UnityEngine;

namespace NevernamedsItems;

[HarmonyPatch(typeof(UltraFortunesFavor))]
[HarmonyPatch(/*Could not decode attribute arguments.*/)]
public class FortunePost
{
	[HarmonyPostfix]
	public static void HarmonyPostfix(UltraFortunesFavor __instance, SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData)
	{
		if (((CastResult)collisionData).MyPixelCollider == __instance.m_bulletBlocker && (Object)(object)collisionData.OtherRigidbody != (Object)null && (Object)(object)((BraveBehaviour)collisionData.OtherRigidbody).projectile != (Object)null && Object.op_Implicit((Object)(object)((Component)__instance).gameObject.GetComponent<NPCShootReactor>()))
		{
			((Component)__instance).gameObject.GetComponent<NPCShootReactor>().OnShot(((BraveBehaviour)collisionData.OtherRigidbody).projectile);
		}
	}
}
