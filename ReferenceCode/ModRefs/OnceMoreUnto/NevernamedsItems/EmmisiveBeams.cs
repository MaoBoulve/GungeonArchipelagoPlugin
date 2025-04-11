using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

internal class EmmisiveBeams : MonoBehaviour
{
	private List<string> TransformList = new List<string> { "Sprite", "beam impact vfx 2", "beam impact vfx" };

	private BasicBeamController beamcont;

	public float EmissivePower;

	public float EmissiveColorPower;

	public Color EmissiveColor;

	public EmmisiveBeams()
	{
		EmissivePower = 100f;
		EmissiveColorPower = 1.55f;
	}

	public void Start()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		Shader shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutoutEmissive");
		foreach (Transform item in ((Component)this).transform)
		{
			Transform val = item;
			if (!TransformList.Contains(((Object)val).name))
			{
				continue;
			}
			tk2dSprite component = ((Component)val).GetComponent<tk2dSprite>();
			if ((Object)(object)component != (Object)null)
			{
				((tk2dBaseSprite)component).usesOverrideMaterial = true;
				((BraveBehaviour)component).renderer.material.shader = shader;
				((BraveBehaviour)component).renderer.material.EnableKeyword("BRIGHTNESS_CLAMP_ON");
				((BraveBehaviour)component).renderer.material.SetFloat("_EmissivePower", EmissivePower);
				((BraveBehaviour)component).renderer.material.SetFloat("_EmissiveColorPower", EmissiveColorPower);
				_ = EmissiveColor;
				if (true)
				{
					((BraveBehaviour)component).renderer.material.SetColor("_EmissiveColor", EmissiveColor);
				}
			}
		}
		beamcont = ((Component)this).GetComponent<BasicBeamController>();
		BasicBeamController val2 = beamcont;
		((BraveBehaviour)val2).sprite.usesOverrideMaterial = true;
		BasicBeamController component2 = ((Component)val2).gameObject.GetComponent<BasicBeamController>();
		if ((Object)(object)component2 != (Object)null)
		{
			((BraveBehaviour)((BraveBehaviour)component2).sprite).renderer.material.shader = shader;
			((BraveBehaviour)((BraveBehaviour)component2).sprite).renderer.material.EnableKeyword("BRIGHTNESS_CLAMP_ON");
			((BraveBehaviour)((BraveBehaviour)component2).sprite).renderer.material.SetFloat("_EmissivePower", EmissivePower);
			((BraveBehaviour)((BraveBehaviour)component2).sprite).renderer.material.SetFloat("_EmissiveColorPower", EmissiveColorPower);
			_ = EmissiveColor;
			if (true)
			{
				((BraveBehaviour)((BraveBehaviour)component2).sprite).renderer.material.SetColor("_EmissiveColor", EmissiveColor);
			}
		}
	}

	public void Update()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		Shader shader = ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutoutEmissive");
		Transform val = ((Component)this).transform.Find("beam pierce impact vfx");
		if (!((Object)(object)val != (Object)null))
		{
			return;
		}
		tk2dSprite component = ((Component)val).GetComponent<tk2dSprite>();
		if ((Object)(object)component != (Object)null)
		{
			((BraveBehaviour)component).renderer.material.shader = shader;
			((BraveBehaviour)component).renderer.material.EnableKeyword("BRIGHTNESS_CLAMP_ON");
			((BraveBehaviour)component).renderer.material.SetFloat("_EmissivePower", EmissivePower);
			((BraveBehaviour)component).renderer.material.SetFloat("_EmissiveColorPower", EmissiveColorPower);
			_ = EmissiveColor;
			if (true)
			{
				((BraveBehaviour)component).renderer.material.SetColor("_EmissiveColor", EmissiveColor);
			}
		}
	}
}
