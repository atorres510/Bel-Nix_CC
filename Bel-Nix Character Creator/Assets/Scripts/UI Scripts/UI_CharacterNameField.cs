using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterNameField : MonoBehaviour
{



    //subscribe to events
    private void Start()
    {
        Token currentToken = ReturnCurrentToken();
        currentToken.ChangeTokenNameEvent += UpdateInputField;

    }

    Token ReturnCurrentToken()
    {

        GameObject tokenObject = GameObject.FindGameObjectWithTag("CurrentToken");
        Token tokenComponent = tokenObject.GetComponent<Token>();

        return tokenComponent;

    }

    void UpdateInputField(string text)
    {

        InputField inputField = gameObject.GetComponent<InputField>();

        inputField.text = text;
        //inputField.onEndEdit.Invoke(text);

    }


}
