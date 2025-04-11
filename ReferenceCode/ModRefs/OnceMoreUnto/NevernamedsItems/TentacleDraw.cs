using UnityEngine;

namespace NevernamedsItems;

public class TentacleDraw : MonoBehaviour
{
	public Transform Attach1;

	public Vector2 Attach1Offset;

	public Transform Attach2;

	public Vector2 Attach2Offset;

	private Mesh m_mesh;

	private Vector3[] m_vertices;

	private MeshFilter m_stringFilter;

	public void Initialize(Transform t1, Transform t2)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		Attach1 = t1;
		Attach2 = t2;
		m_mesh = new Mesh();
		m_vertices = (Vector3[])(object)new Vector3[20];
		m_mesh.vertices = m_vertices;
		int[] array = new int[54];
		Vector2[] uv = (Vector2[])(object)new Vector2[20];
		int num = 0;
		for (int i = 0; i < 9; i++)
		{
			array[i * 6] = num;
			array[i * 6 + 1] = num + 2;
			array[i * 6 + 2] = num + 1;
			array[i * 6 + 3] = num + 2;
			array[i * 6 + 4] = num + 3;
			array[i * 6 + 5] = num + 1;
			num += 2;
		}
		m_mesh.triangles = array;
		m_mesh.uv = uv;
		GameObject val = new GameObject("cableguy");
		m_stringFilter = val.AddComponent<MeshFilter>();
		MeshRenderer val2 = val.AddComponent<MeshRenderer>();
		_003F val3 = val2;
		Object obj = BraveResources.Load("Global VFX/WhiteMaterial", ".mat");
		((Renderer)val3).material = (Material)(object)((obj is Material) ? obj : null);
		((Renderer)val2).material.SetColor("_OverrideColor", Color32.op_Implicit(new Color32((byte)166, (byte)10, (byte)10, byte.MaxValue)));
		m_stringFilter.mesh = m_mesh;
	}

	private void LateUpdate()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)Attach1) && Object.op_Implicit((Object)(object)Attach2))
		{
			Vector3 val = Vector2Extensions.ToVector3ZisY(Vector3Extensions.XY(Attach1.position), -3f) + Vector2Extensions.ToVector3ZisY(Attach1Offset, 0f);
			Vector3 val2 = Vector2Extensions.ToVector3ZisY(Vector3Extensions.XY(Attach2.position), -3f) + Vector2Extensions.ToVector3ZisY(Attach2Offset, 0f);
			BuildMeshAlongCurve(Vector2.op_Implicit(val), Vector2.op_Implicit(val), Vector2.op_Implicit(val2 + new Vector3(0f, -2f, -2f)), Vector2.op_Implicit(val2));
			m_mesh.vertices = m_vertices;
			m_mesh.RecalculateBounds();
			m_mesh.RecalculateNormals();
		}
	}

	private void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)m_stringFilter))
		{
			Object.Destroy((Object)(object)((Component)m_stringFilter).gameObject);
		}
	}

	private void BuildMeshAlongCurve(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float meshWidth = 1f / 32f)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] vertices = m_vertices;
		Vector2? val = null;
		for (int i = 0; i < 10; i++)
		{
			Vector2 val2 = BraveMathCollege.CalculateBezierPoint((float)i / 9f, p0, p1, p2, p3);
			Vector2? val3 = ((i != 9) ? new Vector2?(BraveMathCollege.CalculateBezierPoint((float)i / 9f, p0, p1, p2, p3)) : ((Vector2?)null));
			Vector2 val4 = Vector2.zero;
			Vector2 val6;
			if (val.HasValue)
			{
				Vector2 val5 = val4;
				val6 = Vector3Extensions.XY(Quaternion.Euler(0f, 0f, 90f) * Vector2.op_Implicit(val2 - val.Value));
				val4 = val5 + ((Vector2)(ref val6)).normalized;
			}
			if (val3.HasValue)
			{
				Vector2 val7 = val4;
				val6 = Vector3Extensions.XY(Quaternion.Euler(0f, 0f, 90f) * Vector2.op_Implicit(val3.Value - val2));
				val4 = val7 + ((Vector2)(ref val6)).normalized;
			}
			val4 = ((Vector2)(ref val4)).normalized;
			vertices[i * 2] = Vector2Extensions.ToVector3ZisY(val2 + val4 * meshWidth, 0f);
			vertices[i * 2 + 1] = Vector2Extensions.ToVector3ZisY(val2 + -val4 * meshWidth, 0f);
			val = val2;
		}
	}
}
