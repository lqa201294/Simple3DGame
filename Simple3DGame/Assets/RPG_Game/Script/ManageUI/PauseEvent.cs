using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEvent : MonoBehaviour {
	public GameObject PausePanel;
	public GameObject SetPlayerName;

	void Start()
	{
		SetPlayerName.SetActive (true);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (PausePanel.activeSelf) 
			{
				Time.timeScale = 1;
				PausePanel.SetActive (false);

			}
			else 
			{
				PausePanel.SetActive (true);
				Time.timeScale = 0;
			}
		}

	}

	public void Resume()
	{
		PausePanel.SetActive (false);
		Time.timeScale = 1;
	}

	public void Exit()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}



}
