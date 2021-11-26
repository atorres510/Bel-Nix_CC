using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public string audioSourceTag = "AudioSource";

    AudioSource audioSource;
    
    //finds all audiosources in the game. determines a primary audio source at the first scene of game.  subsequent scenes 
    //will have all other sources except the primary audiosource removed.
    void FindAudioSources() {

        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        if (audioSources.Length == 1)
            TagPrimaryAudioSource(audioSources[0].gameObject);
      

        else 
            RemoveOtherAudioSources(audioSources);
        
    }

    //tags audio source as primary;
    void TagPrimaryAudioSource(GameObject audioObject) {

        audioObject.tag = audioSourceTag;
        audioSource = audioObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(audioObject);

    }

    //removes all other audio sources that do not have the tag.
    void RemoveOtherAudioSources(AudioSource[] audioSources) {

        foreach (AudioSource a in audioSources)
        {

            if (a.gameObject.tag == audioSourceTag)
                audioSource = a;

            else
                Destroy(a.gameObject);


        }
        
    }
    
    private void Awake()
    {

        FindAudioSources();

    }

}
