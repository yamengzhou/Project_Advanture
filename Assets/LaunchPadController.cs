using UnityEngine;
using System.Collections;

public class LaunchPadController : MonoBehaviour {

	public float launch_force = 4000.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
		
		if(collision.collider.tag == "Player" || collision.collider.tag == "Ball")
			collision.collider.rigidbody.AddForce(new Vector3(0.0f,launch_force,0.0f),ForceMode.Impulse);
	
	}
}
