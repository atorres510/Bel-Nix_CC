using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterNameField : MonoBehaviour
{
    
    //subscribe to events
    private void Awake()
    {
        Token currentToken = ReturnCurrentToken();
        currentToken.ChangeTokenNameEvent += UpdateInputField;

        DataManger.FindObjectOfType<DataManger>().OnLoadToken += UpdateInputField;

    }

    Token ReturnCurrentToken()
    {

        CharacterCreator characterCreator = FindObjectOfType<CharacterCreator>();

        return characterCreator.currentToken;

        //GameObject tokenObject = GameObject.FindGameObjectWithTag("CurrentToken");
        //Token tokenComponent = tokenObject.GetComponent<Token>();

       // return tokenComponent;

    }

    public void CallTokenNameEvent(string input) {

        Token currentToken = ReturnCurrentToken();

        currentToken.ChangeTokenName(input);
        
    }

    void UpdateInputField(string text)
    {

        InputField inputField = gameObject.GetComponent<InputField>();

        string[] textSplit = text.Split(' ');

        text = textSplit[0];

        inputField.text = text;
        //inputField.onEndEdit.Invoke(text);

    }


}
