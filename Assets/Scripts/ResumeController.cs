using UnityEngine;
using System.Collections;

public class ResumeController : MonoBehaviour {

	private bool mouse_in;
	public GameObject menu;
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(mouse_in && Input.GetMouseButtonDown(0)){
			menu.SetActive(false);
			Time.timeScale = 1.0f;
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
