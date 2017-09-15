using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillX : MonoBehaviour {

	public int DefaultManaPotion = 10;
	public int MaxGetPotion = 30;

	public float Manarecover = 10f;
	public float cdtime; 
	public float maxcdtime = .5f;

	public Text numberPotion;
	public Image displaycdtime;

	public GameObject Player;
	public GameObject Notify;


	// Use this for initialization
	void Start () {
		cdtime = 0f;
		numberPotion.text = "x" + DefaultManaPotion.ToString ();
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


		if (Input.GetKeyDown (KeyCode.X) && Time.timeScale == 1) 
		{
			if (cdtime <= 0 && DefaultManaPotion > 0) 
			{
				UseHpPotion ();
			}
			else
			{
				Notify.SetActive (true);
				Notify.GetComponent<Text>().text ="Not enough MP Potion or in CD time!";
				StartCoroutine (HideNotify(2f));
			}
		}

		displaycdtime.fillAmount = cdtime / maxcdtime;

	}

	void UseHpPotion()
	{
		cdtime = maxcdtime;
		DefaultManaPotion--;

		numberPotion.text = "x" + DefaultManaPotion.ToString ();
		Player.GetComponent<ManaPlayer> ().ManaRecover (Manarecover);
	}

	public void GetMpPotion(int numpotion)
	{
		if (DefaultManaPotion < MaxGetPotion) 
		{
			DefaultManaPotion +=numpotion;
		}

		numberPotion.text = "x" + DefaultManaPotion.ToString ();
	}

	IEnumerator HideNotify(float time)
	{
		yield return new WaitForSeconds (time);
		Notify.SetActive (false);
	}
}
