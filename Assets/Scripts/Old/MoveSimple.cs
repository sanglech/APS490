using UnityEngine;
using System.Collections;

public class MoveSimple : MonoBehaviour {

	public float speed=3f;
	public float rotateSpeed=10f;
	public float speedDampTime=0.1f;
	Vector3 newPosition;
	Vector3 targetRotation;
	private Animator anim;
	private HashIDs hash;
	private float v;
	private float h; //horizontal movements
	private float d;
	private bool moveCharacter;
	private bool isTouchDevice;


	void Start()
	{
		newPosition = transform.position;
	}

	void Awake()
	{
		if(Application.platform==RuntimePlatform.IPhonePlayer)
		{
			isTouchDevice=true;
		}
		else
		{
			isTouchDevice=false;
		}
		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		anim.SetLayerWeight (1, 1f);

	}

	// Update is called once per frame
	void Update () {

		bool clickDetected;
		Vector3 touchPosition;
		if(isTouchDevice)
		{
			clickDetected=(Input.touchCount>0&& Input.GetTouch(0).phase==TouchPhase.Began);
			touchPosition=Input.GetTouch(0).position;
		}

		else
		{
			clickDetected=Input.GetMouseButtonDown(0);
			touchPosition = Input.mousePosition;
		}

		if(clickDetected)
		{
			RaycastHit hit;
			Ray ray=Camera.main.ScreenPointToRay(touchPosition);

			if(Physics.Raycast(ray,out hit))
			{
				newPosition = hit.point;
				h=newPosition.x; //horizontal movements
				v=newPosition.y;// Veritcal movement
				d=newPosition.z; //Vertical movement in PLANE.
				moveCharacter=true;
			}
			else
			{
				Debug.Log("");
			}
		}

		//transform.position = Vector3.MoveTowards (transform.position, newPosition, Time.deltaTime*speed);
		if(moveCharacter)
			MovementManager(h,v,d,newPosition,true);
	}

	void MovementManager(float horizontal, float vertical,float depth,Vector3 newPosition, bool sneaking)
	{
		float xdiff=horizontal-transform.position.x;
		float ydiff=depth-transform.position.z;

		if(vertical==0f&&(xdiff!=0f||ydiff!=0f))
		{
			anim.SetBool (hash.sneakingBool, sneaking);
			Rotation();
			anim.SetFloat(hash.speedFloat,5.5f,speedDampTime,Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, newPosition, Time.deltaTime*speed);
			if(transform.position.x==horizontal||transform.position.z==depth)
			{
				anim.SetFloat(hash.speedFloat,0);
				anim.SetBool(hash.sneakingBool, false);
			}
		}

		else
		{
			anim.SetFloat(hash.speedFloat,0);
			anim.SetBool(hash.sneakingBool, false);
		}
	}

	void Rotation()
	{
		Quaternion targetRotation=Quaternion.LookRotation(newPosition-transform.position);
		transform.rotation=Quaternion.Slerp(transform.rotation,targetRotation,speed*Time.deltaTime);
	}
}
