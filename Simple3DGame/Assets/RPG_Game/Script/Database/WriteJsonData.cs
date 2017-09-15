using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;

public class WriteJsonData : MonoBehaviour {
	public static string playerjson;
	public static ScoreEntry player;
	public static List<ScoreEntry> board;

	public static JsonData itemdata;
	private string jsonString;


	void Start()
	{
		board = new List<ScoreEntry> ();
		if(File.Exists (Application.dataPath + "/LeaderBoard.json"))
		{
			jsonString = File.ReadAllText(Application.dataPath + "/LeaderBoard.json");
			itemdata = JsonMapper.ToObject (jsonString);
		}
			
		if (itemdata != null) 
		{
			for(int i = 0; i< itemdata["Items"].Count; i++)
			{
				board.Add (new ScoreEntry()
					{
						name =	itemdata ["Items"] [i] ["name"].ToString (),
						timeclear =(double)itemdata ["Items"] [i] ["timeclear"]
					});
			}
		}
			
		print (board.Count);
	}

	public static void SaveData()
	{
		board.Add (new ScoreEntry()
			{
				name =	SetNamePlayer.PlayerName,
				timeclear =(double)TimeManage.curTime
			});
		
		playerjson = JsonHelper.ToJson (board.ToArray());
		File.WriteAllText (Application.dataPath + "/LeaderBoard.json", playerjson);
		print (playerjson);

		#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
		#endif
	}
	
	public static class JsonHelper
	{
		public static T[] FromJson<T>(string json)
		{
			Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
			return wrapper.Items;
		}

		public static string ToJson<T>(T[] array)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
			wrapper.Items = array;
			return JsonUtility.ToJson(wrapper);
		}

		public static string ToJson<T>(T[] array, bool prettyPrint)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
			wrapper.Items = array;
			return JsonUtility.ToJson(wrapper, prettyPrint);
		}

		[Serializable]
		private class Wrapper<T>
		{
			public T[] Items;
		}
	}

}
