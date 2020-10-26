using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TokenData {

    public string tokenName;
    
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
    public int racialSprite;

    public bool[] clothingSprites;
    public bool[] handSprites;

    public float[] paperdollLayerRotations;
    public float[] paperdollClothingLayerRotations;
    public float[] paperdollHandLayerRotations;

    public string[] paperdollLayerHexColors;
    public string[] paperdollClothingLayerHexColors;
    public string[] paperdollHandLayerHexColors;

    public TokenData(Token token) {
        tokenName = token.tokenName;

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
        racialSprite = token.racialSprite;

        clothingSprites = token.clothingSprites;
        handSprites = token.handSprites;

        paperdollLayerRotations = token.paperdollLayerRotations;
        paperdollClothingLayerRotations = token.paperdollClothingLayerRotations;
        paperdollHandLayerRotations = token.paperdollHandLayerRotations;

        paperdollLayerHexColors = new string[token.paperdollLayerColors.Length];
        paperdollClothingLayerHexColors = new string[token.paperdollClothingLayerColors.Length];
        paperdollHandLayerHexColors = new string[token.paperdollHandLayerColors.Length];


        for (int i = 0; i < paperdollLayerHexColors.Length; i++)
        {
            Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollLayerColors[i]));
            paperdollLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollLayerColors[i]);
            

        }

        for (int i = 0; i < paperdollClothingLayerHexColors.Length; i++)
        {
            Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollClothingLayerColors[i]));
            paperdollClothingLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollClothingLayerColors[i]);


        }

        for (int i = 0; i < paperdollHandLayerHexColors.Length; i++)
        {
            Debug.Log(ColorUtility.ToHtmlStringRGBA(token.paperdollHandLayerColors[i]));
            paperdollHandLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollHandLayerColors[i]);


        }
        
    }


}
