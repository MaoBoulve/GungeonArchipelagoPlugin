using System;
using UnityEngine;

namespace NevernamedsItems;

public class NPCShootReactor : MonoBehaviour
{
	public Action<Projectile> OnShot;
}
