using UnityEngine;
using System.Collections;

[System.Serializable]
public class MojangController : MonoBehaviour {

	public Vector3 boundary;
	public int row = 10;
	
	private GameObject card;
	private float card_h = 3.0f;
	private float card_w = 2.0f;
	
	private Vector3[] pos;
	private GameObject[] cards;
	
	void Awake(){
	
		pos = new Vector3[row*row];
		float minX = -boundary.x;
		float minY = -boundary.y;
		
		card_h = boundary.y*2/row;
		card_w = boundary.x*2/row;
		
		for(int i = 1; i <= row; i++)
			for(int j = 1; j <= row; j++)
				pos[(i-1)*(row-1) + j - 1] = new Vector3(minX+i*card_w, minY+j*card_h, 0.0f);
	}
	
	// Use this for initialization
	void Start () {
		cards = new GameObject[row*row];

		for(int i = 1; i < row; i++)
			for(int j = 1; j < row; j++){
			
			GameObject card = (GameObject)Instantiate(Resources.Load("Prefabs/Card_Module"));
			
			card.transform.localScale = new Vector3(boundary.x*2/row,boundary.y*2/row);
			
			cards[(i-1)*(row-1) + j - 1] = card;
			cards[(i-1)*(row-1) + j - 1].transform.position = pos[(i-1)*(row - 1) + j -1];
			}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
