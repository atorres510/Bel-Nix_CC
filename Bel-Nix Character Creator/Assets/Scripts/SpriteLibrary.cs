using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SpriteLibrary : MonoBehaviour {

	public string[] folderPaths;

	//used to take place of null reference exceptions
	Sprite errorSprite;

	//Stores sprites in arrays by faction.  Uses piece Designation to ID piece sprite type.
	Dictionary<string, Sprite[]> spriteLibrary = new Dictionary<string, Sprite[]>();

	//used by manager scripts to retrieve sprites given the faction and unit type
	public Sprite GetSprite(string key, int id){
		
		Sprite[] sprites = RetrieveArray(key);
		
		//checks if the array would throw an out of index error.  if so, throw error and errorsprite
		if (sprites.Length < id) {
			
			Debug.LogError("Failed to Assign Sprite: Out of Index");
			return errorSprite;
			
		}
		
		else{
			
			//corrects for array elements
			//id = (id - 1);
			
			//checks if the array would throw an out of index error.  if so, throw error and errorsprite
			if(id < 0){
				
				Debug.LogError("Failed to Assign Sprite: Out of Index");
				return errorSprite;
				
			}
			
			else{
				
				return sprites[id];
				
			}
			
		}
		
	}

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

    public Sprite[] GetSprites(string key) {

        Sprite[] sprites = RetrieveArray(key);

        return sprites;


    }


	//creates dictionary by reading the folder paths and their contents
	void CreateSpriteDictionary(string[] folderPaths){

		foreach (string path in folderPaths) {
				
			string[] filePaths = Directory.GetFiles (path);
			
			foreach (string filePath in filePaths) {
				
				string cleanedPath = CleanFilePath(filePath);
				
				Sprite[] sprites = LoadSpriteArray(cleanedPath);
				
				//cuts the cleaned path into the key and puts it in all caps to be comparable to enums
				string key = MakeKey(cleanedPath);
				
				spriteLibrary.Add(key, sprites);
                
                
				
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
		clean = clean.Trim ();

		return clean;
	
	}

	//cleans the path to make the dictionary key
	string MakeKey (string path){

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

	
	void Awake(){

		//LoadErrorSprite ();
		CreateSpriteDictionary (folderPaths);
        
	
	}







}
