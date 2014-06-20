using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	//private PlayerController playerController;
	public float cameraSpeed = 0.5f;
	private Camera camera;
	private PlayerController playerController;
	
	// Use this for initialization
	void Start () {
		
		GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		
		if(cameraObject != null)
			camera = cameraObject.GetComponent<Camera>();
		
		if(camera == null){
			Debug.Log("Can't find 'Camera'");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void LateUpdate(){
		
		float cam_x = camera.transform.position.x;
		float cam_y = camera.transform.position.y;
			
		if(Mathf.Sqrt(Mathf.Pow(cam_x - transform.position.x,2)) >= 0.8 || Mathf.Sqrt(Mathf.Pow(cam_y - transform.position.y,2))>=0.8){
			camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position, cameraSpeed*Time.deltaTime);
			cameraSpeed += 0.02f;
		}else{
			if(cameraSpeed > 0.5f)
				cameraSpeed -= 0.02f;
			camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position, cameraSpeed*Time.deltaTime);
		}
		camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -10);
	}
}
