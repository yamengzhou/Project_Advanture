using UnityEngine;
using System.Collections;

public class RestartController : MonoBehaviour {

	private bool mouse_in;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		
		if(mouse_in && Input.GetMouseButtonDown(0)){
			Application.LoadLevel(Application.loadedLevelName);
			
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
