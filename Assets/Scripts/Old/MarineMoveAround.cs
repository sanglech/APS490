using UnityEngine;
using System.Collections;

public class MarineMoveAround : MonoBehaviour {

		public float speed = 1f;            // The speed that the player will move at.
		Vector3 movement;                   // The vector to store the direction of the player's movement.
		Animator anim;                      // Reference to the animator component.
		Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
		float camRayLength = 100f;          // The length of the ray from the camera into the scene.
		//public Joystick joyStickLeft = null;

		public Joystick joyStickRight = null;
		public float rotationSpeed = 0.5f;
		public float gravity = 20.0F;
		private int playAreaMask;
		private bool check = false;
		void Awake()
		{
			if (GameMaster.control.attentionControl || GameMaster.control.memory || GameMaster.control.selfTalk) {
				this.transform.position = GameMaster.control.lastPosition;
			}
			// Create a layer mask for the floor layer.
			playAreaMask = LayerMask.GetMask ("PlayArea");
		
			// Set up references.
			anim = GetComponent <Animator> ();
			playerRigidbody = GetComponent <Rigidbody> ();
		}

		void Start () {
			
			// this is to set the joysticks
		/*
			if(joyStickLeft ==null){
				GameObject objjoyStickLeft = GameObject.FindGameObjectWithTag("LeftJoystick") as GameObject;
				joyStickLeft = objjoyStickLeft.GetComponent<Joystick>();
			}
			*/
			if(joyStickRight==null){
				GameObject objjoyStickRight = GameObject.FindGameObjectWithTag("RightJoystick") as GameObject;
				joyStickRight = objjoyStickRight.GetComponent<Joystick>();
			}
			
		}
		
		// Update is called once per frame
		void FixedUpdate () {
			//CharacterController controller = GetComponent<CharacterController> ();
			float vertical = Mathf.Round (joyStickRight.position.y);
			float horizontal = Mathf.Round (joyStickRight.position.x);
			
			Move (horizontal, vertical);
			//rotatePos = joyStickInput(joyStickLeft);
			
			Turning ();
			Animating (vertical, horizontal);
	}
		

	void Move (float h, float v)
	{
		movement.Set (h,0f,v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (this.transform.position + movement);
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
		float horizontal = Mathf.Round (joyStickLeft.position.x);
		float vertical = Mathf.Round(joyStickLeft.position.y);

		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		// Create a rotation based on this new vector assuming that up is the global y axis.

		if (targetDirection != Vector3.zero) {
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);

			targetDirection = Camera.main.transform.TransformDirection (targetDirection);
			targetDirection.y = 0.0f;
			targetDirection.Normalize ();

			// Create a rotation that is an increment closer to the target rotation from the player's rotation.
			Quaternion newRotation = Quaternion.Lerp (rigidbody.rotation, targetRotation, 8f * Time.deltaTime);
		
			// Change the players rotation to this new rotation.
			rigidbody.MoveRotation (newRotation);

		}
		*/
	}
	
	void Animating (float v, float h)
	{
		//float horizontal = Mathf.Round (joyStickLeft.position.x);
		//float vertical = Mathf.Round(joyStickLeft.position.y);

		bool walking = Mathf.Round(h) != 0f ||  Mathf.Round(v) != 0f;
		//bool firing = horizontal != 0f || vertical != 0f;
		bool firing=false;
		if (Input.touchCount > 1) {
			firing=true;
		}
		anim.SetBool ("IsWalking", walking);
		anim.SetBool ("IsFiring", firing);
	}
}
