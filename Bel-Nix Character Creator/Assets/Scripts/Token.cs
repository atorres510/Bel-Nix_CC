using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public string tokenName = "";

    public float versionNumber;
   
    public List<PaperdollLayerObject> baseLayers = new List<PaperdollLayerObject>();
    public List<PaperdollLayerObject> subLayers = new List<PaperdollLayerObject>();

    public List<PaperdollLayerObject> ReturnAllLayers() {

        List<PaperdollLayerObject> allLayers = new List<PaperdollLayerObject>();

        allLayers.AddRange(baseLayers);
        allLayers.AddRange(subLayers);

        return allLayers;

    }

    public void ClearAllLayers() {

        baseLayers.Clear();
        subLayers.Clear();

    }



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

        baseLayers.AddRange(data.baseLayers);
        subLayers.AddRange(data.subLayers);
        
    }

    public Token(Token token)
    {

        size = token.size;
        chestType = token.chestType;
        raceID = token.raceID;
        raceType = token.raceType;
        bodyType = token.bodyType;
        head = token.head;

        baseLayers.AddRange(token.baseLayers);
        subLayers.AddRange(token.subLayers);

    }

}
