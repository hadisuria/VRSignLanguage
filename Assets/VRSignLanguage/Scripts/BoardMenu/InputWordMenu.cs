using System;
using System.Collections.Generic;
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

	[SerializeField] private GuideBallHandler ballHandler;
	private SignLanguageDictionary languageDictionary = new SignLanguageDictionary();

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
		ballHandler.ResetList();
		gameObject.SetActive(true);
	}

	private void BackButton_OnButtonHit()
	{
		OnRequestingOpenMenu?.Invoke(BoardMenuID.Previous);
	}

	private void InputWordButton_OnButtonHit()
	{
		if(typedWord.text != "" || typedWord.text != " ")
		{
			(List<Vector3> leftTemp, List<Vector3> rightTemp) = ballHandler.CalculateOffset();
			GuideBall tempBall = new GuideBall(typedWord.text, leftTemp, rightTemp);
			languageDictionary.AddWord(tempBall);
			ballHandler.ResetList();
			Debug.Log($"Guide Ball Data Saved With \"{typedWord.text}\"") ;
			typedWord.text = "";
		} else
		{
			Debug.Log("Failed to saved guideball data, please input word. . . BLOK");
		}
	}

	private void ResetButton_OnButtonHit()
	{
		ballHandler.ResetList();
	}

	private void OnDestroy()
	{
		resetButton.OnButtonHit -= ResetButton_OnButtonHit;
		inputWordButton.OnButtonHit -= InputWordButton_OnButtonHit;
		backButton.OnButtonHit -= BackButton_OnButtonHit;
	}
}
