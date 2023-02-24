using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class TokenData {

    public string tokenName;

    public int versionNumber;

    public int size;
    public int chestType;
    public int raceID;
    public int bodyType;
    public int raceType;
    public string head;

    public int hairSprite;
    public int capeSprite;
    public int backSprite;
    public int shoulderSprite;
    public int helmetSprite;
    public int hornSprite;
    public int tailSprite;

    public bool[] clothingSprites;
    public bool[] handSprites;
    public bool[] equipmentSprites;

    public float[] paperdollLayerRotations;
    public float[] paperdollClothingLayerRotations;
    public float[] paperdollHandLayerRotations;
    public float[] paperdollEquipmentLayerRotations;

    public string[] paperdollLayerHexColors;
    public string[] paperdollClothingLayerHexColors;
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

        paperdollLayerRotations = token.paperdollLayerRotations;
        paperdollClothingLayerRotations = token.paperdollClothingLayerRotations;
        paperdollHandLayerRotations = token.paperdollHandLayerRotations;
        paperdollEquipmentLayerRotations = token.paperdollEquipmentLayerRotations;

        paperdollLayerHexColors = new string[token.paperdollLayerColors.Length];
        paperdollClothingLayerHexColors = new string[token.paperdollClothingLayerColors.Length];
        paperdollHandLayerHexColors = new string[token.paperdollHandLayerColors.Length];
        paperdollEquipmentLayerHexColors = new string[token.paperdollEquipmentLayerColors.Length];


        for (int i = 0; i < paperdollLayerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollLayerColors[i]));
            paperdollLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollLayerColors[i]);
            
        }

        for (int i = 0; i < paperdollClothingLayerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollClothingLayerColors[i]));
            paperdollClothingLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollClothingLayerColors[i]);
            
        }

        for (int i = 0; i < paperdollHandLayerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollHandLayerColors[i]));
            paperdollHandLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollHandLayerColors[i]);
            
        }

        for (int i = 0; i < paperdollEquipmentLayerHexColors.Length; i++)
        {
            //Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollEquipmentLayerColors[i]));
            paperdollEquipmentLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollEquipmentLayerColors[i]);
            
        }

    }


}
