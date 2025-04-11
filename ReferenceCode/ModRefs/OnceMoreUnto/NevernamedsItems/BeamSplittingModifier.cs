using System.Collections.Generic;
using System.Linq;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BeamSplittingModifier : MonoBehaviour
{
	private Dictionary<BasicBeamController, float> subBeams;

	public float distanceTilSplit;

	public int amtToSplitTo;

	public float splitAngles;

	public float dmgMultOnSplit;

	private float originalRange;

	private Projectile projectile;

	private BasicBeamController basicBeamController;

	private BeamController beamController;

	private PlayerController owner;

	public BeamSplittingModifier()
	{
		subBeams = new Dictionary<BasicBeamController, float>();
		distanceTilSplit = 7f;
		amtToSplitTo = 0;
		splitAngles = 39f;
		dmgMultOnSplit = 0.66f;
	}

	private void Start()
	{
		projectile = ((Component)this).GetComponent<Projectile>();
		beamController = ((Component)this).GetComponent<BeamController>();
		basicBeamController = ((Component)this).GetComponent<BasicBeamController>();
		if (projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref owner;
			GameActor obj = projectile.Owner;
			reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
		}
		if (projectile.baseData.range > distanceTilSplit)
		{
			originalRange = projectile.baseData.range;
			projectile.baseData.range = distanceTilSplit;
		}
		else
		{
			distanceTilSplit = projectile.baseData.range;
		}
	}

	private void ClearExtantSubBeams()
	{
		if (subBeams.Count <= 0)
		{
			return;
		}
		for (int num = subBeams.Count - 1; num >= 0; num--)
		{
			if (Object.op_Implicit((Object)(object)subBeams.ElementAt(num).Key) && Object.op_Implicit((Object)(object)((Component)subBeams.ElementAt(num).Key).gameObject))
			{
				((BeamController)subBeams.ElementAt(num).Key).CeaseAttack();
			}
		}
		subBeams.Clear();
	}

	private void CreateNewSubBeams()
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		ClearExtantSubBeams();
		float num = splitAngles / ((float)amtToSplitTo - 1f);
		float finalBoneDirection = BeamAPI.GetFinalBoneDirection(basicBeamController);
		float num2 = finalBoneDirection + splitAngles * 0.5f;
		int num3 = 0;
		for (int i = 0; i < amtToSplitTo; i++)
		{
			LinkedList<BeamBone> bones = basicBeamController.m_bones;
			LinkedListNode<BeamBone> linkedListNode = null;
			if (bones != null)
			{
				linkedListNode = bones.Last;
				Vector2 bonePosition = basicBeamController.GetBonePosition(linkedListNode.Value);
				float num4 = num2 - num * (float)num3;
				GameObject val = FakePrefab.Clone(((Component)projectile).gameObject);
				if ((Object)(object)val == (Object)null)
				{
					Debug.LogError((object)"BeamSplitComp: Cloned Beam Prefab was NULL!");
				}
				BeamController component = val.GetComponent<BeamController>();
				if ((Object)(object)component == (Object)null)
				{
					Debug.LogError((object)"BeamSplitComp: ControllerPrefab was NULL!");
				}
				if (component is BasicBeamController)
				{
					GameObject val2 = Object.Instantiate<GameObject>(((Component)component).gameObject);
					BasicBeamController component2 = val2.GetComponent<BasicBeamController>();
					component2.State = (BeamState)2;
					((BeamController)component2).HitsPlayers = false;
					((BeamController)component2).HitsEnemies = true;
					((BeamController)component2).Origin = bonePosition;
					((BeamController)component2).Direction = MathsAndLogicHelper.DegreeToVector2(num4);
					((BeamController)component2).usesChargeDelay = false;
					component2.muzzleAnimation = string.Empty;
					component2.chargeAnimation = string.Empty;
					component2.beamStartAnimation = string.Empty;
					((BraveBehaviour)component2).projectile.Owner = projectile.Owner;
					((BeamController)component2).Owner = ((BeamController)basicBeamController).Owner;
					((BeamController)component2).Gun = ((BeamController)basicBeamController).Gun;
					if (originalRange > 0f)
					{
						((BraveBehaviour)component2).projectile.baseData.range = originalRange;
					}
					ProjectileData baseData = ((BraveBehaviour)component2).projectile.baseData;
					baseData.damage *= dmgMultOnSplit;
					if (Object.op_Implicit((Object)(object)((Component)component2).GetComponent<BeamSplittingModifier>()))
					{
						Object.Destroy((Object)(object)((Component)component2).GetComponent<BeamSplittingModifier>());
					}
					subBeams.Add(component2, num * (float)num3);
				}
				else
				{
					Debug.LogError((object)"BeamSplitComp: Controller prefab was not beam????");
				}
				num3++;
				continue;
			}
			Debug.LogError((object)"Bones was NULL");
			break;
		}
	}

	private void Update()
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		if (projectile.baseData.range > distanceTilSplit)
		{
			originalRange = projectile.baseData.range;
			projectile.baseData.range = distanceTilSplit;
		}
		if (basicBeamController.ApproximateDistance >= distanceTilSplit && subBeams.Count < amtToSplitTo)
		{
			CreateNewSubBeams();
		}
		if (basicBeamController.ApproximateDistance < distanceTilSplit && subBeams.Count > 0)
		{
			ClearExtantSubBeams();
		}
		float finalBoneDirection = BeamAPI.GetFinalBoneDirection(basicBeamController);
		float num = finalBoneDirection + splitAngles * 0.5f;
		if (subBeams.Count > 0)
		{
			for (int i = 0; i < subBeams.Count; i++)
			{
				BasicBeamController key = subBeams.ElementAt(i).Key;
				LinkedList<BeamBone> bones = basicBeamController.m_bones;
				LinkedListNode<BeamBone> last = bones.Last;
				Vector2 bonePosition = basicBeamController.GetBonePosition(last.Value);
				float value = subBeams.ElementAt(i).Value;
				((BeamController)key).Direction = MathsAndLogicHelper.DegreeToVector2(num - value);
				((BeamController)key).Origin = bonePosition;
				((BeamController)key).LateUpdatePosition(Vector2.op_Implicit(bonePosition));
			}
		}
	}

	private void OnDestroy()
	{
		ClearExtantSubBeams();
	}
}
