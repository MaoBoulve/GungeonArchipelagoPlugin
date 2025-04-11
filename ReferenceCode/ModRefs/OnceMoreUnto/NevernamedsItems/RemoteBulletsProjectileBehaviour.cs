using System;
using Gungeon;
using InControl;
using UnityEngine;

namespace NevernamedsItems;

public class RemoteBulletsProjectileBehaviour : MonoBehaviour
{
	private Projectile m_projectile;

	public float trackingSpeed = 45f;

	public float trackingTime = 6f;

	[CurveRange(0f, 0f, 1f, 1f)]
	public AnimationCurve trackingCurve;

	public RemoteBulletsProjectileBehaviour()
	{
		trackingSpeed = ((Component)Game.Items["remote_bullets"]).GetComponent<GuidedBulletsPassiveItem>().trackingSpeed;
		trackingCurve = ((Component)Game.Items["remote_bullets"]).GetComponent<GuidedBulletsPassiveItem>().trackingCurve;
		trackingTime = ((Component)Game.Items["remote_bullets"]).GetComponent<GuidedBulletsPassiveItem>().trackingTime;
	}

	public void Start()
	{
		try
		{
			m_projectile = ((Component)this).GetComponent<Projectile>();
			Projectile projectile = m_projectile;
			projectile.PreMoveModifiers = (Action<Projectile>)Delegate.Combine(projectile.PreMoveModifiers, new Action<Projectile>(PreMoveProjectileModifier));
		}
		catch (Exception ex)
		{
			ETGModConsole.Log((object)ex.Message, false);
			ETGModConsole.Log((object)ex.StackTrace, false);
		}
	}

	private void PreMoveProjectileModifier(Projectile p)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)p) || !(p.Owner is PlayerController))
		{
			return;
		}
		GameActor owner = p.Owner;
		BraveInput instanceForPlayer = BraveInput.GetInstanceForPlayer(((PlayerController)((owner is PlayerController) ? owner : null)).PlayerIDX);
		if ((Object)(object)instanceForPlayer == (Object)null)
		{
			return;
		}
		Vector2 zero = Vector2.zero;
		if (instanceForPlayer.IsKeyboardAndMouse(false))
		{
			GameActor owner2 = p.Owner;
			zero = Vector3Extensions.XY(((PlayerController)((owner2 is PlayerController) ? owner2 : null)).unadjustedAimPoint) - ((BraveBehaviour)p).specRigidbody.UnitCenter;
		}
		else
		{
			if (instanceForPlayer.ActiveActions == null)
			{
				return;
			}
			zero = ((TwoAxisInputControl)instanceForPlayer.ActiveActions.Aim).Vector;
		}
		float num = Vector2Extensions.ToAngle(zero);
		float num2 = BraveMathCollege.Atan2Degrees(p.Direction);
		float num3 = 0f;
		if (p.ElapsedTime < trackingTime)
		{
			num3 = trackingCurve.Evaluate(p.ElapsedTime / trackingTime) * trackingSpeed;
		}
		float num4 = Mathf.MoveTowardsAngle(num2, num, num3 * BraveTime.DeltaTime);
		Vector2 val = Vector2.op_Implicit(Quaternion.Euler(0f, 0f, Mathf.DeltaAngle(num2, num4)) * Vector2.op_Implicit(p.Direction));
		if (p is HelixProjectile)
		{
			HelixProjectile val2 = (HelixProjectile)(object)((p is HelixProjectile) ? p : null);
			val2.AdjustRightVector(Mathf.DeltaAngle(num2, num4));
		}
		if (p.OverrideMotionModule != null)
		{
			p.OverrideMotionModule.AdjustRightVector(Mathf.DeltaAngle(num2, num4));
		}
		p.Direction = ((Vector2)(ref val)).normalized;
		if (p.shouldRotate)
		{
			((BraveBehaviour)p).transform.eulerAngles = new Vector3(0f, 0f, Vector2Extensions.ToAngle(p.Direction));
		}
	}
}
