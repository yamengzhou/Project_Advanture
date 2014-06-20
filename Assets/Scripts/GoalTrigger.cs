using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour {

	private GameController gameController;
	
	void Awake(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if(gameControllerObject)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
			if(gameController == null)
				Debug.LogError("Can't find game controller object");
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
		
		print("Someone is in!!");
		if(collision.collider.tag == "Player")
			gameController.goal = true;
	
	
	}
}
