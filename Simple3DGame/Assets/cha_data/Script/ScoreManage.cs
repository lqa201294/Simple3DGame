using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour {

	public static int Score;
	Text scoredisplay;

	// Use this for initialization
	void Awake () {
		scoredisplay = GetComponent<Text> ();

		Score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoredisplay.text = "Score:" +" " + Score;
	}
}
