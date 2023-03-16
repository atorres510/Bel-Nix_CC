using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PaperdollLayerObject
{

    public string name;
    public Sprite sprite;
    public float rotation;
    public Color color;
    [HideInInspector]
    public string spriteID; //hide to prevent getting incorrectly overwritten by developer in the inspector.  We need this to be public for JSON formattting.

    public string SpriteID { get => spriteID;}  
    
    public PaperdollLayerObject(string layerName, Sprite layerSprite, float layerRotation, Color layerColor) {

        name = layerName;
        sprite = layerSprite;
        spriteID = ConvertSpriteNameToSpriteID(sprite.name);
        rotation = layerRotation;
        color = layerColor;

    }
    
    public PaperdollLayerObject(Image layer)
    {

        name = layer.name;
        sprite = layer.sprite;
        spriteID = ConvertSpriteNameToSpriteID(sprite.name);
        rotation = layer.rectTransform.localRotation.y;
        color = layer.color;

    }

    public PaperdollLayerObject() { }

    string ConvertSpriteNameToSpriteID(string spriteName){

        if (spriteName == "")
            return "";

        string id = spriteName;

        string[] splitName = id.Split('_');

        id = splitName[splitName.Length - 1];

        return id;

    }

    public void ConvertSpriteToSpriteID() {

        if (sprite == null)
            return;
        
        string id = sprite.name;

        string[] splitName = id.Split('_');

        id = splitName[splitName.Length - 1];

        spriteID = id;
        
    }
    
}
