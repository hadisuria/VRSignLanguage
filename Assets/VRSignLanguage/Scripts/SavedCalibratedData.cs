﻿using UnityEngine;

public class SavedCalibratedData
{
	private float maxHandDistance;
	private float headLevelHeight;
	private float bellyHeight;
	private Vector3 leftShoulderOffset;
	private Vector3 rightShoulderOffset;

	public SavedCalibratedData(float handDistance, float height, float calibratedBellyHeight, Vector3 leftShoulder, Vector3 rightShoulder)
	{
		maxHandDistance = handDistance;
		headLevelHeight = height;
		bellyHeight = calibratedBellyHeight;
		leftShoulderOffset = leftShoulder;
		rightShoulderOffset = rightShoulder;
	}
}
