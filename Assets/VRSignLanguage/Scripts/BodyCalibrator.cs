using UnityEngine;

public class BodyCalibrator : MonoBehaviour
{
	[SerializeField] private VRInputHandler inputHandler;
	[SerializeField] private GameObject playerHMD;

	public (float bodyHeight, float handLength) CalibratePosition()
	{
		float bodyHeight = GetBodyHeight(playerHMD.transform.position);
		float handLength = GetHandLength(playerHMD.transform.position);

		return (bodyHeight: bodyHeight, handLength: handLength);
	}

	private float GetHandLength(Vector3 headPos)
	{
		var leftHand = inputHandler.GetLeftHandController().controllerPos;
		var rightHand = inputHandler.GetRightHandController().controllerPos;

		float leftHandLength = leftHand.z - headPos.z;
		float rightHandLength = rightHand.z - headPos.z;

		return Mathf.Abs(leftHandLength + rightHandLength) / 2f;
	}
	
	private float GetBodyHeight(Vector3 headPos)
	{
		return headPos.y;
	}
}
