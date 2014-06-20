using UnityEngine;
using System.Collections;

public class NextLevelController : MonoBehaviour {

	private bool mouse_in;
	public string next_level_name;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		
		if(mouse_in && Input.GetMouseButtonDown(0)){
			Application.LoadLevel(next_level_name);		
		}
	}
	
	void OnMouseEnter(){
		
		mouse_in = true;
		
		renderer.material.color = Color.grey;
	}
	
	void OnMouseExit(){
		
		mouse_in = false;
		
		renderer.material.color = Color.white;
	}
}
