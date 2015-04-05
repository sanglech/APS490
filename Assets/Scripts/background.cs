using UnityEngine;
using System.Collections;
using UnityEngine.UI;


struct queue{
	public int[] buttons;
	public int length;
}


public class background : MonoBehaviour {

	// Use this for initialization
	int EXITCONDITION = 1;
	int difficulty = 1;
	int fail;
	private queue pressed;
	private queue answer;
	private bool ready;
	private bool displaying;
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		fail = 0;
		for (int i = 1; i<=6; i++) 
		{
			Image show;
			string name= "";
			name += i;
			show = GameObject.Find(name).GetComponent<Image>();
			show.enabled = false;

			
		}


		ready = false;
		displaying = false;
		Text txt;
		txt = GameObject.Find("Text1").GetComponent<Text>();
		txt.text = "";
	}
	
	// Update is called once per frame
	void Update () {


		/*Image hi;
		hi = GameObject.Find("Image").GetComponent<Image>();
		hi.enabled = !hi.enabled;*/
	}
	public void update_press(int i)
	{
		if (pressed.length >= answer.length | !ready) {
			return;
				}

		pressed.buttons [pressed.length] = i;
		pressed.length ++;

		string update = "";
		for (int f = 0; f < pressed.length; f++) {
			update += pressed.buttons[f];
		}
		Text txt;
		txt = GameObject.Find("Text1").GetComponent<Text>();
		txt.text = update;

		if (pressed.length == answer.length) 
		{
			int j = 0;
			for(j=0;j<pressed.length;j++)
			{
				if(pressed.buttons[j]!=answer.buttons[j])
					break;
			}
			if (j == pressed.length)
			{
				txt.text = "Level Passed. Congratualtions! Press start to continue.";
				difficulty ++;
				fail = 0;
			}
			else
			{
				fail ++;
				if(fail == 3)
				{
					if (difficulty >= EXITCONDITION && (GameMaster.control.fromMainGame)) 
					{
						GameMaster.control.score += 50 * difficulty;
						GameMaster.control.fromMainGame = false;
						Application.LoadLevel ("MainGame");
						return;
					}
	
					txt.text = "Failed 3 time in this level, difficulty decreased";

					if(difficulty>1) difficulty --;
					fail = 0;
				}
				else
					txt.text = "Failed. Try again.";
			}
			ready = false;
			return;
		}

	}
	IEnumerator display()
	{
		displaying = true;
		Text txt;
		txt = GameObject.Find("Text1").GetComponent<Text>();
		txt.text = "Pay attention!";
		for (int i = 0; i<answer.length; i++) 
		{
			Image show;
			string name = "";
			name += answer.buttons[i];
			show = GameObject.Find(name).GetComponent<Image>();
			show.enabled = true;
			yield return new WaitForSeconds(0.5F);			
			show.enabled = false;	
			yield return new WaitForSeconds(0.3F);	
		}
		ready = true;
		txt.text = "Go!";
		displaying = false;
	}

	public void game_start()
	{
		if (displaying == true)
						return;

		ready = false;
		answer.buttons = new int[difficulty] ;
		for (int i=0; i<difficulty; i++)
						answer.buttons [i] = Random.Range (1,6);
		answer.length = difficulty;
		pressed.buttons = new int[answer.length];
		pressed.length = 0;
		StartCoroutine(display());


	}

	public void back()
	{
		if (difficulty >= EXITCONDITION && (GameMaster.control.fromMainGame)) 
		{
			GameMaster.control.score += 50 * difficulty;
			GameMaster.control.fromMainGame = false;
			Application.LoadLevel ("MainGame");
			return;
		}
		Application.LoadLevel("menu");
	}
}
