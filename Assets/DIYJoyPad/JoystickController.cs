using UnityEngine;
using System.Collections;

public class JoystickController : MonoBehaviour {

	static public JoystickController instance;
	private int action;
	private int action_r;
	
	void Awake(){
		instance = this;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		print("The current action is " + action);
	}
	
	public void SetActions(int action){

		this.action = action;
		
	}
	
	public void SetActionsRight(int action_r){
		this.action_r = action_r;
	}
	
	public int GetActions(){
		return action;
	}
	
	public int GetActionsRight(){
		return action_r;
	}
}
