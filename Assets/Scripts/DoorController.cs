using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	private bool mouse_in;
	public AnimationClip door_open;
	
	private Animation door_anim;
	private bool played;

	public WeightTriggerController weightTriggerController;
	
	private AudioSource audio;
	
	void Awake(){
	
		GameObject weightTriggerControllerObject = GameObject.FindGameObjectWithTag("Weight_Trigger");
		if(weightTriggerControllerObject == null)
			Debug.LogError("No weight trigger controller object is found");
		else{
			weightTriggerController = weightTriggerControllerObject.GetComponent<WeightTriggerController>();
			if(weightTriggerController == null)
				Debug.LogError("No weight trigger controller is found");
		
		}
	
		if(!door_open)
			Debug.LogError("No door opening animation is found!!");
			
		mouse_in = false;
		door_anim = GetComponent<Animation>();
		played = false;
		//audio = GetComponent<AudioSource>();

	}

	void Start(){
		

	}

	// Update is called once per frame
	void Update () {
		
		if(!played && weightTriggerController.GetTrigger()){
			door_anim[door_open.name].speed = 1.0f;
			door_anim.CrossFade(door_open.name);
			//audio.Play();
			played = true;
		}
		

	}
}
