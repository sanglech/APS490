using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {
	void Awake(){
		GameMaster.control.finishGame = true;
		GameMaster.control.achieveOne = true;
		GameMaster.control.fromMainGame = false;
	}
	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width/2-250, 0, 500, 50), "Back To Menu")) {
			Application.LoadLevel("menu");
		}
	}
}
