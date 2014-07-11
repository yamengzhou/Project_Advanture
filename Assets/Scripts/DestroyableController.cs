using UnityEngine;
using System.Collections;

public class DestroyableController : MonoBehaviour {

	//private bool isHit;
	private float move_time;
	//private float time_on_the_fly = 
	// Use this for initialization
	void Start () {
	
//		isHit = false;
		move_time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		//isHit
	}
	
	void OnCollisionEnter(Collision collision){
	
		if(collision.collider.tag == "Bullet"){
		
			//Animation... play a breakdown animation here if there is any available
			// Animator.....................
			
			gameObject.SetActive(false);
		}else if(collision.collider.tag == "Ball"){
			//isHit = true;
			
		}
	}
}
