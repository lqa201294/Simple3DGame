using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;


public class ReadJsonData : MonoBehaviour {
	public static JsonData itemdata;
	private string jsonString;
	private TextAsset file;

	// Use this for initialization
	void Awake () {
		
		if (SceneManager.GetActiveScene ().buildIndex == 0) 
		{
			if(File.Exists (Application.dataPath + "/LeaderBoard.json"))
			{
				jsonString = File.ReadAllText(Application.dataPath + "/LeaderBoard.json");
				itemdata = JsonMapper.ToObject (jsonString);
			}
		}

		else if(SceneManager.GetActiveScene ().buildIndex == 1)
		{
			file = Resources.Load ("AreaInfo") as TextAsset;
			jsonString = file.ToString ();
			itemdata = JsonMapper.ToObject (jsonString);
		}
	}
}
