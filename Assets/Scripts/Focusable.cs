using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ViveSR.anipal.Eye
{
    [RequireComponent(typeof(Renderer), typeof(Collider))]
    public class Focusable : MonoBehaviour
    {
       

        private Renderer Renderer;

        public float focusingTime = 0f;

        private bool isLooking = false;

        Material originalMaterial;

        Color oriColor;

        private float timeCount = 0f;

        private bool oneTime = true;
       

        private void Awake()
        {
           
            Renderer = GetComponent<Renderer>();
            //Focus(Vector3.zero);
            oriColor = Renderer.material.color;

            originalMaterial = Renderer.material;

        }

        private void Update()
        {
            timeCount += Time.deltaTime;

            if (timeCount > 0.5f)
            {
               // Debug.Log(gameObject.name);
                timeCount = 0;
                GlobalScript.inFocus = null;
                //Debug.Log(originalMaterial);
                //Renderer.material = originalMaterial;
                Renderer.material.SetColor("_Color",oriColor);
            }


            if (oneTime)
            {
                if (Global.EndGame)
                {
                    Global.statistic[Global.interation].objectName = gameObject.name;
                    Global.statistic[Global.interation].totalTime = focusingTime;
                    Global.interation++;
                    oneTime = false;
                }
            }
           

       
        }



        public void Focus(Vector3 focusPoint)
        {
            timeCount = 0f;
            GlobalScript.inFocus = this.gameObject;
           
            Renderer.material.SetColor("_Color",Color.green);
            //print("WOW");

            focusingTime += Time.deltaTime;
          
       
        }


    }
}