using UnityEngine;

namespace NevernamedsItems;

internal class RelativeLabelAttacher : MonoBehaviour
{
	public bool centered;

	private dfLabel label;

	private GameObject self;

	private GameObject extantLabel;

	public string labelValue;

	public Color colour;

	public Vector3 offset;

	public RelativeLabelAttacher()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		labelValue = "Lorem Ipsum";
		colour = Color.red;
		offset = Vector2.op_Implicit(Vector2.zero);
		centered = false;
	}

	private void Start()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		self = ((Component)this).gameObject;
		GameObject val = (GameObject)Object.Instantiate(BraveResources.Load("DamagePopupLabel", ".prefab"), ((BraveBehaviour)GameUIRoot.Instance).transform);
		label = val.GetComponent<dfLabel>();
		((Component)label).gameObject.SetActive(true);
		label.Text = labelValue;
		((dfControl)label).Color = Color32.op_Implicit(colour);
		((dfControl)label).Opacity = 1f;
		label.TextAlignment = (TextAlignment)1;
		extantLabel = val;
		extantLabel.transform.position = self.transform.position + offset;
		Vector2 val2 = Vector2.op_Implicit(dfVectorExtensions.QuantizeFloor(extantLabel.transform.position, ((dfControl)extantLabel.GetComponent<dfLabel>()).PixelsToUnits() / (Pixelator.Instance.ScaleTileScale / Pixelator.Instance.CurrentTileScale)));
		extantLabel.transform.position = Vector3Extensions.WithZ(dfFollowObject.ConvertWorldSpaces(Vector2.op_Implicit(val2), GameManager.Instance.MainCameraController.Camera, GameUIRoot.Instance.Manager.RenderCamera), 0f);
	}

	private void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)extantLabel))
		{
			extantLabel.gameObject.SetActive(false);
			Object.Destroy((Object)(object)extantLabel);
			extantLabel = null;
		}
	}

	private void Update()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)extantLabel) && Object.op_Implicit((Object)(object)self))
		{
			Vector3 position = self.transform.position + offset;
			if (centered)
			{
				position.x -= ((dfControl)label).Width * 0.02f * 0.5f;
			}
			extantLabel.transform.position = position;
			Vector2 val = Vector2.op_Implicit(dfVectorExtensions.QuantizeFloor(extantLabel.transform.position, ((dfControl)extantLabel.GetComponent<dfLabel>()).PixelsToUnits() / (Pixelator.Instance.ScaleTileScale / Pixelator.Instance.CurrentTileScale)));
			extantLabel.transform.position = Vector3Extensions.WithZ(dfFollowObject.ConvertWorldSpaces(Vector2.op_Implicit(val), GameManager.Instance.MainCameraController.Camera, GameUIRoot.Instance.Manager.RenderCamera), 0f);
			label.text = labelValue;
		}
	}
}
