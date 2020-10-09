using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupBehaviour : MonoBehaviour
{
    Button button;

    Button[] buttonGroup;

    int myButton = 0;

    //for button UI
    public void OnPress() {

        if (!IsButtonPressed()) {
            TogglePressedStateAsGroup();
        }
        
    }
    
    //For use in Start().  sets buttongroup based on the fellow children of the parent of this object
    void FindButtonGroup() {

        GameObject parentObject = gameObject.transform.parent.gameObject;

        buttonGroup = parentObject.GetComponentsInChildren<Button>();
        
    }

    //For use in Start(). finds the index of this button within the buttongroup
    void FindMyButton() {

        for (int i = 0; i < buttonGroup.Length; i++) {

            if (button == buttonGroup[i])
            {

                myButton = i;
                break;

            }

            else { }

        }
        
    }
    
    //checks if the button is in the pressed state, returning true if it is.
    bool IsButtonPressed()
    {

        if (!button.IsInteractable())
            return true;

        else
            return false;

    }
    
    //toggles between pressed and normal states.
    void TogglePressedState()
    {

        button.interactable = !button.IsInteractable();

    }

    //toggles a set of buttons as a group, ensuring only one button is pressed from the group at a time. similar to a toggle group component
    void TogglePressedStateAsGroup()
    {

        for (int i = 0; i < buttonGroup.Length; i++)
        {
            
            if (i == myButton)
            { //looks for this button within the grid, making sure it is in the pressed state

                buttonGroup[i].interactable = false;

            }

            else
            {// sets the rest of the buttons in the grid that are not the target button to normal color (unpressed)

                buttonGroup[i].interactable = true;

            }

        }

    }

    void Start()
    {
        
        button = gameObject.GetComponent<Button>();
        FindButtonGroup();
        FindMyButton();

    }

}
