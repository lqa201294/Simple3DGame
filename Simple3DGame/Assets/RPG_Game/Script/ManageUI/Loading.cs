using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
	Text curState;
	Color startcolor;
	Color endcolor;

	// Use this for initialization
	void Start () {
		curState = GetComponent<Text> ();
		StartCoroutine (LoadScene(1));

		startcolor = new Color (1,1,1,0);
		endcolor = new Color (1,1,1,1);
	}

	void UpDate()
	{
		GetComponent<Text> ().color = Color.Lerp (startcolor, endcolor, Mathf.PingPong(Time.time,1));
	}

	IEnumerator LoadScene(int numScene)
	{
		yield return null;

		AsyncOperation ao = SceneManager.LoadSceneAsync (numScene);
		ao.allowSceneActivation = false;

		while(!ao.isDone)
		{
			float progress = Mathf.Clamp01 (ao.progress /0.9f);
			curState.text = "Loading..." + (int)(progress * 100)+ "%";

			//loading completed
			if(ao.progress == 0.9f)
			{
				curState.text= "Press a key to start";

				if (Input.anyKey)
				{
					ao.allowSceneActivation = true;
				}
			}

			yield return null;
		}
	}

}
