using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	public float duration = 5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag == "Dead") {
		duration -= Time.deltaTime;
		if(duration <= 0) {
			Destroy(gameObject);
			}
		}
	}
}
