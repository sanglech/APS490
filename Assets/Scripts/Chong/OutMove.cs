using UnityEngine;
using System.Collections;

public class OutMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 temp = GameObject.FindGameObjectWithTag("SpritCamera").transform.position;
		Vector3 a = new Vector3(3,-3.9f,3f);
		//Vector3 b = GameObject.Find("Lungs model").transform.position;
		var Lung = GameObject.FindGameObjectWithTag ("breathout");
		Lung.transform.position = a + temp;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = GameObject.FindGameObjectWithTag("SpritCamera").transform.position;
		Vector3 a = new Vector3(3,-3.9f,3f);
		//Vector3 b = GameObject.Find("Lungs model").transform.position;
		var Lung = GameObject.FindGameObjectWithTag ("breathout");
		Lung.transform.position = a + temp;
	}
}
