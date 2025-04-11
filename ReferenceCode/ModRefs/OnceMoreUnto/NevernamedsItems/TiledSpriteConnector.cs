using UnityEngine;

namespace NevernamedsItems;

public class TiledSpriteConnector : MonoBehaviour
{
	public SpeculativeRigidbody sourceRigidbody;

	public SpeculativeRigidbody targetRigidbody;

	public Vector2 targetVector;

	public bool usesVector;

	public bool eraseSpriteIfTargetOrSourceNull;

	public bool eraseComponentIfTargetOrSourceNull;

	private tk2dTiledSprite tiledSprite;

	private void Start()
	{
		tiledSprite = ((Component)this).GetComponent<tk2dTiledSprite>();
	}

	private void Update()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)sourceRigidbody))
		{
			Vector2 unitCenter = sourceRigidbody.UnitCenter;
			Vector2 val = Vector2.zero;
			if (usesVector && targetVector != Vector2.zero)
			{
				val = targetVector;
			}
			else if (Object.op_Implicit((Object)(object)targetRigidbody))
			{
				val = targetRigidbody.UnitCenter;
			}
			if (val != Vector2.zero)
			{
				((BraveBehaviour)tiledSprite).transform.position = Vector2.op_Implicit(unitCenter);
				Vector2 val2 = val - unitCenter;
				float num = BraveMathCollege.Atan2Degrees(((Vector2)(ref val2)).normalized);
				int num2 = Mathf.RoundToInt(((Vector2)(ref val2)).magnitude / 0.0625f);
				tiledSprite.dimensions = new Vector2((float)num2, tiledSprite.dimensions.y);
				((BraveBehaviour)tiledSprite).transform.rotation = Quaternion.Euler(0f, 0f, num);
				((tk2dBaseSprite)tiledSprite).UpdateZDepth();
			}
			else if (eraseSpriteIfTargetOrSourceNull)
			{
				Object.Destroy((Object)(object)((Component)tiledSprite).gameObject);
			}
			else if (eraseComponentIfTargetOrSourceNull)
			{
				Object.Destroy((Object)(object)this);
			}
		}
		else if (eraseSpriteIfTargetOrSourceNull)
		{
			Object.Destroy((Object)(object)((Component)tiledSprite).gameObject);
		}
		else if (eraseComponentIfTargetOrSourceNull)
		{
			Object.Destroy((Object)(object)this);
		}
	}
}
