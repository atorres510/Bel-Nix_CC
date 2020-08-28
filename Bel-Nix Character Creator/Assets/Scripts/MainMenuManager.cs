using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    //For exit button, quits the game.
    public void QuitGame() {

        Application.Quit();

    }


    public void LoadLevel(int levelID) {

        SceneManager.LoadScene(levelID);

    }

    



}
