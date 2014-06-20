using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {

	public float angle_speed = 10.0f;
	public Transform bullet;
	public float fire_pow = 10.0f;
	public float shot_rate = 0.5f;
	
	private Transform shot;
	private float shot_time;
	void Awake(){
	
		shot = transform.GetChild(0);
		if(!shot)
			Debug.LogError("No child object is found");
		shot_time = 0.0f;
		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate(){
		TakeInput();
		
	}
	
	void TakeInput(){
	
		if(Input.GetKey(KeyCode.UpArrow))
			shot.eulerAngles = new Vector3(0.0f,0.0f,shot.eulerAngles.z + angle_speed * Time.deltaTime);
		if(Input.GetKey(KeyCode.DownArrow))
			shot.eulerAngles = new Vector3(0.0f,0.0f,shot.eulerAngles.z - angle_speed * Time.deltaTime);
		if(Input.GetKey(KeyCode.Space)&& Time.time - shot_time > shot_rate){
			Instantiate(bullet,shot.position + shot.up,shot.rotation);
			//Vector3 shoting_angle = shot.rotation.eulerAngles;
			//shoting_angle.Normalize();
			//Debug.Log( shoting_angle);
			
			shot_time = Time.time;
		}
	}
}
