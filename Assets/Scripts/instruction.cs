using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class instruction : MonoBehaviour {

	// Use this for initialization
	private string line1;
	private string line2;
	private string line3;
	private string line4;
	private string[] lines;

	void Awake(){
		lines = new string[37];
	}

	public void MainGame()
	{
		Text txt;
		txt = GameObject.Find("instructiontext").GetComponent<Text>();
		lines[1]= "1. Control the player movement with a finger on the joystick. \n";
		lines[2]= "2. Use another finger to rotate the player by pointing to the intended direction.\n";
		lines[3]= "3. Tap the screen to shoot. \n";
		//lines[4]= "4. Tap the quit button on the top right corner to go back to the main menu. \n";
		lines[4]= "5. Tap the player to show your lungs and the tactical breathing system. \n";
		lines[5]= "6. Tap the screen with three fingers to make them disappear\n";
		lines[6]="\nYour mission: \n";
		lines [7] = "You are a legend of the Canadian Armed Force. Three hostages are captured in three separated rooms and you must save them by entering into each room and playing the mental readiness game. " +
			"Once you successfully complete the game, the hostage will be released. " +
			"Zombies will attack you once every while, be calm, your gun is your best friend. \n";
		lines [8] = "\nYour heart beat will increase as you walk and shoot more. It would slow down slowly if you stay idle.\n";
		lines [9] = "1. Stop once a while to practice the tactical breathing";
		lines [10] = "2. Follow the lungs animation to breath in and out, you will see your heart beat being dropped in a big chunk after every successful cycle.\n";
		lines [11] = "3. Don’t forget to look out for the zombies, they find every possible opportunity to kill you.\n";								
		lines [12] = "*Heartbeat over 175bps kills you instantly. \n";								
		lines [13] = "*Once you get used to the tactical breathing, try to count the numbers in your head, 4 seconds in, 4 seconds out.\n";

		for (int i=0; i<14; i++) {
			line1+=lines[i];
		}

		txt.text = line1;
	}

	public void NBack()
	{
		Text txt;
		txt = GameObject.Find("instructiontext").GetComponent<Text>();

		lines[15]="N-Back\n";
		lines[16]="1. Start the game, one of the nine squares will lit up in a random order.\n";
		lines[17]="2. Remember which one of the nine squares lit up N steps ago and click it.\n";
		lines[18]="3. N will increase as you advance to the advanced level.\n";
		lines[19]="4. Failure of three times at any level will terminate the game.\n";
		lines[20]="5. Score will be awarded according to the game difficulty.\n";
		lines[21]="6. The quit button will take you back to the main menu.\n";

		for (int i=15; i<22; i++) {
			line2+=lines[i];
		}

		txt.text = line2;
	}
	public void Attention()
	{
		Text txt;
		txt = GameObject.Find("instructiontext").GetComponent<Text>();

		lines [22] = "Attention Control\n";
		lines [23] =	"1. Start the game, the six colored buttons will lit up in a sequence\n";
		lines [24] =	"2. Remember the sequence and reproduce it by tapping the buttons in the same order\n";
		lines [25] = "3. Number of elements in the sequence would increases as you advance to the next level\n";
		lines [26] = "4. Failure of three times at any level will terminate the game\n";
		lines [27] = "5. Score will be awarded according to the game difficulty\n";
		lines [28] =	"6. The Back button will take you back to the main menu\n";

		for (int i=22; i<29; i++) {
			line3+=lines[i];
		}
		txt.text = line3;
	}
	public void SelfTalk()
	{
		Text txt;
		txt = GameObject.Find("instructiontext").GetComponent<Text>();
		lines [29] = "Self-talk\n";
		lines [30] = "1. The avatar starts with negative thoughts\n";
		lines [31] = "2. Guide the avatar in breaking down their negative thoughts\n";
		lines [32] = "3. Type in the positive thoughts in the forms of key words/phrases using the virtual keyboard\n";
		lines [33] = "4. Only after breaking down their negative thoughts and forming a postive statement, the game will terminate.\n";
		lines [34] = "5. The more positve words, in the postive satement the higher the score. However, the more negative thoughts or words used the player will recieve low points.\n";
		lines [35] = "6. In addition, more points are awarded if the player is succesfully able to break down the avatar's negative statement\n";

		for (int i=29; i<36; i++) {
			line4+=lines[i];
		}
		txt.text = line4;
	}
}
