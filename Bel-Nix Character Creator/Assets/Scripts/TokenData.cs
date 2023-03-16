using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class TokenData {

    public string tokenName;
    public float versionNumber;

    public PaperdollLayerObject[] physicalTraitLayers;
    public PaperdollLayerObject[] baseLayers;
    public PaperdollLayerObject[] subLayers;

    public int size;
    public int raceID;
    public int raceType;
    public string head;
    
    public TokenData() { } //empty contructor for serialization

    public TokenData(Token token) {
        
        tokenName = token.tokenName;
        versionNumber = token.versionNumber;

        physicalTraitLayers = token.physicalTraitLayers.ToArray();
        baseLayers = token.baseLayers.ToArray();
        subLayers = token.subLayers.ToArray();
        
        size = token.size;
        raceID = token.raceID;
        raceType = token.raceType;
        head = token.head;
        
    }


}
