using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{

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

    public Color[] paperdollLayerColors;
    public Color[] paperdollClothingLayerColors;
    public Color[] paperdollHandLayerColors;


    public Token(TokenData data) {

        size = data.size;
        chestType = data.chestType;
        race = data.race;
        bodyType = data.bodyType;

        hairSprite = data.hairSprite;
        capeSprite = data.capeSprite;
        backSprite = data.backSprite;
        shoulderSprite = data.shoulderSprite;
        handSprite = data.handSprite;
        headSprite = data.headSprite;
        helmetSprite = data.helmetSprite;
        racialSprite = data.racialSprite;

        clothingSprites = data.clothingSprites;
        handSprites = data.handSprites;

        for (int i = 0; i < paperdollLayerColors.Length; i++) {

            ColorUtility.TryParseHtmlString(data.paperdollLayerHexColors[i], out paperdollLayerColors[i]);
            
        }

        for (int i = 0; i < paperdollClothingLayerColors.Length; i++){

            ColorUtility.TryParseHtmlString(data.paperdollClothingLayerHexColors[i], out paperdollClothingLayerColors[i]);

        }

        for (int i = 0; i < paperdollLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString(data.paperdollHandLayerHexColors[i], out paperdollHandLayerColors[i]);

        }




    }


}
