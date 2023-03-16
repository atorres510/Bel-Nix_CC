using UnityEngine;
using System.IO;
//using Newtonsoft.Json;
//using System.Xml;
//using System.Xml.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //takes in a token and the file's name, saving it as new tokendata. the data then gets formated to JSON and saved with the file type ".token"
    public static void SaveToken(Token token)
    {

        string path = Application.streamingAssetsPath + "/Tokens/" + token.tokenName + ".token";
        
        TokenData data = new TokenData(token);

        string json = JsonUtility.ToJson(data);

        using (StreamWriter writer = new StreamWriter(path)) {

            writer.Write(json);
            
        }
           
    }

    public static TokenData LoadTokenData(string fileName) {


        string path = Application.streamingAssetsPath + "/Tokens/" + fileName + ".token";

        if (File.Exists(path))
        {
           
            string json;

            using (StreamReader reader = new StreamReader(path)) {
                json = reader.ReadToEnd();
                reader.Close();
            }
            
            TokenData data = JsonUtility.FromJson<TokenData>(json);
            return data;

        }

        else
        {

            Debug.LogError("Token file not found in " + path);
            return null;

        }
        
    }
    
}
