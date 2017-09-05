using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpDemon : MonoBehaviour {
	public float currentHP;
	public float maxHP;
	public GameObject AuraEffect;
	public GameObject DropItem;


	public Image hpdisplay;
	public Text hpstatus;
	GameObject Player;
	int n;

	Animator anim;
	public static bool fury;

	// Use this for initialization
	void Start ()
	{
		GameObject go =  (GameObject)Instantiate (AuraEffect); 
		go.transform.SetParent (gameObject.transform,false);


		Player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();

		maxHP = 6 * float.Parse(ReadJsonData.itemdata ["Level"] [CallSmileArea.area]["Hp"].ToString());
		currentHP = maxHP;

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (fury) 
		{
			anim.SetBool ("fury", fury);
			fury = false;
		}


		hpdisplay.fillAmount = currentHP / maxHP;
		hpstatus.text = currentHP + "/" + maxHP;
	}

	void ChangeStatus()
	{
		anim.SetBool ("fury", fury);
	}


	public void GetDamage(float amount)
	{
		currentHP -= amount;

		if (currentHP <= 0) 
		{
			anim.SetTrigger ("dead");
			StartCoroutine (DelayDropItem(2f));

			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<DemonMove> ().enabled = false;
			GetComponent<DemonAttack> ().enabled = false;
			GetComponent<HpDemon> ().enabled = false;

		} 

		if (currentHP <= maxHP / 2 && n < 1) 
		{
			n++;
			fury = true;
		}

	}

	IEnumerator DelayDropItem(float time)
	{
		yield return new WaitForSeconds (time);
		Instantiate (DropItem, transform.position, Quaternion.identity); 
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Eskill") 
		{
			GetDamage (Player.GetComponent<PlayerAttack> ().Plattackdame * 2);
		}
	}


}
