using UnityEngine;
using System.Collections;

public class WallShadingController : MonoBehaviour {
	
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");
		if(playerControllerObject == null)
			Debug.LogError("No player controller object is found");
		else{
			playerController = playerControllerObject.GetComponent<PlayerController>();
			if(playerController == null){
				Debug.LogError("No player controller is found");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 player_pos = new Vector2(playerController.transform.position.x, playerController.transform.position.y);
		Vector2 self_pos = new Vector2(transform.position.x, transform.position.y);
	
		if(Vector2.Distance(player_pos,self_pos) <= 5.0f){
			//print("Here disables renderer");
			renderer.enabled = false;
		}
		else
		{
			renderer.enabled = true;
		}
	}
}
