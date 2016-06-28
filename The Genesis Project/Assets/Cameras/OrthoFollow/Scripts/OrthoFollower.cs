using UnityEngine;
using System.Collections;

public class OrthoFollower : UnityStandardAssets.Cameras.AbstractTargetFollower
{
	public float dampTime = 0.3f;
	public Vector3 cameraOffset = new Vector3(-8, 7, -8);

	private Vector3 velocity = Vector3.zero;

	protected override void FollowTarget(float dt)
	{
		Vector3 goalPosition = m_Target.position + cameraOffset;
		transform.position = Vector3.SmoothDamp(transform.position, goalPosition, ref velocity, dampTime);
	}
}
