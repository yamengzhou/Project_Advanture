using UnityEngine;
using System.Collections;

public class RunnerController : MonoBehaviour {
	
	private bool landing;
	private float jump_time;
	private float air_time;
	private bool gettingHit;
	private float move_back;
	private bool moving_back;
	private Vector3 last_pos;
	private bool touch_ground;
	
	private RunningGameController runningGameController;
	
	void Awake(){
	
		GameObject runningGameControllerObject = GameObject.FindWithTag("GameController");
		
		if(runningGameControllerObject == null)
			Debug.LogError("No running game controller object is found");
		else{
			
			runningGameController = runningGameControllerObject.GetComponent<RunningGameController>();
			
			if(runningGameController == null)
				Debug.LogError("No running game controller is found");
		}
		
		gettingHit = false;
		moving_back = false;
		touch_ground = true;
	}
	
	// Use this for initialization
	void Start () {
	
		landing  = true;
		jump_time = 2.0f;
		air_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Control(){
	
	
	
	}
	
	void FixedUpdate(){
		
		if(moving_back && touch_ground&& transform.position.x >= last_pos.x){
		
			transform.position = transform.position - new Vector3(move_back*Time.deltaTime,0.0f,0.0f);
			
		}
	
		if(Input.GetKey(KeyCode.Space)&&touch_ground){
				rigidbody.AddForce(new Vector3(3.0f,2.0f,0.0f),ForceMode.Impulse);
				AfterJumping();
				air_time = Time.time;
		}
	
		if(gettingHit){
			
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x - 0.5f,0.5f),transform.position.y, transform.position.z);
			gettingHit = false;
		}
			
	}
	
	void OnCollisionEnter(Collision collision){
		
		if(collision.collider.tag == "Chasing")
			runningGameController.GameOver();
		if(collision.collider.tag == "Question"){
			Destroy(collision.gameObject);
			print ("Hit by a question!!!");
			gettingHit = true;
		}
		
		if(collision.collider.tag == "Ground"){
			touch_ground = true;
		}
	}
	
	void OnCollisionExit(Collision collision){
		if(collision.collider.tag == "Ground"){
			touch_ground = false;
		}
	}
	
	public void AfterJumping(){
		
		move_back = 1.0f;
		moving_back = true;
		last_pos = transform.position + new Vector3(0.3f,0.0f,0.0f);
		Debug.Log(last_pos);
	}
	
}
