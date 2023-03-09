using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManger : MonoBehaviour
{

    public float versionNumber;

    public event DisplayTextEvent OnSaveToken;
    public event DisplayTextEvent OnLoadToken;
    public delegate void DisplayTextEvent(string text);
    
    static string fileName = "";
    
    public string FileName { get { return fileName; } set { fileName = value; } }
    
    public string[] GetFileNames(string path) {

        //get all files from our path, but only the ones ending in "token"
        string[] files = Directory.GetFiles(path, "*token");

        List<string> cleanedFiles = new List<string>();

        foreach (string file in files) {

            //removes "\"
            string[] splitFile = file.Split('\\');
            //removes "."
            splitFile = splitFile[1].Split('.');
            //takes the text that comes before the ".", this should be the file's name
            string cleanString = splitFile[0];
            //trims leading and trailing whitespace
            cleanString = cleanString.Trim();

            cleanedFiles.Add(cleanString);

        }

        string[] fileNames = cleanedFiles.ToArray();

        return fileNames;
        
    }
    
    public void SaveToken(Token token) {

        string textToDisplay = "Error.";

        if (token.tokenName == "")
        {
            Debug.LogError("Token needs a name before saving.");
            textToDisplay = "Token needs a name before saving.";
        }

        else if (token.tokenName.Contains("/") || token.tokenName.Contains(@"\"))
        {
            Debug.LogError(@"Token cannot contain '/' or '\' characters.");
            textToDisplay = @"Token cannot contain '/' or '\' characters.";
        }

        else
        {
            SaveSystem.SaveToken(token);
            Debug.Log(token.tokenName + " is saved!");
            textToDisplay = token.tokenName + " is saved!";
        }

        //handle events
        OnSaveToken?.Invoke(textToDisplay);
        
    }

    public void LoadToken(Token token) {

        TokenData data = SaveSystem.LoadToken(fileName);

        token.tokenName = data.tokenName;

        token.versionNumber = data.versionNumber;
        Debug.Log("VersionNumber: " + token.versionNumber);

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
        token.hornSprite = data.hornSprite;

        token.clothingSprites.AddRange(data.clothingSprites);
        token.handSprites = data.handSprites;
        token.equipmentSprites = data.equipmentSprites;

        token.layerRotations = data.layerRotations;
        token.clothingLayerRotations = data.clothingLayerRotations;
        token.handLayerRotations = data.handLayerRotations;
        token.equipmentLayerRotations = data.equipmentLayerRotations;

        for (int i = 0; i < token.layerColors.Length; i++)
        {
           
            ColorUtility.TryParseHtmlString(("#" + data.layerHexColors[i]), out token.layerColors[i]);
            
        }

        for (int i = 0; i < token.clothingLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString("#" + data.clothingLayerHexColors[i], out token.clothingLayerColors[i]);

        }

        for (int i = 0; i < token.handLayerColors.Length; i++)
        {

            ColorUtility.TryParseHtmlString("#" + data.paperdollHandLayerHexColors[i], out token.handLayerColors[i]);

        }

        for (int i = 0; i < data.paperdollEquipmentLayerHexColors.Length; i++)
        {
            ColorUtility.TryParseHtmlString("#" + data.paperdollEquipmentLayerHexColors[i], out token.equipmentLayerColors[i]);

        }

        Debug.Log(token.tokenName + " was loaded!");
        OnLoadToken?.Invoke(token.tokenName + " was loaded!");
       
    }

}
