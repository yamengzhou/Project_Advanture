using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerExit(Collider collision){
		Destroy(collision.gameObject);
	}
	
	void OnCollisionExit(Collision collision){
		Debug.Log("Collision detected");
		Destroy(collision.gameObject);
	}
}
