using UnityEngine;
using System.Collections;

public class selfTalkMenu : MonoBehaviour {

	public void checkMenu(){
		if (GameMaster.control.fromMainGame) {
			Application.LoadLevel("MainGame");
		}

		if (!(GameMaster.control.fromMainGame)) {
			Application.LoadLevel("menu");
		}

	}
}
