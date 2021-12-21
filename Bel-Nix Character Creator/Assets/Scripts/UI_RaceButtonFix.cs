using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_RaceButtonFix : MonoBehaviour
{

    public CharacterCreator characterCreator;

    Token currentToken;

    int currentRace;

    ButtonGroupBehaviour bgb;

    Button[] childButtons;
    
    private void Awake()
    {
        bgb = GetComponent<ButtonGroupBehaviour>();

        childButtons = GetComponentsInChildren<Button>();

        currentToken = characterCreator.currentToken;
    }


    private void OnEnable()
    {
        currentRace = currentToken.raceID - 1;
        bgb.TogglePressedStateAsGroup(childButtons[currentRace]);
    }


}
