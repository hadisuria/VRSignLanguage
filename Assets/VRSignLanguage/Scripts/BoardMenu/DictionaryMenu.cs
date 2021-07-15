using System;
using UnityEngine;

public class DictionaryMenu : MonoBehaviour, IBoardMenu
{
	#region IBoardMenu
	public BoardMenuID menuID { get; } = BoardMenuID.DictionaryMenu;

	public event Action<BoardMenuID> OnRequestingOpenMenu;
	#endregion

	private bool initialized = false;
	[SerializeField] private MenuButton backButton;

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Initialize()
	{
		if (!initialized)
		{
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

	private void OnDestroy()
	{
		backButton.OnButtonHit -= BackButton_OnButtonHit;
	}
}
