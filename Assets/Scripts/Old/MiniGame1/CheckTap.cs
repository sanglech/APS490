using UnityEngine;
using System.Collections;

//Adding random comment to test github.
public class CheckTap : MonoBehaviour {

	// Update is called once per frame

	public bool clickDetected=false;
	public Vector3 touchPosition;

	void Update () {

		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) 
		{
			clickDetected=(Input.touchCount>0&& Input.GetTouch(0).phase==TouchPhase.Began);
			touchPosition=Input.GetTouch(0).position;
			TapControl(touchPosition);
		}
		else
		{
			clickDetected=Input.GetMouseButtonDown(0);
			touchPosition = Input.mousePosition;
			TapControl(touchPosition);
		}
	
	}

	void TapControl(Vector3 pos)
	{
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos= new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);

		if(hit){
			Debug.Log(hit.transform.gameObject.tag);
			HealthScript enemeyHP= hit.gameObject.GetComponent<HealthScript>();
			enemeyHP.Damage(10);
			//hit.transform.gameObject.SendMessage('Clicked',0,SendMessageOptions.DontRequireReceiver);
		}
	}
}
