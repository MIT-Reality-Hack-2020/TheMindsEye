using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private QuestionSystemManager questionSystemManager;

    public Material highlightMat;

    // Start is called before the first frame update
    void Start()
    {
        // play sound, user enter to the game 
        // start game with 1 min investigation
        questionSystemManager = GameObject.Find("QuestionSystemManager").GetComponent<QuestionSystemManager>();
        questionSystemManager.goNext(10f);
        Debug.Log("hi");

        GlobalScript.highlightMaterial = highlightMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
