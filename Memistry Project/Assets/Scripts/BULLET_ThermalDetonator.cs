using UnityEngine;
using System.Collections;

public class BULLET_ThermalDetonator : MonoBehaviour {
	
	float lifespan = 0f;
	public GameObject fireEffect;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		
		if (lifespan <= 0){
			Explode();
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Flask")  {
			collision.gameObject.tag = "Dead";
			Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if(collision.gameObject.tag == "Volumetric")  {
			collision.gameObject.tag = "Dead";
			Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if(collision.gameObject.tag == "Beaker")  {
			collision.gameObject.tag = "Dead";
			Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	void Explode() {
		
		Destroy (gameObject);
	}
}
