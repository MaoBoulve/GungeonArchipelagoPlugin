using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class GunjurersBelt : TargetedAttackPlayerItem
{
	public static void Init()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		PickupObject obj = ItemSetup.NewItem<GunjurersBelt>("Gunjurers Belt", "Poof!", "Knitted by an Apprentice Gunjurer as part of his ammomantic exams, it allows the bearer to slip beyond the curtain.", "gunjurersbelt_icon", assetbundle: true);
		TargetedAttackPlayerItem val = (TargetedAttackPlayerItem)(object)((obj is TargetedAttackPlayerItem) ? obj : null);
		ItemBuilder.SetCooldownType((PlayerItem)(object)val, (CooldownType)0, 5f);
		((PlayerItem)val).consumable = false;
		((PickupObject)val).quality = (ItemQuality)1;
		val.doesStrike = false;
		val.doesGoop = false;
		val.DoScreenFlash = false;
		ref GameObject reticleQuad = ref val.reticleQuad;
		PickupObject byId = PickupObjectDatabase.GetById(443);
		reticleQuad = ((TargetedAttackPlayerItem)((byId is TargetedAttackPlayerItem) ? byId : null)).reticleQuad;
	}

	public override void DoActiveEffect(PlayerController user)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		tk2dBaseSprite extantReticleQuad = base.m_extantReticleQuad;
		Vector2 worldCenter = extantReticleQuad.WorldCenter;
		TeleportPlayerToCursorPosition.StartTeleport(user, worldCenter);
		((TargetedAttackPlayerItem)this).DoActiveEffect(user);
	}

	public override bool CanBeUsed(PlayerController user)
	{
		return ((PlayerItem)this).CanBeUsed(user);
	}
}
