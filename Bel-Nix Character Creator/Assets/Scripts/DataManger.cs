using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{

    public void SaveToken(Token token) {

        SaveSystem.SaveToken(token);
        Debug.Log(token.name + " is saved!");
    }


    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

}
