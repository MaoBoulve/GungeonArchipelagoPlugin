using System.Collections.Generic;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Lefthandedness : PassiveItem
{
	private class BeamIsBenefittingFromLeftHand : MonoBehaviour
	{
	}

	public static void Init()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Lefthandedness>("Lefthandedness", "Shell'tan's Sign", "Empowers bullets when firing to the left.\n\nFor some unknown reason, left-handed people are statistically better at all known branches of Ammomancy.", "lefthandedness_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).CanBeDropped = true;
		((PickupObject)val).quality = (ItemQuality)2;
	}

	private void PostProcessProj(Projectile bullet, float num)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)bullet) && ((GameActor)((PassiveItem)this).Owner).SpriteFlipped)
		{
			ProjectileData baseData = bullet.baseData;
			baseData.damage *= 1.3f;
			bullet.RuntimeUpdateScale(1.2f);
			if (CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Sinister Handed"))
			{
				AdvancedTransmogrifyBehaviour orAddComponent = GameObjectExtensions.GetOrAddComponent<AdvancedTransmogrifyBehaviour>(((Component)bullet).gameObject);
				TransmogData item = new TransmogData
				{
					TargetGuids = new List<string> { "76bc43539fc24648bff4568c75c686d1" },
					TransmogChance = 0.06f,
					identifier = "SinisterHanded"
				};
				orAddComponent.TransmogDataList.Add(item);
			}
		}
	}

	private void ProcessBeam(BeamController bem)
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && Object.op_Implicit((Object)(object)bem))
		{
			GameObject gameObject = ((Component)bem).gameObject;
			Projectile component = gameObject.GetComponent<Projectile>();
			BeamIsBenefittingFromLeftHand component2 = gameObject.GetComponent<BeamIsBenefittingFromLeftHand>();
			if (Object.op_Implicit((Object)(object)component2) && !((GameActor)((PassiveItem)this).Owner).SpriteFlipped)
			{
				ProjectileData baseData = component.baseData;
				baseData.damage /= 1.3f;
				Object.Destroy((Object)(object)component2);
			}
			else if (!Object.op_Implicit((Object)(object)component2) && ((GameActor)((PassiveItem)this).Owner).SpriteFlipped)
			{
				ProjectileData baseData2 = component.baseData;
				baseData2.damage *= 1.3f;
				gameObject.AddComponent<BeamIsBenefittingFromLeftHand>();
			}
		}
	}

	public override void Pickup(PlayerController player)
	{
		((PassiveItem)this).Pickup(player);
		player.PostProcessProjectile += PostProcessProj;
		player.PostProcessBeamChanceTick += ProcessBeam;
	}

	public override DebrisObject Drop(PlayerController player)
	{
		player.PostProcessProjectile -= PostProcessProj;
		player.PostProcessBeamChanceTick -= ProcessBeam;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			((PassiveItem)this).Owner.PostProcessProjectile -= PostProcessProj;
			((PassiveItem)this).Owner.PostProcessBeamChanceTick -= ProcessBeam;
		}
		((PassiveItem)this).OnDestroy();
	}
}
