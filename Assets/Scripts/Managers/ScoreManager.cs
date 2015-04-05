using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
		score = GameMaster.control.score;
    }


    void Update ()
    {
        text.text = "Score: " + score;
		GameMaster.control.score = score;
    }
}
