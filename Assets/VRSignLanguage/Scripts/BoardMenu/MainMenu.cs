using System;
using UnityEngine;

public class MainMenu : MonoBehaviour, IBoardMenu
{
	#region IBoardMenu
	public BoardMenuID menuID { get; } = BoardMenuID.MainMenu;
	public event Action<BoardMenuID> OnRequestingOpenMenu;
	#endregion

	private bool initalized = false;
	[SerializeField] MenuButton dictionaryButton;
	[SerializeField] MenuButton learnButton;
	[SerializeField] MenuButton inputWordButton;
	[SerializeField] MenuButton exitButton;

	public void Initialize()
	{
		if (!initalized)
		{
			dictionaryButton.OnButtonHit += DictionaryButton_OnButtonHit; ;
			learnButton.OnButtonHit += LearnButton_OnButtonHit; ;
			inputWordButton.OnButtonHit += InputWordButton_OnButtonHit; ;
			exitButton.OnButtonHit += ExitGame;
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
		dictionaryButton.OnButtonHit -= DictionaryButton_OnButtonHit;
		learnButton.OnButtonHit -= LearnButton_OnButtonHit;
		inputWordButton.OnButtonHit -= InputWordButton_OnButtonHit;
		exitButton.OnButtonHit -= ExitGame;
	}
}
