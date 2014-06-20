using UnityEngine;
using System.Collections;

public class WeightTriggerController : MonoBehaviour {

	private bool triggered;
	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
	
		if(collision.collider.tag == "Ball" || collision.collider.tag == "Player"){
			triggered = true;
		}
	}
	
	void OnCollisionExit(Collision collision){
		
		if(collision.collider.tag == "Ball" || collision.collider.tag == "Player")
			triggered = false;
	}
	
	public bool GetTrigger(){
		return triggered;
	}
}
