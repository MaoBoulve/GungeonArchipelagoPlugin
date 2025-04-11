using UnityEngine;

namespace NevernamedsItems;

public class SpriteSparkler : BraveBehaviour
{
	private float particleCounter = 0f;

	public bool doParticles = false;

	public bool doVFX = false;

	public float particlesPerSecond = 2f;

	public SparksType particleType;

	public string childTarget = null;

	public GameObject VFX;

	public float lifetime = -1f;

	public bool randomise = false;

	private float lifeTimer = -1f;

	private bool isTiming = false;

	private void Start()
	{
		if (lifetime > 0f)
		{
			lifeTimer = lifetime;
			isTiming = true;
		}
	}

	private void Update()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		if (isTiming && !(lifeTimer > 0f))
		{
			return;
		}
		if (lifeTimer > 0f)
		{
			lifeTimer -= BraveTime.DeltaTime;
		}
		if (!Object.op_Implicit((Object)(object)((BraveBehaviour)this).sprite) || (int)GameManager.Options.ShaderQuality == 0 || (int)GameManager.Options.ShaderQuality == 3)
		{
			return;
		}
		float num = particlesPerSecond;
		if (randomise)
		{
			num += Random.Range(0f - particlesPerSecond, particlesPerSecond);
		}
		particleCounter += BraveTime.DeltaTime * num;
		if (!(particleCounter > 1f))
		{
			return;
		}
		int num2 = Mathf.FloorToInt(particleCounter);
		particleCounter %= 1f;
		Vector2 val = Vector2.op_Implicit(Vector2Extensions.ToVector3ZisY(((BraveBehaviour)this).sprite.WorldBottomLeft, 0f));
		Vector2 val2 = Vector2.op_Implicit(Vector2Extensions.ToVector3ZisY(((BraveBehaviour)this).sprite.WorldTopRight, 0f));
		if (!string.IsNullOrEmpty(childTarget) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).transform.Find(childTarget)))
		{
			val = Vector2.op_Implicit(((BraveBehaviour)this).transform.Find(childTarget).position);
			val2 = Vector2.op_Implicit(((BraveBehaviour)this).transform.Find(childTarget).position);
		}
		if (doVFX)
		{
			for (int i = 0; i < num2; i++)
			{
				GameObject val3 = Object.Instantiate<GameObject>(VFX, Vector2.op_Implicit(new Vector2(Random.Range(val.x, val2.x), Random.Range(val.y, val2.y))), Quaternion.identity);
				val3.GetComponent<tk2dBaseSprite>().HeightOffGround = 0.2f;
			}
		}
		if (doParticles)
		{
			GlobalSparksDoer.DoRandomParticleBurst(num2, Vector2.op_Implicit(val), Vector2.op_Implicit(val2), Vector3.up, 90f, 0.5f, (float?)null, (float?)null, (Color?)null, particleType);
		}
	}
}
