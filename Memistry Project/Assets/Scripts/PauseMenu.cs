using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public bool pause = false;
	public GUITexture pauseGUI;
	
	void Start(){
		pauseGUI.enabled = false;
	}
	void Update(){
		if (Input.GetKeyUp(KeyCode.Escape)){
			if(pause==true){
				pause = false;
			}
			else {
				pause = true;				
			}
			
			if (pause==true){
				Time.timeScale = 0.0f;
				pauseGUI.enabled = true;
			}
			else{
				Time.timeScale = 1.0f;
				pauseGUI.enabled = false;
			}
		}
	}
}
