using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class achieveCheck : MonoBehaviour {

	private bool check;
	private float ctr;

	public GameObject complete;
	public GameObject incomplete;
	Image image; 
	private bool addScore1,addScore2,addScore3;
	// Use this for initialization

	void Awake(){
		addScore1 = true;
		ctr = 0;
		check = true;
		image = GetComponent <Image> ();
		
	}
	void LateUpdate () {
		if (this.gameObject.name.Equals("aText1")) {
			if(GameMaster.control.achieveOne){
				complete.SetActive(true);
				if(addScore1){
					addScore1=false;
					ScoreManager.score+=100;
				}
			}
			else if(!(GameMaster.control.finishGame)){
				incomplete.SetActive(true);
			}
		}
		if (this.gameObject.name.Equals("aText2")) {
			if(GameMaster.control.finishGame){
				complete.SetActive(true);
				if(addScore2){
					addScore2=false;
					ScoreManager.score+=100;
				}
			}
			else if(!(GameMaster.control.finishGame)){
				incomplete.SetActive(true);
			}
		}
		if (this.gameObject.name.Equals("aText3")) {
			if(GameMaster.control.finishGame){
				complete.SetActive(true);
				if(addScore3){
					addScore1=false;
					ScoreManager.score+=1000;
				}
			}
			else if(!(GameMaster.control.finishGame)){
				incomplete.SetActive(true);
			}
		}
		if (check) {
			if(ctr>3){
				ctr=0;
				complete.SetActive(false);
				incomplete.SetActive(false);
				gameObject.SetActive(false);
			}
			else
				ctr+=Time.deltaTime;
		}
		
	}
}