using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	
	public GameObject congratController;
	private PlayerController playerController;
	
	void Awake(){
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");
		if(playerControllerObject)
		{
			playerController = playerControllerObject.GetComponent<PlayerController>();
			if(playerController == null)
				Debug.LogError("No player controller object is found");
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.collider.tag == "Player"){
		
			congratController.transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, congratController.transform.position.z);
			congratController.SetActive(true);
			Time.timeScale = 0.0f;
		}
	
	}
}
