using UnityEngine;
using System.Collections;

public class SurfaceController : MonoBehaviour {

	public float x_move_speed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(transform.position.x + x_move_speed*Time.deltaTime,transform.position.y, transform.position.z);
	}
}
