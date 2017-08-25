using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


public class ReadJsonData : MonoBehaviour {
	public static JsonData itemdata;
	private string jsonString;
	private TextAsset file;

	// Use this for initialization
	void Awake () {
		file = Resources.Load ("AreaInfo") as TextAsset;
		jsonString = file.ToString ();
		itemdata = JsonMapper.ToObject (jsonString);
	}
}
