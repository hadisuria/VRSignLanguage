using System;
using UnityEngine;

public class LearnMenu : MonoBehaviour, IBoardMenu
{
	#region IBoardMenu
	public BoardMenuID menuID { get; } = BoardMenuID.LearnMenu;

	public event Action<BoardMenuID> OnRequestingOpenMenu;
	#endregion

	private bool initialized = false;
	[SerializeField] private ButtonEvent backButton;

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Initialize()
	{
		if (!initialized)
		{
			backButton.OnButtonClicked += BackButton_OnButtonHit;
			initialized = true;
		}
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	private void BackButton_OnButtonHit()
	{
		OnRequestingOpenMenu?.Invoke(BoardMenuID.Previous);
	}

	private void OnDestroy()
	{
		backButton.OnButtonClicked -= BackButton_OnButtonHit;
	}
}
