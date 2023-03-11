using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PaperdollLayerObject
{
   
    public string name;
    public Sprite sprite;
    public string spriteName;
    public float rotation;
    public Color color;


    public PaperdollLayerObject(string layerName, Sprite layerSprite, string layerSpriteName, float layerRotation, Color layerColor) {

        name = layerName;
        sprite = layerSprite;
        spriteName = layerSpriteName;
        rotation = layerRotation;
        color = layerColor;

        Debug.Log("hey");
        
    }
    
}
