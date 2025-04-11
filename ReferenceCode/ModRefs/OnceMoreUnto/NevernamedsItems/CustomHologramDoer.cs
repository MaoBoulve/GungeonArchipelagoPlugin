using System;
using UnityEngine;

namespace NevernamedsItems;

public class CustomHologramDoer : BraveBehaviour
{
	public bool hologramIsGreen;

	public GameObject extantSprite;

	private tk2dSprite m_ItemSprite;

	public CustomHologramDoer()
	{
		hologramIsGreen = false;
	}

	public void ShowSprite(tk2dSpriteCollectionData encounterIconCollection, int spriteID)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)encounterIconCollection) && Object.op_Implicit((Object)(object)((BraveBehaviour)this).gameActor))
		{
			if (Object.op_Implicit((Object)(object)extantSprite))
			{
				Object.Destroy((Object)(object)extantSprite);
			}
			extantSprite = new GameObject("Item Hologram", new Type[1] { typeof(tk2dSprite) })
			{
				layer = 0
			};
			extantSprite.transform.position = ((BraveBehaviour)this).transform.position + new Vector3(0.5f, 2f);
			m_ItemSprite = extantSprite.AddComponent<tk2dSprite>();
			((tk2dBaseSprite)m_ItemSprite).SetSprite(encounterIconCollection, spriteID);
			((tk2dBaseSprite)m_ItemSprite).PlaceAtPositionByAnchor(extantSprite.transform.position, (Anchor)1);
			((BraveBehaviour)m_ItemSprite).transform.localPosition = dfVectorExtensions.Quantize(((BraveBehaviour)m_ItemSprite).transform.localPosition, 0.0625f);
			if ((Object)(object)((BraveBehaviour)this).gameActor != (Object)null)
			{
				extantSprite.transform.parent = ((BraveBehaviour)((BraveBehaviour)this).gameActor).transform;
			}
			if (Object.op_Implicit((Object)(object)m_ItemSprite))
			{
				((BraveBehaviour)this).sprite.AttachRenderer((tk2dBaseSprite)(object)m_ItemSprite);
				((tk2dBaseSprite)m_ItemSprite).depthUsesTrimmedBounds = true;
				((tk2dBaseSprite)m_ItemSprite).UpdateZDepth();
			}
			((BraveBehaviour)this).sprite.UpdateZDepth();
			ApplyHologramShader((tk2dBaseSprite)(object)m_ItemSprite, hologramIsGreen);
		}
	}

	public void ApplyHologramShader(tk2dBaseSprite targetSprite, bool isGreen = false, bool usesOverrideMaterial = true)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		Shader shader = Shader.Find("Brave/Internal/HologramShader");
		Material val = new Material(Shader.Find("Brave/Internal/HologramShader"));
		((Object)val).name = "HologramMaterial";
		Material val2 = val;
		val.SetTexture("_MainTex", ((BraveBehaviour)targetSprite).renderer.material.GetTexture("_MainTex"));
		val2.SetTexture("_MainTex", ((BraveBehaviour)targetSprite).renderer.sharedMaterial.GetTexture("_MainTex"));
		if (isGreen)
		{
			val.SetFloat("_IsGreen", 1f);
			val2.SetFloat("_IsGreen", 1f);
		}
		((BraveBehaviour)targetSprite).renderer.material.shader = shader;
		((BraveBehaviour)targetSprite).renderer.material = val;
		((BraveBehaviour)targetSprite).renderer.sharedMaterial = val2;
		targetSprite.usesOverrideMaterial = usesOverrideMaterial;
	}

	public void HideSprite()
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)this).gameActor) && Object.op_Implicit((Object)(object)extantSprite))
		{
			Object.Destroy((Object)(object)extantSprite);
		}
	}
}
