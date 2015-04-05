using UnityEngine;
using System.Collections;

public class LungMove : MonoBehaviour {



	// Use this for initialization
	void Start () {
		Vector3 temp = GameObject.FindGameObjectWithTag("Player").transform.position;
		Vector3 a = new Vector3(-1.3f,-3.9f,3f);
		//Vector3 b = GameObject.Find("Lungs model").transform.position;
		var Lung = GameObject.FindGameObjectWithTag ("lungs");
		Lung.transform.position = a + temp;
		

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = GameObject.FindGameObjectWithTag("SpritCamera").transform.position;
		Vector3 a = new Vector3(-1.3f,-3.9f,3f);
		//Vector3 b = GameObject.Find("Lungs model").transform.position;
		var Lung = GameObject.FindGameObjectWithTag ("lungs");
		Lung.transform.position = a + temp;

	}
}
