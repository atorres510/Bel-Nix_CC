using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ToggleImage : MonoBehaviour
{
    public Image checkmarkImage;

    public Sprite onSprite;
    public Sprite offSprite;

    Toggle thisToggle;
    bool currentBoolState;

    void GetComponents() {
        
        thisToggle = gameObject.GetComponent<Toggle>();

    }

    void FindChildImage() {

        Transform backgroundTransform = gameObject.GetComponentInChildren<Transform>();
        Transform checkmarkTransform;
        checkmarkTransform = backgroundTransform.Find("Checkmark");
        checkmarkImage = checkmarkTransform.GetComponentInChildren<Image>();
        Debug.Log(checkmarkImage);
        
    }

    void ChangeSprite(Sprite sprite) {

        checkmarkImage.sprite = sprite;

    }

    void ToggleSprite() {

        if (thisToggle.isOn)
            ChangeSprite(onSprite);
        else
            ChangeSprite(offSprite);

    }
    
    private void Awake()
    {
        GetComponents();
        //FindChildImage();
    }




    // Update is called once per frame
    void Update()
    {

        ToggleSprite();
        
    }
}
