using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillQ : MonoBehaviour {
	public GameObject skill;
	public float Cdtime;
	public float maxCdtime = 10f;
	public Image CdDisplay;
	public Text CdText;

	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
		Cdtime = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Cdtime > 0) 
		{
			Cdtime -= Time.deltaTime;
		}
			
		if(Input.GetKeyDown(KeyCode.Q))
			{
				if (Cdtime <= 0)
				{
					CastSkillQ ();
				}

			}

		CdDisplay.GetComponent<Image> ().fillAmount = Cdtime / maxCdtime;

		if (Cdtime <= 0) 
		{
			CdText.enabled = false;
		}
		else
		{
			CdText.enabled = true;
			CdText.GetComponent<Text> ().text = (Mathf.RoundToInt (Cdtime)).ToString ();
		}

	}


	void CastSkillQ()
	{
		Cdtime = maxCdtime;

		float angleY = Player.transform.eulerAngles.y + skill.transform.eulerAngles.y;

		Instantiate (skill, Player.transform.position + new Vector3(0f,0.3f,0f), Quaternion.Euler(-90f, angleY, 0f));
	
	}

}
