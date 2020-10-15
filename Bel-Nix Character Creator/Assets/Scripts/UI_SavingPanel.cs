using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_SavingPanel : MonoBehaviour
{

    public float fadeTimer;
    float timeActive;

    TextMeshProUGUI TMPComponent;

    public InputField characterNameField;
    
    void UpdateFileName(string text) {

        text = text + " was saved!";

        TMPComponent.SetText(text);
        
    }

    void Timer() {

        if (timeActive != fadeTimer)
        {

            timeActive += Time.deltaTime;

        }

        else {
            timeActive = 0.0f;
            Debug.Log("Timer's done!");
            this.gameObject.SetActive(false);
        }


    }
    
    private void Awake()
    {
        TMPComponent = GetComponentInChildren<TextMeshProUGUI>();
        characterNameField.onEndEdit.AddListener(delegate { UpdateFileName(characterNameField.text); });
        characterNameField.onEndEdit.AddListener(delegate { Debug.Log("adlk;lkj;lj"); });
    }

    private void Update()
    {
        Timer();
    }


}
