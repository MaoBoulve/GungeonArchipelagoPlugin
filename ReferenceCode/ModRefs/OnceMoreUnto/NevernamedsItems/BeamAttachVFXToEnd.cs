using UnityEngine;

namespace NevernamedsItems;

public class BeamAttachVFXToEnd : MonoBehaviour
{
	private Projectile projectile;

	private BeamController beamController;

	private BasicBeamController basicBeamController;

	public GameObject VFX;

	private GameObject instanceVFX;

	private bool dying;

	private void Start()
	{
		projectile = ((Component)this).GetComponent<Projectile>();
		beamController = ((Component)this).GetComponent<BeamController>();
		basicBeamController = ((Component)this).GetComponent<BasicBeamController>();
	}

	private void Update()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)instanceVFX) && !dying)
		{
			instanceVFX = SpawnManager.SpawnVFX(VFX, Vector2.op_Implicit(basicBeamController.GetBonePosition(basicBeamController.m_bones.Last.Value)), Quaternion.identity, true);
		}
		if (Object.op_Implicit((Object)(object)instanceVFX))
		{
			instanceVFX.transform.position = Vector2.op_Implicit(basicBeamController.GetBonePosition(basicBeamController.m_bones.Last.Value));
		}
	}

	private void OnDestroy()
	{
		dying = true;
		if (Object.op_Implicit((Object)(object)instanceVFX))
		{
			Object.Destroy((Object)(object)instanceVFX);
		}
	}
}
