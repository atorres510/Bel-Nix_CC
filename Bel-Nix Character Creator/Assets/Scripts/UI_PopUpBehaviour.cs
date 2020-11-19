using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PopUpBehaviour : MonoBehaviour
{

    public float fadeTimer;

    public string defaultText = "";

    public string[] dynamicText;
  
    TextMeshProUGUI TMPComponent;

    string ConstructSentenceWithKeyword(string keyword) {

        string sentence = "";

        for (int i = 0; i < dynamicText.Length; i++)
        {

            if (dynamicText[i] == "")
                dynamicText[i] = keyword;

            sentence = sentence + dynamicText[i];

        }
        
        return sentence;

    }
    
    public void UpdatePopUpText(string keyword) {

        if (keyword == "")
            TMPComponent.SetText(defaultText);

        else
            TMPComponent.SetText(ConstructSentenceWithKeyword(keyword));
        
    }

    IEnumerator PopUpTimer(float seconds) {

        yield return new WaitForSecondsRealtime(seconds);
        gameObject.SetActive(false);

    }

    public void ActivatePanel() {

        gameObject.SetActive(true);

        StartCoroutine(PopUpTimer(fadeTimer));
        
    }

    
    private void Awake()
    {
        TMPComponent = GetComponentInChildren<TextMeshProUGUI>();
        TMPComponent.SetText(defaultText);
        gameObject.SetActive(false);
    }

   


}
