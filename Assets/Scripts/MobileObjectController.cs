using UnityEngine;
using System.Collections;

public class MobileObjectController : MonoBehaviour {

<<<<<<< HEAD
	private PlayerController playerController;
	// Use this for initialization
	void Start () {
		playerController = PlayerController.instance;
=======
	// Use this for initialization
	void Start () {
	
>>>>>>> dac4a523c9afbd0e8eafa05990a587f49290ff6a
	}
	
	// Update is called once per frame
	void Update () {
	
	}
<<<<<<< HEAD
	
	void OnMouseDown(){
		Vector3 dir = transform.position - playerController.transform.position;
	
		dir.Normalize();
		if(playerController.GetSkill() == 1){
			rigidbody.AddForce(-dir*500.0f, ForceMode.Impulse);
			playerController.LoseSP(1);
		}else if(playerController.GetSkill() == 2){
			rigidbody.AddForce(dir*500.0f, ForceMode.Impulse);
			playerController.LoseSP(1);
		}
	}
=======
>>>>>>> dac4a523c9afbd0e8eafa05990a587f49290ff6a
}
