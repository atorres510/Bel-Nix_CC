using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SpriteLibrary : MonoBehaviour {

    public string rootPath;

	public string[] folderPaths;

    [Space(20)]
    [Tooltip("When true, allows errors when sprite cannot be found.  When false, SpriteLibrary will find next best ID value.")]
    public bool debuggingOn;
    
    List<string> keys = new List<string>();

	//used to take place of null reference exceptions
	Sprite errorSprite;

	//Stores sprites in arrays by faction.  Uses piece Designation to ID piece sprite type.
	Dictionary<string, Sprite[]> spriteLibrary = new Dictionary<string, Sprite[]>();

	//used by manager scripts to retrieve sprites given the faction and unit type
	public Sprite GetSprite(string key, int id){

        string path = rootPath + "/" + key;
		
		Sprite[] sprites = Resources.LoadAll<Sprite>(path);
		
		//checks if the array would throw an out of index error.  if so, throw error and errorsprite
		if (sprites.Length < id && debuggingOn) {
			
			Debug.LogError("Failed to Assign Sprite: Out of Index");
			return errorSprite;
			
		}
		
		else{
			
			//checks if the array would throw an out of index error.  if so, throw error and errorsprite
			if(id < 0 && debuggingOn){
				
				Debug.LogError("Failed to Assign Sprite: Out of Index");
				return errorSprite;
				
			}
			
			else{
				
				return sprites[id];
				
			}
			
		}
		
	}

    //overloaded method for string usage
    public Sprite GetSprite(string key, string id)
    {
        string path = rootPath + "/" + key;

        //Debug.Log(path);


        Sprite[] sprites = Resources.LoadAll<Sprite>(path);

        foreach (Sprite s in sprites)
        {
           
            if (s.name == id)
            {

                return s;

            }

            else { }


        }

   
        Debug.LogError("Failed to Assign Sprite: No Match");

        return errorSprite;

      
     

    }

    //returns a full sprite array when given the appropriate key
    public Sprite[] GetSprites(string key)
    {
        string path = rootPath + "/" + key;

        Sprite[] sprites = Resources.LoadAll<Sprite>(path);

        return sprites;


    }

    /*
	//overloaded method for string usage
	public Sprite GetSprite(string key, string id){
		
		Sprite[] sprites = RetrieveArray(key);
		
		foreach (Sprite s in sprites) {
			
			if(s.name == id){
				
				return s;
				
			}
			
			else{}
			
			
		}
		
		Debug.LogError ("Failed to Assign Sprite: No Match");
		
		return errorSprite;
		
	}

    //returns a full sprite array when given the appropriate key
    public Sprite[] GetSprites(string key) {

        Sprite[] sprites = RetrieveArray(key);

        return sprites;


    }
    */

    //returns a string array of all keys instatiated in CreateSprite Dictionary
    public string[] GetKeys() {

        string[] temp = keys.ToArray();

        return temp;

    }

	//creates dictionary by reading the folder paths and their contents
	void CreateSpriteDictionary(string[] folderPaths){
        
		for(int i = 0; i < folderPaths.Length; i++) {

            folderPaths[i] =  rootPath + "/"  + folderPaths[i];

            //Debug.Log(folderPaths[i]);
            
			string[] filePaths = Directory.GetFiles (folderPaths[i]);
			
			foreach (string filePath in filePaths) {
				
				string cleanedPath = CleanFilePath(filePath);

                //Debug.Log(cleanedPath);

				Sprite[] sprites = LoadSpriteArray(cleanedPath);
				
				//cuts the cleaned path into the key and puts it in all caps to be comparable to enums
				string key = MakeKey(cleanedPath);

                keys.Add(key); // add to the keys list for export in GetKeys() by other scripts.
            
				spriteLibrary.Add(key, sprites);

                //Debug.Log(key);
				
			}
		
		}

	}

	//cleans filepath, removing "Assets/Resources/", "\", and ".meta" from the string. also trims whitespace
	string CleanFilePath(string path){

        //removes "Assets/Resources/"
        string clean  = path.Substring(17);
        //removes ".meta"
        clean = clean.Remove(clean.Length - 5);
        //removes "\"
		string [] cleanedStrings = clean.Split ('\\');
        //addes all the cleaned strings and connects the path
        clean = cleanedStrings[0] + "/" + cleanedStrings[1];
         //trims whitespace on ends
        clean = clean.Trim();
        
		return clean;
	
	}

	//cleans the path to make the dictionary key
	string MakeKey(string path){

		string[] s = path.Split ('/');

		string newKey = s [s.Length - 1];

		newKey = newKey.Trim();
		newKey = newKey.ToUpper();

		return newKey;
        
	}
	
	//reads path and creates a sprite array of the assets found
	Sprite[] LoadSpriteArray(string path){

        Sprite[] sprites = Resources.LoadAll<Sprite>(path);

        return sprites;

	}

	//uses the key to retrieve the correct sprite array. consider overload for other types of sprites.
	Sprite[] RetrieveArray(string key){

		Sprite[] temp;

		//accesses values in dictionary, checking to make sure the value is there before returning
		if(spriteLibrary.TryGetValue(key, out temp)){

			//Debug.Log("success");

			return temp;

		}

		else{

			Debug.LogError("Failed to Retrieve Sprite Array: Bad Key or No Value");

			Sprite[] nullArray = new Sprite[] {errorSprite};
			return nullArray;

		}

	}

	//loads Error Sprite from resources folder
	void LoadErrorSprite(){

		errorSprite = Resources.Load<Sprite>("Sprites/ErrorSprite");
	
	}

    Sprite SubstituteOutOfBoundsSprite(Sprite[] SpriteList, int id) {

        int i = id;

        while (SpriteList.Length <= i) {

            i--;

        }

        return SpriteList[i];


    }

	
	void Awake(){

		//LoadErrorSprite ();
		//CreateSpriteDictionary (folderPaths);
        
	
	}







}
