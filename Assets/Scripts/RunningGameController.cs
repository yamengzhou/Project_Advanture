using UnityEngine;
using System.Collections;

public class RunningGameController : MonoBehaviour {

	public GameObject surface;
	public float startWait = 0.0f;
	
	private float spawnTime;
	private float spawnWait;
	private Quaternion spawnRotation;
	
	private RunnerController runnerController;
	private ShotController shotController;
	private HazzardController hazzardController;
	
	public float question_time = 2.0f;
	private float question_temp_time;
	
	private bool question_popup;
	
	private int ans,correct_num;
	private int[] wrong_ans = new int[2];
	
	private int[] level_record = new int[4];
	private int current_level;
	
	public int levelup_threshold = 5;
	
	void Awake(){

		GameObject runnerControllerObject = GameObject.FindWithTag("Player");;
		
		if(runnerControllerObject == null)
			Debug.LogError("No runner Controller object is found");
		else{
			runnerController = runnerControllerObject.GetComponent<RunnerController>();
			if(runnerController == null)
				Debug.LogError("No runner controller is found");
		}
		
		GameObject shotControllerObject = GameObject.FindWithTag("Shooter");
		if(shotControllerObject == null)
			Debug.LogError("No shooter controller object is found");
		else{
			shotController = shotControllerObject.GetComponent<ShotController>();
			if(shotController == null){
				Debug.LogError("No shooter controller is found");
			}
		}
		
		GameObject hazzardControllerObject = GameObject.FindWithTag("Chasing");
		if(hazzardControllerObject == null)
			Debug.LogError("No hazzard controller object is found");
		else{
			hazzardController = hazzardControllerObject.GetComponent<HazzardController>();
			if(hazzardController == null)
				Debug.LogError("No hazzard controller is found");
		}

		spawnWait = 3.5f;
		spawnRotation = Quaternion.identity;
		
		question_popup = false;
		
		for(int i = 0; i < 4; i++)
			level_record[i] = 0;
		
		current_level = 1;
	}
	
	// Use this for initialization
	void Start () {
		//Instantiate(surface);
		for(int i = 0;i < 40; i++){
			Instantiate(surface,new Vector3(-20.0f + 1.0f*i,0.0f,0.0f),spawnRotation);
		}
		question_temp_time = Time.time;
		StartCoroutine(SpawnWaves ());
	}
	
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log(Input.mousePosition);
	}
	
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		
		while(true){
		
			for(int i = 0;i < 30; i++){
				Instantiate(surface,new Vector3(13.0f + 1.0f*i,0.0f,0.0f),spawnRotation);
				
			}
			
			if(Time.time - question_temp_time >= question_time){
				question_popup = true;
				
				
				//ans = 7;
				correct_num = Random.Range(1,3);
				
				for(int i = 0; i < 2 ; i++){
				
					while(true){
						int rnd = Random.Range(1,20);
						
						if(rnd != 7){
							wrong_ans[i] = rnd;
							break;
						}
					}
				
				}

				GetEquation();
				shotController.ProjectileQuestion();
				question_temp_time = Time.time;	
			}
			yield return new WaitForSeconds(spawnWait);
		}
	}
	
	void FixedUpdate(){
		
	
	}

	public void GameOver(){
	
		//Application.LoadLevel();
	}
	
	void GetEquation(){
		
		Queue problems = senseix.pullProblemQ(1,"Mathematics",current_level);
		
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
		shotController.setBlockValue(var_1,symbol,var_2);
		
		//shotController.setBlockValue("3","+","4");
		
	}
	
	void LevelUp(){
	
		shotController.IncreaseBackMoveSpeed();
	
		//current_level++;
	}
	
	void OnGUI(){
	
		if(question_popup){

			
			int n = 0;
			for(int i = 0; i < 3; i++){
				if(i == correct_num){
					if(GUI.Button(new Rect(80 + i*40, 200 + i*40,40,40), ans.ToString())){
						print("Right Answer");
						
						level_record[current_level]++;
						
						if(level_record[current_level] >= levelup_threshold)
							LevelUp();
						
						question_popup = false;
						
						Vector3 player_pos = runnerController.transform.position;
						runnerController.rigidbody.AddForce(new Vector3(3.0f,10.0f,0.0f),ForceMode.Impulse);
						runnerController.AfterJumping();
						//runnerController.transform.position = new Vector3(Mathf.Lerp(runnerController.transform.position.x, player_pos.x,2.0f),runnerController.transform.position.y,runnerController.transform.position.z);
					}
				
				}
				else{
					if(GUI.Button(new Rect(80 + i*40, 200 + i*40,40,40), (wrong_ans[n++]).ToString())){
						print("Wrong answer");
						question_popup = false;
					}
				
				}
			}
		}
	}
}
