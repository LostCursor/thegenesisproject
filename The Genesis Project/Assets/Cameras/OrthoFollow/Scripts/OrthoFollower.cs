﻿using UnityEngine;
using System.Collections;

public class OrthoFollower : UnityStandardAssets.Cameras.AbstractTargetFollower
{
	public float dampTime = 0.3f;
	public Vector3 cameraOffset = new Vector3(-8f, 4f, -8f);
    public bool flipped = false;
    public bool flipping = false;

	private Vector3 velocity = Vector3.zero;
    private int rotationSpeed = 6;
    private int numRot;

	protected override void FollowTarget(float dt)
	{
        Vector3 goalPosition = m_Target.position + cameraOffset;
        if (flipping)
        {
            transform.RotateAround(m_Target.position, Vector3.up, rotationSpeed);
            numRot++;
            if (numRot == Mathf.Floor(Mathf.Abs(180/rotationSpeed)))
            {
                numRot = 0;
                flipping = false;
                flipped = !flipped;
                cameraOffset.Set(-cameraOffset.x, cameraOffset.y, -cameraOffset.z);
            }
        }
        else {
            transform.position = Vector3.SmoothDamp(transform.position, goalPosition, ref velocity, dampTime);
            if (Input.GetKeyDown(KeyCode.J))
            {
                flipping = true;
                rotationSpeed = 6;

            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                flipping = true;
                rotationSpeed = -6;
            }
        }
	}
}
