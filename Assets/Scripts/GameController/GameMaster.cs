using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster control;
	public int currentHealth;
	public int score;
	public int save_score ;
	public int store_point= PlayerPrefs.GetInt("points");
	public bool attentionControl = false;
	public bool memory = false;
	public bool selfTalk = false;
	public Vector3 lastPosition;
	public Vector3 camLastPosition;
	public string _postiveStatement;
	public bool fromMainGame=false;
	public bool finishGame;
	public bool achieveOne;
	public Vector3 defPos;

	private static float defX=-2.28f;
	private static float defY=0.1f;
	private static float defZ=0.51f;

	private static float defCamX=1f;
	private static float defCamY=8f;
	private static float defCamZ=-5f;


	public bool isDead;

	void Awake()
	{
		achieveOne = false;
		_postiveStatement = " ";
		defPos=new Vector3(defX,defY,defZ);

		isDead = false;
		finishGame = false;
		attentionControl = false;
		memory = false;
		selfTalk = false;

		if(control==null)
		{
			DontDestroyOnLoad (gameObject);
			control=this;
			lastPosition.x=defX;
			lastPosition.y=defY;
			lastPosition.z=defZ;
		}
		else if(control!=this){
			Destroy(gameObject);
		}
	}

	void Update(){
		if (isDead||finishGame) {
			lastPosition=defPos;
			attentionControl=false;
			selfTalk = false;
			memory = false;
			isDead=false;
			finishGame=false;
		}
	}
}
