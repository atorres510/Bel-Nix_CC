using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    //Methods for UI use on Main Menu
    
    //For exit button, quits the game.
    public void QuitGame() {

        Application.Quit();

    }

    //loads level
    public void LoadLevel(int levelID) {

        SceneManager.LoadScene(levelID);

    }
    
}
