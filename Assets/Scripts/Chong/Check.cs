using UnityEngine;
using System.Collections;

public class Check : MonoBehaviour {
	public GameObject breathin;
	public GameObject breathout;
	public GameObject lungs;
	public static int shooot;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 1) {
			// Create a ray from the mouse cursor on screen in the direction of the camera.
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (1).position);
			RaycastHit hit = new RaycastHit();

			if(Physics.Raycast(ray,out hit)){
				if(hit.collider.tag == "Player"){
					if (!(Input.touchCount==3)){
						if (GameObject.FindGameObjectWithTag("breathin") == null) {
							Instantiate (breathin);
							Instantiate (breathout);
							Instantiate (lungs);
							Debug.Log(hit.collider.tag);
							//Debug.Log ("WTF");
							shooot=1;
							
						}

					}

				}
			}
		}
		if (Input.touchCount==3) {
			Debug.Log ("BRAP BRAP");
			//animation.Stop ("BreathClip");
			Destroy (GameObject.FindGameObjectWithTag("breathin"));
			Destroy (GameObject.FindGameObjectWithTag("breathout"));
			Destroy (GameObject.FindGameObjectWithTag("lungs"));
			shooot=0;
		}
	}

	public  int a(){
		return shooot;
	}
}
