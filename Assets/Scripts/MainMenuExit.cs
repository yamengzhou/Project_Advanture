using UnityEngine;
using System.Collections;

public class MainMenuExit : MonoBehaviour {

	
	private bool mouse_in;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(mouse_in == true && Input.GetMouseButtonDown(0))
			Application.Quit();
		
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
