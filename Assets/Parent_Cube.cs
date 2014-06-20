using UnityEngine;
using System.Collections;

public class Parent_Cube : MonoBehaviour {

	private bool boom;
	private Animator _animator;
	
	private bool triggered;
	float currentTime;
	// Use this for initialization
	void Start () {
		boom = false;
		
		_animator = GetComponent<Animator>();
		
		triggered = false;


	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Time.time - currentTime >= 0.8f && triggered)
			Destroy(gameObject);
	}
	
	public bool getBoom(){
		return boom;
	}
	
	public void setBoom(bool boom){
		this.boom = boom; 
	}
	
	void OnCollisionEnter(Collision collision){

		//float v = Vector3.Distance(collision.collider.rigidbody.velocity, Vector3.zero);
			
			print ("Hit something");
			//if(collision.collider.rigidbody.mass * v >= 20.0f){
				
				print ("BreakDown!!");
				currentTime = Time.time;
				_animator.Play("Break");
				triggered = true;
			//}
	}
}
