using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_RaceButtonFix : ButtonGroupBehaviour
{

    CharacterCreator characterCreator;

    Token currentToken;

    int currentRace;
    
    /*private void Awake()
    {
        bgb = GetComponent<ButtonGroupBehaviour>();
        
        childButtons = GetComponentsInChildren<Button>();

        currentToken = characterCreator.currentToken;
        Debug.Log("dd");
    }*/

    
    private void OnEnable()
    {

        characterCreator = FindObjectOfType<CharacterCreator>() as CharacterCreator;
        currentToken = characterCreator.currentToken;
        currentRace = currentToken.raceID - 1;
        TogglePressedStateAsGroup(buttonGroup[currentRace]);
        
    }


}
