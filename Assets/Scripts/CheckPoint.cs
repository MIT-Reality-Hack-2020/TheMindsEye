using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private QuestionSystemManager questionSystemManager;


    // Start is called before the first frame update
    void Start()
    {
        questionSystemManager = GameObject.Find("QuestionSystemManager").GetComponent<QuestionSystemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // valid objects fall into the spot
        if (other.CompareTag("answer1"))
        {
            // store the user's choice
            Global.weapon = other.gameObject.name;
            // go to next question with 1 min of investigation time (investigate scene and choose weapon)
            questionSystemManager.goNext(1f);
        }
        else if (other.CompareTag("answer2"))
        {
            // store the user's choice
            Global.murderer = other.gameObject.name;
            // go to next question with 2 min of investigation time (investigate scene and choose murderer)
            questionSystemManager.goNext(5f);
        }
    }
}
