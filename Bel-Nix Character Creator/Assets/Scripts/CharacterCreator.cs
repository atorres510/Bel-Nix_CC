using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;



public class CharacterCreator : MonoBehaviour {

    public SpriteLibrary spriteLibrary;
    public Renderer activeRenderer;
    public GameObject gridObject;
    public GameObject presetsObject;
    public Sprite blankUISprite;

    public Sprite blankSprite;

    public ColorPicker picker;

    //Button grid variables
    Button[] buttonGrid;
    int currentbuttonGridLength = 0;
    
    public GameObject canvasBackgroundObject;

    public string exportName = "CharacterExport";

    public GameObject paperDoll;
    Image[] paperDollLayers;
    Image[] paperDollClothingLayers;
    Image[] paperDollAccessoryLayers;

    public int activeLayer;
    //0: Body, 1: Clothing, 2: Hand
    //3: Back, 4: Shoulder, 5: Hair
    //6: Helmet/Head

    int activeSublayer;
    
    
    // informs the current race of the token.  this value is changed by the buttons in the RaceButtonList UI
    //determines presets, size, and raceType.  
    public int race = 2; //default race is human.
    // 1: Dwarf, 2: Human, 3: Half-elf
    // 4: Elf, 5: Dragonborn, 6: Half-Orc
    // 7: Halfling, 8: Gnome, 9: tiefling
    //add more races here!!
    

    bool isBoy = true;
    int sex = 1; //0 female, 1 male
    int chestType = 0; //0 none, 1 Acup, 2 Bcup
    int size = 0; //0 medium, 1 small
    int raceType = 0;   //0 Base, 1 Dragonborn
    int bodyType = 1; // 0 Bony, 1 Fit
    int accessoryType = 0; // 0 backitem, 1, handitem, 2, helmetitem, 3 shoulderitems, 4 capeitems

    //the rest of these types simply correspond to the sprite in order of where they are in the grid (or list)
    int hairSprite = 1;
    int capeSprite = 0;
    int backSprite = 0;
    int shoulderSprite = 0;
    int handSprite = 0;
    int headSprite = 0;
    int helmetSprite = 0;
    int ScarfSprite = 0;

    //arrays of strings that are used to construct the keys needed to GetSprites or FillButtons.  Used by ConstructKey
    //these will need to be in alphabetical order because that is how the folders are ordered.
    string[] sexStrings = { "F", "M" };
    string[] sizeStrings = { "Med", "Sm" };
    string[] bodyStrings = { "Bony", "Fit", "Stout", "Thick", "Buff"};
    string[] raceStrings = { "Base", "Dragonborn" };
    string[] accessoryStrings = { "BackItems", "HandItems", "HelmetItems", "ShoulderItems", "CapeItems", "ScarfItems" };

    //Stores Keys
    string bodyTypeKey;
    string clothingTypeKey;
    string accessoryTypeKey;
    string hairTypeKey;
    
   

    #region Sprite Key Methods
    
    //takes all of the featureString variables and uses them to construct a specific key and returns it as a string for use by GetSprite or FillButton
    string ConstructKey(string keyType) {

        string key = "";

        keyType = keyType.ToUpper();

        //Debug.Log(keyType);

        switch (keyType) {

            case "BODYTYPEKEY":

                key = sizeStrings[size] + "_bodyType";

                break;

            case "CHESTTYPEKEY":

                key = sizeStrings[size] + "_" + bodyStrings[bodyType] + "_chestType";

                break;

            case "CLOTHINGTYPEKEY":

                key = sizeStrings[size] + "_" + bodyStrings[bodyType] + /*chesttype*/ "_clothingType";

                break;

            case "ACCESSORYTYPEKEY":

                key = sizeStrings[size] + "_" + raceStrings[raceType] + "_" + accessoryStrings[accessoryType];

                break;

            case "HAIRTYPEKEY":

                key = sizeStrings[size] + "_" + raceStrings[raceType] + "_hairType";

                break;
                
            default:
                Debug.Log("Defaulting ConstructKey()");
                break;

        }

        key = key.ToUpper();

        Debug.Log(key);

        return key;

    }

    #endregion

    #region Layer Methods
    //the layer methods are for UI use to set active layers and to fill the grid buttons with the appropriate sprites for use.  

    //takes a paperdoll layer or sub layer and returns values that represent the layers that are enabled as gameobjects (this is mostly for clothing) 
    int[] ReturnFilledLayers(Image[] layers) {

        List<int> activeLayers = new List<int>(); //holds the list of active layers 

        for(int i = 0; i < layers.Length; i++) {

            if (layers[i].sprite != blankSprite) //checks if the layer is active
            {

                activeLayers.Add(i);

                Debug.Log(i);
            }

            else { }


        }

        int[] temp = activeLayers.ToArray();

        return temp;


    }

    int lastfilledAccessory = 0;

    Image ReturnEmptySubLayer(Image[] layers) {

        for (int i = 0; i < layers.Length; i++) {

            if (layers[i].sprite == blankSprite) {

                return layers[i];

            }
            
        }
        lastfilledAccessory++;
        return layers[lastfilledAccessory];

    }

    //For use of the UI to determine what layer of the paperdoll is currently being edited, and to fill the buttons with the appropriate sprites for player's selection
    public void SetActiveLayer(string layer)
    {

        //search for the active layer based on the string and set it to the active layer.
        for (int i = 0; i < paperDollLayers.Length; i++)
        {

            if (paperDollLayers[i].name == layer)
            {

                activeLayer = i;
                break;
            }

        }

        layer = layer.ToUpper();

        switch (layer)
        {

            case "BODY":

                FillButtons(ConstructKey("bodytypekey"));
                SetActiveButtons(bodyType);
                picker.CurrentColor = paperDollLayers[activeLayer].color;
                ChangeFixedColumnCount(3);
    

                break;
            case "CLOTHING":

                FillButtons(ConstructKey("clothingtypekey"));
                SetActiveButtons(ReturnFilledLayers(paperDollClothingLayers));
                ChangeFixedColumnCount(2);
          
                break;

            case "CHEST":

                FillButtons(ConstructKey("chesttypekey"));
                SetActiveButtons(chestType);
                ChangeFixedColumnCount(3);
                break;

            case "ACCESSORIES":

                break;

            case "HAND":
                accessoryType = 1;
                FillButtons(ConstructKey("AccessoryTypeKey"));
                SetActiveButtons(handSprite);//using int means that only one accessory can be applied at a time.
                break;

            case "BACK":
                accessoryType = 0;
                FillButtons(ConstructKey("AccessoryTypeKey"));
                SetActiveButtons(backSprite);
                break;

            case "CAPE":
                accessoryType = 4;
                FillButtons(ConstructKey("AccessoryTypeKey"));
                SetActiveButtons(backSprite);
                break;

            case "SHOULDER":
                break;

            case "HEAD":
                break;

            case "HAIR":
                FillButtons(ConstructKey("HairTypeKey"));
                SetActiveButtons(hairSprite);
                ChangeFixedColumnCount(3);
                break;

            case "HELMET":
                break;

            default:
                break;
                
        }
        
    }

    #endregion
    
    /*
    public void SetActiveLayer(int layer) {

        activeLayer = layer;

        switch (layer) {
            case 0: //body
               
                FillButtons(ConstructKey("bodytypekey"));
                SetActiveButtons(bodyType);
                picker.CurrentColor = paperDollLayers[activeLayer].color;
                break;


            case 1: //hair
           
                break;
            case 2: //clothes
                activeLayer = 9; //no feature selected;
               
                break;
            
            case 4: //back
                activeLayer = 4;
                FillButtons("BACKITEMS");
                SetActiveButtons(handSprite);
                ResetButtonColors();
                break;
            case 5: //hand
                activeLayer = 5;
                FillButtons("HANDITEMS");
                SetActiveButtons(backSprite);
                ResetButtonColors();
                break;
            case 6: //shoulder
                activeLayer = 6;
                FillButtons("SHOULDERITEMS");
                SetActiveButtons(shoulderSprite);
                ResetButtonColors();
                break;
            case 7: //head
                activeLayer = 8;
                FillButtons("HEADITEMS");
                SetActiveButtons(headSprite);
                picker.CurrentColor = paperDollLayers[activeLayer].color;
                break;
            case 8: //sex or empty
                activeLayer = 10;
                DeactivateAllButtons();
                ResetButtonColors();
                break;
           


        }

    }*/

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

    //Finds gameobjects based on tag and returns the image array.  for use in setting up Paperdoll layers and sublayers
    Image[] ReturnImages(string layerTag)
    {

        List<Image> tempList = new List<Image>();

        GameObject[] layerObjects = GameObject.FindGameObjectsWithTag(layerTag);

        for (int i = 0; i < layerObjects.Length; i++)
        {

            Image imgComponent = layerObjects[i].GetComponent<Image>();

            tempList.Add(imgComponent);

           // Debug.Log(imgComponent.gameObject.name);

        }

        Image[] layers = tempList.ToArray();

        return layers;

    }

    //overloaded for use of an image and its gameobject.  Used by paperdollLayers[i] that are parents of sublayers (such as clothing)
    Image[] ReturnImages(string layerTag, Image parentImage)
   {

        List<Image> tempList = new List<Image>();
        //gets the root object and the children
        RectTransform[] layerObjects = parentImage.gameObject.GetComponentsInChildren<RectTransform>(true);

        for (int i = 0; i < layerObjects.Length; i++)
        {

            if (layerObjects[i].tag == layerTag) //sort the children by the given tag and put them into a new list. this should not allow the root object into the new list.
            {

                Image imgComponent = layerObjects[i].GetComponent<Image>();

                tempList.Add(imgComponent);

                //Debug.Log(imgComponent.gameObject.name);

            }

            else { }

        }

        Image[] layers = tempList.ToArray();

        return layers;
    }
    
    //used by the UI buttons on the button grid.  places the sprite represented on the grid onto the paperdoll at the active layer 
    public void SetSpriteToPaperdoll(Button button) {

        //get the button sprite
        Sprite buttonSprite = button.transform.GetChild(0).GetComponent<Image>().sprite; // gets the sprite from the child object's image that actually holds the sprite we want.

        //holds index for the button on the grid
        int buttonIndex = 0;
        for (int i = 0; i < currentbuttonGridLength; i++) {

            if (buttonGrid[i] == button) {

                buttonIndex = i;

            }
            
        }
        
        //holds the image and name of the active layer
        //Sprite paperdollLayerSprite = paperDollLayers[activeLayer].sprite;
        string layerName = paperDollLayers[activeLayer].name.ToUpper(); //used in switch case so that we don't have to hard code in the numbers like we used to.  don't do that again.
        
        switch (layerName) {

            case "BODY": //body

                paperDollLayers[activeLayer].sprite = buttonSprite;

                TogglePressedStateAsGroup(button);
                bodyType = buttonIndex;
                Debug.Log("BodyType = " + bodyType);

                break;
                
            case "CHEST":
                paperDollLayers[activeLayer].sprite = buttonSprite;

                TogglePressedStateAsGroup(button);
                chestType = buttonIndex;
                Debug.Log("ChestType = " + chestType);

                break;

            case "HAIR":
                paperDollLayers[activeLayer].sprite = buttonSprite;

                TogglePressedStateAsGroup(button);
                hairSprite = buttonIndex;
                Debug.Log("HairSprite = " + hairSprite);
                break;

            case "CLOTHING":
                paperDollClothingLayers[buttonIndex].sprite = ReturnButtonSpriteAsToggle(button);
                //paperDollClothingLayers[buttonIndex].gameObject.SetActive(!paperDollClothingLayers[buttonIndex].gameObject.activeSelf);
                //TogglePressedState(button);
                break;

            case "ACCESSORIES":

                ReturnEmptySubLayer(paperDollAccessoryLayers).sprite = ReturnButtonSpriteAsToggle(button);

                string currentAccessory = accessoryStrings[accessoryType];

                currentAccessory.ToUpper();

                switch (currentAccessory) {

                    case "BACKITEMS":
                        //backSprite = buttonIndex;
                        break;

                    case "HANDITEMS":
                        handSprite = buttonIndex;
                        break;

                    case "HELMETITEMS":
                        helmetSprite = buttonIndex;
                        break;

                    case "SHOULDERITEMS":
                        //shoulderSprite = buttonIndex;
                        break;

                    case "SCARFITEMS":
                        break;
                        
                }
                break;

            default:
                break;
                


        }





    }

    /*public void SetSpriteToPaperdoll(Button button)
    {
        //checks if the active feature is a clothing item, and then allows for stacking of clothes and makes sure the button stays pressed 
        //signaling that the item of clothing is applied
        if (activeLayer == 9 || activeLayer == 1 || activeLayer == 2 || activeLayer == 3)
        {

            for (int i = 0; i < buttonGrid.Length; i++)
            {

                if (buttonGrid[i] == button)
                {

                    if (activeLayer == (i + 1))
                    {

                        paperDollLayers[activeLayer].gameObject.SetActive(!paperDollLayers[activeLayer].gameObject.activeSelf);

                        if (paperDollLayers[activeLayer].gameObject.activeSelf)
                        {

                            button.image.color = button.colors.pressedColor;

                        }

                        else {

                            button.image.color = button.colors.normalColor;
                        }

                    }

                    else {

                        
                        activeLayer = (i + 1);
                        if (paperDollLayers[activeLayer].gameObject.activeSelf)
                        {




                        }

                        else {

                            paperDollLayers[activeLayer].gameObject.SetActive(!paperDollLayers[activeLayer].gameObject.activeSelf);
                            if (paperDollLayers[activeLayer].gameObject.activeSelf)
                            {

                                button.image.color = button.colors.pressedColor;

                            }

                            else {

                                button.image.color = button.colors.normalColor;
                            }

                        }
                        

                    }
                    
                    Debug.Log(activeLayer);
                    break;
                }

            }

           
            picker.CurrentColor = paperDollLayers[activeLayer].color;

        }

        //if the active feature is not an item of clothing , apply 
        else {

            Sprite newSprite;
            Image buttonImage = button.transform.GetChild(0).GetComponent<Image>();

            newSprite = buttonImage.sprite;

            if (!paperDollLayers[activeLayer].gameObject.activeSelf) {

                paperDollLayers[activeLayer].gameObject.SetActive(true);

            }

            paperDollLayers[activeLayer].sprite = newSprite;

            switch (activeLayer)
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
                    if (paperDollLayers[activeLayer].gameObject.activeSelf) {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                handSprite = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 5: //back
                    if (paperDollLayers[activeLayer].gameObject.activeSelf)
                    {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                backSprite = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 6: //shoulder
                    if (paperDollLayers[activeLayer].gameObject.activeSelf)
                    {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                shoulderSprite = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 7://hair
                    if (paperDollLayers[activeLayer].gameObject.activeSelf)
                    {

                        for (int i = 0; i < buttonGrid.Length; i++)
                        {

                            if (buttonGrid[i] == button)
                            {
                                hairSprite = i;
                                button.image.color = button.colors.pressedColor;
                            }

                            else {

                                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                            }

                        }

                    }
                    break;
                case 8://head
                    for (int i = 0; i < buttonGrid.Length; i++)
                    {

                        if (buttonGrid[i] == button)
                        {
                            headSprite = i;
                            button.image.color = button.colors.pressedColor;
                        }

                        else {

                            buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

                        }



                    }

                    break;
                 

            }

        }
 
    }*/

    public void UpdateActiveLayerColor() {


        if (activeLayer < 4 || activeLayer == 7 || activeLayer == 8) {

            paperDollLayers[activeLayer].color = activeRenderer.material.color;

        }
        

    }

    void UpdatePaperDoll() {

        //update body
        paperDollLayers[0].sprite = spriteLibrary.GetSprite(ConstructKey("bodytypekey"), bodyType);

        //update clothes
        paperDollLayers[1].sprite = spriteLibrary.GetSprite(ConstructKey("clothingtypekey"), 1);
        paperDollLayers[2].sprite = spriteLibrary.GetSprite(ConstructKey("clothingtypekey"), 2);
        paperDollLayers[3].sprite = spriteLibrary.GetSprite(ConstructKey("clothingtypekey"), 3);



    }

    public void ResizePaperdoll(int resize)
    {
        paperDoll.transform.localScale = new Vector3(resize, resize, resize);
    }

    #endregion
    
    #region Button Grid Methods

    //defines the buttonGrid
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

    void ChangeFixedColumnCount(int size) {

        gridObject.GetComponent<GridLayoutGroup>().constraintCount = size;
        
    }

    void UpdateButtonSpriteColor() {

        if (activeLayer == 0 || activeLayer == 7)
        { //body and hair colors

            for (int i = 0; i < currentbuttonGridLength; i++)
            {

                //set sprite
                Image buttonImage = buttonGrid[i].transform.GetChild(0).GetComponent<Image>();

                buttonImage.color = activeRenderer.material.color;

            }

        }

        else if (activeLayer == 1 || activeLayer == 2 || activeLayer == 3)
        {

            Image buttonImage = buttonGrid[(activeLayer - 1)].transform.GetChild(0).GetComponent<Image>();

            buttonImage.color = activeRenderer.material.color;

        }

        else if (activeLayer == 9)
        {

            for (int i = 0; i < 3; i++)
            {

                Image buttonImage = buttonGrid[i].transform.GetChild(0).GetComponent<Image>();

                buttonImage.color = paperDollLayers[(i + 1)].color;


            }

        }

        else { }


    }

    //places a button in a pressed state if the type of that item is currently active on the paperdoll.  then places the rest of the buttons into the unpressed state
    void SetActiveButtons(int type) {

        if (paperDollLayers[activeLayer].gameObject.activeSelf)
        {
            
            for (int i = 0; i < currentbuttonGridLength; i++)
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


            for (int i = 0; i < currentbuttonGridLength; i++)
            {

               buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

            }

        }



    }
    //overload method that takes an array rather than a single interger.
    void SetActiveButtons(int[] types)
    {
        //sets all buttons into an unpressed state
        for (int i = 0; i < currentbuttonGridLength; i++)
        {

            buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;

        }
        //then presses the ones that are currently active on the paperdoll
        for (int i = 0; i < types.Length; i++) {

            buttonGrid[types[i]].image.color = buttonGrid[types[i]].colors.pressedColor;
            
        }

    }

    Sprite ReturnButtonSpriteAsToggle(Button button)
    {

        Sprite buttonSprite = button.transform.GetChild(0).GetComponent<Image>().sprite; // gets the sprite from the child object's image that actually holds the sprite we want.

        //checks to see if the button is not yet pressed.  if the button is normal color (not pressed) apply the button's sprite and change it to pressed color;
        if (button.image.color == button.colors.normalColor)
        {

            button.image.color = button.colors.pressedColor;
            return buttonSprite;

        }
        //if button was already pressed and active, toggle it back to the normal color and return a blank sprite.
        else
        {

            button.image.color = button.colors.normalColor;
            return blankSprite;

        }

    }

    void TogglePressedState(Button button)
    {

        //checks to see if the button is not yet pressed.  if the button is normal color (not pressed) apply the button's sprite and change it to pressed color;
        if (button.image.color == button.colors.normalColor)
        {

            button.image.color = button.colors.pressedColor;


        }
        //if button was already pressed and active, toggle it back to the normal color and return a blank sprite.
        else
        {

            button.image.color = button.colors.normalColor;
            
        }
    }

    void TogglePressedStateAsGroup(Button button)
    {
        
        for (int i = 0; i < buttonGrid.Length; i++){

            if (buttonGrid[i] == button) {
                
                buttonGrid[i].image.color = buttonGrid[i].colors.pressedColor;
                
            }

            else
            {

                buttonGrid[i].image.color = buttonGrid[i].colors.normalColor;
                
            }


        }

    }


    void ResetColorsOnSpriteGrid() {


        for (int i = 0; i < buttonGrid.Length; i++)
        {

            Image buttonImage = buttonGrid[i].transform.GetChild(0).GetComponent<Image>();
            buttonImage.color = Color.white;

        }

    }

    public void DeactivateAllButtons() {

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
        //Debug.Log(exportName);
        
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
        canvasBackgroundObject.SetActive(false);

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

        canvasBackgroundObject.SetActive(true);
        
        Debug.Log("Screenshot Taken");

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
                    //Debug.Log(counter);
                    

                }

            }



        } while (isThereStillARedundancy);

        exportName = lessRedundantName;
      
    }
        
        #endregion
  
    // Use this for initialization
    void Start () {

        SetButtons();

        paperDollLayers = ReturnImages("PaperdollLayer");
   
        paperDollClothingLayers = ReturnImages("PaperdollSubLayer", paperDollLayers[2]);

        paperDollAccessoryLayers = ReturnImages("PaperdollSubLayer", paperDollLayers[6]);

        SetUpColorPicker();

        DeactivateAllButtons();
      
}
	
	// Update is called once per frame
	void Update () {

        paperDollLayers[1].color = paperDollLayers[0].color;


        UpdateButtonSpriteColor();
        //UpdateActiveLayerColor();
        //UpdatePaperDoll();
	
	}
}
