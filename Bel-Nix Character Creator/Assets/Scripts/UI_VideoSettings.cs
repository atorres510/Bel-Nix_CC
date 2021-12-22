using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_VideoSettings : MonoBehaviour
{

    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;


    void UpdateResDropdown() {

        int x = Screen.width;
        int y = Screen.height;

        string s_x = x.ToString();
        string s_y = y.ToString();


        string resolution = s_x + " x " + s_y;

        Debug.Log(resolution);

        switch (resolution) {

            case "1920 x 1080":
                resolutionDropdown.value = 0;
                break;

            case "1600 x 900":
                resolutionDropdown.value = 1;
                break;

            case "1280 x 720":
                resolutionDropdown.value = 2;
                break;

            default:
                break;
                
        }
    
    }

    void UpdateFullScreenToggle() {

        fullScreenToggle.isOn = Screen.fullScreen;
    
    }


    private void OnEnable()
    {
        UpdateResDropdown();
        UpdateFullScreenToggle();

    }


}
