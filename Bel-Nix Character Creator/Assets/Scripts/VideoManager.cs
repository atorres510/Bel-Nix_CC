using UnityEngine;

public class VideoManager : MonoBehaviour
{

    int currentWidth = 1920;
    int currentHeight = 1080;
    bool isFullscreen;


    public void DropdownResolutionData(int i) {

        switch (i)
        {

            case 0:
                currentWidth = 1920;
                currentHeight = 1080;
                break;
            case 1:
                currentWidth = 1600;
                currentHeight = 900;
                break;
            case 2:
                currentWidth = 1280;
                currentHeight = 720;
                break;
            case 3:
                currentWidth = 1152;
                currentHeight = 648;
                break;
            case 4:
                currentWidth = 1024;
                currentHeight = 576;
                break;
                
        }

        Debug.Log("Width: " + currentWidth + "," + " Height: " + currentHeight);
        
    }

    public void DropdownFullscreenData(int i)
    {

        switch (i)
        {

            case 0:
                
                break;
            case 1:
                currentWidth = 1600;
                currentHeight = 900;
                break;
            case 2:
                currentWidth = 1280;
                currentHeight = 720;
                break;
            case 3:
                currentWidth = 1152;
                currentHeight = 648;
                break;
            case 4:
                currentWidth = 1024;
                currentHeight = 576;
                break;

        }

    }

    public void ChangeResolution() {

        Screen.SetResolution(currentWidth, currentHeight, isFullscreen);
        
    }

    public void SetFullscreen(bool fullScreen) {

        isFullscreen = fullScreen;

    }
    
    private void Awake()
    {

        currentWidth = Screen.width;
        currentHeight = Screen.height;
        isFullscreen = Screen.fullScreen;
        
    }


}
