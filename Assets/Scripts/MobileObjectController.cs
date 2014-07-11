using UnityEngine;
using System.Collections;

public class MobileObjectController : MonoBehaviour {

	private PlayerController playerController;
	// Use this for initialization
	void Start () {
		playerController = PlayerController.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
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
}
