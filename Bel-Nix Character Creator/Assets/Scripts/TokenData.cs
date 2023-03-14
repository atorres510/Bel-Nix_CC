using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class TokenData {

    public string tokenName;
    public float versionNumber;
    
    public PaperdollLayerObject[] baseLayers;
    public PaperdollLayerObject[] subLayers;

    public int size;
    public int chestType;
    public int raceID;
    public int bodyType;
    public int raceType;
    public string head;
    

    public TokenData() { }

    public TokenData(Token token) {


        tokenName = token.tokenName;
        versionNumber = token.versionNumber;

        baseLayers = token.baseLayers.ToArray();
        subLayers = token.subLayers.ToArray();
        
        size = token.size;
        chestType = token.chestType;
        raceID = token.raceID;
        raceType = token.raceType;
        bodyType = token.bodyType;
        head = token.head;
        
    }


}
