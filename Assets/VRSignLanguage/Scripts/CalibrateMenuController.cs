using UnityEngine;

public class CalibrateMenuController : MonoBehaviour
{

    public bool isActive { get; private set; } = false;
    [SerializeField] private CloseMenuButton closeButton;

    void Start()
    {
		closeButton.OnCloseButtonHit += HideCalibrationMenu;
        gameObject.SetActive(isActive);
    }

	private void HideCalibrationMenu()
	{
        isActive = false;
        gameObject.SetActive(isActive);
	}

	public void ShowCalibrationMenu()
	{
        if(CalibrateSaveSytem.LoadCalibratedData() == null){
            closeButton.gameObject.SetActive(false);
        } else {
            closeButton.gameObject.SetActive(true);
        }
        isActive = true;
        gameObject.SetActive(isActive);
    }

	private void OnDestroy()
	{
        closeButton.OnCloseButtonHit -= HideCalibrationMenu;
	}
}
