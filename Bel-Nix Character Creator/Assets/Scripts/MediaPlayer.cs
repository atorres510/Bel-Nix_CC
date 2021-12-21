using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaPlayer : MonoBehaviour
{
    AudioManager audioManager;
    AudioSource mainAudioSource;
    
    public Toggle loopToggle;
    public Toggle shuffleToggle;
    public Toggle playPauseToggle;
    public Toggle muteToggle;

    public Slider volumeSlider;
    public Slider timeSlider;

    public void SetLoopToggle(bool b) {

        loopToggle.isOn = b;
        
    }


    public void SetShuffleToggle(bool b)
    {

        shuffleToggle.isOn = b;

    }

    public void SetPlayPauseToggle(bool b)
    {

        playPauseToggle.isOn = b;

    }


    public void SetMuteToggle(bool b)
    {

        muteToggle.isOn = b;

    }

    public void SetVolumeSlider(float f) {

        volumeSlider.value = f;

    }

    public void SetTimeSlider(float f)
    {

        timeSlider.value = f;

    }

    void FindAudioManager() {

        audioManager = FindObjectOfType<AudioManager>() as AudioManager;
        
    }

}
