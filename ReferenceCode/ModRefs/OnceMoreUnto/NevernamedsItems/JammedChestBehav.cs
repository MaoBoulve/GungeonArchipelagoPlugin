using UnityEngine;

namespace NevernamedsItems;

public class JammedChestBehav : MonoBehaviour
{
	private float particleCounter;

	private Chest m_self;

	private void Start()
	{
		particleCounter = 0f;
		m_self = ((Component)this).GetComponent<Chest>();
		if ((Object)(object)m_self != (Object)null)
		{
			((BraveBehaviour)((BraveBehaviour)m_self).sprite).renderer.material.shader = ShaderCache.Acquire("Brave/LitCutoutUberPhantom");
		}
	}

	private void Update()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		particleCounter += BraveTime.DeltaTime * 40f;
		if (particleCounter > 1f)
		{
			int num = Mathf.FloorToInt(particleCounter);
			particleCounter %= 1f;
			GlobalSparksDoer.DoRandomParticleBurst(num, Vector2Extensions.ToVector3ZisY(((BraveBehaviour)m_self).sprite.WorldBottomLeft, 0f), Vector2Extensions.ToVector3ZisY(((BraveBehaviour)m_self).sprite.WorldTopRight, 0f), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, (SparksType)1);
		}
	}
}
