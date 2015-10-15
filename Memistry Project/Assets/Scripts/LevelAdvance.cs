using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelAdvance : MonoBehaviour {
	
	public GUITexture LevelSuccess;
	public GUITexture LevelUnsuccessful;

	// Use this for initialization
	void Start () {
		LevelSuccess.enabled = false;
		LevelUnsuccessful.enabled = false;
		
		if (PlayerPrefs.GetString("LevelSucceeded") == "true"){
			LevelSuccess.enabled = true;
		}
		if (PlayerPrefs.GetString("LevelSucceeded") == "false"){
			LevelUnsuccessful.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Advance ();
	
	}
	
	void Advance(){
		
		//Level Successful
		if (Input.GetKeyDown("n")){
			Application.LoadLevel(PlayerPrefs.GetInt("LevelToLoad"));
		}
		//Level Unsuccessful
		//else{
		//	Application.LoadLevel(Application.loadedLevel);
		//}
	}
}
