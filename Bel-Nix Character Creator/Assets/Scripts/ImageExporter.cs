﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageExporter : MonoBehaviour
{

    public Token currentToken;
    public GameObject paperDoll;

    [Space(10)]
    public GameObject[] obstructingUIObjects;

    [Space(10)]
    public string filePath;


    //PNG Export Method

    //for stupid button use
    public void StartExportPNG()
    {

        if (currentToken.name == "")
        {
            Debug.LogError("Token needs a name before exporting.");
            return;
        }


        else
            StartCoroutine("ExportPNG");

    }

    void SetUIObjectActive(bool isActive) {

        foreach (GameObject UIObject in obstructingUIObjects)
            UIObject.SetActive(isActive);
        
    }

    //enumerated method for saving the PNG file to screenshots
    IEnumerator ExportPNG()
    {
        //from unity documentation

        string exportName = currentToken.name;

        RectTransform paperDollRectTransform = paperDoll.GetComponent<RectTransform>();

        //stores old settings and changes them for the screenshot
        Vector3 paperDollOldPos = paperDollRectTransform.position;
        Vector3 paperDollOldScale = paperDollRectTransform.localScale;

        paperDollRectTransform.position = new Vector3(40, 40, 0);
        paperDollRectTransform.localScale = new Vector3(1, 1, 1);

        //get rid of background temporarily to preserve alpha
        SetUIObjectActive(false);

        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, ARGB32 format
        // int width = Screen.width;
        // int height = Screen.height;


        Texture2D tex = new Texture2D(70, 70, TextureFormat.ARGB32, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(5, 5, 75, 75), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Object.Destroy(tex);

        exportName = ReturnNonRedudantName(exportName, Application.streamingAssetsPath + filePath);

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.streamingAssetsPath + filePath + exportName + ".png", bytes);

        paperDollRectTransform.position = paperDollOldPos;
        paperDollRectTransform.localScale = paperDollOldScale;

        SetUIObjectActive(true);

        Debug.Log("Screenshot Taken");

        yield return 0;

    }

    //addes numbers to the export name to avoid redundant filenames
    string ReturnNonRedudantName(string name, string folderPath)
    {

        string[] filePaths = Directory.GetFiles(folderPath);

        int counter = 0;

        string currentFilePath;
        string lessRedundantName = name;

        bool isThereStillARedundancy;

        do
        {

            currentFilePath = Application.streamingAssetsPath + filePath + lessRedundantName + ".png";
            isThereStillARedundancy = false;

            foreach (string path in filePaths)
            {

                if (path == currentFilePath)
                {
                    
                    counter++;
                    lessRedundantName = name + counter;
                    isThereStillARedundancy = true;
                    //Debug.Log(counter);


                }

            }



        } while (isThereStillARedundancy);

        return lessRedundantName;

    }

}