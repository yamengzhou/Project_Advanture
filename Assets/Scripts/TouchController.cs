using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	private Texture2D tex;
	private Texture2D jump_button;
	
	static public TouchController instance;
	private RaycastHit[] hits;
	private bool[] controlAction = new bool[6];
	
	private bool touched;
	
	private float speed;
	private int w,h;
	private GameObject selected_obj;
	private float touch_start_time;
	public float touch_time = 0.2f;
	private bool menu_popup = false;
	private bool quit_status = false;
	
	public enum actions{Left,Right,Up,Down,Jump,Touched};
	
	void Awake(){
		instance = this;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		w = Screen.height; 
		h = Screen.width;
		
		tex = Resources.Load("Touchpad") as Texture2D;
		jump_button = Resources.Load("Jump") as Texture2D;
	}
	
	// Use this for initialization
	void Start () {
		//selected_obj = null;
	}
	
	// Update is called once per frame
	void Update () {
	
#if UNITY_ANDROID
		
		for(int i = 0; i < Input.touchCount; i++){

			
			Touch touch = Input.GetTouch(i);
			
			Vector3 touch_pos = touch.position;
			touch_pos.z = -Camera.main.transform.position.z;
			
			if(Input.GetKey(KeyCode.Escape)){
				Application.Quit();			
			}
			
			if(Input.GetKey(KeyCode.Menu)){
				
				menu_popup = true;
			}
			
			
			// Virtual JoyStick
			/*
			if ((touch.phase == TouchPhase.Stationary) && touch.tapCount == 1)
			{
				// Touch are screens location. Convert to world
				
				//touch_pos.z = 10.0f;
				
				if(touch_pos.x < tex.width/2 && touch_pos.x > 0 && touch_pos.y < tex.height/3*2 && touch_pos.y > tex.height/3){
					controlAction[(int)actions.Left] = true;
					//transform.position += new Vector3(-speed*Time.deltaTime,0.0f,0.0f);
				}
				else if(touch_pos.x > tex.width/2 && touch_pos.x < tex.width && touch_pos.y < tex.height/3*2 && touch_pos.y > tex.height/3){
					controlAction[(int)actions.Right] = true;
					//transform.position += new Vector3(speed*Time.deltaTime,0.0f,0.0f);
				}
				else if(touch_pos.x < tex.width/3*2 && touch_pos.x > tex.width/3 && touch_pos.y < tex.height && touch_pos.y > tex.height/2){
					controlAction[(int)actions.Up] = true;
					//transform.position += new Vector3(0.0f,speed*Time.deltaTime,0.0f);
				}
				else if(touch_pos.x < tex.width/3*2 && touch_pos.x > tex.width/3  && touch_pos.y < tex.height/2 && touch_pos.y > 0){
					controlAction[(int)actions.Down] = true;
					//transform.position += new Vector3(0.0f,-speed*Time.deltaTime,0.0f);
				}
			}	
			
			
			if((touch.phase == TouchPhase.Began) && touch.tapCount == 1){
				if(touch_pos.x > w - tex.width && touch_pos.x < w && touch_pos.y > 0 && touch_pos.y < tex.height){
					//rigidbody.AddForce(new Vector3(0.0f,10.0f,0.0f),ForceMode.Impulse);
					controlAction[(int)actions.Jump] = true;
				}else{
					touched = true;
				}
			}	
			
			if(touch.phase == TouchPhase.Ended){
			
				for(int j = 0; j < controlAction.Length; j++)
					controlAction[j] = false;
			}
			*/
			// Screen Touch
			if((touch.phase == TouchPhase.Began)&& touch.tapCount == 1){
				touched = true;
				Ray ray_shot = Camera.main.ScreenPointToRay(touch_pos);
				
				hits = Physics.RaycastAll(ray_shot);
				
				//print ("I am pointing '" + hit + "' ");
				
				for(int j = 0; j < hits.Length; j++){
					RaycastHit hit = hits[j];
					
					if(hit.collider.name != "Plane"){
						GameObject obj = hit.collider.gameObject;
						selected_obj = hit.collider.gameObject;
						//obj.renderer.material.color = Color.red;
						//touch_start_time = Time.time;
						//obj.rigidbody.AddForce(0.0f,5.0f,0.0f,ForceMode.Impulse);
					}
				}
				
			}
			
			else if((touch.phase == TouchPhase.Moved && touch.phase != TouchPhase.Began)&& touch.tapCount == 1){
				if((touch_pos.x < tex.width && touch_pos.y < tex.height)||(touch_pos.x > w - tex.width && touch_pos.y < tex.height))
					continue;
				Ray ray_shot = Camera.main.ScreenPointToRay(touch_pos);
				
				hits = Physics.RaycastAll(ray_shot);
				
				//print ("I am pointing '" + hit + "' ");
				
				for(int j = 0; j < hits.Length; j++){
					RaycastHit hit = hits[j];
					
					if(hit.collider.name != "Plane"){
						selected_obj = hit.collider.gameObject;
						
						 //+ new Vector3(0.0f,0.5f,0.0f);
						//obj.renderer.material.color = Color.red;
						//obj.rigidbody.AddForce(0.0f,5.0f,0.0f,ForceMode.Impulse);
					}
					
					//selected_obj.transform.position = hit.point+ hit.normal*selected_obj.transform.localScale.y*0.5f;
				}
			
			}
			
			if(touch.phase == TouchPhase.Ended){
				touched = false;
				//selected_obj.renderer.material.color = Color.white;
				selected_obj = null;
			}
			
		}	
	
#endif
	}
	
	void SetSpeed(float speed){
		this.speed = speed;
	}
	
	RaycastHit[] GetTouchHit(){
		return hits;
	}
	
	
	public bool GetActionListening(actions act){
	
		return controlAction[(int)act];
	}
	
	public GameObject GetSelectedGameObject(){
		return selected_obj;
	}
	
	public void EraseGameObject(){
		selected_obj = null;
	}
	
	public bool GetTouch(){
		return touched;
	}
	
	public void SetTouch(bool input){
		touched = input;
	}
	
	public bool GetMenuStatus(){
		return menu_popup;
	}
	
	public void SetMenuStatus(bool input){
		this.menu_popup = input;
	}
	
/*	
	void OnGUI(){
		//if(selected_obj != null)
			//GUI.Button(new Rect(700.0f,40.0f,100.0f,40.0f),selected_obj.ToString());
		//if(GUI.Button(new Rect(10.0f,10.0f,300.0f,300.0f),"Just trying")){
		//	selected_obj.rigidbody.AddForce(0.0f,5.0f,0.0f,ForceMode.Impulse);
		//};
		//GUI.Label(new Rect(10.0f,40.0f,100.0f,40.0f),"Succeed!!!!");
		//string temp = sb.ToString();
		//sb = new System.Text.StringBuilder();
		GUI.Label(new Rect(10.0f,(float)h - tex.height,tex.width,tex.height),tex);
		GUI.Label(new Rect(w- tex.width,h-tex.height,tex.width,tex.height),jump_button);
		//GUI.Label(new Rect(50.0f,50.0f,400.0f,40.0f),temp);
	}
	*/
}
