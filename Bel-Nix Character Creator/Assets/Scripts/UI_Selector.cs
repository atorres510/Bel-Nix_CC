using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Selector : MonoBehaviour
{

    RectTransform rect;

    public void SelectThis(RectTransform buttonTransform) {

        gameObject.SetActive(true);

        rect.anchoredPosition = buttonTransform.anchoredPosition;
        

        Debug.Log("Button Name: " + buttonTransform.name);
        Debug.Log(buttonTransform.anchoredPosition);
    }

    public void ResetSelector()
    {
        rect.transform.localPosition= new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        ResetSelector();
    }

}
