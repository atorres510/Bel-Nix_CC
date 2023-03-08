using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class TokenData {

    public string tokenName;
    public float versionNumber;

    public int size;
    public int chestType;
    public int raceID;
    public int bodyType;
    public int raceType;
    public string head;

    public string hairSprite;
    public int capeSprite;
    public int backSprite;
    public int shoulderSprite;
    public int helmetSprite;
    public int hornSprite;
    public int tailSprite;

    public bool[] clothingSprites;
    public bool[] handSprites;
    public bool[] equipmentSprites;

    public float[] layerRotations;
    public float[] clothingLayerRotations;
    public float[] handLayerRotations;
    public float[] equipmentLayerRotations;

    public string[] layerHexColors;
    public string[] clothingLayerHexColors;
    public string[] paperdollHandLayerHexColors;
    public string[] paperdollEquipmentLayerHexColors;

    public TokenData() { }

    public TokenData(Token token) {


        tokenName = token.tokenName;
        versionNumber = token.versionNumber;

        size = token.size;
        chestType = token.chestType;
        raceID = token.raceID;
        raceType = token.raceType;
        bodyType = token.bodyType;
        head = token.head;

        hairSprite = token.hairSprite;
        capeSprite = token.capeSprite;
        backSprite = token.backSprite;
        shoulderSprite = token.shoulderSprite;
        helmetSprite = token.helmetSprite;
        hornSprite = token.hornSprite;
        tailSprite = token.tailSprite;

        clothingSprites = token.clothingSprites;
        handSprites = token.handSprites;
        equipmentSprites = token.equipmentSprites;

        layerRotations = token.layerRotations;
        clothingLayerRotations = token.clothingLayerRotations;
        handLayerRotations = token.handLayerRotations;
        equipmentLayerRotations = token.equipmentLayerRotations;

        layerHexColors = new string[token.layerColors.Length];
        clothingLayerHexColors = new string[token.clothingLayerColors.Length];
        paperdollHandLayerHexColors = new string[token.handLayerColors.Length];
        paperdollEquipmentLayerHexColors = new string[token.equipmentLayerColors.Length];


        for (int i = 0; i < layerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollLayerColors[i]));
            layerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.layerColors[i]);
            
        }

        for (int i = 0; i < clothingLayerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollClothingLayerColors[i]));
            clothingLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.clothingLayerColors[i]);
            
        }

        for (int i = 0; i < paperdollHandLayerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollHandLayerColors[i]));
            paperdollHandLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.handLayerColors[i]);
            
        }

        for (int i = 0; i < paperdollEquipmentLayerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollEquipmentLayerColors[i]));
            paperdollEquipmentLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.equipmentLayerColors[i]);
            
        }

    }


}
