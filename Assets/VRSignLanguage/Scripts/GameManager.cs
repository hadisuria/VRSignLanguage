using UnityEngine;


public class GameManager : MonoBehaviour
{
	[SerializeField] private BodyCalibrator calibrator;
	[SerializeField] private VRInputHandler inputHandler;
	[SerializeField] private MenuButton calibrateMenuButton;
	[SerializeField] private BoardMenuController menuController;
	[SerializeField] private Transform[] keyPositions;
	private float maxHandDistance;
	private float headLevelHeight;
	private float bellyHeight;
	private Vector3 leftShoulderOffset;
	private Vector3 rightShoulderOffset;
	
	// To store saved / loaded calibratedData
	private SavedCalibratedData savedCalibratedData;

	private void Start()
	{
		SaveSystem.Init();
		calibrateMenuButton.OnButtonHit += ShowCalibrationMenu;
		Load();
	} 
	private void Update()
	{
		if (menuController.currMenu.menuID == BoardMenuID.CalibrateMenu)
		{
			if (inputHandler.GetRightHandController().secondaryButton && inputHandler.GetLeftHandController().secondaryButton)
				StartCalibrate();
		}

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray rayLineOut = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(rayLineOut, out hit))
			{
				// set the game object to the gameObject that the raycast hit
				var pointedObject = hit.collider.gameObject;
				if (pointedObject.TryGetComponent<IInteractableObject>(out var target))
				{
					target.ExecuteInteractHit();
				}
			}
		}
	}

	private void SaveCalibratedData(SavedCalibratedData savedCalibratedDataObj)
	{
		string json = JsonUtility.ToJson(savedCalibratedDataObj);
		SaveSystem.SaveData(json, SaveSystem.SAVE_CALIBRATION);
	}

	private void Load()
	{
		// load the callibrated data if any
		string saveString = SaveSystem.LoadData(SaveSystem.SAVE_CALIBRATION);
		if(saveString != null)
		{
			SavedCalibratedData savedCalibratedDataObj = JsonUtility.FromJson<SavedCalibratedData>(saveString);
			// Assign data to saved calibrated data
			savedCalibratedData = new SavedCalibratedData(savedCalibratedDataObj);
		}
		else
		{
			ShowCalibrationMenu();
		}
	}

	private void ShowCalibrationMenu()
	{
		menuController.OpenMenu(BoardMenuID.CalibrateMenu);
	}

	private void StartCalibrate()
	{
        var calibratedValue = calibrator.CalibratePosition();
        maxHandDistance = calibratedValue.handLength;
        headLevelHeight = calibratedValue.bodyHeight;
		bellyHeight = calibratedValue.bellyHeight;
		leftShoulderOffset = calibratedValue.shoulderOffsetLeft;
		rightShoulderOffset = calibratedValue.shoulderOffsetRight;

		// Store calibrated data to local variable
		savedCalibratedData = new SavedCalibratedData(
				maxHandDistance, 
				headLevelHeight, 
				bellyHeight, 
				leftShoulderOffset, 
				rightShoulderOffset
			);

		SaveCalibratedData(savedCalibratedData);

		// visualize calibrated pos using simple game object
		// index 0 = player hmd pos
		// index 1 = head indicator
		keyPositions[1].position = new Vector3(keyPositions[0].position.x, headLevelHeight, keyPositions[0].position.z);

		// inedx 2 = belly indicator
		keyPositions[2].position = new Vector3(keyPositions[0].position.x, bellyHeight, keyPositions[0].position.z);

		// index 3 = left shoulder indicator
		keyPositions[3].position = new Vector3(keyPositions[0].position.x + leftShoulderOffset.x, leftShoulderOffset.y, keyPositions[0].position.z);

		// index 4 = right shoulder indicator
		keyPositions[4].position = new Vector3(keyPositions[0].position.x + rightShoulderOffset.x, rightShoulderOffset.y, keyPositions[0].position.z);
	}

	private void OnDestroy()
	{
		calibrateMenuButton.OnButtonHit -= ShowCalibrationMenu;
	}
}
