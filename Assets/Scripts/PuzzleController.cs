using UnityEngine;
using System.Collections;

public class PuzzleController : MonoBehaviour {

	private bool mouse_in;
	private bool mouse_click_right;
	private PlayerController playerController;
	
	private int click_time;
	private float mouse_x, mouse_y;
	
	private bool push_selected,pull_selected,push,pull;
	
	private Vector2[] puzzles_pos = new[]{new Vector2(-50,-60), new Vector2(-30,-60), new Vector2(-10,-60),
									  new Vector2(-50,-40), new Vector2(-30,-40), new Vector2(-10,-40)};
									  
	private string[] puzzle_nums = new[]{"1","+","2","3","-","4"};
	private string answer = "7";
	private string[] ans_equ = new []{"3+4=7","4+3=7"}; 
	
	private string player_ans;
	private System.Text.StringBuilder sb; 
	private int ans;
	
	private float force;
	
	void Awake(){
		
		GameObject playerControllerObject = GameObject.FindWithTag("Player");
		if (playerControllerObject != null) {
			playerController = playerControllerObject.GetComponent<PlayerController>();		
		}
		if (playerController == null) {
			Debug.Log("Cann't find 'GameController' script");		
		}
		
		mouse_in = false;
		mouse_click_right = false;
		
		click_time = 0;

		force  = playerController.force;
	}
	   
	// Use this for initialization
	void Start () {
		
	}
	
	void Skills(){
		
		Vector3 player_pos = playerController.transform.position;
		Vector3 self_pos = transform.position;
		
		Vector3 vec = player_pos - self_pos;
		
		vec.Normalize();
		
		if(pull){
			rigidbody.AddForce(vec*force, ForceMode.Impulse);
			sb = new System.Text.StringBuilder();
			pull = false;
		}else if(push){
			rigidbody.AddForce(vec*(-force),ForceMode.Impulse);
			sb = new System.Text.StringBuilder();
			push = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(mouse_in && Input.GetMouseButtonDown(1))
		{
			sb = new System.Text.StringBuilder();
			mouse_x = Input.mousePosition.x;
			mouse_y = Input.mousePosition.y;
			
			click_time++;
		}
		Skills();
	}
	
	void OnMouseEnter(){
		mouse_in = true;
	}
	
	void OnMouseExit(){
		mouse_in = false;
	}
	
	void OnGUI(){
		if(pull_selected || push_selected)
			PuzzlePopup();


		if(click_time == 1)
		{
			if(GUI.Button(new Rect(mouse_x,mouse_y,40,20),"push")){
				push_selected = true;
				pull_selected = false;
				
			}
				
			if(GUI.Button(new Rect(mouse_x,mouse_y + 40,30,20),"pull")){
				pull_selected = true;
				push_selected = false;
			}
				
		}else{
			push_selected = false;
			pull_selected = false;
			click_time = 0;
		}
		
	/*
		else{
			if(pull_selected)
			{
				print("pull!!!!");
				pull = true;
				push = false;
			}else if(push_selected){
				print ("push!!!!");
				push = true;
				pull = false;
			}
		
		}
		*/
	}
	
	void GetEquation(){
		
		Queue problems = senseix.pullProblemQ(1,"Mathematics",1);
		
		//Debug.Log(problem.ToString());
		//Debug.Log(problems.Count);
		problem problemA = (problem)problems.Dequeue();
		problem p = problemA;
		string question = p.content;
		string answer = p.answer;
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
		
		ans = int.Parse(answer);
		print(symbol);
		//shotController.setBlockValue(var_1,symbol,var_2);
		
		//shotController.setBlockValue("3","+","4");
		
	}
	
	
	void PuzzlePopup(){
		player_ans = null;
		
		// Draw button blocks for numbers and symbols
		for(int i = 0; i < 6; i++)
		{
			if(GUI.Button(new Rect(mouse_x + puzzles_pos[i].x,mouse_y + puzzles_pos[i].y,20,20),puzzle_nums[i])){
			
				
				
				print(puzzle_nums[i]);
				sb.Append(puzzle_nums[i].ToString());
			}
		}

		player_ans += sb.ToString();
		
		GUI.Label(new Rect(mouse_x + puzzles_pos[2].x + 20, mouse_y + puzzles_pos[2].y,20,40),"=");
		GUI.Label(new Rect(mouse_x + puzzles_pos[2].x + 40, mouse_y + puzzles_pos[2].y,20,40),answer);
		
		player_ans = player_ans + "=" + answer;
		
		
		if(GUI.Button(new Rect(mouse_x + puzzles_pos[2].x + 60, mouse_y + puzzles_pos[2].y,100,20),"answer")){
		
			GUI.Label(new Rect(mouse_x+ puzzles_pos[0].x, mouse_y + puzzles_pos[0].y - 40, 100, 20), player_ans.ToString());
			print("What is the anser??");
			print(player_ans);
			if(string.Equals(player_ans,ans_equ[0]) || string.Equals(player_ans,ans_equ[1]))
			{
				if(pull_selected)
				{
					print("pull!!!!");
					pull = true;
					push = false;
				}else if(push_selected){
					print ("push!!!!");
					push = true;
					pull = false;
				}
			}else
			{
				sb = new System.Text.StringBuilder();
			}
		}
	}
}
