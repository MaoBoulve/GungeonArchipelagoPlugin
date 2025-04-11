using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NevernamedsItems;

internal class ComplexProjModBeamCompatibility
{
	private static Hook complexProjPostProcessBeam;

	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		complexProjPostProcessBeam = new Hook((MethodBase)typeof(ComplexProjectileModifier).GetMethod("PostProcessBeam", BindingFlags.Instance | BindingFlags.NonPublic), typeof(ComplexProjModBeamCompatibility).GetMethod("PostProcessBeamHook", BindingFlags.Instance | BindingFlags.Public), (object)typeof(ComplexProjectileModifier));
	}

	public void PostProcessBeamHook(Action<ComplexProjectileModifier, BeamController> orig, ComplexProjectileModifier self, BeamController beam)
	{
		orig(self, beam);
		if (self.AddsExplosino && self.ExplosionData != null)
		{
			BeamExplosiveModifier beamExplosiveModifier = ((Component)beam).gameObject.AddComponent<BeamExplosiveModifier>();
			beamExplosiveModifier.explosionData = self.ExplosionData;
			beamExplosiveModifier.canHarmOwner = false;
			beamExplosiveModifier.chancePerTick = self.ActivationChance;
			beamExplosiveModifier.tickDelay = 0.25f;
		}
		if (self.AddsChanceToBlank)
		{
			BeamBlankModifier beamBlankModifier = ((Component)beam).gameObject.AddComponent<BeamBlankModifier>();
		}
	}
}
