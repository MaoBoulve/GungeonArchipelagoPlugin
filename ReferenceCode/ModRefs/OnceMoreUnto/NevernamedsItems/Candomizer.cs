using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class Candomizer : BraveBehaviour
{
	public int minCandles = 0;

	public int maxCandles = 4;

	public string candleIdentifier;

	public float chanceForOneToBeKnockedOver;

	private List<GameObject> candles;

	private void Start()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		candles = new List<GameObject>();
		foreach (Transform item in ((BraveBehaviour)this).transform)
		{
			Transform val = item;
			if (Object.op_Implicit((Object)(object)val) && Object.op_Implicit((Object)(object)((Component)val).gameObject) && ((Object)((Component)val).gameObject).name.StartsWith(candleIdentifier))
			{
				candles.Add(((Component)val).gameObject);
			}
		}
		int num = Random.Range(minCandles, maxCandles + 1);
		int num2 = candles.Count - num;
		if (num2 > 0)
		{
			for (int i = 0; i < num2; i++)
			{
				if (candles.Count > 0)
				{
					GameObject val2 = BraveUtility.RandomElement<GameObject>(candles);
					candles.Remove(val2);
					Object.Destroy((Object)(object)val2);
				}
			}
		}
		if (Random.value <= chanceForOneToBeKnockedOver && candles.Count > 0)
		{
			GameObject val3 = BraveUtility.RandomElement<GameObject>(candles);
			if (Object.op_Implicit((Object)(object)val3.GetComponent<PlacedObjectRotator>()))
			{
				val3.GetComponent<PlacedObjectRotator>().DoRotation();
			}
		}
	}
}
