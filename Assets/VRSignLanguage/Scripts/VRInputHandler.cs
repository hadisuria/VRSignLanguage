using System;
using UnityEngine;
using UnityEngine.UI;

public class VRInputHandler : MonoBehaviour
{
	//private bool[] thumbDown = new bool[2];
	//private bool[] indexTriggered = new bool[2];
	//private bool[] handTriggered = new bool[2];
	private ControllerData leftController = new ControllerData();
	private ControllerData rightController = new ControllerData();


	//private List<HandGestures> handGesturesList = new List<HandGestures>();

	[SerializeField] private Text inputText;
	[SerializeField] private Text gestureText;

	public event Action<ControllerData> LeftControllerInput;
	public event Action<ControllerData> RightControllerInput;

	private void Start()
	{
		//AssignVRController();
	}

	// Update is called once per frame
	private void Update()
	{
		leftController.SetPrimaryButton(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch));
		leftController.SetSecondaryButton(OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LTouch));
		leftController.SetTriggerButton(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > .2f);
		leftController.SetGripButton(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > .2f);
		
		rightController.SetPrimaryButton(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch));
		rightController.SetSecondaryButton(OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch));
		rightController.SetTriggerButton(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .2f);
		rightController.SetGripButton(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > .2f);

		//if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
		//{
		//	thumbDown[0] = true;
		//}
		//else
		//{
		//	thumbDown[0] = false;
		//}
		//if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > .2f)
		//{
		//	indexTriggered[0] = true;
		//}
		//else
		//{
		//	indexTriggered[0] = false;
		//}
		//if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > .2f)
		//{
		//	handTriggered[0] = true;
		//}
		//else
		//{
		//	handTriggered[0] = false;
		//}
		//if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
		//{
		//	thumbDown[1] = true;
		//}
		//else
		//{
		//	thumbDown[1] = false;
		//}
		//if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .2f)
		//{
		//	indexTriggered[1] = true;
		//}
		//else
		//{
		//	indexTriggered[1] = false;
		//}
		//if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > .2f)
		//{
		//	handTriggered[1] = true;
		//}
		//else
		//{
		//	handTriggered[1] = false;
		//}
		inputText.text = $"Left Thumb 1 : {leftController.primaryButton} \nLeft Thumb 2 : {leftController.secondaryButton} \nLeft Index Trigger : {leftController.triggerButton} \nLeft Hand Trigger : {leftController.gripButton}" +
						$"\nRight Thumb 1 : {rightController.primaryButton} \nRight Thumb 2 : {rightController.secondaryButton} \nRight Index Trigger : {rightController.triggerButton} \nRight Hand Trigger : {rightController.gripButton}";

		leftController.SetHandGestures(GetHandGestures(leftController.primaryButton, leftController.triggerButton, leftController.gripButton));
		rightController.SetHandGestures(GetHandGestures(rightController.primaryButton, rightController.triggerButton, rightController.gripButton));

		//for (int i = 0; i < handGesturesList.Count; i++)
		//{
		//	if (thumbDown[i] && indexTriggered[i] && handTriggered[i])
		//	{
		//		handGesturesList[i] = HandGestures.Rock;
		//	}
		//	else if (thumbDown[i] && indexTriggered[i] && !handTriggered[i])
		//	{
		//		handGesturesList[i] = HandGestures.OK;
		//	}
		//	else if (thumbDown[i] && !indexTriggered[i] && handTriggered[i])
		//	{
		//		handGesturesList[i] = HandGestures.Point;
		//	}
		//	else if (!thumbDown[i] && !indexTriggered[i] && handTriggered[i])
		//	{
		//		handGesturesList[i] = HandGestures.Gun;
		//	}
		//	else if (!thumbDown[i] && !indexTriggered[i] && !handTriggered[i])
		//	{
		//		handGesturesList[i] = HandGestures.None;
		//	}
		//	else if (!thumbDown[i] && indexTriggered[i] && handTriggered[i])
		//	{
		//		handGesturesList[i] = HandGestures.ThumbUp;
		//	}
		//}
		//if (handGesturesList.Count > 1)
		//{
			gestureText.text = "Left Hand : " + leftController.handGestures.ToString() + "\nRight Hand : " + rightController.handGestures.ToString();
		//}
		//else
		//{
		//	AssignVRController();
		//}

		LeftControllerInput(leftController);
		RightControllerInput(rightController);
	}

	private HandGestures GetHandGestures(bool thumb, bool index, bool grip)
	{
		if (thumb && index && grip)
		{
			return HandGestures.Rock;
		}
		else if (thumb && index && !grip)
		{
			return HandGestures.OK;
		}
		else if (thumb && !index && grip)
		{
			return HandGestures.Point;
		}
		else if (!thumb && index && grip)
		{
			return HandGestures.ThumbUp;
		}
		else if (!thumb && !index && grip)
		{
			return HandGestures.Gun;
		}
		else
		{
			return HandGestures.None;
		}
	}

	//private void AssignVRController()
	//{
	//	handGesturesList.Clear();
	//	foreach (var s in Input.GetJoystickNames())
	//	{
	//		handGesturesList.Add(HandGestures.None);
	//	}
	//}

}
