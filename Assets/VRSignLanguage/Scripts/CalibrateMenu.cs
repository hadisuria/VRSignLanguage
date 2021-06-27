using System;
using UnityEngine;

public class CalibrateMenu : MonoBehaviour, IInteractableObject
{

    public event Action CalibrateMenuHit;

	public void ExecuteInteractHit()
	{
		CalibrateMenuHit.Invoke();
	}
}
