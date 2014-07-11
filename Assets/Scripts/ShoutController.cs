using UnityEngine;
using System.Collections;

public class ShoutController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		rigidbody.AddForce(transform.forward * 200,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
