using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLeaderBoard : MonoBehaviour {
	public GameObject leaderboard;

	public void showLeaderboard()
	{
		leaderboard.SetActive (true);
	}

	public void back()
	{
		leaderboard.SetActive (false);
	}
}

