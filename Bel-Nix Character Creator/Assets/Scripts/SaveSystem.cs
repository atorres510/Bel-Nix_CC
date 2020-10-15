using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveToken(Token token, string path) {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        TokenData data = new TokenData(token);

        formatter.Serialize(stream, data);

        stream.Close();
        
    }

    public static TokenData LoadToken(string path) {
        
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
