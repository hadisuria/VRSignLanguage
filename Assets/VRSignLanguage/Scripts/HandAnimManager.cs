using UnityEngine;

public class HandAnimManager : MonoBehaviour
{
	private enum Hand 
	{
		LeftHand,
		Righthand
	}

	[SerializeField] private VRInputHandler inputHandler;
	[SerializeField] private Hand handTarget;
	[SerializeField] private Animator handAnimator;

	// Start is called before the first frame update
	void Start()
	{
		switch (handTarget)
		{
			case Hand.LeftHand:
				inputHandler.LeftControllerInput += UpdateHandAnimation;
				break;
			case Hand.Righthand:
				inputHandler.RightControllerInput += UpdateHandAnimation;
				break;
		}
	}

	private void UpdateHandAnimation(ControllerData controller)
	{
		if (controller.primaryButton)
			handAnimator.SetFloat("Button", 1f);
		else
			handAnimator.SetFloat("Button", 0f);

		if (controller.triggerButton)
			handAnimator.SetFloat("Trigger", 1f);
		else
			handAnimator.SetFloat("Trigger", 0f);

		if (controller.gripButton)
			handAnimator.SetFloat("Grip", 1f);
		else
			handAnimator.SetFloat("Grip", 0f);
	}

	private void OnDestroy()
	{
		switch (handTarget)
		{
			case Hand.LeftHand:
				inputHandler.LeftControllerInput -= UpdateHandAnimation;
				break;
			case Hand.Righthand:
				inputHandler.RightControllerInput -= UpdateHandAnimation;
				break;
		}
	}
}
