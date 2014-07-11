using UnityEngine;
using System.Collections;

public class DashPadController : MonoBehaviour {

	public float launch_force = 4000.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision){
		
		if(collision.collider.tag == "Ball")
			collision.collider.rigidbody.AddForce(transform.right*launch_force,ForceMode.Impulse);
		else if(collision.collider.tag == "Player")
			collision.collider.rigidbody.AddForce(transform.right*launch_force/50.0f,ForceMode.Impulse);
		
	}
}
