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

    int keywordElement;
  
    TextMeshProUGUI TMPComponent;

    //goes through the dynamic text array to determine the empty space.  this empty space significes where we want the text to go.
    void SetKeywordElement() {

        for (int i = 0; i < dynamicText.Length; i++)
        {

            if (dynamicText[i] == "")
                keywordElement = i;
            
        }

    }


    string ConstructSentenceWithKeyword(string keyword) {

        string sentence = "";

        dynamicText[keywordElement] = keyword;

        for (int i = 0; i < dynamicText.Length; i++)
        {
            sentence = sentence + dynamicText[i];
        }

        return sentence;

    }
    
    //called by other objects in the UI
    public void UpdatePopUpText(string keyword) {

        if (keyword == "")
            TMPComponent.SetText(defaultText);

        else
            TMPComponent.SetText(ConstructSentenceWithKeyword(keyword));


        Debug.Log(keyword);
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
        SetKeywordElement();
        TMPComponent.SetText(defaultText);
        gameObject.SetActive(false);
    }

   


}
