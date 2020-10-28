using UnityEngine;

public class Token : MonoBehaviour
{
    public string tokenName = "";

    public int size;
    public int chestType;
    public int raceID;
    public int raceType;
    public int bodyType;
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
    
    public Color[] paperdollLayerColors;
    public Color[] paperdollClothingLayerColors;
    public Color[] paperdollHandLayerColors;


    public Token(TokenData data) {

        size = data.size;
        chestType = data.chestType;
        raceID = data.raceID;
        raceType = data.raceType;
        bodyType = data.bodyType;
        head = data.head;

        hairSprite = data.hairSprite;
        capeSprite = data.capeSprite;
        backSprite = data.backSprite;
        shoulderSprite = data.shoulderSprite;
        helmetSprite = data.helmetSprite;
        racialSprite = data.racialSprite;

        clothingSprites = data.clothingSprites;
        handSprites = data.handSprites;

        paperdollLayerRotations = data.paperdollLayerRotations;
        paperdollClothingLayerRotations = data.paperdollClothingLayerRotations;
        paperdollHandLayerRotations = data.paperdollHandLayerRotations;

        paperdollLayerColors = new Color[data.paperdollLayerHexColors.Length];
        paperdollClothingLayerColors = new Color[data.paperdollClothingLayerHexColors.Length];
        paperdollHandLayerColors = new Color[data.paperdollHandLayerHexColors.Length];

        for (int i = 0; i < paperdollLayerColors.Length; i++) {

            ColorUtility.TryParseHtmlString(data.paperdollLayerHexColors[i], out paperdollLayerColors[i]);
            
        }

        for (int i = 0; i < paperdollClothingLayerColors.Length; i++){

            ColorUtility.TryParseHtmlString(data.paperdollClothingLayerHexColors[i], out paperdollClothingLayerColors[i]);

        }

        for (int i = 0; i < paperdollHandLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString(data.paperdollHandLayerHexColors[i], out paperdollHandLayerColors[i]);

        }
        
    }

    public Token(Token token)
    {

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

        paperdollLayerColors = token.paperdollLayerColors;
        paperdollClothingLayerColors = token.paperdollClothingLayerColors;
        paperdollHandLayerColors = token.paperdollHandLayerColors;
        
    }

}
