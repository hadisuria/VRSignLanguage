using UnityEngine;
using UnityEngine.UI;

public class VRInputHandler : MonoBehaviour
{
	private ControllerData leftController = new ControllerData();
	private ControllerData rightController = new ControllerData();

	[SerializeField] private Text inputText;
	[SerializeField] private Text gestureText;

	//public event Action<ControllerData> LeftControllerInput;
	//public event Action<ControllerData> RightControllerInput;

	private const float lowThreshold = .2f;
	private const float highThreshold = .8f;

	// Update is called once per frame
	private void Update()
	{
		//set input for left controller
		leftController.SetControllerPos(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
		leftController.SetPrimaryButton(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch));
		leftController.SetSecondaryButton(OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LTouch));
		leftController.SetTriggerButton(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch));
		leftController.SetGripButton(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch));

		//set input for right controller
		leftController.SetControllerPos(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
		rightController.SetPrimaryButton(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch));
		rightController.SetSecondaryButton(OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch));
		rightController.SetTriggerButton(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch));
		rightController.SetGripButton(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch));

		//text for current input received
		inputText.text = $"Left Thumb 1 : {leftController.primaryButton} \nLeft Thumb 2 : {leftController.secondaryButton} \nLeft Index Trigger : {leftController.triggerButton} \nLeft Hand Trigger : {leftController.gripButton} \nLeft Controller Pos : {leftController.controllerPos}" +
						$"\nRight Thumb 1 : {rightController.primaryButton} \nRight Thumb 2 : {rightController.secondaryButton} \nRight Index Trigger : {rightController.triggerButton} \nRight Hand Trigger : {rightController.gripButton} \nRight Controller Pos : {rightController.controllerPos}";

		//set each hand gestures
		leftController.SetHandGestures(GetHandGestures(leftController.primaryButton, leftController.triggerButton, leftController.gripButton));
		rightController.SetHandGestures(GetHandGestures(rightController.primaryButton, rightController.triggerButton, rightController.gripButton));

		//text for current hand gestures
		gestureText.text = "Left Hand : " + leftController.handGestures.ToString() + "\nRight Hand : " + rightController.handGestures.ToString();

		//action to give current controller input
		//LeftControllerInput.Invoke(leftController);
		//RightControllerInput.Invoke(rightController);
	}

	private HandGestures GetHandGestures(bool thumb, float index, float grip)
	{
		if (thumb && index >= lowThreshold && grip >= lowThreshold)
		{
			return HandGestures.Fist;
		}
		else if (thumb && index >= lowThreshold && grip < lowThreshold)
		{
			return HandGestures.RocknRoll;
		}
		else if (thumb && index < lowThreshold && grip >= highThreshold)
		{
			return HandGestures.Point;
		}
		else if (!thumb && index >= lowThreshold && grip >= lowThreshold)
		{
			return HandGestures.ThumbsUp;
		}
		else if (!thumb && index < lowThreshold && grip >= lowThreshold)
		{
			return HandGestures.Gun;
		}
		else if(thumb && index < lowThreshold && (grip >= lowThreshold && grip < highThreshold))
		{
			return HandGestures.Victory;
		}
		else
		{
			return HandGestures.None;
		}
	}

	public ControllerData GetLeftHandController()
	{
		return new ControllerData(leftController);
	}

	public ControllerData GetRightHandController()
	{
		return new ControllerData(rightController);
	}
}
