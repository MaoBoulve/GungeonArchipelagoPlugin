using System.Reflection;
using UnityEngine;

namespace NevernamedsItems;

public class JammedLordController : MonoBehaviour
{
	private string m_cachedAttack;

	private SuperReaperController m_controller;

	private static FieldInfo info = typeof(SuperReaperController).GetField("c_particlesPerSecond", BindingFlags.Instance | BindingFlags.NonPublic);

	public void Initialize(SuperReaperController controller)
	{
		m_controller = controller;
		m_cachedAttack = controller.BulletScript.scriptTypeName;
		tk2dBaseSprite component = ((Component)this).GetComponent<tk2dBaseSprite>();
		component.usesOverrideMaterial = true;
		Material material = ((BraveBehaviour)component).renderer.material;
		material.shader = ShaderCache.Acquire("Brave/LitCutoutUberPhantom");
		material.SetFloat("_PhantomGradientScale", 0.75f);
		material.SetFloat("_PhantomContrastPower", 1.3f);
		controller.BulletScript.scriptTypeName = typeof(JammedCircleBurst12).AssemblyQualifiedName;
		controller.MinSpeed *= 1.5f;
		controller.MaxSpeed *= 1.5f;
		SetParticlesPerSecond(GetParticlesPerSecond() * 2);
	}

	public void Uninitialize()
	{
		m_controller.BulletScript.scriptTypeName = m_cachedAttack;
		tk2dBaseSprite component = ((Component)this).GetComponent<tk2dBaseSprite>();
		component.usesOverrideMaterial = false;
		SuperReaperController controller = m_controller;
		controller.MinSpeed /= 1.5f;
		SuperReaperController controller2 = m_controller;
		controller2.MaxSpeed /= 1.5f;
		SetParticlesPerSecond(GetParticlesPerSecond() / 2);
		Object.Destroy((Object)(object)this);
	}

	private int GetParticlesPerSecond()
	{
		return (int)info.GetValue(m_controller);
	}

	private void SetParticlesPerSecond(int value)
	{
		info.SetValue(m_controller, value);
	}
}
