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

    [Header("Layer Lists")]
    //public List<PaperdollLayerObject> physicalTraitLayers = new List<PaperdollLayerObject>();
    public List<PaperdollLayerObject> baseLayers = new List<PaperdollLayerObject>();
    public List<PaperdollLayerObject> subLayers = new List<PaperdollLayerObject>();
    
    //Events and delegates
    public event ChangeTokenNameDelegate ChangeTokenNameEvent;
    public delegate void ChangeTokenNameDelegate(string n);
    
    public void ChangeTokenName(string name)
    {

        tokenName = name;
        ChangeTokenNameEvent?.Invoke(tokenName);

    }
    
    #region Layer Methods
    public List<PaperdollLayerObject> ReturnAllLayers()
    {

        List<PaperdollLayerObject> allLayers = new List<PaperdollLayerObject>();

        allLayers.AddRange(baseLayers);
        allLayers.AddRange(subLayers);

        return allLayers;

    }

    public void ClearAllLayers()
    {

        baseLayers.Clear();
        subLayers.Clear();

    }
    
    #endregion
    
    public Token(TokenData data) {
        
        size = data.size;
        raceID = data.raceID;
        raceType = data.raceType;
        head = data.head;

        //physicalTraitLayers.AddRange(data.physicalTraitLayers);
        baseLayers.AddRange(data.baseLayers);
        subLayers.AddRange(data.subLayers);
        
    }

    public Token(Token token)
    {

        size = token.size;
        raceID = token.raceID;
        raceType = token.raceType;
        head = token.head;

        //physicalTraitLayers.AddRange(token.physicalTraitLayers);
        baseLayers.AddRange(token.baseLayers);
        subLayers.AddRange(token.subLayers);

    }

}
