using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MediaPlayerSlider : MonoBehaviour
{

    AudioManager audioManager;
   
    
    Slider slider;
    static float currentSongLength = 0;

    void GetComponents() {

        slider = gameObject.GetComponent<Slider>();
        
        
    }

    void SubscribeToAudioManagerEvents() {

        audioManager.OnSongChange += UpdateMaxValue;
        
    }
    void UnsubscribeToAudioManagerEvents()
    {

        audioManager.OnSongChange -= UpdateMaxValue;

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
        audioManager = FindObjectOfType<AudioManager>() as AudioManager;
        GetComponents();
        UpdateMaxValue(audioManager.playList[audioManager.CurrentSong].length);
    
    }

    private void OnEnable()
    {
        SubscribeToAudioManagerEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToAudioManagerEvents();
    }



    // Update is called once per frame
    void Update()
    {

        UpdateSliderValue();

    }
}
