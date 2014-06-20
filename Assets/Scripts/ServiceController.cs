using UnityEngine;
using System.Collections;

public class ServiceController : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		senseix.initSenseix("6d483ee4ac7c4aafff9404f8cac7d567bd54d42a608b36b013d681ff2dd47dae");
		//senseix.coachSignUp("2523261011@qq.com","chris2","password.com");
		//senseix.coachUidPush();
		senseix.coachLogin ("2523261011@qq.com", "password.com");
		ArrayList users = senseix.getPlayerA();
		//senseix.getPlayer();
		int userID = ((heavyUser)users[0]).id;
		senseix.id = userID;
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
