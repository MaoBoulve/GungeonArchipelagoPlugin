using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class CarrionMovementTentacles : MonoBehaviour
{
	public class TentacleBoneSticker : MonoBehaviour
	{
		public BasicBeamController parentBeam;

		public int parentBeamBoneIndex;

		public TentacleDraw cable;

		private GameObject self;

		private void Start()
		{
			self = ((Component)this).gameObject;
		}

		private void Update()
		{
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			if (!Object.op_Implicit((Object)(object)self) || !Object.op_Implicit((Object)(object)parentBeam) || parentBeamBoneIndex < 0 || !Object.op_Implicit((Object)(object)cable))
			{
				Suicide();
			}
			if (BeamAPI.GetBoneCount(parentBeam) - 1 < parentBeamBoneIndex)
			{
				Suicide(destroyCable: true);
			}
			Vector2 indexedBonePosition = BeamAPI.GetIndexedBonePosition(parentBeam, parentBeamBoneIndex);
			self.transform.position = Vector2.op_Implicit(indexedBonePosition);
		}

		private void Suicide(bool destroyCable = false)
		{
			if (Object.op_Implicit((Object)(object)parentBeam) && Object.op_Implicit((Object)(object)cable) && destroyCable)
			{
				CarrionMovementTentacles component = ((Component)parentBeam).GetComponent<CarrionMovementTentacles>();
				if (Object.op_Implicit((Object)(object)component) && component.tentes.Contains(cable))
				{
					TentacleDraw tentacleDraw = component.tentes[component.tentes.IndexOf(cable)];
					TentacleDraw tentacleDraw2 = tentacleDraw;
					component.tentes.RemoveAt(component.tentes.IndexOf(cable));
					Object.Destroy((Object)(object)tentacleDraw2);
				}
			}
			Object.Destroy((Object)(object)self);
		}
	}

	public RaycastResult hit;

	public List<TentacleDraw> tentes = new List<TentacleDraw>();

	private Projectile selfProjectile;

	private BeamController selfBeam;

	private BasicBeamController selfBasicBeam;

	private PlayerController selfOwner;

	private void Start()
	{
		selfProjectile = ((Component)this).GetComponent<Projectile>();
		selfBeam = ((Component)this).GetComponent<BeamController>();
		selfBasicBeam = ((Component)this).GetComponent<BasicBeamController>();
		if (Object.op_Implicit((Object)(object)selfProjectile) && Object.op_Implicit((Object)(object)ProjectileUtility.ProjectilePlayerOwner(selfProjectile)))
		{
			selfOwner = ProjectileUtility.ProjectilePlayerOwner(selfProjectile);
		}
		((MonoBehaviour)this).InvokeRepeating("CreateNewTentacle", 0.05f, 0.05f);
	}

	private void Update()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		foreach (TentacleDraw tente in tentes)
		{
			if ((Object)(object)((Component)tente.Attach1).gameObject != (Object)null && (Object)(object)((Component)tente.Attach2).gameObject != (Object)null && Vector3.Distance(((Component)tente.Attach1).gameObject.transform.position, ((Component)tente.Attach2).gameObject.transform.position) > 25f)
			{
				TentacleDraw tentacleDraw = tentes[tentes.IndexOf(tente)];
				TentacleDraw tentacleDraw2 = tentacleDraw;
				tentes.RemoveAt(tentes.IndexOf(tente));
				Object.Destroy((Object)(object)tentacleDraw2);
				CreateNewTentacle();
			}
		}
	}

	private void OnDestroy()
	{
		for (int num = tentes.Count - 1; num >= 0; num--)
		{
			TentacleDraw tentacleDraw = tentes[num];
			tentes.RemoveAt(num);
			Object.Destroy((Object)(object)tentacleDraw);
		}
	}

	private void CreateNewTentacle()
	{
		if (tentes.Count >= 20)
		{
			TentacleDraw tentacleDraw = tentes[0];
			TentacleDraw tentacleDraw2 = tentacleDraw;
			tentes.RemoveAt(0);
			Object.Destroy((Object)(object)tentacleDraw2);
		}
		CreateTentacleAtBone(Random.Range(0, BeamAPI.GetBoneCount(selfBasicBeam)));
	}

	private void CreateTentacleAtBone(int boneIndex)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		Vector2 indexedBonePosition = BeamAPI.GetIndexedBonePosition(selfBasicBeam, boneIndex);
		float rotationAngle = BeamAPI.GetIndexedBone(selfBasicBeam, boneIndex).RotationAngle;
		float num = rotationAngle;
		num = ((!(Random.value <= 0.5f)) ? (num - Random.Range(0f, 45f)) : (num + Random.Range(0f, 45f)));
		if (PhysicsEngine.Instance.Raycast(indexedBonePosition, BraveMathCollege.DegreesToVector(num, 1f), 20f, ref hit, true, true, int.MaxValue, (CollisionLayer?)null, false, (Func<SpeculativeRigidbody, bool>)null, (SpeculativeRigidbody)null) && ((CastResult)hit).OtherPixelCollider.IsTileCollider)
		{
			TentacleDraw tentacleDraw = ((Component)ETGModMainBehaviour.Instance).gameObject.AddComponent<TentacleDraw>();
			GameObject val = new GameObject("holdPoint");
			val.transform.position = Vector2.op_Implicit(((CastResult)hit).Contact);
			GameObject val2 = new GameObject("TentacleStickler");
			TentacleBoneSticker tentacleBoneSticker = val2.AddComponent<TentacleBoneSticker>();
			tentacleBoneSticker.parentBeam = selfBasicBeam;
			tentacleBoneSticker.parentBeamBoneIndex = boneIndex;
			tentacleBoneSticker.cable = tentacleDraw;
			val2.transform.position = Vector2.op_Implicit(indexedBonePosition);
			tentacleDraw.Initialize(val2.transform, val.transform);
			tentes.Add(tentacleDraw);
			RaycastResult.Pool.Free(ref hit);
		}
	}
}
