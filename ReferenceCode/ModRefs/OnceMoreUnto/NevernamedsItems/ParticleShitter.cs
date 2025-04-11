using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class ParticleShitter : MonoBehaviour
{
	private float particleCounter = 0f;

	private Projectile m_projectile;

	public SparksType particleType;

	public float particlesPerSecond = 40f;

	private void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
	}

	private void Update()
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		particleCounter += BraveTime.DeltaTime * particlesPerSecond;
		if (!(particleCounter > 1f))
		{
			return;
		}
		int num = Mathf.FloorToInt(particleCounter);
		particleCounter %= 1f;
		if (Object.op_Implicit((Object)(object)((Component)m_projectile).GetComponent<BeamController>()))
		{
			BasicBeamController component = ((Component)m_projectile).GetComponent<BasicBeamController>();
			Vector2 indexedBonePosition = BeamAPI.GetIndexedBonePosition(component, Random.Range(0, BeamAPI.GetBoneCount(component)));
			for (int i = 0; i < num; i++)
			{
				Quaternion val = Quaternion.Euler(0f, 0f, (float)Random.Range(-90, 90));
				Vector3 up = Vector3.up;
				Vector3 normalized = ((Vector3)(ref up)).normalized;
				up = Vector3.up;
				float num2 = ((Vector3)(ref up)).magnitude - 0.5f;
				up = Vector3.up;
				Vector3 val2 = val * (normalized * Random.Range(num2, ((Vector3)(ref up)).magnitude + 0.5f));
				GlobalSparksDoer.DoSingleParticle(Vector2.op_Implicit(indexedBonePosition), val2, (float?)null, (float?)null, (Color?)null, particleType);
			}
		}
		else
		{
			GlobalSparksDoer.DoRandomParticleBurst(num, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)m_projectile).sprite.WorldBottomLeft, 0f), Vector2Extensions.ToVector3ZisY(((BraveBehaviour)m_projectile).sprite.WorldTopRight, 0f), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, particleType);
		}
	}
}
