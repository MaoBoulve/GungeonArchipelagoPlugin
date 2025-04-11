using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

public class Rubedo : PassiveItem
{
	private float timer;

	public static void Init()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<Rubedo>("Rubedo", "Absolution", "Periodically heals from the pool of stored hearts.\n\nOnce the Citrinitas stage of the Prime Materia matures into it's reddish hues, it has achieved completion. The Masterwork. THE Magnum Opus. Perfection.", "rubedo_icon", assetbundle: true);
		PassiveItem val = (PassiveItem)(object)((obj is PassiveItem) ? obj : null);
		((PickupObject)val).quality = (ItemQuality)3;
		ItemBuilder.AddToSubShop((PickupObject)(object)val, (ShopType)0, 1f);
	}

	public override void Update()
	{
		if (!Object.op_Implicit((Object)(object)((PassiveItem)this).Owner))
		{
			return;
		}
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (timer <= 0f)
		{
			if (Random.value <= 0.5f)
			{
				DoHeal();
			}
			timer = 5f;
		}
	}

	public override void Pickup(PlayerController player)
	{
		if (!base.m_pickedUpThisRun)
		{
			HeartDispenser.CurrentHalfHeartsStored += 2;
		}
		timer = 5f;
		GameManager.Instance.OnNewLevelFullyLoaded += NewFloor;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= NewFloor;
		return ((PassiveItem)this).Drop(player);
	}

	public override void OnDestroy()
	{
		GameManager.Instance.OnNewLevelFullyLoaded -= NewFloor;
		((PassiveItem)this).OnDestroy();
	}

	private void NewFloor()
	{
		HeartDispenser.CurrentHalfHeartsStored += 2;
		if (Object.op_Implicit((Object)(object)((PassiveItem)this).Owner) && CustomSynergies.PlayerHasActiveSynergy(((PassiveItem)this).Owner, "Magnum Opus"))
		{
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyHealing(1E+13f);
		}
	}

	private void DoHeal()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (HeartDispenser.CurrentHalfHeartsStored > 0 && ((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.GetCurrentHealthPercentage() < 1f)
		{
			AkSoundEngine.PostEvent("Play_OBJ_heart_heal_01", ((Component)((PassiveItem)this).Owner).gameObject);
			((GameActor)((PassiveItem)this).Owner).PlayEffectOnActor(((Component)PickupObjectDatabase.GetById(73)).GetComponent<HealthPickup>().healVFX, Vector3.zero, true, false, false);
			((BraveBehaviour)((PassiveItem)this).Owner).healthHaver.ApplyHealing(0.5f);
			HeartDispenser.CurrentHalfHeartsStored -= 1;
		}
	}
}
