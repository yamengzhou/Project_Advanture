using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController_Android : MonoBehaviour {
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpAnimation;

	public float walkMaxAnimationSpeed = 0.75f;
	public float trotMaxAnimationSpeed = 1.0f;
	public float runMaxAnimationSpeed = 1.0f;
	public float jumpAnimationSpeed = 0.2f;
	public float landAnimationSpeed = 1.0f;

	private Animation _animation;
	
	public float force = 10.0f;
	public float walkSpeed = 1.0f;
	public float runningSpeed = 30.0f;
	public float jumpingSpeed= 5.0f;
	private float currentSpeed;

	public float fallingAcc = 0.1f;

	public float jumpingTime = 0.2f;
	
	private bool landed;
	private bool jumping;
	private float startJumping;

	private bool climbing;
	private Quaternion face_dir = new Quaternion();
	private Quaternion current_dir = new Quaternion();
	
	private int health_point, spirit_point;
	public int max_hp = 10, max_sp = 10;
	
	private bool[] skill_status = new bool[4];
	
	private GameController gameController;
	private Camera cameraController;
	private MobileObjectController mobileObjectController;
	
	private bool skill_circle;
	private int right_click_time;
	private Vector2[] skills_pos = new Vector2[]{new Vector2(0.0f,-80.0f), new Vector2(0.0f,80.0f), new Vector2(80.0f,0.0f), new Vector2(-80.0f,0.0f)};
	private string[] skills = new string[4]{"Fireball","Water","Pull","Push"};
	
	public Transform shot_spot;
	public GameObject bullet;
	public float fire_pow = 5.0f;
	public float skill_force = 400.0f;
	
	public GameObject DragonShout;
	
	private int skill_ready;
	
	enum CharacterState {
		Idle = 0,
		Walking = 1,
		Trotting = 2,
		Running = 3,
		Jumping = 4,
	}

	enum CharacterSkill {
		Fire = 0,
		water = 1,
		Pull = 2,
		Push = 3,
	}

	void Awake(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject == null)
			Debug.LogError("No game controller object is found");
		else{
			gameController = gameControllerObject.GetComponent<GameController>();
			if(gameController == null)
				Debug.LogError("No game controller is found");
		}
		
		GameObject cameraControllerObject = GameObject.FindGameObjectWithTag("MainCamera");
		if(cameraControllerObject == null)
			Debug.LogError("No camera controller object is found");
		else{
			cameraController = cameraControllerObject.GetComponent<Camera>();
			if(cameraController == null)
				Debug.LogError("No camera controller is found");	
			}

		if (!walkAnimation)
			Debug.LogError ("No walking animation exist");

		if (!idleAnimation)
			Debug.LogError ("No idle animation exist");

		if(!runAnimation)
			Debug.LogError ("No running animation exist");
			
		if(!jumpAnimation)
			Debug.LogError ("No jumping animation exist");

		_animation = GetComponent<Animation> ();

		landed = false;
		jumping = false;
		
		currentSpeed = 0.0f;
		
		for(int i = 0; i < 4; i++)
			skill_status[i] = false;
			
		//skill_status[3] = true;
		
		
		health_point = max_hp;
		spirit_point = max_sp;
		
		skill_circle = false;
		right_click_time = 0;
		
		skill_ready = 99;
	}


	// Use this for initialization
	void Start () {
		face_dir.eulerAngles = new Vector3(0.0f,90.0f,0.0f);
		//transform.Rotate(0.0f,180.0f,0.0f);
		transform.rotation = face_dir;
		//transform.Rotate (0.0f, 90.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit[] hit = Physics.RaycastAll(transform.position,transform.forward,Mathf.Infinity,0);
		if(hit.Length > 0)
			if(hit[0].distance <= 0.1){
				print (hit[0].distance);
				rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
			}
	}

	void FixedUpdate(){
		
		//Debug.Log(jumping);
		TakeInput();
	}
	
	void TakeInput(){
		
		if (Input.GetKey (KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.LeftShift)&&!jumping) {
			
			//if(Mathf.Sqrt( Mathf.Pow (transform.rotation.eulerAngles.y - (90),2)) <= 1){
				face_dir.eulerAngles = new Vector3(0.0f,-90.0f,0.0f);
				//transform.Rotate(0.0f,180.0f,0.0f);
				transform.rotation = face_dir;
				current_dir = transform.rotation;
			//}
			_animation[walkAnimation.name].speed = walkMaxAnimationSpeed;
			_animation.CrossFade(walkAnimation.name);
			
			transform.position = new Vector3(transform.position.x - walkSpeed*Time.deltaTime, transform.position.y, transform.position.z);
			currentSpeed = -walkSpeed;
		}
		
		else if (Input.GetKey (KeyCode.RightArrow)&& !Input.GetKey(KeyCode.LeftShift)&&!jumping) {
			
			//Debug.Log("Get right arrow key!!!!!!!!!");
			
			//if(Mathf.Sqrt( Mathf.Pow (transform.rotation.eulerAngles.y - (270),2)) <= 1){
				face_dir.eulerAngles = new Vector3(0.0f,90.0f,0.0f);
				//transform.Rotate(0.0f,180.0f,0.0f);
				transform.rotation = face_dir;
				current_dir = transform.rotation;
			//}
			_animation[walkAnimation.name].speed = walkMaxAnimationSpeed;	
			_animation.CrossFade(walkAnimation.name);
			
			transform.position = new Vector3(transform.position.x + walkSpeed*Time.deltaTime, transform.position.y, transform.position.z);
			currentSpeed = walkSpeed;
		}
		
		else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift)&&!jumping){
			face_dir.eulerAngles = new Vector3(0.0f,-90.0f,0.0f);
			//transform.Rotate(0.0f,180.0f,0.0f);
			transform.rotation = face_dir;
			current_dir = transform.rotation;
			
			_animation[runAnimation.name].speed = runMaxAnimationSpeed;
			_animation.CrossFade(runAnimation.name);
			
			transform.position = new Vector3(transform.position.x - runningSpeed*Time.deltaTime, transform.position.y, transform.position.z);
			currentSpeed = -runningSpeed;
		}
		
		else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift)&&!jumping){
			face_dir.eulerAngles = new Vector3(0.0f,90.0f,0.0f);
			//transform.Rotate(0.0f,180.0f,0.0f);
			transform.rotation = face_dir;
			current_dir = transform.rotation;
			
			_animation[runAnimation.name].speed = runMaxAnimationSpeed;
			_animation.CrossFade(runAnimation.name);
			
			transform.position = new Vector3(transform.position.x + runningSpeed*Time.deltaTime, transform.position.y, transform.position.z);
			currentSpeed = runningSpeed;
		}
		
		else if(Input.GetKey(KeyCode.Space)&&!jumping && Time.time - startJumping >= 1.5f){
			
			Debug.Log("Jump!!!!");
			//rigidbody.AddForce(0.0f,10.0f,0.0f);
			startJumping = Time.time;
			jumping = true;
		}
		else if(jumping)
		{
			
			/*
				_animation[jumpAnimation.name].speed = Mathf.Clamp(rigidbody.velocity.magnitude, 0.0f, runMaxAnimationSpeed);;
				_animation.CrossFade(jumpAnimation.name);
				*/
			rigidbody.AddForce(new Vector3(currentSpeed*rigidbody.mass,force,0.0f),ForceMode.Impulse);
			jumping = false;
		}else if(Input.GetKey(KeyCode.UpArrow) && climbing){
		
			transform.position = transform.position + transform.up * Time.deltaTime;
			rigidbody.useGravity = false;
			//transform.Rotate (0.0f, -90.0f, 0.0f);
			
			face_dir.eulerAngles = new Vector3(0.0f,0.0f,0.0f);
			current_dir = transform.rotation;
			transform.rotation = face_dir;
		}
		
		else{
			jumping = false;
			_animation.CrossFade (idleAnimation.name);
			currentSpeed = 0.0f;
			transform.rotation = current_dir;
			//transform.Rotate (0.0f, 90.0f, 0.0f);
		}
		
		if(Input.GetMouseButtonDown(1) && !jumping && right_click_time == 0){
			skill_circle = true;
			right_click_time++;
		}else if(Input.GetMouseButtonDown(1) && right_click_time == 1){
			skill_circle = false;
			right_click_time = 0;
		}
		
		if(Input.GetMouseButtonDown(2)){
			TriggerSkills(skill_ready);
		}
		
		if(Input.GetKeyDown(KeyCode.A)){
			Quaternion forward = new Quaternion();
			forward.eulerAngles = shot_spot.transform.forward;
			
			print (forward.eulerAngles);
			
			Instantiate(DragonShout,shot_spot.position,forward);
		}
	}
	
	void OnTriggerStay(){
	
		climbing = true;
	}
	
	void OnTriggerExit(){
	
		climbing = false;
		rigidbody.useGravity = true;
	}
	
	public int GetHealth(){
		return health_point;
	}
	
	public int GetSpirit(){
		return spirit_point;
	}
	
	public void LoseHP(int substraction){
		health_point -= substraction;
		if(health_point <= 0){
			health_point = 0;
			gameController.GameOver();
		}
	}
	
	public void LoseSP(int usage){
		
		spirit_point -= usage;
		if(spirit_point <= 0)
			spirit_point = 0;
		
	}
	
	public void GetPerks(int skill){
		skill_status[skill] = true;
	}
	
	public void RestoreHP(){
		health_point = max_hp;
	}
	
	public void RestoreSP(){
		spirit_point = max_sp;
	}
	
	void CastFireBall(){
		
	//	Quaternion
		if(spirit_point > 0){
			Instantiate(bullet, shot_spot.position, shot_spot.transform.rotation);
			LoseSP(2);
		}
	}
	
	void CastWater(){
	
	}
	
	void CastPull(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		RaycastHit[] hits = Physics.RaycastAll(ray);
		
		if(hits.Length > 0){
			print (hits[0].collider.name);
			string Tag = hits[0].collider.tag;
			
			RaycastHit[] sight = Physics.RaycastAll(transform.position,hits[0].collider.transform.position);
			
			string Tag_sight;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			
			
			if(sight.Length > 0)
				sb.Append(sight[sight.Length - 1].collider.tag);
			
			Tag_sight = sb.ToString();
			print("target in sight");
			print(Tag_sight);
			if(Tag.Equals("Ball")){
				mobileObjectController = hits[0].collider.gameObject.GetComponent<MobileObjectController>();
				//GameObject mobileObject = GameObject.FindWithTag("Ball");
				//mobileObjectController = mobileObject.GetComponent<MobileObjectController>();
				
				Vector3 direction = (transform.position - mobileObjectController.transform.position);
				
				direction.Normalize();
				
				if(spirit_point > 0){
					mobileObjectController.rigidbody.AddForce(direction * skill_force,ForceMode.Impulse);
					
					LoseSP(1);
				}
			}
		}
	}
	
	void CastPush(){
	
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		RaycastHit[] hits = Physics.RaycastAll(ray);
		
		if(hits.Length > 0){
			print (hits[hits.Length-1].collider.name);
			string Tag = hits[hits.Length-1].collider.tag;
			print(Tag);
			if(Tag.Equals("Ball")){
				mobileObjectController = hits[hits.Length-1].collider.gameObject.GetComponent<MobileObjectController>();
			//GameObject mobileObject = GameObject.FindWithTag("Ball");
			//mobileObjectController = mobileObject.GetComponent<MobileObjectController>();
			
			Vector3 direction = -(transform.position - mobileObjectController.transform.position);
			
			direction.Normalize();
			
			if(spirit_point > 0){
					mobileObjectController.rigidbody.AddForce(direction * skill_force,ForceMode.Impulse);
			
				LoseSP(1);
				}
			}
		}
	}
	
	void TriggerSkills(int num){
	
		//if(skill_status[num] == false)
			
		//print(skills[num]);
		print (num);
		
		switch(num){
			case 0:
				CastFireBall();break;
			case 1:
				CastWater();break;
			case 2:
				CastPull();break;
			case 3:
				CastPush();break;
			default:
				break;
		}
		
	}
	
	void OnGUI(){
	
		Vector3 circle_center = cameraController.WorldToScreenPoint(transform.position) + new Vector3(-30.0f,-10.0f,0.0f);
		if(skill_circle){
			for(int i = 0; i < 4; i++)
				if(GUI.Button(new Rect(circle_center.x + skills_pos[i].x,circle_center.y + skills_pos[i].y,80.0f,20.0f),skills[i])){
					
					if(skill_status[i] == true)
						skill_ready = i;
					
					if(skill_status[i] == false)
						GUI.Label(new Rect(circle_center.x ,circle_center.y -100.0f,150.0f,20.0f),"Find shrines!!");
					//else
						//TriggerSkills(i);
					skill_circle = false;
				}
		}
	
	}
	
	void OnCollisionEnter(Collision collision){
		
		if(collision.collider.tag == "Coin"){
			gameController.AddCoin();
			Destroy(collision.gameObject);
		}
	
	}
}
