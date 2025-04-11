using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class EmmisiveTrail : MonoBehaviour
{
	private List<string> TransformList = new List<string> { "trailObject" };

	public float EmissivePower;

	public float EmissiveColorPower;

	public bool debugLogging;

	public EmmisiveTrail()
	{
		EmissivePower = 75f;
		EmissiveColorPower = 1.55f;
		debugLogging = false;
	}

	public void Start()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		Shader shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutoutEmissive");
		foreach (Transform item in ((Component)this).transform)
		{
			Transform val = item;
			tk2dBaseSprite component = ((Component)val).GetComponent<tk2dBaseSprite>();
			if ((Object)(object)component != (Object)null)
			{
				if (debugLogging)
				{
					Debug.Log((object)("Checks were passed for transform; " + ((Object)val).name));
				}
				component.usesOverrideMaterial = true;
				((BraveBehaviour)component).renderer.material.shader = shader;
				((BraveBehaviour)component).renderer.material.EnableKeyword("BRIGHTNESS_CLAMP_ON");
				((BraveBehaviour)component).renderer.material.SetFloat("_EmissivePower", EmissivePower);
				((BraveBehaviour)component).renderer.material.SetFloat("_EmissiveColorPower", EmissiveColorPower);
			}
			else if (debugLogging)
			{
				Debug.Log((object)"Sprite was null");
			}
		}
	}
}
