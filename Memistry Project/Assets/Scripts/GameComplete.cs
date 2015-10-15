using UnityEngine;
using System.Collections;

public class GameComplete : MonoBehaviour {
	
	public GUIText timeText;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		displayTime();
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
	
	void displayTime(){
		timeText.text = "Total Time: " + PlayerPrefs.GetFloat("TotalTime").ToString();
	}
}
