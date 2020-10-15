using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveToken(Token token) {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/firstToken.token";
        FileStream stream = new FileStream(path, FileMode.Create);

        TokenData data = new TokenData(token);

        formatter.Serialize(stream, data);

        stream.Close();
        
    }








}
