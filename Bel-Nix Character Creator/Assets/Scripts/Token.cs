using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public string tokenName = "";

    public float versionNumber;

    [Space(10)]

    [Header("Racial Traits")]
    public int size;
    public int raceID;
    public int raceType;
    public string head;

    [Space(10)]

    [Header("Body Traits")]
    public int chestType;
    public int bodyType;
    public string hairSprite;
    public int hornSprite;
    public int tailSprite;
    
    [Space(10)]

    [Header("Clothing/Equipment")]
    public int capeSprite;
    public int backSprite;
    public int shoulderSprite;
    public int helmetSprite;
  

    public List<string> clothingSprites = new List<string>();
    public bool[] handSprites;
    public bool[] equipmentSprites;

    public float[] layerRotations;
    public float[] clothingLayerRotations;
    public float[] handLayerRotations;
    public float[] equipmentLayerRotations;

    public Color[] layerColors;
    public Color[] clothingLayerColors;
    public Color[] handLayerColors;
    public Color[] equipmentLayerColors;
    
    public void ChangeTokenName(string name) {

        tokenName = name;
        ChangeTokenNameEvent?.Invoke(tokenName);

    }

    public void ChangeTokenRace(int race)
    {

        raceID = race;
        ChangeTokenRaceEvent?.Invoke(raceID);

    }

    public event ChangeTokenNameDelegate ChangeTokenNameEvent;
    public delegate void ChangeTokenNameDelegate(string n);

    public event ChangeTokenRaceDelegate ChangeTokenRaceEvent;
    public delegate void ChangeTokenRaceDelegate(int race);
    
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
        hornSprite = data.hornSprite;

        clothingSprites = data.clothingSprites;
        handSprites = data.handSprites;
        equipmentSprites = data.equipmentSprites;
        

        layerRotations = data.layerRotations;
        clothingLayerRotations = data.clothingLayerRotations;
        handLayerRotations = data.handLayerRotations;
        equipmentLayerRotations = data.equipmentLayerRotations;

        layerColors = new Color[data.layerHexColors.Length];
        clothingLayerColors = new Color[data.clothingLayerHexColors.Length];
        handLayerColors = new Color[data.paperdollHandLayerHexColors.Length];
        equipmentLayerColors = new Color[data.paperdollEquipmentLayerHexColors.Length];

        for (int i = 0; i < layerColors.Length; i++) {

            ColorUtility.TryParseHtmlString(data.layerHexColors[i], out layerColors[i]);
            
        }

        for (int i = 0; i < clothingLayerColors.Length; i++){

            ColorUtility.TryParseHtmlString(data.clothingLayerHexColors[i], out clothingLayerColors[i]);

        }

        for (int i = 0; i < handLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString(data.paperdollHandLayerHexColors[i], out handLayerColors[i]);

        }

        for (int i = 0; i < equipmentLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString(data.paperdollEquipmentLayerHexColors[i], out equipmentLayerColors[i]);

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
        hornSprite = token.hornSprite;

        clothingSprites.AddRange(token.clothingSprites);
        handSprites = token.handSprites;

        layerRotations = token.layerRotations;
        clothingLayerRotations = token.clothingLayerRotations;
        handLayerRotations = token.handLayerRotations;
        equipmentLayerRotations = token.equipmentLayerRotations;

        layerColors = token.layerColors;
        clothingLayerColors = token.clothingLayerColors;
        handLayerColors = token.handLayerColors;
        equipmentLayerColors = token.equipmentLayerColors;

    }

}
