using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour {

	private Animator _animator;
	private PowerController powerController;
	private bool opened;
	// Use this for initialization
	void Start () {
		_animator = this.GetComponent<Animator>();
		powerController = this.GetComponent<PowerController>();
		opened = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(powerController.GetOpened() && !opened){
			opened = true;
			_animator.Play("Treasure_Chest_Idle");
		}
	}
}
