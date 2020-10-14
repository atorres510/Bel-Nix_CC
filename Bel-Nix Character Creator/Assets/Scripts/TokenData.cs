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

    public string[] paperdollLayerHexColors;
    public string[] paperdollClothingLayerHexColors;
    public string[] paperdollHandLayerHexColors;

    public TokenData(CharacterCreator creator) {



    }


}
