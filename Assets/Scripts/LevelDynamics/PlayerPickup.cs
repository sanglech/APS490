using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour
{
	//public AudioClip keyGrab;                       // Audioclip to play when the key is picked up.
	
	
	private GameObject player;                      // Reference to the player.
	private GameObject hostage;                      // Reference to the player.
	private GameObject thisHostage;                      // Reference to the player.
	private GameObject cam;
	//private PlayerInventory playerInventory;        // Reference to the player's inventory.
	
	
	void Awake ()
	{
		thisHostage=this.gameObject;
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag(Tags.player);
		//playerInventory = player.GetComponent<PlayerInventory>();
		cam = GameObject.FindGameObjectWithTag (Tags.mainCamera);

	}

	void Start(){

		if(thisHostage.name=="Hostage1"&&(GameMaster.control.attentionControl))
		{
			player.transform.position=GameMaster.control.lastPosition;
			cam.transform.position=GameMaster.control.camLastPosition;
			hostage=GameObject.Find("Hostage1");
			Destroy(hostage);
			
		}
		
		if(gameObject.name=="Hostage2"&&(GameMaster.control.selfTalk))
		{
			player.transform.position=GameMaster.control.lastPosition;
			cam.transform.position=GameMaster.control.camLastPosition;
			hostage=GameObject.Find("Hostage2");
			Destroy(hostage);
			
		}

		if(gameObject.name=="Hostage3"&&(GameMaster.control.memory))
		{
			player.transform.position=GameMaster.control.lastPosition;
			cam.transform.position=GameMaster.control.camLastPosition;
			hostage=GameObject.Find("Hostage3");
			Destroy(hostage);
			
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			if(gameObject.name=="Hostage1"&&!(GameMaster.control.attentionControl))
			{
				Debug.Log("Saved Hostage 1");
				GameMaster.control.attentionControl=true;
				GameMaster.control.fromMainGame = true;
				GameMaster.control.lastPosition=gameObject.transform.position;
				GameMaster.control.camLastPosition=cam.transform.position;
				//Destroy(this.gameObject);
				Application.LoadLevel("AttentionControl");


			}
			else if(gameObject.name=="Hostage2"&&!(GameMaster.control.selfTalk))
			{
				Debug.Log("Saved Hostage 2");
				GameMaster.control.selfTalk = true;
				GameMaster.control.fromMainGame = true;
				GameMaster.control.lastPosition=gameObject.transform.position;
				GameMaster.control.camLastPosition=cam.transform.position;
				//Destroy(this.gameObject);
				Application.LoadLevel("SelfTalk");
			}

			else if(gameObject.name=="Hostage3"&&!(GameMaster.control.memory))
			{
				Debug.Log("Saved Hostage 3");
				GameMaster.control.memory = true;
				GameMaster.control.fromMainGame = true;
				GameMaster.control.lastPosition=gameObject.transform.position;
				GameMaster.control.camLastPosition=cam.transform.position;
				//Destroy(this.gameObject);
				Application.LoadLevel("Memory");

			}

			Debug.Log(gameObject.name);
			
			// ... the player has a key ...

			
			// ... and destroy this gameobject.
			Destroy(gameObject);
		}
	}
}