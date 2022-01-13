using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Selector : MonoBehaviour
{
    GameObject MyPimpDaddy;
    RectTransform rect;

    public void SelectThis(RectTransform buttonTransform) {

        gameObject.SetActive(true);

        rect.SetParent(buttonTransform);

        rect.anchoredPosition = Vector2.zero;

        /*
        rect.anchoredPosition = buttonTransform.anchoredPosition;
        

        Debug.Log("Button Name: " + buttonTransform.name);
        Debug.Log(buttonTransform.anchoredPosition);*/

        

    }

    public void ResetSelector()
    {
        rect.transform.localPosition= new Vector3(0, 0, 0);
        rect.SetParent(MyPimpDaddy.transform);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        MyPimpDaddy = gameObject.transform.parent.gameObject;
        rect = gameObject.GetComponent<RectTransform>();
        ResetSelector();
        //Debug.Log("MyPimpDaddy = " + MyPimpDaddy.name);
    }

}
