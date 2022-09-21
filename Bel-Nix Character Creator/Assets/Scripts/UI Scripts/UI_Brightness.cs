using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Brightness : MonoBehaviour
{
    
    public float brightnessValue;

    Image imageComponent;
   


    public void ChangeBrightness(float f) {

        brightnessValue = f;
    
    }
    
    private void Awake()
    {
        imageComponent = GetComponent<Image>();
        
    }



    void Update()
    {
        imageComponent.color = new Color (0,0,0, (1 - brightnessValue));
    }
}
