using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PerformsAttack : MonoBehaviour {
	
	public float range = 100.0f;
		
	public float cooldown = 0.1f;
	float cooldownRemaining = 0;
	
	public GameObject debrisPrefab;
	
	public GUIText countText;
	private int count;
	
	public GUIText timeText;
	private float timer;
	
	public static List<int> scenes = new List<int>(Enumerable.Range (1, 13));
	
	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(scenes);
		count = 0;
		timer = PlayerPrefs.GetFloat("TotalTime");
		SetCountText();
		scenes.Remove (PlayerPrefs.GetInt("StartingLevel"));
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		timer += Time.deltaTime;
		SetTimeText();
		
		if( Input.GetMouseButton(0) && cooldownRemaining <= 0) {
			cooldownRemaining = cooldown;
			Ray ray = new Ray( Camera.main.transform.position, Camera.main.transform.forward );
			RaycastHit hitInfo;
			
			if (Physics.Raycast(ray, out hitInfo, range ) ) {
				Vector3 hitPoint = hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				//Debug.Log ("Hit Object: " + go.name);
				if (go.tag == "Volumetric") {
					count += 1;
					SetCountText();
				}
				
				if (go.tag == "Flask") {
					count += 1;
					SetCountText();
				}
				
				if (go.tag == "Beaker") {
					count += 1;
					SetCountText();
				}
				
				if(debrisPrefab != null) {
				Instantiate( debrisPrefab, hitPoint, Quaternion.identity );
				}
			}
		}
		
		if ( Input.GetKeyDown("r")){
			if (scenes.Count == 0 && count == Application.loadedLevel){
				Application.LoadLevel("Game Complete");
			}
			else {
				LevelAdvance ();
			}
		}
	}
	
	void SetCountText(){
		countText.text = "Protons: " + count.ToString();
	}
	
	void SetTimeText(){
		timeText.text = "Time: " + timer.ToString();
		PlayerPrefs.SetFloat("TotalTime", timer);
	}
	
	void LevelAdvance(){
		int randomIndex = Random.Range(0, scenes.Count);
		int level = scenes[randomIndex];
		
		//Level Successful
		if (count == Application.loadedLevel){
			scenes.RemoveAt(randomIndex);
			PlayerPrefs.SetString("LevelSucceeded", "true");
			PlayerPrefs.SetInt("LevelToLoad", level);
			Application.LoadLevel("levelAdvance");
		}
		//Level Unsuccessful
		else{
			PlayerPrefs.SetString("LevelSucceeded", "false");
			PlayerPrefs.SetInt("LevelToLoad", Application.loadedLevel);
			Application.LoadLevel("levelAdvance");
		}
	}
}
