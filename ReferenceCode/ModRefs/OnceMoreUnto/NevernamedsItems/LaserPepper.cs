using System;
using System.Collections.Generic;
using Alexandria.Misc;
using Dungeonator;
using UnityEngine;

namespace NevernamedsItems;

public class LaserPepper : PassiveItem
{
	private float timer;

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<LaserPepper>("Laser Pepper", "Burns the Tongue", "A delectable condemnation of the scientific drive to create spicier and spicier peppers. \n\nThey were so preoccupied with whether they could, they didn't stop to think if they should.", "laserpepper_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)3;
	}

	public override void Update()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			if (timer <= 0f)
			{
				timer = Random.Range(1f, 6f);
				if ((Object)(object)MathsAndLogicHelper.GetNearestEnemyToPosition(((GameActor)((PassiveItem)this).Owner).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null) != (Object)null && Vector2.Distance(Vector2.op_Implicit(MathsAndLogicHelper.GetNearestEnemyToPosition(((GameActor)((PassiveItem)this).Owner).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null).Position), ((GameActor)((PassiveItem)this).Owner).CenterPosition) <= 5f)
				{
					AIActor nearestEnemyToPosition = MathsAndLogicHelper.GetNearestEnemyToPosition(((GameActor)((PassiveItem)this).Owner).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null);
					Object.Instantiate<GameObject>(SharedVFX.LaserSlashUndertale, Vector2.op_Implicit(((BraveBehaviour)nearestEnemyToPosition).sprite.WorldCenter), Quaternion.identity);
					if (Object.op_Implicit((Object)(object)nearestEnemyToPosition) && (!Object.op_Implicit((Object)(object)((BraveBehaviour)nearestEnemyToPosition).healthHaver) || !((BraveBehaviour)nearestEnemyToPosition).healthHaver.IsBoss))
					{
						((MonoBehaviour)GameManager.Instance.Dungeon).StartCoroutine(LaserKnife.HandleEnemyDeath(nearestEnemyToPosition, MathsAndLogicHelper.GetVectorToNearestEnemy(((GameActor)((PassiveItem)this).Owner).CenterPosition, true, (ActiveEnemyType)1, (List<AIActor>)null, (Func<AIActor, bool>)null)));
					}
					else if (Object.op_Implicit((Object)(object)nearestEnemyToPosition) && Object.op_Implicit((Object)(object)((BraveBehaviour)nearestEnemyToPosition).healthHaver) && ((BraveBehaviour)nearestEnemyToPosition).healthHaver.IsBoss)
					{
						((BraveBehaviour)nearestEnemyToPosition).healthHaver.ApplyDamage(100f, Vector2.zero, "Laser Pepper", (CoreDamageTypes)0, (DamageCategory)5, true, (PixelCollider)null, true);
					}
					AkSoundEngine.PostEvent("Play_WPN_bountyhunterarm_shot_03", ((Component)((PassiveItem)this).Owner).gameObject);
				}
			}
			else
			{
				timer -= BraveTime.DeltaTime;
			}
		}
		((PassiveItem)this).Update();
	}
}
