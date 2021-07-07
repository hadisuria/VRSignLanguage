using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandRay : MonoBehaviour
{

    [SerializeField] private VRInputHandler inputHandler;

    public LineRenderer rightHandRayLine;

    public float lineWidth = 0.1f;
    public float lineMaxLength = 1f;

    // boolean to determine if line renderer is enabled or disabled
    public bool toggled = false;

    private float handRight;
    // private float handRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger); // old code style

    private GameObject pointedObject;

    // Start is called before the first frame update
    void Start()
    {
        // init setup line renderer position
        Vector3[] startLinePositions = new Vector3[2] {Vector3.zero, Vector3.zero};
        rightHandRayLine.SetPositions( startLinePositions );
        rightHandRayLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // update value of handRight every frame with new value from trigger    
        handRight = inputHandler.GetRightHandController().triggerButton;
        // handRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

        if( handRight > 0.9){
            toggled = true;
             rightHandRayLine.enabled = true;

        } else {
            rightHandRayLine.enabled = false;
            toggled = false;
        }

        if(toggled){
            // render raycast if the trigger is pulled
            renderRayLine(transform.position, transform.forward, lineMaxLength);
        }
    }


    private void renderRayLine(Vector3 targetPosition, Vector3 direction, float length){
        // set raycast hit
        RaycastHit hit;
        Ray rayLineOut = new Ray(targetPosition, direction);

        Vector3 endPosition = targetPosition + (length * direction);

        if(Physics.Raycast(rayLineOut, out hit)){
            endPosition = hit.point;

            // set the game object to the gameObject that the raycast hit
            pointedObject = hit.collider.gameObject;
            if(pointedObject.TryGetComponent<IInteractableObject>(out var target))
			{
                target.ExecuteInteractHit();
			}

        }    

        // update the line renderer that declared at the top
        rightHandRayLine.SetPosition(0, targetPosition);
        rightHandRayLine.SetPosition(1, endPosition);
    }

}


