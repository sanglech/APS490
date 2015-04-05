/* Speech Bubble Creation: 
 * 41 Post - Created by DimasTheDriver on Dec/12/2011 . Part of the 'Unity: How to create a speech balloon' post. 
	Available at: http://www.41post.com/?p=4545
	Questionaire style game: Christian
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class SpeechBubble : MonoBehaviour 
{
	//this game object's transform
	private Transform goTransform;
	//the game object's position on the screen, in pixels
	private Vector3 goScreenPos;
	//the game objects position on the screen
	private Vector3 goViewportPos;
	
	//the width of the speech bubble
	public int bubbleWidth = 200;
	//the height of the speech bubble
	public int bubbleHeight = 100;
	
	//an offset, to better position the bubble 
	public float offsetX = 0;
	public float offsetY = 150;
	
	//an offset to center the bubble 
	private int centerOffsetX;
	private int centerOffsetY;

	//a material to render the triangular part of the speech balloon
	public Material mat;
	//a guiSkin, to render the round part of the speech balloon
	public GUISkin guiSkin;
	
	private Rect rect;
	private string nextmsg;
	private string challengeTalk;
	private bool postiveStatement;
	private bool challenge;
	private bool selfHelp;
	private bool step1,step2,step3,step4,all;
	private string[] inputString;
	private string checkString;
	private float ctr;
	List<string> strongWords = new List<string>();
	List<string> posWords = new List<string>();


	//use this for early initialization
	void Awake() 
	{
		//get this game object's transform
		// Add terms in the satement that the oldier is saying into here.
		goTransform = this.GetComponent<Transform>();
		rect=new Rect(10,25,190,50);
		nextmsg="";
		challengeTalk = "";
		posWords.Add ("good");
		posWords.Add ("believe");
		posWords.Add ("can");
		posWords.Add ("belief");
		posWords.Add ("best");
		posWords.Add ("YOLO");
		strongWords.Add ("cant");
		strongWords.Add ("can't");
		strongWords.Add ("cannot");
		strongWords.Add ("never");
		strongWords.Add ("always");
		strongWords.Add ("nothing");
		strongWords.Add ("everything");
		checkString = "I can't do this. I have never done anything like this.";


	}
	
	//use this for initialization
	void Start()
	{
		//if the material hasn't been found
		if (!mat) 
		{
			Debug.LogError("Please assign a material on the Inspector.");
			return;
		}
		
		//if the guiSkin hasn't been found
		if (!guiSkin) 
		{
			Debug.LogError("Please assign a GUI Skin on the Inspector.");
			return;
		}
		
		//Calculate the X and Y offsets to center the speech balloon exactly on the center of the game object
		centerOffsetX = bubbleWidth/2;
		centerOffsetY = bubbleHeight/2;
	}
	
	void Update(){
		ctr+=Time.deltaTime;
	}
	//Called once per frame, after the update
	void LateUpdate() 
	{
		//find out the position on the screen of this game object
		goScreenPos = Camera.main.WorldToScreenPoint(goTransform.position);	
		
		//Could have used the following line, instead of lines 70 and 71
		//goViewportPos = Camera.main.WorldToViewportPoint(goTransform.position);
		goViewportPos.x = goScreenPos.x/(float)Screen.width;
		goViewportPos.y = goScreenPos.y/(float)Screen.height;
	}
	
	//Draw GUIs
	void OnGUI()
	{
		//Begin the GUI group centering the speech bubble at the same position of this game object. After that, apply the offset
		GUI.BeginGroup(new Rect(goScreenPos.x-centerOffsetX-offsetX,Screen.height-goScreenPos.y-centerOffsetY-offsetY,bubbleWidth,bubbleHeight));
			
			//Render the round part of the bubble
			GUI.Label(new Rect(0,0,200,100),"",guiSkin.customStyles[0]);
			
			//Render the text
			GUI.Label(new Rect(10,25,190,50),checkString,guiSkin.label);
		GUI.EndGroup();


		if(!selfHelp){
			if(GUI.Button(new Rect(Screen.width/2 - 300, Screen.height - 100f, 300, 100), "Create Postive Statement"))
			{
				postiveStatement=true;
				selfHelp=true;
			}
		}

		if(!selfHelp){
			if(GUI.Button(new Rect(Screen.width/2 - 0, Screen.height - 100f, 300, 100), "Challenge Negative Thinking"))
			{
				challenge=true;
				selfHelp=true;
				step1=true;
				step2=false;
				step3=false;
				step4=false;
				all=false;

			}
		}


		if (postiveStatement&&selfHelp&&!step1&&!step2&&!step3&&!step4){
			bool negWordPresent=false;
			if(GUI.Button(new Rect(Screen.width-125f, Screen.height-50f, 100, 40),"Submit")){
				// check msg for negative terms, if none give them full points
				GameMaster.control._postiveStatement=nextmsg;
				inputString=nextmsg.Split(" "[0]);
				int j=0;
				for (int i=0;i<inputString.Length;i++){
					foreach(string str1 in strongWords){
						if(str1==inputString[i]){
							ScoreManager.score = 0;
							negWordPresent=true;
							break;
						}
					}
					if(negWordPresent){
						break;
					}
					foreach(string str2 in posWords){
						if(str2==inputString[i]){
							ScoreManager.score += 100;
						}
						else if(inputString[i].Equals(" ")){
							ScoreManager.score += 0;
						}
						else{
							ScoreManager.score += 50;
						}
					}
				}
				GameMaster.control.score+=j*5;

				if(challenge){
					all=true;
				}
				else{
					all=false;
				}

				selfHelp=false;
				nextmsg="";
			}

			else{
				negWordPresent=false;
				GUI.TextField(new Rect(10, 100, 375, 30f), " What positive statement can you give to bring this soldier up", 100);
				nextmsg = GUI.TextField(new Rect(10, Screen.height - 50f, Screen.width - 150f, 40f), nextmsg, 100);
			}
		}

		if (challenge&&selfHelp&&step1) {
			if(GUI.Button(new Rect(Screen.width-125f, Screen.height-50f, 100, 40),"Submit1")){
				// check msg for negative terms, if find all the terms
				inputString=challengeTalk.Split(" "[0]);
				for (int i=0;i<inputString.Length;i++){
					foreach(string str in strongWords){
						if(str==inputString[i]){
							ScoreManager.score +=100;
						}
					}
				}
				step1=false;
				step2=true;
				challengeTalk="";
			}
			
			else{
				string blah="Was this soldier using extreme words if so wirte them down.";
				GUI.TextField(new Rect(10, 100, blah.Length*7, 30f), blah, 100);
				challengeTalk = GUI.TextField(new Rect(10, Screen.height - 50f, Screen.width - 150f, 40f), challengeTalk, 100);
			}
		}


		if (challenge&&selfHelp&&step2) {
			if(GUI.Button(new Rect(Screen.width-125f, Screen.height-50f, 100, 40),"Submit2")){
				// check if num given >50 give full points
				inputString=challengeTalk.Split(" "[0]);
				for (int i=0;i<inputString.Length;i++){
					int checkVal=0;
					bool isInt=int.TryParse(inputString[i], out checkVal);

					if(isInt)
					{
						if(checkVal<=50)
							ScoreManager.score-=100;
						else
							ScoreManager.score+=50;

						step2=false;
						step3=true;
						challengeTalk="";
					}
					else{
						if(ctr>3){
							ctr=0;
							challengeTalk="";
						}
						else
							challengeTalk="ERROR: Please input a number from 0-100";
					}
				}
			}
			
			else{
				string blah="What are the percentage odds, That they cant do this with your help (0-100) ";
				GUI.TextField(new Rect(10, 100, blah.Length*6, 30f), blah, 100);
				challengeTalk = GUI.TextField(new Rect(10, Screen.height - 50f, Screen.width - 150f, 40f), challengeTalk, 100);
			}
		}


		if (challenge&&selfHelp&&step3) {
			if(GUI.Button(new Rect(Screen.width-125f, Screen.height-50f, 100, 40),"Submit3")){
				// check msg for negative terms, if none give them full points
				inputString=challengeTalk.Split(" "[0]);
				for (int i=0;i<inputString.Length;i++){
					foreach(string str in strongWords){
						if(str==inputString[i]){
							ScoreManager.score-=100;
						}
					}
					foreach(string str2 in posWords){
						if(str2==inputString[i]){
							ScoreManager.score+=100;
						}
						else if(inputString[i].Equals(" ")){
							ScoreManager.score+=0;
						}else{
							ScoreManager.score+=50;
						}
					}
					ScoreManager.score+=5;
				}
				step3=false;
				step4=true;
				challengeTalk="";
			}
			
			else{ 
				GUI.TextField(new Rect(10, 100, 375, 30f), " What is the evidence that they cant complete this?", 100);
				challengeTalk = GUI.TextField(new Rect(10, Screen.height - 50f, Screen.width - 150f, 40f), challengeTalk, 100);
			}
		}


		if (challenge&&selfHelp&&step4) {
			if(GUI.Button(new Rect(Screen.width-125f, Screen.height-50f, 100, 40),"Submit4")){
				// check msg for negative terms, if none give them full points

				inputString=challengeTalk.Split(" "[0]);
				for (int i=0;i<inputString.Length;i++){
					foreach(string str in strongWords){
						if(str==inputString[i]){
							ScoreManager.score-=100;
						}
					}

					foreach(string str2 in posWords){
						if(str2==inputString[i]){
							ScoreManager.score+=100;
						}
						else if(inputString[i].Equals(" ")){
							ScoreManager.score+=0;
						}else{
							ScoreManager.score+=50;
						}
					}
					ScoreManager.score+=5;
				}

				step4=false;
				selfHelp=false;
				challengeTalk="";

				if(postiveStatement){
					all=true;
				}
				else{
					all=false;
				}
			}
			
			else{ 
				GUI.TextField(new Rect(10, 100, 375, 30f), " As a friend to this soldeier, what would you say to him?", 100);
				challengeTalk = GUI.TextField(new Rect(10, Screen.height - 50f, Screen.width - 150f, 40f), challengeTalk, 100);
			}
		}

		//Load back into main Game
		if(postiveStatement&&challenge&&all&&(GameMaster.control.fromMainGame))
			Application.LoadLevel("MainGame");
		if(postiveStatement&&challenge&&all&&!(GameMaster.control.fromMainGame))
			Application.LoadLevel("menu");
	}

	//Called after camera has finished rendering the scene
	void OnRenderObject()
	{
		//push current matrix into the matrix stack
		GL.PushMatrix();
		//set material pass
		mat.SetPass(0);
		//load orthogonal projection matrix
		GL.LoadOrtho();
		//a triangle primitive is going to be rendered
		GL.Begin(GL.TRIANGLES);
	
			//set the color
			GL.Color(Color.white);
			
			//Define the triangle vetices
			GL.Vertex3(goViewportPos.x, goViewportPos.y+(offsetY/3)/Screen.height, 0.1f);
			GL.Vertex3(goViewportPos.x - (bubbleWidth/3)/(float)Screen.width, goViewportPos.y+offsetY/Screen.height, 0.1f);
			GL.Vertex3(goViewportPos.x - (bubbleWidth/8)/(float)Screen.width, goViewportPos.y+offsetY/Screen.height, 0.1f);
		
		GL.End();
		//pop the orthogonal matrix from the stack
		GL.PopMatrix();
	}
}