using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	private bool move;
	private float speed;
	// Use this for initialization
	void Start () {
		move = false;
		speed = 1.0f;
		rigidbody.AddForce(new Vector3(15.0f,0.0f,0.0f), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(move){
			transform.position = new Vector3(transform.position.x - speed*Time.deltaTime, transform.position.y, transform.position.z);
			
		}
	
	}
	
	void OnCollisionEnter(Collision collision){
	
		print ("Hit the ground!!!");
		move = true;
	}
	
	public void SpeedUp(){
		speed += 0.2f;
	}
}
