using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class menu : MonoBehaviour {
	
	// Use this for initialization

	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;

	}
	
	// Update is called once per frame
	void Update () {
		
		
		/*Image hi;
		hi = GameObject.Find("Image").GetComponent<Image>();
		hi.enabled = !hi.enabled;*/
	}

	public void load_mainGame()
	{
		Application.LoadLevel ("MainGame");
		
	}

	public void load_mem()
	{
		Application.LoadLevel ("AttentionControl");
	
	}

	public void load_selfTalk()
	{
		Application.LoadLevel ("SelfTalk");
		
	}

	public void load_nback()
	{
		Application.LoadLevel ("Memory");
		
	}

	public void load_achievement()
	{
		Application.LoadLevel ("Achievements");
		
	}

	public void load_store()
	{
		Application.LoadLevel ("Store");
		
	}
	public void quit()
	{
		Application.Quit();
	}
}
