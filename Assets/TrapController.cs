using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour {

	private PlayerController playerController;

	private float HurtTime;

	void Awake(){
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");
		if(playerControllerObject)
		{
			playerController = playerControllerObject.GetComponent<PlayerController>();
			if(playerController == null)
				Debug.LogError("No player controller object is found");
		}
		HurtTime = Time.time;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.collider.tag == "Player" && Time.time - HurtTime >= 1.0f){
			playerController.LoseHP(3);
			HurtTime = Time.time;
		}
	}
}
