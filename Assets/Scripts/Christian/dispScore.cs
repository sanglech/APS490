using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dispScore : MonoBehaviour
{
	public int score;
	
	
	Text text;
	
	
	void Awake ()
	{
		text = GetComponent <Text> ();
		score = PlayerPrefs.GetInt("points");
	}
	
	
	void Update ()
	{
		text.text = "Current Points: " + score;
		GameMaster.control.score = score;
	}
}
