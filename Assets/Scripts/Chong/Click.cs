using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	
	public GameObject breathin;
	public GameObject breathout;
	public GameObject lungs;


	void Start () {

		//Instantiate (breathin);
		//Instantiate (breathout);
		//Instantiate (lungs);
	}
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButtonDown (0)) {
			//animation.Play ("BreathClip");

			if (GameObject.FindGameObjectWithTag("breathin") == null) {
				Instantiate (breathin);
				Instantiate (breathout);
				Instantiate (lungs);

					Debug.Log ("WTF");
				
			}
		
		} else if (Input.GetMouseButtonDown (1)) {
			//animation.Stop ("BreathClip");
			Destroy (GameObject.FindGameObjectWithTag("breathin"));
			Destroy (GameObject.FindGameObjectWithTag("breathout"));
			Destroy (GameObject.FindGameObjectWithTag("lungs"));

		}


	}
}
