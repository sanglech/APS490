using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartBeatManager : MonoBehaviour {

	public int HeartBeat;
	public static HeartBeatManager Instance;
	
	
	public Text text;

	public GameObject breathin;
	public GameObject breathout;
	public GameObject lungs;


	void Awake ()
	{

		text = GetComponent <Text> ();
		HeartBeat = 0;
		Instance = this;

	}
	
	
	void Update ()
	{
		string a = HeartBeat.ToString ();
		text.text = a;
	

	}




	// on start, no objects
	// on first click, create objects
	// on second click, remove objects
	/*
	void OnMouseDown() {
		if (GameObject.FindGameObjectsWithTag ("breathin") != null) {
			
			Destroy(breathin);
		} else {
			animation.Play ("BreathClip");
			Instantiate (breathin, transform.position, Quaternion.identity);
			Instantiate (breathout, transform.position, Quaternion.identity);
		}


	}
*/


	public void setColor(Color _NewColour)
	{

		text.color = _NewColour;
	}



}
