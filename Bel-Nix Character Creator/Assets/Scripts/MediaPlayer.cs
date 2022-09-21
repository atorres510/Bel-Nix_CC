using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaPlayer : MonoBehaviour
{
    AudioManager audioManager;
    AudioSource mainAudioSource;
    
    //UI Elements
    public Toggle loopToggle;
    public Toggle shuffleToggle;
    public Toggle playPauseToggle;
    public Toggle muteToggle;

    [Space(10)]
    public Button nextSong;
    public Button previousSong;

    [Space(10)]
    public Slider volumeSlider;
    //public Slider timeSlider;

    public void SetLoopToggle(bool b) {

        loopToggle.isOn = b;
        loopToggle.onValueChanged.AddListener(delegate { audioManager.ToggleLoop(); });
    }

    public void SetShuffleToggle(bool b)
    {

        shuffleToggle.isOn = b;
        shuffleToggle.onValueChanged.AddListener(delegate { audioManager.ToggleShuffle(); });

    }

    public void SetPlayPauseToggle(bool b)
    {

        playPauseToggle.isOn = b;
        playPauseToggle.onValueChanged.AddListener(delegate { audioManager.TogglePlay(); });
    }

    public void SetMuteToggle(bool b)
    {

        muteToggle.isOn = b;
        muteToggle.onValueChanged.AddListener(delegate { audioManager.ToggleMute(); });

    }

    void SetNextButton() {

        nextSong.onClick.AddListener(delegate { audioManager.PlayNextSong(); });
    
    }

    void SetPreviousButton()
    {

        previousSong.onClick.AddListener(delegate { audioManager.PlayLastSong(); });

    }

    public void SetVolumeSlider(float f) {

        volumeSlider.value = f;
        volumeSlider.onValueChanged.AddListener(delegate (float vol) { audioManager.SetVolume(vol); });

    }

    /*public void SetTimeSlider(float f)
    {

        timeSlider.value = f;

    }*/

    public void SyncUIElementstoAudio() {

        SetLoopToggle(audioManager.IsLooping);
        SetShuffleToggle(audioManager.IsShuffling);
        SetPlayPauseToggle(mainAudioSource.isPlaying);
        SetMuteToggle(audioManager.IsMuted);


        SetVolumeSlider(audioManager.SourceVolume);

        SetNextButton();
        SetPreviousButton();
    
    }
    
    void FindAudioManager() {

        audioManager = FindObjectOfType<AudioManager>() as AudioManager;
        
    }

    void SetMainAudioSource() {

        mainAudioSource = audioManager.MainAudioSource;
    
    }

    private void Start()
    {
        FindAudioManager();
        SetMainAudioSource();
        SyncUIElementstoAudio();
    }

}
