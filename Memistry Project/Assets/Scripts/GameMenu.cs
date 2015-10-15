using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMenu : MonoBehaviour {
	
	public bool isQuit = false;
	public bool isStart = false;
	public bool isInstructions = false;
	public GUITexture instructionsGUI;
	
	void Start(){
		instructionsGUI.enabled = false;

	}
	void OnMouseEnter(){
		//change text color
		GetComponent<Renderer>().material.color = Color.red;
	}
	
	void OnMouseExit(){
		//change text color
		GetComponent<Renderer>().material.color = Color.white;
	}
	
	void OnMouseUp(){
		if (isQuit==true){
			Application.Quit ();
		}
		
		if (isStart==true){
			startGame();
		}
		
		if (isInstructions==true){
			instructionsGUI.enabled = true;
		}
	}
	
	void Update(){
		if ( instructionsGUI.enabled == true && Input.GetKeyDown("p")){
				startGame();
			}
	}
	
	void startGame(){
		int randomLevel = Random.Range (1, 13);
		PlayerPrefs.SetFloat("TotalTime", 0);
		PlayerPrefs.SetInt("StartingLevel", randomLevel);
		Application.LoadLevel(randomLevel);	
	}
		
	
}
