public class ControllerData
{
	public bool primaryButton { get; private set; }
	public bool secondaryButton { get; private set; }
	public bool triggerButton { get; private set; }
	public bool gripButton { get; private set; }
	public HandGestures handGestures { get; private set; }

	public ControllerData()
	{

	}

	public ControllerData(bool primaryButtonValue, bool secondaryButtonValue, bool triggerButtonValue, bool gripButtonValue)
	{
		SetPrimaryButton(primaryButtonValue);
		SetSecondaryButton(secondaryButtonValue);
		SetTriggerButton(triggerButtonValue);
		SetGripButton(gripButtonValue);
		SetHandGestures(HandGestures.None);
	}
	public ControllerData(bool primaryButtonValue, bool secondaryButtonValue, bool triggerButtonValue, bool gripButtonValue, HandGestures handGesturesValue)
	{
		SetPrimaryButton(primaryButtonValue);
		SetSecondaryButton(secondaryButtonValue);
		SetTriggerButton(triggerButtonValue);
		SetGripButton(gripButtonValue);
		SetHandGestures(handGesturesValue);
	}

	public void SetPrimaryButton(bool value)
	{
		primaryButton = value;
	}
	public void SetSecondaryButton(bool value)
	{
		secondaryButton = value;
	}
	public void SetTriggerButton(bool value)
	{
		triggerButton = value;
	}
	public void SetGripButton(bool value)
	{
		gripButton = value;
	}
	public void SetHandGestures(HandGestures value)
	{
		handGestures = value;
	}
}
