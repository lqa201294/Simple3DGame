using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpDemon : MonoBehaviour {
	public float currentHP;
	public float maxHP;
	float getpldamage;

	public Image hpdisplay;
	public Text hpstatus;

	Animator anim;
	public static bool fury;

	// Use this for initialization
	void Start ()
	{
		
		anim = GetComponent<Animator> ();

		maxHP = 6 * float.Parse(ReadJsonData.itemdata ["Level"] [CallSmileArea.area]["Hp"].ToString());
		currentHP = maxHP;

	}
	
	// Update is called once per frame
	void Update ()
	{

		hpdisplay.fillAmount = currentHP / maxHP;
		hpstatus.text = currentHP + "/" + maxHP;
	}


	public void GetDamage(float amount)
	{
		getpldamage = amount;
		currentHP -= amount;

		if (currentHP <= 0) 
		{
			anim.SetTrigger ("dead");
		} 
		else if (currentHP <= maxHP / 2) 
		{
			anim.SetTrigger ("fury");
			fury = true;
		}
			 
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Eskill") 
		{
			currentHP -= 2* getpldamage; 
		}
	}

}
