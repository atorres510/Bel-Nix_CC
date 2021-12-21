using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    //takes in a token and the file's name, saving it as new tokendata. the data then gets serialized and saved with the file type ".token"
    public static void SaveToken(Token token) {

        string path = Application.streamingAssetsPath + "/Tokens/" + token.tokenName + ".token";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        TokenData data = new TokenData(token);

        formatter.Serialize(stream, data);

        stream.Close();
        
    }

    //takes in the file's name and obtains the .token which is returned as TokenData
    public static TokenData LoadToken(string fileName) {

        string path = Application.streamingAssetsPath + "/Tokens/" + fileName + ".token";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TokenData data = formatter.Deserialize(stream) as TokenData;
            stream.Close();

            return data;

        }

        else {

            Debug.LogError("Token file not found in " + path);
            return null;

        }





    }
    

}
