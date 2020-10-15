using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TokenData {

    public int size;
    public int chestType;
    public int race;
    public int bodyType;

    public int hairSprite;
    public int capeSprite;
    public int backSprite;
    public int shoulderSprite;
    public int handSprite;
    public int headSprite;
    public int helmetSprite;
    public int racialSprite;

    public bool[] clothingSprites;
    public bool[] handSprites;

    public string[] paperdollLayerHexColors;
    public string[] paperdollClothingLayerHexColors;
    public string[] paperdollHandLayerHexColors;

    public TokenData(Token token) {

        size = token.size;
        chestType = token.chestType;
        race = token.race;
        bodyType = token.bodyType;

        hairSprite = token.hairSprite;
        capeSprite = token.capeSprite;
        backSprite = token.backSprite;
        shoulderSprite = token.shoulderSprite;
        handSprite = token.handSprite;
        headSprite = token.headSprite;
        helmetSprite = token.helmetSprite;
        racialSprite = token.racialSprite;

        clothingSprites = token.clothingSprites;
        handSprites = token.handSprites;

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

            paperdollClothingLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollClothingLayerColors[i]);


        }

        for (int i = 0; i < paperdollHandLayerHexColors.Length; i++)
        {

            paperdollHandLayerHexColors[i] = ColorUtility.ToHtmlStringRGBA(token.paperdollHandLayerColors[i]);


        }
        
    }


}
