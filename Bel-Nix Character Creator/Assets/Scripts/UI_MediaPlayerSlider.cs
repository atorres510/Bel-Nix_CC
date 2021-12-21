using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MediaPlayerSlider : MonoBehaviour
{

    public AudioManager audioManager;
    //AudioSource audioSource;
    
    Slider slider;
    static float currentSongLength = 0;

    void GetComponents() {

        slider = gameObject.GetComponent<Slider>();
        //audioSource = audioManager.MainAudioSource;
        
    }

    void SubscribeToAudioManagerEvents() {

        audioManager.OnSongChange += UpdateMaxValue;
        
    }

    void UpdateSliderValue() {

        slider.value = audioManager.MainAudioSource.time;
        //Debug.Log(audioSource.time);
        
    }

    void UpdateMaxValue(string name, float songLength) {

        currentSongLength = songLength;
        slider.maxValue = currentSongLength;
        Debug.Log(slider.maxValue);

    }

    void UpdateMaxValue(float songLength) {

        currentSongLength = songLength;
        slider.maxValue = currentSongLength;
        Debug.Log(slider.maxValue);

    }
    


    private void Awake()
    {
        GetComponents();
        SubscribeToAudioManagerEvents();
        UpdateMaxValue(currentSongLength);

    }


    // Update is called once per frame
    void Update()
    {

        UpdateSliderValue();

    }
}
