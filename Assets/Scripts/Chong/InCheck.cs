using UnityEngine;
using System.Collections;
using System.Diagnostics;
//using System.Threading;

public class InCheck : MonoBehaviour {

	//public static LayerMask sprit = 1 << 2;
	//Debug.Log(LayerMask.GetMask("UserLayerA"));
	// Use this for initialization
	public GameObject breathout; 
	Stopwatch stopwatch = new Stopwatch ();
	public  double timer = 0.0;
	//public static float aaa =1f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		//Debug.Log ("here");
		if(Physics.Raycast(ray,out hit, Mathf.Infinity)){
			//Debug.Log (hit.transform.gameObject.layer);
			//Debug.Log (hit.collider.name);
			if(hit.collider.tag == "breathin"){
				//Debug.Log ("YOYO");
				if (Input.GetMouseButtonDown (0)) {
					//animation.Play ("BreathClip");
					//var In = GameObject.FindGameObjectWithTag ("breathin");
					//In.gameObject.renderer.material.color = new Color(R, G, B, A);
					
					//Debug.Log ("cliiiick");
					Renderer rend = GetComponent<Renderer>();
					Color color = rend.material.color;
					color.r = 0.5f;
					rend.material.color = color;
					GameObject In = GameObject.FindGameObjectWithTag ("breathout");
					//Renderer rend1 = GetComponent<Renderer>();
					if(In.GetComponent<Renderer>().material.color.r==0.5f){
						//Debug.Log ("mother");
						In.GetComponent<OutCheck>().test1();
					}

					//Debug.Log(stopwatch.Elapsed);
					timer = stopwatch.Elapsed.TotalSeconds;
					double total = In.GetComponent<OutCheck>().total();
					double a = timer - total;
					//double b = timer - a;
					UnityEngine.Debug.Log ("In->"+a);
					UnityEngine.Debug.Log ("Out->"+ total);
					if(a>3.5&&a<4.3&&total>2.3&&total<3){
						if(SWP_HeartRateMonitor.Instance.BeatsPerMinute-60>=20)
						SWP_HeartRateMonitor.Instance.BeatsPerMinute -=20;
						//else SWP_HeartRateMonitor.Instance.BeatsPerMinute=60;
					};
					stopwatch.Reset();
					stopwatch.Start();
					//if(In.GetComponent<OutCheck>().timer>=3.0f&&In.GetComponent<OutCheck>().timer<=5.0f){
						//if(timer>=3.0f&&timer<=5.0f){
				//	Debug.Log ("Relaaaaax");
						//}
					//}
					//timer = 0.0f;
				
					
					
					//Color color = ;
					//rend.material.SetColor("_TintColor", color);
					//gameObject.renderer.color.a = 0.5;
					
					
				} 
			}
		}
	}

	public void test(){
		Renderer rend = GetComponent<Renderer>();
		Color color = rend.material.color;
		color.r = 1f;
		rend.material.color = color;
	}


}
