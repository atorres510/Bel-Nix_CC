using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public string audioSourceTag = "AudioSource";

    [Space(10)]

    public static bool isShuffling;

    [Space(10)]

    public static int startingSong;
    public AudioClip[] playList;


    AudioSource mainAudioSource;

    public AudioSource MainAudioSource {

        get { return mainAudioSource; }

    }
    
    static bool isFirstLoad = true;
    static int currentSong;
    static float[] songLengths;
    static Stack<int> previousSongs = new Stack<int>();


    public event SongChangeEvent OnSongChange;
    public delegate void SongChangeEvent(string songName, float songLength);



    #region AudioSource Methods
    //finds all audiosources in the game. determines a primary audio source at the first scene of game.  subsequent scenes 
    //will have all other sources except the primary audiosource removed.
    void FindAudioSources() {

        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        if (audioSources.Length == 1)
            TagPrimaryAudioSource(audioSources[0].gameObject);
      

        else 
            RemoveOtherAudioSources(audioSources);
        


    }

    void AudioLoadAssist() {



    }

    void TurnOnLoadInBackground(AudioClip clip) {
        
    }

    void TurnOffLoadInBackground(AudioClip clip) {



    }


    //tags audio source as primary;
    void TagPrimaryAudioSource(GameObject audioObject) {

        audioObject.tag = audioSourceTag;
        mainAudioSource = audioObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(audioObject);

    }

    //removes all other audio sources that do not have the tag.
    void RemoveOtherAudioSources(AudioSource[] audioSources) {

        foreach (AudioSource a in audioSources)
        {

            if (a.gameObject.tag == audioSourceTag)
                mainAudioSource = a;

            else
                Destroy(a.gameObject);


        }
        
    }

    void OnFirstLoad() {

        if (isFirstLoad)
        {
            AudioClip newClip = playList[startingSong];
            mainAudioSource.clip = newClip;
            currentSong = startingSong;

            OnSongChange?.Invoke(newClip.name, newClip.length);
            mainAudioSource.Play();
            isFirstLoad = false;

        }

        else return;

    }

    bool IsSongOver() {

        float f_currentTime = mainAudioSource.time;
        float f_totalSongTime = mainAudioSource.clip.length;

        int currentTime = (int)f_currentTime;
        int totalSongTime = (int)f_totalSongTime;

        bool isSongOver = (currentTime == totalSongTime);

        //Debug.Log("isSongOver: " + isSongOver);

        return isSongOver;

    }

    #endregion

    #region Playlist Methods

    void GetSongLengths() {

        for (int i = 0; i < playList.Length; i++) {

            songLengths[i] = playList[i].length;
            


        }


    }

    int ReturnNextSong() {

        int nextSong = 0;

        previousSongs.Push(currentSong);

        if (isShuffling)
        {

            do
            {

                nextSong = Random.Range(0, playList.Length);

            } while (nextSong == currentSong);

        }

        else {

            nextSong = currentSong + 1;

            if (playList.Length <= nextSong)
            {

                nextSong = 0;

            }

            else { };

        }
            
            
        return nextSong;
    }

    int ReturnPreviousSong() {

        int previousSong;

        if (previousSongs.Count != 0)
            previousSong = previousSongs.Pop();
        else
            previousSong = 0;
        
        return previousSong;

    }
    

    #endregion

    #region Media Player Methods

    public void TogglePlay() {

        if (mainAudioSource.isPlaying)
            mainAudioSource.Pause();
        else
            mainAudioSource.Play();

    }

    public void ToggleLoop() {

        if (mainAudioSource.loop)
            mainAudioSource.loop = false;
        else
            mainAudioSource.loop = true;

    }

    public void ToggleShuffle() {

        if (isShuffling)
            isShuffling = false;
        else
            isShuffling = true;

    }

    public void PlayNextSong() {

        currentSong = ReturnNextSong();

        AudioClip newClip = playList[currentSong];

        mainAudioSource.Stop();
        mainAudioSource.clip = newClip;
        mainAudioSource.Play();
        
        OnSongChange?.Invoke(newClip.name, newClip.length);
        Debug.Log("Now Playing: " + newClip.name);

    }

    public void PlayLastSong() {

        currentSong = ReturnPreviousSong();


        AudioClip newClip = playList[currentSong];

        mainAudioSource.Stop();
        mainAudioSource.clip = newClip;
        mainAudioSource.Play();

        OnSongChange?.Invoke(newClip.name, newClip.length);
        Debug.Log("Now Playing: " + playList[currentSong].name);
    }
    
    #endregion


    private void Awake()
    {

        FindAudioSources();

        OnFirstLoad();
        
        Debug.Log("Currently Playing: " + playList[currentSong].name);

    }

    private void Update()
    {
        if (IsSongOver() && !mainAudioSource.loop)
            PlayNextSong();
    }

}
