using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool goal;
	
	public GameObject menu;
	public GameObject gameover;
	
	private PlayerController playerController;
	private Texture2D health_bar_tex, spirit_bar_tex, empty_bar_tex;
	
	void Awake(){
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");
		if(playerControllerObject)
		{
			playerController = playerControllerObject.GetComponent<PlayerController>();
			if(playerController == null)
				Debug.LogError("No player controller object is found");
		}
		
		// Load texture from resources folder
		health_bar_tex = Resources.Load("health_bar") as Texture2D;
		spirit_bar_tex = Resources.Load("spirit_bar") as Texture2D;
		empty_bar_tex = Resources.Load("empty_bar") as Texture2D;
// Commented content below is the service part
/*	
		senseix.initSenseix("6d483ee4ac7c4aafff9404f8cac7d567bd54d42a608b36b013d681ff2dd47dae");
		//senseix.coachSignUp("2523261011@qq.com","chris2","password.com");
		//senseix.coachUidPush();
		senseix.coachLogin ("2523261011@qq.com", "password.com");
		ArrayList users = senseix.getPlayerA();
		//senseix.getPlayer();
		int userID = ((heavyUser)users[0]).id;
		senseix.id = userID;
		
		Queue problems = senseix.pullProblemQ(4,"Mathematics",1);
		
		//Debug.Log(problem.ToString());
		Debug.Log(problems.Count);
		problem problemA = (problem)problems.Dequeue();
		problem p = problemA;
		string question = p.content;
		string answer = p.answer;
		
		char[] destination = new char[20];
		
		question.CopyTo(0,destination,0,question.Length);
		Debug.Log (question);
	*/	
		//senseix.p
	}

	
	// Use this for initialization
	void Start () {
		goal = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(goal){
			//playerController.renderer.material.color= Color.yellow;
			print ("destroyed");
		}
		
		if(Input.GetKey(KeyCode.Escape)){
		
			menu.SetActive(true);
			
			menu.transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, menu.transform.position.z);
			
			Time.timeScale = 0.0f;
		}
	}
	
	void OnGUI(){
		int player_hp = playerController.GetHealth();
		int player_sp = playerController.GetSpirit();
		
		int player_max_hp = playerController.max_hp;
		int player_max_sp = playerController.max_sp;
		
		float hp_ratio = (float)player_hp/player_max_hp;
		float sp_ratio = (float)player_sp/player_max_sp;
		
		GUI.BeginGroup(new  Rect(10.0f,10.0f,empty_bar_tex.width ,empty_bar_tex.height));
			GUI.Box(new Rect(0,0,empty_bar_tex.width,empty_bar_tex.height),empty_bar_tex);
		
				GUI.BeginGroup(new Rect(0.0f,0.0f,health_bar_tex.width * hp_ratio,health_bar_tex.height));
					GUI.Box(new Rect(0.0f,0.0f,health_bar_tex.width,health_bar_tex.height), health_bar_tex);
				GUI.EndGroup();
		GUI.EndGroup();
		
		GUI.BeginGroup(new  Rect(10.0f,50.0f,empty_bar_tex.width ,empty_bar_tex.height));
		GUI.Box(new Rect(0,0,empty_bar_tex.width,empty_bar_tex.height),empty_bar_tex);
		
		GUI.BeginGroup(new Rect(0.0f,0.0f,spirit_bar_tex.width * sp_ratio,spirit_bar_tex.height));
		GUI.Box(new Rect(0.0f,0.0f,spirit_bar_tex.width,spirit_bar_tex.height), spirit_bar_tex);
		GUI.EndGroup();
		GUI.EndGroup();
		
		//GUI.Label(new Rect(10.0f,50.0f,spirit_bar_tex.width * sp_ratio,spirit_bar_tex.height), spirit_bar_tex);
	}
	
	public void GameOver(){
		Time.timeScale = 0.0f;
		gameover.SetActive(true);
		gameover.transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, gameover.transform.position.z);
	}
	

}
