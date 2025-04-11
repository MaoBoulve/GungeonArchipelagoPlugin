using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class InstantTeleportToPlayerCursorBehav : MonoBehaviour
{
	private Projectile m_projectile;

	private PlayerController owner;

	public float procChance;

	public InstantTeleportToPlayerCursorBehav()
	{
		procChance = 1f;
	}

	private void Start()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		m_projectile = ((Component)this).GetComponent<Projectile>();
		if (m_projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref owner;
			GameActor obj = m_projectile.Owner;
			reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
		}
		if (Object.op_Implicit((Object)(object)owner) && Random.value <= procChance)
		{
			((BraveBehaviour)m_projectile).specRigidbody.Position = new Position(PlayerUtility.GetCursorPosition(owner, 30f));
		}
	}
}
