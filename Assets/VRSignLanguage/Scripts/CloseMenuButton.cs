using System;
using UnityEngine;

public class CloseMenuButton : MonoBehaviour, IInteractableObject
{
	public event Action OnCloseButtonHit;
	public void ExecuteInteractHit()
	{
		OnCloseButtonHit.Invoke();
	}
}
