using UnityEngine;
using System.Collections;

public class MinionController : MonoBehaviour {

	public float moving_speed = 1.0f;
	public float moving_time = 3.0f;
	public int health_point = 1;
	public int attack = 5;

	private float current_speed;
	private float start_time;
	
	Vector3 start_pos;
	
	private PlayerController playerController;
	
	private bool get_hit;
	
	void Awake(){
	
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");
		if(playerControllerObject == null)
			Debug.LogError("no player controller object is found");
		else{
			playerController = playerControllerObject.GetComponent<PlayerController>();
			if(playerController == null)
				Debug.LogError("no player controller is found");
		}
	
		start_pos = transform.position;
		get_hit = false;
		current_speed = moving_speed;
		start_time = Time.time;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!get_hit){
		
			if(Time.time - start_time <= 5.0f)
				transform.position += new Vector3(1.0f,0.0f,0.0f)*current_speed * Time.deltaTime;
			else{
				current_speed *= -1.0f;
				start_time = Time.time;
			}
		}
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.collider.tag == "Ball" || collision.collider.tag == "Bullet"){
			health_point--;
			if(health_point <= 0)
				Destroy(gameObject);
		}
		else if(collision.collider.tag == "Player")
			playerController.LoseHP(attack);
		if(collision.collider.tag != "Ground" && collision.collider.tag != "Weight_Trigger"){
			get_hit = true;
			current_speed = 0.0f;
		}
	}
}
