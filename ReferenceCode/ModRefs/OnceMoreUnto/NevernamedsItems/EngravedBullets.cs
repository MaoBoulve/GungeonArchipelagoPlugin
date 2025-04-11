using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class EngravedBullets : PassiveItem
{
	private string enemyToKillEngraved = UnengravedBullets.engravedEnemy;

	public static void Init()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<EngravedBullets>("Engraved Bullets", "Bullet with your name on it", "These bullets are specially made to absolutely annihilate one specific foe.\n\nThey may run. They may hide. But you will find them.", "engravedbullets_icon", assetbundle: true);
		AlexandriaTags.SetTag(val, "bullet_modifier");
		val.quality = (ItemQuality)(-100);
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProjectile;
		player.PostProcessBeam += PostProcessBeam;
	}

	private void PostProcessBeam(BeamController sourceBeam)
	{
		if (Object.op_Implicit((Object)(object)((BraveBehaviour)sourceBeam).projectile))
		{
			PostProcessProjectile(((BraveBehaviour)sourceBeam).projectile, 1f);
		}
	}

	private void PostProcessProjectile(Projectile sourceProjectile, float effectChanceScalar)
	{
		ProjectileInstakillBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<ProjectileInstakillBehaviour>(((Component)sourceProjectile).gameObject);
		orAddComponent.enemyGUIDsToKill.Add(enemyToKillEngraved);
	}

	public override void DisableEffect(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProjectile;
		player.PostProcessBeam -= PostProcessBeam;
		((PassiveItem)this).DisableEffect(player);
	}
}
