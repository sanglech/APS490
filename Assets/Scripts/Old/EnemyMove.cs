using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	// Use this for initialization
	Animator anim;                      // Reference to the animator component.
	void Awake () {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Animating ();
	}

	void Animating ()
	{
		anim.SetBool ("Dead", false);
	}
}
