using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    List<Material> originalMaterials;
    private QuestionSystemManager questionSystemManager;
    private List<Material> fadeOutMaterialList;
    public bool isColorful;
    // Start is called before the first frame update
    void Start()
    {
        isColorful = false;
        if (gameObject.GetComponent<MeshRenderer>())
            originalMaterials = new List<Material>(gameObject.GetComponent<MeshRenderer>().materials);

        questionSystemManager = GameObject.Find("QuestionSystemManager").GetComponent<QuestionSystemManager>();
        fadeOutMaterialList = new List<Material>();
        fadeOutMaterialList.Add(questionSystemManager.fadeoutMaterial);
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.fadeOut)
        {
           
            if (isColorful)
            {
                SwitchToOriginalMaterial();
            }
            else
            {
                SwitchToFadeoutMaterial();
            }
        }
        else
        {
            SwitchToOriginalMaterial();
        }

    }

    public void SwitchToOriginalMaterial()
    {
        if (gameObject.GetComponent<MeshRenderer>())
            gameObject.GetComponent<MeshRenderer>().materials = originalMaterials.ToArray();
    }

    private void SwitchToFadeoutMaterial()
    {
        if (gameObject.GetComponent<MeshRenderer>())
            gameObject.GetComponent<MeshRenderer>().materials = fadeOutMaterialList.ToArray();
    }
}
