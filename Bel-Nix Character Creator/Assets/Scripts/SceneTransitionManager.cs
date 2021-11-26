using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    public Animator animator;
    public Canvas fadeCanvas;

    int nextSceneToLoad = 0;

    public void QuitGame() {

        Application.Quit();

    }

    public void TransitionToNextScene(int sceneID) {

        SetNextSeceneToLoad(sceneID);
        SceneFadeOut();
        
    }

    public void LoadScene() {

        SceneManager.LoadScene(nextSceneToLoad);
        
    }

    void SetNextSeceneToLoad(int sceneID) {

        nextSceneToLoad = sceneID;
        
    }


    public void SceneFadeIn(Scene scene, LoadSceneMode mode) {

        animator.SetTrigger("FadeInAnim");

    }

    public void SceneFadeOut() {

        animator.SetTrigger("FadeOutAnim");

    }

    private void Awake()
    {
        //SceneManager.sceneLoaded += SceneFadeIn;
    }


}
