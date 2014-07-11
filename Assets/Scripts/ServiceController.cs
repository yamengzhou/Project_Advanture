using UnityEngine;
using System.Collections;

public class ServiceController : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		//senseix.initSenseix("040069fda83c7dbc41bafaece3437b188da5003980547b33091a70f25c5fbf3c");
		senseix.initSenseix("394b98dd815c87b627e78d4f18158f522a79228a65b4595c4e3037eb628efeff");
		//senseix.coachSignUp("252326101@qq.com","yameng","abcd1234");
		senseix.coachUidPush();
		senseix.coachLogin ("252326101@qq.com", "abcd1234");
		//senseix.createPlayer("player_1");
		
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
