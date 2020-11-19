using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_LoadingPanel : MonoBehaviour
{

    public Button buttonPrefab;

    public Button loadButton;

    public DataManger dataManager;

    public TMP_InputField fileNameText;
    
    public string filePath = "";
    
    public void InstantiateButtons() {

        string path = Application.streamingAssetsPath + filePath;

        string[] fileNames = dataManager.GetFileNames(path);

        if (fileNames.Length == 0)
            return;

        for (int i = 0; i < fileNames.Length; i++) {


            //Debug.Log(fileNames[i]);
            Button newButton = Instantiate(buttonPrefab, this.transform);

            newButton.GetComponentInChildren<TextMeshProUGUI>().SetText(fileNames[i]);

            newButton.onClick.AddListener(delegate {ChangeNameText(newButton.GetComponentInChildren<TextMeshProUGUI>().text); });
            newButton.onClick.AddListener(delegate { ActivateLoadButton(); });
        }
        
    }

    void ChangeNameText(string name) {

        fileNameText.text = name;
        dataManager.FileName = name;
        
    }

    void ActivateLoadButton() {

        loadButton.interactable = true;

    }

    public void ResetPanel() {

        fileNameText.text = "";

        loadButton.interactable = false;

        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons) {

            Destroy(button.gameObject);

        }


    }
    
}
