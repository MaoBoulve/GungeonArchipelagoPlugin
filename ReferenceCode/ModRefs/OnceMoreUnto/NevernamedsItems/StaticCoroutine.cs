using System.Collections;
using UnityEngine;

namespace NevernamedsItems;

public class StaticCoroutine : MonoBehaviour
{
	private static StaticCoroutine m_instance;

	private void OnDestroy()
	{
		((MonoBehaviour)m_instance).StopAllCoroutines();
	}

	private void OnApplicationQuit()
	{
		((MonoBehaviour)m_instance).StopAllCoroutines();
	}

	private static StaticCoroutine Build()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		if ((Object)(object)m_instance != (Object)null)
		{
			return m_instance;
		}
		m_instance = (StaticCoroutine)(object)Object.FindObjectOfType(typeof(StaticCoroutine));
		if ((Object)(object)m_instance != (Object)null)
		{
			return m_instance;
		}
		GameObject val = new GameObject("StaticCoroutine");
		val.AddComponent<StaticCoroutine>();
		m_instance = val.GetComponent<StaticCoroutine>();
		if ((Object)(object)m_instance != (Object)null)
		{
			return m_instance;
		}
		ETGModConsole.Log((object)"STATIC COROUTINE: Build did not generate a replacement instance. Method Failed!", false);
		return null;
	}

	public static void Start(string methodName)
	{
		((MonoBehaviour)Build()).StartCoroutine(methodName);
	}

	public static void Start(string methodName, object value)
	{
		((MonoBehaviour)Build()).StartCoroutine(methodName, value);
	}

	public static Coroutine Start(IEnumerator routine)
	{
		return ((MonoBehaviour)Build()).StartCoroutine(routine);
	}
}
