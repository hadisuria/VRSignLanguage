using UnityEngine;

public class CenterPointTeleporter : MonoBehaviour, IInteractableObject
{
	[SerializeField] private GameObject player;

	public void ExecuteInteractHit()
	{
		player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
	}
}
