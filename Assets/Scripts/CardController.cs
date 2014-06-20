using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {

	private bool[] status;
	Vector3[] fwd = new[]{new Vector3(1.0f,0.0f,0.0f),new Vector3(-1.0f,0.0f,0.0f),new Vector3(0.0f,1.0f,0.0f),new Vector3(0.0f,-1.0f,0.0f)}; //= new Vector3(1.0f,0.0f,0.0f);
	void Awake(){
		status = new bool[4];
		

			
		 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	
	void FixedUpdate(){

		for(int i = 0; i < 4; i++)
			status[i] = false;

		for(int j = 0; j < 4; j++){
			RaycastHit[] hits;
			hits = Physics.RaycastAll(transform.position, fwd[j], 100.0f);
			//Debug.Log(hits.Length);	
			
			
			int i = 0;
			while(i < hits.Length){
				RaycastHit hit = hits[i];
				if(hit.collider.tag == "BoundingBox")
					break;
				i++;
			}
			//Debug.Log(i);
			
			if(i == 0)
				status[j] = true;
			//print(status[j]);
		}
	}
	
}
