using UnityEngine;
using System.Collections;

public class LoadlAttentionControl : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if(GameMaster.control.attentionControl)
			Application.LoadLevel("temp");
		else
			Destroy(gameObject);
	}
}
