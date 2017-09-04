using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharName : MonoBehaviour {
	Text CharName;


	// Use this for initialization
	void Start () 
	{
		CharName = transform.GetChild (2).GetChild(0).GetComponent<Text>();

	}
	// Update is called once per frame
	void Update () 
	{
			CharName.text = SetNamePlayer.PlayerName;
	}
}
