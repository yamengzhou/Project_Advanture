using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {

	private PlayerController playerController;
	private Camera cameraController;
	private GameController gameController;
	
	private bool pointed;
	private bool triggered;
	
	private Vector3 mouse_pos;
	private Vector2[] puzzles_pos = new[]{new Vector2(0,-200), new Vector2(-100,-200), new Vector2(-200,-200), new Vector2(0,-100), new Vector2(-100,-100), new Vector2(-200,-100)};
	
	private string[] input = new string[]{"3","+","2","1","-","4"};
	private string ans = "7";
	
	private string[] symbols = new string[]{"+","-","*","/"};
	private System.Text.StringBuilder sb = new System.Text.StringBuilder();
	
	public int perks = 0;
	
	private bool opened;
	
	void Awake(){
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");
		if(playerControllerObject)
		{
			playerController = playerControllerObject.GetComponent<PlayerController>();
			if(playerController == null)
				Debug.LogError("No player controller object is found");
		}
		
		GameObject cameraControllerObject = GameObject.FindGameObjectWithTag("MainCamera");
		if(cameraControllerObject == null)
			Debug.LogError("No camera controller object is found");
		else{
			cameraController = cameraControllerObject.GetComponent<Camera>();
			if(cameraController == null)
				Debug.LogError("No camera controller is found");
		
		}
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if(gameControllerObject)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
			if(gameController == null)
				Debug.LogError("No game controller object is found");
		}
		
		pointed = false;
		triggered = false;
		opened = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate(){
		
		mouse_pos = cameraController.WorldToScreenPoint(transform.position);
		
		float dist = Vector3.Distance(playerController.transform.position, transform.position);
/*
#if UNITY_EDITOR_WIN
		if(Input.GetMouseButtonDown(0) && dist < 2.0f && pointed){
			GetEquation();
			triggered = true;
		}else if(Input.GetMouseButtonDown(0) && dist > 3.0f)
		{
			triggered = false;
		}
		
#endif
*/
#if UNITY_ANDROID
		if(dist < 2.0f && pointed && !triggered){
			GetEquation();
			triggered = true;
		}else if(dist > 3.0f)
		{
			triggered = false;
		}
#endif
	}
	
	void OnMouseOver(){
		renderer.material.color = Color.red;
<<<<<<< HEAD
		
=======
>>>>>>> dac4a523c9afbd0e8eafa05990a587f49290ff6a
		print("Pointed!!!");
		pointed = true;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.grey;
		pointed = false;
	}
	
	int CalculusMethod(int a, int b, string symbol){
		int result;
		
		switch(symbol){
		case "+":
			result = a + b; break;
		case "-":
			result = a - b; break;
		case "*":
			result = a * b; break;
		case "/":
			result = a / b; break;
		default:
			result = 0; break;
		}
		
		return result;
	}
	
 	bool CheckAnswer(string num_1, string symbol, string num_2){
	
		int temp = 0;
		//if(!int.TryParse(num_1,out temp) || !int.TryParse(symbol,out temp)|| !int.TryParse(num_2,out temp))
		//	return false;
		
		int a = int.Parse(num_1);
		int b = int.Parse(num_2);
		
		int result;
		/*
		switch(symbol){
			case "+":
				result = a + b; break;
			case "-":
				result = a - b; break;
			case "*":
				result = a * b; break;
			case "/":
				result = a / b; break;
			default:
				result = 0; break;
		}
		*/
		
		result = CalculusMethod(a,b,symbol);
		
		print(result);
		int answer = int.Parse(ans);
		
		if(result == answer)
			return true;
		return false;
	}
	
	void OnGUI(){
	
		GUI.skin.label.fontSize = 40;
		if(triggered){
			
			//print(mouse_pos);
			GUI.Label(new Rect(mouse_pos.x - 20.0f, mouse_pos.y - 100.0f, 80.0f,20.0f),"Question");
			
			for(int i = 0; i < 6; i++)
				if(GUI.Button(new Rect(mouse_pos.x + puzzles_pos[i].x - 200.0f, mouse_pos.y + puzzles_pos[i].y, 100.0f,100.0f), input[i])){
					sb.Append(input[i].ToString());
				}
			print(sb.ToString());
			
			string player_pick = sb.ToString();
			
			char[] player_input = new char[3];
			
			if(player_pick.Length > 0)
				player_pick.CopyTo(0,player_input,0,player_pick.Length);
			
			GUI.Label(new Rect(mouse_pos.x - 400.0f,mouse_pos.y + 50.0f,300.0f,50.0f),player_pick);
			GUI.Label(new Rect(mouse_pos.x - 200.0f,mouse_pos.y + 50.0f,80.0f,50.0f),"=" + ans);
			
			bool check_answer = false;
			if(GUI.Button(new Rect(mouse_pos.x - 300.0f, mouse_pos.y, 200.0f, 50.0f),"Answer")){
				if(player_pick.Length == 3)
					check_answer = CheckAnswer(player_input[0].ToString(),player_input[1].ToString(),player_input[2].ToString());
				sb = new System.Text.StringBuilder();
			
			
				if(check_answer){
					//print("Get Fire!!!!");
				
				// Change the function of shrine to help player character	
				//********************************************************************/
					if(perks <= 10)
						playerController.GetPerks(perks);
					else if(perks == 66)
						playerController.RestoreHP();
					else if(perks == 77)
						playerController.RestoreSP();
					else if(perks >= 99 && !opened){
						gameController.AddTreasures(perks);
						opened = true;
					}
					triggered = false;
					pointed = false;
				}else{
					//GUI.Label(new Rect(mouse_pos.x ,mouse_pos.y - 80.0f,80.0f,20.0f),"Wrong answer!!! Check again!!");
					
					playerController.LoseHP(2);
					
				//********************************************************************/
				}
				triggered = false;
				pointed = false;
			}	
		}
	}
	
	void GenerateInput(string num_1, string symbol, string num_2){
	
		int n_1 = int.Parse(num_1);
		int n_2 = int.Parse(num_2);
		int result = int.Parse(ans);
		System.Text.StringBuilder sb_1 = new System.Text.StringBuilder();
		System.Text.StringBuilder sb_2 = new System.Text.StringBuilder();
		
		string rand_1, rand_2, rand_symbol;
		
		bool loop_lock = true;
		while(loop_lock){
			
			int temp_1 = Random.Range(1,9);
			int temp_2 = Random.Range(1,9);
			
			if(n_1 == temp_1 || n_2 == temp_2 || n_1 == temp_2 || n_2 == temp_1 ||CalculusMethod(temp_1,temp_2,symbol) == result || temp_1 == result || temp_2 == result){
				continue;
			}
			
			sb_1.Append(temp_1.ToString());
			sb_2.Append(temp_2.ToString());
			break;
		}
	
		rand_1 = sb_1.ToString();
		rand_2 = sb_2.ToString();
		
		sb_1 = new System.Text.StringBuilder();
		while(loop_lock){
		
			int num = Random.Range(0,3);
			string temp_symbol = symbols[num];
			if(!temp_symbol.Equals(symbol)){
				sb_1.Append(temp_symbol.ToString());
				break;
			}
		}
		rand_symbol = sb_1.ToString();
		
		int[] perm_nums = new int[6];
		
		int[] order = new int[6]{0,1,2,3,4,5};
		
		for(int i = 0; i < 100; i++){
		
			float dice = Random.Range(0.0f,1.0f);
			int idx_1 = Random.Range(0,5);
			int idx_2 = Random.Range(0,5);
			
			if(idx_1 == idx_2)
				continue;
			
			if(dice >= 0.5f){
				int temp = order[idx_1];
				order[idx_1] = order[idx_2];
				order[idx_2] = temp;
			}
		}
		
		input[order[0]] = num_1;
		input[order[1]] = num_2;
		input[order[2]] = symbol;
		input[order[3]] = rand_1;
		input[order[4]] = rand_2;
		input[order[5]] = rand_symbol;

	}
	
	void GetEquation(){
		
		Queue problems = senseix.pullProblemQ(1,"Mathematics",1);
		
		//Debug.Log(problem.ToString());
		//Debug.Log(problems.Count);
		problem problemA = (problem)problems.Dequeue();
		problem p = problemA;
		string question = p.content;
		ans = p.answer;
		string level = p.level;
		
		//print(level);
		
		//current_level = int.Parse(level);
		
		char[] destination = new char[20];
		
		question.CopyTo(0,destination,0,question.Length);
		Debug.Log (destination[0]);
		
		//bool symbol_flag = false;
		
		int symbol_num = 0;
		for(int i = 0; i < question.Length; i++){
			if(destination[i] == '+' || destination[i] == '-' || destination[i] == '*' || destination[i] == '/'){
				symbol_num = i;
				break;
			}
		}
		
		string var_1, var_2, symbol;
		
		System.Text.StringBuilder sb_1 = new System.Text.StringBuilder();
		System.Text.StringBuilder sb_2 = new System.Text.StringBuilder();
		for(int i = 0; i < question.Length; i++){
			if(destination[i] == ' ')
				continue;
			
			if(i < symbol_num)
				sb_1.Append(destination[i].ToString());
			else if(i == symbol_num)
				continue;
			else{
				sb_2.Append(destination[i].ToString());
				print (i);
				print(sb_2.ToString());
			}
			
			if(destination[i+1] == ' ' && destination[i+2] == '=')
				break;
			
		}
		
		symbol = destination[symbol_num].ToString();
		var_1 = sb_1.ToString();
		var_2 = sb_2.ToString();
		
		GenerateInput(var_1, symbol, var_2);
		//ans = int.Parse(answer);
		//print(symbol);
		//shotController.setBlockValue(var_1,symbol,var_2);
		
		//shotController.setBlockValue("3","+","4");
		
	}
	
	public bool GetOpened(){
		return opened;
	}
}
