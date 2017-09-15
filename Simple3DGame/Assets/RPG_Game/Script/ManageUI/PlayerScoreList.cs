using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {
	private List<ScoreEntry> Highscores;
	public GameObject Entry;
	string playername;
	float timeclear;

	// Use this for initialization
	void Start () {
		Highscores = new List<ScoreEntry> ();

		if (ReadJsonData.itemdata ["Items"].Count != 0) 
		{
			for(int j=0; j< ReadJsonData.itemdata["Items"].Count; j++)
			{
				Highscores.Add (new ScoreEntry()
					{
						name = ReadJsonData.itemdata["Items"][j]["name"].ToString(),
						timeclear =(double)ReadJsonData.itemdata["Items"][j]["timeclear"]
					});
			}

		}

		print (Highscores.Count);

		if (Highscores.Count != 0) 
		{
			SortScores ();

			for (int i = 0; i < Highscores.Count; i++) 
			{
				GameObject go = (GameObject)Instantiate (Entry);
				go.transform.SetParent (gameObject.transform, false);
				go.transform.GetChild (0).GetComponent<Text>().text = Highscores[i].name;
				go.transform.GetChild (1).GetComponent<Text> ().text = string.Format("{0:00}:{1:00}", (int)Highscores[i].timeclear /60, (int)Highscores[i].timeclear %60);
				go.transform.GetChild (2).GetComponent<Text> ().text = (i + 1).ToString();
			}


		}

	}

	public void SortScores()
	{
		if (Highscores.Count > 1) 
		{
			Highscores.Sort ((a,b) => a.timeclear.CompareTo(b.timeclear));
		}
	}

}
