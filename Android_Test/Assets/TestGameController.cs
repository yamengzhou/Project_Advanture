using UnityEngine;
using System.Collections;

public class TestGameController : MonoBehaviour {

	private Texture2D tex;
	private Texture2D jump_button;
	
	private string debugStr;
	private System.Text.StringBuilder sb = new System.Text.StringBuilder();
	
	public float speed = 10.0f;
	
	void Awake(){
	
		tex = Resources.Load("Touchpad") as Texture2D;
		jump_button = Resources.Load("Jump") as Texture2D;
		
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR || UNITY_EDITOR_WIN
		//print(Input.mousePosition);

#endif

#if UNITY_ANDROID	
		//Input.multiTouchEnabled(true);
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			Vector3 touch_pos = touch.position;
			print("touched!!!");
			if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && touch.tapCount == 1)
			{
				// Touch are screens location. Convert to world
				
				touch_pos.z = 10.0f;
				
				if(touch_pos.x < 160 && touch_pos.x > 0 && touch_pos.y < 400 && touch_pos.y > 10)
					transform.position += new Vector3(-speed*Time.deltaTime,0.0f,0.0f);
				else if(touch_pos.x > 160 && touch_pos.x < 350 && touch_pos.y < 400 && touch_pos.y > 10)
					transform.position += new Vector3(speed*Time.deltaTime,0.0f,0.0f);
	
			}	
			
			
			if((touch.phase == TouchPhase.Ended) && touch.tapCount == 1){
				if(touch_pos.x > 1600 && touch_pos.x < 1800 && touch_pos.y > 10 && touch_pos.y < 300){
					rigidbody.AddForce(new Vector3(0.0f,10.0f,0.0f),ForceMode.Impulse);
				}
				
			}	
		}
#endif
	
	
	}
	
	void OnGUI(){
		
		//string temp = sb.ToString();
		//sb = new System.Text.StringBuilder();
		GUI.Label(new Rect(10.0f,750.0f,tex.width,tex.height),tex);
		GUI.Label(new Rect(1600.0f,900.0f,tex.width,tex.height),jump_button);
		//GUI.Label(new Rect(50.0f,50.0f,400.0f,40.0f),temp);
	}
}
