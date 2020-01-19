using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float sec;
    public bool run;
    // Start is called before the first frame update
    void Start()
    {
        sec = 0;
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            sec += Time.deltaTime;
        }
        
    }

}
