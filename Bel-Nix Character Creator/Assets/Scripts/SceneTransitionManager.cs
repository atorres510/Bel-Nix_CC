using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    public void QuitGame() {

        Application.Quit();

    }

    public void LoadScene(int scene) {

        SceneManager.LoadScene(scene);
        
    }



}
