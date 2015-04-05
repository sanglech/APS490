using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stopText : MonoBehaviour {

	private bool check;
	private float ctr;
	Text text;
	// Update is called once per frame

	void Awake(){
		ctr = 0;
		check = true;
		text = GetComponent <Text> ();

	}
	void LateUpdate () {
		if (GameMaster.control.score < 1000000) {
			text.text="Sorry, you do not have enough funds\n"+"Play more games to earn more points!";
		}
		if (check) {
			if(ctr>3){
				ctr=0;
				gameObject.SetActive(false);
			}
			else
				ctr+=Time.deltaTime;
		}
	
	}
}
