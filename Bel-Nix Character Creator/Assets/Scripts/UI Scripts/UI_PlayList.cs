using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PlayList : MonoBehaviour
{
    
    List<AudioClip> playList = new List<AudioClip>();
    
    public Button buttonPrefab;

    AudioManager audioManager;
    
    public void InstantiateButtons()
    {

        List<string> songNamesList = new List<string>();

        foreach (AudioClip song in playList) {

            songNamesList.Add(song.name);
            
        }

        string[] songNames = songNamesList.ToArray();
        
        if (songNames.Length == 0)
            return;

        for (int i = 0; i < songNames.Length; i++)
        {

            //Debug.Log(fileNames[i]);
            Button newButton = Instantiate(buttonPrefab, this.transform);

            newButton.GetComponentInChildren<TextMeshProUGUI>().SetText(songNames[i]);

            newButton.onClick.AddListener(delegate { audioManager.PlaySongByName(newButton.GetComponentInChildren<TextMeshProUGUI>().text); });
            
        }

    }


    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playList.AddRange(audioManager.playList);
        InstantiateButtons();
    }


}
