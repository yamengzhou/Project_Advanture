using UnityEngine;
using System.Collections;

public class MainMenuLevelSelection : MonoBehaviour {

	private bool mouse_in;
	public GameObject menu;
	public GameObject sub_menu_level_selection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(mouse_in == true && Input.GetMouseButtonDown(0)){
			menu.SetActive(false);
			sub_menu_level_selection.SetActive(true);
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
