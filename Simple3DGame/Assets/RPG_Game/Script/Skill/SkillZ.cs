using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillZ : MonoBehaviour {
	public int DefaultHpPotion = 10;
	public int MaxGetPotion = 30;

	public float hprecover = 10f;
	public float cdtime; 
	public float maxcdtime = .5f;

	public Text numberPotion;
	public Image displaycdtime;

	public GameObject Player;
	public GameObject Notify;


	// Use this for initialization
	void Start () {
		cdtime = 0f;
		numberPotion.text = "x" + DefaultHpPotion.ToString ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cdtime > 0) 
		{
			cdtime -= Time.deltaTime; 
		}
		else
		{
			cdtime = 0f;
		}

	
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			if (cdtime <= 0 && DefaultHpPotion > 0) 
			{
				UseHpPotion ();
			}
			else
			{
				Notify.SetActive (true);
				Notify.GetComponent<Text>().text = "Not enough HP Potion!";
				StartCoroutine (HideNotify(2f));
			}
		}

		displaycdtime.fillAmount = cdtime / maxcdtime;

	}

	void UseHpPotion()
	{
		cdtime = maxcdtime;
		DefaultHpPotion--;

		numberPotion.text = "x" + DefaultHpPotion.ToString ();
		Player.GetComponent<Healthplayer> ().RecoverHealth (hprecover);
	}

	public void GetHpPotion(int numpotion)
	{
		if (DefaultHpPotion < MaxGetPotion) 
		{
			DefaultHpPotion +=numpotion;
		}

		numberPotion.text = "x" + DefaultHpPotion.ToString ();
	}

	IEnumerator HideNotify(float time)
	{
		yield return new WaitForSeconds (time);
		Notify.SetActive (false);
	}

}
