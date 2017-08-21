using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillE : MonoBehaviour {
	public Image displayCDtime;
	public Text CdText;
	public float cdtime;
	public float maxcdtime = 30f;

	public GameObject Shield;
	public GameObject Player;
	public SmileAttack sAttack;

	public bool absorbDamage;

	// Use this for initialization
	void Start () 
	{
		cdtime = 0f;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cdtime > 0) 
		{
			cdtime -= Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			if (cdtime <= 0) 
			{
				CastShield ();
			}

		}
			
		displayCDtime.GetComponent<Image> ().fillAmount = cdtime / maxcdtime;

		if (cdtime > 0)
		{
			CdText.enabled = true;
			CdText.GetComponent<Text> ().text = (Mathf.RoundToInt (cdtime)).ToString ();
		}
		else
		{
			CdText.enabled = false;
		}

		if (Player.transform.Find ("Shield(Clone)") == null)
		{
			absorbDamage = false;
		}
			
	}

	void CastShield()
	{
		cdtime = maxcdtime;
		absorbDamage = true;

		GameObject go =  (GameObject)Instantiate (Shield, Player.transform.position + new Vector3(0f,2f,0f), Quaternion.identity);
		go.transform.SetParent (Player.transform);

	}
}
