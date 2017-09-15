using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillV : MonoBehaviour {
	public Image displayCDtime;
	public Text CdText;
	public float cdtime;
	public float maxcdtime = 30f;
	public float manaCost = 20f;

	public GameObject Shield;
	public GameObject Player;
	public GameObject Notify;

	public static bool absorbDamage;

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
			CdText.enabled = true;
			CdText.GetComponent<Text> ().text = (Mathf.RoundToInt (cdtime)).ToString ();
		}
		else 
		{
			CdText.enabled = false;
		}


		if (Input.GetKeyDown (KeyCode.V) && Time.timeScale == 1) 
		{
			if (cdtime <= 0 && manaCost < Player.GetComponent<ManaPlayer>().curMana) 
			{
				CastShield ();
			}
			else if (cdtime > 0) 
			{
				Notify.SetActive (true);
				Notify.GetComponent<Text>().text = "After" +" "+Mathf.RoundToInt(cdtime) +" "+ "s you can cast skill";
				StartCoroutine (HideNotify(2f));
			} 
			else if (manaCost > Player.GetComponent<ManaPlayer> ().curMana) 
			{
				Notify.SetActive (true);
				Notify.GetComponent<Text>().text = "Not enough mana!";
				StartCoroutine (HideNotify(2f));
			}

		}
			
		displayCDtime.GetComponent<Image> ().fillAmount = cdtime / maxcdtime;

	
			
	}

	void CastShield()
	{
		Player.GetComponent<ManaPlayer> ().SpendMana (manaCost);

		cdtime = maxcdtime;
		absorbDamage = true;

		GameObject go =  (GameObject)Instantiate (Shield, Player.transform.position + new Vector3(0f,2f,0f), Quaternion.identity);
		go.transform.SetParent (Player.transform);

	}

	IEnumerator HideNotify(float time)
	{
		yield return new WaitForSeconds (time);
		Notify.SetActive (false);
	}

}
