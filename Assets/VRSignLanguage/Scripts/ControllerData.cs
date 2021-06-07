public class ControllerData
{
	public bool primaryButton { get; private set; }
	public bool secondaryButton { get; private set; }
	public float triggerButton { get; private set; }
	public float gripButton { get; private set; }
	public HandGestures handGestures { get; private set; }

	public ControllerData()
	{

	}

	public ControllerData(bool primaryButtonValue, bool secondaryButtonValue, float triggerButtonValue, float gripButtonValue)
	{
		SetPrimaryButton(primaryButtonValue);
		SetSecondaryButton(secondaryButtonValue);
		SetTriggerButton(triggerButtonValue);
		SetGripButton(gripButtonValue);
		SetHandGestures(HandGestures.None);
	}
	public ControllerData(bool primaryButtonValue, bool secondaryButtonValue, float triggerButtonValue, float gripButtonValue, HandGestures handGesturesValue)
	{
		SetPrimaryButton(primaryButtonValue);
		SetSecondaryButton(secondaryButtonValue);
		SetTriggerButton(triggerButtonValue);
		SetGripButton(gripButtonValue);
		SetHandGestures(handGesturesValue);
	}

	public ControllerData(ControllerData value)
	{
		primaryButton = value.primaryButton;
		secondaryButton = value.secondaryButton;
		triggerButton = value.triggerButton;
		gripButton = value.gripButton;
		handGestures = value.handGestures;
	}

	public void SetPrimaryButton(bool value)
	{
		primaryButton = value;
	}
	public void SetSecondaryButton(bool value)
	{
		secondaryButton = value;
	}
	public void SetTriggerButton(float value)
	{
		triggerButton = value;
	}
	public void SetGripButton(float value)
	{
		gripButton = value;
	}
	public void SetHandGestures(HandGestures value)
	{
		handGestures = value;
	}
}
