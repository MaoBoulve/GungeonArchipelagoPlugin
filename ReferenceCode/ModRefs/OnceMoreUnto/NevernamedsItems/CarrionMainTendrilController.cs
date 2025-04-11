using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class CarrionMainTendrilController : MonoBehaviour
{
	public GameObject subTendrilPrefab;

	public int forme;

	private int boneNumLastChecked;

	private Projectile projectileSelf;

	private BeamController beamContollerSelf;

	private BasicBeamController basicBeamControllerSelf;

	private PlayerController Owner;

	public void Start()
	{
		forme = 1;
		projectileSelf = ((Component)this).GetComponent<Projectile>();
		beamContollerSelf = ((Component)this).GetComponent<BeamController>();
		basicBeamControllerSelf = ((Component)this).GetComponent<BasicBeamController>();
		if (projectileSelf.Owner is PlayerController)
		{
			ref PlayerController owner = ref Owner;
			GameActor owner2 = projectileSelf.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
	}

	public void Update()
	{
		if (!Object.op_Implicit((Object)(object)basicBeamControllerSelf))
		{
			return;
		}
		LinkedList<BeamBone> bones = basicBeamControllerSelf.m_bones;
		if (bones != null)
		{
			if (bones.Count > boneNumLastChecked && Random.value <= 0.5f)
			{
				SpawnSubTendril(bones.Count - 1);
			}
			boneNumLastChecked = bones.Count;
		}
	}

	public void SpawnSubTendril(int boneIndex)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		if (!((Object)(object)subTendrilPrefab != (Object)null))
		{
			return;
		}
		BeamController component = subTendrilPrefab.GetComponent<BeamController>();
		if ((Object)(object)component == (Object)null)
		{
			Debug.LogError((object)"CarrionMainTendril: ControllerPrefab was NULL!");
		}
		if (component is BasicBeamController)
		{
			GameObject val = Object.Instantiate<GameObject>(((Component)component).gameObject);
			BasicBeamController component2 = val.GetComponent<BasicBeamController>();
			component2.State = (BeamState)2;
			((BeamController)component2).HitsPlayers = false;
			((BeamController)component2).HitsEnemies = true;
			((BeamController)component2).Origin = BeamAPI.GetIndexedBonePosition(basicBeamControllerSelf, boneIndex);
			((BeamController)component2).Direction = MathsAndLogicHelper.DegreeToVector2(BeamAPI.GetFinalBoneDirection(basicBeamControllerSelf));
			((BeamController)component2).usesChargeDelay = false;
			((BraveBehaviour)component2).projectile.Owner = projectileSelf.Owner;
			((BeamController)component2).Owner = ((BeamController)basicBeamControllerSelf).Owner;
			((BeamController)component2).Gun = ((BeamController)basicBeamControllerSelf).Gun;
			ProjectileData baseData = ((BraveBehaviour)component2).projectile.baseData;
			baseData.damage *= (float)forme;
			HelixProjectileMotionModule val2 = new HelixProjectileMotionModule();
			if (Random.value <= 0.5f)
			{
				val2.ForceInvert = true;
			}
			((BraveBehaviour)component2).projectile.OverrideMotionModule = (ProjectileMotionModule)(object)val2;
			CarrionSubTendrilController component3 = val.GetComponent<CarrionSubTendrilController>();
			if (Object.op_Implicit((Object)(object)component3))
			{
				component3.parentBeam = basicBeamControllerSelf;
				component3.parentBoneIndex = boneIndex;
				((Component)component3).GetComponent<Projectile>().PossibleSourceGun = projectileSelf.PossibleSourceGun;
			}
		}
	}
}
