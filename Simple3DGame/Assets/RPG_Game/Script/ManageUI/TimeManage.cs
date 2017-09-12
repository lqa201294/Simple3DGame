using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour {
	public float TimeRequired = 300f;
	public static float curTime;
	Text timeRemain;

	public float minutes;
	public float seconds;

	// Use this for initialization
	void Start () {
		curTime = TimeRequired;
		timeRemain = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (curTime >0) 
		{
			curTime -= Time.deltaTime;
		}

		minutes = (int)curTime / 60;
		seconds = (int)curTime % 60;
		timeRemain.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
