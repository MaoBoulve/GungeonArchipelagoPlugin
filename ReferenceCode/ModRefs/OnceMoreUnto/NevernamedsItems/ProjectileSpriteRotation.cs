using UnityEngine;

namespace NevernamedsItems;

internal class ProjectileSpriteRotation : MonoBehaviour
{
	private Projectile self;

	public float RotPerFrame = 1f;

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
	}

	private void FixedUpdate()
	{
		((Component)this).transform.Rotate(0f, 0f, RotPerFrame);
	}
}
