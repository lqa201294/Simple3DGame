using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillC : MonoBehaviour {
	
	public float Cdtime;
	public float maxCdtime = 10f;
	public float manaCost = 20f;

	public Image CdDisplay;
	public Text CdText;

	public GameObject skill;
	public GameObject Player;
	public GameObject Notify;

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
			CdText.enabled = true;
			CdText.GetComponent<Text> ().text = (Mathf.RoundToInt (Cdtime)).ToString ();
		}
		else
		{
			CdText.enabled = false;
		}
			
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			if (Cdtime <= 0 && manaCost <= Player.GetComponent<ManaPlayer> ().curMana) 
			{
				CastSkillE ();
			} 
			else if (Cdtime > 0) 
			{
				Notify.SetActive (true);
				Notify.GetComponent<Text>().text = "After" +" "+Mathf.RoundToInt(Cdtime) +" "+ "s you can cast skill";
				StartCoroutine (HideNotify(2f));
			} 
			else if (manaCost > Player.GetComponent<ManaPlayer> ().curMana) 
			{
				Notify.SetActive (true);
				Notify.GetComponent<Text>().text = "Not enough mana!";
				StartCoroutine (HideNotify(2f));
			}
		}

		CdDisplay.GetComponent<Image> ().fillAmount = Cdtime / maxCdtime;


	}


	void CastSkillE()
	{
		Player.GetComponent<ManaPlayer> ().SpendMana (manaCost);
		Cdtime = maxCdtime;

		float angleY = Player.transform.eulerAngles.y + skill.transform.eulerAngles.y;

		Instantiate (skill, Player.transform.position + new Vector3(0f,0.3f,0f), Quaternion.Euler(-90f, angleY, 0f));
	
	}

	IEnumerator HideNotify(float time)
	{
		yield return new WaitForSeconds (time);
		Notify.SetActive (false);
	}

}
