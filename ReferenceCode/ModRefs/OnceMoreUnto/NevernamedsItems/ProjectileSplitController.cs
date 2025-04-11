using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class ProjectileSplitController : MonoBehaviour
{
	private Projectile parentProjectile;

	private PlayerController parentOwner;

	private bool hasSplit;

	public bool distanceBasedSplit;

	public float distanceTillSplit;

	public bool splitOnEnemy;

	public float splitAngles;

	public int amtToSplitTo;

	public float chanceToSplit;

	public float dmgMultAfterSplit;

	public float sizeMultAfterSplit;

	public int maxRecursionAmount;

	private int curRecursionAmount;

	public ProjectileSplitController()
	{
		distanceTillSplit = 7.5f;
		splitAngles = 35f;
		amtToSplitTo = 0;
		dmgMultAfterSplit = 0.66f;
		sizeMultAfterSplit = 0.8f;
		chanceToSplit = 1f;
	}

	private void Start()
	{
		parentProjectile = ((Component)this).GetComponent<Projectile>();
		parentOwner = ProjectileUtility.ProjectilePlayerOwner(parentProjectile);
	}

	private void Update()
	{
		if ((Object)(object)parentProjectile != (Object)null && distanceBasedSplit && !hasSplit && parentProjectile.GetElapsedDistance() > distanceTillSplit)
		{
			SplitProjectile();
		}
	}

	private void SplitProjectile()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value <= chanceToSplit)
		{
			float num = splitAngles / ((float)amtToSplitTo - 1f);
			float num2 = Vector2Extensions.ToAngle(parentProjectile.Direction);
			float num3 = num2 + splitAngles * 0.5f;
			int num4 = 0;
			for (int i = 0; i < amtToSplitTo; i++)
			{
				float num5 = num3 - num * (float)num4;
				GameObject val = SpawnManager.SpawnProjectile(((Component)parentProjectile).gameObject, Vector2.op_Implicit(parentProjectile.SafeCenter), Quaternion.Euler(0f, 0f, num5), true);
				Projectile component = val.GetComponent<Projectile>();
				if ((Object)(object)component != (Object)null)
				{
					component.Owner = (GameActor)(object)parentOwner;
					component.Shooter = ((BraveBehaviour)parentOwner).specRigidbody;
					ProjectileData baseData = component.baseData;
					baseData.damage *= dmgMultAfterSplit;
					component.RuntimeUpdateScale(sizeMultAfterSplit);
					ProjectileSplitController component2 = ((Component)component).gameObject.GetComponent<ProjectileSplitController>();
					if (Object.op_Implicit((Object)(object)component2))
					{
						if (curRecursionAmount < maxRecursionAmount)
						{
							component2.curRecursionAmount = curRecursionAmount + 1;
						}
						else
						{
							Object.Destroy((Object)(object)component2);
						}
					}
				}
				num4++;
			}
			Object.Destroy((Object)(object)((Component)parentProjectile).gameObject);
		}
		hasSplit = true;
	}
}
