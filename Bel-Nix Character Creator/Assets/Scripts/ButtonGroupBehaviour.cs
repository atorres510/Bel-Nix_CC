using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonGroupBehaviour : MonoBehaviour
{
    public Button[] buttonGroup;

    //finds all the children and adds them to the group.
    public void FindButtonChildren() {

        buttonGroup = GetComponentsInChildren<Button>(true);
        
    }

    //uses onClick.AddListener to add the togglepressedstateasgroup() for each of the buttons in the group.
    public void AddListenersFunctions() {

        for (int i = 0; i < buttonGroup.Length; i++) {

            int button = i;

            buttonGroup[button].onClick.AddListener(delegate { TogglePressedStateAsGroup(buttonGroup[button]); });
            Debug.Log("Adding listener from " + buttonGroup[i].name + ".");
        }
       
    }


    //toggles a set of buttons as a group, ensuring only one button is pressed from the group at a time. similar to a toggle group component
    public void TogglePressedStateAsGroup(Button thisButton)
    {
        Debug.Log("Wow");
        thisButton.interactable = false; //this button is now pressed.
        
        for (int i = 0; i < buttonGroup.Length; i++)
        {
            //find the rest of the buttons in the group, and sets them to the unpressed state.
            if (buttonGroup[i] != thisButton)
            { 
                
                buttonGroup[i].interactable = true;

            }
            

        }

    }

    //to be called by a button that would activate the group to reset it.  
    public void ResetGroup() {

        for (int i = 0; i < buttonGroup.Length; i++) {

            buttonGroup[i].interactable = true;

        }
        
    }
    

    void Awake()
    {

        FindButtonChildren();
        AddListenersFunctions();
        
    }


}
