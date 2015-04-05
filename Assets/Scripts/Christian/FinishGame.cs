using UnityEngine;
using System.Collections;

public class FinishGame : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	private bool attentionControl;
	private bool selfTalk;
	private bool memory;

	
	// Update is called once per frame
	void Awake () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		memory = GameMaster.control.memory;
		attentionControl = GameMaster.control.attentionControl;
		selfTalk = GameMaster.control.selfTalk;
	}

	void OnTriggerEnter (Collider other)
	{
		// If the colliding gameobject is the player...
		if(other.gameObject == player){
			if(attentionControl&&memory&&selfTalk)
			{
				Application.LoadLevel("FinishScene");
			}
		}
	}

}
