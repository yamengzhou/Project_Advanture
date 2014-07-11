using UnityEngine;
using System.Collections;

public class TestGameController : MonoBehaviour {

	private Texture2D tex;

	private string debugStr;
	void Awake(){
	
		tex = Resources.Load("Touchpad") as Texture2D;
	
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
#if UNITY_EDITOR || UNITY_EDITOR_WIN
		print(Input.mousePosition);
#endif

#if UNITY_ANDROID	
<<<<<<< HEAD
//		Input.multiTouchEnabled(true);
=======
		Input.multiTouchEnabled(true);
>>>>>>> dac4a523c9afbd0e8eafa05990a587f49290ff6a
		debugStr = Input.GetTouch(0).position.ToString();
#endif
	
	
	}
	
	void OnGUI(){
	
		GUI.Label(new Rect(0.0f,400.0f,tex.width,tex.height),tex);
		GUI.Label(new Rect(10.0f,10.0f,400.0f,40.0f),debugStr);
	}
}
