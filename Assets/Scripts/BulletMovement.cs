using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	private PlayerController shooterController;
	private Transform shot;
	private Camera cameraController;
	void Awake(){
		GameObject shooterControllerObject = (GameObject)GameObject.FindGameObjectWithTag("Player");
		if(!shooterControllerObject)
			Debug.LogError("Can't find any shooter object");
		shooterController = shooterControllerObject.GetComponent<PlayerController>();
		shot = shooterController.transform.GetChild(3);
		
		GameObject cameraControllerObject = GameObject.FindGameObjectWithTag("MainCamera");
		if(cameraControllerObject == null)
			Debug.LogError("No camera controller object is found");
		else{
			cameraController = cameraControllerObject.GetComponent<Camera>();
			if(cameraController == null)
				Debug.LogError("No camera controller is found");	
		}
		
	}
	
	// Use this for initialization
	void Start () {
		
		Vector3 object_on_screen = cameraController.WorldToScreenPoint(transform.position);
		
		Vector3 direction = Input.mousePosition - object_on_screen;
		
		direction = new Vector3(direction.x, direction.y,0.0f);
		direction.Normalize();
		print (direction);
		rigidbody.AddForce(direction * shooterController.fire_pow, ForceMode.Impulse);
		//rigidbody.AddExplosionForce(shooterController.fire_pow,transform.position - transform.up,10.0f,3.0f,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
