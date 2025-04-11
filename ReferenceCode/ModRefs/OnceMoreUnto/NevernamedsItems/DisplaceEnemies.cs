using System;
using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class DisplaceEnemies : MonoBehaviour
{
	public static List<string> DisplacerIgnoreList = new List<string> { EnemyGuidDatabase.Entries["super_space_turtle_dummy"] };

	private Projectile m_projectile;

	private void Start()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			if ((Object)(object)m_projectile != (Object)null)
			{
				SpeculativeRigidbody specRigidbody = ((BraveBehaviour)m_projectile).specRigidbody;
				specRigidbody.OnPreRigidbodyCollision = (OnPreRigidbodyCollisionDelegate)Delegate.Combine((Delegate)(object)specRigidbody.OnPreRigidbodyCollision, (Delegate)new OnPreRigidbodyCollisionDelegate(OnPreCollision));
			}
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void OnPreCollision(SpeculativeRigidbody myRigidBody, PixelCollider myPixelCollider, SpeculativeRigidbody otherRigidBody, PixelCollider otherPixelCollider)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((Object)(object)otherRigidBody != (Object)null) || !((Object)(object)((BraveBehaviour)otherRigidBody).aiActor != (Object)null) || !((Object)(object)((BraveBehaviour)otherRigidBody).healthHaver != (Object)null) || ((BraveBehaviour)otherRigidBody).healthHaver.IsBoss || !((BraveBehaviour)otherRigidBody).healthHaver.IsVulnerable || AlexandriaTags.HasTag(((BraveBehaviour)otherRigidBody).aiActor, "mimic") || DisplacerIgnoreList.Contains(((BraveBehaviour)otherRigidBody).aiActor.EnemyGuid) || !((Object)(object)((Component)otherRigidBody).GetComponent<CompanionController>() == (Object)null) || !((Object)(object)((BraveBehaviour)otherRigidBody).aiActor.CompanionOwner == (Object)null))
			{
				return;
			}
			AkSoundEngine.PostEvent("Play_OBJ_chestwarp_use_01", ((Component)this).gameObject);
			PickupObject byId = PickupObjectDatabase.GetById(573);
			GameObject teleportVFX = ((ChestTeleporterItem)((byId is ChestTeleporterItem) ? byId : null)).TeleportVFX;
			SpawnManager.SpawnVFX(teleportVFX, Vector2.op_Implicit(((BraveBehaviour)otherRigidBody).sprite.WorldCenter), Quaternion.identity, true);
			float currentHealth = ((BraveBehaviour)otherRigidBody).healthHaver.GetCurrentHealth();
			float num = 30f;
			float num2 = 0f;
			if ((Object)(object)m_projectile.Owner != (Object)null && m_projectile.Owner is PlayerController)
			{
				GameActor owner = m_projectile.Owner;
				PlayerController val = (PlayerController)(object)((owner is PlayerController) ? owner : null);
				num *= val.stats.GetStatValue((StatType)5);
				if (CustomSynergies.PlayerHasActiveSynergy(val, "Delete This"))
				{
					num2 = 0.25f;
				}
			}
			if (currentHealth > num && num2 < Random.value)
			{
				listOfDisplacedEnemies.DisplacedEnemies.Add(new DisplacedEnemy
				{
					GUID = ((BraveBehaviour)otherRigidBody).aiActor.EnemyGuid,
					HEALTH = currentHealth - num,
					ISJAMMED = ((BraveBehaviour)otherRigidBody).aiActor.IsBlackPhantom
				});
			}
			if (Object.op_Implicit((Object)(object)((Component)otherRigidBody).gameObject.GetComponent<ExplodeOnDeath>()))
			{
				Object.Destroy((Object)(object)((Component)otherRigidBody).gameObject.GetComponent<ExplodeOnDeath>());
			}
			((BraveBehaviour)otherRigidBody).aiActor.EraseFromExistenceWithRewards(true);
			m_projectile.DieInAir(false, true, true, false);
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}
}
