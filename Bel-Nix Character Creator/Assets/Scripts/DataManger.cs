using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{

    string dataPath = "";

    public void WriteDataPath(string path) {

        dataPath = Application.dataPath + "/Tokens/" + path + ".token";
        Debug.Log(dataPath);

    }

    public void SaveToken(Token token) {

        SaveSystem.SaveToken(token, dataPath);
        Debug.Log(token.name + " is saved!");
    }

    public void LoadToken(Token token) {

        TokenData data = SaveSystem.LoadToken(dataPath);

        token.name = data.name;  

        token.size = data.size;
        token.chestType = data.chestType;
        token.raceID = data.raceID;
        token.bodyType = data.bodyType;
        token.raceType = data.raceType;
        token.head = data.head;

        token.hairSprite = data.hairSprite;
        token.capeSprite = data.capeSprite;
        token.backSprite = data.backSprite;
        token.shoulderSprite = data.shoulderSprite;
        token.helmetSprite = data.helmetSprite;
        token.racialSprite = data.racialSprite;

        token.clothingSprites = data.clothingSprites;
        token.handSprites = data.handSprites;

        token.paperdollLayerRotations = data.paperdollLayerRotations;
        token.paperdollClothingLayerRotations = data.paperdollClothingLayerRotations;
        token.paperdollHandLayerRotations = data.paperdollHandLayerRotations;

        for (int i = 0; i < token.paperdollLayerColors.Length; i++)
        {
           
            ColorUtility.TryParseHtmlString(("#" + data.paperdollLayerHexColors[i]), out token.paperdollLayerColors[i]);
            
        }

        for (int i = 0; i < token.paperdollClothingLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString("#" + data.paperdollClothingLayerHexColors[i], out token.paperdollClothingLayerColors[i]);

        }

        for (int i = 0; i < token.paperdollHandLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString("#" + data.paperdollHandLayerHexColors[i], out token.paperdollHandLayerColors[i]);

        }
        
        Debug.Log(token.name + " was loaded!");


    }

    private void Start()
    {
        WriteDataPath("myToken");
    }

}
