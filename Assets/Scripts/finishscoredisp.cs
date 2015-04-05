using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class finishscoredisp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameMaster.control.store_point=PlayerPrefs.GetInt ("points");
		GameMaster.control.store_point += GameMaster.control.score;

		PlayerPrefs.SetInt("points", GameMaster.control.store_point);
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
		Text txt;
		txt = GameObject.Find("score_display").GetComponent<Text>();
		txt.text = "Your Score: " + GameMaster.control.score + "\nStore Points: " + GameMaster.control.store_point;
	}
}
