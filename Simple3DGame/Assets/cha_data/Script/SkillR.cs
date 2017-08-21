using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillR : MonoBehaviour {
	public Image displayCDtime;
	public Text cdText;

	public float cdtime;
	public float maxcdtime = 60f;


	// Use this for initialization
	void Start () 
	{
		cdtime = 0f;	
	}
	
	// Update is called once per frame
	void Update () {
		if (cdtime > 0) 
		{
			cdtime -= Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			if (cdtime <= 0) 
			{
				CastUltiMate ();

			}
		}

		displayCDtime.GetComponent<Image> ().fillAmount = cdtime / maxcdtime;

		if (cdtime > 0)
		{
			cdText.enabled = true;
			cdText.GetComponent<Text> ().text = (Mathf.RoundToInt (cdtime)).ToString ();

		} else 
		{
			cdText.enabled = false;
		}
	}

	void CastUltiMate()
	{
		cdtime = maxcdtime;
	}
}
