using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public GameObject block_1;
	public GameObject block_2;
	public GameObject block_3;
	public Transform proj_0;
	public Transform proj_n45;
	public Transform proj_45;
	
	private HazzardController hazzardController;
	private string number_1;
	private string number_2;
	private string symbol;
	
	private string[] symbols = new string[4]{"+","-","*","/"};
	private string[] symbols_name = new string[4]{"plus","subtraction","multiplication","division"};
	
	void Awake(){
	
		GameObject hazzardControllerObject = GameObject.FindWithTag("Chasing");
		
		if(hazzardControllerObject == null)
			Debug.LogError("No hazzard controller object is found");
		else{
			hazzardController = hazzardControllerObject.GetComponent<HazzardController>();
			
			if(hazzardController == null)
				Debug.LogError("No hazzard controller is found");
		}
	
	}

	// Use this for initialization
	void Start () {
		//ProjectileQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate(){
	
		transform.position = hazzardController.transform.position + new Vector3(2.0f,3.0f,0.0f);
	}
	
	
	public void ProjectileQuestion(){
		
		Instantiate(block_1, proj_0.position, proj_0.rotation);
		Instantiate(block_2, proj_n45.position, proj_n45.rotation);
		Instantiate(block_3, proj_45.position, proj_45.rotation);
		
	}
	
	public void setBlockValue(string num_1, string symbol, string num_2){
	
		number_1 = num_1;
		number_2 = num_2;
		this.symbol = symbol;
		
		string num_1_name = "num_" + num_1;
		
		int symbol_num = 0;
		for(int i = 0; i < 4; i++)
			if((this.symbol).Equals(symbols[i])){
				symbol_num = i;
				break;
			}
		
		string symbol_name = symbols_name[symbol_num];
		//string symbol_name = "plus";
		string num_2_name = "num_" + num_2;
		
		print(num_1_name);
		print(symbol_name);
		print(num_2_name);
		
		Texture2D num_1_tex = Resources.Load(num_1_name) as Texture2D;
		Texture2D num_2_tex = Resources.Load(num_2_name) as Texture2D;
		Texture2D symbol_tex = Resources.Load(symbol_name) as Texture2D;
		
		block_1.renderer.material.mainTexture = symbol_tex;
		block_2.renderer.material.mainTexture = num_2_tex;
		block_3.renderer.material.mainTexture = num_1_tex;
		

	}
	
	public void IncreaseBackMoveSpeed(){
	
		ProjectileController block_1_Object = block_1.GetComponent<ProjectileController>();
		block_1_Object.SpeedUp();
		
		ProjectileController block_2_Object = block_2.GetComponent<ProjectileController>();
		block_2_Object.SpeedUp();
		
		ProjectileController block_3_Object = block_3.GetComponent<ProjectileController>();
		block_3_Object.SpeedUp();
	
	}
}
