using UnityEngine;

namespace NevernamedsItems;

public class GameObjectDestroyTimer : MonoBehaviour
{
	public float secondsTillDeath;

	private float timer;

	public GameObjectDestroyTimer()
	{
		secondsTillDeath = 1f;
	}

	private void Start()
	{
		timer = secondsTillDeath;
	}

	private void FixedUpdate()
	{
		if ((Object)(object)((Component)this).gameObject != (Object)null)
		{
			if (timer > 0f)
			{
				timer -= BraveTime.DeltaTime;
			}
			if (timer <= 0f)
			{
				Object.Destroy((Object)(object)((Component)this).gameObject);
			}
		}
	}
}
