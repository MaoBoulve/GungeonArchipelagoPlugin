using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace NevernamedsItems;

public class EasyTrailBullet : BraveBehaviour
{
	public Texture _gradTexture;

	private Projectile proj;

	public Vector2 TrailPos;

	public Color BaseColor;

	public Color StartColor;

	public Color EndColor;

	public float LifeTime;

	public float StartWidth;

	public float EndWidth;

	public EasyTrailBullet()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		TrailPos = Vector2.op_Implicit(new Vector3(0f, 0f, 0f));
		BaseColor = Color.red;
		StartColor = Color.red;
		EndColor = Color.white;
		LifeTime = 1f;
		StartWidth = 1f;
		EndWidth = 0f;
	}

	public void Start()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		proj = ((BraveBehaviour)this).projectile;
		GameObject val = ETGMod.AddChild(((Component)((BraveBehaviour)this).projectile).gameObject, "trail object", new Type[0]);
		val.transform.position = ((BraveBehaviour)((BraveBehaviour)this).projectile).transform.position;
		val.transform.localPosition = Vector2.op_Implicit(TrailPos);
		TrailRenderer val2 = val.AddComponent<TrailRenderer>();
		((Renderer)val2).shadowCastingMode = (ShadowCastingMode)0;
		((Renderer)val2).receiveShadows = false;
		Material val3 = new Material(Shader.Find("Sprites/Default"));
		val3.mainTexture = _gradTexture;
		((Renderer)val2).material = val3;
		val2.minVertexDistance = 0.1f;
		val3.SetColor("_Color", BaseColor);
		val2.startColor = StartColor;
		val2.endColor = EndColor;
		val2.time = LifeTime;
		val2.startWidth = StartWidth;
		val2.endWidth = EndWidth;
	}
}
