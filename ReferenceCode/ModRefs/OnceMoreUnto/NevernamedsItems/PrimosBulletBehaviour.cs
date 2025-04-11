using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class PrimosBulletBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public void Start()
	{
		m_projectile = ((Component)this).GetComponent<Projectile>();
		RoomHandler absoluteRoomFromProjectile = MiscToolbox.GetAbsoluteRoomFromProjectile(m_projectile);
		if (absoluteRoomFromProjectile != Primos1.lastFiredRoom)
		{
			ProjectileData baseData = m_projectile.baseData;
			baseData.speed *= 0.5f;
			ProjectileData baseData2 = m_projectile.baseData;
			baseData2.damage *= 6.3f;
			PierceProjModifier orAddComponent = GameObjectExtensions.GetOrAddComponent<PierceProjModifier>(((Component)m_projectile).gameObject);
			orAddComponent.penetration = 1000;
			BounceProjModifier orAddComponent2 = GameObjectExtensions.GetOrAddComponent<BounceProjModifier>(((Component)m_projectile).gameObject);
			orAddComponent2.numberOfBounces = 1;
			m_projectile.RuntimeUpdateScale(2f);
			m_projectile.UpdateSpeed();
			Primos1.lastFiredRoom = absoluteRoomFromProjectile;
		}
	}
}
