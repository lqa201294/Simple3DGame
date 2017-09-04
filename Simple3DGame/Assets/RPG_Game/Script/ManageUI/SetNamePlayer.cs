using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetNamePlayer : MonoBehaviour {
	public GameObject SetNameBoard;
	public InputField inputname;

	public static string PlayerName;

	void Start()
	{
		Time.timeScale = 0;
	}

	public void setCharName()
	{
		if (inputname.text != "") 
		{
			PlayerName = inputname.text;
		}
		else
		{
			PlayerName = "Noname";
		}

		Time.timeScale = 1;

		SetNameBoard.SetActive (false);
	}

}
