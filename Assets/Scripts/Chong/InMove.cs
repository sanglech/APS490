using UnityEngine;
using System.Collections;

public class InMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 temp = GameObject.FindGameObjectWithTag("SpritCamera").transform.position;
		Vector3 a = new Vector3(2f,-2f,6f);
		//Vector3 b = GameObject.Find("Lungs model").transform.position;
		var Lung = GameObject.FindGameObjectWithTag ("breathin");
		Lung.transform.position = a + temp;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = GameObject.FindGameObjectWithTag("SpritCamera").transform.position;
		Vector3 a = new Vector3(2f,-2f,6f);
		//Vector3 b = GameObject.Find("Lungs model").transform.position;
		var Lung = GameObject.FindGameObjectWithTag ("breathin");
		Lung.transform.position = a + temp;
	
	}
}
