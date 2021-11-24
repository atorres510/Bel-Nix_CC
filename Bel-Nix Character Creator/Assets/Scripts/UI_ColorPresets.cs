using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ColorPresets : MonoBehaviour
{

    public GameObject[] colorPresets;

    Token currentToken;
    
    Token ReturnCurrentToken() {

        GameObject tokenObject = GameObject.FindGameObjectWithTag("CurrentToken");
        Token tokenComponent = tokenObject.GetComponent<Token>();

        return tokenComponent;

    }

    void SetActiveColorPreset(int value) {

       value--; //to correct for array element values at index 0;

        foreach (GameObject color in colorPresets) {
            color.SetActive(false);
        }

        colorPresets[value].SetActive(true);
        
    }
    
    private void Awake()
    {

        currentToken = ReturnCurrentToken();
        currentToken.ChangeTokenRaceEvent += SetActiveColorPreset;
        SetActiveColorPreset(currentToken.raceID);
       
    }

}
