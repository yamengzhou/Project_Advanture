using UnityEngine;
using System.Collections;

public class DestroyByTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.collider.tag == "Bullet" ||collision.collider.tag == "Ball"){
			Destroy(gameObject);
		}
	
	}
}
