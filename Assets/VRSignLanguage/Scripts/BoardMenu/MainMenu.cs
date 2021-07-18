using System;
using UnityEngine;

public class MainMenu : MonoBehaviour, IBoardMenu
{
	#region IBoardMenu
	public BoardMenuID menuID { get; } = BoardMenuID.MainMenu;
	public event Action<BoardMenuID> OnRequestingOpenMenu;
	#endregion

	private bool initalized = false;
	[SerializeField] ButtonEvent dictionaryButton;
	[SerializeField] ButtonEvent learnButton;
	[SerializeField] ButtonEvent inputWordButton;
	[SerializeField] ButtonEvent exitButton;

	public void Initialize()
	{
		if (!initalized)
		{
			dictionaryButton.OnButtonClicked += DictionaryButton_OnButtonHit; ;
			learnButton.OnButtonClicked += LearnButton_OnButtonHit; ;
			inputWordButton.OnButtonClicked += InputWordButton_OnButtonHit; ;
			exitButton.OnButtonClicked += ExitGame;
			initalized = true;
		}
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	private void InputWordButton_OnButtonHit()
	{
		OnRequestingOpenMenu?.Invoke(BoardMenuID.InputWordMenu);
	}

	private void LearnButton_OnButtonHit()
	{
		OnRequestingOpenMenu?.Invoke(BoardMenuID.LearnMenu);
	}

	private void DictionaryButton_OnButtonHit()
	{
		OnRequestingOpenMenu?.Invoke(BoardMenuID.DictionaryMenu);
	}

	private void ExitGame()
	{
		Application.Quit();
	}

	private void OnDestroy()
	{
		dictionaryButton.OnButtonClicked -= DictionaryButton_OnButtonHit;
		learnButton.OnButtonClicked -= LearnButton_OnButtonHit;
		inputWordButton.OnButtonClicked -= InputWordButton_OnButtonHit;
		exitButton.OnButtonClicked -= ExitGame;
	}
}
