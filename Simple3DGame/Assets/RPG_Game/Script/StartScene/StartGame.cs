using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	public GameObject Loading;

	public void GameStart()
	{
		Loading.SetActive (true);
		Leaderboard.destroyself = true;

	}
}
