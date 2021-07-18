using System;
using UnityEngine;

public class DictionaryMenu : MonoBehaviour, IBoardMenu
{
	#region IBoardMenu
	public BoardMenuID menuID { get; } = BoardMenuID.DictionaryMenu;

	public event Action<BoardMenuID> OnRequestingOpenMenu;
	#endregion

	private bool initialized = false;
	[SerializeField] private ButtonEvent backButton;

	[SerializeField] private WordListControl wordListControl;


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
		wordListControl.GenerateWordList();
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
