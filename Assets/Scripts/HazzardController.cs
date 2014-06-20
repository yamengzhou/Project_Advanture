using UnityEngine;
using System.Collections;

public class HazzardController : MonoBehaviour {

	
	
	public float ang_speed = -30.0f;
	private float angle;
	// Use this for initialization
	void Start () {
		//rigidbody.AddTorque(1.0f,0.0f,0.0f,ForceMode.Force);
		angle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(0.0f,0.0f,angle+ang_speed*Time.deltaTime);
		if(angle >= 360.0f)
			angle = 0.0f;
		
	}

}
