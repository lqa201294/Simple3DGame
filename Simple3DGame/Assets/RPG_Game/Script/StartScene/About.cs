using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class About : MonoBehaviour {
	public GameObject InfoPanel;

	public void ShowInfo()
	{
		InfoPanel.SetActive (true);

	}
		
	public void Back()
	{
		InfoPanel.SetActive (false);
	}
	
}
