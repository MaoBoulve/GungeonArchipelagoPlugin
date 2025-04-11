using UnityEngine;

namespace NevernamedsItems;

public class HandGunCardBullet : MonoBehaviour
{
	public enum CardValue
	{
		ACE,
		QUEEN,
		KING,
		KNAVE,
		GENERIC
	}

	public enum CardSuit
	{
		HEARTS,
		DIAMONDS,
		SPADES,
		CLUBS,
		OTHER
	}

	public CardSuit Suit;

	public CardValue Value;
}
