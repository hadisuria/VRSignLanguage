using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private BodyCalibrator calibrator;
	[SerializeField] private VRInputHandler inputHandler;
	[SerializeField] private CalibrateMenu calibrateMenu;
	[SerializeField] private CalibrateMenuController calibrateMenuController;
	private float maxHandDistance;
	private float headLevelHeight;

	private void Start()
	{
		calibrateMenu.CalibrateMenuHit += ShowCalibrationMenu;
	} 
	private void Update()
	{
		if (calibrateMenuController.isActive)
		{
			if (inputHandler.GetRightHandController().secondaryButton && inputHandler.GetLeftHandController().secondaryButton)
				StartCalibrate();
		}
	}

	private void ShowCalibrationMenu()
	{
		calibrateMenuController.ShowCalibrationMenu();
	}

	private void StartCalibrate()
	{
        var calibratedValue = calibrator.CalibratePosition();
        maxHandDistance = calibratedValue.handLength;
        headLevelHeight = calibratedValue.bodyHeight;
	}

	private void OnDestroy()
	{
		calibrateMenu.CalibrateMenuHit -= ShowCalibrationMenu;
	}
}
