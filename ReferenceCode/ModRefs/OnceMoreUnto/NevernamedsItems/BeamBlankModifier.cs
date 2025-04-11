using System.Collections.Generic;
using Alexandria.Misc;
using UnityEngine;

namespace NevernamedsItems;

public class BeamBlankModifier : MonoBehaviour
{
	public float chancePerTick;

	public float tickDelay;

	private EasyBlankType blankType;

	private float timer;

	private Projectile projectile;

	private BasicBeamController basicBeamController;

	private BeamController beamController;

	private PlayerController owner;

	public BeamBlankModifier()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		blankType = (EasyBlankType)1;
		chancePerTick = 0.25f;
		tickDelay = 1f;
	}

	private void Start()
	{
		timer = tickDelay;
		projectile = ((Component)this).GetComponent<Projectile>();
		beamController = ((Component)this).GetComponent<BeamController>();
		basicBeamController = ((Component)this).GetComponent<BasicBeamController>();
		if (projectile.Owner is PlayerController)
		{
			ref PlayerController reference = ref owner;
			GameActor obj = projectile.Owner;
			reference = (PlayerController)(object)((obj is PlayerController) ? obj : null);
		}
	}

	private void Update()
	{
		if (timer > 0f)
		{
			timer -= BraveTime.DeltaTime;
		}
		if (timer <= 0f)
		{
			DoTick();
			timer = tickDelay;
		}
	}

	private void DoTick()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value < chancePerTick)
		{
			LinkedList<BeamBone> bones = basicBeamController.m_bones;
			LinkedListNode<BeamBone> last = bones.Last;
			Vector2 bonePosition = basicBeamController.GetBonePosition(last.Value);
			Blank(bonePosition);
		}
	}

	private void Blank(Vector2 pos)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (GameObject)ResourceCache.Acquire("Global VFX/BlankVFX_Ghost");
		AkSoundEngine.PostEvent("Play_OBJ_silenceblank_small_01", ((Component)this).gameObject);
		GameObject val2 = new GameObject("silencer");
		SilencerInstance val3 = val2.AddComponent<SilencerInstance>();
		float num = 0.25f;
		val3.TriggerSilencer(pos, 20f, 5f, val, 0f, 3f, 3f, 3f, 30f, 3f, num, owner, true, false);
	}
}
