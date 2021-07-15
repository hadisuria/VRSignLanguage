using System;
using TMPro;
using UnityEngine;

public class InputWordMenu : MonoBehaviour, IBoardMenu
{
	#region IBoardMenu
	public BoardMenuID menuID { get; } = BoardMenuID.InputWordMenu;

	public event Action<BoardMenuID> OnRequestingOpenMenu;
	#endregion

	private bool initialized = false;
	[SerializeField] private MenuButton resetButton;
	[SerializeField] private MenuButton inputWordButton;
	[SerializeField] private MenuButton backButton;
	[SerializeField] private TextMeshProUGUI typedWord;

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Initialize()
	{
		if (!initialized)
		{
			resetButton.OnButtonHit += ResetButton_OnButtonHit;
			inputWordButton.OnButtonHit += InputWordButton_OnButtonHit;
			backButton.OnButtonHit += BackButton_OnButtonHit;
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

	private void InputWordButton_OnButtonHit()
	{
		throw new NotImplementedException();
	}

	private void ResetButton_OnButtonHit()
	{
		throw new NotImplementedException();
	}

	private void OnDestroy()
	{
		resetButton.OnButtonHit -= ResetButton_OnButtonHit;
		inputWordButton.OnButtonHit -= InputWordButton_OnButtonHit;
		backButton.OnButtonHit -= BackButton_OnButtonHit;
	}
}
