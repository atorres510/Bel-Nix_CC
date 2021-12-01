using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    public Animator animator;
    [Space(10)]
    public Canvas IntroAnimCanvas;
    public Canvas fadeCanvas;

    Animator IntroAnimCanvasAnimator;

    public static bool isFirstLoad = true;
    int nextSceneToLoad = 0;

    public void QuitGame() {

        Application.Quit();

    }

    void InstantiateIntroAnimator() {

        if (IntroAnimCanvas != null)
            IntroAnimCanvasAnimator = IntroAnimCanvas.GetComponent<Animator>();
        else
            Debug.LogWarning("No intro animation canvas object.  Please set canvas object in the inspector.");


    }

    public void PlayIntroAnimation() {

        animator.SetTrigger("FadeInAnim");
        IntroAnimCanvasAnimator.SetTrigger("IntroAnim");
        isFirstLoad = false;

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
        InstantiateIntroAnimator();

        if(isFirstLoad)
            PlayIntroAnimation();


    }


}
