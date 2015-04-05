using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;

public class OutCheck : MonoBehaviour {
	//public float bbb =1f;
	public GameObject breathin; 
	Stopwatch stopwatch1 = new Stopwatch ();
	// Use this for initialization
	public  double timer1 = 0.0;
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
			if(hit.collider.tag == "breathout"){
				//Debug.Log ("YOYO");
				if (Input.GetMouseButtonDown (0)) {
					//animation.Play ("BreathClip");
					//var In = GameObject.FindGameObjectWithTag ("breathin");
					//In.gameObject.renderer.material.color = new Color(R, G, B, A);
					//Debug.Log(stopwatch.Elapsed);
					stopwatch1.Reset();
					stopwatch1.Start();
					//timer = stopwatch1.Elapsed.TotalSeconds;
					//UnityEngine.Debug.Log ("testtttt->"+timer);
					//stopwatch.Start();
					//Debug.Log ("cliiiick");
					Renderer rend = GetComponent<Renderer>();
					Color color = rend.material.color;
					color.r = 0.5f;
					rend.material.color = color;


					GameObject In = GameObject.FindGameObjectWithTag ("breathin");
					//Renderer rend1 = GetComponent<Renderer>();
					if(In.GetComponent<Renderer>().material.color.r==0.5f){
						//Debug.Log ("father");
						In.GetComponent<InCheck>().test();
					}
				
					
					//Color color = ;
					//rend.material.SetColor("_TintColor", color);
					//gameObject.renderer.color.a = 0.5;
					
					
				} 
			}
		}
	}
	public void test1(){
		Renderer rend = GetComponent<Renderer>();
		Color color = rend.material.color;
		color.r = 1f;
		rend.material.color = color;
	}
	public double total(){
		return stopwatch1.Elapsed.TotalSeconds;
	}


}
