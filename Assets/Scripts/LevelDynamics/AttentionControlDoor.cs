using UnityEngine;
using System.Collections;

public class AttentionControlDoor : MonoBehaviour
{
	public bool requireKey;                     // Whether or not a key is required.
	//public AudioClip accessDeniedClip;        // Maybe add a hostage sound screaming for help?
	private GameObject player;                  // Reference to the player GameObject.
	//private PlayerInventory playerInventory;    // Reference to the PlayerInventory script.
	private int count;                          // The number of colliders present that should open the doors.
	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag(Tags.player);
		//playerInventory = player.GetComponent<PlayerInventory>();
	}

	void OnTriggerEnter (Collider other)
	{
		// If the triggering gameobject is the player...
		if(other.gameObject == player)
		{
			// ... if this door requires a key...
			if(requireKey)
			{
				// ... if the player has the key...
				if(GameMaster.control.attentionControl)
				{
					Debug.Log ("Have key");
					if(gameObject.name=="laserDoor1")
					// ... increase the count of triggering objects.
						Destroy(gameObject);
					else
						Debug.Log ("Not right key?");
				}
				if(GameMaster.control.selfTalk)
				{
					Debug.Log ("Have key");
					if(gameObject.name=="laserDoor2")
						// ... increase the count of triggering objects.
						Destroy(gameObject);
					else
						Debug.Log ("Not right key?");
				}
				if(GameMaster.control.memory)
				{
					Debug.Log ("Have key");
					if(gameObject.name=="laserDoor3")
						// ... increase the count of triggering objects.
						Destroy(gameObject);
					else
						Debug.Log ("Not right key?");
				}

				if(GameMaster.control.memory&&GameMaster.control.attentionControl&&GameMaster.control.selfTalk){
					if(gameObject.name=="laserDoor4")
						// ... increase the count of triggering objects.
						Destroy(gameObject);
					else
						Debug.Log ("Not right key?");

				}
				else
				{
					Debug.Log ("Dont Have key");
				}
			}
			else
				Debug.Log("All doors require keyerino");
		}
		// If the triggering gameobject is an enemy...
		else if(other.gameObject.tag == Tags.enemy)
		{
			// ... if the triggering collider is a capsule collider...
			if(other is CapsuleCollider)
				// ... increase the count of triggering objects.
				count++;
		}
	}
	void OnTriggerExit (Collider other)
	{
		// If the leaving gameobject is the player or an enemy and the collider is a capsule collider...
		if(other.gameObject == player || (other.gameObject.tag == Tags.enemy && other is CapsuleCollider))
			// decrease the count of triggering objects.
			count = Mathf.Max(0, count-1);
	}
}