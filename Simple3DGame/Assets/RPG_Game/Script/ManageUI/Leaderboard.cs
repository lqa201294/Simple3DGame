using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour {
	public static List<ScoreEntry> Entries = new List<ScoreEntry>();
	public static bool destroyself;

	// Use this for initialization
	void Start () {
		destroyself = false;
		DontDestroyOnLoad (gameObject);
	
	}

	void Update()
	{
		if (destroyself) 
		{
			destroyself = false;
			Destroy (gameObject);
		}
	}





}
