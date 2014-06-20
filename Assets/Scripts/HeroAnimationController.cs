using UnityEngine;
using System.Collections;

public class HeroAnimationController : MonoBehaviour {

	public AnimationClip runningAnimation;
	public AnimationClip JumpingAnimation;
	
	//private Animation _animation;
	private Animator animator;
	private bool jumping;
	// Use this for initialization
	
	void Awake(){
		//_animation = GetComponent<Animation>();
		/*
		if(!runningAnimation){
			Debug.LogError("No running animation clip is found !!!!!");
		
		}
		
		*/
		animator = GetComponent<Animator>();
		
		
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//_animation[runningAnimation.name].speed = 1.0f;
		//_animation.CrossFade(runningAnimation.name);
		animator.Play("Run");
	}
}
