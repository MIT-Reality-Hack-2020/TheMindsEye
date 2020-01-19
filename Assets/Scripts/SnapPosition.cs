using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPosition : MonoBehaviour
{
    public Vector3 originalPosition = new Vector3(0f, 0f, 0f);
    public Quaternion originalRotation = new Quaternion(0f, 0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = GetComponent<Transform>().position;
        originalRotation = GetComponent<Transform>().rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
