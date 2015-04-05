using UnityEngine;
using System.Collections;

public class LoadSelfTalk : MonoBehaviour {
	void OnTriggerEnter(Collider collider){
		
		Application.LoadLevel("SelfTalk");
	}
}
