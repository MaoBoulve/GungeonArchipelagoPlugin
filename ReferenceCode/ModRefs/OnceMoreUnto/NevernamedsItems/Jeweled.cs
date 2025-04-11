using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public class Jeweled : MonoBehaviour
{
	public HealthHaver hh;

	public Gun m_attachedGun;

	public PlayerController m_player;

	private Vector2 m_cachedSourceVector = Vector2.zero;

	private GameObject instantiatedVFX;

	public bool doPoisonPool;

	public List<Tuple<Bejeweler.GemColour, GameObject>> instantiatedGemVFX = new List<Tuple<Bejeweler.GemColour, GameObject>>();

	public Dictionary<Bejeweler.GemColour, GameObject> colourToVFX = new Dictionary<Bejeweler.GemColour, GameObject>
	{
		{
			Bejeweler.GemColour.BLUE,
			Bejeweler.stickyBlue
		},
		{
			Bejeweler.GemColour.GREEN,
			Bejeweler.stickyGreen
		},
		{
			Bejeweler.GemColour.ORANGE,
			Bejeweler.stickyOrange
		},
		{
			Bejeweler.GemColour.PINK,
			Bejeweler.stickyPink
		},
		{
			Bejeweler.GemColour.RED,
			Bejeweler.stickyRed
		},
		{
			Bejeweler.GemColour.WHITE,
			Bejeweler.stickyWhite
		},
		{
			Bejeweler.GemColour.YELLOW,
			Bejeweler.stickyYellow
		}
	};

	public Dictionary<Bejeweler.GemColour, GameObject> colourToShatter = new Dictionary<Bejeweler.GemColour, GameObject>
	{
		{
			Bejeweler.GemColour.BLUE,
			Bejeweler.hitEffectBlue.effects[0].effects[0].effect
		},
		{
			Bejeweler.GemColour.GREEN,
			Bejeweler.hitEffectGreen.effects[0].effects[0].effect
		},
		{
			Bejeweler.GemColour.ORANGE,
			Bejeweler.hitEffectOrange.effects[0].effects[0].effect
		},
		{
			Bejeweler.GemColour.PINK,
			Bejeweler.hitEffectPink.effects[0].effects[0].effect
		},
		{
			Bejeweler.GemColour.RED,
			Bejeweler.hitEffectRed.effects[0].effects[0].effect
		},
		{
			Bejeweler.GemColour.WHITE,
			Bejeweler.hitEffectWhite.effects[0].effects[0].effect
		},
		{
			Bejeweler.GemColour.YELLOW,
			Bejeweler.hitEffectYellow.effects[0].effects[0].effect
		}
	};

	public void AddGem(GameActor target, Bejeweler.GemColour colour)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)hh == (Object)null)
		{
			hh = ((Component)this).GetComponent<HealthHaver>();
		}
		instantiatedVFX = SpawnManager.SpawnVFX(colourToVFX[colour], ((Component)this).transform.position, Quaternion.identity, true);
		tk2dSprite component = instantiatedVFX.GetComponent<tk2dSprite>();
		tk2dSprite component2 = ((Component)this).GetComponent<tk2dSprite>();
		if ((Object)(object)component != (Object)null && (Object)(object)component2 != (Object)null)
		{
			((tk2dBaseSprite)component2).AttachRenderer((tk2dBaseSprite)(object)component);
			((tk2dBaseSprite)component).HeightOffGround = 1f;
			((tk2dBaseSprite)component).IsPerpendicular = true;
			((tk2dBaseSprite)component).usesOverrideMaterial = true;
		}
		BuffVFXAnimator component3 = instantiatedVFX.GetComponent<BuffVFXAnimator>();
		if ((Object)(object)component3 != (Object)null)
		{
			component3.Initialize(((Component)this).GetComponent<GameActor>());
		}
		instantiatedGemVFX.Add(new Tuple<Bejeweler.GemColour, GameObject>(colour, instantiatedVFX));
	}

	public void ShatterGem(Bejeweler.GemColour colour)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (instantiatedGemVFX.Exists((Tuple<Bejeweler.GemColour, GameObject> x) => x.First == colour))
		{
			Tuple<Bejeweler.GemColour, GameObject> val = instantiatedGemVFX.Find((Tuple<Bejeweler.GemColour, GameObject> x) => x.First == colour);
			GameObject second = val.Second;
			SpawnManager.SpawnVFX(SharedVFX.TenPointsPopup, Vector2.op_Implicit(((tk2dBaseSprite)second.GetComponent<tk2dSprite>()).WorldCenter), Quaternion.identity);
			SpawnManager.SpawnVFX(colourToShatter[colour], Vector2.op_Implicit(((tk2dBaseSprite)second.GetComponent<tk2dSprite>()).WorldCenter), Quaternion.identity);
			Object.Destroy((Object)(object)second);
			instantiatedGemVFX.Remove(val);
		}
	}

	public void ShatterGem(GameObject gem)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		if (instantiatedGemVFX.Exists((Tuple<Bejeweler.GemColour, GameObject> x) => (Object)(object)x.Second == (Object)(object)gem))
		{
			Tuple<Bejeweler.GemColour, GameObject> val = instantiatedGemVFX.Find((Tuple<Bejeweler.GemColour, GameObject> x) => (Object)(object)x.Second == (Object)(object)gem);
			SpawnManager.SpawnVFX(SharedVFX.TenPointsPopup, Vector2.op_Implicit(((tk2dBaseSprite)gem.GetComponent<tk2dSprite>()).WorldCenter), Quaternion.identity);
			SpawnManager.SpawnVFX(colourToShatter[val.First], Vector2.op_Implicit(((tk2dBaseSprite)gem.GetComponent<tk2dSprite>()).WorldCenter), Quaternion.identity);
			Object.Destroy((Object)(object)gem);
			instantiatedGemVFX.Remove(val);
		}
	}
}
