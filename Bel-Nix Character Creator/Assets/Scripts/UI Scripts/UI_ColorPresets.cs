using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ColorPresets : MonoBehaviour
{

    public GameObject[] colorPresets;
    
    void SetActiveColorPreset(int value) {

        value--; //to correct for array element values at index 0;

        foreach (GameObject color in colorPresets) {
            color.SetActive(false);
        }

        colorPresets[value].SetActive(true);
        
    }
    
    private void Awake()
    {

        CharacterCreator characterCreator = FindObjectOfType<CharacterCreator>();
        characterCreator.ChangeTokenRaceEvent += SetActiveColorPreset;
        SetActiveColorPreset(characterCreator.currentToken.raceID);
       
    }

}
