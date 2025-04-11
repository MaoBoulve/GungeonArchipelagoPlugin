using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ExsanguinationSetup
{
	public static Dictionary<int, GameObject> effectStackVFX;

	public static GameObject labelStackVFX;

	public static GameObject BloodParticleDoer;

	public static void Init()
	{
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		effectStackVFX = new Dictionary<int, GameObject>
		{
			{
				1,
				VFXToolbox.CreateVFXBundle("ExsanguinationOverhead_1", usesZHeight: false, 0f, -1f, -1f, null)
			},
			{
				2,
				VFXToolbox.CreateVFXBundle("ExsanguinationOverhead_2", usesZHeight: false, 0f, -1f, -1f, null)
			},
			{
				3,
				VFXToolbox.CreateVFXBundle("ExsanguinationOverhead_3", usesZHeight: false, 0f, -1f, -1f, null)
			},
			{
				4,
				VFXToolbox.CreateVFXBundle("ExsanguinationOverhead_4", usesZHeight: false, 0f, -1f, -1f, null)
			},
			{
				5,
				VFXToolbox.CreateVFXBundle("ExsanguinationOverhead_5", usesZHeight: false, 0f, -1f, -1f, null)
			}
		};
		labelStackVFX = VFXToolbox.CreateVFXBundle("ExsanguinationOverhead_Label", usesZHeight: false, 0f, -1f, -1f, null);
		BloodParticleDoer = FakePrefab.Clone(((Component)PickupObjectDatabase.GetById(449)).GetComponent<TeleporterPrototypeItem>().TelefragVFXPrefab.gameObject);
		EmissionModule emission = BloodParticleDoer.GetComponent<ParticleSystem>().emission;
		Burst val = default(Burst);
		((Burst)(ref val)).count = MinMaxCurve.op_Implicit(1f);
		((Burst)(ref val)).time = 0f;
		((Burst)(ref val)).cycleCount = 1;
		((Burst)(ref val)).repeatInterval = 0.01f;
		((Burst)(ref val)).maxCount = 1;
		((Burst)(ref val)).minCount = 1;
		((EmissionModule)(ref emission)).SetBurst(0, val);
	}
}
