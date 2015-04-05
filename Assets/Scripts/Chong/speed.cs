using UnityEngine;
using System.Collections;

public class speed : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float someNumber;
		someNumber = .18f;
		GetComponent<Animation>().Play("C4D Animation Take");
		GetComponent<Animation>()["C4D Animation Take"].speed = someNumber;
	}
}
