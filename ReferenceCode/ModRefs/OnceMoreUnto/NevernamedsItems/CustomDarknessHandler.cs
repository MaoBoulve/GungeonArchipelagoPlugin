using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class CustomDarknessHandler : MonoBehaviour
{
	public static OverridableBool shouldBeDark = new OverridableBool(false);

	public static OverridableBool shouldBeLightOverride = new OverridableBool(false);

	public static bool isDark = false;

	public static Shader DarknessEffectShader;

	public float FlashlightAngle = 25f;

	private static Material m_material;

	private void Start()
	{
		GameObject val = LoadHelper.LoadAssetFromAnywhere<GameObject>("_ChallengeManager");
		ChallengeModifier challenge = val.GetComponent<ChallengeManager>().PossibleChallenges[5].challenge;
		DarknessEffectShader = ((DarknessChallengeModifier)((challenge is DarknessChallengeModifier) ? challenge : null)).DarknessEffectShader;
	}

	private bool ReturnShouldBeDark()
	{
		if (shouldBeDark.Value && !shouldBeLightOverride.Value && (Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null && !GameManager.Instance.IsFoyer)
		{
			return true;
		}
		return false;
	}

	private void Update()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Invalid comparison between Unknown and I4
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)GameManager.Instance) || !Object.op_Implicit((Object)(object)GameManager.Instance.MainCameraController) || Dungeon.IsGenerating)
		{
			return;
		}
		if (ReturnShouldBeDark() && !isDark)
		{
			EnableDarkness();
		}
		else if (!ReturnShouldBeDark() && isDark)
		{
			DisableDarkness();
		}
		if (!isDark)
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)Pixelator.Instance) && (Object)(object)Pixelator.Instance.AdditionalCoreStackRenderPass == (Object)null)
		{
			m_material = new Material(DarknessEffectShader);
			Pixelator.Instance.AdditionalCoreStackRenderPass = m_material;
		}
		if (!((Object)(object)m_material != (Object)null) || !((Object)(object)GameManager.Instance.PrimaryPlayer != (Object)null) || !((Object)(object)GameManager.Instance.MainCameraController != (Object)null) || !((Object)(object)GameManager.Instance.MainCameraController.Camera != (Object)null))
		{
			return;
		}
		float num = ((GameActor)GameManager.Instance.PrimaryPlayer).FacingDirection;
		if (num > 270f)
		{
			num -= 360f;
		}
		if (num < -270f)
		{
			num += 360f;
		}
		m_material.SetFloat("_ConeAngle", FlashlightAngle);
		Vector4 centerPointInScreenUV = GetCenterPointInScreenUV(((GameActor)GameManager.Instance.PrimaryPlayer).CenterPosition);
		centerPointInScreenUV.z = num;
		Vector4 val = centerPointInScreenUV;
		if ((int)GameManager.Instance.CurrentGameType == 1)
		{
			num = ((GameActor)GameManager.Instance.SecondaryPlayer).FacingDirection;
			if (num > 270f)
			{
				num -= 360f;
			}
			if (num < -270f)
			{
				num += 360f;
			}
			val = GetCenterPointInScreenUV(((GameActor)GameManager.Instance.SecondaryPlayer).CenterPosition);
			val.z = num;
		}
		m_material.SetVector("_Player1ScreenPosition", centerPointInScreenUV);
		m_material.SetVector("_Player2ScreenPosition", val);
	}

	private static Vector4 GetCenterPointInScreenUV(Vector2 centerPoint)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = GameManager.Instance.MainCameraController.Camera.WorldToViewportPoint(Vector2Extensions.ToVector3ZUp(centerPoint, 0f));
		return new Vector4(val.x, val.y, 0f, 0f);
	}

	private void EnableDarkness()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (!isDark)
		{
			m_material = new Material(DarknessEffectShader);
			Pixelator.Instance.AdditionalCoreStackRenderPass = m_material;
			isDark = true;
		}
	}

	private void DisableDarkness()
	{
		if (isDark)
		{
			if (Object.op_Implicit((Object)(object)Pixelator.Instance))
			{
				Pixelator.Instance.AdditionalCoreStackRenderPass = null;
			}
			isDark = false;
		}
	}
}
