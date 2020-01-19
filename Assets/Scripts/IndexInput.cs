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
    private QuestionSystemManager questionSystemManager;
    private bool weaponOnce = true;


    // Start is called before the first frame update
    void Start()
    {
        questionSystemManager = GameObject.Find("QuestionSystemManager").GetComponent<QuestionSystemManager>();
        //PinchAction();
        //SkeletonAction();
    }

    private void Update()
    {

        if (GlobalScript.inFocus) {
            
            if (ViveInput.GetPressEx(HandRole.LeftHand, ControllerButton.Menu))
            {
               
                if (weaponOnce)
                {
                    // compare tag select weapon
                    if (GlobalScript.inFocus.CompareTag("answer1"))
                    {
                        weaponOnce = false;
                        // store the user's choice
                        Global.weapon = GlobalScript.inFocus.name;
                        // go to next question with 1 min of investigation time (investigate scene and choose suspect)
                        questionSystemManager.goNext(10f);
                    }
                }

                if (GlobalScript.inFocus.CompareTag("answer2"))
                {
                    Global.murderer = GlobalScript.inFocus.name;
                    // end game, statistic
                    Global.EndGame = true;
                    Debug.Log(Global.statistic[0].objectName);
                    Debug.Log(Global.statistic[0].totalTime);
                }
            }

            if (ViveInput.GetPressEx(HandRole.RightHand, ControllerButton.Menu))
            {

                if (weaponOnce)
                {
                    // compare tag select weapon
                    if (GlobalScript.inFocus.CompareTag("answer1"))
                    {
                        weaponOnce = false;
                        // store the user's choice
                        Global.weapon = GlobalScript.inFocus.name;
                        // go to next question with 1 min of investigation time (investigate scene and choose suspect)
                        questionSystemManager.goNext(10f);
                    }
                }

                if (GlobalScript.inFocus.CompareTag("answer2"))
                {
                    Global.murderer = GlobalScript.inFocus.name;
                    // end game
                }
            }



            if (ViveInput.GetPressEx(HandRole.LeftHand, ControllerButton.Trigger)) {
                //print("HAND press");
                // store the grabbed object
                GlobalScript.grabbedObject = GlobalScript.inFocus;
                // object fly to the user
                GlobalScript.inFocus.transform.position = leftHand.transform.position;//Vector3.Lerp(GlobalScript.inFocus.transform.position, leftHand.transform.position, 0.5f);
                //GlobalScript.inFocus.transform.position = Vector3.Lerp(GlobalScript.inFocus.transform.position, leftHand.transform.position, 0.5f);
                GlobalScript.inFocus.transform.rotation = leftHand.transform.rotation;
            }
            

            if (ViveInput.GetPressEx(HandRole.RightHand, ControllerButton.Trigger))
            {
                //print("HAND press");
                GlobalScript.grabbedObject = GlobalScript.inFocus;
                 GlobalScript.inFocus.transform.position = rightHand.transform.position;//Vector3.Lerp(GlobalScript.inFocus.transform.position, rightHand.transform.position, 0.5f);
                //GlobalScript.inFocus.transform.position = Vector3.Lerp(GlobalScript.inFocus.transform.position, rightHand.transform.position, 0.5f);
                GlobalScript.inFocus.transform.rotation = rightHand.transform.rotation;
            }
        }




        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Trigger))
        {
            //print("Hand release");
            if (GlobalScript.grabbedObject)
            {
                //GlobalScript.grabbedObject.transform.position = Vector3.Lerp(GlobalScript.grabbedObject.transform.position, GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition, 0.5f);
                GlobalScript.grabbedObject.transform.position = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition;
                GlobalScript.grabbedObject.transform.rotation = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalRotation;
            }
        }
        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Trigger))
        {
            //print("Hand release");
            if (GlobalScript.grabbedObject)
            {
                GlobalScript.grabbedObject.transform.position = Vector3.Lerp(GlobalScript.grabbedObject.transform.position, GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition, 0.5f);
                /*GlobalScript.grabbedObject.transform.position = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalPosition;*/
                GlobalScript.grabbedObject.transform.rotation = GlobalScript.grabbedObject.GetComponent<SnapPosition>().originalRotation;
            }
        }
    }


}
