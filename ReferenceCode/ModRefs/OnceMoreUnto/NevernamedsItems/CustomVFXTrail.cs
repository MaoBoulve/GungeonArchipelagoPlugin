using UnityEngine;

namespace NevernamedsItems;

public class CustomVFXTrail : MonoBehaviour
{
	public enum Anchor
	{
		ChildTransform,
		Center
	}

	public VFXPool VFX;

	public float timeBetweenSpawns;

	private float timer;

	public float fixedHeightOffGround;

	public float heightOffset;

	public bool inheritVelocity;

	public bool inheritRotation;

	public bool parentSelf;

	public Anchor anchor;

	private Projectile self;

	public CustomVFXTrail()
	{
		anchor = Anchor.Center;
		timeBetweenSpawns = 0.1f;
		fixedHeightOffGround = -1f;
		inheritVelocity = false;
		heightOffset = 0f;
		parentSelf = false;
		inheritRotation = false;
	}

	private void Start()
	{
		self = ((Component)this).GetComponent<Projectile>();
		timer = timeBetweenSpawns;
		if (Object.op_Implicit((Object)(object)self) && fixedHeightOffGround == -1f)
		{
			if (Projectile.CurrentProjectileDepth != 0.8f)
			{
				fixedHeightOffGround = Projectile.CurrentProjectileDepth;
			}
			else
			{
				fixedHeightOffGround = (Object.op_Implicit((Object)(object)((BraveBehaviour)self).sprite) ? ((BraveBehaviour)self).sprite.HeightOffGround : 0f);
			}
		}
		fixedHeightOffGround += heightOffset;
	}

	private void Update()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)self))
		{
			return;
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
			return;
		}
		if (VFX != null)
		{
			VFX.SpawnAtPosition(GetAnchoredPosition(), inheritRotation ? Vector2Extensions.ToAngle(self.Direction) : 0f, parentSelf ? ((BraveBehaviour)self).transform : null, (Vector2?)Vector2.zero, inheritVelocity ? new Vector2?(((BraveBehaviour)self).specRigidbody.Velocity) : new Vector2?(Vector2.zero), (float?)fixedHeightOffGround, false, (SpawnMethod)null, (tk2dBaseSprite)null, false);
		}
		timer = timeBetweenSpawns;
	}

	private Vector3 GetAnchoredPosition()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2.op_Implicit(self.LastPosition);
		switch (anchor)
		{
		case Anchor.Center:
			if ((Object)(object)((BraveBehaviour)self).specRigidbody != (Object)null)
			{
				val = ((BraveBehaviour)self).specRigidbody.UnitCenter;
			}
			break;
		case Anchor.ChildTransform:
			if ((Object)(object)((BraveBehaviour)self).transform.Find("CustomVFXSpawnpoint") != (Object)null)
			{
				val = Vector2.op_Implicit(((BraveBehaviour)self).transform.Find("CustomVFXSpawnpoint").position);
			}
			break;
		}
		return Vector2.op_Implicit(val);
	}
}
