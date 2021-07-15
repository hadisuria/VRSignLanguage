using System;
using UnityEngine;

public class CalibrateMenuController : MonoBehaviour, IBoardMenu
{
	#region IBoardMenu
	public BoardMenuID menuID { get; } = BoardMenuID.CalibrateMenu;

	public event Action<BoardMenuID> OnRequestingOpenMenu;
	#endregion

	private bool initialized = false;
	//public bool isActive { get; private set; } = false;

	[SerializeField] private MenuButton closeButton;

	//void Start()
 //   {
	//	closeButton.OnCloseButtonHit += HideCalibrationMenu;
 //       gameObject.SetActive(isActive);
 //   }

	//private void HideCalibrationMenu()
	//{
 //       isActive = false;
 //       gameObject.SetActive(isActive);
	//}

	//public void ShowCalibrationMenu()
	//{
 //       if(SaveSystem.LoadData(SaveSystem.SAVE_CALIBRATION) == null){
 //           closeButton.gameObject.SetActive(false);
 //       } else {
 //           closeButton.gameObject.SetActive(true);
 //       }
 //       isActive = true;
 //       gameObject.SetActive(isActive);
 //   }

	public void Initialize()
	{
		if (!initialized)
		{
			closeButton.OnButtonHit += CloseButton_OnButtonHit;
			initialized = true;
		}
	}

	private void CloseButton_OnButtonHit()
	{
		OnRequestingOpenMenu?.Invoke(BoardMenuID.MainMenu);
	}

	public void Show()
	{
		if (SaveSystem.LoadData(SaveSystem.SAVE_CALIBRATION) == null)
		{
			closeButton.gameObject.SetActive(false);
		}
		else
		{
			closeButton.gameObject.SetActive(true);
		}
		//isActive = true;
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		//isActive = false;
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
        closeButton.OnButtonHit -= CloseButton_OnButtonHit;
	}
}
