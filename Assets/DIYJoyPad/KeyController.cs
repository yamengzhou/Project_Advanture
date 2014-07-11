using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	static public KeyController instance;
	public int actions;
	private bool mouse_in;
	
	private JoystickController joystickController;
	
	void Awake(){
	
		instance = this;
	}

	void Start(){
		joystickController = JoystickController.instance;
		//actions = 0;
	}

	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnMouseDown(){
		if(actions > 4)
			joystickController.SetActionsRight(actions);
		else
		joystickController.SetActions(actions);
		
		mouse_in = true;
		renderer.material.color = Color.red;
	}
	
	void OnMouseUp(){
		if(actions > 4)
			joystickController.SetActionsRight(0);
		else
			joystickController.SetActions(0);
	
		
		
		mouse_in = false;
		renderer.material.color = Color.white;
		
	}
}
