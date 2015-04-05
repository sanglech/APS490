﻿using UnityEngine;
using System.Collections;

public class LastPlayerSighting : MonoBehaviour {

	public Vector3 position = new Vector3(1000f,1000f,1000f);            // The Last global sighting of the player.
	public Vector3 resetPosition = new Vector3 (1000f, 1000f, 1000f);    // The default position if the player is not in sight.
	public float lightHighIntensity = 0.25f;						     // The directional light's intensity when the alarms are off.
	public float lightLowIntensity=0f;								     // The directional light's intensity when the alarms are on.
	public float fadeSpeed=7f;										     // How fast the light fades between low and high intensity.
	public float musicFadeSpeed = 1f;                                    // The speed at which the music fades between low and high.



	private AlarmLight alarm;                                            // Reference to the AlarmLight Script.
	private Light mainLight;                                             // Referene to the main Light.
	private AudioSource panicAudio;                                      // Reference to the AudioSource of the panic
	private AudioSource[] sirens;                                        // Reference to the AudioSources of the megaphones.


	void Awake()
	{
		alarm = GameObject.FindGameObjectWithTag (Tags.alarmLight).GetComponent<AlarmLight> ();
		mainLight = GameObject.FindGameObjectWithTag (Tags.mainLight).GetComponent<Light>();
		panicAudio = transform.Find ("secondaryMusic").GetComponent<AudioSource>();
		GameObject[] sirenGameObjects = GameObject.FindGameObjectsWithTag (Tags.siren);
		sirens = new AudioSource[sirenGameObjects.Length];

		for (int i=0; i<sirens.Length; i++) 
		{
			sirens[i]=sirenGameObjects[i].GetComponent<AudioSource>();
		}
	}
	void Update()
	{
		SwitchAlarms ();
		MusicFading ();
	}

	void SwitchAlarms()
	{
		alarm.alarmOn=position!=resetPosition;
		float newIntensity;

		if (position != resetPosition) 
		{
			newIntensity=lightLowIntensity;
		}
		else
		{
			newIntensity=lightHighIntensity;
		}

		mainLight.intensity = Mathf.Lerp (mainLight.intensity, newIntensity, fadeSpeed * Time.deltaTime);

		for(int i=0;i<sirens.Length;i++)
		{
			if(position!=resetPosition&&!sirens[i].isPlaying)
				sirens[i].Play();
			else if(position==resetPosition)
				sirens[i].Stop ();
		}
	}

	void MusicFading()
	{
		if(position!=resetPosition)
		{
			GetComponent<AudioSource>().volume=Mathf.Lerp(GetComponent<AudioSource>().volume,0f,musicFadeSpeed*Time.deltaTime);
			panicAudio.volume=Mathf.Lerp (GetComponent<AudioSource>().volume, 0.8f,musicFadeSpeed*Time.deltaTime);
		}

		else
		{
			GetComponent<AudioSource>().volume=Mathf.Lerp(GetComponent<AudioSource>().volume,0.8f,musicFadeSpeed*Time.deltaTime);
			panicAudio.volume=Mathf.Lerp (GetComponent<AudioSource>().volume, 0f,musicFadeSpeed*Time.deltaTime);
		}
	}
}