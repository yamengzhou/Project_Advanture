using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float life_time = 15.0f;
	//private float exist_time;
	// Use this for initialization
	void Start () {
		//exist_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,life_time);
	}
}
