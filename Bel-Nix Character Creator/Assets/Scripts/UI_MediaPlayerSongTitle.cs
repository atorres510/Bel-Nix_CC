using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_MediaPlayerSongTitle : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject maskObject;

    [Space(10)]

    public float scrollPadding = 0;

    TextMeshProUGUI textMesh;
    RectTransform maskRect;
    RectTransform thisRect;

    public float scrollSpeed;

    float border;

    static string currentSongName;
    
    
    void GetComponents() {

        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        thisRect = gameObject.GetComponent<RectTransform>();
        maskRect = maskObject.GetComponent<RectTransform>();

    }

    void SubscribeToAudioManagerEvents() {
        
        audioManager.OnSongChange += UpdateText;
         
    }

    void UnsubscribeToAudioManagerEvents()
    {

        audioManager.OnSongChange -= UpdateText;

    }

    float FindBorder() {

        return (thisRect.rect.width / 2) + (maskRect.rect.width / 2);
        
    }
    

    void UpdateText(string text, float time) {

        currentSongName = text;
        textMesh.text = currentSongName;
        ResetScroll();
        
    }

    void UpdateText(string text) {

        currentSongName = text;
        textMesh.text = currentSongName;
        ResetScroll();

    }

    void UpdateScroll() {

        if (!HasTextScrollCompleted())
            AutoScroll();
        else
            ResetScroll();

            

    }

    void ResetScroll() {

        float resetPositionX = (border) + scrollPadding;

        thisRect.anchoredPosition = new Vector2(resetPositionX, 0);

    }

    void AutoScroll() {

        thisRect.anchoredPosition += Vector2.left*scrollSpeed;
        
    }

    bool HasTextScrollCompleted() {

        bool hasTextCompletePass;

        hasTextCompletePass = thisRect.anchoredPosition.x < -(border);

        //Debug.Log("hascompletedpass:" + hasTextCompletePass);
        return (hasTextCompletePass);

    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        GetComponents();
        border = FindBorder();
        Debug.Log("Border: " + border);
        //Debug.Log(thisRect.rect.width + maskRect.rect.width / 2);
        UpdateText(audioManager.GetCurrentSong().name);
       
       
    }

    private void OnEnable()
    {
        SubscribeToAudioManagerEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToAudioManagerEvents();
    }

    private void Update()
    {
        UpdateScroll();
    }
}
