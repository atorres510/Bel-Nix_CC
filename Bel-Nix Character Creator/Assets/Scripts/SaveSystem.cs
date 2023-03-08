using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //takes in a token and the file's name, saving it as new tokendata. the data then gets serialized and saved with the file type ".token"
    public static void SaveToken(Token token)
    {

        string path = Application.streamingAssetsPath + "/Tokens/" + token.tokenName + ".token";
        
        XmlSerializer serializer = new XmlSerializer(typeof(TokenData));

        TextWriter writer = new StreamWriter(path);

        //FileStream stream = new FileStream(path, FileMode.Create);

        TokenData data = new TokenData(token);

        serializer.Serialize(writer, data);

        writer.Close();

    }

    public static TokenData LoadToken(string fileName) {


        string path = Application.streamingAssetsPath + "/Tokens/" + fileName + ".token";

        if (File.Exists(path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TokenData));
            
            FileStream stream = new FileStream(path, FileMode.Open);

            TokenData data = serializer.Deserialize(stream) as TokenData;
            stream.Close();

            return data;

        }

        else
        {

            Debug.LogError("Token file not found in " + path);
            return null;

        }
        
    }
    
}
