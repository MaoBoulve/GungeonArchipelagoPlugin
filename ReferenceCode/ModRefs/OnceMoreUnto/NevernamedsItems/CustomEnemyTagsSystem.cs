using UnityEngine;

namespace NevernamedsItems;

public class CustomEnemyTagsSystem : MonoBehaviour
{
	public bool isKalibersEyeMinion;

	public bool isGundertaleFriendly;

	public bool ignoreForGoodMimic;

	public CustomEnemyTagsSystem()
	{
		isKalibersEyeMinion = false;
		ignoreForGoodMimic = false;
		isGundertaleFriendly = false;
	}
}
