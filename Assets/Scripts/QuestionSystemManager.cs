using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class HighlightedObject
{
    public string question;
    public GameObject[] highlightedObjects;
    public AudioSource WordOfNPC;
}

public class QuestionSystemManager : MonoBehaviour
{
    public HighlightedObject[] objectArray;
    public GameObject questionText; 
    public Material fadeoutMaterial;

    int target;
    int next;
    float timer = 0;
    bool investigation = false;
    float timeLimit = 3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = -2;
        next = -1;
    }

    // Update is called once per frame
    void Update()
    {
        next = target + 1;
        // investigation begins
        if (investigation){
            timer = timer + Time.deltaTime;
        }
       // investigation end
        if(investigation && timer > timeLimit){
            Debug.Log("end investigation");
            Debug.Log(next);
            Debug.Log(objectArray[next].highlightedObjects.Length);
            investigation = false;
            timer = 0;

            if (target > -1)
            {
                // get the current colorful objects fade out
                for (int i = 0; i < objectArray[target].highlightedObjects.Length; i++)
                {
                    objectArray[target].highlightedObjects[i].GetComponent<ColorController>().isColorful = false;
                }
            }
          
            // next certain objects stay colorful
            for (int i = 0; i < objectArray[next].highlightedObjects.Length; i++)
            {
                Debug.Log(objectArray[next].highlightedObjects[i]);
                objectArray[next].highlightedObjects[i].GetComponent<ColorController>().isColorful = true;
            }

            // all objects fade out
            Debug.Log(Global.fadeOut);
            Global.fadeOut = true;
        }
    }

    public void goNext(float lengthOfInvestigation)
    {
        timeLimit = lengthOfInvestigation;
        timer = 0;
        target++;
        next++;
        // go to next question
        questionText.GetComponent<TextMeshProUGUI>().text = objectArray[next].question;
        // start talking, play audio
        //objectArray[next].WordOfNPC.Play();
        // stop talking
        // start 1 min of investigation
        Global.fadeOut = false;
        investigation = true;
      
        // end of 30 seconds of investigation
        // most objects fade out

       
    }

    
}
