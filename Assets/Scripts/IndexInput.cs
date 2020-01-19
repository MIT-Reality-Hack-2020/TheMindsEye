using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using HTC.UnityPlugin.Vive;
using ViveSR.anipal.Eye;

public class IndexInput : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
        //PinchAction();
        //SkeletonAction();
    }

    private void Update()
    {

        if (GlobalScript.inFocus) {
            if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Menu))
            {
                print("Menu press");
                // compare tag select weapon
            }

            if (ViveInput.GetPressEx(HandRole.LeftHand, ControllerButton.Grip)) {
                print("HAND press");
                // store the grabbed object
                GlobalScript.grabbedObject = GlobalScript.inFocus;
                // object fly to the user
                GlobalScript.inFocus.transform.position = leftHand.transform.position;//Vector3.Lerp(GlobalScript.inFocus.transform.position, leftHand.transform.position, 0.5f);
                GlobalScript.inFocus.transform.rotation = leftHand.transform.rotation;
            }
            

            if (ViveInput.GetPressEx(HandRole.RightHand, ControllerButton.Grip))
            {
                print("HAND press");
                GlobalScript.grabbedObject = GlobalScript.inFocus;
                GlobalScript.inFocus.transform.position = rightHand.transform.position;//Vector3.Lerp(GlobalScript.inFocus.transform.position, rightHand.transform.position, 0.5f);
                GlobalScript.inFocus.transform.rotation = rightHand.transform.rotation;
            }
        }




        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Grip))
        {
            print("Hand release");
            if (GlobalScript.grabbedObject)
            {
                //GlobalScript.grabbedObject.transform.position = Vector3.Lerp(GlobalScript.grabbedObject.transform.position, GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition, 0.5f);
                GlobalScript.grabbedObject.transform.position = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition;
                GlobalScript.grabbedObject.transform.rotation = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalRotation;
            }
        }
        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Grip))
        {
            print("Hand release");
            if (GlobalScript.grabbedObject)
            {
                GlobalScript.grabbedObject.transform.position = Vector3.Lerp(GlobalScript.grabbedObject.transform.position, GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition, 0.5f);
                /*GlobalScript.grabbedObject.transform.position = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition;*/
                GlobalScript.grabbedObject.transform.rotation = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalRotation;
            }
        }
    }


}
