using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillW : MonoBehaviour {
	public Healthplayer healthpl;
	public GameObject healthparticle;

	public float HpRecover = 10f;
	public float cdtime ;
	public float maxcdtime = 20f;
	public Image cddisplay;
	public Text cdText;

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

		if (Input.GetKeyDown (KeyCode.W)) 
		{
			if (cdtime <= 0) 
			{
				CastSkillW ();
			}
		}
			
		cddisplay.GetComponent<Image> ().fillAmount = cdtime / maxcdtime;

		if (cdtime > 0) 
		{
			cdText.enabled = true;
			cdText.GetComponent<Text> ().text = (Mathf.RoundToInt (cdtime)).ToString ();
		}
		else
		{
			cdText.enabled = false;
		}
	}

	void CastSkillW()
	{
		cdtime = maxcdtime;
		healthpl.RecoverHealth (HpRecover);
	}
}
