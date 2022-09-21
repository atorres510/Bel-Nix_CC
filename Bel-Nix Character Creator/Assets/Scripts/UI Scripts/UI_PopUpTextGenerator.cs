using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PopUpTextGenerator : MonoBehaviour
{
    public GameObject popUpPrefab;
    public float popUpFadeTime = 3f;
    public GameObject popUpAnchorOverride;

    //for event subscriptions
    private void Start()
    {

        DataManger dataManagerEvents = FindObjectOfType<DataManger>();
        dataManagerEvents.OnSaveToken += DisplayPopUp;
        dataManagerEvents.OnLoadToken += DisplayPopUp;

        ImageExporter imageExporterEvents = FindObjectOfType<ImageExporter>();
        imageExporterEvents.OnExportToken += DisplayPopUp;
       
    }
    
    public void DisplayPopUp(string textToDisplay)
    {
        if (popUpPrefab == null) {
            Debug.LogError("Pop-Up Prefab missing.");
            return;
        }

        GameObject popUp = InstantiateandReturnNewPopUp(popUpPrefab);
        SetDisplayText(popUp, textToDisplay);
        StartCoroutine(PopUpTimer(popUp, popUpFadeTime));
       
    }

    public void DisplayPopUp(string textToDisplay, float displayTimer)
    {
        if (popUpPrefab == null)
        {
            Debug.LogError("Pop-Up Prefab missing.");
            return;
        }

        GameObject popUp = InstantiateandReturnNewPopUp(popUpPrefab);
        SetDisplayText(popUp, textToDisplay);
        StartCoroutine(PopUpTimer(popUp, displayTimer));

    }

    //instantiates the prefab and returns it.
    GameObject InstantiateandReturnNewPopUp(GameObject prefab) {
        
        //default to canvas as the parent object
        GameObject parentObject = GameObject.FindGameObjectWithTag("Canvas");

        //ensure that the anchor is part of the canvas, if !=null override as parent object
        if (popUpAnchorOverride != null)
            parentObject = popUpAnchorOverride;

        GameObject newPopUpObject = Instantiate(popUpPrefab, parentObject.transform);

        return newPopUpObject;
    }
    
    void SetDisplayText(GameObject popUpObject, string text)
    {
        TextMeshProUGUI TMPComponent;
        TMPComponent = popUpObject.GetComponentInChildren<TextMeshProUGUI>();
        TMPComponent.SetText(text);
    }

    IEnumerator PopUpTimer(GameObject popUpObject, float seconds)
    {

        yield return new WaitForSecondsRealtime(seconds);
        popUpObject.SetActive(false);
        Destroy(popUpObject);

    }

    
}
