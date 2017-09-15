using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour {

	public static int Score;
	Text scoredisplay;

	// Use this for initialization
	void Awake () {
		Score = 0;
	}

}
