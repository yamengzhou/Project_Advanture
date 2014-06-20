using UnityEngine;
using System.Collections;

public class DisableCharController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
		cc.enabled = false; // Turn off the component
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
