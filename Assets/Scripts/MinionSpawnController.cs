using UnityEngine;
using System.Collections;

public class MinionSpawnController : MonoBehaviour {

	public GameObject minion_object;
	public float spawn_speed;

	private float start_time;
	// Use this for initialization
	void Start () {
	
		start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Time.time - start_time >= spawn_speed){
			Instantiate(minion_object,transform.position,transform.rotation);
			start_time = Time.time;
		}
	}
}
