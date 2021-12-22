using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public string audioSourceTag = "AudioSource";
    public string audioManagerTag = "AudioManager";

    [Space(10)]

    static bool isLooping;
    static bool isShuffling;
    static bool isMuted;
    static int startingSong = 0;
    public AudioClip[] playList;

    static float sourceVolume = 0.25f;

    AudioSource mainAudioSource;

    public AudioSource MainAudioSource {

        get { return mainAudioSource; }

    }

    static bool isFirstLoad = true;
    static int currentSong;
    //static float[] songLengths;
    static Stack<int> previousSongs = new Stack<int>();


    public event SongChangeEvent OnSongChange;
    public delegate void SongChangeEvent(string songName, float songLength);

    public event OnLoadEvent OnLoad;
    public delegate void OnLoadEvent();

    public bool IsLooping
    {

        get { return isLooping; }

    }

    public bool IsShuffling
    {

        get { return isShuffling; }

    }

    public bool IsMuted
    {

        get { return isMuted; }

    }

    public float SourceVolume
    {

        get { return sourceVolume; }

    }

    /*public float[] SongLengths 
    {

        get { return songLengths; }
        
    }*/

    public int CurrentSong 
    {
    
        get { return currentSong; }
    
    }
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


    void SyncAudioVariablesToSource(AudioSource source) {

        source.loop = isLooping;
        source.mute = isMuted;
                
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

    //removes all other audio sources that do not have the tag.
    void RemoveOtherAudioManagers(AudioManager[] audioManagers)
    {

            foreach (AudioManager a in audioManagers)
            {

                if (a.gameObject.tag == audioManagerTag) { }

                else
                    Destroy(a.gameObject);

            }
    


        

    }

    void OnFirstLoad() {

        if (isFirstLoad)
        {

            sourceVolume = 0.25f;
            AudioClip newClip = playList[startingSong];
            mainAudioSource.clip = newClip;
            currentSong = startingSong;

            OnSongChange?.Invoke(newClip.name, newClip.length);
            mainAudioSource.Play();
            gameObject.tag = "AudioManager";
            isFirstLoad = false;
            DontDestroyOnLoad(gameObject);
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

    public AudioClip GetCurrentSong() {

        return playList[currentSong];


    }

    #endregion

    #region Playlist Methods

    /*void GetSongLengths() {

        

        for (int i = 0; i < playList.Length; i++) {

            songLengths[i] = playList[i].length;
            
        }
        
    }*/

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

        if (isLooping)
        {
            isLooping = false;
            mainAudioSource.GetComponent<CleanMusicLoop>().enabled = false;
        }

        else {
            isLooping = true;
            mainAudioSource.GetComponent<CleanMusicLoop>().enabled = true;
        }
            

        Debug.Log("Looping = " + IsLooping);
        SyncAudioVariablesToSource(mainAudioSource);

    }

    public void ToggleMute() {

        if (isMuted)
            isMuted = false;
        else
            isMuted = true;

        Debug.Log("Muted = " + IsMuted);
        SyncAudioVariablesToSource(mainAudioSource);

    }

    public void ToggleShuffle() {

        if (isShuffling)
            isShuffling = false;
        else
            isShuffling = true;

        Debug.Log("Shuffle = " + IsShuffling);
        SyncAudioVariablesToSource(mainAudioSource);
    }

    public void SetVolume(float volume) {

        sourceVolume = volume;
        Debug.Log("Source Volume: " + sourceVolume);

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
        SceneManager.sceneLoaded += OnSceneLoaded;

        Debug.Log("AudioManager Awake Fired.");
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        Debug.Log("Currently Playing: " + playList[currentSong].name);
        if(!isFirstLoad)
            RemoveOtherAudioManagers(FindObjectsOfType<AudioManager>() as AudioManager[]);
        RemoveOtherAudioSources(FindObjectsOfType<AudioSource>() as AudioSource[]);
        Debug.Log("AudioManager OnSceneLoaded Fired."); 
    }

    private void Start()
    {
        OnFirstLoad();
    }

    private void Update()
    {
        if (IsSongOver() && !mainAudioSource.loop)
            PlayNextSong();

        mainAudioSource.volume = sourceVolume;

    }

}
