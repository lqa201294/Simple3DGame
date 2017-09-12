using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpDemon : MonoBehaviour {
	public float currentHP;
	public float maxHP;
	public GameObject[] AuraEffect;
	public GameObject DropItem;
	public GameObject demonEffect;


	public Image hpdisplay;
	public Text hpstatus;
	GameObject Player;
	int n;

	Animator anim;
	public static bool fury;

	// Use this for initialization
	void Start ()
	{
		GameObject go =  (GameObject)Instantiate (AuraEffect[Random.Range(0, AuraEffect.Length)]); 
		go.transform.SetParent (gameObject.transform,false);

		GameObject effect = (GameObject)Instantiate (demonEffect);
		effect.transform.SetParent (gameObject.transform, false);
		effect.transform.localScale = new Vector3 (3,3,6);

		switch (CallSmileArea.area) 
		{
		case 0: 
			ParticleSystem.MainModule setting	= effect.GetComponent<ParticleSystem> ().main;
			setting.startColor = Color.green;
			break;
		case 1:
			ParticleSystem.MainModule setcolor	= effect.GetComponent<ParticleSystem> ().main;
			setcolor.startColor = Color.yellow;
			break;
		case 2:
			ParticleSystem.MainModule set	= effect.GetComponent<ParticleSystem> ().main;
			set.startColor = Color.white;
			break;
		case 3:
			ParticleSystem.MainModule setcl	= effect.GetComponent<ParticleSystem> ().main;
			setcl.startColor = Color.red;
			break;
		}


		Player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();

		maxHP = 6 * float.Parse(ReadJsonData.itemdata ["Level"] [CallSmileArea.area]["Hp"].ToString());
		currentHP = maxHP;

	}
	
	// Update is called once per frame
	void Update ()
	{

//		if (fury) 
//		{
//			anim.SetBool ("fury", fury);
//			fury = false;
//		}

		if (currentHP < 0) 
		{
			currentHP = 0;
		}

		hpdisplay.fillAmount = currentHP / maxHP;
		hpstatus.text = currentHP + "/" + maxHP;
	}

//	void ChangeStatus()
//	{
//		anim.SetBool ("fury", fury);
//	}


	public void GetDamage(float amount)
	{
		currentHP -= amount;

		if (currentHP <= 0) 
		{
			anim.Play ("Death");

			StartCoroutine (DelayDropItem(3f));
			Destroy (transform.GetChild (4).gameObject);
			Destroy (transform.GetChild (3).gameObject);

			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<DemonMove> ().enabled = false;
			GetComponent<DemonAttack> ().enabled = false;
		

		} 

		if (currentHP <= maxHP / 2 && n < 1) 
		{
			n++;
			anim.Play ("Fury");
			//fury = true;
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
