using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class nback : MonoBehaviour {
	
	// Use this for initialization
	int EXITCONDITION = 1;
	int difficulty = 1;
	int fail;
	private queue answer;
	private bool[] buttons;
	private bool displaying;
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		fail = 0;
		buttons = new bool[9];
		for (int i = 0; i<9; i++)
			buttons[i] = false;

		Text txt;
		txt = GameObject.Find("Text1").GetComponent<Text>();
		txt.text = "";
		displaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		/*Image hi;
		hi = GameObject.Find("Image").GetComponent<Image>();
		hi.enabled = !hi.enabled;*/
	}
	public void update_press(int i)
	{
		buttons [i - 1] = true;
		
	}
	IEnumerator display()
	{
		displaying = true;
		Text txt;
		int total = 0;
		int missed = 0;
		int hit = 0;
		int expect = -1;
		txt = GameObject.Find("Text1").GetComponent<Text>();
		txt.text = "Pay attention!";
		Text scoretxt = GameObject.Find("score").GetComponent<Text>();
		scoretxt.text = "0";
		Text misstxt = GameObject.Find("miss").GetComponent<Text>();
		misstxt.text = "0";
		Text Nback = GameObject.Find("Nback").GetComponent<Text>();
		Nback.text = difficulty + "-Back";
		for (int i = 0; i<answer.length + 1; i++) 
		{
			if(expect > 0 )
			{
				if(buttons[expect-1] == true)
				{	hit ++;

					scoretxt.text = "" +  (hit);
					GameMaster.control.score+=hit*difficulty;
				}
				else
				{	
					missed ++;

					misstxt.text = "" + (missed);
				}
			}
			for(int j = 0; j < 9; j++)
			{
				if(expect == -1 && buttons[j] == true)
				{
					missed ++;
					misstxt.text = "" + (missed);
				}

				buttons[j] = false;
			}
			if(i == answer.length)
			{
				float a = missed;
				float b = total;
				if(b !=0 && a/b <0.4)
				{
					difficulty ++;
					fail = 0;
				}
				else fail ++;
				if(fail == 3)
				{
					if(difficulty >= EXITCONDITION &&(GameMaster.control.fromMainGame))
					{
						GameMaster.control.score+=50*difficulty;
						Application.LoadLevel("MainGame");
						GameMaster.control.fromMainGame = false;
						yield break;
					}
					if(difficulty > 1)
						difficulty --;
					fail = 0;

				}
				Nback.text = difficulty + "-Back";
				break;
			}
			Image show;
			string name = "B";
			name += answer.buttons[i];
			show = GameObject.Find(name).GetComponent<Image>();
			show.color = Color.blue;
			yield return new WaitForSeconds(0.8F);			
			show.color = Color.white;	
			yield return new WaitForSeconds(0.8F);
			if(i > difficulty - 1  && answer.buttons[i]==answer.buttons[i - difficulty])
			{
				expect = answer.buttons[i];
				total ++;
			}

			else
				expect = -1;
		}
		txt.text = "Done!";
		displaying = false;
	}
	
	public void game_start()
	{
		if (displaying == true)
			return;

		answer.buttons = new int[20*difficulty] ;
		for (int i=0; i<20*difficulty; i++)
			answer.buttons [i] = Random.Range (1,9);
		answer.length = 20*difficulty;
		StartCoroutine(display());
		//Image show;
		//show = GameObject.Find("B1").GetComponent<Image>();
		//show.color = Color.blue;
		
	}
	public void back()
	{
		if (difficulty >= EXITCONDITION && (GameMaster.control.fromMainGame)) 
		{
			GameMaster.control.score += 50 * difficulty;
			Application.LoadLevel ("MainGame");
			GameMaster.control.fromMainGame = false;
			return;
		}
		Application.LoadLevel("menu");
	}
	public void quit()
	{
		Application.Quit();
	}
}
