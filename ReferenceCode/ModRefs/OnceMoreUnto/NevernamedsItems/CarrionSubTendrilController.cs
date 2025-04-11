using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class CarrionSubTendrilController : MonoBehaviour
{
	private Projectile projectileSelf;

	private BeamController beamContollerSelf;

	private BasicBeamController basicBeamControllerSelf;

	private PlayerController Owner;

	private float Angle;

	private bool movingLeft;

	public BasicBeamController parentBeam;

	public int parentBoneIndex;

	public void Start()
	{
		projectileSelf = ((Component)this).GetComponent<Projectile>();
		beamContollerSelf = ((Component)this).GetComponent<BeamController>();
		basicBeamControllerSelf = ((Component)this).GetComponent<BasicBeamController>();
		if (projectileSelf.Owner is PlayerController)
		{
			ref PlayerController owner = ref Owner;
			GameActor owner2 = projectileSelf.Owner;
			owner = (PlayerController)(object)((owner2 is PlayerController) ? owner2 : null);
		}
		if (Random.value <= 0.5f)
		{
			Angle = Random.Range(70, 110);
		}
		else
		{
			Angle = Random.Range(-70, -110);
		}
	}

	public void Update()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)parentBeam == (Object)null)
		{
			RemoveTendril();
			return;
		}
		if (BeamAPI.GetBoneCount(parentBeam) - 1 < parentBoneIndex)
		{
			RemoveTendril();
			return;
		}
		Vector2 indexedBonePosition = BeamAPI.GetIndexedBonePosition(parentBeam, parentBoneIndex);
		if (!(indexedBonePosition != Vector2.zero))
		{
			return;
		}
		((BeamController)basicBeamControllerSelf).Direction = MathsAndLogicHelper.DegreeToVector2(BeamAPI.GetIndexedBone(parentBeam, parentBoneIndex).RotationAngle + Angle);
		((BeamController)basicBeamControllerSelf).Origin = indexedBonePosition;
		((BeamController)basicBeamControllerSelf).LateUpdatePosition(Vector2.op_Implicit(indexedBonePosition));
		if (Random.value <= 0.25f)
		{
			movingLeft = !movingLeft;
		}
		if (Random.value <= 0.75f)
		{
			if (movingLeft)
			{
				Angle += 1f;
			}
			else
			{
				Angle -= 1f;
			}
		}
	}

	private void RemoveTendril()
	{
		beamContollerSelf.CeaseAttack();
	}
}
