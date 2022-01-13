using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;
using TMPro;

public class UI_MediaPlayerTimer : MonoBehaviour
{
    public TextMeshProUGUI timeLapsed;
    public TextMeshProUGUI totalTime;

    AudioManager audioManager;

    void FindAudioManager() 
    {

        audioManager = FindObjectOfType<AudioManager>() as AudioManager;
        audioManager.OnSongChange += SetTimerValues;
    
    }

    void SetTimerValues(string text, float songLength) 
    {


        //timeLapsed.text = audioManager.mainAudioSource.time.ToString("0");
    
    
    }

    /*string SecondsToMinutesandSeconds(float seconds) {

        string s;

        float minutes = Mathf.Floor(seconds / 60.0f);

        float minutesInSeconds = minutes * 60.0f;
        seconds = seconds - 



        return s;
    
    }*/

    private void Awake()
    {
        FindAudioManager();
    }

    void Update()
    {
        
    }
}
