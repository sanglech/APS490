using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	public float speed = 1f;            // The speed that the player will move at.

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;          // The length of the ray from the camera into the scene.
	int walkCount =0;
	int stayCount =0;
	public int beat = 60;


	
	public Joystick joyStickRight = null;
	public float rotationSpeed = 0.5f;
	public float gravity = 20.0F;
	private int playAreaMask;
	private bool check = false;



	void Awake ()
	{
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");
		playAreaMask = LayerMask.GetMask ("PlayArea");
		
		// Set up references.
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}

	void Start(){
		if(joyStickRight==null){
			GameObject objjoyStickRight = GameObject.FindGameObjectWithTag("RightJoystick") as GameObject;
			joyStickRight = objjoyStickRight.GetComponent<Joystick>();
		}
	}
	
	
	void FixedUpdate ()
	{
		// Store the input axes.
		float vertical = Mathf.Round (joyStickRight.position.y);
		float horizontal = Mathf.Round (joyStickRight.position.x);
		
		// Move the player around the scene.
		Move (horizontal, vertical);
		
		// Turn the player to face the mouse cursor.
		Turning ();
		
		// Animate the player.
		Animating (horizontal, vertical);
	}
	
	void Move (float h, float v)
	{

		movement.Set (h,0f,v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (this.transform.position + movement);

		/*
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);

		*/
	}
	
	void Turning ()
	{

		if (Input.touchCount > 1) {
			// Create a ray from the mouse cursor on screen in the direction of the camera.
			Ray camRay = Camera.main.ScreenPointToRay (Input.GetTouch (1).position);
			
			// Create a RaycastHit variable to store information about what was hit by the ray.
			RaycastHit floorHit;
			
			// Perform the raycast and if it hits something on the floor layer...
			check=Physics.Raycast (camRay, out floorHit, camRayLength, playAreaMask);
			if (check) {
				// Create a vector from the player to the point on the floor the raycast from the mouse hit.
				Vector3 playerToMouse = floorHit.point - transform.position;
				// Ensure the vector is entirely along the floor plane.
				playerToMouse.y = 0f;
				
				// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
				Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
				//Debug.Log("newRotation= "+newRotation);
				
				// Set the player's rotation to this new rotation.
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRotation, 6 * Time.deltaTime);
				//playerRigidbody.MoveRotation (newRotation);
			}
		}
		/*
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			
			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);
		}
		*/
	}
	
	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.

		bool walking = Mathf.Round(h) != 0f ||  Mathf.Round(v) != 0f;
		// Tell the animator whether or not the player is walking.
		bool firing=false;
		if (Input.touchCount > 1) {
			firing=true;
		}
		anim.SetBool ("IsFiring", firing);
		anim.SetBool ("IsWalking", walking);
		if (walking) 
		{
			walkCount+=1;
		}
		else stayCount+=1;

		if(SWP_HeartRateMonitor.Instance.BeatsPerMinute>=180)
		{
			PlayerHealth.Instance.Death();
			PlayerHealth.Instance.currentHealth=0;
			PlayerHealth.Instance.healthSlider.value = 0;
		}


		if (walking&&walkCount==10) 
		{
			beat++;
			SWP_HeartRateMonitor.Instance.BeatsPerMinute +=1;
			walkCount=0;
			//Debug.Log ("plus!", gameObject);


		}

	
		if(stayCount>=100&&beat>60){
			SWP_HeartRateMonitor.Instance.BeatsPerMinute -=1;
			stayCount=0;
			beat--;
			//Debug.Log ("Minus!", gameObject);
	     //if (walking==false&&stayCount==10&&SWP_HeartRateMonitor.Instance.BeatsPerMinute>60) 
		//if (walking==false&&stayCount==10&&HeartBeatManager.Instance.HeartBeat>60)
		}

	}
}