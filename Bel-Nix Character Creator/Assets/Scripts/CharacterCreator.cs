using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class CharacterCreator : MonoBehaviour {

    public SpriteLibrary spriteLibrary;
    public Renderer activeRenderer;
    public GameObject gridObject;
    public Sprite blankUISprite;

    //Button grid variables
    Button[] buttonGrid;
    int currentbuttonGridLength = 0;
    
    public Image canvasBackground;

    public string exportName = "CharacterExport";

    public GameObject paperDoll;
    Image[] paperDollLayers;

    public int activeFeature;
    // 1: Sex, 2: Hair, 3: Clothes
    // 4: Hand, 5: Back, 6: Shoulder
    // 7: Head, 

    // informs the current race of the token.  this value is changed by the buttons in the RaceButtonList UI
    public int activeRace = 2; //default race is human.
    // 1: Dwarf, 2: Human, 3: Clothes
    // 4: Elf, 5: Dragonborn, 6: Half-Orc
    // 7: Halfling, 8: Gnome, 9: tiefling
    //add more races here!!
    

    bool isBoy = true;
    int bodyType = 0; // 0 fit, 1 chubby, 2 fat
    int hairType = 1;
    int backType = 0;
    int shoulderType = 0;
    int handType = 0;
    int headType = 0;

    public ColorPicker picker;



    public void SetSex() {

        isBoy = !isBoy;

    }

    public void SetActiveRace(int i) {

        activeRace = i; 

    }

    public void SetActiveFeature(int caseSwitch) {

        switch (caseSwitch) {
            case 1: //BodyTypes
                activeFeature = 0;

                if (isBoy)
                {
                    FillButtons("MALE");
                }
                else
                {
                    FillButtons("FEMALE");
                }
                

                for (int i = 0; i < buttonGrid.Length; i++)
                {

                    if (i == bodyType)
                    {
                        
                        buttonGrid[i].image.color = buttonGrid[i].colors.pressedColor;
                    }

                    else {

                        buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                    }



                }
                picker.CurrentColor = paperDollLayers[activeFeature].color;
                break;


            case 2: //hair
                activeFeature = 7;
                FillButtons("HAIRTYPES");
                SetActiveButtons(hairType);
                picker.CurrentColor = paperDollLayers[activeFeature].color;
                break;
            case 3: //clothes
                activeFeature = 9; //no feature selected;
                if (isBoy)
                {

                    switch (bodyType)
                    {
                        case 0: //fit
                            FillButtons("01_M_FitClothes".ToUpper());
                            break;
                        case 1: //chubs
                            FillButtons("02_M_ChubbyClothes".ToUpper());
                            break;
                        case 2: //fat
                            FillButtons("03_M_FatClothes".ToUpper());
                            break;

                    }

                }

                else
                {

                    switch (bodyType)
                    {

                        case 0: //fit
                            FillButtons("01_F_FitClothes".ToUpper());
                            break;
                        case 1: //chubs
                            FillButtons("02_F_ChubbyClothes".ToUpper());
                            break;
                        case 2: //fat
                            FillButtons("03_F_FatClothes".ToUpper());
                            break;

                    }

                }

                for (int i = 1; i < 4; i++) {

                    if (paperDollLayers[i].gameObject.activeSelf)
                    {

                        buttonGrid[i - 1].image.color = buttonGrid[i - 1].colors.pressedColor;

                    }

                    else {

                        buttonGrid[i - 1].image.color = buttonGrid[i - 1].colors.normalColor;
                    }

                }
               
                break;
            
            case 4: //hand
                activeFeature = 4;
                FillButtons("BACKITEMS");
                SetActiveButtons(handType);
                ResetButtonColors();
                break;
            case 5: //back
                activeFeature = 5;
                FillButtons("HANDITEMS");
                SetActiveButtons(backType);
                ResetButtonColors();
                break;
            case 6: //shoulder
                activeFeature = 6;
                FillButtons("SHOULDERITEMS");
                SetActiveButtons(shoulderType);
                ResetButtonColors();
                break;
            case 7: //head
                activeFeature = 8;
                FillButtons("HEADITEMS");
                SetActiveButtons(headType);
                picker.CurrentColor = paperDollLayers[activeFeature].color;
                break;
            case 8: //sex or empty
                activeFeature = 10;
                DeactivateAllButtons();
                ResetButtonColors();
                break;
           


        }

    }

    #region ColorPicker Methods

    void SetUpColorPicker() {

        picker.CurrentColor = Color.white;

        picker.onValueChanged.AddListener(color =>
        {
            activeRenderer.material.color = color;
        });

    }

    public void SetActiveColor(Button button)
    {

        Image buttonImage = button.GetComponent<Image>();

        picker.CurrentColor = buttonImage.color;

    }

    public void ResetActiveColor()
    {
        picker.SendChangedEvent();
    }

    #endregion

    #region Paperdoll Methods

    void SetPaperDollLayers() {

        paperDollLayers = paperDoll.transform.GetComponentsInChildren<Image>();

        for (int i = 0; i < paperDollLayers.Length; i++) {

            Debug.Log(paperDollLayers[i].gameObject.name);

        }

        paperDollLayers[1].gameObject.SetActive(false);
        paperDollLayers[3].gameObject.SetActive(false);
        /*paperDollLayers[4].gameObject.SetActive(false);
        paperDollLayers[5].gameObject.SetActive(false);
        paperDollLayers[6].gameObject.SetActive(false);
        paperDollLayers[8].gameObject.SetActive(false);*/

    }

    //used by the UI buttons on the button grid.  passes themselves in 
    public void SetFeaturetoPaperDoll(Button button)
    {

        if (activeFeature == 9 || activeFeature == 1 || activeFeature == 2 || activeFeature == 3)
        {

            for (int i = 0; i < buttonGrid.Length; i++)
            {

                if (buttonGrid[i] == button)
                {

                    if (activeFeature == (i + 1))
                    {

                        paperDollLayers[activeFeature].gameObject.SetActive(!paperDollLayers[activeFeature].gameObject.activeSelf);

                        if (paperDollLayers[activeFeature].gameObject.activeSelf)
                        {

                            button.image.color = button.colors.pressedColor;

                        }

                        else {

                            button.image.color = button.colors.normalColor;
                        }

                    }

                    else {

                        
                        activeFeature = (i + 1);
                        if (paperDollLayers[activeFeature].gameObject.activeSelf)
                        {




                        }

                        else {

                            paperDollLayers[activeFeature].gameObject.SetActive(!paperDollLayers[activeFeature].gameObject.activeSelf);
                            if (paperDollLayers[activeFeature].gameObject.activeSelf)
                            {

                                button.image.color = button.colors.pressedColor;

                            }

                            else {

                                button.image.color = button.colors.normalColor;
                            }

                        }
                        

                    }
                    
                    Debug.Log(activeFeature);
                    break;
                }

            }

           
            picker.CurrentColor = paperDollLayers[activeFeature].color;

        }


        else {

            Sprite newSprite;
            Image buttonImage = button.transform.GetChild(0).GetComponent<Image>();

            newSprite = buttonImage.sprite;

            if (!paperDollLayers[activeFeature].gameObject.activeSelf) {

                paperDollLayers[activeFeature].gameObject.SetActive(true);

            }

            paperDollLayers[activeFeature].sprite = newSprite;

            switch (activeFeature)
            {

                case 0: //body

                    for (int i = 0; i < buttonGrid.Length; i++)
                    {

                        if (buttonGrid[i] == button)
                        {
                            bodyType = i;
                            button.image.color = button.colors.pressedColor;
                        }

                        else {

                            buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                        }

                        

                    }

                    break;

                //clothes 
                case 1: //longshirt
                case 2: //shortshirt
                case 3: //vest
                    
                    break;


                case 4:
                    //hand
                    if (paperDollLayers[activeFeature].gameObject.activeSelf) {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                handType = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 5: //back
                    if (paperDollLayers[activeFeature].gameObject.activeSelf)
                    {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                backType = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 6: //shoulder
                    if (paperDollLayers[activeFeature].gameObject.activeSelf)
                    {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                shoulderType = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 7:
                    if (paperDollLayers[activeFeature].gameObject.activeSelf)
                    {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                hairType = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 8:
                    for (int i = 0; i < buttonGrid.Length; i++)
                    {

                        if (buttonGrid[i] == button)
                        {
                            headType = i;
                            button.image.color = button.colors.pressedColor;
                        }

                        else {

                            buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                        }



                    }

                    break;
                 

            }

        }
 
    }

    public void UpdateActiveFeatureColor() {


        if (activeFeature < 4 || activeFeature == 7 || activeFeature == 8) {

            paperDollLayers[activeFeature].color = activeRenderer.material.color;

        }
        

    }

    void UpdatePaperDoll() {

        #region Update Based on Sex
 
        if (isBoy)
        {


            paperDollLayers[0].sprite = spriteLibrary.GetSprite("MALE", bodyType);

            switch (bodyType) {

                case 0: //fit
                    paperDollLayers[1].sprite = spriteLibrary.GetSprite("01_M_FitClothes".ToUpper(), 0);  //long
                    paperDollLayers[2].sprite = spriteLibrary.GetSprite("01_M_FitClothes".ToUpper(), 1);  //short
                    paperDollLayers[3].sprite = spriteLibrary.GetSprite("01_M_FitClothes".ToUpper(), 2);  //vest
                    break;
                case 1: //chubs
                    paperDollLayers[1].sprite = spriteLibrary.GetSprite("02_M_ChubbyClothes".ToUpper(), 0);
                    paperDollLayers[2].sprite = spriteLibrary.GetSprite("02_M_ChubbyClothes".ToUpper(), 1);
                    paperDollLayers[3].sprite = spriteLibrary.GetSprite("02_M_ChubbyClothes".ToUpper(), 2);
                    break;
                case 2: //fat
                    paperDollLayers[1].sprite = spriteLibrary.GetSprite("03_M_FatClothes".ToUpper(), 0);
                    paperDollLayers[2].sprite = spriteLibrary.GetSprite("03_M_FatClothes".ToUpper(), 1);
                    paperDollLayers[3].sprite = spriteLibrary.GetSprite("03_M_FatClothes".ToUpper(), 2);
                    break;

            }
            
        }

        else {

            paperDollLayers[0].sprite = spriteLibrary.GetSprite("FEMALE", bodyType);


            switch (bodyType)
            {

                case 0: //fit
                    paperDollLayers[1].sprite = spriteLibrary.GetSprite("01_F_FitClothes".ToUpper(), 0);  //long
                    paperDollLayers[2].sprite = spriteLibrary.GetSprite("01_F_FitClothes".ToUpper(), 1);  //short
                    paperDollLayers[3].sprite = spriteLibrary.GetSprite("01_F_FitClothes".ToUpper(), 2);  //vest
                    break;
                case 1: //chubs
                    paperDollLayers[1].sprite = spriteLibrary.GetSprite("02_F_ChubbyClothes".ToUpper(), 0);  //long
                    paperDollLayers[2].sprite = spriteLibrary.GetSprite("02_F_ChubbyClothes".ToUpper(), 1);  //short
                    paperDollLayers[3].sprite = spriteLibrary.GetSprite("02_F_ChubbyClothes".ToUpper(), 2);  //vest
                    break;
                case 2: //fat
                    paperDollLayers[1].sprite = spriteLibrary.GetSprite("03_F_FatClothes".ToUpper(), 0);  //long
                    paperDollLayers[2].sprite = spriteLibrary.GetSprite("03_F_FatClothes".ToUpper(), 1);  //short
                    paperDollLayers[3].sprite = spriteLibrary.GetSprite("03_F_FatClothes".ToUpper(), 2);  //vest
                    break;

            }

        }

        #endregion

        #region Update Based on Race   
        switch (activeRace) {

            case 1: //dwarf

                break;

            case 2: //human
                break;

            case 3: //half-elf
                break;

            case 4: //elf
                break;

            case 5: //dragonborn
                break;

            case 6: //half-orc
                break;

            case 7: //halfling
                break;

            case 8: //gnome
                break;

            case 9: //tiefling
                break;


        }

        #endregion

    }

    public void ResizePaperdoll(int resize)
    {
        paperDoll.transform.localScale = new Vector3(resize, resize, resize);
    }

    #endregion
    
    #region Button Grid Methods

    void SetButtons()
    {

        buttonGrid = gridObject.transform.GetComponentsInChildren<Button>();

    }

    //activates the appropriate number of buttons needed, applying the appropriate sprite dictated by the sprite library
    void FillButtons(string filePath) {
        
        Sprite[] sprites = spriteLibrary.GetSprites(filePath);

        if (currentbuttonGridLength < sprites.Length) {

            for (int i = currentbuttonGridLength; i < sprites.Length; i++) {

                buttonGrid[i].gameObject.SetActive(true);

            }

        }

        for (int i = 0; i < sprites.Length; i++)
        {

            //set sprite
            Image buttonImage = buttonGrid[i].transform.GetChild(0).GetComponent<Image>();
            
            buttonImage.sprite = sprites[i];

        }

        for (int i = sprites.Length; i < buttonGrid.Length; i++)
        {

            buttonGrid[i].gameObject.SetActive(false);

        }

        currentbuttonGridLength = sprites.Length;

        
    }

    void UpdateButtonColor() {

        if (activeFeature == 0 || activeFeature == 7)
        { //body and hair colors

            for (int i = 0; i < currentbuttonGridLength; i++)
            {

                //set sprite
                Image buttonImage = buttonGrid[i].transform.GetChild(0).GetComponent<Image>();

                buttonImage.color = activeRenderer.material.color;

            }

        }

        else if (activeFeature == 1 || activeFeature == 2 || activeFeature == 3)
        {

            Image buttonImage = buttonGrid[(activeFeature - 1)].transform.GetChild(0).GetComponent<Image>();

            buttonImage.color = activeRenderer.material.color;

        }

        else if (activeFeature == 9)
        {

            for (int i = 0; i < 3; i++)
            {

                Image buttonImage = buttonGrid[i].transform.GetChild(0).GetComponent<Image>();

                buttonImage.color = paperDollLayers[(i + 1)].color;


            }

        }

        else { }


    }

    void SetActiveButtons(int type) {

        if (paperDollLayers[activeFeature].gameObject.activeSelf)
        {

            for (int i = 0; i < buttonGrid.Length; i++)
            {

                if (i == type)
                {

                    buttonGrid[i].image.color = buttonGrid[i].colors.pressedColor;
                }

                else {

                    buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                }

            }

        }

        else {


            for (int i = 0; i < buttonGrid.Length; i++)
            {

               buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

            }

        }



    }

    void ResetButtonColors() {


        for (int i = 0; i < buttonGrid.Length; i++)
        {

            Image buttonImage = buttonGrid[i].transform.GetChild(0).GetComponent<Image>();
            buttonImage.color = Color.white;

        }

    }

    void DeactivateAllButtons() {

        for (int i = 0; i < buttonGrid.Length; i++){

            buttonGrid[i].gameObject.SetActive(false);

        }

        currentbuttonGridLength = 0;

    }

    #endregion

    #region PNG Export Methods

    //for stupid button use
    public void StartUploadPNG() {

      StartCoroutine("UploadPNG");
      
      
    }

    public void SetExportName(string name) {

        exportName = name;
        Debug.Log(exportName);
        
    }

    IEnumerator UploadPNG()
    {
        //from unity documentation

        RectTransform paperDollRectTransform = paperDoll.GetComponent<RectTransform>();
        //stores old settings and changes them for the screenshot
        Vector3 paperDollOldPos = paperDollRectTransform.position;
        Vector3 paperDollOldScale = paperDollRectTransform.localScale;

        paperDollRectTransform.position = new Vector3(40, 40, 0);
        paperDollRectTransform.localScale = new Vector3(1, 1, 1);

        //get rid of background temporarily to preserve alpha
        canvasBackground.enabled = false;

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

        ReassignRedundantExportName(exportName, Application.dataPath + "/Screenshots/");

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/Screenshots/" + exportName + ".png", bytes);

        paperDollRectTransform.position = paperDollOldPos;
        paperDollRectTransform.localScale = paperDollOldScale;
        
        canvasBackground.enabled = true;
        
        Debug.Log("screenshot taken");

        yield return 0;

    }

   void ReassignRedundantExportName(string name, string folderPath) {

        string[] filePaths = Directory.GetFiles(folderPath);

        int counter = 0;

        string currentFilePath;
        string lessRedundantName = name;

        bool isThereStillARedundancy;

        do
        {

            currentFilePath = Application.dataPath + "/Screenshots/" + lessRedundantName + ".png";
            isThereStillARedundancy = false;

            foreach (string filePath in filePaths)
            {

                if (filePath == currentFilePath)
                {

                    counter++;
                    lessRedundantName = name + counter;
                    isThereStillARedundancy = true;
                    Debug.Log(counter);
                    

                }

            }



        } while (isThereStillARedundancy);

        exportName = lessRedundantName;
      
    }
        
        #endregion
  
    // Use this for initialization
    void Start () {

    SetButtons();

    SetPaperDollLayers();

    SetUpColorPicker();

    DeactivateAllButtons();

      
}
	
	// Update is called once per frame
	void Update () {

        UpdateButtonColor();
        UpdateActiveFeatureColor();
        UpdatePaperDoll();
	
	}
}
